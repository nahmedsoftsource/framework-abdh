using System.Collections.Generic;

namespace ABDHFramework.Lib.FluentHtml
{
		/// <summary>
	/// Generate an HTML input element of type 'submit.'
	/// </summary>
	public class Button : InputBase<Button>
	{
		/// <summary>
		/// Generate an HTML input element of type 'submit.'
		/// </summary>
		/// <param name="text">Value of the 'value' and 'name' attributes. Also used to derive the 'id' attribute.</param>
    public Button(string text) : base(HtmlInputType.Button, text) { }
	}
}
