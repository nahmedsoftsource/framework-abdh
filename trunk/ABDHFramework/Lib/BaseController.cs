using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABDHFramework.Data;
using System.Web.Mvc;
using ABDHFramework.Common;
using ABDHFramework.Lib.Javascripts;
using ABDHFramework.Routing;
using ABDHFramework.Services;
using ABDHFramework.Utility.ActionFilter;

namespace ABDHFramework.Lib
{
  [SetCulture]
  public  class BaseController : System.Web.Mvc.Controller
  {
    public ActionResult SetCulture(string id)
    {

      HttpCookie userCookie = Request.Cookies["Culture"];

      userCookie.Value = id;
      userCookie.Expires = DateTime.Now.AddYears(100);
      Response.SetCookie(userCookie);

      return Redirect(Request.UrlReferrer.ToString());
    }
    public static ABDHFrameworkService Service
    {
      get
      {
        return ABDHFrameworkService.Instance;
      }
    }
    #region Properties
    private ISearchQuery _searchQuery;
    protected ISearchQuery SearchQuery
    {
      get
      {
        //if (_searchQuery == null)
        //  _searchQuery = SearchQueryBuilder.CreateQuery();
        return _searchQuery;
      }
      set
      {
        _searchQuery = value;
      }
    }

    private Routing.Routing _routing;
    public Routing.Routing Routing
    {
      get
      {
        if (_routing == null)
        {
          _routing = new Routing.Routing(Url);
        }
        return _routing;
      }
    }
    #endregion

    #region Utilities
    /// <summary>
    /// get param
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Object getParam(String name)
    {
      // check [] value
      if (Request.Params.Get(name + "[]") != null)
      {
        return Request.Params.GetValues(name + "[]");
      }
      else
      {
        return Request.Params.Get(name);
      }
    }

    /// <summary>
    /// get param with default value
    /// </summary>
    /// <param name="name"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public Object getParam(String name, Object defaultValue)
    {
      return getParam(name) != null ? getParam(name) : defaultValue;
    }

    /// <summary>
    /// get param with default value
    /// </summary>
    /// <param name="name"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public Y getParam<Y>(String name, Object defaultValue)
    {
      return (Y)(getParam(name) != null ? getParam(name) : defaultValue);
    }

    /// <summary>
    /// close dialog
    /// </summary>
    /// <param name="option"></param>
    /// <returns></returns>
    protected JsonResult CloseDialog(DialogCloseOption option)
    {
      if (option.ReloadID == null)
      {
        option.ReloadID = Request.Params.Get("ReloadID");
      }

      if (option.ReloadURL == null)
      {
        option.ReloadURL = Request.Params.Get("ReloadURL");
      }

      if (option.RunJS == null)
      {
        option.RunJS = Request.Params.Get("RunJS");
      }

      return Json(new
      {
        complete = option.Close,
        message = option.Message,
        eventName = option.EventName,
        eventData = option.EventData,
        reloadID = option.ReloadID,
        reloadURL = option.ReloadURL,
        redirectURL = option.RedirectURL,
        runJS = option.RunJS
      });
    }

    /// <summary>
    /// bind value from request to object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    public void Bind<T>(T obj)
    {
      Bind<T>(obj, null);
    }

    /// <summary>
    /// bind value from request to object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <param name="fields"></param>
    public void Bind<T>(T obj, IEnumerable<String> fields)
    {
      // binding value
      var fieldList = fields != null ? fields : Request.Params.AllKeys;
      foreach (var key in fieldList)
      {
        var type = typeof(T);
        var prop = type.GetProperty(key);
        if (prop != null)
        {
          if (prop.PropertyType == typeof(String))
          {
            prop.SetValue(obj, Request[key], null);
          }
          else if (prop.PropertyType == typeof(int))
          {
            var value = Tool.ToInt(Request[key]);

            if (value != null)
            {
              prop.SetValue(obj, value.Value, null);
            }
          }
          else if (prop.PropertyType == typeof(int?))
          {
            prop.SetValue(obj, Tool.ToInt(Request[key]), null);
          }
          else if (prop.PropertyType == typeof(Guid))
          {
            if (Tool.IsGuid(Request[key]))
            {
              prop.SetValue(obj, new Guid(Request[key]), null);
            }
            else
            {
              prop.SetValue(obj, null, null);
            }
          }
          else if (prop.PropertyType == typeof(Guid?))
          {
            if (Tool.IsGuid(Request[key]))
            {
              prop.SetValue(obj, new Guid(Request[key]), null);
            }
            else
            {
              prop.SetValue(obj, null, null);
            }
          }
        }
      }
    }

    /// <summary>
    /// close any opened dialog
    /// </summary>
    /// <returns></returns>
    protected ContentResult CloseFrameDialog()
    {
      var ret = "";
      var builder = new TagBuilder("script");

      builder.MergeAttribute("type", "text/javascript");


      if (Request["ReloadURL"] != null && Request["ReloadID"] != null)
      {
        ret += "parent." + Javascript.RemoteFunc(new RemoteOption
        {
          URL = Request["ReloadURL"],
          Update = Request["ReloadID"]
        });
      }
      builder.InnerHtml = ret + ";parent.Core.dialog.closeBox()";

      return Content(builder.ToString());
    }

    /// <summary>
    /// check if form is post
    /// </summary>
    /// <returns></returns>
    protected Boolean IsRequestPost()
    {
      return Request.RequestType == "POST";
    }

    #endregion

    #region Overriden methods
//    protected override void OnException(ExceptionContext filterContext)
//    {
//      ExceptionHandler exHandler = ExceptionHandler.Handle(filterContext.Exception);

//      if (filterContext.ExceptionHandled)
//      {
//        return;
//      }
//#if DEBUG
//      exHandler.Message += Environment.NewLine + Environment.NewLine + filterContext.Exception.ToString();
//#endif
//      if (Request.IsAjaxRequest())
//      {
//        JsonResult result;
//        result = Json(new { message = exHandler.Message });
//        filterContext.HttpContext.Response.StatusCode = exHandler.HttpErrorCode;
//        filterContext.Result = result;
//      }
//      else
//      {
//        filterContext.Result = View("Error", exHandler);
//      }
//      filterContext.ExceptionHandled = true;
//      filterContext.HttpContext.Response.Clear();
//      filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
//      base.OnException(filterContext);
//    }

    #endregion

    
  }
}
