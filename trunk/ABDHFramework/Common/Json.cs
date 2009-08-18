using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ABDHFramework.Common
{
  public class Json
  {
    /// <summary>
    /// encode
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string Encode(Object obj)
    {
      var jss = new JavaScriptSerializer();
      return jss.Serialize(obj);

    }

    /// <summary>
    /// decode
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="json"></param>
    /// <returns></returns>
    public static T Decode<T>(string json)
    {
      var jss = new JavaScriptSerializer();
      return jss.Deserialize<T>(json);

    }

    /// <summary>
    /// encode dictionary
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="dic"></param>
    /// <returns></returns>
    public static string EncodeDictionary<TKey, TValue>(IDictionary<TKey, TValue> dic)
    {
      var ret = new List<String>();
      foreach (var kvp in dic)
      {
        ret.Add(Encode(kvp.Key.ToString()) + ":" + Encode(kvp.Value));
      }
      return "{" + String.Join(",", ret.ToArray()) + "}";
    }

    /// <summary>
    /// convert dictionary to object
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    /// <param name="dic"></param>
    /// <returns></returns>
    public static Object DictionaryToObject<TKey, TValue>(IDictionary<TKey, TValue> dic)
    {
      return Decode<Object>(EncodeDictionary(dic));
    }
  }
}
