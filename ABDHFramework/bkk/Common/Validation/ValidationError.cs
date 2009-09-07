using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Validation
{
  public class ValidationError
  {
    public string PropertyName { get; private set; }
    public string ErrorMessage { get; private set; }
    public object SourceObject { get; private set; }

    public ValidationError(string propertyName, string errorMessage, object sourceObject)
    {
      PropertyName = propertyName;
      ErrorMessage = errorMessage;
      SourceObject = sourceObject;
    }

    public ValidationError(string propertyName, string errorMessage)
      : this(propertyName, errorMessage, null)
    {
    }
  }
}
