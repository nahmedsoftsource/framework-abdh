using System.Collections.Generic;
using System.Linq.Expressions;

namespace ABDHFramework.Lib.FluentHtml
{
	/// <summary>
	/// Base class for text input elements.
	/// </summary>
	/// <typeparam name="T">The derived type</typeparam>
	public abstract class TextInputBase<T> : InputBase<T> where T : TextInputBase<T>
	{

    protected TextInputBase(string type, string name) : base(type, name) { }

		/// <summary>
		/// Set the 'maxlength' attribute. 
		/// </summary>
		/// <param name="value">Value for the maxlength attribute.</param>
		public virtual T MaxLength(int value)
		{
			Attr(HtmlAttribute.MaxLength, value);
			return (T)this;
		}
	}
}
