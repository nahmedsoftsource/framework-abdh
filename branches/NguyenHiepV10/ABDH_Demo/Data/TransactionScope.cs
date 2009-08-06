using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABDH_Demo.FrameWork;

namespace ABDH_Demo.Data
{
  public class TransactionScope : Scope<TransactionContext>
  {
    #region Constructors

    public TransactionScope(TransactionContext context)
      : base(context)
    {

    }

    public TransactionScope(TransactionContext context, bool isDisposable)
      : base(context, isDisposable)
    {

    }
    #endregion

    #region Public method
    public void Commit()
    {
      if (base._isDisposable)
        Context.Commit();
    }
    #endregion

    #region Static members

    /// <summary>
    /// Gets the current transaction scope.
    /// </summary>
    /// <value>The current.</value>
    public static new TransactionScope Current
    {
      get
      {
        return Scope<TransactionContext>.Current as TransactionScope;
      }
    }

    /// <summary>
    /// Enters a transaction context.
    /// </summary>
    /// <returns></returns>
    public static TransactionScope Enter()
    {
      return Enter(false);
    }

    /// <summary>
    /// Enters a transaction context, require new context if needed.
    /// </summary>
    /// <param name="requireNew">if set to <c>true</c> [require new].</param>
    /// <returns></returns>
    public static TransactionScope Enter(bool requireNew)
    {
      TransactionScope scope = null;
      try
      {
        if (!requireNew && Current != null && Current.Context != null)
        {
          scope = new TransactionScope(Current.Context, false);
        }
        else
        {
          scope = new TransactionScope(DataClientProvider.Instance.CreateTransactionContext());
        }
      }
      catch (Exception ex)
      {
        Console.Out.WriteLine(ex.Message);
      }
      return scope;
    }

    #endregion
  }
}
