using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class OrderType : Common.DomainTypeCode
  {
    private static IDictionary<int, OrderType> _orderTypes;
    public static IDictionary<int, OrderType> OrderTypes
    {
      get
      {
        if (_orderTypes == null)
        {
          _orderTypes = new Dictionary<int, OrderType>();
        }
        return _orderTypes;
      }

      set
      {
        _orderTypes = value;
      }
    }
		public struct ORDER_TYPE
		{
			public const int Paramed = 1;
			public const int Direct = 2;
		}
  }
}
