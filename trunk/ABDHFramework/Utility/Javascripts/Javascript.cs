using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ABDHFramework.Utility.Javascripts
{
  public static class Javascript
  {
    /// <summary>
    /// add param to url
    /// </summary>
    /// <param name="url"></param>
    /// <param name="param"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static String addParamToURL(String url, String param, String value)
    {
      if (url.IndexOf("?") > 0)
      {
        return url + "&" + param + "=" + System.Web.HttpUtility.UrlEncode(value);
      }
      else
      {
        return url + "?" + param + "=" + System.Web.HttpUtility.UrlEncode(value);
      }
    }

    /// <summary>
    /// add javascript to script tag
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static String AddToJavascriptTag(String content)
    {
      var builder = new TagBuilder("script");

      builder.MergeAttribute("type", "text/javascript");
      builder.InnerHtml = content;
      return builder.ToString();
    }

    /// <summary>
    /// submit button to remote
    /// </summary>
    /// <param name="name"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String SubmitToRemote(String name, String cssClass, RemoteOption option)
    {
      return SubmitToRemote(name, cssClass, option, null);
    }

    /// <summary>
    /// Submits to remote.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="cssClass">The CSS class.</param>
    /// <param name="option">The option.</param>
    /// <param name="htmlAttr">The custom HTML attr.</param>
    /// <returns></returns>
    public static String SubmitToRemote(String name, String cssClass, RemoteOption option, object htmlAttr)
    {
      option.IsForm = true;
      var onClick = RemoteFunc(option);
      var builder = new TagBuilder("input");
      RouteValueDictionary _htmlAttr = new RouteValueDictionary();
      if (htmlAttr != null)
        _htmlAttr = new RouteValueDictionary(htmlAttr);

      builder.MergeAttribute("type", "button");
      builder.MergeAttribute("onClick", onClick);
      builder.MergeAttribute("value", name);

      if(!_htmlAttr.ContainsKey("id"))
        builder.MergeAttribute("id", UIHelper.GenerateId(name).Replace(" ",""));

      if (cssClass != "")
        builder.MergeAttribute("class", cssClass);

      builder.MergeAttributes(_htmlAttr);

      return builder.ToString();
    }


    /// <summary>
    /// submit button to remote
    /// </summary>
    /// <param name="name"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String SubmitToRemote(String name, RemoteOption option)
    {
      return SubmitToRemote(name, "form-button ui-corner-all next", option);
    }

    /// <summary>
    /// link to remote
    /// </summary>
    /// <param name="name"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String LinkToRemote(String name, String cssClass, RemoteOption option)
    {
      var onClick = RemoteFunc(option);
      var builder = new TagBuilder("a");

      if (cssClass != "")
        builder.MergeAttribute("class", cssClass);
      builder.MergeAttribute("href", "javascript:void(0)");
      builder.MergeAttribute("onClick", onClick);
      builder.InnerHtml = name;

      return builder.ToString();
    }

    public static String LinkForSort(String content, RemoteOption option)
    {
      var onClick = RemoteFunc(option);
      var builder = new TagBuilder("a");

      builder.MergeAttribute("class", "tool-icon-button");
      builder.MergeAttribute("href", "javascript:void(0)");
      builder.MergeAttribute("onClick", onClick);
      builder.InnerHtml+=content;

      return builder.ToString();
    }

    public static TagBuilder TableHeaderForSort(String content, RemoteOption option)
    {
      var onClick = RemoteFunc(option);
      var builder = new TagBuilder("th");

      builder.MergeAttribute("onClick", onClick);
      if (!string.IsNullOrEmpty(content))
      {
        builder.InnerHtml += content;
      }
      else
      {
        builder.InnerHtml += "&nbsp;";
      }

      return builder;
    }

    public static String LinkToRemote(String name, RemoteOption option)
    {
      return LinkToRemote(name,"", option);
    }
    /// <summary>
    /// load remote content
    /// </summary>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String LoadRemote(RemoteOption option)
    {
      var script = "$(document).ready(function(){" + RemoteFunc(option) + ";});";
      return AddToJavascriptTag(script);
    }

    /// <summary>
    /// remote function
    /// </summary>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String RemoteFunc(RemoteOption option)
    {
      var a = String.Format("Core.SubmitToRemote(this, {0} {1})", option.ToJSON(), String.IsNullOrEmpty(option.OnSuccess)? "": ", " + option.OnSuccess);
      if (option.CallBefore != null)
      {
        a = string.Format("if ({0}){{{1}}}", option.CallBefore, a);
      }
      return a;
    }


    /// <summary>
    /// button to url
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="url"></param>
    /// <returns></returns>
    public static String ButtonTo(String name, String url)
    {
      var onClick = String.Format("window.location=\"{0}\"", url);

      var b = new TagBuilder("input");
      b.MergeAttribute("type", "button");
      b.MergeAttribute("class", "form-button ui-corner-all next");
      b.MergeAttribute("value", name);
      b.MergeAttribute("onclick", onClick);

      return b.ToString();
    }

    public static String ButtonTo(String name, String url, String confirm){
      var onClick = String.Format("if (confirm('{0}')) window.location=\"{1}\"", confirm, url);

      var b = new TagBuilder("input");
      b.MergeAttribute("type", "button");
      b.MergeAttribute("class", "form-button ui-corner-all next");
      b.MergeAttribute("value", name);
      b.MergeAttribute("onclick", onClick);

      return b.ToString();
    }    
  }
}
