using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
    public class ApprovalStatus : DomainTypeCode
    {
      private static IDictionary<int, ApprovalStatus> _approvalStatus;

      public static IDictionary<int, ApprovalStatus> ApprovalStatuses
      {
        get
        {
          if (_approvalStatus == null)
          {
            _approvalStatus = new Dictionary<int, ApprovalStatus>();
          }
          return _approvalStatus;
        }
        set
        {
          _approvalStatus = value;
        }
      }

      public struct STATUS_ID
      {
        public const int New = 0;        
        public const int Pending=1;
        public const int Approved = 2;
        public const int Declined = 3;
      }
  }
}
