using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class Priority : Common.DomainTypeCode
  {
    private static IDictionary<int, Priority> _priority;
    public static IDictionary<int, Priority> Priorities
    {
      get
      {
        if (_priority == null)
        {
          _priority = new Dictionary<int, Priority>();
        }
        return _priority;
      }

      set
      {
        _priority = value;
      }
    }
    public struct Codes
    {
      public const uint Low = 1;
      public const uint Medium = 2;
      public const uint High = 3;
      public const uint Rush = 4;
    }
  }
}
