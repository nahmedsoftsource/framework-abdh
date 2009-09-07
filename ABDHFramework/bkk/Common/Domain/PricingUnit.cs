using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class PricingUnit : DomainTypeCode
  {
    #region Predefine codes
    public struct Codes
    {
      public const int USD = 1;
      public const int Percent = 2;
    }

    #endregion

    #region Static members

    private static IDictionary<int, PricingUnit> _pricingUnits;

    public static IDictionary<int, PricingUnit> PricingUnits
    {
      get
      {
        if (_pricingUnits == null)
        {
          _pricingUnits = new Dictionary<int, PricingUnit>();
        }
        return _pricingUnits;
      }
      set
      {
        _pricingUnits = value;
      }
    }

    #endregion
  }
}
