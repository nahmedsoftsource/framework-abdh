using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common
{
  /// <summary>
  /// null value for property of anonymous object
  /// </summary>
  public class AnonymousObjectNull
  {
    private bool _isNull;

    public AnonymousObjectNull(bool value)
    {
      _isNull = value;
    }

    public static AnonymousObjectNull NullValue
    {
      get
      {
        return new AnonymousObjectNull(true);
      }
    }

    public static AnonymousObjectNull NotNullValue
    {
      get
      {
        return new AnonymousObjectNull(false);
      }
    }

    public static bool operator == (AnonymousObjectNull obj1, AnonymousObjectNull obj2){
      return obj1._isNull == obj2._isNull;
    }

    public static bool operator !=(AnonymousObjectNull obj1, AnonymousObjectNull obj2)
    {
      return obj1._isNull != obj2._isNull;
    }

    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    public override bool Equals(object obj)
    {
      return base.Equals(obj);
    }
  }
}
