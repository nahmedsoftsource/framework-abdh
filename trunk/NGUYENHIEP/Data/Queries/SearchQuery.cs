using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Linq.Expressions;

namespace NguyenHiep.Data.Queries
{
    public class SearchQuery : IQueryable
  {
    private SearchCriteria _criteria = SearchCriteria.Empty;
    private Dictionary<string, IQueryExpression> _expressions;
    private IList<ISortOrder> _orderClauses;
    private int _page = 1;
    private int _firstResult = 0;
    private int _maxResults = int.MaxValue;

    #region Criteria methods
    public bool HasCriteria
    {
      get
      {
        return (_criteria != SearchCriteria.Empty) || (Expressions.Count > 0);
      }
    }

    public IDictionary<string, IQueryExpression> Expressions
    {
      get
      {
        if (_expressions == null)
        {
          _expressions = new Dictionary<string, IQueryExpression>();
        }
        return _expressions;
      }
    }

    public IQueryable SetCriteria(SearchCriteria criteria)
    {
      if (criteria == null)
      {
        _criteria = SearchCriteria.Empty;
      }
      _criteria = criteria;
      return this;
    }

    public SearchCriteria GetCriteria()
    {
      return _criteria;
    }

    //public IQueryExpression Where(string propertyName)
    //{
    //  QueryExpression ex = new QueryExpression(this, propertyName);
    //  Expressions.Add(propertyName, ex);
    //  return ex;
    //}

    #endregion

    #region Order clauses

    public bool HasOrderClause
    {
      get
      {
        return OrderClauses.Count > 0;
      }
    }

    public IList<ISortOrder> OrderClauses
    {
      get
      {
        if (_orderClauses == null)
        {
          _orderClauses = new List<ISortOrder>();
        }
        return _orderClauses;
      }
    }

    public IQueryable OrderBy(string propertyName)
    {
      OrderClauses.Add(new SortOrder(propertyName, true));
      return this;
    }

    public IQueryable OrderByDescending(string propertyName)
    {
      OrderClauses.Add(new SortOrder(propertyName, false));
      return this;
    }

    #endregion

    #region Paging

    public bool HasPaging
    {
      get
      {
        return _maxResults != int.MaxValue;
      }
    }

    public IQueryable SetPage(int page)
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
      return this;
    }

    public IQueryable SetFirstResult(int firstResult)
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
      return this;
    }

    public IQueryable SetMaxResults(int maxResults)
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
      return this;
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
      #region Implement 
    IEnumerator IEnumerable.GetEnumerator()
    {
        return null;
    }
    public Type ElementType { get; set; }
    public  Expression Expression { get; set; }
    public IQueryProvider Provider { get; set; }

      #endregion
  }
}
