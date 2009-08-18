using System.Collections.Generic;
using System.Linq.Expressions;

namespace ABDHFramework.Lib.FluentHtml
{
	/// <summary>
	/// Base class for input elements.
	/// </summary>
	/// <typeparam name="T">Derived class type.</typeparam>
	public class HiddenField : InputBase<HiddenField>
	{
    public HiddenField(string name)
      : base(HtmlInputType.Hidden, name)
		{
		}
	}
}
