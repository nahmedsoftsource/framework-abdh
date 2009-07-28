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
        #region
        #endregion
        NguyenHiepService _nguyenHiepService = NguyenHiepService.Instance;
        public ActionResult Index()
        {
          return View();
        }
        public ActionResult IndexForNews(int? pageSize, int? page)
        {
            ViewData["Type"] = NguyenHiep.Common.CategoryTypes.News;
            SearchResult<tblNew> listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1),NguyenHiep.Common.CategoryTypes.News);
            return View(listAllNews);
        }
        public ActionResult IndexForContruction(int? pageSize, int? page)
        {
          ViewData["Type"] = NguyenHiep.Common.CategoryTypes.Contruction;
          SearchResult<tblNew> listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1), NguyenHiep.Common.CategoryTypes.Contruction);
          return View(listAllNews);
        }
        public ActionResult IndexForProduct(int? pageSize, int? page)
        {
            SearchResult<tblProduct> listAllNews = _nguyenHiepService.GetAllProduct((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1));
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
        public ActionResult ViewProduct(Guid? newsID)
        {
            if (newsID != null && !newsID.Equals(Guid.Empty))
            {
                tblProduct tblproduct = _nguyenHiepService.GetProductByID((Guid)newsID);
                return View(tblproduct);
            }
            else if (TempData["ProductID"] != null)
            {
                tblProduct tblproduct = _nguyenHiepService.GetProductByID((Guid)TempData["ProductID"]);
                return View(tblproduct);
            }
            tblProduct tblpro = new tblProduct();
            return View(tblpro);
        }
        public ActionResult ListAllNews(int? pageSize, int? page)
        {

          SearchResult<tblNew> listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1), NguyenHiep.Common.CategoryTypes.News);
            return View(listAllNews);
        }
        public ActionResult ListAllContruction(int? pageSize, int? page)
        {

          SearchResult<tblNew> listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1),NguyenHiep.Common.CategoryTypes.Contruction);
          return View(listAllNews);
        }
        public ActionResult ListAllProduct(int? pageSize, int? page)
        {

            SearchResult<tblProduct> listAllNews = _nguyenHiepService.GetAllProduct((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1));
            return View(listAllNews);
        }
        public ActionResult ListCategory(int? pageSize, int? page)
        {
            SearchResult<tblCategory> listAllCategory = _nguyenHiepService.GetAllCategory((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1));
            return View(listAllCategory);
        }
        public ActionResult EditNews(Guid? newsID)
        {

            if (newsID != null)
            {
                tblNew tblnew = _nguyenHiepService.GetNewsByID((Guid)newsID);
                List<SelectListItem> ls = new List<SelectListItem>();
                ls.Add((new SelectListItem { Text = "Tin Tức", Value = CategoryTypes.News.ToString(), Selected = true }));
                ls.Add((new SelectListItem { Text = "Công trình", Value = CategoryTypes.Contruction.ToString() }));
                ViewData["NewsType"] = ls;
                ViewData["ContentVN"] = tblnew.ContentVN;
                ViewData["command"] = "upload";
                return View(tblnew);
            }
            else
            {
                List<SelectListItem> ls = new List<SelectListItem>();
                ls.Add((new SelectListItem { Text = "Tin Tức", Value = CategoryTypes.News.ToString(), Selected = true }));
                ls.Add((new SelectListItem { Text = "Công trình", Value = CategoryTypes.Contruction.ToString() }));
                ViewData["NewsType"] = ls;
                ViewData["AddNews"] = true;
                tblNew tblnew = new tblNew();
                return View(tblnew);
            }
        }
        public ActionResult EditCategory(Guid? newsID)
        {

            if (newsID != null)
            {
                tblCategory tblCategory = new tblCategory();// = _nguyenHiepService.GetCategoryByID((Guid)newsID);

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

        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditCategory(Guid? newsID, [Bind(Exclude = "ID")] tblCategory tblnew)
        {
            bool flag = false;
            if (newsID != null && ModelState.IsValid)
            {
                _nguyenHiepService.UpdateCategory(tblnew);
                TempData["CategoryID"] = newsID;
                //todo: view one category
                return RedirectToAction("ViewNews");
            }
            else if (newsID == null && ModelState.IsValid)
            {
                flag = true;
                tblnew.ID = Guid.NewGuid();
                newsID = tblnew.ID;

                TempData["CategoryID"] = newsID;
                _nguyenHiepService.InsertCategory(tblnew);
                //todo: view one category
                return RedirectToAction("ViewNews");
            }
            

            if (newsID == null)
            {
                ViewData["AddNews"] = true;
            }
            return View(tblnew);
        }
        public ActionResult EditProduct(Guid? newsID)
        {
            List<SelectListItem> categories = new List<SelectListItem>();
            List<tblCategory> listCategory = _nguyenHiepService.GetAllCategory();
            int counter = 0;
            foreach (tblCategory cat in listCategory)
            {
                if (counter == 0)
                {
                    categories.Add(new SelectListItem { Text = cat.ID.ToString(), Value = cat.CategoryNameEN });
                }
                else
                {
                    categories.Add(new SelectListItem { Text = cat.ID.ToString(), Value = cat.CategoryNameEN, Selected = true });
                }
                counter++;
            }
            List<SelectListItem> storeStatus = new List<SelectListItem>();
            storeStatus.Add((new SelectListItem { Text = "Còn hàng", Value = StoreStatuses.Exhausted.ToString() }));
            storeStatus.Add((new SelectListItem { Text = "Hết hàng", Value = StoreStatuses.NotExhausted.ToString() }));
            List<SelectListItem> promotion = new List<SelectListItem>();
            promotion.Add((new SelectListItem { Text = "Có khuyến mãi", Value = StoreStatuses.Exhausted.ToString() }));
            promotion.Add((new SelectListItem { Text = "Không có khuyến mãi", Value = StoreStatuses.NotExhausted.ToString() }));
            ViewData["StoreStatus"] = storeStatus;
            ViewData["Promotion"] = promotion;
            ViewData["Categories"] = categories;

            if (newsID != null)
            {
                tblProduct tblproduct = _nguyenHiepService.GetProductByID((Guid)newsID);
                
                
                return View(tblproduct);
            }
            else
            {
                
                ViewData["AddProduct"] = true;
                tblProduct tblproduct = new tblProduct();
                return View(tblproduct);
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
                        if (!tblnew.Type.HasValue)
                            tblnew.Type = (byte)NguyenHiep.Common.CategoryTypes.News;
                        if (tblnew.Type == NguyenHiep.Common.CategoryTypes.News)
                        {
                          return RedirectToAction("IndexForNews");
                        }
                        else if (tblnew.Type == NguyenHiep.Common.CategoryTypes.Contruction)
                        {
                          return RedirectToAction("IndexForContruction");
                        }
                    }

                }

            }
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add((new SelectListItem { Text = "Tin Tức", Value = CategoryTypes.News.ToString(),Selected=true}));
            ls.Add((new SelectListItem { Text = "Công trình", Value = CategoryTypes.Contruction.ToString() }));
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

        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditProduct(Guid? newsID, [Bind(Exclude = "ID")] tblProduct tblproduct)
        {
            string pathFolder = Server.MapPath(ConfigurationManager.AppSettings["ImagesNews"]);
            bool flag = false;
            if (!Directory.Exists(pathFolder)) Directory.CreateDirectory(pathFolder);
            foreach (string inputTagName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[inputTagName];

                if (newsID != null && ModelState.IsValid)
                {
                    tblproduct.ID = (Guid)newsID;
                    string pathImage;
                    if (file != null && Utility.File.File.SaveFile(file, out pathImage, (Guid)newsID, pathFolder))
                    {
                        flag = true;
                        tblproduct.Image = pathImage;
                        
                    }
                    if (tblproduct.Image == null)
                    {
                        tblproduct.Image = Request["Image"];
                    }

                    _nguyenHiepService.UpdateProduct(tblproduct);
                    TempData["ProductID"] = newsID;
                    return RedirectToAction("ViewProduct");
                }
                else if (newsID == null && ModelState.IsValid)
                {
                    flag = true;
                    tblproduct.ID = Guid.NewGuid();
                    newsID = tblproduct.ID;
                    string pathImage;
                    if (file != null && Utility.File.File.SaveFile(file, out pathImage, (Guid)newsID, pathFolder))
                    {
                        tblproduct.Image = pathImage;
                        
                    }
                    _nguyenHiepService.InsertProduct(tblproduct);
                    return RedirectToAction("IndexForProduct");

                }

            }
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add((new SelectListItem { Text = "Tin Tức", Value = CategoryTypes.News.ToString() }));
            ls.Add((new SelectListItem { Text = "Công trình", Value = CategoryTypes.Contruction.ToString() }));
            if (!flag)
            {
                ModelState.AddModelError("UploadFile", "File Request is not support");
            }
            ViewData["NewsType"] = ls;
            if (newsID == null)
            {
                ViewData["AddNews"] = true;
            }
            return View(tblproduct);
        }
    }
}
