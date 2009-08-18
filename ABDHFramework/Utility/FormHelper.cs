using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Framework.Utility
{
  public static class FormHelper
  {
    /// <summary>
    /// form tag
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static IDisposable FormTag(this HtmlHelper html, String url)
    {
      return FormTag(html, url, null /* attribute */);
    }

    /// <summary>
    /// form tag
    /// </summary>
    /// <param name="html"></param>
    /// <param name="url"></param>
    /// <param name="attributes"></param>
    /// <returns></returns>
    public static IDisposable FormTag(this HtmlHelper html, String url, object attributes)
    {
      var builder = new TagBuilder("form");

      var values = new RouteValueDictionary(attributes);
      builder.MergeAttributes(values);
      builder.MergeAttribute("action", url);

      var startTag = builder.ToString(TagRenderMode.StartTag);
      html.ViewContext.HttpContext.Response.Write(startTag);

      return new DisposableAction(delegate()
      {
        html.ViewContext.HttpContext.Response.Write(builder.ToString(TagRenderMode.EndTag));
      });
    }

    /// <summary>
    /// reset button
    /// </summary>
    /// <param name="html"></param>
    /// <returns></returns>
    public static String ResetButton(this HtmlHelper html)
    {
      return ResetButton(html, "Reset", new { @class = "form-button ui-corner-all" });
    }

    public static String ResetButton(this HtmlHelper html, string name)
    {
      return ResetButton(html, name, new { @class = "form-button ui-corner-all" });
    }

    public static String ResetButton(this HtmlHelper html, string name, object htmlAttributes)
    {
      var builder = new TagBuilder("input");

      builder.MergeAttribute("type", "reset");
      builder.MergeAttribute("value", name);
      builder.MergeAttributes((htmlAttributes == null) ? new RouteValueDictionary() : new RouteValueDictionary(htmlAttributes));
      return builder.ToString();
    }

    /// <summary>
    /// radio button
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <param name="label"></param>
    /// <returns></returns>
    public static String RadioButton(this HtmlHelper html, String name, object value, String label)
    {
      return RadioButton(html, name, value, label, false, new { });
    }

    /// <summary>
    /// radio button
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <param name="label"></param>
    /// <returns></returns>
    public static String RadioButton(this HtmlHelper html, String name, object value, String label, bool? isChecked)
    {
      return RadioButton(html, name, value, label, isChecked, new { });
    }

    /// <summary>
    /// radio button
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="value"></param>
    /// <param name="label"></param>
    /// <param name="attributes"></param>
    /// <returns></returns>
    public static String RadioButton(this HtmlHelper html, String name, object value, String label, bool? isChecked, object attributes)
    {
      var builder = new TagBuilder("input");

      var id = name + "_" + value.ToString();
      var attrDic = new RouteValueDictionary(attributes);
      if (attrDic.ContainsKey("id"))
      {
        id = attrDic["id"].ToString();
      }

      builder.MergeAttribute("type", "radio");
      builder.MergeAttribute("value", value.ToString());
      builder.MergeAttribute("name", name);
      builder.MergeAttribute("id", id);
      builder.MergeAttributes(attrDic, true);

      if (isChecked == true){
        builder.MergeAttribute("checked", "checked");
      }

      var lb = new TagBuilder("label");
      lb.MergeAttribute("for", id);
      lb.SetInnerText(label);

      return builder.ToString() + lb.ToString();
    }

    public static String MyCheckBox(this HtmlHelper htmlHelper, string name, Object value, bool isChecked)
    {
      return htmlHelper.MyCheckBox(name, value, isChecked, new { } /* html attribute */);
    }

    public static String MyCheckBox(this HtmlHelper htmlHelper, string name, Object value, bool isChecked, object htmlAttribute){
      var builder = new TagBuilder("input");
      builder.MergeAttribute("type", "checkbox");
      builder.MergeAttribute("name", name);

      var attrDic = new RouteValueDictionary(htmlAttribute);

      builder.MergeAttributes(attrDic, true);

      if (value != null){
        builder.MergeAttribute("value", value.ToString());
      }

      if (isChecked)
      {
        builder.MergeAttribute("checked", "checked");
      }
      return builder.ToString();
    }

    /// <summary>
    /// smm checkbox
    /// </summary>
    /// <param name="htmlHelper"></param>
    /// <param name="name"></param>
    /// <param name="isChecked"></param>
    /// <returns></returns>
    public static String SMMCheckBox(this HtmlHelper htmlHelper, string name, bool isChecked)
    {
      var builder = new TagBuilder("input");
      builder.MergeAttribute("type", "checkbox");
      builder.MergeAttribute("name", name);

      if (isChecked)
      {
        builder.MergeAttribute("checked", "checked");
      }      
      return builder.ToString();
    }
    public static String SMMCheckBox(this HtmlHelper htmlHelper, string name, bool isChecked, object htmlAttributes)
    {
      var builder = new TagBuilder("input");
      builder.MergeAttribute("type", "checkbox");
      builder.MergeAttribute("name", name);

      if (isChecked)
      {
        builder.MergeAttribute("checked", "checked");
      }

      builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
      return builder.ToString();
    }



  }
}
