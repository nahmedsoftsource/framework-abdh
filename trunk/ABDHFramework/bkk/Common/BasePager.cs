using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common
{
  public class BasePager<T> : IPager<T>
  {
    /// <summary>
    /// current page
    /// </summary>
    protected int _page;

    /// <summary>
    /// page size
    /// </summary>
    protected int _limit;

    /// <summary>
    /// total item
    /// </summary>
    protected int _total;

    /// <summary>
    /// result
    /// </summary>
    protected IList<T> _result;

    /// <summary>
    /// constructor when not run
    /// </summary>
    /// <param name="page"></param>
    /// <param name="limit"></param>
    public BasePager(int page, int limit)
    {
      _page = page;
      _limit = limit;
    }

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="page"></param>
    /// <param name="limit"></param>
    /// <param name="result"></param>
    /// <param name="total"></param>
    public BasePager(int page, int limit, IList<T> result, int total)
    {
      _page = page;
      _limit = limit;
      _result = result;
      _total = total;
    }

    /// <summary>
    /// copy constructor
    /// </summary>
    /// <param name="pager"></param>
    public BasePager(BasePager<T> pager)
    {
      this._page = pager._page;
      this._limit = pager._limit;
      this._result = pager._result;
      this._total = pager._total;
    }


    #region IPager Members

    public IList<T> GetResult()
    {
      return _result;
    }

    public int GetTotalResult()
    {
      return _total;
    }

    public int GetPage()
    {
      return _page;
    }

    public int GetNextPage()
    {
      if (_page + 1 <= GetLastPage())
      {
        return _page + 1;
      }
      return -1;
    }

    public int GetPreviousPage()
    {
      return (_page > 1) ? _page - 1 : -1;
    }

    public int GetMaxPerPage()
    {
      return _limit;
    }

    public int GetFirstPage()
    {
      return 1;
    }

    public int GetLastPage()
    {
      return (int)Math.Ceiling((double)(_total) / (double)(_limit));
    }

    public bool HaveToPagination()
    {
      return _total > _limit;
    }

    #endregion
  }
}
