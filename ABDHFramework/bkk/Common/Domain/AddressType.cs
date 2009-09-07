using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Superior.MobileMedics.Common.Domain
{
  public class AddressType: DomainTypeCode
  {
    private static IDictionary<int, AddressType> _addressTypes;
    public static IDictionary<int, AddressType> AddressTypes
    {
      get
      {
        if (_addressTypes == null)
        {
          _addressTypes = new Dictionary<int, AddressType>();
        }
        return _addressTypes;
      }
      set
      {
        _addressTypes = value;
      }
    }

    public const int Work = 1;
    public const int Home = 2;
  }
}
