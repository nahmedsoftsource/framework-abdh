using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using NGUYENHIEP.Models;
using NGUYENHIEP.Services;
using NguyenHiep.Data;
using NguyenHiep.Common;
using System.IO;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;

namespace NGUYENHIEP.Controllers
{
    [HandleError]
    public class ProductController : BaseController
    {
        #region
        #endregion
        public ActionResult IndexForProduct(int? pageSize, int? page)
        {
            SearchResult<tblProduct> listAllNews = new SearchResult<tblProduct>();
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.NormalProduct;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = Service.GetAllProduct(NguyenHiep.Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), true);
            }
            else
            {
                listAllNews = Service.GetAllProduct(NguyenHiep.Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), false);
            }
            return View(listAllNews);
        }
        public ActionResult ListAllProduct(int? pageSize, int? page)
        {
            SearchResult<tblProduct> listAllNews = new SearchResult<tblProduct>();
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = Service.GetAllProduct(NguyenHiep.Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), true);
            }
            else
            {
                listAllNews = Service.GetAllProduct(NguyenHiep.Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), false);
            }
            return View(listAllNews);
        }
        
    }
}
