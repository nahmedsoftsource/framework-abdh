using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABDHFramework.Utility;

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

  }
}
