using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using EPICCentral.Models;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.LinqSupportClasses.ExpressionClasses;

public static class QueryableExtensions
{
    /// <summary>
    /// Generates an expression to extract properties to sort by.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="type"></param>
    /// <param name="columns"></param>
    /// <param name="sorts"> </param>
    /// <returns></returns>
    public static IOrderedQueryable<TEntity> Sort<TEntity>(this IQueryable<TEntity> source, ColumnCollection<TEntity> columns, IEnumerable<DataTablesRequestModel.Sort> sorts)
    {
        IOrderedQueryable<TEntity> resultOrdered = null;
        var parameter = Expression.Parameter(typeof(TEntity), "m");

        // get the columns set to valid properties
        Dictionary<DataTableColumn<TEntity>, KeyValuePair<MemberExpression, ParameterExpression>> collections;
        var validColumns = GetMemberExpressions(columns, parameter, out collections);

        // loop through each sort and create the IQuerable for each sorted column, defaults to 1 column
        foreach (var sort in sorts)
        {
            if (sort.iSortCol >= 0 && sort.iSortCol < columns.Count())
            {
                // select the member access based on iSortCol index
                var expression = validColumns.Where(x => x.Key == columns[sort.iSortCol]);
                if (expression.Any())
                {
                    // get the IQueryable method that matches the argument count
                    MethodInfo method = null;
                    if (sort.sSortDir.ToLower() == "asc")
                        method = typeof(Queryable).GetMethods().First(x => x.Name == "OrderBy" && x.GetParameters().Count() == 2);
                    else // sort descending
                        method = typeof(Queryable).GetMethods().First(x => x.Name == "OrderByDescending" && x.GetParameters().Count() == 2);

                    // create the lambda expression
                    var body = expression.First().Value;
                    var lambda = Expression.Lambda(body, new[] { parameter });

                    resultOrdered = (IOrderedQueryable<TEntity>)source.Provider.CreateQuery<TEntity>(
                        Expression.Call(
                            null,
                            method.MakeGenericMethod(typeof(TEntity), body.Type),
                            new[] { resultOrdered == null ? source.Expression : resultOrdered.Expression, Expression.Quote(lambda) }
                            ));
                }
            }
        }

        // no valid columns were sorted
        if (resultOrdered == null)
            throw new ArgumentException("Invalid columns.", "columns");

        return resultOrdered;
    }

    /// <summary>
    /// Generates an expression to pass to IQueryable functions, just like LINQ syntax but done with code.
    /// TODO: Optimization marks the only filter done on properties based on types
    /// TODO: Split term marks where search terms are split in to seperate matches rather than the whole string
    /// TODO: NOT marks there search terms are marked with a ! and the inverse is used
    /// TODO: Search terms marks where terms can be input in two formats, using ColumnName:term, or the search enumerable parameter from the datatables model
    /// </summary>
    /// <param name="source"></param>
    /// <param name="columns"></param>
    /// <param name="search"></param>
    /// <param name="useIndexOf"> </param>
    /// <returns></returns>
    public static IQueryable<TEntity> Search<TEntity>(this IQueryable<TEntity> source, IEnumerable<DataTableColumn<TEntity>> columns, string search, bool useIndexOf = false)
    {
        // this parameter is created for passing the TEntity in to when the query is evaluated
        var parameter = Expression.Parameter(typeof(TEntity), "m");

        // this is the method used below to determine if a property contains the search terms
        var containsMethod = typeof(string).GetMethod("Contains");

        // get the columns set to valid properties
        Dictionary<DataTableColumn<TEntity>, KeyValuePair<MemberExpression, ParameterExpression>> collections;
        /* Also supports
         * x => x.UserAssignedLocations.Any(y => y.Name.IndexOf("search") != -1)
         */
        var validColumns = GetMemberExpressions(columns, parameter, out collections).Where(x => x.Key.CanSearch);
        Dictionary<DataTableColumn<TEntity>, List<string>> columnTerms;
        Dictionary<DataTableColumn<TEntity>, List<string>> columnExclusions;
        GetSearchTerms(validColumns.Select(x => x.Key), search, out columnTerms, out columnExclusions);

        // create an expression to pass to the IQueryable.Where<>() function
        Expression termOr = null;
        Expression excAnd = null;
        foreach (var validColumn in validColumns)
        {
            if(!columnTerms.ContainsKey(validColumn.Key))
                continue;
            var terms = columnTerms[validColumn.Key].Distinct().Where(x => x.Trim() != "");
            var property = validColumn.Value;

            // if validColumn is a collection of items create the search on the inner expression and handle it below
            if (collections != null && collections.ContainsKey(validColumn.Key))
            {
                property = collections[validColumn.Key].Key;
            }

            // TODO: handles Nullable<> types and converts them to their object types
            MemberExpression nullableProperty = null;
            if (property.Type.IsGenericType && property.Type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                nullableProperty = property;
                property = Expression.MakeMemberAccess(property, property.Type.GetProperty("Value"));
            }

            TypeCode typeCode = Type.GetTypeCode(property.Type);
            
            // TODO: Optimization
            // determine if search string is numeric, used to match types below
            decimal outVar;
            var isNumeric = terms.Any(x => decimal.TryParse(x, out outVar));

            // if search string is not numeric but the column is, they will never match
            if (!isNumeric && !(
                // this list is object, strings, and all the other special cases handled below
                //  this is supposed to be everything except numeric types
                typeCode == TypeCode.Object || typeCode == TypeCode.Char || typeCode == TypeCode.String ||
                                typeCode == TypeCode.DateTime || typeCode == TypeCode.Boolean || property.Type.IsEnum))
                continue;

            foreach (var term in terms)
            {
                Expression right = null;

                // if the property if not of type string, convert it, all LLBLGen properties should be a primitive type
                if (property.Type != typeof(string))
                {
                    if (property.Type == typeof(Boolean))
                    {
                        // TODO: translate true and false
                        if (true.ToString().ToLower().Contains(term.ToLower()))
                            right = Expression.Equal(property, Expression.Constant(true)); //(Expression<Func<bool, bool>>)(p => p);
                        if (false.ToString().ToLower().Contains(term.ToLower()))
                            right = right != null
                                        ? Expression.OrElse(right,
                                                            Expression.Equal(property, Expression.Constant(false)))
                                        : Expression.Equal(property, Expression.Constant(false));
                    }
                    else if (property.Type.IsEnum)
                    {
                        // TODO: translate enums
                        // convert the Enum to string and search the string for the text
                        var matches =
                            Enum.GetNames(property.Type)
                                .Select(x =>
                                            {
                                                return new KeyValuePair<string, string>(x,
                                                                                 (Enum.Parse(property.Type, x) as Enum).
                                                                                     GetDisplayText());
                                            })
                                .Where(x => x.Value.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) > -1)
                                .Select(x => Enum.Parse(property.Type, x.Key, true));

                        // loop through each matches enum value and search for that
                        var enumType = Enum.GetUnderlyingType(property.Type);
                        foreach (var match in matches)
                        {
                            right = right != null
                                        ? Expression.OrElse(right,
                                                            Expression.Equal(Expression.Convert(property, enumType),
                                                                             Expression.Constant(
                                                                                 Convert.ChangeType(match,
                                                                                                    enumType))))
                                        : Expression.Equal(Expression.Convert(property, enumType),
                                                           Expression.Constant(Convert.ChangeType(match, enumType)));
                        }
                    }
                    else if (property.Type == typeof(DateTime))
                    {
                        MethodCallExpression access = null;
                        var method = typeof(DateTime).GetMethod("ToString", new Type[] { });
                        if (validColumn.Key.Format != null && validColumn.Key.Format.Body.ToString().Contains("ConvertTime"))
                        {
                            // TODO: Localize to user's time
                            var addhours = typeof(DateTime).GetMethod("AddHours", new[] { typeof(double) });
                            var timezone = ((TimeZoneInfo)HttpContext.Current.Items["TimeZoneInfo"]);
                            access = Expression.Call(
                                Expression.Call(
                                    property,
                                    addhours,
                                    Expression.Constant((double) timezone.BaseUtcOffset.Hours)),
                                method,
                                null);
                            // convert the object to a string and test for the search string
                            /*
                            // use the daylight savings time rule to modify the time server side and look for matches
                            // adjust for timezone
                            // adjust for daylight savings time
                            foreach(var rule in timezone.GetAdjustmentRules())
                            {
                                // if date >= DaylightTransitionStart && date <= DaylightTransitionEnd
                                var startEnd = Expression.AndAlso(
                                    Expression.GreaterThanOrEqual(property,
                                                                  Expression.Constant(rule.DaylightTransitionStart)),
                                    Expression.LessThanOrEqual(property, Expression.Constant(rule.DaylightTransitionEnd)));
                                // if condition then use BaseUtcOffset + DaylightDelta
                                conditional = Expression.IfThenElse(startEnd, 
                                    Expression.Call(property, addhours, Expression.Constant((double)timezone.BaseUtcOffset.Hours +
                                    rule.DaylightDelta.Hours)), conditional);
                            }
                            access = Expression.Call(access, method, null);
                        */
                        }
                        else
                            access = Expression.Call(property, method, null);
                        // search for term
                        if (useIndexOf)
                        {
                            var indexOf = Expression.Call(access, "IndexOf", null,
                                                            Expression.Constant(term, typeof (string)),
                                                            Expression.Constant(StringComparison.OrdinalIgnoreCase));
                            right = Expression.NotEqual(indexOf, Expression.Constant(-1));
                        }
                        else
                        {
                            right = Expression.Call(access, containsMethod,
                                                    Expression.Constant(term, typeof (string)));
                        }
                    }
                    else
                    {
                        // convert the object to a string and test for the search string
                        var method = typeof(Convert).GetMethod("ToString", new[] { property.Type });
                        var access = Expression.Call(null, method, property);
                        if (method != null)
                        {
                            if (useIndexOf)
                            {
                                var indexOf = Expression.Call(access, "IndexOf", null,
                                                              Expression.Constant(term, typeof (string)),
                                                              Expression.Constant(StringComparison.OrdinalIgnoreCase));
                                right = Expression.NotEqual(indexOf, Expression.Constant(-1));
                            }
                            else
                            {
                                right = Expression.Call(access, containsMethod,
                                                        Expression.Constant(term, typeof (string)));
                            }
                        }
                    }
                }
                else
                {
                    // already a string, just perform IndexOf()
                    if (useIndexOf)
                    {
                        var indexOf = Expression.Call(property, "IndexOf", null,
                                                      Expression.Constant(term, typeof (string)),
                                                      Expression.Constant(StringComparison.OrdinalIgnoreCase));
                        right = Expression.NotEqual(indexOf, Expression.Constant(-1));
                    }
                    else
                    {
                        right = Expression.Call(property, containsMethod, Expression.Constant(term, typeof(string)));

                    }
                }

                // TODO: handles Nullable<> types and converts them to their object types
                if (nullableProperty != null && right != null)
                {
                    // x => x.HasValue && right
                    right =
                        Expression.AndAlso(
                            Expression.Equal(
                                Expression.MakeMemberAccess(nullableProperty,
                                                            nullableProperty.Type.GetProperty("HasValue")),
                                Expression.Constant(true)),
                            right);
                }

                // TODO Collections matches Any() in collections
                if (collections != null && right != null && collections.ContainsKey(validColumn.Key))
                {
                    var objectType =
                        validColumn.Value.Type.GenericImplementsType(typeof (IEnumerable<>)).GetGenericArguments()[0];

                    var funcType = typeof (Func<,>).MakeGenericType(objectType, typeof (bool));
                    var any =
                        typeof (Enumerable).GetMethods().First(x => x.Name == "Any" && x.GetParameters().Count() == 2);
                    /*
                     * Func<objectType,bool> = x => collections[validColumn.Key].IndexOf(search) != -1
                     */
                    var newParam = collections[validColumn.Key].Value;
                    var lambda = (Expression) Expression.Lambda(funcType, right, newParam);

                    /*
                     * validColumn.Value.Any(Func<objectType,bool)
                     */
                    right = Expression.Call(
                        null,
                        any.MakeGenericMethod(objectType),
                        new[] {validColumn.Value, lambda});
                }

                // TODO: NOT operations to the oposite and are ANDed together rather than ORed
                // null can occur if the property is an ENUM and there are not matches
                if (right != null)
                {
                    if (columnExclusions.ContainsKey(validColumn.Key) &&
                        columnExclusions[validColumn.Key].Contains(term))
                        // inverse if excluding the match with ~
                        excAnd = excAnd != null
                                     ? Expression.AndAlso(excAnd, Expression.Not(right))
                                     : (Expression) Expression.Not(right);
                    else
                        // put OrElse expressions between each field
                        termOr = termOr != null
                                     ? Expression.OrElse(termOr, right)
                                     : right;
                }

                // end term loop
            }

            // end property loop
        }

        // create the body which is a combination of the inclusion terms AND excluding the terms marked with ~
        Expression body = null;
        if (termOr != null)
            body = termOr;
        if (excAnd != null)
            body = termOr != null ? Expression.AndAlso(termOr, excAnd) : excAnd;
        if (body != null)
        {
            // pass the lambda expression to IQueryable.Where<>()
            var lambda = Expression.Lambda(body, new[] { parameter });

            return source.Provider.CreateQuery<TEntity>(
                Expression.Call(
                    null,
                    typeof(Queryable).GetMethods().First(x => x.Name == "Where").MakeGenericMethod(typeof(TEntity)),
                    new[] { source.Expression, Expression.Quote(lambda) }
                    ));
        }

        // no valid columns where found for searching
        return source;
    }

    /// <summary>
    /// Generates a list of search terms and exclusions for each columns.
    /// Handles complex searching such as "literal full string search"
    ///   columnName:term for searching specific columns
    ///   ~exlusionTerm for excluding terms from the result
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="validColumns"></param>
    /// <param name="search"></param>
    /// <param name="outTerms"></param>
    /// <param name="outExclusions"></param>
    public static void GetSearchTerms<TEntity>(
        IEnumerable<DataTableColumn<TEntity>> validColumns, 
        string search, 
        out Dictionary<DataTableColumn<TEntity>, List<string>> outTerms, 
        out Dictionary<DataTableColumn<TEntity>, List<string>> outExclusions)
    {

        // these are lists that contain all the term information
        var columnTerms = new Dictionary<DataTableColumn<TEntity>, List<string>>();
        var columnExclusions = new Dictionary<DataTableColumn<TEntity>, List<string>>();
        // TODO Split
        if (search.StartsWith("\"") && search.EndsWith("\""))
            // add the string to the terms dictionary for each column, this means any columns must match the whole search string
            columnTerms = validColumns.ToDictionary(x => x,
                                                    x => new List<string> { search.Substring(1, search.Length - 2) });
        else
        {
            // TODO: Search terms are split by column name
            try
            {
                Regex regexObj = new Regex(
                    @"#match all terms with ~ infront
		            ~(?<exclusion>[^\s]*)|
		            #match all column specific terms
		            (?<column>(?<columnName>[^\s]*):(~(?<columnExclusion>[^\s]*)|(?<columnTerm>[^\s]*)))|
		            #match all other terms
		            (?<term>[^\s]*)
		            ",
                    RegexOptions.IgnorePatternWhitespace);
                Match matchResult = regexObj.Match(search);
                while (matchResult.Success)
                {
                    if (matchResult.Groups["exclusion"].Success)
                    {
                        // add the term to the terms dictionary for each column
                        columnTerms = validColumns.ToDictionary(x => x, x => columnTerms.ContainsKey(x)
                            ? columnTerms[x].Concat(new List<string> { matchResult.Groups["exclusion"].Value }).ToList()
                            : new List<string> { matchResult.Groups["exclusion"].Value });

                        // add the term to the exclusions dictionary for each column
                        columnExclusions = validColumns.ToDictionary(x => x, x => columnExclusions.ContainsKey(x)
                            ? columnExclusions[x].Concat(new List<string> { matchResult.Groups["exclusion"].Value }).ToList()
                            : new List<string> { matchResult.Groups["exclusion"].Value });
                    }
                    else if (matchResult.Groups["column"].Success)
                    {
                        var column = validColumns
                            .FirstOrDefault(x =>
                                // match the name exactly
                                x.ColumnName.ToLower() == matchResult.Groups["columnName"].Value.ToLower() ||
                                    // match the last property name
                                x.ColumnName.ToLower().EndsWith('.' + matchResult.Groups["columnName"].Value.ToLower()));
                        if (column != null)
                        {
                            var term = matchResult.Groups["columnTerm"].Value;
                            if(matchResult.Groups["columnExclusion"].Success)
                            {
                                term = matchResult.Groups["columnExclusion"].Value;
                                // add the exclusion to the specified column
                                if (columnExclusions.ContainsKey(column))
                                    columnExclusions[column].Add(term);
                                else
                                    columnExclusions.Add(column, new List<string> { term });
                            }
                            // add the term to the specified column
                            if (columnTerms.ContainsKey(column))
                                columnTerms[column].Add(term);
                            else
                                columnTerms.Add(column, new List<string> { term });
                        }
                        else
                        {
                            // add the whole column expression to terms because it didn't match anything 
                            //  so maybe they intended to search for a string like column:term
                            columnTerms = validColumns.ToDictionary(x => x, x => columnTerms.ContainsKey(x)
                                ? columnTerms[x].Concat(new List<string> { matchResult.Groups["column"].Value }).ToList()
                                : new List<string> { matchResult.Groups["column"].Value });
                        }
                    }
                    else if (matchResult.Groups["term"].Success)
                    {
                        // add the term to the columnTerms dictionary to search all columns
                        columnTerms = validColumns.ToDictionary(x => x, x => columnTerms.ContainsKey(x)
                            ? columnTerms[x].Concat(new List<string> { matchResult.Groups["term"].Value }).ToList()
                            : new List<string> { matchResult.Groups["term"].Value });
                    }
                    matchResult = matchResult.NextMatch();
                }
            }
            catch (ArgumentException ex)
            {
                // Syntax error in the regular expression
            }
        }
        outTerms = columnTerms;
        outExclusions = columnExclusions;
    }

    public static List<KeyValuePair<DataTableColumn<TEntity>, MemberExpression>> GetMemberExpressions<TEntity>(IEnumerable<DataTableColumn<TEntity>> columns, ParameterExpression parameter)
    {
        Dictionary<DataTableColumn<TEntity>, KeyValuePair<MemberExpression, ParameterExpression>> collections;
        return GetMemberExpressions(columns, parameter, out collections);
    }

    /// <summary>
    /// Get a MemberAccess Expression for collection type properties
    /// </summary>
    /// <param name="columns"></param>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public static List<KeyValuePair<DataTableColumn<TEntity>, MemberExpression>> GetMemberExpressions<TEntity>(IEnumerable<DataTableColumn<TEntity>> columns, ParameterExpression parameter, out Dictionary<DataTableColumn<TEntity>, KeyValuePair<MemberExpression, ParameterExpression>> collections)
    {
        var result = new List<KeyValuePair<DataTableColumn<TEntity>, MemberExpression>>();
        collections = new Dictionary<DataTableColumn<TEntity>, KeyValuePair<MemberExpression, ParameterExpression>>();

        foreach (var webGridColumn in columns)
        {
            // do not search test in formatted columns because it may not show up right anyways
            //if (webGridColumn.Format != null)
            //    continue;

            var parts = webGridColumn.ColumnName.Split('.');
            MemberExpression innerExpression;
            ParameterExpression newParam;
            var access = GetExpressionRecursive<TEntity>(parts, parameter, out innerExpression, out newParam);

            if (access != null)
            {
                result.Add(new KeyValuePair<DataTableColumn<TEntity>, MemberExpression>(webGridColumn, access));
                if(innerExpression != null)
                    collections.Add(webGridColumn, new KeyValuePair<MemberExpression, ParameterExpression>(innerExpression, newParam));
            }
        }

        return result;
    }

    /// <summary>
    /// Recursively get the property or if it is a collection apply calls that are specified.
    /// </summary>
    /// <param name="parts">The list of string parts that describes the property to access such as Organization.Name.</param>
    /// <param name="parameter">The entity passed in to the expression tree.</param>
    /// <param name="innerExpression">The Member access expression for inside the collection</param>
    /// <param name="newParam"> </param>
    /// <returns></returns>
    public static MemberExpression GetExpressionRecursive<TEntity>(IEnumerable<string> parts, ParameterExpression parameter, out MemberExpression innerExpression, out ParameterExpression newParam)
    {
        MemberExpression access = null;

        var currentType = typeof(TEntity);
        var currentParts = parts; // keeps a list of remaining parts to get the property of

        foreach (var part in parts)
        {
            var prop = currentType.GetProperty(part);
            if (prop != null)
            {
                // shift off the top of parts
                currentParts = currentParts.Where((s, i) => i > 0);

                // special handler for collections
                var genericCollection = prop.PropertyType.GenericImplementsType(typeof(ICollection<>));
                if (genericCollection != null)
                {
                    var objectType = genericCollection.GetGenericArguments()[0]; // get the type of collection
                    var collectionAccess = Expression.MakeMemberAccess((Expression)access ?? parameter, prop); // access to the collection property
                    newParam = Expression.Parameter(objectType, TagBuilder.CreateSanitizedId(collectionAccess.Type.Name)); // create a parameter of the new type

                    MemberExpression innerInnerExpression = null;
                    ParameterExpression innerParameterExpression = null;
                    // returns
                    innerExpression = (MemberExpression)((MethodInfo)MethodBase.GetCurrentMethod()).MakeGenericMethod(objectType)
                        .Invoke(null, new object[] { currentParts, newParam, innerInnerExpression, innerParameterExpression }); // get the remainder of the expression
                    return collectionAccess;
                }
                
                // normal Property access, this assumes the property is pretty simple
                access = Expression.MakeMemberAccess((Expression)access ?? parameter, prop);
                currentType = prop.PropertyType;
            }
            else // part does not exist as a property so do not yield this column (no searching allowed)
            {
                access = null;
                break;
            }
        }

        newParam = null;
        innerExpression = null;
        return access;
    }
}
