using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABDH_Demo.Common;

namespace ABDH_Demo.Data
{
  public class SearchResult<T>
  {
    private IList<T> _items;
    private ISearchQuery _query;

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
    public ISearchQuery Query
    {
      get
      {
        if (_query == null)
        {
          _query = SearchQueryBuilder.CreateQuery();
        }
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
        int maxResults = Query.GetMaxResults();
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

    public SearchResult(IList<T> items, int totalRows, ISearchQuery query)
    {
      _items = items;
      TotalRows = totalRows;
      _query = query;
    }

    public BasePager<T> ToBasePager()
    {
      return new BasePager<T>(_query.GetPage(), _query.GetMaxResults(), _items, TotalRows);
    }
  }
}
