using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common
{
  public class QueryPager<T>
    : BasePager<T>
  {
    /// <summary>
    /// query to get total result
    /// </summary>
    private IQueryable<T> _totalQuery;
    public IQueryable<T> TotalQuery { get { return _totalQuery; } set { _totalQuery = value; } }

    /// <summary>
    /// query to get result
    /// </summary>
    private IQueryable<T> _resultQuery;
    public IQueryable<T> ResultQuery { get { return _resultQuery; } set { _resultQuery = value; } }

    /// <summary>
    /// constructor for query. This query will be used to build total query and result query
    /// </summary>
    /// <param name="query"></param>
    /// <param name="page"></param>
    /// <param name="limit"></param>
    public QueryPager(IQueryable<T> query, int page, int limit)
      : base(page, limit)
    {
      _totalQuery = query;
      _resultQuery = query.Skip((page - 1) * limit).Take(limit);
      Initialize();
    }

    public QueryPager(IQueryable<T> totalQuery, IQueryable<T> resultQuery, int page, int limit)
      : base(page, limit)
    {
      _totalQuery = totalQuery;
      _resultQuery = resultQuery.Skip((page - 1) * limit).Take(limit);
    }

    public void Initialize()
    {
      _total = _totalQuery.Count();
      _result = _resultQuery.ToList();
    }
  }
}
