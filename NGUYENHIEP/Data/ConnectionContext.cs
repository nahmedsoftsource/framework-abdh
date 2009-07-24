using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace NguyenHiep.Data
{
  /// <summary>
  /// ConnectionContext defines the connection environment which executing code is running against.
  /// </summary>
  public abstract class ConnectionContext : IDisposable
  {
    #region Public properties
    public abstract IDbConnection Connection { get; }
    #endregion

    #region Static members

    /// <summary>
    /// Returns the current executing <c>ConnectionContext</c>
    /// </summary>
    public static ConnectionContext Current
    {
      get
      {
        if (ConnectionScope.Current != null)
        {
          return ConnectionScope.Current.Context;
        }
        return null;
      }
    }

    #endregion

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
