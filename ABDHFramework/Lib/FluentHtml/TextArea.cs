using System.Collections.Generic;
using System.Linq.Expressions;

namespace ABDHFramework.Lib.FluentHtml
{
	public class TextArea : TextAreaBase<TextArea>
	{
		/// <summary>
		/// Generate an HTML textarea element.
		/// </summary>
		/// <param name="name">Value of the 'name' attribute of the element.  Also used to derive the 'id' attribute.</param>
		public TextArea(string name) : base(name) { }

	}
}
