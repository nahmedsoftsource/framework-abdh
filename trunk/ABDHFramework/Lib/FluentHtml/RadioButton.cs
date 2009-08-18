using System.Collections.Generic;
using System.Linq.Expressions;

namespace Framework.Lib.FluentHtml
{
	/// <summary>
	/// A radio button.
	/// </summary>
	public class RadioButton : RadioButtonBase<RadioButton>
	{
		public RadioButton(string name) : base(name) { }
	}
}