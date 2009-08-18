using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABDHFramework.Routing;

namespace ABDHFramework.Routing
{
  public class Demo:BaseRoute
  {
    public Demo(UrlHelper url)
      : base(url, "Demo")
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
    public String UrlForSearchAll()
    {
      return UrlFor("ListResult", new { Command = "SearchAll" });
    }
    public String UrlForListResutl()
    {
      return UrlFor("ListResult");
    }  
  }
}
