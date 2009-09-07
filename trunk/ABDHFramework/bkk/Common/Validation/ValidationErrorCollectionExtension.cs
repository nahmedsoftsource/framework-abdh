using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Validation
{
  public static class ValidationErrorCollectionExtension
  {
    /// <summary>
    /// add prefix to error name
    /// </summary>
    /// <param name="errors"></param>
    /// <param name="prefix"></param>
    /// <returns></returns>
    public static ValidationErrorCollection AddPrefix(this ValidationErrorCollection errors, String prefix)
    {
      var ret = new ValidationErrorCollection();

      foreach (var item in errors)
      {
        ret.Add(prefix + item.Key, new ValidationError(prefix + item.Value.PropertyName, item.Value.ErrorMessage, item.Value.SourceObject));
      }

      return ret;
    }
  }
}
