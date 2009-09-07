using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.Framework.Exception;

namespace Superior.MobileMedics.Common.Validation
{
  public class ValidationException : SuperiorExceptionBase
  {
    #region Constructors

    public ValidationException(IEnumerable<ValidationError> errors)
      :base("")
    {
      Errors = new ValidationErrorCollection(errors);
    }

    public ValidationException(IDictionary<string, ValidationError> errors)
      : base("")
    {
      Errors = new ValidationErrorCollection(errors);
    }

    public ValidationException(ValidationErrorCollection errors)
      : base("")
    {
      Errors = errors;
    }

    public ValidationException(string propertyName, string errorMessage)
      : this(propertyName, errorMessage, null) { }

    public ValidationException(string propertyName, string errorMessage, object onObject)
      :base(errorMessage)
    {
      Errors = new ValidationErrorCollection(new[] { new ValidationError(propertyName, errorMessage, onObject) });
    }

    #endregion

    #region Public properties

    public ValidationErrorCollection Errors { get; private set; }

    public override string Message
    {
      get
      {
        StringBuilder strBuilder = new StringBuilder();
        strBuilder.AppendLine("Input validation failed");
        foreach (var item in Errors.Values)
        {
          strBuilder.AppendLine(item.ErrorMessage);
        }
        return strBuilder.ToString();
      }
    }
    #endregion

  }
}
