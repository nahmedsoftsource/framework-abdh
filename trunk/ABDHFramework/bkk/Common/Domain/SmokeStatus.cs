using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class SmokeStatus : DomainTypeCode
  {
    private static IDictionary<int, SmokeStatus> _smokeStatuses;

    public static IDictionary<int, SmokeStatus> SmokeStatuses
    {
      get
      {
        if (_smokeStatuses == null)
        {
          _smokeStatuses = new Dictionary<int, SmokeStatus>();
        }
        return _smokeStatuses;
      }
      set
      {
        _smokeStatuses = value;
      }
    }
  }
}
