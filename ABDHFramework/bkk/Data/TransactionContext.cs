using System;

namespace Superior.Data
{
  /// <summary>
  /// TransactionContext defines the transaction environment which executing code is running against.
  /// </summary>
  public abstract class TransactionContext: IDisposable
  {
    /// <summary>
    /// Returns the current executing transaction context
    /// </summary>
    public static TransactionContext Current
    {
      get
      {
        return TransactionScope.Current.Context;
      }
    }

    public abstract void Commit();

    #region IDisposable Members

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public virtual void Dispose()
    {
    }

    #endregion
  }
}
