using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.Data.LinqClient
{
  public class LinqTransactionContext: TransactionContext
  {
    private System.Transactions.TransactionScope _systemTransactionScope;

    internal LinqTransactionContext()
    {
      if (System.Transactions.Transaction.Current == null)
      {
        _systemTransactionScope = new System.Transactions.TransactionScope();
      }
      else
      {
        _systemTransactionScope = null;
      }
    }

    public override void Dispose()
    {
      if (_systemTransactionScope != null)
      {
        _systemTransactionScope.Dispose();
      }
      base.Dispose();
    }

    public override void Commit()
    {
      if (_systemTransactionScope != null)
      {
        _systemTransactionScope.Complete();
      }
    }
  }
}
