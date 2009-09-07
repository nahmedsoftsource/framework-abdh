using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Superior.Framework
{
  /// <summary>
  ///   Gets or sets the thread-context object
  /// </summary>
  public class ThreadContextContainer
  {
    [ThreadStatic]
    private static IDictionary<string, object> _contextDictionary;
    
    private static IDictionary<string, object> ContextDictionary
    {
      get
      {
        if (HttpContext.Current != null)
        {
          return HttpContext.Current.Items[typeof(ThreadContextContainer).AssemblyQualifiedName] as IDictionary<string, object>;
        }
        else
        {
          return _contextDictionary;
        }
      }
      set
      {
        if (HttpContext.Current != null)
        {
          HttpContext.Current.Items[typeof(ThreadContextContainer).AssemblyQualifiedName] = value;
        }
        else
        {
          _contextDictionary = value;
        }
      }
    }

    /// <summary>
    /// Gets the context object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">The key.</param>
    /// <returns></returns>
    public static T GetContextObject<T>(string key)
    {
      if (ContextDictionary == null)
      {
        ContextDictionary = new Dictionary<string, object>();
      }
      if (ContextDictionary.ContainsKey(key))
      {
        object result = ContextDictionary[key];
        if (result.GetType() == typeof(T))
        {
          return (T)result;
        }
      }
      return default(T);
    }

    /// <summary>
    /// Gets the context object or default.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">The key.</param>
    /// <param name="activator">The activator to create the default object.</param>
    /// <returns></returns>
    public static T GetContextObjectOrDefault<T>(string key, Func<T> activator)
    {
      T result = GetContextObject<T>(key);
      if (result.Equals(default(T)))
      {
        if (activator != null)
        {
          result = activator();
        }
      }
      return result;
    }

    /// <summary>
    /// Sets the context object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key">The key.</param>
    /// <param name="obj">The obj. Null for removing that object</param>
    public static void SetContextObject<T>(string key, T obj)
    {
      if (obj == null)
      {
        if (ContextDictionary != null && ContextDictionary.ContainsKey(key))
        {
          ContextDictionary.Remove(key);
          // clean up the context memory
          if (ContextDictionary.Count == 0)
          {
            ContextDictionary = null;
          }
        }
        return;
      }
      if (ContextDictionary == null)
      {
        ContextDictionary = new Dictionary<string, object>();
      }
      ContextDictionary[key] = obj;
    }
  }
}
