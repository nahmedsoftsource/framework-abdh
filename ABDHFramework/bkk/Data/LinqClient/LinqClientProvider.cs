using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using Superior.Framework.Exception;

namespace Superior.Data.LinqClient
{
  public class LinqClientProvider: DataClientProvider
  {
    public static LinqConnectionContext CurrentConnectionContext
    {
      get
      {
        return ConnectionContext.Current as LinqConnectionContext;
      }
    }

    public static LinqTransactionContext CurrentTransactionContext
    {
      get
      {
        return TransactionContext.Current as LinqTransactionContext;
      }
    }

    public override ConnectionContext CreateConnectionContext()
    {
      return new LinqConnectionContext();
    }

    public override TransactionContext CreateTransactionContext()
    {
      return new LinqTransactionContext();
    }
  }
}
