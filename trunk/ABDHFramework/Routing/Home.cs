using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABDHFramework.Routing;

namespace ABDHFramework.Routing
{
  public class Home:BaseRoute
  {
      public Home(UrlHelper url)
          : base(url, "Home")
    {

    }
    
    public String UrlForIndex()
    {
      return UrlFor("Index");
    }
    
    
  }
}
