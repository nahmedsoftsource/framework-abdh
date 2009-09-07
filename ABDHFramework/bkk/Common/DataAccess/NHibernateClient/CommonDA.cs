using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Superior.MobileMedics.Common.Domain;
using NHibernate.Expression;
using Superior.Data;
using Superior.Data.Queries;

namespace Superior.MobileMedics.Common.DataAccess.NHibernateClient
{
    public class CommonDA:BaseDA<int, Common.DomainTypeCode>,ICommonDA
    {
        public IList<T> GetMetadataDomains<T>()
        {
            return base.GetAll<T>();
        }

        public new SearchResult<T> Search<T>(ISearchQuery query)
        {
            return base.Search<T>(query);
        }

        public T GetObject<T>(int id)
        {
          return base.GetMetadataObject<T>(id);
        }        
    }
}
