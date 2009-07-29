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
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.News;
            SearchResult<tblNew> listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1),NguyenHiep.Common.NewsTypes.News);
            return View(listAllNews);
        }
        public ActionResult IndexForRecruitment()
        {
            tblNew recruitment = _nguyenHiepService.GetSpecialNew(NguyenHiep.Common.NewsTypes.Recruitment);
            return View(recruitment);
        }
        public ActionResult IndexForContact()
        {
            tblInformation contact = _nguyenHiepService.GetInformation();
            return View(contact);
        }
        public ActionResult IndexForIntroduction()
        {
            tblNew introduction = _nguyenHiepService.GetSpecialNew(NguyenHiep.Common.NewsTypes.Introduction);
            return View(introduction);
        }
        public ActionResult IndexForContruction(int? pageSize, int? page)
        {
          ViewData["Type"] = NguyenHiep.Common.NewsTypes.Contruction;
          SearchResult<tblNew> listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.Contruction);
          return View(listAllNews);
        }
        public ActionResult IndexForProduct(int? pageSize, int? page)
        {
            SearchResult<tblProduct> listAllNews = _nguyenHiepService.GetAllProduct((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1));
            return View(listAllNews);
        }
        public ActionResult ViewNews(Guid? newsID,byte? type)
        {
            if (!type.HasValue)
            {
                type = (byte)NguyenHiep.Common.NewsTypes.News;
            }
            if (newsID != null && !newsID.Equals(Guid.Empty))
            {
                tblNew tblnews = _nguyenHiepService.GetNewsByID((Guid)newsID);
                return View(tblnews);
            }
            else if (TempData["NewsID"] != null )
            {
                if (TempData["Type"] == null)
                    type = (byte)NguyenHiep.Common.NewsTypes.News;
                else
                    type = (byte)TempData["Type"];
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

          SearchResult<tblNew> listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.News);
            return View(listAllNews);
        }
        public ActionResult ListAllContruction(int? pageSize, int? page)
        {

          SearchResult<tblNew> listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1),NguyenHiep.Common.NewsTypes.Contruction);
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
                ls.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = true }));
                ls.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString() }));
                ViewData["NewsType"] = ls;
                ViewData["ContentVN"] = tblnew.ContentVN;
                ViewData["command"] = "upload";
                return View(tblnew);
            }
            else
            {
                List<SelectListItem> ls = new List<SelectListItem>();
                ls.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = true }));
                ls.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString() }));
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
                
                if (file != null && file.ContentLength > 0 && newsID != null && ModelState.IsValid)
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
                else if (file != null && file.ContentLength > 0 && newsID == null && ModelState.IsValid)
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
                            tblnew.Type = (byte)NguyenHiep.Common.NewsTypes.News;
                        if (tblnew.Type == NguyenHiep.Common.NewsTypes.News)
                        {
                          return RedirectToAction("IndexForNews");
                        }
                        else if (tblnew.Type == NguyenHiep.Common.NewsTypes.Contruction)
                        {
                          return RedirectToAction("IndexForContruction");
                        }
                        else if (tblnew.Type == NguyenHiep.Common.NewsTypes.HotNew)
                        {
                            return RedirectToAction("ViewHotNew");
                        }
                        else if (tblnew.Type == NguyenHiep.Common.NewsTypes.Introduction)
                        {
                            return RedirectToAction("ViewIntroduction");
                        }
                        else if (tblnew.Type == NguyenHiep.Common.NewsTypes.Recruitment)
                        {
                            return RedirectToAction("ViewRecruitment");
                        }
                    }

                }

            }
           
            if (!flag)
            {
                ModelState.AddModelError("UploadFile", "File Request is not support");
            }
            ViewData["NewsType"] = BuildNewsTypes();
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
           
            if (!flag)
            {
                ModelState.AddModelError("UploadFile", "File Request is not support");
            }
            ViewData["NewsType"] = BuildProductTypes();
            if (newsID == null)
            {
                ViewData["AddNews"] = true;
            }
            return View(tblproduct);
        }
        public ActionResult EditContact(Guid? newsID)
        {
            tblInformation contact = _nguyenHiepService.GetInformation();
            return View(contact);
        }
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditContact(Guid? newsID, string contactVN)
        {
            tblInformation contact = new tblInformation();
            if (newsID.HasValue && !newsID.Value.Equals(Guid.Empty))
            {
                contact = _nguyenHiepService.GetInformation((Guid)newsID);
                if (contact != null)
                {
                    contact.ContactVN = contactVN;
                    if (_nguyenHiepService.UpdateInformation(contact))
                    {
                        return RedirectToAction("IndexForContact");
                    }
                }
            }
            else
            {
                contact.ID = Guid.NewGuid();
                contact.ContactVN = contactVN;
                contact.CreatedDate = DateTime.Now;
                if (_nguyenHiepService.InsertInformation(contact))
                {
                    return RedirectToAction("IndexForContact");
                }
            }
            return View(contact);
            
        }
        public ActionResult ViewRecruitment()
        {
            tblNew recruitment = _nguyenHiepService.GetSpecialNew(NguyenHiep.Common.NewsTypes.Recruitment);
            return View(recruitment);
        }
        public ActionResult ViewIntroduction()
        {
            tblNew introduction = _nguyenHiepService.GetSpecialNew(NguyenHiep.Common.NewsTypes.Introduction);
            return View(introduction);
        }
        protected List<SelectListItem> BuildNewsTypes()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = true }));
            ls.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString() }));
            ls.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString() }));
            ls.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString() }));
            ls.Add((new SelectListItem { Text = "Tin tức tuyển dụng", Value = NewsTypes.Recruitment.ToString() }));
            return ls;
        }
        protected List<SelectListItem> BuildProductTypes()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add((new SelectListItem { Text = "Sản phẩm khuyến mãi", Value = NewsTypes.PromotionNew.ToString() }));
            ls.Add((new SelectListItem { Text = "Sản phẩm thường", Value = NewsTypes.NormalProduct.ToString() }));
            return ls;
        }
    }
}
