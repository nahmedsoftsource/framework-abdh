using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NGUYENHIEP.Routing
{
  public class NguyenHiep:BaseRoute
  {
    public NguyenHiep(UrlHelper url)
      : base(url, "NguyenHiep")
    {

    }
    public String UrlForIndexForNews()
    {
      return UrlFor("ForIndexForNews");
    }
    public String UrlForIndexForProduct()
    {
      return UrlFor("IndexForProduct");
    }
    public String UrlForIndexForIndex()
    {
      return UrlFor("Index");
    }
    public String UrlForIndexForContruction()
    {
      return UrlFor("IndexForContruction");
    }
    public String UrlForViewNews(Guid? newsID)
    {
      return UrlFor("ViewNews", new { NewsID = newsID });
    }
    public String UrlForViewProduct()
    {
      return UrlFor("ViewProduct");

    }
    public String UrlForListAllNews()
    {
      return UrlFor("ListAllNews");
    }
    public String UrlForListAllContruction()
    {
      return UrlFor("ListAllContruction");
    }
    public String UrlForListAllProduct()
    {
      return UrlFor("ListAllProduct");
    }
    public String UrlForListAllProduct(int? pageSize, int? page)
    {
        return UrlFor("ListAllProduct", new { pageSize = pageSize, page = page });
    }
    public String UrlForListCategory()
    {
      return UrlFor("ListCategory");
    }
    public String UrlForEditNews(Guid? newsID)
    {
      return UrlFor("EditNews", new { NewsID = newsID });
    }
    public String UrlForEditCategory()
    {
      return UrlFor("EditCategory");
    }
    public String UrlForEditProduct()
    {
      return UrlFor("EditProduct");
    }
    

  }
}
