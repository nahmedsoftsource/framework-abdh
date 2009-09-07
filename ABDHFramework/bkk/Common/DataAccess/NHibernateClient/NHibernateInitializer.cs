using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Superior.MobileMedics.Common.DataAccess.NHibernateClient
{
  public class NHibernateInitializer
  {
    /// <summary>
    /// Get property value of an object
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="propertyName"></param>
    /// <returns></returns>
    private static object GetPropertyValue(object obj, string propertyName)
    {
      PropertyInfo p = obj.GetType().GetProperty(propertyName);

      return p.GetValue(obj, null);
    }

    private static void Initialize(object obj, string nestedPathToInitialize)
    {
      string[] propertyNames = nestedPathToInitialize.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
      if (propertyNames.Length <= 1)
        NHibernate.NHibernateUtil.Initialize(GetPropertyValue(obj,nestedPathToInitialize));

      for (int i = 0; i < propertyNames.Length - 1; i++)
      {
        object property = GetPropertyValue(obj, propertyNames[i]);
        NHibernate.NHibernateUtil.Initialize(property);
      }
    }

    public static void Initialize(object obj, string[] nestedPathsToInitialize)
    {
      for (int i = 0; i < nestedPathsToInitialize.Length;i++ )
      {
        Initialize(obj, nestedPathsToInitialize[i]);  
      }
    }
  }
}
