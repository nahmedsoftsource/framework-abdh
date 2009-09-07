using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Superior.Framework;
using System.Data;

namespace Superior.Data.NHibernateClient
{
  public class NHibernateConnectionContext : ConnectionContext
  {
    #region Private fields
    // for adapt with current linq only
    private Scope<LinqClient.LinqConnectionContext> _linqScope;

    #endregion

    internal NHibernateConnectionContext(ISession session)
    {
      _linqScope = new Scope<LinqClient.LinqConnectionContext>(DataClientProvider.GetInstance("LinqClient").CreateConnectionContext() as LinqClient.LinqConnectionContext);
      Session = session;
    }

    #region Public properties

    public ISession Session { get; private set; }

    public override System.Data.IDbConnection Connection
    {
      get
      {
        return Session.Connection;
      }
    }
    public override void Dispose()
    {
      _linqScope.Dispose();
      Session.Close();
      base.Dispose();
    }
    public override void Flush()
    {
      Session.Flush();
    }
    #endregion

  }
}
