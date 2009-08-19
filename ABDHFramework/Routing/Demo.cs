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
      return UrlFor("ListResult");
    }
    public String UrlForListResutl()
    {
      return UrlFor("ListResult");
    }
    public String UrlForNewProduct(Guid? id)
    {
      return UrlFor("NewProduct", new { ID = id });
    }
    public String UrlForListAllNews()
    {
      return UrlFor("ListAllNews");
    }
    public String UrlForAddNews(Guid? id)
    {
      return UrlFor("AddNews", new { ID = id });
    }
  }
}
