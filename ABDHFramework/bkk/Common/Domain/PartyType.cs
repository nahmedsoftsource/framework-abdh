using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class PartyType : DomainTypeCode
  {    
    private static IDictionary<int, PartyType> _partyTypes;    

    public static IDictionary<int, PartyType> PartyTypes
    {
      get
      {
        if (_partyTypes == null)
        {
          _partyTypes = new Dictionary<int, PartyType>();
        }
        return _partyTypes;
      }
      set
      {
        _partyTypes = value;
      }
    }    

    public struct PARTY_TYPE
    {
      public const uint Person = 1;
      public const uint Organization = 2;
    }
  }
}
