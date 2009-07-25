using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NGUYENHIEP.Models;
using NGUYENHIEP.Services;
using NguyenHiep.Data;
using NguyenHiep.Common;

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
            else if(TempData["NewsID"] != null)
            {
                tblNew tblnews = _nguyenHiepService.GetNewsByID((Guid)TempData["NewsID"]);
                return View(tblnews);
            }
            return new EmptyResult();
        }
        public ActionResult ListAllNews(int? pageSize,int? page)
        {

            SearchResult<tblNew> listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1));
            return View(listAllNews);
        }
        public ActionResult EditNews(Guid? newsID)
        {
            if (newsID != null)
            {
                tblNew tblnew = _nguyenHiepService.GetNewsByID((Guid)newsID);
                List<SelectListItem> ls = new List<SelectListItem>();
                ls.Add((new SelectListItem { Text = "Tin Tức", Value = CategoryTypes.News.ToString() }));
                ls.Add((new SelectListItem { Text = "Tuyển Dụng", Value = CategoryTypes.RecruitmentS.ToString() }));
                ViewData["NewsType"] = ls;
                return View(tblnew);
            }
            else
            {
                List<SelectListItem> ls = new List<SelectListItem>();
                ls.Add((new SelectListItem { Text = "Tin Tức", Value = CategoryTypes.News.ToString() }));
                ls.Add((new SelectListItem { Text = "Tuyển Dụng", Value = CategoryTypes.RecruitmentS.ToString() }));
                ViewData["NewsType"] = ls;
                ViewData["AddNews"] = true;
                tblNew tblnew= new tblNew();
                return View(tblnew);
            }
        }
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditNews(Guid? newsID, [Bind(Exclude = "ID")] tblNew tblnew)
        {
            if (newsID != null && ModelState.IsValid)
            {
                tblnew.ID = (Guid)newsID;
                _nguyenHiepService.UpdateNews(tblnew);
                TempData["NewsID"] = newsID;
                return RedirectToAction("ViewNews");
            }
            else if (newsID == null && ModelState.IsValid)
            {
                tblnew.ID = Guid.NewGuid();
                _nguyenHiepService.InsertNews(tblnew);
                return RedirectToAction("Index");
            }
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add((new SelectListItem { Text = "Tin Tức", Value = CategoryTypes.News.ToString() }));
            ls.Add((new SelectListItem { Text = "Tuyển Dụng", Value = CategoryTypes.RecruitmentS.ToString() }));
            ViewData["NewsType"] = ls;
            if (newsID == null)
            {
                ViewData["AddNews"] = true;
            }
            return View(tblnew);
        }
    }
}
