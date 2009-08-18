using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace ABDHFramework.Lib.FluentHtml
{
	/// <summary>
	/// Generate a validation message (text inside a span element).
	/// </summary>
	public class ValidationMessage: LiteralBase<ValidationMessage>
	{
		public ValidationMessage() {}

    public virtual ValidationMessage For(string id)
    {
      Builder.MergeAttribute(HtmlAttribute.ValidateFor, id);
      return this;
    }

    protected override void PreRender()
    {
      Class(HtmlHelper.ValidationMessageCssClassName);
      if (GetValue() == null)
      {
        Style("display:none");
      }
      base.PreRender();
    }
	}
}