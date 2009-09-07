using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.MobileMedics.Common;

namespace Superior.MobileMedics.Common.Domain
{
  public class OrderAssignmentFeeType:Common.DomainTypeCode
  {
    private static IDictionary<int, OrderAssignmentFeeType> _orderAssignmentFeeTypes;

    public static IDictionary<int, OrderAssignmentFeeType> OrderAssignmentFeeTypes
    {
      get
      {
        if (_orderAssignmentFeeTypes == null)
          _orderAssignmentFeeTypes = new Dictionary<int, OrderAssignmentFeeType>();

        return _orderAssignmentFeeTypes;
      }

      set { _orderAssignmentFeeTypes = value; }
    }

    public struct ORDERASSIGNMENTFEE_TYPE
    {
      public const uint Bonus = 1;
      public const uint Referral = 2;
      public const uint Admin = 3;
      public const uint ExtraFee = 4;
      public const uint KitFee = 5;
      public const uint Deduction = 6;
    }
  }
}
