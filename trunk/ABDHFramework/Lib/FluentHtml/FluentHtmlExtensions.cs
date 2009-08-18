using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Framework.Lib.FluentHtml.Behaviors;
using System.Web.Mvc;
using System.Globalization;
using System.Web.Mvc.Resources;
using ABDHFramework;
using Framework.Lib.FluentHtml;
using Framework.Lib;

namespace ABDHFramework.Lib.FluentHtml
{
  public static class FluentHtmlExtensions
  {
    private static string _resourceClassKey;

    public static string ResourceClassKey
    {
      get
      {
        return _resourceClassKey ?? String.Empty;
      }
      set
      {
        _resourceClassKey = value;
      }
    }

    #region Fluent controls

    public static TextBox TextBox(this FluentHtmlHelper html, string name)
    {
      return new TextBox(name).Value(String.IsNullOrEmpty(name) ? null : html.ViewData.Eval(name))
        .Do(ValidateOn(html, name));
    }

    public static Literal Literal(this FluentHtmlHelper html)
    {
      return new Literal();
    }

    public static Literal Literal(this FluentHtmlHelper html, string name)
    {
      return new Literal().Value(String.IsNullOrEmpty(name) ? null : html.ViewData.Eval(name));
    }

    public static TextArea TextArea(this FluentHtmlHelper html, string name)
    {
      return new TextArea(name).Value(String.IsNullOrEmpty(name) ? null : html.ViewData.Eval(name))
        .Do(ValidateOn(html, name));
    }

    public static SubmitButton SubmitButton(this FluentHtmlHelper html, string name)
    {
      return new SubmitButton(name);
    }

    public static RadioButton RadioButton(this FluentHtmlHelper html, string name)
    {
      return new RadioButton(name).SelectedValue(String.IsNullOrEmpty(name) ? null : html.ViewData.Eval(name));
    }

    public static CheckBox CheckBox(this FluentHtmlHelper html, string name)
    {
      return new CheckBox(name).SelectedValue(String.IsNullOrEmpty(name) ? null : html.ViewData.Eval(name));
    }

    public static ValidationMessage ValidationMessage(this FluentHtmlHelper html, string name)
    {
      ModelState state = GetModelState(html, name);
      string message = null;
      if (state != null && state.Errors != null && state.Errors.Count > 0)
      {
        message = GetUserErrorMessageOrDefault(html.ViewContext.HttpContext, state.Errors[0], state);
      }
      return new ValidationMessage().Value(message);
    }

    #endregion

    #region Behaviors

    public static ValidationBehavior ValidateOn(this FluentHtmlHelper html, string name)
    {
      if (!String.IsNullOrEmpty(name))
      {
        return new ValidationBehavior(() => GetModelState(html, name));
      }
      return null;
    }

    #endregion

    #region Support methods

    private static ModelState GetModelState(FluentHtmlHelper html, string name)
    {
      ModelState state;
      if (html.ViewData.ModelState.TryGetValue(name, out state))
      {
        return state;
      }
      return null;
    }

    private static string GetUserErrorMessageOrDefault(HttpContextBase httpContext, ModelError error, ModelState modelState)
    {
      if (!String.IsNullOrEmpty(error.ErrorMessage))
      {
        return error.ErrorMessage;
      }
      if (modelState == null)
      {
        return null;
      }

      string attemptedValue = (modelState.Value != null) ? modelState.Value.AttemptedValue : null;
      return String.Format(CultureInfo.CurrentCulture, GetInvalidPropertyValueResource(httpContext), attemptedValue);
    }

    private static string GetInvalidPropertyValueResource(HttpContextBase httpContext)
    {
      string resourceValue = null;
      if (!String.IsNullOrEmpty(ResourceClassKey) && (httpContext != null))
      {
        // If the user specified a ResourceClassKey try to load the resource they specified.
        // If the class key is invalid, an exception will be thrown.
        // If the class key is valid but the resource is not found, it returns null, in which
        // case it will fall back to the MVC default error message.
        resourceValue = httpContext.GetGlobalResourceObject(ResourceClassKey, "InvalidPropertyValue", CultureInfo.CurrentUICulture) as string;
      }
      return resourceValue ?? "Invalid value";
    }
    #endregion
  }
}
