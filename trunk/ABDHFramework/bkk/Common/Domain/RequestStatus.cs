using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class RequestStatus : DomainTypeCode
  {
    private static IDictionary<int, RequestStatus> _requestStatus;

    public static IDictionary<int, RequestStatus> RequestStatuses
    {
      get
      {
        if (_requestStatus == null)
        {
          _requestStatus = new Dictionary<int, RequestStatus>();
        }
        return _requestStatus;
      }
      set
      {
        _requestStatus = value;
      }
    }

    public enum Status : int
    {
      Pending = 1,
      Approved = 2,
      Disapproved = 3
    }
  }
}
