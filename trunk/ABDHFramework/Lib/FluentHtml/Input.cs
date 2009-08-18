using System.Collections.Generic;
using System.Linq.Expressions;

namespace ABDHFramework.Lib.FluentHtml
{
	/// <summary>
	/// Base class for input elements.
	/// </summary>
	/// <typeparam name="T">Derived class type.</typeparam>
	public abstract class Input : InputBase<Input>
	{
		protected Input(string type, string name) : base(type, name)
		{
		}
	}
}
