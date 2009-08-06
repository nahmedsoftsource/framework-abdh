using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABDH_Demo.Utility.Pager;
using System.Web.Routing;

namespace ABDH_Demo.Utility
{
  public static class GridExtensions
  {
    public static string SimpleGrid<T>(this HtmlHelper html, IEnumerable<T> listItems, IEnumerable<ColumnOption<T>> options)
    {
      return SimpleGrid<T>(html, listItems, options, true);
    }

    public static string SimpleGrid<T>(this HtmlHelper html, IEnumerable<T> listItems, IEnumerable<ColumnOption<T>> options, bool showHeader)
    {

      var buider = new TagBuilder("table");
      buider.MergeAttribute("class", "table-list maxwidth");
      buider.MergeAttribute("border", "0");
      buider.MergeAttribute("cellpadding", "0");
      buider.MergeAttribute("cellspacing", "0");

      if (showHeader)
        buider.InnerHtml += BuildListDataHeader<T>(html, options);
      if (listItems != null)
      {
        bool isAltRow = false;
        foreach (var item in listItems)
        {
          buider.InnerHtml += BuildListDataRow(html, item, options, isAltRow);
          isAltRow = !isAltRow;
        }
      }
      return buider.ToString();
    }

    /// <summary>
    /// build list data header
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="html"></param>
    /// <param name="columns"></param>
    /// <returns></returns>
    private static String BuildListDataHeader<T>(this HtmlHelper html, IEnumerable<ColumnOption<T>> options)
    {
      var builder = new TagBuilder("tr");
      builder.AddCssClass("table-list-header");

      foreach (var column in options)
      {
        var b1 = new TagBuilder("th");
        if (column.HeaderAttributes != null)
        {
          b1.MergeAttributes(new RouteValueDictionary(column.HeaderAttributes));
        }
        String value = null;

        var option = column as ColumnOption<T>;
        ColumnCheckbox<T> headerCheckBox = column as ColumnCheckbox<T>;
        if (headerCheckBox != null)
        {
          value = BuildHeaderCheckbox(headerCheckBox);
          if (value != null)
          {
            b1.InnerHtml += value;
            builder.InnerHtml += b1.ToString();
          }
        }
        else
        {
          if (option.Name != null)
          {
            value = option.Name;
          }
          else
          {
            value = option.FieldName;
          }
          if (value != null)
          {
            b1.SetInnerText(value);
            builder.InnerHtml += b1.ToString();
          }
        }
      }

      return builder.ToString();
    }

    private static string BuildHeaderCheckbox<T>(ColumnCheckbox<T> headerColumn)
    {
      var builder = new TagBuilder("input");
      builder.MergeAttribute("type", "checkbox");
      builder.MergeAttribute("name", headerColumn.Name);
      builder.MergeAttribute("id", headerColumn.Name);
      if (headerColumn.CheckAllFunction != null && !"".Equals(headerColumn.CheckAllFunction))
        builder.MergeAttribute("onchange", "javascript:" + headerColumn.CheckAllFunction);

      return builder.ToString();
    }

    /// <summary>
    /// build list data row
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="html"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    private static String BuildListDataRow<T>(this HtmlHelper html, T item, IEnumerable<ColumnOption<T>> options, bool isAltRow)
    {
      var builder = new TagBuilder("tr");

      RouteValueDictionary values = new RouteValueDictionary(item);

      foreach (var column in options)
      {
        var b1 = new TagBuilder("td");
        if (isAltRow && column.AltRowAttributes != null)
        {
          b1.MergeAttributes(new RouteValueDictionary(column.AltRowAttributes));
        }
        else if (column.RowAttributes != null)
        {
          b1.MergeAttributes(new RouteValueDictionary(column.RowAttributes));
        }

        String value = null;
        var option = column as ColumnOption<T>;

        if (option.Action != null)
        {
          value = option.Action(item);
        }
        else if (option.FieldName != null && values.ContainsKey(option.FieldName) && values[option.FieldName] != null)
        {
          value = values[option.FieldName].ToString();
        }

        if (value != null)
        {
          b1.InnerHtml = value;
          builder.InnerHtml += b1.ToString();
        }
      }

      return builder.ToString();
    }

  }
}
