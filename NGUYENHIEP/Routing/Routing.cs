using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoutingNS = NGUYENHIEP.Routing;

namespace NGUYENHIEP.Routing
{
  public class Routing
  {

    public RoutingNS.BaseRoute ForController(String controllerName)
    {
      return new RoutingNS.BaseRoute(_url, controllerName);
    }     
    private UrlHelper _url;
    public Routing(UrlHelper url)
    {
      _url = url;
    }
    /* Routing for NguyenHiep Controler*/
    private RoutingNS.NguyenHiep _nguyenHiep;
    public RoutingNS.NguyenHiep NguyenHiep
    {
      get
      {
        if (_nguyenHiep == null)
        {
          _nguyenHiep = new RoutingNS.NguyenHiep(_url);
        }

        return _nguyenHiep;
      }
    }

    


  }
}
