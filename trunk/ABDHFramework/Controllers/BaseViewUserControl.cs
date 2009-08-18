using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABDHFramework.Lib;

namespace ABDHFramework.Controllers
{
  public class BaseViewUserControl : System.Web.Mvc.ViewUserControl
  {
    public ABDHFramework.Routing.Routing _routing;
    public ABDHFramework.Routing.Routing Routing
    {
      get
      {
        if (_routing == null)
        {
          _routing = new ABDHFramework.Routing.Routing(Url);
        }
        return _routing;
      }
    }
    private FluentHtmlHelper _fluentHtml;
    public FluentHtmlHelper FluentHtml
    {
      get
      {
        if (_fluentHtml == null)
        {
          _fluentHtml = new FluentHtmlHelper(ViewContext, this);
        }
        return _fluentHtml;
      }
    }
  }

  public class BaseViewUserControl<T> : System.Web.Mvc.ViewUserControl<T> where T : class
  {
    private FluentHtmlHelper _fluentHtml;
    public FluentHtmlHelper FluentHtml
    {
      get
      {
        if (_fluentHtml == null)
        {
          _fluentHtml = new FluentHtmlHelper(ViewContext, this);
        }
        return _fluentHtml;
      }
    }
    public ABDHFramework.Routing.Routing _routing;
    public ABDHFramework.Routing.Routing Routing
    {
      get
      {
        if (_routing == null)
        {
          _routing = new ABDHFramework.Routing.Routing(Url);
        }
        return _routing;
      }
    }
  }
}
