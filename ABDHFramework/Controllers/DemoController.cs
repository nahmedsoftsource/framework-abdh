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
  public class DemoController : BaseController
    {
        #region
        #endregion
        public ActionResult IndexForProduct(int? pageSize, int? page)
        {
            SearchResult<tblProduct> listAllNews = new SearchResult<tblProduct>();
            ViewData["Type"] = ABDHFramework.Common.NewsTypes.NormalProduct;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = Service.GetAllProduct(ABDHFramework.Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), true);
            }
            else
            {
                listAllNews = Service.GetAllProduct(ABDHFramework.Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), false);
            }
            return View(listAllNews);
        }
        public ActionResult ListAllProduct(int? pageSize, int? page)
        {
            SearchResult<tblProduct> listAllNews = new SearchResult<tblProduct>();
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = Service.GetAllProduct(ABDHFramework.Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), true);
            }
            else
            {
                listAllNews = Service.GetAllProduct(ABDHFramework.Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), false);
            }
            return View(listAllNews);
        }
        public ActionResult ListResult(int? page)
        {
          SearchResult<tblProduct> listAllNews = new SearchResult<tblProduct>();
          listAllNews = Service.GetAllProduct(ABDHFramework.Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), false);
          return View(listAllNews);
        }
    }
}
