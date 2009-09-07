using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Superior.MobileMedics.Common.Validation
{
  public static class DataAnnotationsValidationRunner
  {
    public static ValidationErrorCollection GetErrors(object instance)
    {
      ValidationErrorCollection errors = new ValidationErrorCollection();
      foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(instance).Cast<PropertyDescriptor>())
      {
        foreach (ValidationAttribute attribute in prop.Attributes.OfType<ValidationAttribute>())
        {
          if (!attribute.IsValid(prop.GetValue(instance)))
          {
            errors.Add(new ValidationError(prop.Name, attribute.FormatErrorMessage(string.Empty), instance));
          } else if (attribute is DataTypeAttribute){
            var dataAttr = (DataTypeAttribute)attribute;

            // validate datetime min, max
            if (dataAttr.DataType == DataType.Date || dataAttr.DataType == DataType.DateTime){
              if (prop.PropertyType == typeof(DateTime) || (prop.PropertyType == typeof(DateTime?) && prop.GetValue(instance) != null)){
                // validate min date
                DateTime value;
                if (prop.PropertyType == typeof(DateTime))
                {
                  value = (DateTime)prop.GetValue(instance);
                }
                else
                {
                  value = ((DateTime?)prop.GetValue(instance)).Value;
                }

                if (value < System.Data.SqlTypes.SqlDateTime.MinValue.Value || value > System.Data.SqlTypes.SqlDateTime.MaxValue.Value)
                {
                  errors.Add(new ValidationError(prop.Name, "Invalid datetime input", instance));
                }
              }
            }
            else if (dataAttr.DataType == DataType.EmailAddress)
            {
              var value = prop.GetValue(instance) as String;

              if (value.Length > 0 && !Regex.Match(value, "^[\\w\\.=-]+@[\\w\\.-]+\\.[\\w]{2,}$").Success)
              {
                errors.Add(new ValidationError(prop.Name, "Please enter a valid email address", instance));
              }
            }
          }
        }
      }

      return errors;
    }
  }
}
