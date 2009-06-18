using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABDH_Demo.Common
{
  public static class Utility
  {
    public static bool TryGetGuid(string input, out Guid value)
    {
      try
      {
        if (input == null)
        {
          value = Guid.Empty;
          return false;
        }

        value = new Guid(input);
        return true;
      }
      catch (FormatException)
      {
        value = Guid.Empty;
        return false;
      }
    }

    public static String GetStringValue(String value)
    {
      if (value == null)
      {
        return "";
      }

      else
      {
        return value;
      }
    }

    public static int GetIntValue(Nullable<int> value)
    {
      int kq = 0;
      if (value != null && value.HasValue == true)
      {
        kq = value.Value;
      }
      return kq;
    }

    public static Guid GetGuidValue(Nullable<Guid> value)
    {
      Guid kq = new Guid();
      if (value != null && value.HasValue == true)
      {
        kq = value.Value;
      }
      return kq;
    }

    public static DateTime GetDateTimeValue(Nullable<DateTime> value)
    {
      DateTime kq = new DateTime();
      if (value != null && value.HasValue == true)
      {
        kq = value.Value;
      }

      return kq;
    }

    public static Nullable<int> GetPositiveInteger(Nullable<int> value)
    {
      if (value.HasValue == false)
      {
        return null;
      }
      else if (value < 0)
      {
        return 0;
      }
      else
      {
        return value.Value;
      }
    }

    public static Guid GetIDFromObject(DomainBase<Guid> domain)
    {
      if (domain != null)
      {
        return domain.ID;
      }
      else
      {
        return new Guid();
      }
    }

    public static string GetDecimal(decimal value)
    {
      return string.Format("{0:0.00}", value);
    }

    public static int GetRealID(int parentID, int childID, bool isWrite)
    {
      int result;
      if (parentID == 0 && childID != 0)
      {
        result = childID;
      }

      else if (parentID != 0 && childID == 0)
      {
        result = parentID;
      }

      else if (parentID != 0 && childID != 0)
      {
        result = (isWrite == true) ? parentID : childID;
      }
      else
      {
        result = 0;
      }

      return result;
    }

    public static Guid GetRealID(Guid parentGuid, Guid childGuid, bool isWrite)
    {
      Guid result = new Guid();
      if (parentGuid == Guid.Empty && childGuid != Guid.Empty)
      {
        result = childGuid;
      }

      else if (parentGuid != Guid.Empty && childGuid == Guid.Empty)
      {
        result = parentGuid;
      }

      else if (parentGuid != Guid.Empty && childGuid != Guid.Empty)
      {
        result = (isWrite == true) ? parentGuid : childGuid;
      }
      else
      {
        result = new Guid();
      }

      return result;

    }

    public static string searchConditionToSqlPattern(string str)
    {
      for (int i = 0; i < str.Length; i++)
      {
        if (str.IndexOf('*') < str.Length - 1 && str.IndexOf('*') >= 0)
        {
          str = str.Remove(str.IndexOf('*') + 1);
        }
        str = str.Replace('?', '_');
        str = str.Replace("*", "%");
      }
      return str;
    }

    public static string[] getListParams(string[] paramList, string matchText, string sepStr)
    {
      int numKey = 0;
      int numParams = paramList.Length;
      for (int i = 0; i < numParams; i++)
      {
        if (paramList[i].Contains(matchText))
        {
          string itemid = paramList[i];
          itemid = itemid.Substring(itemid.IndexOf(sepStr) + 1);
          paramList[i] = itemid;
          numKey++;
        }
        else
        {
          paramList[i] = "";
        }
      }

      string[] retList = new string[numKey];
      int index = 0;
      for (int i = 0; i < numParams; i++)
      {
        if (paramList[i] != "")
        {
          retList[index++] = paramList[i];
        }
      }
      return retList;
    }
  }
}
