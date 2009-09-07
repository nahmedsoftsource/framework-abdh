using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class SurchargeType:Common.DomainTypeCode
  {
    private static IDictionary<int, SurchargeType> _surchargeTypes;

    public static IDictionary<int, SurchargeType> SurchargeTypes
    {
      get
      {
        if (_surchargeTypes == null)
          _surchargeTypes = new Dictionary<int, SurchargeType>();

        return _surchargeTypes;
      }
      set { _surchargeTypes = value; }
    }
    public struct Codes
    {
      public const int GeographicalSurcharge = 1;
      public const int GasSurcharge = 2;
      public const int AdminFee = 3;
      public const int ExtraFee = 4;
      public const int DocumentFee = 5;
      public const int Discount = 6;
      public const int ServiceChargeback = 7;
      public const int ServiceCredit = 8;
      public const int DiscountAfterPosted = 9;
    }
  }
}
