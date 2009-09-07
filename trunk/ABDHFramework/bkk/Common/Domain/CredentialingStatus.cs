using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class CredentialingStatus : DomainTypeCode
  {
    private static IDictionary<int, CredentialingStatus> _credentialingStatuses;

    public static IDictionary<int, CredentialingStatus> CredentialingStatuses
    {
      get
      {
        if (_credentialingStatuses == null)
        {
          _credentialingStatuses = new Dictionary<int, CredentialingStatus>();
        }
        return _credentialingStatuses;
      }
      set
      {
        _credentialingStatuses = value;
      }
    }

    public struct Codes
    {
      public const int New = 0;
      public const int Received = 1;
      public const int Expired = 2;
      public const int Renew = 3;
    }
  }
}
