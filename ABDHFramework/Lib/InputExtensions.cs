using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Text;
using System.Web.Mvc.Html;

namespace ABDHFramework.Lib
{
  public static class InputExtensions
  {
    
      #region Date picker

      /// <summary>
      /// date picker textbox
      /// </summary>
      /// <param name="html"></param>
      /// <param name="name"></param>
      /// <returns></returns>
      public static String DatePickerTextBox(this HtmlHelper html, String name)
      {
        return DatePickerTextBox(html, name, null, null);
      }

      /// <summary>
      /// date picker textbox
      /// </summary>
      /// <param name="html"></param>
      /// <param name="name"></param>
      /// <returns></returns>
      public static String DatePickerTextBox(this HtmlHelper html, String name, Object value)
      {
        return DatePickerTextBox(html, name, value, null);
      }

      /// <summary>
      /// Dates the picker text box.
      /// </summary>
      /// <param name="html">The HTML.</param>
      /// <param name="name">The name.</param>
      /// <param name="value">The value.</param>
      /// <returns></returns>
      public static String DatePickerTextBox(this HtmlHelper html, String name, Object value, Object htmlAttributes)
      {
        return DatePickerTextBox(html, name, value, new RouteValueDictionary(htmlAttributes));
      }

      /// <summary>
      /// date picker textbox
      /// </summary>
      /// <param name="html">HTML helper.</param>
      /// <param name="name">The name.</param>
      /// <param name="value">The value.</param>
      /// <param name="htmlAttributes">The HTML attributes.</param>
      /// <returns></returns>
      public static String DatePickerTextBox(this HtmlHelper html, String name, Object value, IDictionary<string, object> htmlAttributes)
      {
        string id = UIHelper.GenerateId(name);
        StringBuilder sb = new StringBuilder();

        Object content = null;
        if (value is DateTime)
        {
          content = ((DateTime)value).ToShortDateString();
        }
        else if (value != null)
        {
          content = value.ToString();
        }

        sb.Append(html.TextBox(name, content, htmlAttributes));
        sb.Append("<a class='tool-icon-button' href='javascript:void(0)' onclick=\"showCalendar('" + id + "');return false;\"><span class='tool-icon tool-icon-calendar'>select date</span></a>");
        return sb.ToString();
      }
      #endregion

      #region Time picker

      /// <summary>
      /// Selects the time.
      /// </summary>
      /// <param name="html">The HTML.</param>
      /// <param name="name">The name.</param>
      /// <param name="htmlAttr">The HTML attr.</param>
      /// <returns></returns>
      static public string TimePicker(this HtmlHelper html, string name, DateTime currentTime, object htmlAttr)
      {
        List<SelectListItem> list = new List<SelectListItem>();
        DateTime time = DateTime.Today;
        int seletedIndex = (int)Math.Round(((double)currentTime.TimeOfDay.TotalMinutes) / 30.0, 0);
        for (int i = 0; i < 48; i++)
        {
          list.Add(new SelectListItem
          {
            Value = time.ToString("hh:mm tt"),
            Text = time.ToString("hh:mm tt"),
            Selected = i == seletedIndex
          });
          time = time.AddMinutes(30);
        }
        return html.DropDownList(name, list, "-- Select time --", htmlAttr);
      }
      #endregion

      #region General helpers

      static public string IdFor(this HtmlHelper html, string name)
      {
        return UIHelper.GenerateId(name);
      }
      #endregion

      #region Label

      static public string LabelFor(this HtmlHelper html, string name, string text)
      {
        return LabelFor(html, name, text, "", null);
      }

      static public string LabelFor(this HtmlHelper html, string name, string text, string cssClass)
      {
        return LabelFor(html, name, text, cssClass, null);
      }

      static public string LabelFor(this HtmlHelper html, string name, string text, string cssClass, object htmlAttr)
      {
        string id = UIHelper.GenerateId(name);
        TagBuilder builder = new TagBuilder("label");
        builder.MergeAttributes(new RouteValueDictionary(htmlAttr));
        builder.MergeAttribute("name", id);
        builder.AddCssClass(cssClass);
        builder.SetInnerText(text);
        return builder.ToString();
      }
      #endregion
    }
}
