using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.Framework.DesignByContract;

namespace Superior.Data.Collection
{
  public class LazyDictionary<TKey, TValue>: IDictionary<TKey, TValue>
  {
    private IDictionary<TKey, TValue> _data;
    private Func<IDictionary<TKey, TValue>> _loader;

    public LazyDictionary(Func<IDictionary<TKey, TValue>> loader)
    {
      Check.Require(loader != null);
      _loader = loader;
    }

    private IDictionary<TKey, TValue> Data
    {
      get
      {
        if (_data == null)
        {
          using (ConnectionScope.Enter(true))
          {
            _data = _loader();
          }
        }
        return _data;
      }
    }

    #region IDictionary<TKey,TValue> Members

    public void Add(TKey key, TValue value)
    {
      Data.Add(key, value);
    }

    public bool ContainsKey(TKey key)
    {
      return Data.ContainsKey(key);
    }

    public ICollection<TKey> Keys
    {
      get { return Data.Keys; }
    }

    public bool Remove(TKey key)
    {
      return Data.Remove(key);
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
      return Data.TryGetValue(key, out value);
    }

    public ICollection<TValue> Values
    {
      get { return Data.Values; }
    }

    public TValue this[TKey key]
    {
      get
      {
        return Data[key];
      }
      set
      {
        Data[key] = value;
      }
    }

    #endregion

    #region ICollection<KeyValuePair<TKey,TValue>> Members

    public void Add(KeyValuePair<TKey, TValue> item)
    {
      Data.Add(item);
    }

    public void Clear()
    {
      Data.Clear();
    }

    public bool Contains(KeyValuePair<TKey, TValue> item)
    {
      return Data.Contains(item);
    }

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
      Data.CopyTo(array, arrayIndex);
    }

    public int Count
    {
      get { return Data.Count; }
    }

    public bool IsReadOnly
    {
      get { return Data.IsReadOnly; }
    }

    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
      return Data.Remove(item);
    }

    #endregion

    #region IEnumerable<KeyValuePair<TKey,TValue>> Members

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
      return Data.GetEnumerator();
    }

    #endregion

    #region IEnumerable Members

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return Data.GetEnumerator();
    }

    #endregion
  }
}
