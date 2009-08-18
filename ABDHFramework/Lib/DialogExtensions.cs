using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABDHFramework.Lib;
using ABDHFramework.Utility.Javascripts;

namespace ABDHFramework.Lib
{
  public static class DialogExtensions
  {
    /// <summary>
    /// link to open remote dialog
    /// </summary>
    /// <param name="html"></param>
    /// <param name="linkText"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String LinkToRemoteDialog(this HtmlHelper html, String linkText, DialogOpenOption option)
    {
      return DialogHelper.LinkToRemote(linkText, option);
    }

    /// <summary>
    /// link to open remote dialog
    /// </summary>
    /// <param name="html"></param>
    /// <param name="linkText"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String LinkToRemoteDialog(this HtmlHelper html, String linkText, DialogOpenOption option, string css)
    {
      return DialogHelper.LinkToRemote(linkText, option, css);
    }
    /// <summary>
    /// button to open remote dialog
    /// </summary>
    /// <param name="html"></param>
    /// <param name="linkText"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String ButtonToRemoteDialog(this HtmlHelper html, String linkText, DialogOpenOption option)
    {
      return DialogHelper.ButtonToRemote(linkText, option);
    }

    public static String ButtonToRemoteDialog(this HtmlHelper html, String linkText, DialogOpenOption option, Object htmlAttributes)
    {
      return DialogHelper.ButtonToRemote(linkText, option, htmlAttributes);
    }

    /// <summary>
    /// cancel button with default name "Cancel"
    /// </summary>
    /// <param name="html"></param>
    /// <returns></returns>
    public static String DialogCloseButton(this HtmlHelper html)
    {
      return DialogCloseButton(html, "Cancel");
    }

    /// <summary>
    /// cancel button
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static String DialogCloseButton(this HtmlHelper html, String name)
    {
      return String.Format(@"<button class=""form-button ui-corner-all"" type=""button"" onclick=""Core.dialog.closeBox()"">{0}</button>", name);
    }

    /// <summary>
    /// Button to serialize all data of form and post to an URL
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="url"></param>
    /// <returns></returns>
    public static String DialogSubmitToRemote(this HtmlHelper html, String name, String url)
    {
      return String.Format(@"<button class=""form-button ui-corner-all next"" type=""button""  onclick=""javascript:void($.post('{0}', $(this).parents('form').serialize(), Core.DialogCallback))"">{1}</button>", url, name);
    }

    /// <summary>
    /// Button to serialize all data of form and post to an URL. Call a javascript method before submit
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="url"></param>
    /// <param name="callBefore"></param>
    /// <returns></returns>
    public static String DialogSubmitToRemote(this HtmlHelper html, String name, String url, String callBefore)
    {
      return String.Format(@"<button class=""form-button ui-corner-all next"" type=""button""  onclick=""{2};$.post('{0}', $(this).parents('form').serialize(), Core.DialogCallback)"">{1}</button>", url, name, callBefore);
    }

    /// <summary>
    /// Button to serialize all data of form and post to an URL. Call a confirm before submit
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="url"></param>
    /// <param name="confirmMethod"></param>
    /// <returns></returns>
    public static String DialogSubmitToRemoteWithConfirm(this HtmlHelper html, String name, String url, String confirmMethod)
    {
      return String.Format(@"<button class=""form-button ui-corner-all next"" type=""button""  onclick=""if ({2}){{$.post('{0}', $(this).parents('form').serialize(), Core.DialogCallback)}}"">{1}</button>", url, name, confirmMethod);
    }

    /// <summary>
    /// Button to serialize all data of form and post to an URL and do not proccess anything
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="url"></param>
    /// <param name="callBefore"></param>
    /// <returns></returns>
    public static String DialogSubmitToRemoteNoClose(this HtmlHelper html, String name, String url)
    {
      return String.Format(@"<button class=""form-button ui-corner-all next"" type=""button""  onclick=""javascript:void($.post('{0}', $(this).parents('form').serialize()))"">{1}</button>", url, name);
    }

    /// <summary>
    /// Button to open a dialog
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="url"></param>
    /// <returns></returns>
    public static String ButtonToRemoteDialog(this HtmlHelper html, string name, string url)
    {
      return String.Format(@"<input class='form-button ui-corner-all next'
type='button' value='{0}' onclick=""Core.openDialog('{1}')"" />", name, url);
    }

    /// <summary>
    /// Button to open a dialog
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="url"></param>
    /// <param name="cssClass"></param>
    /// <returns></returns>
    public static String ButtonToRemoteDialog(this HtmlHelper html, string name, string url, string cssClass)
    {
      return String.Format(@"<input 
type='button' value='{0}' onclick=""Core.openDialog('{1}')"" class={2}/>", name, url, cssClass);
    }

    /// <summary>
    /// Button to open a dialog
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="url"></param>
    /// <param name="cssClass"></param>
    /// <returns></returns>
    public static String ButtonToRemoteDialog(this HtmlHelper html, string name, DialogOpenOption option, string cssClass)
    {
      return String.Format(@"<input 
        type='button' value='{0}' onclick='{1}' class={2}/>", name, DialogHelper.OpenDialogScript(option), cssClass);
    }

    public static String NewRecordButton(this HtmlHelper html, DialogOpenOption option)
    {
      return String.Format(@"<input 
        type='button' value='{0}' onclick='{1}' class='{2}'/>", "NEW RECORD", DialogHelper.OpenDialogScript(option), "toolbar-button toolbar-icon-task-add");
    }

    public static String NewRecordButtonForList(this HtmlHelper html, DialogOpenOption option)
    {
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      sb.Append("<div style='width: 90px;float:right; margin:5px'>");
      sb.Append("<div style='margin-right: 1px;' onclick='{0}' class='iadd ibutton'>");
      sb.Append("<span></span>");
      sb.Append("</div>");
      sb.Append("<div style='margin-top: 6px;'>NEW RECORD</div>");
      sb.Append("</div>");
      return String.Format(sb.ToString(), DialogHelper.OpenDialogScript(option));
    }

    public static String EditLinkForList(this HtmlHelper html, DialogOpenOption option)
    {
      return LinkToRemoteDialog(html, "", option, "ui-icon ui-icon-pencil");
    }

    
    /// <summary>
    /// Button to open a dialog
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="url"></param>
    /// <returns></returns>
    public static String ButtonToRemoteDialogHaveReload(this HtmlHelper html, string name, string url, string reloadID, string reloadURL)
    {
      url = Javascript.addParamToURL(url, "reloadID", reloadID);
      url = Javascript.addParamToURL(url, "reloadURL", reloadURL);
      return String.Format(@"<input 
type='button' value='{0}' onclick=""Core.openDialog('{1}')"" />", name, url);
    }

    /// <summary>
    /// Link to open a dialog
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="url"></param>
    /// <returns></returns>
    public static String LinkToRemoteDialog(this HtmlHelper html, string name, string url)
    {
      return String.Format(@"<a href=""#"" onClick=""Core.openDialog('{1}')"" >{0}</a>", name, url);
    }

    /// <summary>
    /// Link to open a dialog, this link has style specified by the third parameter
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="url"></param>
    /// <param name="css">name of the css style</param>
    /// <returns></returns>

    public static String LinkToRemoteDialogWithStyle(this HtmlHelper html, string name, string url, string css)
    {
      return String.Format(@"<a href=""#"" onClick=""Core.openDialog('{1}')"" class=""{2}"" >{0}</a>", name, url, css);
    }

    public static String EditButtonForList(this HtmlHelper html, DialogOpenOption option)
    {
      System.Text.StringBuilder sb = new System.Text.StringBuilder();
      sb.Append("<div style='width: 50px;float:right; margin:5px'>");
      sb.Append("<div style='margin-right: 1px;' onclick='{0}' class='iedit ibutton'>");
      sb.Append("<span></span>");
      sb.Append("</div>");
      sb.Append("<div style='margin-top: 6px;'>EDIT</div>");
      sb.Append("</div>");
      return String.Format(sb.ToString(), DialogHelper.OpenDialogScript(option));
    }
  }
}
