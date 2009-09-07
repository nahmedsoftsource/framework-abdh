using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Superior.MobileMedics.Common.Validation
{
  public class NotEmptyGuidAttribute : ValidationAttribute
  {


    public override bool IsValid(object value)
    {
      return (Guid)value != Guid.Empty;
    }
  }
}
