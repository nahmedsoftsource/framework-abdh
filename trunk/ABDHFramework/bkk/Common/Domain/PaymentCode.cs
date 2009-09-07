using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
          
namespace Superior.MobileMedics.Common.Domain
{
  public class PaymentCode : DomainTypeCode
  {
    private static IDictionary<int, PaymentCode> _paymentCodes;

    public static IDictionary<int, PaymentCode> PaymentCodes
    {
      get
      {
        if (_paymentCodes == null)
        {
          _paymentCodes = new Dictionary<int, PaymentCode>();
        }
        return _paymentCodes;
      }
      set
      {
        _paymentCodes = value;
      }
    }
  }
}
