using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class EmailFormat : Common.DomainTypeCode
  {
    private bool _inactive;
    private static IDictionary<int, EmailFormat> _emailFormats;
    public static IDictionary<int, EmailFormat> EmailFormats
    {
      get
      {
        if (_emailFormats == null)
        {
          _emailFormats = new Dictionary<int, EmailFormat>();
        }
        return EmailFormat._emailFormats;
      }
      set
      {
        EmailFormat._emailFormats = value;
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

