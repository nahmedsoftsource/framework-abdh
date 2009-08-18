using System.Collections.Generic;
using System.Linq.Expressions;

namespace Framework.Lib.FluentHtml
{
	/// <summary>
	/// Base class for input elements.
	/// </summary>
	/// <typeparam name="T">Derived class type.</typeparam>
	public abstract class InputBase<T> : FormElement<T> where T : InputBase<T>
	{

		protected InputBase(string type, string name) : base(HtmlTag.Input, name)
		{
      Builder.MergeAttribute(HtmlAttribute.Name, name, true);
      Builder.MergeAttribute(HtmlAttribute.Type, type, true);
		}

		/// <summary>
		/// Set the 'size' attribute.
		/// </summary>
		/// <param name="value">The value for the attribute.</param>
		public virtual T Size(int value)
		{
			Attr(HtmlAttribute.Size, value);
			return (T)this;
		}

		protected override void PreRender()
		{
			Attr(HtmlAttribute.Value, GetFormattedValue());
			base.PreRender();
		}
	}
}
