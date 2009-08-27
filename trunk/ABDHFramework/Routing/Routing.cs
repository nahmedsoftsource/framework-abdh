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

    //Routing for Home
    private RoutingNS.Home _home = null;
    public RoutingNS.Home Home
    {
        get
        {
            if (_home == null)
            {
                _home = new RoutingNS.Home(_url);
            }

            return _home;
        }
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
    //Routing for Category
    private RoutingNS.Category _category = null;
    public RoutingNS.Category Category
    {
        get
        {
            if (_category == null)
            {
                _category = new RoutingNS.Category(_url);
            }

            return _category;
        }
    }

    //Routing for Product
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
