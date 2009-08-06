using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABDH_Demo.Common
{
  public interface IPager<T>
  {
    /// <summary>
    /// list records
    /// </summary>
    /// <returns></returns>
    IList<T> GetResult();

    /// <summary>
    /// total record
    /// </summary>
    /// <returns></returns>
    int GetTotalResult();

    /// <summary>
    /// get current page
    /// </summary>
    /// <returns></returns>
    int GetPage();

    /// <summary>
    /// next page
    /// </summary>
    /// <returns></returns>
    int GetNextPage();

    /// <summary>
    /// get previous page
    /// </summary>
    /// <returns></returns>
    int GetPreviousPage();

    /// <summary>
    /// number items each page
    /// </summary>
    /// <returns></returns>
    int GetMaxPerPage();

    /// <summary>
    /// get first page
    /// </summary>
    /// <returns></returns>
    int GetFirstPage();

    /// <summary>
    /// get last page
    /// </summary>
    /// <returns></returns>
    int GetLastPage();

    /// <summary>
    /// need to pagination or not
    /// </summary>
    /// <returns></returns>
    Boolean HaveToPagination();
  }
}
