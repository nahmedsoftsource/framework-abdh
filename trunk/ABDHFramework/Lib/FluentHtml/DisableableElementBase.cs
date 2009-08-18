using System.Collections.Generic;
using System.Linq.Expressions;

namespace ABDHFramework.Lib.FluentHtml
{
	/// <summary>
	/// Base class for elements that are disablable.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class DisableableElementBase<T> : ElementBase<T> where T : DisableableElementBase<T>
	{
    protected DisableableElementBase(string tag) : base(tag) { }

		/// <summary>
		/// Set the disabled attribute.
		/// </summary>
		/// <param name="value">Whether the element should be disabled.</param>
		public virtual T Disabled(bool value)
		{
			if (value)
			{
				Attr(HtmlAttribute.Disabled, HtmlAttribute.Disabled);
			}
			else
			{
				RemoveAttr(HtmlAttribute.Disabled);
			}
			return (T)this;
		}
	}
}
