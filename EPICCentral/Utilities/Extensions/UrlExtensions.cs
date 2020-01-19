using System;
using System.Web;
using System.Web.Mvc;

public static class UrlExtensions
{
    /// <summary>
    /// Used in emails.  Just for convenience generates links to the absolute path.
    /// </summary>
    /// <param name="url"></param>
    /// <param name="actionName"></param>
    /// <param name="controllerName"></param>
    /// <param name="routeValues"></param>
    /// <returns></returns>
	public static string AbsoluteAction(this UrlHelper url, string actionName, string controllerName, object routeValues = null)
	{
		return url.Action(actionName, controllerName, routeValues, url.RequestContext.HttpContext.Request.Url.Scheme);
	}

	public static string AbsoluteContent(this UrlHelper url, string path)
	{
		var uri = new Uri(path, UriKind.RelativeOrAbsolute);

	    return UrlHelper.GenerateContentUrl(path, url.RequestContext.HttpContext);

		//If the URI is not already absolute, rebuild it based on the current request.
		if (!uri.IsAbsoluteUri)
		{
			UriBuilder builder = new UriBuilder(url.RequestContext.HttpContext.Request.Url) { Path = VirtualPathUtility.ToAbsolute(path), Query = string.Empty };

			uri = builder.Uri;
		}

		return uri.ToString();
	}
}
