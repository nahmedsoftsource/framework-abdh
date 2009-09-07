using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class GovIDType : Common.DomainTypeCode
  {
    public string AbbrName { get; set; }
    private static IDictionary<int, GovIDType> _govIDTypes;
    public static IDictionary<int, GovIDType> GovIDTypes
    {
      get
      {        
        if (_govIDTypes == null)
        {
            _govIDTypes = new Dictionary<int, GovIDType>();
        }
        return GovIDType._govIDTypes;        
      }
      set
      {
        GovIDType._govIDTypes = value;
      }
    }

    public bool UseForApplicant { get; set; }

    public struct GOVID_TYPE
    {
      public const int UNKNOWN = 0;
      public const int SSN = 1;
      public const int TID = 2;
    }
  }
}
