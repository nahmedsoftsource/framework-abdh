using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class Gender : DomainTypeCode
  {
    private static IDictionary<int, Gender> _genders;

    public static IDictionary<int, Gender> Genders
    {
      get
      {
        if (_genders == null)
        {
          _genders = new Dictionary<int, Gender>();
        }
        return _genders;
      }
      set
      {
        _genders = value;
      }
    }

    public Gender()
    {
      this.ID = 0;
      this.Name = "Unknown";
    }
  }
}
