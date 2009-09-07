using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class OrderPriority : Common.DomainTypeCode
  {
    private static IDictionary<int, OrderPriority> _orderPriority;
    public static IDictionary<int, OrderPriority> OrderPriorities
    {
      get
      {
        if (_orderPriority == null)
        {
          _orderPriority = new Dictionary<int, OrderPriority>();
        }
        return _orderPriority;
      }

      set
      {
        _orderPriority = value;
      }
    }
		public struct ORDER_PRIORITY
		{
			public const int Low = 1;
			public const int Medium = 2;
			public const int High = 3;
			public const int Rush = 4;
		}
  }
}
