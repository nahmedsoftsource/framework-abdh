using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class PhoneType : Common.DomainTypeCode
  {    
    private bool _inactive;
    private static IDictionary<int, PhoneType> _phoneTypes;
    public static IDictionary<int, PhoneType> PhoneTypes
    {
      get
      {
        if (_phoneTypes == null)
        {
          _phoneTypes = new Dictionary<int, PhoneType>();
        }
        return PhoneType._phoneTypes;
      }

      set
      {
        PhoneType._phoneTypes = value;
      }
    }
       
    public bool Inactive
    {
      get
      {
        return _inactive;
      }
      set
      {        
          _inactive = value;          
      }
    }
  }
}
