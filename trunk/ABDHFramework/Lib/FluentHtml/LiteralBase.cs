using System.Collections.Generic;
using System.Linq.Expressions;

namespace ABDHFramework.Lib.FluentHtml
{
	/// <summary>
	/// Base class for a literal (text inside a span element).
	/// </summary>
	public abstract class LiteralBase<T> : FormElement<T> where T : LiteralBase<T>
	{
		protected LiteralBase() : base(HtmlTag.Span, "") { }

    protected override void PreRender()
    {
      Builder.SetInnerText(GetFormattedValue());
      base.PreRender();
    }
	}
}