using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABDHFramework.Common;
using ABDHFramework.Data.Queries;

namespace ABDHFramework.Data
{
  public class SearchResult<T>
  {
      private int _page = 1;
      private int _firstResult = 0;
      private int _maxResults = int.MaxValue;
    private IList<T> _items;
    private IQueryable _query;

    /// <summary>
    /// Gets or sets the result items.
    /// </summary>
    /// <value>The items.</value>
    public IList<T> Items
    {
      get
      {
        if (_items == null)
        {
          return new List<T>();
        }
        return _items;
      }
      set { _items = value; }
    }

    /// <summary>
    /// Gets or sets the query corresponding to the search result.
    /// </summary>
    /// <value>The query.</value>
    public IQueryable Query
    {
      get
      {
        //if (_query == null)
        //{
        //  _query = SearchQueryBuilder.CreateQuery();
        //}
        return _query;
      }
        set { _query = value; }
    }

    /// <summary>
    /// Gets or sets the total rows.
    /// </summary>
    /// <value>The total rows.</value>
    public int TotalRows { get; set; }

    public int LastPage
    {
      get
      {
          int maxResults = ((SearchQuery)Query).GetMaxResults();
        if (maxResults > 0)
        {
          return (int)Math.Ceiling(((double)TotalRows) / maxResults);
        }
        return 1;
      }
    }


    public SearchResult()
    {
    }

    public SearchResult(IList<T> items)
    {
      _items = items;
      TotalRows = items.Count;
    }

    public SearchResult(IList<T> items, int totalRows)
    {
      _items = items;
      TotalRows = totalRows;
    }

    public SearchResult(IList<T> items, int totalRows, SearchQuery query)
    {
      _items = items;
      TotalRows = totalRows;
      _query = query;
    }

    public BasePager<T> ToBasePager()
    {
      return new BasePager<T>(GetPage(), GetMaxResults(), _items, TotalRows);
    }
    #region Paging

    public bool HasPaging
    {
        get
        {
            return _maxResults != int.MaxValue;
        }
    }

    public void SetPage(int page)
    {
        if (page > 0)
        {
            _page = page;
            if (_maxResults > 0 && _maxResults < int.MaxValue)
            {
                _firstResult = (_page - 1) * _maxResults;
            }
        }
        else
        {
            _page = 1;
        }
    }

    public void SetFirstResult(int firstResult)
    {
        if (_firstResult >= 0)
        {
            _firstResult = firstResult;
            if (_maxResults > 0 && _maxResults < int.MaxValue)
            {
                _page = (_firstResult / _maxResults) + 1;
            }
        }
        else
        {
            _firstResult = 0;
        }
    }

    public void SetMaxResults(int maxResults)
    {
        if (_maxResults > 0)
        {
            _maxResults = maxResults;
            if (_firstResult > 0)
            {
                _page = (_firstResult / _maxResults) + 1;
            }
            else if (_page > 0)
            {
                _firstResult = (_page - 1) * _maxResults;
            }
        }
        else
        {
            _maxResults = int.MaxValue;
        }
    }

    public int GetPage()
    {
        return _page;
    }

    public int GetFirstResult()
    {
        return _firstResult;
    }

    public int GetMaxResults()
    {
        return _maxResults;
    }
    #endregion
  }
}
