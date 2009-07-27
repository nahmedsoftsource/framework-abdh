using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NGUYENHIEP.Models;
using NGUYENHIEP.Services;
using NguyenHiep.Data;
using NguyenHiep.Common;
using System.IO;
using System.Configuration;

namespace NGUYENHIEP.Controllers
{
    [HandleError]
    public class NguyenHiepController : Controller
    {
        NguyenHiepService _nguyenHiepService = NguyenHiepService.Instance;
        public ActionResult Index(int? pageSize, int? page)
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
            else if (TempData["NewsID"] != null)
            {
                tblNew tblnews = _nguyenHiepService.GetNewsByID((Guid)TempData["NewsID"]);
                return View(tblnews);
            }
            return new EmptyResult();
        }
        public ActionResult ListAllNews(int? pageSize, int? page)
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
                ViewData["ContentVN"] = tblnew.ContentVN;
                ViewData["command"] = "upload";
                return View(tblnew);
            }
            else
            {
                List<SelectListItem> ls = new List<SelectListItem>();
                ls.Add((new SelectListItem { Text = "Tin Tức", Value = CategoryTypes.News.ToString() }));
                ls.Add((new SelectListItem { Text = "Tuyển Dụng", Value = CategoryTypes.RecruitmentS.ToString() }));
                ViewData["NewsType"] = ls;
                ViewData["AddNews"] = true;
                tblNew tblnew = new tblNew();
                return View(tblnew);
            }
        }
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditNews(Guid? newsID, [Bind(Exclude = "ID")] tblNew tblnew)
        {
            string pathFolder = Server.MapPath(ConfigurationManager.AppSettings["ImagesNews"]);
            bool flag = false;
            if (!Directory.Exists(pathFolder)) Directory.CreateDirectory(pathFolder);
            foreach (string inputTagName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[inputTagName];
                
                if (newsID != null && ModelState.IsValid)
                {
                    tblnew.ID = (Guid)newsID;
                    string pathImage;
                    if (file != null && Utility.File.File.SaveFile(file, out pathImage, (Guid)newsID, pathFolder))
                    {
                        flag = true;
                        tblnew.Image = pathImage;
                        _nguyenHiepService.UpdateNews(tblnew);
                        TempData["NewsID"] = newsID;
                        return RedirectToAction("ViewNews");
                    }
                }
                else if (newsID == null && ModelState.IsValid)
                {
                    flag = true;
                    tblnew.ID =Guid.NewGuid();
                    newsID = tblnew.ID;
                    string pathImage;
                    if (file != null && Utility.File.File.SaveFile(file, out pathImage, (Guid)newsID, pathFolder))
                    {
                        tblnew.Image = pathImage;
                        _nguyenHiepService.InsertNews(tblnew);
                        return RedirectToAction("Index");
                    }

                }

            }
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add((new SelectListItem { Text = "Tin Tức", Value = CategoryTypes.News.ToString() }));
            ls.Add((new SelectListItem { Text = "Tuyển Dụng", Value = CategoryTypes.RecruitmentS.ToString() }));
            if (!flag)
            {
                ModelState.AddModelError("UploadFile", "File Request is not support");
            }
            ViewData["NewsType"] = ls;
            if (newsID == null)
            {
                ViewData["AddNews"] = true;
            }
            return View(tblnew);
        }
    }
}
