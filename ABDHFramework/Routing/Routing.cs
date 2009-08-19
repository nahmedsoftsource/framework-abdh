using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoutingNS = ABDHFramework.Routing;

namespace ABDHFramework.Routing
{
  public  class Routing
  {

    public RoutingNS.BaseRoute ForController(String controllerName)
    {
      return new RoutingNS.BaseRoute(_url, controllerName);
    }     
    private  UrlHelper _url;
    public  Routing(UrlHelper url)
    {
      _url = url;
    }
   
   
    //Routing for Demo
    private RoutingNS.Demo _demo = null;
    public RoutingNS.Demo Demo
    {
      get
      {
        if (_demo == null)
        {
          _demo = new RoutingNS.Demo(_url);
        }

        return _demo;
      }
    }
    


  }
}
