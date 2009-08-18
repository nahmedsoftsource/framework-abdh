using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABDHFramework.Utility.Javascripts;
using System.Web.Routing;
using Framework.Utility;

namespace ABDHFramework.Utility
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

    public static String LinkForSort(String content, RemoteOption option)
    {
      return Javascript.LinkForSort(content, option);
    }

    public static TagBuilder TableHeaderForSort(String content, RemoteOption option)
    {
      return Javascript.TableHeaderForSort(content, option);
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
      builder.MergeAttribute("class", "form-button ui-corner-all next");
      builder.MergeAttribute("onClick", func);
      builder.MergeAttribute("value", name);

      return builder.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="func"></param>
    /// <returns></returns>
    public static String NewRecordToFunc(this HtmlHelper html, String func)
    {
      return NewRecordToFunc(html, "NEW RECORD", func, 90);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="func"></param>
    /// <param name="width">Pixel</param>
    /// <returns></returns>
    public static String NewRecordToFunc(this HtmlHelper html, string name, String func, int width)
    {
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      sb.Append(string.Format("<div style='width: {0}px;float:right; margin:5px'>", width.ToString()));
      sb.Append(string.Format("<div style='margin-right: 1px;' onclick='{0}' class='iadd ibutton'>", func));
      sb.Append("<span></span>");
      sb.Append("</div>");
      sb.Append(string.Format("<div style='margin-top: 6px;'>{0}</div>", name));
      sb.Append("</div>");

      return sb.ToString();
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
      b.MergeAttribute("class", "form-button ui-corner-all next");
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
      return ButtonToRemote(html, name, "form-button ui-corner-all", options, htmlAttr);
    }

    public static String ButtonToRemote(this HtmlHelper html, String name, String cssClass, RemoteOption options)
    {
      return ButtonToRemote(html, name, cssClass, options, null);
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

    /// <summary>
    ///   render image button
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="imgCss"></param>
    /// <param name="imgPath"></param>
    /// <param name="enabled"></param>
    /// <param name="onClick"></param>
    /// <returns></returns>
    public static String ImageButton(this HtmlHelper html, String name, String imgCss, String imgPath, bool enabled, string onClick)
    {
      return ImageButton(html, name, imgCss, imgPath, enabled, onClick, null);
    }

    /// <summary>
    ///   render image button
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="imgCss"></param>
    /// <param name="imgPath"></param>
    /// <param name="enabled"></param>
    /// <param name="onClick"></param>
    /// <param name="htmlAttr"></param>
    /// <returns></returns>
    public static String ImageButton(this HtmlHelper html, String name, String imgCss, String imgPath, bool enabled, string onClick, object htmlAttr)
    {
      onClick = (enabled ? onClick + ";" : "") + "return false;";
      var builder = new TagBuilder("a");

      builder.MergeAttribute("href", "#");
      builder.AddCssClass("tool-icon-button");
      if (!enabled)
      {
        builder.AddCssClass("ui-state-disabled");
      }
      builder.MergeAttribute("onclick", onClick);
      builder.MergeAttribute("title", name);
      TagBuilder inner = new TagBuilder("img");
      if (imgCss != "")
      {
        inner.AddCssClass(imgCss);
      }
      inner.MergeAttribute("alt", name);
      inner.MergeAttribute("src", imgPath);

      builder.MergeAttributes((htmlAttr == null) ? new RouteValueDictionary() : new RouteValueDictionary(htmlAttr));
      builder.InnerHtml = inner.ToString();
      return builder.ToString();
    }

    /// <summary>
    /// render javascript tag
    /// </summary>
    /// <param name="html"></param>
    /// <returns></returns>
    public static IDisposable JavascriptTag(this HtmlHelper html)
    {
      var builder = new TagBuilder("script");

      builder.MergeAttribute("type", "text/javascript");

      var startTag = builder.ToString(TagRenderMode.StartTag);
      html.ViewContext.HttpContext.Response.Write(startTag);

      return new DisposableAction(delegate()
      {
        html.ViewContext.HttpContext.Response.Write(builder.ToString(TagRenderMode.EndTag));
      });
    }
    /// <summary>
    /// Link Delete For List
    /// </summary>
    /// <param name="html"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String LinkDeleteForList(this HtmlHelper html, RemoteOption option)
    {
      var builder = new TagBuilder("span");
      builder.MergeAttribute("class", "ui-state-error-text");

      builder.InnerHtml += Javascript.LinkToRemote("", "ui-icon ui-icon-closethick", option);
      return builder.ToString();
    }

    /// <summary>
    /// Button to func with + icon
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="func"></param>
    /// <returns></returns>
    public static String AddButtonToFunc(this HtmlHelper html, String name, String func)
    {
      var builder = new TagBuilder("span");
      builder.MergeAttribute("class", "ui-icon ui-icon-plusthick");
      builder.MergeAttribute("onClick", func);
      builder.MergeAttribute("style", "cursor:hand;");
      builder.SetInnerText(name);

      return builder.ToString();
    }
    /// <summary>
    /// Button to func with X icon
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="func"></param>
    /// <returns></returns>
    public static String RemoveButtonToFunc(this HtmlHelper html, String name, String func)
    {
      var builderSpan = new TagBuilder("span");
      builderSpan.MergeAttribute("class", "ui-state-error-text");
      var builder = new TagBuilder("span");
      builder.MergeAttribute("class", "ui-icon ui-icon-closethick");
      builder.MergeAttribute("onClick", func);
      builder.MergeAttribute("style", "cursor:hand;");
      builder.SetInnerText(name);
      builderSpan.InnerHtml += builder.ToString();
      return builderSpan.ToString();
    }
  }
}
