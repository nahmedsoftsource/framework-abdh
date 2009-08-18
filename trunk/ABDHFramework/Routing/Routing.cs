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
   
    /* Routing for Product Controler*/
    private RoutingNS.Product _product = null;
    public RoutingNS.Product Product
    {
        get
        {
            if (_product == null)
            {
                _product = new RoutingNS.Product(_url);
            }

            return _product;
        }
    }

    


  }
}
