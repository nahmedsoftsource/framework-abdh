using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABDH_Demo.Utility.Javascripts;
using System.Web.Routing;

namespace ABDH_Demo.Utility
{
  public static class JavascriptHelper
  {
    /// <summary>
    /// submit to remote button
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String SubmitToRemote(this HtmlHelper html, String name, RemoteOption option)
    {
      return Javascript.SubmitToRemote(name, option);
    }

    /// <summary>
    /// submit to remote button
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String SubmitToRemote(this HtmlHelper html, String name, String cssClass, RemoteOption option)
    {
      return Javascript.SubmitToRemote(name, cssClass, option);
    }

    /// <summary>
    /// Submits to remote.
    /// </summary>
    /// <param name="html">The HTML.</param>
    /// <param name="name">The name.</param>
    /// <param name="cssClass">The CSS class.</param>
    /// <param name="option">The option.</param>
    /// <param name="htmlAttr">The HTML attr.</param>
    /// <returns></returns>
    public static String SubmitToRemote(this HtmlHelper html, String name, String cssClass, RemoteOption option, object htmlAttr)
    {
      return Javascript.SubmitToRemote(name, cssClass, option, htmlAttr);
    }

    /// <summary>
    /// link to remote
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String LinkToRemote(this HtmlHelper html, String name, RemoteOption option)
    {
      return Javascript.LinkToRemote(name, "", option);
    }

    public static String LinkToRemote(this HtmlHelper html, String name, String cssClass, RemoteOption option)
    {
      return Javascript.LinkToRemote(name, cssClass, option);
    }

    /// <summary>
    /// load remote
    /// </summary>
    /// <param name="html"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String LoadRemote(this HtmlHelper html, RemoteOption option)
    {
      return Javascript.LoadRemote(option);
    }

    /// <summary>
    /// remote function
    /// </summary>
    /// <param name="html"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String RemoteFunc(this HtmlHelper html, RemoteOption option)
    {
      return Javascript.RemoteFunc(option);
    }

    /// <summary>
    /// auto complete for an input
    /// </summary>
    /// <param name="html"></param>
    /// <param name="HtmlID"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String AutoCompleteFor(this HtmlHelper html, String HtmlID, AutoCompleteOption option)
    {
      var jsOption = option.ToJSON();

      var js = String.Format(@"$(""#{0}"").autocomplete(""{1}"", {2});", HtmlID, option.URL, jsOption);
      var js1 = "";
      if (option.Result != null)
      {
        js1 = String.Format(@"$(""#{0}"").result(function(event, data, formatted) {{ var info; eval(""info = ""+formatted);{1}}} );", HtmlID, option.Result);
      }
      else if (option.ResultFunc != null)
      {
        js1 = String.Format(@"$(""#{0}"").result({1});", HtmlID, option.ResultFunc);
      }

      return Javascript.AddToJavascriptTag(js + js1);
    }


    /// <summary>
    /// render auto complete data
    /// </summary>
    /// <param name="html"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static String RenderAutoCompleteData(this HtmlHelper html, IEnumerable<AutoCompleteDataItem> data)
    {
      var ret = new List<String>();
      if (data != null)
      {
        foreach (var item in data)
        {
          ret.Add(item.ToJSON());
        }
      }

      return string.Join("\n", ret.ToArray());
    }

    /// <summary>
    /// button to javascript function
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="func"></param>
    /// <returns></returns>
    public static String ButtonToFunc(this HtmlHelper html, String name, String func)
    {
      var builder = new TagBuilder("input");
      builder.MergeAttribute("type", "button");
      builder.MergeAttribute("class", "form-button ui-state-default ui-corner-all next");
      builder.MergeAttribute("onClick", func);
      builder.MergeAttribute("value", name);

      return builder.ToString();
    }

    /// <summary>
    /// load javascript file
    /// </summary>
    /// <param name="html"></param>
    /// <param name="file"></param>
    /// <returns></returns>
    public static String LoadJavascript(this HtmlHelper html, String file)
    {
      if (!file.EndsWith(".js"))
      {
        file += ".js";
      }

      var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
      var url = urlHelper.Content("~/Content/js/" + file);

      var b = new TagBuilder("script");
      b.MergeAttribute("type", "text/javascript");
      b.MergeAttribute("src", url);

      return b.ToString();
    }

    /// <summary>
    /// load javascript file
    /// </summary>
    /// <param name="html"></param>
    /// <param name="file"></param>
    /// <returns></returns>
    public static String LoadJavascript(this BaseController controller, String file)
    {
      if (!file.EndsWith(".js"))
      {
        file += ".js";
      }

      var urlHelper = controller.Url;
      var url = urlHelper.Content("~/Content/js/" + file);

      var b = new TagBuilder("script");
      b.MergeAttribute("type", "text/javascript");
      b.MergeAttribute("src", url);

      return b.ToString();
    }

    /// <summary>
    /// button to url
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="url"></param>
    /// <returns></returns>
    public static String ButtonTo(this HtmlHelper html, String name, String url)
    {
      var onClick = String.Format("window.location=\"{0}\"", url);

      var b = new TagBuilder("input");
      b.MergeAttribute("type", "button");
      b.MergeAttribute("class", "form-button ui-state-default ui-corner-all next");
      b.MergeAttribute("value", name);
      b.MergeAttribute("onclick", onClick);

      return b.ToString();
    }

    /// <summary>
    /// Buttons to remote without the form required.
    /// </summary>
    /// <param name="html">The HTML.</param>
    /// <param name="name">The name.</param>
    /// <param name="options">The options.</param>
    /// <returns></returns>
    public static String ButtonToRemote(this HtmlHelper html, String name, RemoteOption options)
    {
      return ButtonToRemote(html, name, options, null);
    }

    /// <summary>
    /// Buttons to remote.
    /// </summary>
    /// <param name="html">The HTML.</param>
    /// <param name="name">The name.</param>
    /// <param name="options">The options.</param>
    /// <param name="htmlAttr">The HTML attr.</param>
    /// <returns></returns>
    public static String ButtonToRemote(this HtmlHelper html, String name, RemoteOption options, object htmlAttr)
    {
      return ButtonToRemote(html, name, "form-button ui-state-default ui-corner-all", options, htmlAttr);
    }

    /// <summary>
    /// Buttons to remote.
    /// </summary>
    /// <param name="html">The HTML.</param>
    /// <param name="name">The name.</param>
    /// <param name="cssClass">The CSS class.</param>
    /// <param name="options">The options.</param>
    /// <param name="htmlAttr">The HTML attr.</param>
    /// <returns></returns>
    public static String ButtonToRemote(this HtmlHelper html, String name, String cssClass, RemoteOption options, object htmlAttr)
    {
      var onClick = Javascript.RemoteFunc(options);
      var builder = new TagBuilder("input");

      builder.MergeAttribute("type", "button");
      builder.MergeAttribute("onClick", onClick);
      builder.MergeAttribute("value", name);
      if (cssClass != "")
        builder.MergeAttribute("class", cssClass);

      builder.MergeAttributes((htmlAttr == null) ? new RouteValueDictionary() : new RouteValueDictionary(htmlAttr));

      return builder.ToString();
    }

  }
}
