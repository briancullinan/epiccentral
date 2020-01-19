using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages;
using EPICCentral.Controllers;
using EPICCentral.Models;

public static class HtmlExtensions
{
    /// <summary>
    /// Attachments for update listeners.
    /// </summary>
    /// <param name="htmlHelper"></param>
    /// <param name="actionName"></param>
    /// <param name="controllerName"></param>
    /// <param name="functionName"></param>
    /// <returns></returns>
    public static MvcHtmlString Attach(this HtmlHelper htmlHelper, string actionName, string controllerName, string functionName)
    {
        var dictionary = htmlHelper.ViewContext.HttpContext.Items["_attachments_"] as Dictionary<string, Dictionary<string, string>> ??
                         new Dictionary<string, Dictionary<string, string>>();

        if (dictionary.ContainsKey(controllerName))
            dictionary[controllerName].Add(actionName, functionName);
        else
            dictionary.Add(controllerName, new Dictionary<string, string>
                                               {
                                                   {actionName, functionName}
                                               });

        htmlHelper.ViewContext.HttpContext.Items["_attachments_"] = dictionary;

        return MvcHtmlString.Empty;
    }

    /// <summary>
    /// Render all of the listeners and add the necessary AJAX scripts.
    /// </summary>
    /// <param name="htmlHelper"></param>
    /// <returns></returns>
    public static MvcHtmlString RenderAttachments(this HtmlHelper htmlHelper)
    {
        var attachments = htmlHelper.ViewContext.HttpContext.Items["_attachments_"] as Dictionary<string, Dictionary<string, string>>;
        if(attachments != null)
            htmlHelper.RenderPartial("_UpdateAttachmentPartial", new UpdatesModel(attachments));
        return MvcHtmlString.Empty;
    }

    /// <summary>
    /// Help put scripts in heading
    /// </summary>
    /// <param name="htmlHelper"></param>
    /// <param name="template"></param>
    /// <returns></returns>
    public static MvcHtmlString Script(this HtmlHelper htmlHelper, Func<object, HelperResult> template)
    {
        if (htmlHelper.ViewContext.HttpContext.Items["_scripts_"] == null)
            htmlHelper.ViewContext.HttpContext.Items["_scripts_"] = new List<Func<object, HelperResult>>();
        ((List<Func<object, HelperResult>>)htmlHelper.ViewContext.HttpContext.Items["_scripts_"]).Add(template);
        return MvcHtmlString.Empty;
    }

    /// <summary>
    /// Render all of the script tags.
    /// TODO: make this load the scripts and minimize them using something like: http://svn.offwhite.net/trac/SmallSharpTools.Packer/wiki
    /// </summary>
    /// <param name="htmlHelper"></param>
    /// <returns></returns>
    public static MvcHtmlString RenderScripts(this HtmlHelper htmlHelper)
    {
        if (htmlHelper.ViewContext.HttpContext.Items["_scripts_"] != null)
        {
            foreach (var template in (List<Func<object, HelperResult>>)htmlHelper.ViewContext.HttpContext.Items["_scripts_"])
            {
                htmlHelper.ViewContext.Writer.Write(template(null));
            }
        }
        return MvcHtmlString.Empty;
    }


	/// <summary>
	/// Format input telephone number based on culture of user and country of number.
	/// </summary>
	/// <param name="htmlHelper">extended class</param>
	/// <param name="phoneNumber">telephone number to format</param>
	/// <returns></returns>
	public static string GetPhoneDisplayText(
			this HtmlHelper htmlHelper,
			string phoneNumber
			)
	{
		// TODO: Make country origin/culture based.
		string clean = new string(phoneNumber.Where(char.IsDigit).ToArray());
		return clean.Length == 10 ? string.Format("({0}) {1}-{2}", clean.Substring(0, 3), clean.Substring(3, 3), clean.Substring(6)) : phoneNumber;
	}

    /// <summary>
    /// Creates a DataTable
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="htmlHelper"></param>
    /// <param name="source"></param>
    /// <param name="columns"></param>
    /// <param name="dialogs"></param>
    /// <param name="actions"> </param>
    /// <param name="add"> </param>
    /// <param name="defaultCount"> </param>
    /// <param name="defaultSort"> </param>
    /// <returns></returns>
    public static MvcHtmlString DataTableFor<TModel, TEntity>(
			this HtmlHelper<TModel> htmlHelper,
            IQueryable<TEntity> source,
			ColumnCollection<TEntity> columns,
			DataTablesDialogModelCollection dialogs = null,
			DataTablesDirectActionModelCollection actions = null,
			DataTablesAddModel add = null,
			int? defaultCount = null,
            List<DataTablesRequestModel.Sort> defaultSort = null,
            object htmlAttributes = null,
            string ajaxUrl = null)
    {
        var attributeDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

        // get ajax url from calling Action route values
        // this is used in the generation of the tableId and will help make it unique to the page but static to the application
        if (String.IsNullOrEmpty(ajaxUrl))
            ajaxUrl =
                new UrlHelper(htmlHelper.ViewContext.RequestContext).RouteUrl(htmlHelper.ViewContext.RouteData.Values);

        string tableId;
        if(attributeDictionary.ContainsKey("id"))
            tableId = attributeDictionary["id"].ToString();
        else
        {
		    // Generate a table ID that is unique for the table. It must be unique in the page
		    // but the same on every request. This ID is appended to the AJAX callback URL so
		    // the controller that handles the request can determin which table is make a request.
            tableId = ajaxUrl + source.GetType().AssemblyQualifiedName +
                      String.Join(",", columns.Select(x => x.ColumnName));
		    tableId = 'T' + String.Join("", System.Security.Cryptography.MD5.Create().ComputeHash(
										      System.Text.Encoding.ASCII.GetBytes(tableId)).Select(
											      x => x.ToString("X2")));
            attributeDictionary.Add("id", tableId);
        }

        // merge classes
        if (attributeDictionary.ContainsKey("class"))
            attributeDictionary["class"] += " dataTable";
        else
            attributeDictionary.Add("class", "dataTable");

		// Create the AJAX callback URL. It will be the original URL for the current
		// request, keeping all parameters intact, with the table ID appended. Carefull
		// to create proper format.
        // add query string and datatableid
        if(htmlHelper.ViewData.ModelState.Count > 0)
        {
            // combine route values and model state to get the needed url to access the path this method was called from
            ajaxUrl += '?' +
                       String.Join("&",
                                   htmlHelper.ViewData.ModelState.Where(
                                       x => x.Value.Errors.Count == 0 && x.Value.Value != null).Select(
                                           x => x.Key + "=" + HttpUtility.UrlEncode(x.Value.Value.AttemptedValue)));
        }
		ajaxUrl = string.Format("{0}{1}epicTableId={2}", ajaxUrl, ajaxUrl.Contains("?") ? "&" : "?", tableId);

		// set up initialization model
		var dataTableInit = new DataTablesInitializationModel<TEntity>
								{
									Columns = columns,
									Url = ajaxUrl,
									Source = source,
									ID = tableId,
									Dialogs = dialogs,
									DirectActions = actions,
									Add = add,
									DefaultCount = defaultCount,
                                    DefaultSorts = defaultSort,
                                    TableAttributes = attributeDictionary,
								};

		// Save it in ViewData where the controller can get it. Since there may be more than
		// one table in a page, this must be managed as a collection.
		//
		// NOTE: Using htmlHelper.ViewData doesn't work. That doesn't seem to be visible to the
		// controller. So we use the one that is a property of the Controller. Documentation
		// seems to indicate they are the same, but they don't appear to be.
        // This could be due to the viewData not being passed around to child actions
		var viewData = htmlHelper.ViewContext.Controller.ViewData;
        var models = viewData["DataTablesModels"] as Dictionary<string, object>;
		if (models == null)
		{
			models = new Dictionary<string, object>();
			viewData.Add("DataTablesModels", models);
		}
		models.Add(tableId, dataTableInit);

		// return html grid and javascript initializer
		using (var sw = new StringWriter())
		{
			// create a view context for the DataTablesPartial
			var newViewContext = new ViewContext(htmlHelper.ViewContext, htmlHelper.ViewContext.View, new ViewDataDictionary(dataTableInit), htmlHelper.ViewContext.TempData, sw);
			var view = ViewEngines.Engines.FindPartialView(htmlHelper.ViewContext.Controller.ControllerContext, "_DataTablesPartial");

			// render the View to a string to outputting to the page
			view.View.Render(newViewContext, sw);
			return MvcHtmlString.Create(sw.GetStringBuilder().ToString());
		}
	}

    public static MvcHtmlString DataTableFor<TModel, TEntity>(
            this HtmlHelper<TModel> htmlHelper,
            IQueryable<TEntity> source,
            BindingFlags bindingAttr,
            DataTablesDialogModelCollection dialogs = null,
            DataTablesDirectActionModelCollection actions = null,
            DataTablesAddModel add = null,
            int? defaultCount = null,
            List<DataTablesRequestModel.Sort> defaultSort = null,
            object htmlAttributes = null,
            string ajaxUrl = null)
    {
        var columns =
            new ColumnCollection<TEntity>(
                typeof(TEntity).GetProperties(bindingAttr).Select(x => new DataTableColumn<TEntity>
                {
                    ColumnName = x.Name
                }));
        return DataTableFor(
            htmlHelper, source, columns,
            dialogs, actions, add,
            defaultCount, defaultSort, htmlAttributes,
            ajaxUrl);
    }

    public static MvcHtmlString DataTableFor<TModel, TEntity>(
            this HtmlHelper<TModel> htmlHelper,
            IQueryable<TEntity> source,
            IEnumerable<PropertyInfo> properties,
            DataTablesDialogModelCollection dialogs = null,
            DataTablesDirectActionModelCollection actions = null,
            DataTablesAddModel add = null,
            int? defaultCount = null,
            List<DataTablesRequestModel.Sort> defaultSort = null,
            object htmlAttributes = null,
            string ajaxUrl = null)
    {
        var columns =
            new ColumnCollection<TEntity>(
                properties.Select(x => new DataTableColumn<TEntity>
                {
                    ColumnName = x.Name
                }));
        return DataTableFor(
            htmlHelper, source, columns,
            dialogs, actions, add,
            defaultCount, defaultSort, htmlAttributes,
            ajaxUrl);
    }
}
