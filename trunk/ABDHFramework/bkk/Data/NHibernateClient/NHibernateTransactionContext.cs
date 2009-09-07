using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Superior.Data.NHibernateClient
{
  public class NHibernateTransactionContext: TransactionContext
  {
    private ConnectionScope _connectionScope;

    private ITransaction _transaction;
    internal NHibernateTransactionContext()
    {
      if (ConnectionContext.Current == null)
      {
        _connectionScope = ConnectionScope.Enter();
      }
      try
      {
        _transaction = NHibernateClientProvider.CurrentSession.BeginTransaction();
      }
      catch
      {
        if (_connectionScope != null)
        {
          _connectionScope.Leave();
        }
        throw;
      }
    }

    /// <summary>
    /// Releases unmanaged and - optionally - managed resources
    /// </summary>
    public override void Dispose()
    {
      if (_transaction != null)
      {
        try
        {
          _transaction.Dispose();
        }
        finally
        {
          if (_connectionScope != null)
          {
            _connectionScope.Leave();
          }
        }
      }
      base.Dispose();
    }

    /// <summary>
    /// Commits this transaction.
    /// </summary>
    public override void Commit()
    {
      if (_transaction != null)
      {
        _transaction.Commit();
      }
    }
  }
}
