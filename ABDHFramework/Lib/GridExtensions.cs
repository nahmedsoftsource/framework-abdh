using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ABDHFramework.Lib.Pager;
using ABDHFramework.Lib.FluentHtml;
using ABDHFramework.Common;
using ABDHFramework.Data;
using ABDHFramework.Utility.Javascripts;

namespace ABDHFramework.Lib
{
  public static class GridExtensions
  {
    private const string ROW_EMPTY_STYLE = "emptyrow";

    public static string SimpleGrid<T>(this HtmlHelper html, IEnumerable<T> listItems, IEnumerable<ColumnOption<T>> options)
    {
      return SimpleGrid<T>(html, listItems, options, null, true);
    }

    public static string SimpleGrid<T>(this HtmlHelper html, IEnumerable<T> listItems, IEnumerable<ColumnOption<T>> options, bool showHeader)
    {
      return SimpleGrid<T>(html, listItems, options, null, showHeader);
    }

    public static string SimpleGrid<T>(this HtmlHelper html, IEnumerable<T> listItems, IEnumerable<ColumnOption<T>> options, GridOption<T> gridOption)
    {
      return SimpleGrid<T>(html, listItems, options, gridOption, true);
    }

    private static string SimpleGrid<T>(this HtmlHelper html, IEnumerable<T> listItems, IEnumerable<ColumnOption<T>> options, GridOption<T> gridOption, bool showHeader)
    {
      ContainerElement container = new ContainerElement();
      container.Class("table-container");
      if (gridOption != null && gridOption.Style!=null)
        container.Class("table-container").Style(gridOption.Style);
      TagBuilder builder = new TagBuilder("table");
      builder.AddCssClass("table-list maxwidth");
      builder.MergeAttribute("border", "0");
      builder.MergeAttribute("cellpadding", "0");
      builder.MergeAttribute("cellspacing", "0");

      if (showHeader)
        builder.InnerHtml += BuildListDataHeader<T>(html, options, gridOption);
      if (listItems != null && listItems.Count() > 0)
      {
        bool isAltRow = false;
        foreach (var item in listItems)
        {
          builder.InnerHtml += BuildListDataRow(html, item, options, isAltRow, gridOption);
          isAltRow = !isAltRow;
        }
      }
      else if (gridOption == null || gridOption.Style == null || !gridOption.Style.Contains(HtmlStyleAttribute.Height))
      {
        builder.InnerHtml += BuildListEmptyDataRow(html, options);
      }
      container.InnerElement(new TextElement().InnerText(builder.ToString()));
      return container.ToString();
    }

    public static string BuildSortHeader<T>(this HtmlHelper html, ColumnOption<T> column, GridOption<T> gridOption)
    {
      return BuildSortHeaderTag<T>(html, gridOption, column).ToString();
    }

    public static void GetSortParams(this HtmlHelper html, ref string sortColumn, ref string sortOption)
    {
      if (html.ViewContext.HttpContext.Request.Params.AllKeys.Contains("SortColumn"))
      {
        sortColumn = html.ViewContext.HttpContext.Request.Params["SortColumn"];
        sortOption = html.ViewContext.HttpContext.Request.Params["SortOption"];
      }
    }

    /// <summary>
    /// Build table header for sorting
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="html"></param>
    /// <param name="gridOption"></param>
    /// <param name="column"></param>
    /// <returns></returns>
    public static TagBuilder BuildSortHeaderTag<T>(this HtmlHelper html, GridOption<T> gridOption, ColumnOption<T> column)
    {
      string sortColumn = column.FieldName;
      string sortOptionValue = "";
      bool currentSort = false;
      string sortButton = "";
      string upButtonCSS = "sorted-asc";
      string downButtonCSS = "sorted-desc";
      string unsortedCSS = "unsorted";

      GetSortParams(html, ref sortColumn, ref sortOptionValue);
      if (string.IsNullOrEmpty(sortColumn) || string.IsNullOrEmpty(sortOptionValue))
      {
        if (!string.IsNullOrEmpty(gridOption.DefaultSortColumn) && gridOption.DefaultSortColumn.Equals(column.FieldName))
        {
          currentSort = true;
          sortOptionValue = gridOption.DefaultSortOption;
        }
        else
        {
          sortColumn = column.FieldName;
          sortOptionValue = column.DefaultSortOption;
        }
      }
      else
      {
        if (sortColumn.Equals(column.FieldName))
          currentSort = true;
        else
          sortOptionValue = column.DefaultSortOption;
      }

      #region build parameter list
      var param = html.ViewContext.HttpContext.Request.Form;
      //paging param
      var data = new RouteValueDictionary();
      foreach (var key in param.AllKeys)
      {
        if (!data.ContainsKey(key) && !key.Equals("SortColumn") && !key.Equals("SortOption"))
        {
          string[] values = param.GetValues(key);
          data.Add(key, values);
        }
      }
      int page = 1;
      string pageKey = "Page";
      if (html.ViewContext.HttpContext.Request.Params[pageKey] != null)
        int.TryParse(html.ViewContext.HttpContext.Request.Params[pageKey], out page);
      #endregion

      var dataObj = Json.Decode<Object>(Json.EncodeDictionary(data));
      var HtmlID = gridOption.HtmlID;

      //parameters for sorting
      if (string.IsNullOrEmpty(sortOptionValue))
        sortOptionValue = SortOption.Asc.ToString();
      if (sortOptionValue.Equals(SortOption.Asc.ToString()))
      {
        sortOptionValue = SortOption.Desc.ToString();
        sortButton = upButtonCSS;
      }
      else
      {
        sortOptionValue = SortOption.Asc.ToString();
        sortButton = downButtonCSS;
      }
      var url = Javascript.addParamToURL(gridOption.URL, "SortColumn", column.FieldName);
      url = Javascript.addParamToURL(url, "SortOption", sortOptionValue);
      url = Javascript.addParamToURL(url, pageKey, page.ToString());

      //build sort header
      TagBuilder header = null;
      if (currentSort)
      {
        header = JavascriptHelper.TableHeaderForSort(column.Name, new RemoteOption { URL = url, Update = HtmlID, Data = dataObj });
        header.AddCssClass(sortButton);
      }
      else
      {
        header = JavascriptHelper.TableHeaderForSort(column.Name, new RemoteOption { URL = url, Update = HtmlID, Data = dataObj });
        header.AddCssClass(unsortedCSS);
      }

      return header;
    }

    #region Private methods
    /// <summary>
    /// build list data row
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="html"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    private static String BuildListDataRow<T>(this HtmlHelper html, T item, IEnumerable<ColumnOption<T>> options, bool isAltRow, GridOption<T> gridOption)
    {
      var builder = new TagBuilder("tr");
      if (gridOption != null && gridOption.OnRowPreferChecking != null)
      {
        if (gridOption.OnRowPreferChecking(item))
        {
          builder.AddCssClass("prefer");
        }
      }
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

    /// <summary>
    /// build list data header
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="html"></param>
    /// <param name="columns"></param>
    /// <returns></returns>
    public static String BuildListDataHeader<T>(this HtmlHelper html, IEnumerable<ColumnOption<T>> options, GridOption<T> gridOption)
    {
      var builder = new TagBuilder("tr");
      builder.AddCssClass("table-list-header");

      foreach (var column in options)
      {
        var b1 = new TagBuilder("th");
        String value = null;

        var option = column as ColumnOption<T>;
        if (option.Name != null)
        {
          value = option.Name;
        }
        else
        {
          value = option.FieldName;
        }
        if (column is ColumnCheckbox<T>)
        {
          var checkboxCol = column as ColumnCheckbox<T>;
          string checkAllID = checkboxCol.FieldName + "_checkAll";
          CheckBox checkAll = new CheckBox("").Id(checkAllID).Value("");
          if (!string.IsNullOrEmpty(checkboxCol.CheckAllFunction))
          {
            checkAll.OnClick(checkboxCol.CheckAllFunction);
          }
          else
          {
            string selector = "$('[name=" + checkboxCol.FieldName + "]')";

            //b1.InnerHtml += UIHelper.JavascriptTag("$(function(){$('#__id__').click(function(){})});"
            //  .Replace("__id__", checkAllID)
            //  .Replace("__selector__", selector));
            checkAll.OnClick("if (this.checked) __selector__.attr('checked', 'checked'); else __selector__.removeAttr('checked')"
              .Replace("__selector__", selector));
          }
          if (!String.IsNullOrEmpty(checkboxCol.Name))
          {
            checkAll.LabelAfter(checkboxCol.Name);
          }
          b1.InnerHtml += checkAll.ToString();
        }
        else if (value != null)
        {
          if (option.IsSort && !string.IsNullOrEmpty(option.FieldName) && gridOption != null && !string.IsNullOrEmpty(gridOption.URL))
            b1 = BuildSortHeaderTag<T>(html, gridOption, option);
          else if (!string.IsNullOrEmpty(value))
            b1.SetInnerText(value);
          else
            b1.InnerHtml = "&nbsp;";
        }
        if (column.HeaderAttributes != null)
        {
          b1.MergeAttributes(new RouteValueDictionary(column.HeaderAttributes));
        }
        builder.InnerHtml += b1.ToString();
      }

      return builder.ToString();
    }
    #endregion

    /// <summary>
    /// build list data row
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="html"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    private static String BuildListEmptyDataRow<T>(this HtmlHelper html, IEnumerable<ColumnOption<T>> options)
    {
      var builder = new TagBuilder("tr");

      foreach (var column in options)
      {
        var b1 = new TagBuilder("td");
        b1.Attributes.Add("class", ROW_EMPTY_STYLE);
        builder.InnerHtml += b1.ToString();
      }

      return builder.ToString();
    }

    public static String RenderEmptyDataRow(this HtmlHelper html, int numberOfColumns)
    {
      var builder = new TagBuilder("tr");

      for (int i = 0; i < numberOfColumns; i++)
      {
        var b1 = new TagBuilder("td");
        b1.Attributes.Add("class", ROW_EMPTY_STYLE);
        builder.InnerHtml += b1.ToString();
      }

      return builder.ToString();
    }
  }
}
