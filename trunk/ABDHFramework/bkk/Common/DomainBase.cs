using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.MobileMedics.Common.Validation;

namespace Superior.MobileMedics.Common
{
  /// <summary>
  ///   Base for all Domain objects
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public abstract class DomainBase<T>
  {
    public virtual T ID { get; set; }

    /// <summary>
    /// Gets a value indicating whether this instance is new. Override this property if you use another default id.
    /// </summary>
    /// <value><c>true</c> if this instance is new; otherwise, <c>false</c>.</value>
    public virtual bool IsNew
    {
      get
      {
        return ID.Equals(default(T));
      }
    }
    #region Validation Methods

    private ValidationErrorCollection _errors;
    /// <summary>
    /// Gets a value indicating whether this instance is valid.
    /// </summary>
    /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
    public bool IsValid
    {
      get
      {
        return (_errors == null) || _errors.Any();
      }
    }

    /// <summary>
    /// Gets the errors.
    /// </summary>
    /// <value>The errors.</value>
    public ValidationErrorCollection Errors
    {
      get
      {
        if (_errors == null)
        {
          _errors = new ValidationErrorCollection();
        }
        return _errors;
      }
    }

    /// <summary>
    /// Validates this instance.
    /// </summary>
    /// <returns></returns>
    public ValidationErrorCollection Validate()
    {
      _errors = DataAnnotationsValidationRunner.GetErrors(this);
      OnValidating(_errors);
      return _errors;
    }

    /// <summary>
    /// Called when [validating]. Override this if you need to validate more than default.
    /// </summary>
    /// <param name="errors">The errors.</param>
    protected virtual void OnValidating(ValidationErrorCollection errors)
    {
    }
    #endregion
  }
}
