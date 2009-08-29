using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABDHFramework.Routing;

namespace ABDHFramework.Routing
{
  public class Product : BaseRoute
  {
    public Product(UrlHelper url)
      : base(url, "Product")
    {

    }

    #region View
    public String UrlForIndexForProduct(Guid? categoryID,int? pageSize, int? page)
    {
      return UrlFor("IndexForProduct", new {CategoryID = categoryID, PageSize = pageSize, Page = page });

    }
    public String UrlForListProduct(Guid? categoryID,int? pageSize, int? page, String sortColunm, String sortOption)
    {
      return UrlFor("ListProduct", new { CategoryID = categoryID, PageSize = pageSize, Page = page, SortColunm = sortColunm, SortOption = sortOption });

    }
    public String UrlForViewProduct(Guid? productID)
    {
      return UrlFor("ViewProduct", new { ProductID = productID});

    }
    public String UrlForViewProduct()
    {
      return UrlFor("ViewProduct");

    }
    public String UrlForQuickSearch()
    {
      return UrlFor("QuickSearch");

    }
    public String UrlForSuggestForField(String field)
    {
      return UrlFor("SuggestForField", new { Field = field});

    }
    
    #endregion
    #region Admin
    public String UrlForAdminProductForIframe(int? page)
    {
        return UrlFor("AdminProductForIframe", new { Page = page });

    }
      
    public String UrlForAdminListProduct(int? page)
    {
      return UrlFor("AdminListProduct", new { Page = page });

    }
    public String UrlForAdminListProduct()
    {
        return UrlFor("AdminListProduct");

    }
    public String UrlForDeleteListProduct()
    {
      return UrlFor("DeleteListProduct");

    }
    public String UrlForDeleteProduct(Guid? id)
    {
      return UrlFor("DeleteProduct", new { Id = id });

    }
    public String UrlForEditProduct(Guid? productID)
    {
      return UrlFor("EditProduct", new { ProductID = productID});

    }
    public String UrlForIframeEditProduct(Guid? productID)
    {
      return UrlFor("IframeEditProduct", new { ProductID = productID });

    }
    
    #endregion
  }
}
