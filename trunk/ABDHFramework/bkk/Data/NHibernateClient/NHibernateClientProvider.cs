using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Superior.Data.NHibernateClient
{
  public class NHibernateClientProvider : DataClientProvider
  {
    #region Override methods

    public override ConnectionContext CreateConnectionContext()
    {
      Database db = DatabaseFactory.CreateDatabase();
      ISession session = SessionFactory.OpenSession();
      session.FlushMode = FlushMode.Commit;
      return new NHibernateConnectionContext(session);
    }

    public override TransactionContext CreateTransactionContext()
    {
      return new NHibernateTransactionContext();
    }

    #endregion

    #region Static members
    private static ISessionFactory _sessionFactory;
    public static ISessionFactory SessionFactory
    {
      get
      {
        if (_sessionFactory == null)
        {
          _sessionFactory = new NHibernate.Cfg.Configuration().Configure().BuildSessionFactory();
        }
        return _sessionFactory;
      }
    }

    static NHibernateClientProvider()
    {
    }

    public static NHibernateConnectionContext CurrentConnectionContext
    {
      get
      {
        return ConnectionContext.Current as NHibernateConnectionContext;
      }
    }

    public static NHibernateTransactionContext CurrentTransactionContext
    {
      get
      {
        return TransactionContext.Current as NHibernateTransactionContext;
      }
    }

    public static ISession CurrentSession
    {
      get
      {
        return CurrentConnectionContext.Session;
      }
    }

    public static IDbConnection CurrentDbConnection
    {
      get
      {
        return CurrentConnectionContext.Connection;
      }
    }
    #endregion
  }
}
