using System.Collections.Generic;
using System.Linq.Expressions;

namespace Framework.Lib.FluentHtml
{
	/// <summary>
	/// Base class for elements that are disablable.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class DisableableElement : DisableableElementBase<DisableableElement>
	{
    protected DisableableElement(string tag) : base(tag) { }

	}
}
