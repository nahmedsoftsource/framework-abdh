using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections;

namespace Superior.Framework.Exception
{
  public class ExceptionHandler
  {
    public ExceptionHandler()
    {
      ErrorNumber = Guid.NewGuid();
    }

    public string Message { get; set; }
    public int HttpErrorCode { get; set; }
    public Guid ErrorNumber { get; set; }
    public System.Exception InnerException { get; set; }

    public static ExceptionHandler Handle(System.Exception ex)
    {
      return Handle(ex, false);
    }

    public static ExceptionHandler Handle(System.Exception ex, bool logAll)
    {
      ExceptionHandler handler = new ExceptionHandler();
      handler.InnerException = ex;
      HttpException httpException = ex as HttpException;
      if (httpException != null && httpException.GetHttpCode() != 500)
      {
        handler.Message = httpException.Message;
        handler.HttpErrorCode = httpException.GetHttpCode();
      }
      else if (httpException != null && httpException is HttpRequestValidationException)
      {
        handler.Message = httpException.Message;
        handler.HttpErrorCode = httpException.GetHttpCode();
      }
      // handle this very special case only
      else if (httpException != null && httpException.Message == "Maximum request length exceeded.")
      {
        handler.Message = httpException.Message;
        handler.HttpErrorCode = 500;
      }
      else if (ex is SuperiorExceptionBase)
      {
        handler.Message = ex.Message;
        handler.ErrorNumber = (ex as SuperiorExceptionBase).Guid;
        handler.HttpErrorCode = 500;
      }
      else
      {
        handler.Message = "Sorry, an error occurred while processing your request. If you still get this error, please give us this error number: " + handler.ErrorNumber.ToString("N").Substring(0, 8);
        handler.HttpErrorCode = 500;
      }

      StringBuilder additionalInfo = new StringBuilder();
      /* watch intermittent error*/
      if (ex.Message.Contains("The connection's current state is closed."))
      {
        if (HttpContext.Current != null)
        {
          additionalInfo.AppendLine("---- Context Variables ----");
          foreach (var key in HttpContext.Current.Items.Keys)
          {
            if (key != null && HttpContext.Current.Items[key] != null)
            {
              string name = key.ToString();
              string value = HttpContext.Current.Items[key].ToString();
              additionalInfo.Append(name).Append(" = ").Append(value).AppendLine();
            }
          }
        }
      }

      if (HttpContext.Current != null)
      {
        if (HttpContext.Current.Session != null && HttpContext.Current.Session.Count > 0)
        {
          additionalInfo.AppendLine("---- Session Variables ----");
          foreach (var item in HttpContext.Current.Session)
          {
            if (item != null && HttpContext.Current.Session[item.ToString()] != null)
            {
              string name = item.ToString();
              string value = HttpContext.Current.Session[name].ToString();
              additionalInfo.Append(name).Append(" = ").Append(value).AppendLine();
            }
          }
        }
        if (HttpContext.Current.Application != null && HttpContext.Current.Application.Count > 0)
        {
          additionalInfo.AppendLine("---- Application Variables ----");
          foreach (var item in HttpContext.Current.Application)
          {
            if (item != null && HttpContext.Current.Application[item.ToString()] != null)
            {
              string name = item.ToString();
              string value = HttpContext.Current.Application[name].ToString();
              additionalInfo.Append(name).Append(" = ").Append(value).AppendLine();
            }
          }
        }
        if (HttpContext.Current.Request != null)
        {
          if (HttpContext.Current.Request.QueryString != null && HttpContext.Current.Request.QueryString.Count > 0)
          {
            additionalInfo.AppendLine("---- QueryString Variables ----");
            foreach (var item in HttpContext.Current.Request.QueryString)
            {
              if (item != null && HttpContext.Current.Request.QueryString[item.ToString()] != null)
              {
                string name = item.ToString();
                string value = HttpContext.Current.Request.QueryString[name];
                additionalInfo.Append(name).Append(" = ").Append(value).AppendLine();
              }
            }
          }
          /*if (HttpContext.Current.Request.Form != null && HttpContext.Current.Request.Form.Count > 0)
          {
            additionalInfo.AppendLine("---- Form Variables ----");
            foreach (var item in HttpContext.Current.Request.Form)
            {
              if (item != null && HttpContext.Current.Request.Form[item.ToString()] != null)
              {
                string name = item.ToString();
                string value = HttpContext.Current.Request.Form[name];
                additionalInfo.Append(name).Append(" = ").Append(value).AppendLine();
              }
            }
          }*/
          if (HttpContext.Current.Request.ServerVariables != null && HttpContext.Current.Request.ServerVariables.Count > 0)
          {
            additionalInfo.AppendLine("---- ServerVariables Variables ----");
            foreach (var item in HttpContext.Current.Request.ServerVariables)
            {
              if (item != null)
              {
                string name = item.ToString();
                string value = HttpContext.Current.Request.ServerVariables[name];
                additionalInfo.Append(name).Append(" = ").Append(value).AppendLine();
              }
            }
          }
          if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies.Count > 0)
          {
            additionalInfo.AppendLine("---- Cookies Variables ----");
            foreach (var item in HttpContext.Current.Request.Cookies)
            {
              if (item != null && HttpContext.Current.Request.Cookies[item.ToString()] != null)
              {
                string name = item.ToString();
                string value = HttpContext.Current.Request.Cookies[name].ToString();
                additionalInfo.Append(name).Append(" = ").Append(value).AppendLine();
              }
            }
          }
        }
      }
      // do not log the user message
      if (logAll || !(ex is SuperiorExceptionBase))
      {
        using (log4net.NDC.Push(additionalInfo.ToString()))
        {
          Logger.Current.Error(handler.Message, handler.InnerException);
        }
      }
      return handler;
    }
  }
}
