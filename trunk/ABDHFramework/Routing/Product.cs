using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABDHFramework.Routing;

namespace ABDHFramework.Routing
{
  public class Product:BaseRoute
  {
      public Product(UrlHelper url)
      : base(url, "Product")
    {

    }
    
    public String UrlForIndexForProduct()
    {
      return UrlFor("IndexForProduct");
    }
    
    public String UrlForViewProduct()
    {
      return UrlFor("ViewProduct");

    }
    
    public String UrlForListAllProduct()
    {
      return UrlFor("ListAllProduct");
    }
        

  }
}
