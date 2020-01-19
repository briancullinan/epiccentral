using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using System.Web.UI;
using EPICCentral.Models;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentral.Controllers
{
    /// <summary>
    /// Inherited class for responding to Datatables requests and performing the proper filtering, closely dependent on the QueryableExtension class.
    /// </summary>
    public class DataTablesController : Controller
	{
        /// <summary>
        /// This is the primary query function called by all inheritors of DataTablesController.
        /// </summary>
        /// <param name="viewResult">The view result from the function that displays the datatable and sets up the datatable for the page.  The configuration is stored in the ViewData.</param>
        /// <param name="model">The model created by the dataTables script making an AJAX callback to the server.</param>
        /// <returns></returns>
        protected JsonResult Query(ViewResultBase viewResult, DataTablesRequestModel model)
        {
            return Query(viewResult, model, ControllerContext);
        }

        /// <summary>
        /// Main Query logic just used in a static context so some controllers could inherit other types and still use the Datatables functionality.
        /// </summary>
        /// <param name="viewResult"></param>
        /// <param name="model"></param>
        /// <param name="controllerContext"></param>
        /// <returns></returns>
		public static JsonResult Query(ViewResultBase viewResult, DataTablesRequestModel model, ControllerContext controllerContext)
		{
			// Render the view so the DataTables initialization model is rebuilt.
			StringWriter bitbucket = new StringWriter();
		    IView view = viewResult.View ??
                ViewEngines.Engines.FindView(controllerContext,
		                                     string.IsNullOrEmpty(viewResult.ViewName)
                                                 ? controllerContext.RouteData.Values["action"].ToString()
		                                         : viewResult.ViewName, null).View;
            view.Render(new ViewContext(controllerContext, view, viewResult.ViewData, viewResult.TempData, bitbucket), bitbucket);

			// Get set of table models from the ViewData.
            var dataTableInitModels = controllerContext.Controller.ViewData["DataTablesModels"] as Dictionary<string, object>;
			if (dataTableInitModels == null)
				throw new HttpException(500, ControllerRes.DataTables.InitializationModelNotFound);

			// Get the model for the table making the request.
			var dataTableInit = dataTableInitModels[model.epicTableId];

			// If the object isn't defined in the cache, we don't know what columns to return.
			if (dataTableInit == null)
				throw new HttpException(500, ControllerRes.DataTables.ColumnDefinitionNotFound);

            var objectType = dataTableInit.GetType().GetGenericArguments()[0];

		    var method =
		        typeof (DataTablesController).GetMethods(BindingFlags.NonPublic | BindingFlags.Static).First(
		            x => x.Name == "Query" && x.IsGenericMethod);

            // call Query<TEntity>()
		    return (JsonResult)method.MakeGenericMethod(new[] { objectType }).Invoke(null, new[] { dataTableInit, model });
		}

        /// <summary>
        /// The call for this function is generated in order to simplify the filtering below.  This is not usually necessary for IQueryable&lt;object&gt;
        /// However, LLBLGen has problems with IQuerable when the type is casted to object, so the proper typed call is generated above and this generic is called.
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dataTableInit"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private static JsonResult Query<TEntity>(DataTablesInitializationModel<TEntity> dataTableInit, DataTablesRequestModel model)
        {

            // Get source model used to create the view.
            var source = dataTableInit.Source;

            // get IQueryable type of object passed in, this makes the work below generalized for any type

            /*var source2 = source as IQueryable<PatientEntity>;
            if(source2 != null)
            {
                source2 = source2.Where(x => Convert.ToString(x.BirthDate, new DateTimeFormatInfo(){ShortDatePattern = }).Contains("fe"));

                var result = source2.ToList();
            }
            */

            // start with the source, then add on each filter
            var count = source.Count();
            var displayCount = count;
            if (!String.IsNullOrEmpty(model.sSearch))
            {
                var llblGenProProvider = source.Provider as LLBLGenProProvider;
                if (llblGenProProvider != null)
                {
                    var dateConverter = new FunctionMapping(typeof(DateTime), "ToString", 0,
                                                         @"CONVERT(nvarchar(2), CONVERT(int, SUBSTRING(CONVERT(nvarchar(23), {0}, 121), 6, 2))) + '/' + CONVERT(nvarchar(2), CONVERT(int, SUBSTRING(CONVERT(nvarchar(23), {0}, 121), 9, 2))) + '/' + CONVERT(nvarchar(4), CONVERT(int, SUBSTRING(CONVERT(nvarchar(23), {0}, 121), 1, 4))) + ' ' + CASE WHEN CONVERT(int, SUBSTRING(CONVERT(nvarchar(23), {0}, 121), 12, 2)) > 12 THEN CONVERT(nvarchar(4), CONVERT(int, SUBSTRING(CONVERT(nvarchar(23), {0}, 121), 12, 2)) - 12) ELSE CONVERT(nvarchar(4), CONVERT(int, SUBSTRING(CONVERT(nvarchar(23), {0}, 121), 12, 2))) END +':' +SUBSTRING(CONVERT(nvarchar(23), {0}, 121), 15, 2) + ':' + SUBSTRING(CONVERT(nvarchar(23), {0}, 121), 18, 2) + CASE WHEN CONVERT(int, SUBSTRING(CONVERT(nvarchar(23), {0}, 121), 12, 2)) > 11 THEN ' PM' ELSE ' AM' END");
                    //var indexOf = new FunctionMapping(typeof(string), "IndexOf", 1, "PATINDEX('%{1}%', {0}) - 1");
                    //var indexOf2 = new FunctionMapping(typeof(string), "IndexOf", 2, "PATINDEX('%{1}%', {0}) - 1");
                    if ((llblGenProProvider).CustomFunctionMappings == null)
                    {
                        (llblGenProProvider).CustomFunctionMappings = new FunctionMappingStore();
                    }
                    (llblGenProProvider).CustomFunctionMappings.Add(dateConverter);
                    //(llblGenProProvider).CustomFunctionMappings.Add(indexOf);
                    //(llblGenProProvider).CustomFunctionMappings.Add(indexOf2);
                    // ^--- Doesn't work for no apparent reason but would make the Search() function a lot simpler.
                }

                // search all specified columns for the specified string
                source = source.Search(dataTableInit.Columns, model.sSearch, !(source.Provider is LLBLGenProProvider));

                displayCount = source.Count();
            }

            // sort the result based on the model, this calls OrderBy on multiple columns sequentially
            if(model.Sorts.Any())
                source = source.Sort(dataTableInit.Columns, model.Sorts);

            // filter page based on start and length, this is like the SQL LIMIT directive
            if (model.iDisplayLength > 0)
                source = source.Skip(model.iDisplayStart).Take(model.iDisplayLength);

            // now build the response
            var response = new DataTablesResponseModel
            {
                sEcho = model.sEcho.Value,
                iTotalRecords = count,
                iTotalDisplayRecords = displayCount
            };

            // loop through each item and output JSON
            foreach (TEntity entity in source.ToList())
            {
                var row = response.NewRow();
                row.SetRowId(string.Empty + entity.GetHashCode());
                foreach (var column in dataTableInit.Columns)
                {
                    // if the column specifies a formatting function
                    if (column.Format != null)
                    {
                        var method = column.Format.Compile();
                        row.PushColumn(method.Invoke(entity).ToString());
                    }
                    else
                    {
                        var value = DataBinder.Eval(entity, column.ColumnName);
                        row.PushColumn(value != null ? value.ToString() : "");
                    }
                }
            }

            return new JsonResult
            {
                Data = response,
                ContentType = null,
                ContentEncoding = null,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
	}
}