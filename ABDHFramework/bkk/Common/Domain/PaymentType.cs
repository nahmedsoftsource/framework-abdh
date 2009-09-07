using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Superior.MobileMedics.Common.Domain
{
  public class PaymentType : DomainTypeCode
  {
    private static IDictionary<int, PaymentType> _paymentTypes;
    public static IDictionary<int, PaymentType> PaymentTypes
    {
      get
      {
        if (_paymentTypes == null)
        {
          _paymentTypes = new Dictionary<int, PaymentType>();
        }
        return _paymentTypes;
      }
      set
      {
        _paymentTypes = value;
      }
    }
    public const int CHECK = 1;
    public const int CREDIT_CARD = 2;
    public const int CASH = 3;
    public const int DIRECT_DIPOSITE = 4;
  }
}
