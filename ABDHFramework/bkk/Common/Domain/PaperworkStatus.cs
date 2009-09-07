using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class PaperworkStatus : Common.DomainTypeCode
  {
    private static IDictionary<int, PaperworkStatus> _paperworkStatuses;
    public static IDictionary<int, PaperworkStatus> PaperworkStatuses
    {
      get
      {
        if (_paperworkStatuses == null)
        {
          _paperworkStatuses = new Dictionary<int, PaperworkStatus>();
        }
        return PaperworkStatus._paperworkStatuses;
      }
      set
      {
        _paperworkStatuses = value;
      }
    }

    public bool IsNotifyOrderingParty { get; set; }
    public bool IsNotifySupervisor { get; set; }

    public struct PAPERWORK_STATUS
    {
      public const int Completed = 11;
    }
  }
}

