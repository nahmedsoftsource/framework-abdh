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
using NGUYENHIEP.Infrastructure;

namespace NGUYENHIEP.Controllers
{
    [HandleError]
    public class NguyenHiepController : BaseController
    {
        #region
        #endregion
        NguyenHiepService _nguyenHiepService = NguyenHiepService.Instance;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexForPromotionNews(int? pageSize, int? page)
        {
            SearchResult<tblNew> listAllNews = new SearchResult<tblNew>();
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.PromotionNew;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.PromotionNew, true);
            }
            else
            {
                listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.PromotionNew, false);
            }
            return View(listAllNews);
        }
        public ActionResult ListPromotionNews(int? pageSize, int? page)
        {
            SearchResult<tblNew> listAllNews = new SearchResult<tblNew>();
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.PromotionNew;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.PromotionNew, true);
            }
            else
            {
                listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.PromotionNew, false);
            }
            return View(listAllNews);
        }
        public ActionResult IndexForNews(int? pageSize, int? page)
        {
            SearchResult<tblNew> listAllNews = new SearchResult<tblNew>();
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.News;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.News, true);
            }
            else
            {
                listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.News, false);
            }
            return View(listAllNews);
        }
        public ActionResult IndexForRecruitment()
        {
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.Recruitment;
            tblNew recruitment = _nguyenHiepService.GetSpecialNew(NguyenHiep.Common.NewsTypes.Recruitment);
            return View(recruitment);
        }
        public ActionResult IndexForContact()
        {
            tblInformation contact = new tblInformation();
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                contact = _nguyenHiepService.GetInformation(true);
            }
            else
            {
                contact = _nguyenHiepService.GetInformation(false);
            }
            return View(contact);
        }
        public ActionResult IndexForIntroduction()
        {
            
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.Introduction;
            tblNew introduction = _nguyenHiepService.GetSpecialNew(NguyenHiep.Common.NewsTypes.Introduction);
            return View(introduction);
        }
        public ActionResult IndexForContruction(int? pageSize, int? page)
        {
            SearchResult<tblNew> listAllNews = new SearchResult<tblNew>();
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.Contruction;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.Contruction, true);
            }
            else
            {
                listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.Contruction, false);
            }
            return View(listAllNews);
        }
        public ActionResult IndexForProduct(int? pageSize, int? page)
        {
            SearchResult<tblProduct> listAllNews = new SearchResult<tblProduct>();
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.NormalProduct;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = _nguyenHiepService.GetAllProduct((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1),true);
            }
            else
            {
                listAllNews = _nguyenHiepService.GetAllProduct((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1),false);
            }
            return View(listAllNews);
        }
        public ActionResult ViewNews(Guid? newsID, byte? type)
        {
            ViewData["Type"] = type;
            if (!type.HasValue)
            {
                type = (byte)NguyenHiep.Common.NewsTypes.News;
            }
            if (newsID != null && !newsID.Equals(Guid.Empty))
            {
                tblNew tblnews = _nguyenHiepService.GetNewsByID((Guid)newsID);
                return View(tblnews);
            }
            else if (TempData["NewsID"] != null)
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
        public ActionResult ViewProduct(Guid? newsID, byte? type)
        {
            ViewData["Type"] = type;
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
            SearchResult<tblNew> listAllNews = new SearchResult<tblNew>();
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.News;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.News, true);
            }
            else
            {
                listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.News, false);
            }
            return View(listAllNews);
        }
        public ActionResult ListAllContruction(int? pageSize, int? page)
        {
            SearchResult<tblNew> listAllNews = new SearchResult<tblNew>();
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.Contruction;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.Contruction, true);
            }
            else
            {
                listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.Contruction, false);
            }
            return View(listAllNews);
        }
        public ActionResult ListAllProduct(int? pageSize, int? page)
        {
            SearchResult<tblProduct> listAllNews = new SearchResult<tblProduct>();
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = _nguyenHiepService.GetAllProduct((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1),true);
            }
            else
            {
                listAllNews = _nguyenHiepService.GetAllProduct((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1),false);
            }
            return View(listAllNews);
        }
        public ActionResult IndexForProductByCategory(int? pageSize, int? page, Guid? categoryID)
        {
            SearchResult<tblProduct> listAllNews = new SearchResult<tblProduct>();
            if (categoryID.HasValue && !categoryID.Value.Equals(Guid.Empty))
            {
                ViewData["CategoryID"] = categoryID;
                listAllNews = _nguyenHiepService.GetAllProductByCategory((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1), (Guid)categoryID);
            }

            return View(listAllNews);
        }
        public ActionResult ListAllProductByCategory(int? pageSize, int? page,Guid? categoryID)
        {
            SearchResult<tblProduct> listAllNews = new SearchResult<tblProduct>();
            if (categoryID.HasValue && !categoryID.Value.Equals(Guid.Empty))
            {
                ViewData["CategoryID"] = categoryID;
                listAllNews = _nguyenHiepService.GetAllProductByCategory((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1), (Guid)categoryID);
            }
            
            return View(listAllNews);
        }
        public ActionResult ListCategory(int? pageSize, int? page)
        {
            SearchResult<tblCategory> listAllCategory = new SearchResult<tblCategory>();
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllCategory = _nguyenHiepService.GetAllCategory((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1),true);
            }
            else 
            {
                listAllCategory = _nguyenHiepService.GetAllCategory((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1),false);
            }

            return View(listAllCategory);
        }
        public ActionResult EditNews(Guid? newsID, byte? type)
        {
            if (type.HasValue)
            {
                ViewData["CurrentType"] = type;
            }
            else
            {
                ViewData["CurrentType"] = NguyenHiep.Common.NewsTypes.News;
            }
            List<SelectListItem> lsEN = new List<SelectListItem>();
            List<SelectListItem> lsVN = new List<SelectListItem>();
            tblNew tblnew = null;
            if (newsID.HasValue && !newsID.Value.Equals(Guid.Empty))
            {
                tblnew = _nguyenHiepService.GetNewsByID((Guid)newsID);
            }
            #region Edit
            if (newsID.HasValue && !newsID.Equals(Guid.Empty) && tblnew != null)
            {
                if (tblnew.Type.HasValue && tblnew.Type.Value == NewsTypes.News)
                {
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString(), Selected = false }));

                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString(), Selected = false }));

                }
                else if (tblnew.Type.HasValue && tblnew.Type.Value == NewsTypes.Contruction)
                {
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString(), Selected = false }));

                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString(), Selected = false }));

                }
                else if (tblnew.Type.HasValue && tblnew.Type.Value == NewsTypes.HotNew)
                {
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString(), Selected = false }));

                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString(), Selected = false }));
                }
                else if (tblnew.Type.HasValue && tblnew.Type.Value == NewsTypes.Introduction)
                {
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString(), Selected = false }));

                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString(), Selected = false }));
                }
                else if (tblnew.Type.HasValue && tblnew.Type.Value == NewsTypes.NormalProduct)
                {
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString(), Selected = false }));


                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString(), Selected = false }));
                }
                else if (tblnew.Type.HasValue && tblnew.Type.Value == NewsTypes.PromotionNew)
                {
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString(), Selected = false }));

                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString(), Selected = false }));
                }
                else if (tblnew.Type.HasValue && tblnew.Type.Value == NewsTypes.Recruitment)
                {
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));

                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));

                }
                if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                {
                    ViewData["Type"] = lsEN;
                    ViewData["ContentEN"] = tblnew.ContentEN;
                }
                else
                {
                    ViewData["Type"] = lsVN;
                    ViewData["ContentVN"] = tblnew.ContentVN;
                }



                ViewData["command"] = "upload";
                return View(tblnew);
            }
            #endregion
            #region Add
            if (type.HasValue && type.Value == NewsTypes.News)
            {
                lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = true }));
                lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString() }));
                lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString() }));
                lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString() }));
                lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString() }));
                lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString() }));
                lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString() }));

                lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString(), Selected = true }));
                lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString() }));
                lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString() }));
                lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString() }));
                lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString() }));
                lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString() }));
                lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString() }));

            }
            else
                if (type.HasValue && type.Value == NewsTypes.Contruction)
                {
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString() }));

                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString() }));

                }
                else if (type.HasValue && type.Value == NewsTypes.HotNew)
                {
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString() }));

                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString() }));
                }
                else if (type.HasValue && type.Value == NewsTypes.Introduction)
                {
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString() }));

                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString() }));
                }
                else if (type.HasValue && type.Value == NewsTypes.NormalProduct)
                {
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString() }));

                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString() }));
                }
                else if (type.HasValue && type.Value == NewsTypes.PromotionNew)
                {
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString() }));

                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString() }));
                }
                else if (type.HasValue && type.Value == NewsTypes.Recruitment)
                {
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString(), Selected = true }));


                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString() }));



                }
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                ViewData["Type"] = lsEN;
            }
            else
            {
                ViewData["Type"] = lsVN;
            }
            ViewData["AddNews"] = true;
            tblnew = new tblNew();
            return View(tblnew);
            #endregion
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
        public ActionResult EditCategory(Guid? newsID, [Bind(Exclude = "ID")] tblCategory tblnew, byte? type)
        {
            bool flag = false;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                if (tblnew != null && String.IsNullOrEmpty(tblnew.CategoryNameEN))
                {
                    ModelState.AddModelError("CategoryNameEN", "Category name is required");
                }
                else if (tblnew != null && tblnew.CategoryNameEN.Length >= 100)
                {
                    ModelState.AddModelError("CategoryNameEN", "Input no more than 100 characters");
                }
                if (tblnew != null && !String.IsNullOrEmpty(tblnew.DescriptionEN) && tblnew.DescriptionEN.Length >= 250)
                {
                    ModelState.AddModelError("CategoryNameEN", "Input no more than 250 characters");
                }
            }
            else
            {
                if (tblnew != null && String.IsNullOrEmpty(tblnew.CategoryNameVN))
                {
                    ModelState.AddModelError("CategoryNameVN", "Cần nhập tên loại sản phẩm");
                }
                else if (tblnew != null && tblnew.CategoryNameVN.Length >= 100)
                {
                    ModelState.AddModelError("CategoryNameVN", "Không nhập quá 100 ký tự");
                }
                if (tblnew != null && !String.IsNullOrEmpty(tblnew.DescriptionVN) && tblnew.DescriptionVN.Length >= 250)
                {
                    ModelState.AddModelError("DescriptionVN", "Không nhập quá 250 ký tự");
                }
            }
            if (newsID != null && ModelState.IsValid)
            {
                _nguyenHiepService.UpdateCategory(tblnew);
                TempData["CategoryID"] = newsID;
                //todo: view one category
                return RedirectToAction("IndexForNews");
            }
            else if (newsID == null && ModelState.IsValid)
            {
                flag = true;
                tblnew.ID = Guid.NewGuid();
                newsID = tblnew.ID;

                TempData["CategoryID"] = newsID;
                _nguyenHiepService.InsertCategory(tblnew);
                //todo: view one category
                return RedirectToAction("IndexForNews");
            }


            if (newsID == null)
            {
                ViewData["AddNews"] = true;
            }

            return View(tblnew);
        }
        public ActionResult EditProduct(Guid? newsID, byte? type)
        {
            ViewData["Type"] = type;

            List<SelectListItem> categories = new List<SelectListItem>();
            List<tblCategory> listCategory = new List<tblCategory>();
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listCategory = _nguyenHiepService.GetAllCategory(true);
            }
            else
            {
                listCategory = _nguyenHiepService.GetAllCategory(false);
            }
            int counter = 0;
            foreach (tblCategory cat in listCategory)
            {
                if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                {
                    categories.Add(new SelectListItem { Text = cat.CategoryNameEN, Value = cat.ID.ToString() });
                }
                else
                {
                    categories.Add(new SelectListItem { Text = cat.CategoryNameVN, Value = cat.ID.ToString() });
                }
                
            }
            List<SelectListItem> storeStatusVN = new List<SelectListItem>();
            storeStatusVN.Add((new SelectListItem { Text = "Còn hàng", Value = StoreStatuses.Exhausted.ToString() }));
            storeStatusVN.Add((new SelectListItem { Text = "Hết hàng", Value = StoreStatuses.NotExhausted.ToString() }));
            List<SelectListItem> storeStatusEN = new List<SelectListItem>();
            storeStatusEN.Add((new SelectListItem { Text = "Available", Value = StoreStatuses.Exhausted.ToString() }));
            storeStatusEN.Add((new SelectListItem { Text = "Not Available", Value = StoreStatuses.NotExhausted.ToString() }));


            List<SelectListItem> promotionVN = new List<SelectListItem>();
            promotionVN.Add((new SelectListItem { Text = "Có khuyến mãi", Value = StoreStatuses.Exhausted.ToString() }));
            promotionVN.Add((new SelectListItem { Text = "Không có khuyến mãi", Value = StoreStatuses.NotExhausted.ToString() }));

            List<SelectListItem> promotionEN = new List<SelectListItem>();
            promotionEN.Add((new SelectListItem { Text = "Có khuyến mãi", Value = StoreStatuses.Exhausted.ToString() }));
            promotionEN.Add((new SelectListItem { Text = "Không có khuyến mãi", Value = StoreStatuses.NotExhausted.ToString() }));
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                ViewData["StoreStatus"] = storeStatusEN;

                ViewData["Promotion"] = promotionEN;
            }
            else
            {
                ViewData["Promotion"] = promotionVN;
                ViewData["StoreStatus"] = storeStatusVN;
            }


            ViewData["Categories"] = categories;

            if (newsID != null)
            {
                tblProduct tblproduct = _nguyenHiepService.GetProductByID((Guid)newsID);
                if (tblproduct != null && !string.IsNullOrEmpty(tblproduct.Description))
                {
                    ViewData["Description"] = tblproduct.Description;
                }

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
        public ActionResult EditNews(Guid? newsID, [Bind(Exclude = "ID")] tblNew tblnew, byte? type)
        {
            
            byte tmpType = 0;
            if (tblnew.Type.HasValue)
            {
                tmpType = (byte)tblnew.Type;
            }
            else if (type.HasValue)
            {
                tmpType = (byte)type;
            }
            ViewData["CurrentType"] = tmpType;
            string pathFolder = Server.MapPath(ConfigurationManager.AppSettings["ImagesNews"]);
            bool flag = false;
            bool insert = false;
            if (!Directory.Exists(pathFolder)) Directory.CreateDirectory(pathFolder);
            foreach (string inputTagName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[inputTagName];
                if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                {
                    
                    if (String.IsNullOrEmpty(tblnew.SubjectEN))
                    {
                        ModelState.AddModelError("SubjectEN", "Subject field is required");
                    }
                    else if (tblnew.SubjectEN.Length >= 500)
                    {
                        ModelState.AddModelError("SubjectEN", "Input no more than 500 characters");
                    }
                    if (String.IsNullOrEmpty(tblnew.TitleEN))
                    {
                        ModelState.AddModelError("TitleEN", "Title field is required");
                    }
                    else if (tblnew.TitleEN.Length >= 250)
                    {
                        ModelState.AddModelError("TitleEN", "Input no more than 250 characters");
                    }
                    
                    if (String.IsNullOrEmpty(tblnew.ContentEN))
                    {
                        ModelState.AddModelError("ContentEN", "Content field is required");
                    }
                    else if (tblnew.ContentEN.Length >= 4000)
                    {
                        ModelState.AddModelError("ContentEN", "Input no more than 4000 characters");
                    }
                    

                }
                else
                {
                    
                    if (String.IsNullOrEmpty(tblnew.SubjectVN))
                    {
                        ModelState.AddModelError("SubjectVN", "Cần nhập chủ đề");
                    }
                    else if (tblnew.SubjectVN.Length >= 500)
                    {
                        ModelState.AddModelError("SubjectVN", "Chủ đề nhập không quá 500 ký tự");
                    }
                    if (String.IsNullOrEmpty(tblnew.TitleVN))
                    {
                        ModelState.AddModelError("TitleVN", "Cần nhập tiêu đề");
                    }
                    else if (tblnew.TitleVN.Length >= 250)
                    {
                        ModelState.AddModelError("TitleVN", "Tiêu đề nhập không quá 250 ký tự");
                    }
                    
                    if (String.IsNullOrEmpty(tblnew.ContentVN))
                    {
                        ModelState.AddModelError("ContentVN", "Cần nhập nội dung");
                    }
                    else if (tblnew.ContentVN.Length >= 4000)
                    {
                        ModelState.AddModelError("ContentVN", "Tiêu đề nhập không quá 4000 ký tự");
                    }
                }
                if (file != null && file.ContentLength > 0 && newsID != null && !newsID.Value.Equals(Guid.Empty) && ModelState.IsValid)
                {
                    tblnew.ID = (Guid)newsID;
                    string pathImage;
                    if (file != null && Utility.File.File.SaveFile(file, out pathImage, (Guid)newsID, pathFolder))
                    {
                        flag = true;
                        tblnew.Image = pathImage;
                        _nguyenHiepService.UpdateNews(tblnew);
                        insert = false;
                        TempData["NewsID"] = newsID;
                        TempData["Type"] = tblnew.Type;
                        ModelState.Clear();
                        if (tblnew.Type == NguyenHiep.Common.NewsTypes.News)
                        {
                            return RedirectToAction("ViewNews");
                        }
                        else if (tblnew.Type == NguyenHiep.Common.NewsTypes.Contruction)
                        {
                            return RedirectToAction("ViewNews");
                        }
                        else if (tblnew.Type == NguyenHiep.Common.NewsTypes.HotNew)
                        {
                            return RedirectToAction("ViewHotNew");
                        }
                        else if (tblnew.Type == NguyenHiep.Common.NewsTypes.Introduction)
                        {
                            return RedirectToAction("IndexForIntroduction");
                        }
                        else if (tblnew.Type == NguyenHiep.Common.NewsTypes.Recruitment)
                        {
                            return RedirectToAction("IndexForRecruitment");
                        }
                    }
                }
                else if (file != null && file.ContentLength > 0 && (!newsID.HasValue || newsID.Value.Equals(Guid.Empty)) && ModelState.IsValid)
                {
                    flag = true;
                    tblnew.ID = Guid.NewGuid();
                    newsID = tblnew.ID;
                    string pathImage;
                    if (file != null && Utility.File.File.SaveFile(file, out pathImage, (Guid)newsID, pathFolder))
                    {
                        tblnew.Image = pathImage;
                        _nguyenHiepService.InsertNews(tblnew);
                        ModelState.Clear();
                        insert = true;
                        TempData["Type"] = tblnew.Type;
                        if (!type.HasValue)
                            type = (byte)NguyenHiep.Common.NewsTypes.News;
                        if (type == NguyenHiep.Common.NewsTypes.News)
                        {
                            return RedirectToAction("IndexForNews");
                        }
                        else if (type == NguyenHiep.Common.NewsTypes.Contruction)
                        {
                            return RedirectToAction("IndexForContruction");
                        }
                        else if (type == NguyenHiep.Common.NewsTypes.HotNew)
                        {
                            return RedirectToAction("ViewHotNew");
                        }
                        else if (type == NguyenHiep.Common.NewsTypes.Introduction)
                        {
                            return RedirectToAction("IndexForIntroduction");
                        }
                        else if (type == NguyenHiep.Common.NewsTypes.Recruitment)
                        {
                            return RedirectToAction("IndexForRecruitment");
                        }
                        else if (type == NguyenHiep.Common.NewsTypes.PromotionNew)
                        {
                            return RedirectToAction("IndexForNews");
                        }
                    }

                }

            }
            if (tmpType != NguyenHiep.Common.NewsTypes.Recruitment && tmpType != NguyenHiep.Common.NewsTypes.Introduction)
            {
                if (!flag && tblnew != null && String.IsNullOrEmpty(tblnew.Image))
                {
                    if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                    {
                        ModelState.AddModelError("Image", "This image is not support or  haven't pick up");
                    }
                    else
                    {
                        ModelState.AddModelError("Image", "Định dạng hình ảnh này không trợ giúp hoặc chưa chọn");
                    }
                    
                }
                else if (!flag && tblnew != null && !String.IsNullOrEmpty(tblnew.Image))
                {
                    if (!newsID.HasValue || newsID.Value.Equals(Guid.Empty) && ModelState.IsValid)
                    {
                        tblnew.ID = Guid.NewGuid();
                        newsID = tblnew.ID;
                        _nguyenHiepService.InsertNews(tblnew);
                        TempData["Type"] = tblnew.Type;
                        if (!type.HasValue)
                            type = (byte)NguyenHiep.Common.NewsTypes.News;
                        if (type == NguyenHiep.Common.NewsTypes.News)
                        {
                            return RedirectToAction("IndexForNews");
                        }
                        else if (type == NguyenHiep.Common.NewsTypes.Contruction)
                        {
                            return RedirectToAction("IndexForContruction");
                        }
                        else if (type == NguyenHiep.Common.NewsTypes.HotNew)
                        {
                            return RedirectToAction("ViewHotNew");
                        }
                        else if (type == NguyenHiep.Common.NewsTypes.Introduction)
                        {
                            return RedirectToAction("IndexForIntroduction");
                        }
                        else if (type == NguyenHiep.Common.NewsTypes.Recruitment)
                        {
                            return RedirectToAction("IndexForRecruitment");
                        }
                        else if (type == NguyenHiep.Common.NewsTypes.PromotionNew)
                        {
                            return RedirectToAction("IndexForNews");
                        }
                    }
                    else if (newsID.HasValue && !newsID.Value.Equals(Guid.Empty) && ModelState.IsValid)
                    {
                        tblnew.ID = (Guid)newsID;
                        _nguyenHiepService.UpdateNews(tblnew);
                        TempData["NewsID"] = newsID;
                        TempData["Type"] = tblnew.Type;
                        if (tblnew.Type == NguyenHiep.Common.NewsTypes.News)
                        {
                            return RedirectToAction("ViewNews");
                        }
                        else if (tblnew.Type == NguyenHiep.Common.NewsTypes.Contruction)
                        {
                            return RedirectToAction("ViewNews");
                        }
                        else if (tblnew.Type == NguyenHiep.Common.NewsTypes.HotNew)
                        {
                            return RedirectToAction("ViewHotNew");
                        }
                        else if (tblnew.Type == NguyenHiep.Common.NewsTypes.Introduction)
                        {
                            return RedirectToAction("IndexForIntroduction");
                        }
                        else if (tblnew.Type == NguyenHiep.Common.NewsTypes.Recruitment)
                        {
                            return RedirectToAction("IndexForRecruitment");
                        }
                        else if (type == NguyenHiep.Common.NewsTypes.PromotionNew)
                        {
                            return RedirectToAction("ViewNews");
                        }
                    }
                }
            }
            else
            {
                if (tmpType == NguyenHiep.Common.NewsTypes.Recruitment || tmpType == NguyenHiep.Common.NewsTypes.Introduction)
                {
                    if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                    {
                        if (String.IsNullOrEmpty(tblnew.ContentEN))
                        {
                            ModelState.AddModelError("ContentEN", "Content field is required");
                        }
                        else if (tblnew.ContentEN.Length >= 4000)
                        {
                            ModelState.AddModelError("ContentEN", "Input no more than 4000 characters");
                        }

                        
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(tblnew.ContentVN))
                        {
                            ModelState.AddModelError("ContentVN", "Cần nhập nội dung");
                        }
                        else if (tblnew.ContentVN.Length >= 4000)
                        {
                            ModelState.AddModelError("ContentVN", "Tiêu đề nhập không quá 4000 ký tự");
                        }
                    }
                    
                }
                if (newsID.HasValue && !newsID.Value.Equals(Guid.Empty) && ModelState.IsValid)
                {
                    tblnew.ID = (Guid)newsID;
                        _nguyenHiepService.UpdateNews(tblnew);
                        if (tmpType == NguyenHiep.Common.NewsTypes.Recruitment)
                        {
                            return RedirectToAction("IndexForRecruitment");
                        }
                        else if (tmpType == NguyenHiep.Common.NewsTypes.Introduction)
                        {
                            return RedirectToAction("IndexForIntroduction");
                        }
                } if (!newsID.HasValue || newsID.Value.Equals(Guid.Empty) && ModelState.IsValid)
                {
                    tblnew.ID = Guid.NewGuid();
                    newsID = tblnew.ID;
                    tblnew.CreatedDate = DateTime.Now;
                    _nguyenHiepService.InsertNews(tblnew);
                    return RedirectToAction("IndexForRecruitment");

                }
            }
            List<SelectListItem> lsEN = new List<SelectListItem>();
            List<SelectListItem> lsVN = new List<SelectListItem>();
            #region Edit
            if (newsID.HasValue && !newsID.Equals(Guid.Empty) && tblnew != null)
            {
                if (tblnew.Type.HasValue && tblnew.Type.Value == NewsTypes.News)
                {
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString(), Selected = false }));

                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString(), Selected = false }));

                }
                else if (tblnew.Type.HasValue && tblnew.Type.Value == NewsTypes.Contruction)
                {
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString(), Selected = false }));

                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString(), Selected = false }));

                }
                else if (tblnew.Type.HasValue && tblnew.Type.Value == NewsTypes.HotNew)
                {
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString(), Selected = false }));

                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString(), Selected = false }));
                }
                else if (tblnew.Type.HasValue && tblnew.Type.Value == NewsTypes.Introduction)
                {
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString(), Selected = false }));

                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString(), Selected = false }));
                }
                else if (tblnew.Type.HasValue && tblnew.Type.Value == NewsTypes.NormalProduct)
                {
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString(), Selected = false }));


                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString(), Selected = false }));
                }
                else if (tblnew.Type.HasValue && tblnew.Type.Value == NewsTypes.PromotionNew)
                {
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString(), Selected = false }));

                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString(), Selected = false }));
                }
                else if (tblnew.Type.HasValue && tblnew.Type.Value == NewsTypes.Recruitment)
                {
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));

                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));

                }
                if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                {
                    ViewData["Type"] = lsEN;
                    ViewData["ContentVN"] = tblnew.ContentEN;
                }
                else
                {
                    ViewData["Type"] = lsVN;
                    ViewData["ContentVN"] = tblnew.ContentVN;
                }


                
                ViewData["command"] = "upload";
            }
            else
            #endregion
                #region Add
                if (type.HasValue && type.Value == NewsTypes.News)
                {
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString() }));
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString() }));

                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString(), Selected = true }));
                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString() }));
                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString() }));

                }
                else
                    if (type.HasValue && type.Value == NewsTypes.Contruction)
                    {
                        lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString(), Selected = true }));
                        lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString() }));

                        lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString(), Selected = true }));
                        lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString() }));

                    }
                    else if (type.HasValue && type.Value == NewsTypes.HotNew)
                    {
                        lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString(), Selected = true }));
                        lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString() }));

                        lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString(), Selected = true }));
                        lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString() }));
                    }
                    else if (type.HasValue && type.Value == NewsTypes.Introduction)
                    {
                        lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString(), Selected = true }));
                        lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString() }));

                        lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString(), Selected = true }));
                        lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString() }));
                    }
                    else if (type.HasValue && type.Value == NewsTypes.NormalProduct)
                    {
                        lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString(), Selected = true }));
                        lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString() }));

                        lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString(), Selected = true }));
                        lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString() }));
                    }
                    else if (type.HasValue && type.Value == NewsTypes.PromotionNew)
                    {
                        lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString(), Selected = true }));
                        lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString() }));

                        lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString(), Selected = true }));
                        lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString() }));
                    }
                    else if (type.HasValue && type.Value == NewsTypes.Recruitment)
                    {
                        lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString(), Selected = true }));
                        lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString() }));
                        lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString(), Selected = true }));


                        lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString(), Selected = true }));
                        lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString() }));
                        lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString() }));



                    }
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                ViewData["Type"] = lsEN;
            }
            else
            {
                ViewData["Type"] = lsVN;
            }
            ViewData["AddNews"] = true;
            //tblnew = new tblNew();
                #endregion
            if (newsID == null)
            {
                ViewData["AddNews"] = true;
            }
            return View(tblnew);
        }

        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditProduct(Guid? newsID, [Bind(Exclude = "ID,StoreStatus")] tblProduct tblproduct)
        {
            if (tblproduct != null && !string.IsNullOrEmpty(tblproduct.Description))
            {
                ViewData["Description"] = tblproduct.Description;
            }
            
            List<SelectListItem> categories = new List<SelectListItem>();
            List<tblCategory> listCategory = new List<tblCategory>();
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listCategory = _nguyenHiepService.GetAllCategory(true);
            }
            else
            {
                listCategory = _nguyenHiepService.GetAllCategory(false);
            }
            
            List<SelectListItem> storeStatusVN = new List<SelectListItem>();
            List<SelectListItem> storeStatusEN = new List<SelectListItem>();
            List<SelectListItem> promotionVN = new List<SelectListItem>();
            List<SelectListItem> promotionEN = new List<SelectListItem>();
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                
                if (String.IsNullOrEmpty(tblproduct.ProductNameEN))
                {
                    ModelState.AddModelError("ProductNameEN", "Product name field is required");
                }
                else if (tblproduct.ProductNameEN.Length >= 100)
                {
                    ModelState.AddModelError("ProductNameEN", "Input no more than 100 characters");
                }
                if (String.IsNullOrEmpty(tblproduct.WarrantyTime) && tblproduct.WarrantyTime.Length >= 25)
                {
                    ModelState.AddModelError("WarrantyTime", "Input no more than 25 characters");
                }
                if (String.IsNullOrEmpty(tblproduct.Property))
                {
                    ModelState.AddModelError("Property", "Property field is required");
                }
                else if (tblproduct.Property.Length > 250)
                {
                    ModelState.AddModelError("Property", "Input no more than 250 characters");
                }
                if (String.IsNullOrEmpty(tblproduct.Description))
                {
                    ModelState.AddModelError("Description", "Description field is required");
                }
                else if (tblproduct.Description.Length > 4000)
                {
                    ModelState.AddModelError("Description", "Input no more than 4000 characters");
                }


            }
            else
            {
                if (String.IsNullOrEmpty(tblproduct.ProductNameVN))
                {
                    ModelState.AddModelError("ProductNameVN", "Cần nhập tên sản phẩm");
                }
                else if (tblproduct.ProductNameVN.Length >= 100)
                {
                    ModelState.AddModelError("ProductNameVN", "Không nhập quá 100 ký tự");
                }
                if (String.IsNullOrEmpty(tblproduct.WarrantyTime) && tblproduct.WarrantyTime.Length >= 25)
                {
                    ModelState.AddModelError("WarrantyTime", "Không nhập quá 25 ký tự");
                }
                if (String.IsNullOrEmpty(tblproduct.Property))
                {
                    ModelState.AddModelError("Property", "Cần mô tả ngắn gọn");
                }
                else if (tblproduct.Property.Length > 250)
                {
                    ModelState.AddModelError("Property", "Không nhập quá 250 ký tự");
                }
                if (String.IsNullOrEmpty(tblproduct.Description))
                {
                    ModelState.AddModelError("Description", "Cần nhập chi tiết ");
                }
                else if (tblproduct.Description.Length > 4000)
                {
                    ModelState.AddModelError("Description", "Không nhập quá 4000 ký tự");
                }
            }
            string pathFolder = Server.MapPath(ConfigurationManager.AppSettings["ImagesNews"]);
            bool flag = false;
            if (!Directory.Exists(pathFolder)) Directory.CreateDirectory(pathFolder);

            foreach (string inputTagName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[inputTagName];

                if (newsID != null && !newsID.Value.Equals(Guid.Empty) && ModelState.IsValid)
                {
                    tblproduct.ID = (Guid)newsID;
                    string pathImage;
                    if (file != null && Utility.File.File.SaveFile(file, out pathImage, (Guid)newsID, pathFolder))
                    {
                        flag = true;
                        tblproduct.Image = pathImage;

                    }
                    if (tblproduct != null && String.IsNullOrEmpty(tblproduct.Image))
                    {
                        if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                        {
                            ModelState.AddModelError("Image", "This image is not support or  haven't pick up");
                        }
                        else
                        {
                            ModelState.AddModelError("Image", "Định dạng hình ảnh này không trợ giúp hoặc chưa chọn");
                        }
                    }
                    if (ModelState.IsValid)
                    {
                        _nguyenHiepService.UpdateProduct(tblproduct);
                        TempData["ProductID"] = newsID;
                        return RedirectToAction("ViewProduct");
                    }
                    else
                    {
                        foreach (tblCategory cat in listCategory)
                        {
                            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                            {
                                categories.Add(new SelectListItem { Text = cat.CategoryNameEN, Value = cat.ID.ToString() });
                            }
                            else
                            {
                                categories.Add(new SelectListItem { Text = cat.CategoryNameVN, Value = cat.ID.ToString() });
                            }
                            
                        }
                        storeStatusVN.Add((new SelectListItem { Text = "Còn hàng", Value = StoreStatuses.Exhausted.ToString() }));
                        storeStatusVN.Add((new SelectListItem { Text = "Hết hàng", Value = StoreStatuses.NotExhausted.ToString() }));
                        storeStatusEN.Add((new SelectListItem { Text = "Available", Value = StoreStatuses.Exhausted.ToString() }));
                        storeStatusEN.Add((new SelectListItem { Text = "Not Available", Value = StoreStatuses.NotExhausted.ToString() }));


                        promotionVN.Add((new SelectListItem { Text = "Có khuyến mãi", Value = StoreStatuses.Exhausted.ToString() }));
                        promotionVN.Add((new SelectListItem { Text = "Không có khuyến mãi", Value = StoreStatuses.NotExhausted.ToString() }));

                        promotionEN.Add((new SelectListItem { Text = "Có khuyến mãi", Value = StoreStatuses.Exhausted.ToString() }));
                        promotionEN.Add((new SelectListItem { Text = "Không có khuyến mãi", Value = StoreStatuses.NotExhausted.ToString() }));
                        if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                        {
                            ViewData["StoreStatus"] = storeStatusEN;

                            ViewData["Promotion"] = promotionEN;
                        }
                        else
                        {
                            ViewData["Promotion"] = promotionVN;
                            ViewData["StoreStatus"] = storeStatusVN;
                        }


                        ViewData["Categories"] = categories;
                        if (newsID == null)
                        {
                            ViewData["AddNews"] = true;
                        }
                        return View(tblproduct);
                    }
                }
                else if ((newsID == null || newsID.Value.Equals(Guid.Empty)) && ModelState.IsValid)
                {
                    flag = true;
                    tblproduct.ID = Guid.NewGuid();
                    newsID = tblproduct.ID;
                    string pathImage;
                    if (file != null && Utility.File.File.SaveFile(file, out pathImage, (Guid)newsID, pathFolder))
                    {
                        tblproduct.Image = pathImage;

                    }
                    if (tblproduct != null && String.IsNullOrEmpty(tblproduct.Image))
                    {
                        if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                        {
                            ModelState.AddModelError("Image", "This image is not support or  haven't pick up");
                        }
                        else
                        {
                            ModelState.AddModelError("Image", "Định dạng hình ảnh này không trợ giúp hoặc chưa chọn");
                        }
                    }
                    if (ModelState.IsValid)
                    {
                        _nguyenHiepService.InsertProduct(tblproduct);
                        return RedirectToAction("IndexForProduct");
                    }
                    else 
                    {
                        
                        foreach (tblCategory cat in listCategory)
                        {
                            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                            {
                                categories.Add(new SelectListItem { Text = cat.CategoryNameEN, Value = cat.ID.ToString() });
                            }
                            else
                            {
                                categories.Add(new SelectListItem { Text = cat.CategoryNameVN, Value = cat.ID.ToString() });
                            }
                        }
                        storeStatusVN.Add((new SelectListItem { Text = "Còn hàng", Value = StoreStatuses.Exhausted.ToString() }));
                        storeStatusVN.Add((new SelectListItem { Text = "Hết hàng", Value = StoreStatuses.NotExhausted.ToString() }));
                        storeStatusEN.Add((new SelectListItem { Text = "Available", Value = StoreStatuses.Exhausted.ToString() }));
                        storeStatusEN.Add((new SelectListItem { Text = "Not Available", Value = StoreStatuses.NotExhausted.ToString() }));


                        promotionVN.Add((new SelectListItem { Text = "Có khuyến mãi", Value = StoreStatuses.Exhausted.ToString() }));
                        promotionVN.Add((new SelectListItem { Text = "Không có khuyến mãi", Value = StoreStatuses.NotExhausted.ToString() }));

                        promotionEN.Add((new SelectListItem { Text = "Có khuyến mãi", Value = StoreStatuses.Exhausted.ToString() }));
                        promotionEN.Add((new SelectListItem { Text = "Không có khuyến mãi", Value = StoreStatuses.NotExhausted.ToString() }));
                        if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                        {
                            ViewData["StoreStatus"] = storeStatusEN;

                            ViewData["Promotion"] = promotionEN;
                        }
                        else
                        {
                            ViewData["Promotion"] = promotionVN;
                            ViewData["StoreStatus"] = storeStatusVN;
                        }


                        ViewData["Categories"] = categories;
                        if (newsID == null)
                        {
                            ViewData["AddNews"] = true;
                        }
                        return View(tblproduct);
                    }
                    

                }

            }
            
            
            
            foreach (tblCategory cat in listCategory)
            {
                if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                {
                    categories.Add(new SelectListItem { Text = cat.CategoryNameEN, Value = cat.ID.ToString() });
                }
                else
                {
                    categories.Add(new SelectListItem { Text = cat.CategoryNameVN, Value = cat.ID.ToString() });
                }
            }
            
            storeStatusVN.Add((new SelectListItem { Text = "Còn hàng", Value = StoreStatuses.Exhausted.ToString() }));
            storeStatusVN.Add((new SelectListItem { Text = "Hết hàng", Value = StoreStatuses.NotExhausted.ToString() }));
            
            storeStatusEN.Add((new SelectListItem { Text = "Available", Value = StoreStatuses.Exhausted.ToString() }));
            storeStatusEN.Add((new SelectListItem { Text = "Not Available", Value = StoreStatuses.NotExhausted.ToString() }));


            
            promotionVN.Add((new SelectListItem { Text = "Có khuyến mãi", Value = StoreStatuses.Exhausted.ToString() }));
            promotionVN.Add((new SelectListItem { Text = "Không có khuyến mãi", Value = StoreStatuses.NotExhausted.ToString() }));

            
            promotionEN.Add((new SelectListItem { Text = "Có khuyến mãi", Value = StoreStatuses.Exhausted.ToString() }));
            promotionEN.Add((new SelectListItem { Text = "Không có khuyến mãi", Value = StoreStatuses.NotExhausted.ToString() }));
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                ViewData["StoreStatus"] = storeStatusEN;

                ViewData["Promotion"] = promotionEN;
            }
            else
            {
                ViewData["Promotion"] = promotionVN;
                ViewData["StoreStatus"] = storeStatusVN;
            }


            ViewData["Categories"] = categories;
            if (newsID == null)
            {
                ViewData["AddNews"] = true;
            }
            return View(tblproduct);
        }
        public ActionResult EditContact(Guid? newsID)
        {
            tblInformation contact = new tblInformation();
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                contact = _nguyenHiepService.GetInformation(true);
                if (contact != null)
                {
                    ViewData["ContactEN"] = contact.ContactEN;
                }
                
            }
            else
            {
                contact = _nguyenHiepService.GetInformation(false);
                if (contact != null)
                {
                    ViewData["ContactVN"] = contact.ContactVN;
                }
            }
            return View(contact);
        }
        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditContact(Guid? newsID, [Bind(Exclude = "ID")] tblInformation tblinfor)
        {
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                if (tblinfor == null || string.IsNullOrEmpty(tblinfor.ContactEN))
                {
                    ModelState.AddModelError("ContactEN", "Contact field is required");
                }
                else if (tblinfor != null && tblinfor.ContactEN.Length >= 250)
                {
                    ModelState.AddModelError("ContactEN", "Input no more than 250 characters");
                }
            }
            else
            {
                if (tblinfor == null || string.IsNullOrEmpty(tblinfor.ContactEN))
                {
                    ModelState.AddModelError("ContactVN", "Cần nhập thông tin");
                }
                else if (tblinfor != null && tblinfor.ContactEN.Length >= 250)
                {
                    ModelState.AddModelError("ContactEN", "Nhập không quá 250 ký tự");
                }
            }

            if (newsID.HasValue && !newsID.Value.Equals(Guid.Empty) && ModelState.IsValid)
            {
                
                if (tblinfor != null && ModelState.IsValid)
                {
                    tblinfor.ID = (Guid)newsID;
                    tblinfor.ContactVN = tblinfor.ContactVN;
                    tblinfor.ContactEN = tblinfor.ContactEN;
                    if (_nguyenHiepService.UpdateInformation(tblinfor))
                    {
                        return RedirectToAction("IndexForContact");
                    }
                }
            }
            else if((!newsID.HasValue || newsID.Value.Equals(Guid.Empty)) && ModelState.IsValid) 
            {
                if (tblinfor != null)
                {
                    tblinfor.ID = Guid.NewGuid();
                    tblinfor.CreatedDate = DateTime.Now;
                    if (_nguyenHiepService.InsertInformation(tblinfor))
                    {
                        return RedirectToAction("IndexForContact");
                    }
                }
            }
            
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {

                if (tblinfor != null)
                {
                    ViewData["ContactEN"] = tblinfor.ContactEN;
                }

            }
            else
            {
                if (tblinfor != null)
                {
                    ViewData["ContactVN"] = tblinfor.ContactVN;
                }
            }
            return View(tblinfor);

        }
        public ActionResult ViewRecruitment(byte? type)
        {
            ViewData["Type"] = type;
            tblNew recruitment = _nguyenHiepService.GetSpecialNew(NguyenHiep.Common.NewsTypes.Recruitment);
            return View(recruitment);
        }
        public ActionResult ViewIntroduction(byte? type)
        {
            ViewData["Type"] = type;
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

        public ActionResult SetCulture(string id)
        {

            HttpCookie userCookie = Request.Cookies["Culture"];

            userCookie.Value = id;
            userCookie.Expires = DateTime.Now.AddYears(100);
            Response.SetCookie(userCookie);

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}
