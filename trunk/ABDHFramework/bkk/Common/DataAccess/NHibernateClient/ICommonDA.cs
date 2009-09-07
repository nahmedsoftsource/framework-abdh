using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Expression;
using Superior.Data;

namespace Superior.MobileMedics.Common.DataAccess.NHibernateClient
{
    public interface ICommonDA
    {
      IList<T> GetMetadataDomains<T>();
      SearchResult<T> Search<T>(ISearchQuery query);
      T GetObject<T>(int id); 
    }
}
