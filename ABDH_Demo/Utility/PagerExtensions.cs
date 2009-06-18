using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABDH_Demo.Utility.Pager;
using ABDH_Demo.Common;
using System.Web.Routing;
using ABDH_Demo.Utility.Javascripts;

namespace ABDH_Demo.Utility
{
  public static class PagerExtensions
  {

    /// <summary>
    /// Ajaxes the pager.
    /// </summary>
    /// <param name="html">The HTML.</param>
    /// <param name="options">The options.</param>
    /// <param name="options">The options.</param>
    /// <returns></returns>
    public static string AjaxPager(this HtmlHelper html, PagingOption pagingOptions, AjaxPaginationOption ajaxOptions)
    {
      var param = html.ViewContext.HttpContext.Request.Form;

      // merge data of ajax pagination option and request
      var data = new RouteValueDictionary(ajaxOptions.Data);
      if (ajaxOptions.AutoLoadParam == true)
      {
        foreach (var key in param.AllKeys)
        {
          if (key != null && !data.ContainsKey(key))
          {
            data.Add(key, param[key]);
          }
        }
      }

      int firstPage = 1;
      var before = (int)Math.Ceiling((double)(pagingOptions.PageSize / 2));
      var after = pagingOptions.PageSize - before;
      var startPage = Math.Max(1, pagingOptions.CurrentPage - before);
      int lastPage = (int)Math.Ceiling((double)(pagingOptions.TotalRows) / (double)(pagingOptions.PageSize));
      var endPage = Math.Min(lastPage, pagingOptions.CurrentPage + after);


      var dataObj = Json.Decode<Object>(Json.EncodeDictionary(data));

      // autload htmlID
      var HtmlID = ajaxOptions.HtmlID;
      if (ajaxOptions.AutoLoadHtmlID == true && param["HtmlID"] != null)
      {
        HtmlID = param["HtmlID"];
      }

      string hiddenRefresh = html.ButtonToRemote("", "cmdRefresh", new RemoteOption { URL = pagingOptions.UrlMaker(pagingOptions.CurrentPage), Update = HtmlID, Data = dataObj }, new { style = "display:none" });
      if (pagingOptions.TotalRows <= pagingOptions.PageSize)
      {
        return hiddenRefresh;
      }


      var ret = new List<String>();


      //pager.LinkPattern = linkPagePattern;
      string currentLinkPattern = "<b>" + pagingOptions.CurrentPage + "</b>";

      // first page
      if (pagingOptions.CurrentPage != firstPage)
      {
        ret.Add(html.LinkToRemote("First", new RemoteOption { URL = pagingOptions.UrlMaker(firstPage), Update = HtmlID, Data = dataObj }));
      }

      // previous page
      if (pagingOptions.CurrentPage > 1)
      {
        ret.Add(html.LinkToRemote("Previous", new RemoteOption { URL = pagingOptions.UrlMaker(pagingOptions.CurrentPage - 1), Update = HtmlID, Data = dataObj }));
      }

      // pages
      for (int i = startPage; i <= endPage; i++)
      {
        if (i == pagingOptions.CurrentPage)
        {
          ret.Add(currentLinkPattern);
        }
        else
        {
          ret.Add(html.LinkToRemote(i.ToString(), new RemoteOption { URL = pagingOptions.UrlMaker(i), Update = HtmlID, Data = dataObj }));
        }
      }

      // next page
      if (pagingOptions.CurrentPage < endPage)
      {
        ret.Add(html.LinkToRemote("Next", new RemoteOption { URL = pagingOptions.UrlMaker(pagingOptions.CurrentPage + 1), Update = HtmlID, Data = dataObj }));
      }

      // last page
      if (pagingOptions.CurrentPage != lastPage)
      {
        ret.Add(html.LinkToRemote("Last", new RemoteOption { URL = pagingOptions.UrlMaker(lastPage), Update = HtmlID, Data = dataObj }));
      }
      ret.Add(hiddenRefresh);
      return String.Join(" ", ret.ToArray());
    }


    /// <summary>
    /// show web pager
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="html"></param>
    /// <param name="pager"></param>
    /// <param name="columns"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String ShowWebPager<T>(this HtmlHelper html, WebPager<T> pager, Object[] columns, AjaxPaginationOption option)
    {
      return ListData(html, pager, columns) + AjaxPagination(html, pager, option);
    }

    /// <summary>
    /// ajax pagination
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="html"></param>
    /// <param name="pager"></param>
    /// <param name="option"></param>
    /// <returns></returns>
    public static String AjaxPagination<T>(this HtmlHelper html, WebPager<T> pager, AjaxPaginationOption option)
    {
      var param = html.ViewContext.HttpContext.Request.Form;

      // merge data of ajax pagination option and request
      var data = new RouteValueDictionary(option.Data);
      if (option.AutoLoadParam == true)
      {
        foreach (var key in param.AllKeys)
        {
          if (key != null && !data.ContainsKey(key))
          {
            data.Add(key, param[key]);
          }
        }
      }

      var dataObj = Json.Decode<Object>(Json.EncodeDictionary(data));

      // autload htmlID
      var HtmlID = option.HtmlID;
      if (option.AutoLoadHtmlID == true && param["HtmlID"] != null)
      {
        HtmlID = param["HtmlID"];
      }
      var url = Javascript.addParamToURL(option.URL, "page", WebPager<T>.PageValue);

      string hiddenRefresh = html.ButtonToRemote(WebPager<T>.PageName, "cmdRefresh", new RemoteOption { URL = url, Update = HtmlID, Data = dataObj }, new { style = "display:none" }).Replace(WebPager<T>.PageValue, pager.GetPage().ToString());
      if (!pager.HaveToPagination())
      {
        return hiddenRefresh;
      }

      var ret = new List<String>();

      var linkPattern = html.LinkToRemote(WebPager<T>.PageName, new RemoteOption { URL = url, Update = HtmlID, Data = dataObj });
      var linkPagePattern = linkPattern.Replace(WebPager<T>.PageName, WebPager<T>.PageValue);

      pager.LinkPattern = linkPagePattern;
      pager.CurrentLinkPattern = "<b>" + WebPager<T>.PageValue + "</b>";

      // first page
      if (pager.GetPage() != pager.GetFirstPage())
      {
        ret.Add(linkPattern.Replace(WebPager<T>.PageName, "First").Replace(WebPager<T>.PageValue, pager.GetFirstPage().ToString()));
      }

      // previous page
      if (pager.GetPreviousPage() > 0)
      {
        ret.Add(linkPattern.Replace(WebPager<T>.PageName, "Previous").Replace(WebPager<T>.PageValue, pager.GetPreviousPage().ToString()));
      }

      // pages
      foreach (var link in pager.GetLinks())
      {
        ret.Add(link);
      }

      // next page
      if (pager.GetNextPage() > 0)
      {
        ret.Add(linkPattern.Replace(WebPager<T>.PageName, "Next").Replace(WebPager<T>.PageValue, pager.GetNextPage().ToString()));
      }

      // last page
      if (pager.GetPage() != pager.GetLastPage())
      {
        ret.Add(linkPattern.Replace(WebPager<T>.PageName, "Last").Replace(WebPager<T>.PageValue, pager.GetLastPage().ToString()));
      }

      return String.Join(" ", ret.ToArray()) + hiddenRefresh;
    }

    public static String ListData<T>(this HtmlHelper html, IPager<T> pager)
    {
      return ListData(html, pager, null);
    }

    /// <summary>
    /// build list data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="html"></param>
    /// <param name="pager"></param>
    /// <param name="columns"></param></param>    /// 
    /// <returns></returns>
    public static String ListData<T>(this HtmlHelper html, IPager<T> pager, Object[] columns)
    {
      if (columns == null)
      {
        columns = Reflection.GetPropertyNames<T>();
      }

      var buider = new TagBuilder("table");

      buider.MergeAttribute("class", "table-list maxwidth");
      buider.MergeAttribute("border", "0");
      buider.MergeAttribute("cellpadding", "0");
      buider.MergeAttribute("cellspacing", "0");

      var result = pager.GetResult();

      buider.InnerHtml += BuildListDataHeader<T>(html, columns);
      if (result != null)
      {
        foreach (var item in result)
        {
          buider.InnerHtml += BuildListDataRow(html, item, columns);
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
    public static String BuildListDataHeader<T>(this HtmlHelper html, Object[] columns)
    {
      var builder = new TagBuilder("tr");
      builder.MergeAttribute("class", "table-list-header");

      foreach (var column in columns)
      {
        var b1 = new TagBuilder("th");
        String value = null;
        if (column is String)
        {
          value = column.ToString();
        }
        else if (column is ColumnOption<T>)
        {
          var option = column as ColumnOption<T>;
          if (option.Name != null)
          {
            value = option.Name;
          }
          else
          {
            value = option.FieldName;
          }
        }

        if (value != null)
        {
          b1.SetInnerText(value);
          builder.InnerHtml += b1.ToString();
        }
      }

      return builder.ToString();
    }

    /// <summary>
    /// build list data row
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="html"></param>
    /// <param name="item"></param>
    /// <returns></returns>
    public static String BuildListDataRow<T>(this HtmlHelper html, T item, Object[] columns)
    {
      var builder = new TagBuilder("tr");

      RouteValueDictionary values = new RouteValueDictionary(item);

      foreach (var column in columns)
      {
        var b1 = new TagBuilder("td");

        String value = null;
        if (column is String)
        {
          var columnName = column.ToString();
          if (values.ContainsKey(columnName) && values[columnName] != null)
          {
            value = values[columnName].ToString();
          }
        }
        else if (column is ColumnOption<T>)
        {
          var option = column as ColumnOption<T>;

          if (option.Action != null)
          {
            value = option.Action(item);
          }
          else if (option.FieldName != null && values.ContainsKey(option.FieldName))
          {
            value = values[option.FieldName].ToString();
          }
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
