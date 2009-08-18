using System.Collections.Generic;
using System.Linq.Expressions;

namespace ABDHFramework.Lib.FluentHtml
{
	/// <summary>
	/// Generate an HTML input element of type 'text.'
	/// </summary>
	public class TextBox : TextInputBase<TextBox>
	{
		/// <summary>
		/// Generate an HTML input element of type 'text.'
		/// </summary>
		/// <param name="name">Value of the 'name' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public TextBox(string name) : base(HtmlInputType.Text, name) { }

	}
}
