using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABDHFramework.Utility;
using ABDHFramework.Lib;

namespace ABDHFramework.Controllers
{
  public class BaseViewPage : System.Web.Mvc.ViewPage
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

  public class BaseViewPage<T> : System.Web.Mvc.ViewPage<T> where T : class
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

    private Helper _helper;
    public Helper Helper
    {
      get
      {
        if (_helper == null)
        {
          _helper = new Helper(Html);
        }
        return _helper;
      }
      set { _helper = value; }
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
}
