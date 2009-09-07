using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Superior.Data.LinqClient
{
  public class LinqConnectionContext: ConnectionContext
  {
    private Database _database = null;

    public Database Database
    {
      get { return _database; }
    }
    private DbConnection _connection = null;

    public override IDbConnection Connection
    {
      get { return _connection; }
    }


    internal LinqConnectionContext()
    {
      Database db = DatabaseFactory.CreateDatabase();
      _connection = db.CreateConnection();
      _connection.Open();
    }

    public override void Dispose()
    {
      _connection.Dispose();
      base.Dispose();
    }
  }
}
