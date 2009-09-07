using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Validation
{
  public class ValidationErrorCollection : IDictionary<string, ValidationError>
  {
    private Dictionary<string, ValidationError> _errors;

    public ValidationErrorCollection()
    {
      _errors = new Dictionary<string, ValidationError>();
    }

    public ValidationErrorCollection(IEnumerable<ValidationError> errors)
    {
      _errors = new Dictionary<string, ValidationError>(errors.ToDictionary((error => error.PropertyName)));
    }

    public ValidationErrorCollection(IDictionary<string, ValidationError> errors)
    {
      _errors = new Dictionary<string, ValidationError>(errors);
    }

    /// <summary>
    /// Adds the specified error.
    /// </summary>
    /// <param name="propertyName">Name of the property.</param>
    /// <param name="errorMessage">The error message.</param>
    public void Add(string propertyName, string errorMessage)
    {
      _errors.Add(propertyName, new ValidationError(propertyName, errorMessage));
    }

    /// <summary>
    /// Adds the specified error.
    /// </summary>
    /// <param name="propertyName">Name of the property.</param>
    /// <param name="errorMessage">The error message.</param>
    /// <param name="sourceObject">The source object.</param>
    public void Add(string propertyName, string errorMessage, object sourceObject)
    {
      _errors.Add(propertyName, new ValidationError(propertyName, errorMessage, sourceObject));
    }

    /// <summary>
    /// Adds the specified error.
    /// </summary>
    /// <param name="error">The error.</param>
    public void Add(ValidationError error)
    {
      if (!_errors.ContainsKey(error.PropertyName)){
        _errors.Add(error.PropertyName, error);
      }
    }

    public void Add(IDictionary<string, ValidationError> validationErrorCollection)
    {
      foreach (var item in validationErrorCollection)
      {
        _errors.Add(item.Key, item.Value);
      }
    }

    #region IEnumerable Members

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return _errors.GetEnumerator();
    }

    #endregion


    #region IDictionary<string,ValidationError> Members

    public void Add(string key, ValidationError value)
    {
      _errors.Add(key, value);
    }

    public bool ContainsKey(string key)
    {
      return _errors.ContainsKey(key);
    }

    public ICollection<string> Keys
    {
      get { return _errors.Keys; }
    }

    public bool Remove(string key)
    {
      return _errors.Remove(key);
    }

    public bool TryGetValue(string key, out ValidationError value)
    {
      return _errors.TryGetValue(key,out value);
    }

    public ICollection<ValidationError> Values
    {
      get { return _errors.Values; }
    }

    public ValidationError this[string key]
    {
      get
      {
        return _errors[key];
      }
      set
      {
        _errors[key] = value;
      }
    }

    #endregion

    #region ICollection<KeyValuePair<string,ValidationError>> Members

    public void Add(KeyValuePair<string, ValidationError> item)
    {
      (_errors as ICollection<KeyValuePair<string,ValidationError>>).Add(item);
    }

    public void Clear()
    {
      _errors.Clear();
    }

    public bool Contains(KeyValuePair<string, ValidationError> item)
    {
      return _errors.Contains(item);
    }

    public void CopyTo(KeyValuePair<string, ValidationError>[] array, int arrayIndex)
    {
      ((ICollection<KeyValuePair<string, ValidationError>>)_errors).CopyTo(array, arrayIndex);
    }

    public int Count
    {
      get { return _errors.Count; }
    }

    public bool IsReadOnly
    {
      get { return ((ICollection<KeyValuePair<string,ValidationError>>)_errors).IsReadOnly; }
    }

    public bool Remove(KeyValuePair<string, ValidationError> item)
    {
      return (_errors as ICollection<KeyValuePair<string,ValidationError>>).Remove(item);
    }

    #endregion

    #region IEnumerable<KeyValuePair<string,ValidationError>> Members

    IEnumerator<KeyValuePair<string, ValidationError>> IEnumerable<KeyValuePair<string, ValidationError>>.GetEnumerator()
    {
      return ((IEnumerable<KeyValuePair<string, ValidationError>>)_errors).GetEnumerator();
    }

    #endregion

  }
}
