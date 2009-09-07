using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class OrderRelationship : Superior.MobileMedics.Common.DomainBase<int>
  {
    private String _name;
    public String Name
    {
      get
      {
        return _name;
      }
      set
      {
        _name = value;
      }
    }
		public struct ORDERRELATIONSHIP_TYPE
		{
			public const int Other = 1;
		}
  }
}
