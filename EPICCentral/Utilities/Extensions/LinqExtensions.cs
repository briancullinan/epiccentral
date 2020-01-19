using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

public static class LinqExtensions
{
    public static IEnumerable<TSource> DistinctBy<TSource, TKey>
        (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
        var seenKeys = new HashSet<TKey>();
        foreach (TSource element in source)
        {
            if (seenKeys.Add(keySelector(element)))
            {
                yield return element;
            }
        }
    }

    public static IEnumerable<TResult> FullOuterJoin<TOuter, TInner, TKey, TResult>(

        this IEnumerable<TOuter> outer,

        IEnumerable<TInner> inner,

        Func<TOuter, TKey> outerKeySelector,

        Func<TInner, TKey> innerKeySelector,

        Func<TOuter, TInner, TResult> resultSelector)

        where TOuter : class

        where TInner : class
    {

        return outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector)

            .Concat(
                LeftAntiSemiJoin(outer, inner, outerKeySelector, innerKeySelector).Select(o => resultSelector(o, null)))

            .Concat(
                LeftAntiSemiJoin(inner, outer, innerKeySelector, outerKeySelector).Select(i => resultSelector(null, i)));

    }


    public static IEnumerable<TResult> LeftOuterJoin<TOuter, TInner, TKey, TResult>(

        this IEnumerable<TOuter> outer,

        IEnumerable<TInner> inner,

        Func<TOuter, TKey> outerKeySelector,

        Func<TInner, TKey> innerKeySelector,

        Func<TOuter, TInner, TResult> resultSelector)

        where TOuter : class

        where TInner : class
    {
        return outer

            .GroupJoin(inner, outerKeySelector, innerKeySelector, (o, i) => new { Outer = o, Group = i })

            .SelectMany(z => z.Group.DefaultIfEmpty(), (left, right) => resultSelector(left.Outer, right));
    }

    public static IEnumerable<TOuter> LeftAntiSemiJoin<TOuter, TInner, TKey>(

        this IEnumerable<TOuter> outer,

        IEnumerable<TInner> inner,

        Func<TOuter, TKey> outerKeySelector,

        Func<TInner, TKey> innerKeySelector)
    {

        return outer

            .GroupJoin(inner, outerKeySelector, innerKeySelector, (o, i) => new {Outer = o, Group = i})

            .Where(r => !r.Group.Any())

            .Select(r => r.Outer);

    }

}
