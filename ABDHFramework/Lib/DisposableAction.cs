using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABDHFramework.Lib
{
  /// <summary>
  ///   Used this helper to create a disposable anonymous method
  /// </summary>
  public class DisposableAction : IDisposable
  {
    private Action _action;

    public DisposableAction(Action action)
    {
      _action = action;
    }
    #region IDisposable Members

    public void Dispose()
    {
      if (_action != null)
      {
        _action();
      }
    }

    #endregion
  }

}
