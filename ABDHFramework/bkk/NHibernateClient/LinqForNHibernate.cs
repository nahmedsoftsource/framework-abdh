using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using NHibernate;

namespace Superior.Data.NHibernateClient
{
    public static class LinqForNHibernate
    {
        public static IQueryable<T> Linq<T>(this ISession session)
        {
            return new NHibernateLinqQuery<T>(session);
        }
    }
}
