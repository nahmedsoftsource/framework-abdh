using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace ABDHFramework.Utility
{
  public class Reflection
  {
    public static String[] GetPropertyNames<T>()
    {
      var ret = new List<String>();
      PropertyInfo[] props = typeof(T).GetProperties();

      foreach (var vi in props)
      {
        ret.Add(vi.Name);
      }

      return ret.ToArray();
    }
  }
}
