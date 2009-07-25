using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NGUYENHIEP.Models;
using NGUYENHIEP.Services;
using NguyenHiep.Data;

namespace NGUYENHIEP.Controllers
{
    [HandleError]
    public class NguyenHiepController : Controller
    {
        NguyenHiepService _nguyenHiepService = NguyenHiepService.Instance;
        public ActionResult Index(int? pageSize,int? page)
        {
            SearchResult<tblNew> listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1));
            return View(listAllNews);
        }
        public ActionResult ViewNews(Guid? newsID)
        {
            if (newsID != null && !newsID.Equals(Guid.Empty))
            {
                tblNew tblnews = _nguyenHiepService.GetNewsByID((Guid)newsID);
                return View(tblnews);
            }
            return new EmptyResult();
        }
        public ActionResult ListAllNews(int? pageSize,int? page)
        {

            SearchResult<tblNew> listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1));
            return View(listAllNews);
        }
    }
}
