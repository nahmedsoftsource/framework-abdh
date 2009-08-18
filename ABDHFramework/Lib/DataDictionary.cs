using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace ABDHFramework.Lib
{
  /// <summary>
  ///   This class is to replace the use of object in some place, which brings us more flexibility
  /// </summary>
  public class DataDictionary: IDictionary<string, object>
  {
    private Dictionary<string, object> _values = new Dictionary<string,object>();

    /// <summary>
    /// Adds the specified data.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public DataDictionary Add(IDictionary<string, object> data)
    {
      foreach (var item in data)
      {
        if (!_values.ContainsKey(item.Key))
        {
          _values.Add(item.Key, item.Value);
        }
      }
      return this;
    }

    /// <summary>
    /// Adds the specified key/value.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public DataDictionary Add(string key, object value)
    {
      _values.Add(key, value);
      return this;
    }

    /// <summary>
    /// Merges the specified data.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public DataDictionary Merge(IDictionary<string, object> data)
    {
      foreach (var item in data)
      {
        if (!_values.ContainsKey(item.Key))
        {
          _values.Add(item.Key, item.Value);
        }
        else
        {
          _values[item.Key] = item.Value;
        }
      }
      return this;
    }

    /// <summary>
    /// Merges the specified key/value.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public DataDictionary Merge(string key, object value)
    {
      if (!_values.ContainsKey(key))
      {
        _values.Add(key, value);
      }
      else
      {
        _values[key] = value;
      }
      return this;
    }

    /// <summary>
    /// Adds the object.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public DataDictionary AddObject(Object data)
    {
      return Add(new RouteValueDictionary(data));
    }

    /// <summary>
    /// Merges the object.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public DataDictionary MergeObject(Object data)
    {
      return Merge(new RouteValueDictionary(data));
    }

    #region IDictionary<string,object> Members

    /// <summary>
    /// Adds an element with the provided key and value to the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
    /// </summary>
    /// <param name="key">The object to use as the key of the element to add.</param>
    /// <param name="value">The object to use as the value of the element to add.</param>
    /// <exception cref="T:System.ArgumentNullException">
    /// 	<paramref name="key"/> is null.
    /// </exception>
    /// <exception cref="T:System.ArgumentException">
    /// An element with the same key already exists in the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
    /// </exception>
    /// <exception cref="T:System.NotSupportedException">
    /// The <see cref="T:System.Collections.Generic.IDictionary`2"/> is read-only.
    /// </exception>
    void IDictionary<string,object>.Add(string key, object value)
    {
      _values.Add(key, value);
    }

    /// <summary>
    /// Determines whether the <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the specified key.
    /// </summary>
    /// <param name="key">The key to locate in the <see cref="T:System.Collections.Generic.IDictionary`2"/>.</param>
    /// <returns>
    /// true if the <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the key; otherwise, false.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// 	<paramref name="key"/> is null.
    /// </exception>
    public bool ContainsKey(string key)
    {
      return _values.ContainsKey(key);
    }

    /// <summary>
    /// Gets an <see cref="T:System.Collections.Generic.ICollection`1"/> containing the keys of the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// An <see cref="T:System.Collections.Generic.ICollection`1"/> containing the keys of the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"/>.
    /// </returns>
    public ICollection<string> Keys
    {
      get { return _values.Keys; }
    }

    /// <summary>
    /// Removes the element with the specified key from the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
    /// </summary>
    /// <param name="key">The key of the element to remove.</param>
    /// <returns>
    /// true if the element is successfully removed; otherwise, false.  This method also returns false if <paramref name="key"/> was not found in the original <see cref="T:System.Collections.Generic.IDictionary`2"/>.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// 	<paramref name="key"/> is null.
    /// </exception>
    /// <exception cref="T:System.NotSupportedException">
    /// The <see cref="T:System.Collections.Generic.IDictionary`2"/> is read-only.
    /// </exception>
    public bool Remove(string key)
    {
      return _values.Remove(key);
    }

    /// <summary>
    /// Gets the value associated with the specified key.
    /// </summary>
    /// <param name="key">The key whose value to get.</param>
    /// <param name="value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.</param>
    /// <returns>
    /// true if the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the specified key; otherwise, false.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// 	<paramref name="key"/> is null.
    /// </exception>
    public bool TryGetValue(string key, out object value)
    {
      return _values.TryGetValue(key, out value);
    }

    /// <summary>
    /// Gets an <see cref="T:System.Collections.Generic.ICollection`1"/> containing the values in the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// An <see cref="T:System.Collections.Generic.ICollection`1"/> containing the values in the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"/>.
    /// </returns>
    public ICollection<object> Values
    {
      get { return _values.Values; }
    }

    /// <summary>
    /// Gets or sets the <see cref="System.Object"/> with the specified key.
    /// </summary>
    /// <value></value>
    public object this[string key]
    {
      get
      {
        return _values[key];
      }
      set
      {
        _values[key] = value;
      }
    }

    #endregion

    #region ICollection<KeyValuePair<string,object>> Members

    /// <summary>
    /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
    /// </summary>
    /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
    /// <exception cref="T:System.NotSupportedException">
    /// The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
    /// </exception>
    public void Add(KeyValuePair<string, object> item)
    {
      (_values as ICollection<KeyValuePair<string, object>>).Add(item);
    }

    /// <summary>
    /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
    /// </summary>
    /// <exception cref="T:System.NotSupportedException">
    /// The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
    /// </exception>
    public void Clear()
    {
      _values.Clear();
    }

    /// <summary>
    /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"/> contains a specific value.
    /// </summary>
    /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
    /// <returns>
    /// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
    /// </returns>
    public bool Contains(KeyValuePair<string, object> item)
    {
      return _values.Contains(item);
    }

    /// <summary>
    /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
    /// </summary>
    /// <param name="array">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1"/>. The <see cref="T:System.Array"/> must have zero-based indexing.</param>
    /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
    /// <exception cref="T:System.ArgumentNullException">
    /// 	<paramref name="array"/> is null.
    /// </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// 	<paramref name="arrayIndex"/> is less than 0.
    /// </exception>
    /// <exception cref="T:System.ArgumentException">
    /// 	<paramref name="array"/> is multidimensional.
    /// -or-
    /// <paramref name="arrayIndex"/> is equal to or greater than the length of <paramref name="array"/>.
    /// -or-
    /// The number of elements in the source <see cref="T:System.Collections.Generic.ICollection`1"/> is greater than the available space from <paramref name="arrayIndex"/> to the end of the destination <paramref name="array"/>.
    /// -or-
    /// Type <paramref name="T"/> cannot be cast automatically to the type of the destination <paramref name="array"/>.
    /// </exception>
    public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
    {
      (_values as ICollection<KeyValuePair<string, object>>).CopyTo(array, arrayIndex);
    }

    /// <summary>
    /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
    /// </returns>
    public int Count
    {
      get { return _values.Count; }
    }

    /// <summary>
    /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
    /// </summary>
    /// <value></value>
    /// <returns>true if the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only; otherwise, false.
    /// </returns>
    public bool IsReadOnly
    {
      get { return (_values as ICollection<KeyValuePair<string, object>>).IsReadOnly; }
    }

    /// <summary>
    /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
    /// </summary>
    /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
    /// <returns>
    /// true if <paramref name="item"/> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.
    /// </returns>
    /// <exception cref="T:System.NotSupportedException">
    /// The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
    /// </exception>
    public bool Remove(KeyValuePair<string, object> item)
    {
      return (_values as ICollection<KeyValuePair<string, object>>).Remove(item);
    }

    #endregion

    #region IEnumerable<KeyValuePair<string,object>> Members

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
    /// </returns>
    public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
    {
      return _values.GetEnumerator();
    }

    #endregion

    #region IEnumerable Members

    /// <summary>
    /// Returns an enumerator that iterates through a collection.
    /// </summary>
    /// <returns>
    /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
    /// </returns>
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return _values.GetEnumerator();
    }

    #endregion
  }
}
