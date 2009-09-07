using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common
{
  public class DomainTypeCode : DomainBase<int>
  {
    string _name;
    public string Name
    {
      get
      { return _name; }
      set
      {        
        _name = value;
      }
    }
  }
}
