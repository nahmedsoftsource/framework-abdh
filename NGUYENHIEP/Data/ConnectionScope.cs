using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NguyenHiep.FrameWork;

namespace NguyenHiep.Data
{
  public class ConnectionScope : Scope<ConnectionContext>
  {
    #region Constructors

    public ConnectionScope(ConnectionContext context)
      : base(context)
    {

    }

    public ConnectionScope(ConnectionContext context, bool isDisposable)
      : base(context, isDisposable)
    {

    }
    #endregion

    #region Static methods
    /// <summary>
    /// Gets the current connection scope.
    /// </summary>
    /// <value>The current.</value>
    public static new ConnectionScope Current
    {
      get
      {
        return Scope<ConnectionContext>.Current as ConnectionScope;
      }
    }

    /// <summary>
    ///    New a connection scope. Inherit by default.
    /// </summary>
    public static ConnectionScope Enter()
    {
      return Enter(false);
    }

    /// <summary>
    ///    New a connection scope. Could be New or Inherit.
    /// </summary>
    public static ConnectionScope Enter(bool requireNew)
    {
      ConnectionScope scope;
      if (!requireNew && Current != null && Current.Context != null)
      {
        scope = new ConnectionScope(Current.Context, false);
      }
      else
      {
        scope = new ConnectionScope(DataClientProvider.Instance.CreateConnectionContext());
      }
      return scope;
    }

    #endregion


  }
}
