using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Identifiers
{
  public class IdGeneratorContainer
  {
    private static readonly Dictionary<Type, object> _container = new Dictionary<Type, object>();

    static IdGeneratorContainer()
    {
      _container.Add(typeof(Guid), new GuidIdGenerator());
    }

    public static void RegisterInstance<T>(IdGenerator<T> instance)
    {
      _container.Add(typeof(T), instance);
    }

    public static IdGenerator<T> GetInstance<T>()
    {
      if (_container.ContainsKey(typeof(T)))
      {
        return _container[typeof(T)] as IdGenerator<T>;
      }
      return new DefaultIdGenerator<T>();
    }

  }
}
