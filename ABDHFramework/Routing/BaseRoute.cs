using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace ABDHFramework.Routing
{
  public class BaseRoute
  {
    protected String _controllerName;
    protected UrlHelper _url;

    public BaseRoute(UrlHelper url, String controllerName)
    {
      _url = url;
      _controllerName = controllerName;
    }

    /// <summary>
    /// url for action
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    public String UrlFor(String action)
    {
      return UrlFor(action, null);
    }

    /// <summary>
    /// generate url base on current controllerName, action and params
    /// </summary>
    /// <param name="action"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    public String UrlFor(String action, Object param)
    {
      return UrlFor(_controllerName, action, param);
    }

    /// <summary>
    /// generate url base on controller name, action name and params
    /// </summary>
    /// <param name="controllerName"></param>
    /// <param name="action"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    public String UrlFor(String controllerName, String action, Object param)
    {
      var query = BuildParams(param);
      if (query.Length > 0)
      {
        query = "?" + query;
      }
      return _url.Content(String.Format("~/{0}/{1}", controllerName, action)) + query;
    }

    /// <summary>
    /// link to action
    /// </summary>
    /// <param name="linkText"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public String LinkTo(String linkText, String action)
    {
      return LinkTo(linkText, action, new { });
    }

    /// <summary>
    /// link to action
    /// </summary>
    /// <param name="linkText"></param>
    /// <param name="controllerName"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public String LinkTo(String linkText, String controlerName, String action, object param)
    {
      var url = UrlFor(controlerName, action, param);
      // Create tag builder  
      var builder = new TagBuilder("a");

      builder.MergeAttribute("href", url);
      builder.SetInnerText(linkText);
      return builder.ToString();
    }

    public String LinkTo(String linkText, String controlerName, String action, String style, object param)
    {
      var url = UrlFor(controlerName, action, param);
      // Create tag builder  
      var builder = new TagBuilder("a");

      builder.MergeAttribute("href", url);
      builder.MergeAttribute("class", style);
      builder.SetInnerText(linkText);
      return builder.ToString();
    }

    /// <summary>
    /// link to url with html param
    /// </summary>
    /// <param name="linkText"></param>
    /// <param name="controlerName"></param>
    /// <param name="action"></param>
    /// <param name="param"></param>
    /// <param name="htmlAttributes"></param>
    /// <returns></returns>
    public String LinkTo(String linkText, String controlerName, String action, object param, Object htmlAttributes)
    {
      var url = UrlFor(controlerName, action, param);
      // Create tag builder  
      var builder = new TagBuilder("a");

      builder.MergeAttribute("href", url);

      var attr = new RouteValueDictionary(htmlAttributes);
      builder.MergeAttributes(attr);
      builder.SetInnerText(linkText);
      return builder.ToString();
    }

    /// <summary>
    /// link to by opening another page
    /// </summary>
    /// <param name="linkText"></param>
    /// <param name="controlerName"></param>
    /// <param name="action"></param>
    /// <param name="page"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    public String LinkToPage(String linkText, String controlerName, String action, String page, object param)
    {
      var url = UrlFor(controlerName, action, param);
      // Create tag builder  
      var builder = new TagBuilder("a");

      builder.MergeAttribute("href", url);
      builder.MergeAttribute("target", page);
      builder.SetInnerText(linkText);
      return builder.ToString();
    }
    /// <summary>
    /// link to action base on current controllerName
    /// </summary>
    /// <param name="linkText"></param>
    /// <param name="action"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    public String LinkTo(String linkText, String action, Object param)
    {
      var url = UrlFor(action, param);
      // Create tag builder  
      var builder = new TagBuilder("a");

      builder.MergeAttribute("href", url);
      builder.SetInnerText(linkText);
      return builder.ToString();
    }

    public String LinkWithStyle(String linkText, String action, String style, Object param)
    {
      var url = UrlFor(action, param);
      // Create tag builder  
      var builder = new TagBuilder("a");

      builder.MergeAttribute("href", url);
      builder.MergeAttribute("class", style);
      builder.SetInnerText(linkText);
      return builder.ToString();
    }

    /// <summary>
    /// convert parameter in object to string
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    public String BuildParams(Object param)
    {
      var jss = new JavaScriptSerializer();
      var parameters = jss.Deserialize<Dictionary<string, String>>(jss.Serialize(param));

      if (parameters == null)
      {
        return "";
      }

      var values = new List<String>();
      foreach (var kvp in parameters)
      {
        values.Add(kvp.Key + "=" + _url.Encode(kvp.Value));
      }

      return String.Join("&", values.ToArray());
    }
  }
}
