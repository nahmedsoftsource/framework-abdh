using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Collections;
using System;

namespace ABDHFramework.Lib.FluentHtml
{
  /// <summary>
  /// Base class for form elements.
  /// </summary>
  /// <typeparam name="T">Derived type</typeparam>
  public abstract class FormElement<T> : DisableableElementBase<T>, IFormElement where T : FormElement<T>
  {
    private string _format;
    private object _elementValue;

    protected FormElement(string tag, string name)
      : base(tag)
    {
      SetName(name);
    }

    public override string ToString()
    {
      return base.ToString();
    }

    /// <summary>
    /// Specify a format string to be applied to the value.  The format string can be either a
    /// specification (e.g., '$#,##0.00') or a placeholder (e.g., '{0:$#,##0.00}').
    /// </summary>
    /// <param name="value">A format string.</param>
    public virtual T Format(string value)
    {
      _format = value;
      return (T)this;
    }

    /// <summary>
    /// Set the 'value' attribute.
    /// </summary>
    /// <param name="value">The value for the attribute.</param>
    public virtual T Value(object value)
    {
      SetValue(value);
      return (T)this;
    }

    /// <summary>
    ///   Get the 'value' attribute.
    /// </summary>
    /// <returns></returns>
    public virtual void SetValue(object value)
    {
      _elementValue = value;
    }

    /// <summary>
    ///   Get the 'value' attribute.
    /// </summary>
    /// <returns></returns>
    public virtual object GetValue()
    {
      return _elementValue;
    }

    /// <summary>
    /// Determines how the HTML element is closed.
    /// </summary>
    public override TagRenderMode TagRenderMode
    {
      get { return TagRenderMode.SelfClosing; }
    }

    protected void SetName(string name)
    {
      SetAttr(HtmlAttribute.Name, name);
    }

    protected virtual string GetFormattedValue()
    {
      var rawValue = GetValue();
      if (!(rawValue is string) && rawValue is IEnumerable)
      {
        var items = new List<string>();
        foreach (var item in (IEnumerable)rawValue)
        {
          items.Add(FormatValue(item));
        }
        return string.Join(Environment.NewLine, items.ToArray());
      }
      else
      {
        return FormatValue(rawValue);
      }

    }

    protected virtual string FormatValue(object value)
    {
      return string.IsNullOrEmpty(_format)
             ? value == null
               ? null
               : value.ToString()
             : (_format.StartsWith("{0") && _format.EndsWith("}"))
               ? string.Format(_format, value)
               : string.Format("{0:" + _format + "}", value);
    }
  }
}