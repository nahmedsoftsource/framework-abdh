using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class EmailType : Common.DomainTypeCode
  {
    private bool _inactive;
    private static IDictionary<int, EmailType> _emailTypes;
    public static IDictionary<int, EmailType> EmailTypes
    {
      get
      {
        if (_emailTypes == null)
        {
          _emailTypes = new Dictionary<int, EmailType>();
        }
        return EmailType._emailTypes;
      }
      set
      {
        EmailType._emailTypes = value;
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
