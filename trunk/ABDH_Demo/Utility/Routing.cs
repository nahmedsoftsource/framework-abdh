using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RoutingNS = ABDH_Demo.Utility.Routing;
using System.Web.Mvc;
namespace ABDH_Demo.Utility
{
  public class Routing
  {
    private UrlHelper _url;
    public Routing(UrlHelper url)
    {
      _url = url;
    }
    //private RoutingNS.OrderLab _orderLab;
    //public RoutingNS.OrderLab OrderLab
    //{
    //  get
    //  {
    //    if (_orderLab == null)
    //    {
    //      _orderLab = new RoutingNS.OrderLab(_url);
    //    }

    //    return _orderLab;
    //  }
    //}

    
  }
}
