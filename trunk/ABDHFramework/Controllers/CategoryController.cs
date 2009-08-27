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

namespace ABDHFramework.Controllers
{
    [HandleError]
    public class CategoryController : BaseController
    {
        #region View
        public ActionResult ListCategory(int? pageSize, int? page, String sortColunm, String sortOption)
        {
            SearchResult<tblCategory> listAllCategory = new SearchResult<tblCategory>();
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
              listAllCategory = Service.GetAllCategory(Common.Constants.DefautPagingSizeForCategory, (page.HasValue ? (int)page : 1), true,"", sortColunm, sortOption);
            }
            else
            {
              listAllCategory = Service.GetAllCategory(Common.Constants.DefautPagingSizeForCategory, (page.HasValue ? (int)page : 1), false,"", sortColunm, sortOption);
            }

            return View(listAllCategory);
        }
        public ActionResult ListCategoryByLevel(byte? level)
        {
            
            List<tblCategory> listAllCategory = new List<tblCategory>();
            List<SelectListItem> listCategory = new List<SelectListItem>();
            if (level.HasValue && level.Value > 1)
            {
                level--;
                if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                {
                    listAllCategory = Service.GetAllCategory(true, (byte)level);
                }
                else
                {
                    listAllCategory = Service.GetAllCategory(false, (byte)level);
                }
                
                foreach (tblCategory category in listAllCategory)
                {
                    listCategory.Add(new SelectListItem { Text = category.CategoryName, Value = category.ID.ToString() });
                }
            }
            ViewData["ListCategory"] = listCategory;
            return View("Admin/ListCategoryByLevel");
        }
        #endregion
        #region Admin
        public ActionResult EditCategory(Guid? categoryID)
        {
            List<SelectListItem> listLevelCategory = new List<SelectListItem>();
            listLevelCategory.Add(new SelectListItem { Text = "Mức 1", Value = "1" });
            listLevelCategory.Add(new SelectListItem { Text = "Mức 2", Value = "2" });
            //listLevelCategory.Add(new SelectListItem { Text = "Mức 3", Value = "3" });
            ViewData["ListLevelCategory"] = listLevelCategory;
            if (categoryID.HasValue && !categoryID.Value.Equals(Guid.Empty))
            {
                tblCategory tblCategory = new tblCategory();
                
                tblCategory = Service.GetCategoryByID((Guid)categoryID);
                return View("Admin/EditCategory", tblCategory);
            }
            else
            {
                tblCategory tblCategory = new tblCategory();
                return View("Admin/EditCategory", tblCategory);
            }
        }
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditCategory(Guid? categoryID, [Bind(Exclude = "ID")] tblCategory tblcategory)
        {
          if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
          {
            if (tblcategory != null && String.IsNullOrEmpty(tblcategory.CategoryName))
            {
              ModelState.AddModelError("CategoryName", "Category name is required");
            }
            else if (tblcategory != null && tblcategory.CategoryName.Length >= 100)
            {
              ModelState.AddModelError("CategoryName", "Input no more than 100 characters");
            }
            if (tblcategory != null && !String.IsNullOrEmpty(tblcategory.Description) && tblcategory.Description.Length >= 250)
            {
              ModelState.AddModelError("CategoryName", "Input no more than 250 characters");
            }
          }
          else
          {
            if (tblcategory != null && String.IsNullOrEmpty(tblcategory.CategoryName))
            {
              ModelState.AddModelError("CategoryName", "Cần nhập tên loại sản phẩm");
            }
            else if (tblcategory != null && tblcategory.CategoryName.Length >= 100)
            {
              ModelState.AddModelError("CategoryName", "Không nhập quá 100 ký tự");
            }
            if (tblcategory != null && !String.IsNullOrEmpty(tblcategory.Description) && tblcategory.Description.Length >= 250)
            {
              ModelState.AddModelError("Description", "Không nhập quá 250 ký tự");
            }
          }
          if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
          {
              tblcategory.Language = Languages.EN;
          }
          else 
          {
              tblcategory.Language = Languages.VN;
          }
          if (categoryID.HasValue && !categoryID.Value.Equals(Guid.Empty) && ModelState.IsValid)
          {
            tblcategory.ID = (Guid)categoryID;
            Service.UpdateCategory(tblcategory);
            return RedirectToAction("AdminListCategory");
          }
          else if ((!categoryID.HasValue || categoryID.Value.Equals(Guid.Empty)) && ModelState.IsValid)
          {
            tblcategory.ID = Guid.NewGuid();
            categoryID = tblcategory.ID;

            Service.InsertCategory(tblcategory);
            //todo: view one category
            return RedirectToAction("AdminListCategory");
          }
          List<SelectListItem> listLevelCategory = new List<SelectListItem>();
          listLevelCategory.Add(new SelectListItem { Text = "Mức 1", Value = "1" });
          listLevelCategory.Add(new SelectListItem { Text = "Mức 2", Value = "2" });
          //listLevelCategory.Add(new SelectListItem { Text = "Mức 3", Value = "3" });
          ViewData["ListLevelCategory"] = listLevelCategory;
          
          return View("Admin/EditCategory", tblcategory);
        }
        public ActionResult AdminCategory(int? page)
        {
          string sortColumn = !String.IsNullOrEmpty(Request["sortColumn"]) ? Request["sortColumn"] : "CategoryName";
          string sortOption = !String.IsNullOrEmpty(Request["SortOption"]) ? Request["SortOption"] : SortOption.Asc.ToString();
            SearchResult<tblCategory> listAllCategory = new SearchResult<tblCategory>();
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
              listAllCategory = Service.GetAllCategory(Common.Constants.DefautPagingSizeForCategory, (page.HasValue ? page.Value : 1), true, "", sortColumn, sortOption);
            }
            else
            {
              listAllCategory = Service.GetAllCategory(Common.Constants.DefautPagingSizeForCategory, (page.HasValue ? page.Value : 1), false, "", sortColumn, sortOption);
            }
            ViewData["Page"] = (page.HasValue ? page.Value : 1);
            return View("Admin/AdminCategory",listAllCategory);
        }
        public ActionResult AdminListCategory(int? page)
        {
          string sortColumn = !String.IsNullOrEmpty(Request["sortColumn"]) ? Request["sortColumn"] : "CategoryName";
          string sortOption = !String.IsNullOrEmpty(Request["SortOption"]) ? Request["SortOption"] : SortOption.Asc.ToString();
          SearchResult<tblCategory> listAllCategory = new SearchResult<tblCategory>();
          if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
          {
            listAllCategory = Service.GetAllCategory(Common.Constants.DefautPagingSizeForCategory, (page.HasValue ? page.Value : 1), true, "", sortColumn, sortOption);
          }
          else
          {
            listAllCategory = Service.GetAllCategory(Common.Constants.DefautPagingSizeForCategory, (page.HasValue ? page.Value : 1), false, "", sortColumn, sortOption);
          }
          ViewData["Page"] = (page.HasValue ? page.Value : 1);
          return View("Admin/AdminListCategory", listAllCategory);
        }
        public ActionResult DeleteListCategory(String listIDToDelete)
        {
          if (listIDToDelete != null)
          {
            string[] listID = listIDToDelete.Split('|');
            foreach (string id in listID)
            {
              if (Tool.IsGuid(id))
              {
                Guid guid = new Guid(id);
                Service.DeleteCategory(guid);
              }
            }
          }
          return RedirectToAction("AdminListCategory");
        }
        public ActionResult DeleteCategory(Guid? Id)
        {
          if (!Id.HasValue && Request["Id"] != null && Tool.IsGuid(Request["Id"] as string))
          {
            Id = new Guid(Request["Id"] as string);
          }
          if (Id.HasValue && Id.Value != Guid.Empty)
          {
            Service.DeleteCategory(Id.Value);
          }
          return RedirectToAction("AdminListCategory");
        }
        #endregion
    }
}
