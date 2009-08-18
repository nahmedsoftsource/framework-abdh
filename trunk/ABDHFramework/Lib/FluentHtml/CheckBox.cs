using System.Collections.Generic;
using System.Linq.Expressions;

namespace Framework.Lib.FluentHtml
{
	/// <summary>
	/// A radio button.
	/// </summary>
  public class CheckBox : CheckBoxBase<CheckBox>
	{
    public CheckBox(string name) : base(name) { }
	}
}