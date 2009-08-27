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
          listAllProduct = Service.GetAllProduct(Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), true, "", "", "");
        }
        else
        {
          listAllProduct = Service.GetAllProduct(Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), false, "", "", "");
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
          listAllProduct = Service.GetAllProduct(Common.Constants.DefautPagingSizeForCategory, (page.HasValue ? (int)page : 1), true, criteria, sortColunm, sortOption);
        }
        else
        {
          listAllProduct = Service.GetAllProduct(Common.Constants.DefautPagingSizeForCategory, (page.HasValue ? (int)page : 1), false, criteria, sortColunm, sortOption);
        }
      }

      return View(listAllProduct);
    }
    public ActionResult ViewProduct(Guid? productID, byte? type)
    {
      ViewData["Type"] = type;
      if (productID != null && !productID.Equals(Guid.Empty))
      {
        if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
        {
          tblProduct tblproduct = Service.GetProductByID((Guid)productID, true);
          return View(tblproduct);
        }
        else
        {
          tblProduct tblproduct = Service.GetProductByID((Guid)productID, false);
          return View(tblproduct);
        }

      }
      else if (TempData["ProductID"] != null)
      {
        if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
        {
          tblProduct tblproduct = Service.GetProductByID((Guid)TempData["ProductID"], true);
          return View(tblproduct);
        }
        else
        {
          tblProduct tblproduct = Service.GetProductByID((Guid)TempData["ProductID"], false);
          return View(tblproduct);
        }
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
    public ActionResult EditProduct(Guid? productID, byte? type)
    {
      ViewData["Type"] = type;
      byte tmpType = NewsTypes.NormalProduct;
      if (type.HasValue)
      {
        tmpType = (byte)type;
      }
      #region delete
      if (Request["Delete"] != null)
      {
        if (productID.HasValue && !productID.Equals(Guid.Empty))
        {
          Service.DeleteProduct((Guid)productID);

          if (tmpType == NewsTypes.NormalProduct)
          {
            return RedirectToAction("IndexForProduct");
          }
          else if (tmpType == NewsTypes.PromotionNew)
          {
            return RedirectToAction("IndexForPromotionNews");
          }
          else
          {
            return RedirectToAction("IndexForProduct");
          }
        }
      }
      #endregion
      List<SelectListItem> categories = new List<SelectListItem>();
      List<tblCategory> listCategory = new List<tblCategory>();
      if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
      {
        listCategory = Service.GetAllCategory(true);
      }
      else
      {
        listCategory = Service.GetAllCategory(false);
      }
      int counter = 0;
      foreach (tblCategory cat in listCategory)
      {
        if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
        {
          categories.Add(new SelectListItem { Text = cat.CategoryName, Value = cat.ID.ToString() });
        }
        else
        {
          categories.Add(new SelectListItem { Text = cat.CategoryName, Value = cat.ID.ToString() });
        }

      }
      List<SelectListItem> storeStatusVN = new List<SelectListItem>();
      storeStatusVN.Add((new SelectListItem { Text = "Còn hàng", Value = StoreStatuses.Exhausted.ToString() }));
      storeStatusVN.Add((new SelectListItem { Text = "Hết hàng", Value = StoreStatuses.NotExhausted.ToString() }));
      List<SelectListItem> storeStatusEN = new List<SelectListItem>();
      storeStatusEN.Add((new SelectListItem { Text = "Available", Value = StoreStatuses.Exhausted.ToString() }));
      storeStatusEN.Add((new SelectListItem { Text = "Not Available", Value = StoreStatuses.NotExhausted.ToString() }));


      List<SelectListItem> promotionVN = new List<SelectListItem>();
      promotionVN.Add((new SelectListItem { Text = "Không có khuyến mãi", Value = Promoted.NotHas.ToString() }));
      promotionVN.Add((new SelectListItem { Text = "Có khuyến mãi", Value = Promoted.Has.ToString() }));


      List<SelectListItem> promotionEN = new List<SelectListItem>();
      promotionEN.Add((new SelectListItem { Text = "Not Promoted", Value = Promoted.NotHas.ToString() }));
      promotionEN.Add((new SelectListItem { Text = "Promoted", Value = Promoted.Has.ToString() }));

      if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
      {
        ViewData["StoreStatus"] = storeStatusEN;

        ViewData["Promotion"] = promotionEN;
      }
      else
      {
        ViewData["Promotion"] = promotionVN;
        ViewData["StoreStatus"] = storeStatusVN;
      }


      ViewData["Categories"] = categories;

      if (productID != null)
      {
        tblProduct tblproduct = new tblProduct();
        if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
        {
          tblproduct = Service.GetProductByID((Guid)productID, true);
        }
        else
        {
          tblproduct = Service.GetProductByID((Guid)productID, false);
        }
        if (tblproduct != null && !string.IsNullOrEmpty(tblproduct.Description))
        {
          ViewData["Description"] = tblproduct.Description;
        }

        return View("Admin/EditProduct",tblproduct);
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
      if (tblproduct != null && !string.IsNullOrEmpty(tblproduct.Description))
      {
        ViewData["Description"] = tblproduct.Description;
      }

      List<SelectListItem> categories = new List<SelectListItem>();
      List<tblCategory> listCategory = new List<tblCategory>();
      if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
      {
        listCategory = Service.GetAllCategory(true);
      }
      else
      {
        listCategory = Service.GetAllCategory(false);
      }

      List<SelectListItem> storeStatusVN = new List<SelectListItem>();
      List<SelectListItem> storeStatusEN = new List<SelectListItem>();
      List<SelectListItem> promotionVN = new List<SelectListItem>();
      List<SelectListItem> promotionEN = new List<SelectListItem>();
      if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
      {

        if (String.IsNullOrEmpty(tblproduct.ProductName))
        {
          ModelState.AddModelError("ProductName", "Product name field is required");
        }
        else if (tblproduct.ProductName.Length >= 100)
        {
          ModelState.AddModelError("ProductName", "Input no more than 100 characters");
        }
        
        if (String.IsNullOrEmpty(tblproduct.Property))
        {
          ModelState.AddModelError("Property", "Property field is required");
        }
        else if (tblproduct.Property.Length > 250)
        {
          ModelState.AddModelError("Property", "Input no more than 250 characters");
        }
        if (String.IsNullOrEmpty(tblproduct.Description))
        {
          ModelState.AddModelError("Description", "Description field is required");
        }
        else if (tblproduct.Description.Length > 16000)
        {
          ModelState.AddModelError("Description", "Input no more than 16000 characters");
        }


      }
      else
      {
        if (String.IsNullOrEmpty(tblproduct.ProductName))
        {
          ModelState.AddModelError("ProductName", "Cần nhập tên sản phẩm");
        }
        else if (tblproduct.ProductName.Length >= 100)
        {
          ModelState.AddModelError("ProductName", "Không nhập quá 100 ký tự");
        }
        
        if (String.IsNullOrEmpty(tblproduct.Property))
        {
          ModelState.AddModelError("Property", "Cần mô tả ngắn gọn");
        }
        else if (tblproduct.Property.Length > 250)
        {
          ModelState.AddModelError("Property", "Không nhập quá 250 ký tự");
        }
        if (String.IsNullOrEmpty(tblproduct.Description))
        {
          ModelState.AddModelError("Description", "Cần nhập chi tiết ");
        }
        else if (tblproduct.Description.Length > 16000)
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
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
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
            foreach (tblCategory cat in listCategory)
            {
              if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
              {
                categories.Add(new SelectListItem { Text = cat.CategoryName, Value = cat.ID.ToString() });
              }
              else
              {
                categories.Add(new SelectListItem { Text = cat.CategoryName, Value = cat.ID.ToString() });
              }

            }
            storeStatusVN.Add((new SelectListItem { Text = "Còn hàng", Value = StoreStatuses.Exhausted.ToString() }));
            storeStatusVN.Add((new SelectListItem { Text = "Hết hàng", Value = StoreStatuses.NotExhausted.ToString() }));
            storeStatusEN.Add((new SelectListItem { Text = "Available", Value = StoreStatuses.Exhausted.ToString() }));
            storeStatusEN.Add((new SelectListItem { Text = "Not Available", Value = StoreStatuses.NotExhausted.ToString() }));

            promotionVN.Add((new SelectListItem { Text = "Không có khuyến mãi", Value = Promoted.NotHas.ToString() }));
            promotionVN.Add((new SelectListItem { Text = "Có khuyến mãi", Value = Promoted.Has.ToString() }));


            promotionEN.Add((new SelectListItem { Text = "NotPromoted", Value = Promoted.NotHas.ToString() }));
            promotionEN.Add((new SelectListItem { Text = "Promoted", Value = Promoted.Has.ToString() }));

            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
              ViewData["StoreStatus"] = storeStatusEN;

              ViewData["Promotion"] = promotionEN;
            }
            else
            {
              ViewData["Promotion"] = promotionVN;
              ViewData["StoreStatus"] = storeStatusVN;
            }


            ViewData["Categories"] = categories;
            if (productID == null)
            {
              ViewData["AddNews"] = true;
            }
            return View(tblproduct);
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
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
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

            foreach (tblCategory cat in listCategory)
            {
              if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
              {
                categories.Add(new SelectListItem { Text = cat.CategoryName, Value = cat.ID.ToString() });
              }
              else
              {
                categories.Add(new SelectListItem { Text = cat.CategoryName, Value = cat.ID.ToString() });
              }
            }
            storeStatusVN.Add((new SelectListItem { Text = "Còn hàng", Value = StoreStatuses.Exhausted.ToString() }));
            storeStatusVN.Add((new SelectListItem { Text = "Hết hàng", Value = StoreStatuses.NotExhausted.ToString() }));
            storeStatusEN.Add((new SelectListItem { Text = "Available", Value = StoreStatuses.Exhausted.ToString() }));
            storeStatusEN.Add((new SelectListItem { Text = "Not Available", Value = StoreStatuses.NotExhausted.ToString() }));

            promotionVN.Add((new SelectListItem { Text = "Không có khuyến mãi", Value = Promoted.NotHas.ToString() }));
            promotionVN.Add((new SelectListItem { Text = "Có khuyến mãi", Value = Promoted.Has.ToString() }));


            promotionEN.Add((new SelectListItem { Text = "Not promoted", Value = Promoted.NotHas.ToString() }));
            promotionEN.Add((new SelectListItem { Text = "Promoted", Value = Promoted.Has.ToString() }));
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
              ViewData["StoreStatus"] = storeStatusEN;

              ViewData["Promotion"] = promotionEN;
            }
            else
            {
              ViewData["Promotion"] = promotionVN;
              ViewData["StoreStatus"] = storeStatusVN;
            }


            ViewData["Categories"] = categories;
            if (productID == null)
            {
              ViewData["AddNews"] = true;
            }
            return View(tblproduct);
          }


        }

      }



      foreach (tblCategory cat in listCategory)
      {
        if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
        {
          categories.Add(new SelectListItem { Text = cat.CategoryName, Value = cat.ID.ToString() });
        }
        else
        {
          categories.Add(new SelectListItem { Text = cat.CategoryName, Value = cat.ID.ToString() });
        }
      }

      storeStatusVN.Add((new SelectListItem { Text = "Còn hàng", Value = StoreStatuses.Exhausted.ToString() }));
      storeStatusVN.Add((new SelectListItem { Text = "Hết hàng", Value = StoreStatuses.NotExhausted.ToString() }));

      storeStatusEN.Add((new SelectListItem { Text = "Available", Value = StoreStatuses.Exhausted.ToString() }));
      storeStatusEN.Add((new SelectListItem { Text = "Not Available", Value = StoreStatuses.NotExhausted.ToString() }));


      promotionVN.Add((new SelectListItem { Text = "Không có khuyến mãi", Value = Promoted.NotHas.ToString() }));
      promotionVN.Add((new SelectListItem { Text = "Có khuyến mãi", Value = Promoted.Has.ToString() }));



      promotionEN.Add((new SelectListItem { Text = "Not Promoted", Value = Promoted.NotHas.ToString() }));
      promotionEN.Add((new SelectListItem { Text = "Promoted", Value = Promoted.Has.ToString() }));
      if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
      {
        ViewData["StoreStatus"] = storeStatusEN;

        ViewData["Promotion"] = promotionEN;
      }
      else
      {
        ViewData["Promotion"] = promotionVN;
        ViewData["StoreStatus"] = storeStatusVN;
      }


      ViewData["Categories"] = categories;
      if (productID == null)
      {
        ViewData["AddNews"] = true;
      }
      return View(tblproduct);
    }
    public ActionResult AdminProduct(int? page)
    {
      string sortColumn = !String.IsNullOrEmpty(Request["sortColumn"]) ? Request["sortColumn"] : "ProductName";
      string sortOption = !String.IsNullOrEmpty(Request["SortOption"]) ? Request["SortOption"] : SortOption.Asc.ToString();
      SearchResult<tblProduct> listAllProduct = new SearchResult<tblProduct>();
      if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
      {
        listAllProduct = Service.GetAllProduct(Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? page.Value : 1), true, "", sortColumn, sortOption);
      }
      else
      {
        listAllProduct = Service.GetAllProduct(Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? page.Value : 1), false, "", sortColumn, sortOption);
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
        listAllProduct = Service.GetAllProduct(Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? page.Value : 1), true, "", sortColumn, sortOption);
      }
      else
      {
        listAllProduct = Service.GetAllProduct(Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? page.Value : 1), false, "", sortColumn, sortOption);
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
