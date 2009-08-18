using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Framework.Lib.FluentHtml
{
  /// <summary>
  /// base class for an HTML textarea element.
  /// </summary>
  public abstract class TextAreaBase<T> : FormElement<T> where T : TextAreaBase<T>
  {
    protected TextAreaBase(string name) : base(HtmlTag.TextArea, name) { }

    /// <summary>
    /// Set the 'rows' attribute.
    /// </summary>
    /// <param name="value">The value of the rows attribute<./param>
    public virtual T Rows(int value)
    {
      Attr(HtmlAttribute.Rows, value);
      return (T)this;
    }

    /// <summary>
    /// Set the 'columns' attribute.
    /// </summary>
    /// <param name="value">The value of the columns attribute.</param>
    public virtual T Columns(int value)
    {
      Attr(HtmlAttribute.Cols, value);
      return (T)this;
    }

    protected override void PreRender()
    {
      Builder.SetInnerText(GetFormattedValue());
      base.PreRender();
    }

    public override TagRenderMode TagRenderMode
    {
      get { return TagRenderMode.Normal; }
    }
  }
}