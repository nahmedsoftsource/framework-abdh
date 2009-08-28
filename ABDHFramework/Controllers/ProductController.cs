using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ABDHFramework.Models;
using ABDHFramework.Services;
using ABDHFramework.Data;
using ABDHFramework.Common;
using System.IO;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using ABDHFramework.Utility;
using ABDHFramework.Lib;
using ABDHFramework.Lib.Javascripts;

namespace ABDHFramework.Controllers
{
  [HandleError]
  public class ProductController : BaseController
  {
    #region View
    public ActionResult IndexForProduct(Guid? categoryID, int? pageSize, int? page)
    {

      SearchResult<tblProduct> listAllProduct = new SearchResult<tblProduct>();
      ViewData["Type"] = NewsTypes.NormalProduct;
      if (categoryID.HasValue && categoryID.Value != Guid.Empty)
      {
        listAllProduct = Service.GetAllProductByCategory(Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), (Guid)categoryID);
      }
      else
      {
        if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
        {
          listAllProduct = Service.GetAllProduct(Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), Languages.EN, "", "", "");
        }
        else
        {
          listAllProduct = Service.GetAllProduct(Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), Languages.VN, "", "", "");
        }
      }
      return View(listAllProduct);
    }

    public ActionResult ListProduct(Guid? categoryID, int? pageSize, int? page, String sortColunm, String sortOption)
    {
      String criteria = "";
      if (Request["Command"] != null && Request["Command"] == "Search" && Request["ProductName"] != null)
        criteria = Request["ProductName"];
      SearchResult<tblProduct> listAllProduct = new SearchResult<tblProduct>();
      if (categoryID.HasValue && categoryID.Value != Guid.Empty)
      {
        listAllProduct = Service.GetAllProductByCategory(Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), (Guid)categoryID);
      }
      else
      {
        if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
        {
          listAllProduct = Service.GetAllProduct(Common.Constants.DefautPagingSizeForCategory, (page.HasValue ? (int)page : 1), Languages.EN, criteria, sortColunm, sortOption);
        }
        else
        {
          listAllProduct = Service.GetAllProduct(Common.Constants.DefautPagingSizeForCategory, (page.HasValue ? (int)page : 1), Languages.VN, criteria, sortColunm, sortOption);
        }
      }

      return View(listAllProduct);
    }
    public ActionResult ViewProduct(Guid? productID)
    {
      if (productID != null && !productID.Equals(Guid.Empty))
      {
          tblProduct tblproduct = Service.GetProductByID((Guid)productID);
          return View(tblproduct);
      }
      else if (TempData["ProductID"] != null)
      {
       
          tblProduct tblproduct = Service.GetProductByID((Guid)TempData["ProductID"]);
          return View(tblproduct);
        
      }
      tblProduct tblpro = new tblProduct();
      return View(tblpro);
    }
    public ActionResult QuickSearch()
    {
      return View();
    }
    public ActionResult SuggestForField(String field, String q)
    {
      var data = Service.ProductSuggestForField(q, Constants.DefautSizeSuggestion).Select(
        op => new AutoCompleteDataItem
        {
          Html = op.ProductName,
          Text = op.ProductName,
          Data = new
          {
            ProductID = op.ID
          }
        }
          );
      return View(data);
    }
    #endregion
    #region Admin
    public ActionResult EditProduct(Guid? productID)
    {
      List<SelectListItem> categories = new List<SelectListItem>();
      List<tblCategory> listCategory = new List<tblCategory>();
      if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
      {
        listCategory = Service.GetAllCategory(Languages.EN);
      }
      else
      {
        listCategory = Service.GetAllCategory(Languages.VN);
      }
      foreach (tblCategory cat in listCategory)
      {
        categories.Add(new SelectListItem { Text = cat.CategoryName, Value = cat.ID.ToString() });
      }

      ViewData["Categories"] = categories;
      if (productID != null)
      {
        tblProduct tblproduct = new tblProduct();
        
         tblproduct = Service.GetProductByID((Guid)productID);
        if (tblproduct != null && !string.IsNullOrEmpty(tblproduct.Description))
        {
          //ViewData["Description"] = tblproduct.Description;
          ViewData["Description"] = "test choi";
        }

        return View("Admin/EditProduct", tblproduct);
      }
      else
      {

        ViewData["AddProduct"] = true;
        tblProduct tblproduct = new tblProduct();
        return View("Admin/EditProduct", tblproduct);
      }
    }
    
    [ValidateInput(false)]
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult EditProduct(Guid? productID, [Bind(Exclude = "ID")] tblProduct tblproduct)
    {
      #region delete
      if (Request["Delete"] != null)
      {
        if (productID.HasValue && !productID.Equals(Guid.Empty))
        {
          Service.DeleteProduct((Guid)productID);
          return RedirectToAction("IndexForProduct");
        }
      }
      #endregion
      if (tblproduct != null && !string.IsNullOrEmpty(tblproduct.Description))
      {
        ViewData["Description"] = tblproduct.Description;
      }
      if (tblproduct == null)
      {
        tblproduct = new tblProduct();
      }
      List<SelectListItem> categories = new List<SelectListItem>();
      List<tblCategory> listCategory = new List<tblCategory>();
      if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
      {
        tblproduct.Language = Languages.EN;
        listCategory = Service.GetAllCategory(Languages.EN);
      }
      else
      {
        tblproduct.Language = Languages.VN;
        listCategory = Service.GetAllCategory(Languages.VN);
      }

      foreach (tblCategory cat in listCategory)
      {
          categories.Add(new SelectListItem { Text = cat.CategoryName, Value = cat.ID.ToString() });
      }
      ViewData["Categories"] = categories;

      if (String.IsNullOrEmpty(tblproduct.ProductName))
      {
        if (tblproduct.Language.HasValue && tblproduct.Language.Value.Equals(Languages.EN))
        {
          ModelState.AddModelError("ProductName", "Product name field is required");
        }
        else
        {
          ModelState.AddModelError("ProductName", "Cần nhập tên sản phẩm");
        }
      }
      else if (tblproduct.ProductName.Length >= 100)
      {
        if (tblproduct.Language.HasValue && tblproduct.Language.Value.Equals(Languages.EN))
        {
          ModelState.AddModelError("ProductName", "Input no more than 100 characters");
        }
        else
        {
          ModelState.AddModelError("ProductName", "Không nhập quá 100 ký tự");
        }
      }

      if (String.IsNullOrEmpty(tblproduct.Property))
      {
        if (tblproduct.Language.HasValue && tblproduct.Language.Value.Equals(Languages.EN))
        {
          ModelState.AddModelError("Property", "Property field is required");
        }
        else
        {
          ModelState.AddModelError("Property", "Cần mô tả ngắn gọn");
        }

      }
      else if (tblproduct.Property.Length > 250)
      {
        if (tblproduct.Language.HasValue && tblproduct.Language.Value.Equals(Languages.EN))
        {
          ModelState.AddModelError("Property", "Input no more than 250 characters");
        }
        else
        {
          ModelState.AddModelError("Property", "Không nhập quá 250 ký tự");
        }
      }
      if (String.IsNullOrEmpty(tblproduct.Description))
      {
        if (tblproduct.Language.HasValue && tblproduct.Language.Value.Equals(Languages.EN))
        {
          ModelState.AddModelError("Description", "Description field is required");
        }
        else
        {
          ModelState.AddModelError("Description", "Cần nhập chi tiết ");
        }
      }
      else if (tblproduct.Description.Length > 16000)
      {
        if (tblproduct.Language.HasValue && tblproduct.Language.Value.Equals(Languages.EN))
        {
          ModelState.AddModelError("Description", "Input no more than 16000 characters");
        }
        else
        {
          ModelState.AddModelError("Description", "Không nhập quá 16000 ký tự");
        }
      }



      string pathFolder = Server.MapPath(ConfigurationManager.AppSettings["ImagesNews"]);
      string pathFolderThumb = Server.MapPath(ConfigurationManager.AppSettings["ThumbImagesNews"]);
      string pathFolderThumbSmallest = Server.MapPath(ConfigurationManager.AppSettings["ThumbImagesNewsSmallest"]);
      bool flag = false;
      if (!Directory.Exists(pathFolder)) Directory.CreateDirectory(pathFolder);
      if (!Directory.Exists(pathFolderThumb)) Directory.CreateDirectory(pathFolderThumb);
      if (!Directory.Exists(pathFolderThumbSmallest)) Directory.CreateDirectory(pathFolderThumbSmallest);

      foreach (string inputTagName in Request.Files)
      {
        HttpPostedFileBase file = Request.Files[inputTagName];

        if (productID != null && !productID.Value.Equals(Guid.Empty) && ModelState.IsValid)
        {
          tblproduct.ID = (Guid)productID;
          string pathImage;
          string pathImageThumb;
          string pathImageThumbSmallest;
          if (file != null && Utility.File.File.SaveFile(file, out pathImage, out pathImageThumb, out pathImageThumbSmallest, (Guid)productID, pathFolder, Request.PhysicalApplicationPath))
          {
            flag = true;
            tblproduct.Image = pathImageThumb;

          }
          if (tblproduct != null && String.IsNullOrEmpty(tblproduct.Image))
          {
            if (tblproduct.Language.HasValue && tblproduct.Language.Value.Equals(Languages.EN))
            {
              ModelState.AddModelError("Image", "This image is not support or  haven't pick up");
            }
            else
            {
              ModelState.AddModelError("Image", "Định dạng hình ảnh này không trợ giúp hoặc chưa chọn");
            }
          }
          if (ModelState.IsValid)
          {
            Service.UpdateProduct(tblproduct);
            TempData["ProductID"] = productID;
            return RedirectToAction("ViewProduct");
          }
          else
          {
            return View("Admin/EditProduct", tblproduct);
          }
        }
        else if ((productID == null || productID.Value.Equals(Guid.Empty)) && ModelState.IsValid)
        {
          flag = true;
          tblproduct.ID = Guid.NewGuid();
          productID = tblproduct.ID;
          string pathImage;
          string pathImageThumb;
          string pathImageThumbSmallest;
          if (file != null && Utility.File.File.SaveFile(file, out pathImage, out pathImageThumb, out pathImageThumbSmallest, (Guid)productID, pathFolder, Request.PhysicalApplicationPath))
          {
            tblproduct.Image = pathImageThumb;

          }
          if (tblproduct != null && String.IsNullOrEmpty(tblproduct.Image))
          {
            if (tblproduct.Language.HasValue && tblproduct.Language.Value.Equals(Languages.EN))
            {
              ModelState.AddModelError("Image", "This image is not support or  haven't pick up");
            }
            else
            {
              ModelState.AddModelError("Image", "Định dạng hình ảnh này không trợ giúp hoặc chưa chọn");
            }
          }
          if (ModelState.IsValid)
          {
            Service.InsertProduct(tblproduct);
            return RedirectToAction("IndexForProduct");
          }
          else
          {
            tblproduct.ID = Guid.Empty;
            return View("Admin/EditProduct", tblproduct);
          }

        }

      }
      ViewData["Description"] = (String.IsNullOrEmpty(tblproduct.Description) ? "" : tblproduct.Description);
      ViewData["Categories"] = categories;

      return View("Admin/EditProduct", tblproduct);
    }
    public ActionResult IframeEditProduct(Guid? productID)
    {
      var url = Url.Content("~/Product/EditProduct") + "?productID=" + productID.ToString();
      return Content(String.Format("<iframe width=\"100%\" scrolling=\"no\" height=\"1200px\" frameborder=\"0\" src=\"{0}\" />", Routing.Product.UrlForEditProduct(productID)));
    }
    public ActionResult AdminProduct(int? page)
    {
      string sortColumn = !String.IsNullOrEmpty(Request["sortColumn"]) ? Request["sortColumn"] : "ProductName";
      string sortOption = !String.IsNullOrEmpty(Request["SortOption"]) ? Request["SortOption"] : SortOption.Asc.ToString();
      SearchResult<tblProduct> listAllProduct = new SearchResult<tblProduct>();
      if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
      {
        listAllProduct = Service.GetAllProduct(Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? page.Value : 1), Languages.EN, "", sortColumn, sortOption);
      }
      else
      {
        listAllProduct = Service.GetAllProduct(Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? page.Value : 1), Languages.VN, "", sortColumn, sortOption);
      }
      ViewData["Page"] = (page.HasValue ? page.Value : 1);
      return View("Admin/AdminProduct", listAllProduct);
    }
    public ActionResult AdminListProduct(int? page)
    {
      string sortColumn = !String.IsNullOrEmpty(Request["sortColumn"]) ? Request["sortColumn"] : "ProductName";
      string sortOption = !String.IsNullOrEmpty(Request["SortOption"]) ? Request["SortOption"] : SortOption.Asc.ToString();
      SearchResult<tblProduct> listAllProduct = new SearchResult<tblProduct>();
      if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
      {
        listAllProduct = Service.GetAllProduct(Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? page.Value : 1), Languages.EN, "", sortColumn, sortOption);
      }
      else
      {
        listAllProduct = Service.GetAllProduct(Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? page.Value : 1), Languages.VN, "", sortColumn, sortOption);
      }
      ViewData["Page"] = (page.HasValue ? page.Value : 1);
      return View("Admin/AdminListProduct", listAllProduct);
    }
    public ActionResult DeleteListProduct(String listIDToDelete)
    {
      if (listIDToDelete != null)
      {
        string[] listID = listIDToDelete.Split('|');
        foreach (string id in listID)
        {
          if (Tool.IsGuid(id))
          {
            Guid guid = new Guid(id);
            Service.DeleteProduct(guid);
          }
        }
      }
      return RedirectToAction("AdminListProduct");
    }
    public ActionResult DeleteProduct(Guid? Id)
    {
      if (!Id.HasValue && Request["Id"] != null && Tool.IsGuid(Request["Id"] as string))
      {
        Id = new Guid(Request["Id"] as string);
      }
      if (Id.HasValue && Id.Value != Guid.Empty)
      {
        Service.DeleteProduct(Id.Value);
      }
      return RedirectToAction("AdminListProduct");
    }
    #endregion
  }
}
