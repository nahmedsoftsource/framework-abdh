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
        public ActionResult Index(int? pageSize, int? page)
        {
            SearchResult<tblNew> listAllNews = new SearchResult<tblNew>();
            
            listAllNews = Service.SearchNews(ABDHFramework.Common.Constants.DefautPagingSizeForNews, (page.HasValue ? (int)page : 1), "","");
            
            return View(listAllNews);
        }
       
        public ActionResult ListResult(int? page, String sortColunm, String sortOption)
        {
          SearchResult<tblNew> listAllNews = new SearchResult<tblNew>();
          listAllNews = Service.SearchNews(ABDHFramework.Common.Constants.DefautPagingSizeForNews, (page.HasValue ? (int)page : 1),sortColunm,sortOption);
          return View(listAllNews);
        }
       
    }
}
