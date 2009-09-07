using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.Data.LinqClient;
using System.Data;
using Superior.Data.NHibernateClient;
using Superior.Data;
using Superior.Framework;

namespace Superior.MobileMedics.DataMappers.LinqDataMapper
{
  public class DataHelper
  {
    public static EntitiesDataContext CreateDataContext()
    {
      IDbConnection connection = Scope<Superior.Data.LinqClient.LinqConnectionContext>.Current.Context.Connection;
      return new EntitiesDataContext(connection);
    }
  }
}
