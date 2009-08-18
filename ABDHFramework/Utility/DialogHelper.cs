using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Framework.Lib;
using System.Web.Mvc;
using System.Web.Routing;
using ABDHFramework.Utility.Javascripts;

namespace Framework.Utility
{
  public static class DialogHelper
  {
    /// <summary>
    /// link to remote dialog
    /// </summary>
    /// <param name="linkText"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String LinkToRemote(String linkText, DialogOpenOption option)
    {
      // Create tag builder  
      var builder = getTagBuilderForRemoteDialog("a", linkText, option);

      builder.MergeAttribute("href", "javascript:void(0)");

      return builder.ToString();
    }

    /// <summary>
    /// link to remote dialog
    /// </summary>
    /// <param name="linkText"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String LinkToRemote(String linkText, DialogOpenOption option, string css)
    {
      // Create tag builder  
      var builder = getTagBuilderForRemoteDialog("a", linkText, option);

      builder.MergeAttribute("href", "javascript:void(0)");
      builder.MergeAttribute("class", css);

      return builder.ToString();
    }



    public static String LinkToRemote(String linkText, DialogOpenOption option, Object attributes)
    {
      // Create tag builder  
      var builder = getTagBuilderForRemoteDialog("a", linkText, option);

      builder.MergeAttribute("href", "javascript:void(0)");

      var attr = new RouteValueDictionary(attributes);
      builder.MergeAttributes(attr);

      return builder.ToString();
    }
    /// <summary>
    ///  link to remote 
    /// </summary>
    /// <param name="linkText"></param>
    /// <param name="css"></param>
    /// <param name="href"></param>
    /// <param name="onclick"></param>
    /// <returns></returns>
    public static String LinkToRemote(String linkText, String css, String href, String onclick)
    {
      TagBuilder builder = new TagBuilder("a");
      builder.MergeAttribute("class", css);
      builder.MergeAttribute("href", href);
      builder.MergeAttribute("onclick", onclick);
      builder.SetInnerText(linkText);
      return builder.ToString();
    }

    /// <summary>
    /// button to remote dialog
    /// </summary>
    /// <param name="linkText"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String ButtonToRemote(String linkText, DialogOpenOption option, Object htmlAttributes)
    {
      // Create tag builder  
      var builder = getTagBuilderForRemoteDialog("button", linkText, option);

      if (htmlAttributes == null)
        builder.MergeAttribute("class", "form-button ui-corner-all next");

      builder.MergeAttribute("type", "button");

      if (htmlAttributes != null)
        builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

      return builder.ToString();
    }

    public static String ButtonToRemote(String linkText, DialogOpenOption option)
    {
      return ButtonToRemote(linkText, option, null);
    }

    /// <summary>
    /// get tag builder for remote dialog
    /// </summary>
    /// <param name="tagName"></param>
    /// <param name="linkText"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    private static TagBuilder getTagBuilderForRemoteDialog(String tagName, String linkText, DialogOpenOption option)
    {
      // Create tag builder  
      var builder = new TagBuilder(tagName);

      builder.MergeAttribute("onClick", OpenDialogScript(option));

      builder.SetInnerText(linkText);

      return builder;
    }

    /// <summary>
    /// javascript to open dialog
    /// </summary>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String OpenDialogScript(DialogOpenOption option)
    {
      string a = String.Format("Core.openDialog({0}, this)", option.ToJSon());
      if (option.RemoteOptions != null && !String.IsNullOrEmpty(option.RemoteOptions.CallBefore))
      {
        a = string.Format("if ({0}){{{1}}}", option.RemoteOptions.CallBefore, a);
      }
      return a;
    }

    /// <summary>
    /// javascript to open dialog
    /// </summary>
    /// <param name="html"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String OpenDialogScript(this HtmlHelper html, DialogOpenOption option)
    {
      return OpenDialogScript(option);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="html"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String DialogSubmit(this HtmlHelper html, DialogSubmitOption option)
    {
      return DialogSubmit(html, option, null);
    }

    /// <summary>
    /// dialog submit button
    /// </summary>
    /// <param name="html"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String DialogSubmit(this HtmlHelper html, DialogSubmitOption option, Object htmlAttributes)
    {
      var url = option.URL;

      // check if has ReloadID and ReloadURL param
      var param = html.ViewContext.RequestContext.HttpContext.Request.Params;
      if (param.Get("ReloadID") != null)
      {
        url = Javascript.addParamToURL(url, "ReloadID", param.Get("ReloadID"));
      }

      if (param.Get("ReloadURL") != null)
      {
        url = Javascript.addParamToURL(url, "ReloadURL", param.Get("ReloadURL"));
      }

      if (param.Get("RunJS") != null)
      {
        url = Javascript.addParamToURL(url, "RunJS", param.Get("RunJS"));
      }

      var onClick = String.Format("$.post('{0}', $(this).parents('form').serialize(), Core.DialogCallback)", url);
      if (option.CausesValidation)
      {
        onClick = string.Format("if ($(this).parents('form').valid()) {{{0}}}", onClick);
      }
      if (option.ConfirmMessage != null)
      {
        onClick = String.Format("if ({0}){{{1}}}", String.Format(@"confirm(""{0}"")", option.ConfirmMessage), onClick);
      }
      else if (option.CallBefore != null)
      {
        onClick = String.Format("if ({0}){{{1}}}", option.CallBefore, onClick);
      }

      // Create tag builder  
      var builder = new TagBuilder("button");

      builder.MergeAttribute("class", "form-button ui-corner-all next");
      builder.MergeAttribute("type", "button");
      builder.MergeAttribute("onClick", onClick);

      builder.SetInnerText(option.Name);

      if (htmlAttributes != null)
        builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

      return builder.ToString();
    }
    /// <summary>
    /// dialog submit link
    /// </summary>
    /// <param name="html"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String LinkSubmit(this HtmlHelper html, DialogSubmitOption option)
    {
      return LinkSubmit(html, option, null);
    }
    /// <summary>
    /// dialog submit button
    /// </summary>
    /// <param name="html"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String LinkSubmit(this HtmlHelper html, DialogSubmitOption option, Object htmlAttributes)
    {
      string onClick = CreateLink(html, option);

      // Create tag builder  
      var builder = new TagBuilder("a");
      builder.MergeAttribute("class", "toolbar-button toolbar-icon-task-add");
      builder.MergeAttribute("href", "javascript:void(0)");
      builder.MergeAttribute("onClick", onClick);

      if (htmlAttributes != null)
        builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

      builder.SetInnerText(option.Name);

      return builder.ToString();
    }

    public static String LinkDeleteForList(this HtmlHelper html, DialogSubmitOption option)
    {

      string onClick = CreateLink(html, option);
      // Create tag builder  
      var builder = new TagBuilder("span");
      builder.MergeAttribute("class", "ui-state-error-text");

      var builderLink = new TagBuilder("a");

      builderLink.MergeAttribute("class", "ui-icon ui-icon-closethick");
      builderLink.MergeAttribute("href", "javascript:void(0)");
      builderLink.MergeAttribute("onClick", onClick);

      builderLink.SetInnerText(option.Name);
      builder.InnerHtml += builderLink.ToString();
      return builder.ToString();
    }

    private static string CreateLink(this HtmlHelper html, DialogSubmitOption option)
    {
      var url = option.URL;

      // check if has ReloadID and ReloadURL param
      var param = html.ViewContext.RequestContext.HttpContext.Request.Params;
      if (param.Get("ReloadID") != null && param.Get("ReloadURL") != null)
      {
        url = Javascript.addParamToURL(url, "ReloadID", param.Get("ReloadID"));
        url = Javascript.addParamToURL(url, "ReloadURL", param.Get("ReloadURL"));
      }

      var onClick = String.Format("$.post('{0}', $(this).parents('form').serialize(), Core.DialogCallback)", url);
      if (option.CausesValidation)
      {
        onClick = string.Format("if ($(this).parents('form').valid()) {{{0}}}", onClick);
      }
      if (option.ConfirmMessage != null)
      {
        onClick = String.Format("if ({0}){{{1}}}", String.Format(@"confirm(""{0}"")", option.ConfirmMessage), onClick);
      }
      else if (option.CallBefore != null)
      {
        onClick = String.Format("if ({0}){{{1}}}", option.CallBefore, onClick);
      }
      return onClick;
    }


  }

}
