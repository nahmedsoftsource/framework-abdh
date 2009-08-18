using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABDHFramework.Lib.Pager
{
  public class ColumnCheckbox<T>:ColumnOption<T>
  {
    private string _checkAllFunction;
    public string CheckAllFunction{
      get { return _checkAllFunction; }
      set { _checkAllFunction = value; }
    }
  }
}
