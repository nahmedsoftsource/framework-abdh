using System;
using System.Web.Mvc;

namespace ABDHFramework.Lib.FluentHtml.Behaviors
{
	public class ValidationBehavior : IBehavior
	{
		private readonly Func<ModelState> _validationFunc;
		private readonly string validationErrorCssClass;

    public ValidationBehavior(Func<ModelState> validationFunc)
      : this(validationFunc, HtmlHelper.ValidationInputCssClassName) { }

    public ValidationBehavior(Func<ModelState> validationFunc, string validationErrorCssClass)
		{
      this._validationFunc = validationFunc;
			this.validationErrorCssClass = validationErrorCssClass;
		}

		public void Execute(IElement element)
		{
      ModelState state = _validationFunc();
			if (state != null && state.Errors != null && state.Errors.Count > 0)
			{
				element.Builder.AddCssClass(validationErrorCssClass);
        if (element is IFormElement && state.Value != null)
        {
          ((IFormElement)element).SetValue(state.Value.AttemptedValue);
        }
			}
		}
	}
}