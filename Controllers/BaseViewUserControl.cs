using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGUYENHIEP.Controllers
{
  public class BaseViewUserControl : System.Web.Mvc.ViewUserControl
  {
    public NGUYENHIEP.Routing.Routing _routing;
    public NGUYENHIEP.Routing.Routing Routing
    {
      get
      {
        if (_routing == null)
        {
          _routing = new NGUYENHIEP.Routing.Routing(Url);
        }
        return _routing;
      }
    }
  }

  public class BaseViewUserControl<T> : System.Web.Mvc.ViewUserControl<T> where T : class
  {
    public NGUYENHIEP.Routing.Routing _routing;
    public NGUYENHIEP.Routing.Routing Routing
    {
      get
      {
        if (_routing == null)
        {
          _routing = new NGUYENHIEP.Routing.Routing(Url);
        }
        return _routing;
      }
    }
  }
}
