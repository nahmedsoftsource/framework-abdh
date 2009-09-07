using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class PaymentStatus : DomainTypeCode
  {
    private static IDictionary<int, PaymentStatus> _paymentStatus;

    public static IDictionary<int, PaymentStatus> PaymentStatuses
    {
      get
      {
        if (_paymentStatus == null)
        {
          _paymentStatus = new Dictionary<int, PaymentStatus>();
        }
        return _paymentStatus;
      }
      set
      {
        _paymentStatus = value;
      }
    }

    public enum Status : int
    {
      New = 1,      
      Posted = 5
    }
  }
}
