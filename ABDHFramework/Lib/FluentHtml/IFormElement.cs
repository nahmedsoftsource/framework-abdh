using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABDHFramework.Lib.FluentHtml
{
  public interface IFormElement
  {
    void SetValue(object value);
    object GetValue();
  }
}
