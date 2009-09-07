using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Validation
{
  public interface IValidation
  {
    /// <summary>
    /// Gets a value indicating whether this instance is valid.
    /// </summary>
    /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
    bool IsValid { get; }

    /// <summary>
    /// Gets the errors.
    /// </summary>
    /// <value>The errors.</value>
    ValidationErrorCollection Errors { get; }

    /// <summary>
    /// Validates this instance.
    /// </summary>
    /// <returns></returns>
    ValidationErrorCollection Validate();
  }
}
