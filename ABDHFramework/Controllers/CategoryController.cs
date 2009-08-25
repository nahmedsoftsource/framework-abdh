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
        public ActionResult ListCategory(int? pageSize, int? page)
        {
            SearchResult<tblCategory> listAllCategory = new SearchResult<tblCategory>();
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllCategory = Service.GetAllCategory(Common.Constants.DefautPagingSizeForCategory, (page.HasValue ? (int)page : 1), true);
            }
            else
            {
                listAllCategory = Service.GetAllCategory(Common.Constants.DefautPagingSizeForCategory, (page.HasValue ? (int)page : 1), false);
            }

            return View(listAllCategory);
        }
        public ActionResult IndexForProductByCategory(int? pageSize, int? page, Guid? categoryID)
        {
            SearchResult<tblProduct> listAllNews = new SearchResult<tblProduct>();
            if (TempData["CategoryID"] != null)
            {
                categoryID = (Guid)TempData["CategoryID"];
            }
            if (categoryID.HasValue && !categoryID.Value.Equals(Guid.Empty))
            {
                ViewData["CategoryID"] = categoryID;
                listAllNews = Service.GetAllProductByCategory(Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), (Guid)categoryID);
            }

            return View(listAllNews);
        }
        public ActionResult ListAllProductByCategory(int? pageSize, int? page, Guid? categoryID)
        {
            SearchResult<tblProduct> listAllNews = new SearchResult<tblProduct>();
            if (categoryID.HasValue && !categoryID.Value.Equals(Guid.Empty))
            {
                ViewData["CategoryID"] = categoryID;
                listAllNews = Service.GetAllProductByCategory(Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), (Guid)categoryID);
            }

            return View(listAllNews);
        }
        public ActionResult EditCategory(Guid? categoryID)
        {
            if (Request["Delete"] != null)
            {
                if (categoryID.HasValue && !categoryID.Value.Equals(Guid.Empty))
                {
                    Service.DeleteCategory((Guid)categoryID);
                    return RedirectToAction("IndexForProduct");
                }
            }
            if (categoryID.HasValue && !categoryID.Value.Equals(Guid.Empty))
            {
                tblCategory tblCategory = new tblCategory();
                if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                {
                    tblCategory = Service.GetCategoryByID((Guid)categoryID, true);
                }
                else
                {
                    tblCategory = Service.GetCategoryByID((Guid)categoryID, false);
                }

                ViewData["NameVN"] = tblCategory.CategoryNameVN;
                ViewData["NameEN"] = tblCategory.CategoryNameVN;
                ViewData["DescriptionVN"] = tblCategory.DescriptionVN;
                ViewData["DescriptionEN"] = tblCategory.DescriptionEN;
                ViewData["command"] = "upload";
                return View(tblCategory);
            }
            else
            {
                ViewData["AddNews"] = true;
                tblCategory tblCategory = new tblCategory();
                return View(tblCategory);
            }
        }


    }
}
