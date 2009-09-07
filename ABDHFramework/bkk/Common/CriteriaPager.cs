using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Superior.MobileMedics.Common
{
  public class CriteriaPager<T>
    : BasePager<T>
  {
    public ICriteria Criteria { get; set; }

    /// <summary>
    /// constructor for criteria. This criteria will be used to build total query and result query
    /// </summary>
    /// <param name="query"></param>
    /// <param name="page"></param>
    /// <param name="limit"></param>
    public CriteriaPager(ICriteria criteria, int page, int limit)
      : base(page, limit)
    {
      Criteria = criteria;
      Initialize();
    }

    public void Initialize()
    {
      _total = Criteria.List().Count;
      Criteria.SetMaxResults(GetMaxPerPage());
      Criteria.SetFirstResult((GetPage() -1) * GetMaxPerPage());

      _result = Criteria.List<T>();
    }
  }
}
