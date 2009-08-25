using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABDHFramework.Routing;

namespace ABDHFramework.Routing
{
  public class Category:BaseRoute
  {
      public Category(UrlHelper url)
          : base(url, "Category")
    {

    }

      public String UrlForIndexForProductByCategory(Guid? categoryID)
    {
        return UrlFor("IndexForProductByCategory",new  {CategoryID = categoryID });
    }

      public String UrlForListAllProductByCategory(int? page, Guid? categoryID)
    {
        return UrlFor("ListAllProductByCategory", new  {Page = page,CategoryID = categoryID });

    }
    
    
  }
}
