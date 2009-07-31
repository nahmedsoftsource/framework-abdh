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
        public ActionResult IndexForNews(int? pageSize, int? page)
        {
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.News;

            SearchResult<tblNew> listAllNews = _nguyenHiepService.GetAllNews((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.News, false);
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
            tblInformation contact = _nguyenHiepService.GetInformation();
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
        public ActionResult ListCategory(int? pageSize, int? page)
        {
            SearchResult<tblCategory> listAllCategory = _nguyenHiepService.GetAllCategory((pageSize.HasValue ? (int)pageSize : NguyenHiep.Common.Constants.DefautPagingSize), (page.HasValue ? (int)page : 1));
            return View(listAllCategory);
        }
        public ActionResult EditNews(Guid? newsID, byte? type)
        {
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
                    ViewData["ContentVN"] = tblnew.ContentEN;
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
        public ActionResult EditProduct(Guid? newsID, byte? type)
        {
            ViewData["Type"] = type;

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
                    }

                }

            }

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
                if (!newsID.HasValue || newsID.Value.Equals(Guid.Empty))
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
                }
                else if (newsID.HasValue && !newsID.Value.Equals(Guid.Empty))
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
            tblnew = new tblNew();
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
            int counter = 0;
            List<SelectListItem> categories = new List<SelectListItem>();
            List<tblCategory> listCategory = _nguyenHiepService.GetAllCategory();
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
                        counter = 0;
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
                        
                        counter = 0;
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
            
            
            
            counter = 0;
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
