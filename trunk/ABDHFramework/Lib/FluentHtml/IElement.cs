using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABDHFramework.Lib.FluentHtml
{
  public interface IElement
  {
    /// <summary>
    /// TagBuilder object used to generate HTML.
    /// </summary>
    TagBuilder Builder { get; }

    /// <summary>
    /// Set the value of the specified attribute.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    /// <param name="value">The value of the attribute.</param>
    void SetAttr(string name, object value);

    /// <summary>
    /// Set the value of the specified attribute.
    /// </summary>
    /// <param name="name">The name of the attribute.</param>
    string GetAttr(string name);

    HtmlStyle Style();
  }
}
