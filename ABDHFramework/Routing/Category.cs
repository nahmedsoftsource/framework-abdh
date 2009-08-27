using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABDHFramework.Routing;

namespace ABDHFramework.Routing
{
  public class Category : BaseRoute
  {
    public Category(UrlHelper url)
      : base(url, "Category")
    {

    }

    public String UrlForIndexForProductByCategory(Guid? categoryID)
    {
      return UrlFor("IndexForProductByCategory", new { CategoryID = categoryID });
    }
    public String UrlForListCategoryByLevel()
    {
        return UrlFor("ListCategoryByLevel");
    }
    public String UrlForListAllProductByCategory(int? page, Guid? categoryID)
    {
      return UrlFor("ListAllProductByCategory", new { Page = page, CategoryID = categoryID });

    }

    public String UrlForAdminCategory(int? page)
    {
      return UrlFor("AdminCategory", new { Page = page });

    }
    public String UrlForAdminListCategory(int? page)
    {
      return UrlFor("AdminListCategory", new { Page = page });

    }
    public String UrlForDeleteListCategory()
    {
      return UrlFor("DeleteListCategory");

    }
    public String UrlForDeleteCategory(Guid? id)
    {
      return UrlFor("DeleteCategory", new { Id = id });

    }
    public String UrlForEditCategory(Guid? categoryID)
    {
      return UrlFor("EditCategory", new { CategoryID = categoryID });

    }
    
  }
}
