using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class Country : DomainTypeCode
  {
    public struct Codes
    {
      public const int DefaultCountryID = 1;
    }

    private string _callingCode;
    private static IDictionary<int, Country> _countries;

    public string CallingCode
    {
      get
      {
        return _callingCode;
      }
      set
      {
        _callingCode = value;
      }
    }

    public static IDictionary<int, Country> Countries
    {
      get
      {
        if (_countries == null)
        {
          _countries = new Dictionary<int, Country>();
        }
        return _countries;
      }
      set
      {
        _countries = value;
      }
    }
  }
}
