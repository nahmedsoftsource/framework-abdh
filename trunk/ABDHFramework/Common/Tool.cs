using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Reflection;

namespace ABDHFramework.Common
{
  public class Tool
  {
    private static DateTime EmptyDateTime = new DateTime();

    /// <summary>
    /// check if a value is empty
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool Empty(Object value)
    {
      if (value == null)
      {
        return true;
      }

      if (value is String)
      {
        return (String)value == "";
      }

      return false;
    }

    /// <summary>
    /// check if datetime if empty
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static bool IsEmptyDateTime(DateTime d)
    {
      return d == null || d == EmptyDateTime;
    }

    /// <summary>
    /// check if datetime if empty
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static bool IsEmptyDateTime(DateTime? d)
    {
      return d == null || d == EmptyDateTime;
    }

    /// <summary>
    /// check if a string is valid guid
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsGuid(String str)
    {
      if (str == null)
      {
        return false;
      }

      return Regex.IsMatch(str, @"^?[\da-f]{8}-([\da-f]{4}-){3}[\da-f]{12}?$", RegexOptions.IgnoreCase);
    }

    /// <summary>
    /// convert to int
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int? ToInt(String str)
    {
      int ret;
      var ok = int.TryParse(str, out ret);

      if (ok)
      {
        return ret;
      }
      else
      {
        return null;
      }
    }

    public static Guid GetGuidIDFromRequest(String id)
    {
      Guid result = new Guid();

      if (id == null)
      {
        return result;
      }


      bool success = Common.Utility.TryGetGuid(id, out result);
      if (success == true)
      {
        return result;
      }
      else
      {
        return new Guid();
      }
    }

    public static int GetIDFromRequest(String id)
    {
      int result = 0;

      if (id == null)
      {
        return 0;
      }


      bool success = int.TryParse(id, out result);
      if (success == true)
      {
        return result;
      }
      else
      {
        return 0;
      }

    }

    /// <summary>
    /// convert to bool
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool? ToBool(String str)
    {
      bool ret;
      var ok = bool.TryParse(str, out ret);

      if (ok)
      {
        return ret;
      }
      else
      {
        return null;
      }
    }

    /// <summary>
    /// convert to datetime
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static DateTime? ToDateTime(String str)
    {
      DateTime ret;
      var ok = DateTime.TryParse(str, out ret);

      if (ok)
      {
        return ret;
      }
      else
      {
        return null;
      }
    }

    /// <summary>
    /// get field name
    /// </summary>
    /// <param name="prefix"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static String GetFieldName(String prefix, String name)
    {
      if (prefix == null || prefix == "")
      {
        return name;
      }
      else
      {
        return prefix + "[" + name + "]";
      }
    }

    public static T CloneDomain<T>(T domain) where T : new()
    {
      return CloneDomain<T>(domain, new String[] { });
    }

    /// <summary>
    /// clone domain
    /// </summary>
    /// <param name="domain"></param>
    /// <returns></returns>
    public static T CloneDomain<T>(T domain, IEnumerable<String> IgnoreFields) where T : new()
    {
      var ret = new T();
      var myIgnoreFields = new String[] { "IsNew", "IsValid", "Errors" };
      foreach (PropertyInfo prop in typeof(T).GetProperties())
      {
        if (IgnoreFields.Contains(prop.Name) || myIgnoreFields.Contains(prop.Name))
        {
          continue;
        }
        var value = prop.GetValue(domain, null);
        try
        {
          prop.SetValue(ret, value, null);
        }
        catch (Exception)
        {

        }
      }

      return ret;
    }
  }
}
