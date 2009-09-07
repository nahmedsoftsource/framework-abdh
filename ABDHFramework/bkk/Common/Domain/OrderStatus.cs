using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class OrderStatus: Common.DomainTypeCode
  {
    private static IDictionary<int, OrderStatus> _orderStatuses;
    public static IDictionary<int, OrderStatus> OrderStatuses
    {
      get
      {
        if (_orderStatuses == null)
        {
          _orderStatuses = new Dictionary<int, OrderStatus>();
        }
        return _orderStatuses;
      }

      set
      {
        _orderStatuses = value;
      }
    }

    public bool IsNotifyOrderingParty { get; set; }
    public bool IsNotifySupervisor { get; set; }

		public struct ORDER_STATUS
		{
			public const int New = 1;
			public const int Processing = 2;
			public const int OnHold = 3;
			public const int Completed = 4;
			public const int Cancelled = 5;
			public const int Verified = 6;
			public const int Closed = 7;
		}
  }
}
