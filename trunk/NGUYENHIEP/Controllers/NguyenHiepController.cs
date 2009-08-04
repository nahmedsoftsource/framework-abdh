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
using NGUYENHIEP.Infrastructure;
using System.Text;
using System.Text.RegularExpressions;

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
            SearchResult<tblNew> listAllNews = new SearchResult<tblNew>();
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.News;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = _nguyenHiepService.GetAllNews(NguyenHiep.Common.Constants.DefautPagingSizeForNews,1, NguyenHiep.Common.NewsTypes.News, true);
            }
            else
            {
                listAllNews = _nguyenHiepService.GetAllNews(NguyenHiep.Common.Constants.DefautPagingSizeForNews, 1, NguyenHiep.Common.NewsTypes.News, false);
            }
            return View(listAllNews);
        }
        public ActionResult IndexForPromotionNews(int? pageSize, int? page)
        {
            SearchResult<tblNew> listAllNews = new SearchResult<tblNew>();
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.PromotionNew;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = _nguyenHiepService.GetAllNews(NguyenHiep.Common.Constants.DefautPagingSizeForCategory, (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.PromotionNew, true);
            }
            else
            {
                listAllNews = _nguyenHiepService.GetAllNews(NguyenHiep.Common.Constants.DefautPagingSizeForCategory, (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.PromotionNew, false);
            }
            return View(listAllNews);
        }
        public ActionResult ListPromotionNews(int? pageSize, int? page)
        {
            SearchResult<tblNew> listAllNews = new SearchResult<tblNew>();
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.PromotionNew;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = _nguyenHiepService.GetAllNews(NguyenHiep.Common.Constants.DefautPagingSizeForCategory, (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.PromotionNew, true);
            }
            else
            {
                listAllNews = _nguyenHiepService.GetAllNews(NguyenHiep.Common.Constants.DefautPagingSizeForCategory, (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.PromotionNew, false);
            }
            return View(listAllNews);
        }
        public ActionResult IndexForNews(int? pageSize, int? page)
        {
            SearchResult<tblNew> listAllNews = new SearchResult<tblNew>();
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.News;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = _nguyenHiepService.GetAllNews(NguyenHiep.Common.Constants.DefautPagingSizeForNews, (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.News, true);
            }
            else
            {
                listAllNews = _nguyenHiepService.GetAllNews(NguyenHiep.Common.Constants.DefautPagingSizeForNews, (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.News, false);
            }
            return View(listAllNews);
        }
        public ActionResult IndexForRecruitment()
        {
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.Recruitment;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                tblNew recruitment = _nguyenHiepService.GetSpecialNew(NguyenHiep.Common.NewsTypes.Recruitment,true);
                return View(recruitment);
            }
            else
            {
                tblNew recruitment = _nguyenHiepService.GetSpecialNew(NguyenHiep.Common.NewsTypes.Recruitment, false);
                return View(recruitment);
            }
        }

        public ActionResult IndexForContact()
        {
            tblInformation contact = new tblInformation();
            ViewData["Department"] = LoadDataForDropDownList();
            if(TempData["Message"] != null)
            {
                ViewData["Message"] = TempData["Message"];
            }
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
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                tblNew introduction = _nguyenHiepService.GetSpecialNew(NguyenHiep.Common.NewsTypes.Introduction,true);
                return View(introduction);
            }
            else
            {
                tblNew introduction = _nguyenHiepService.GetSpecialNew(NguyenHiep.Common.NewsTypes.Introduction,false);
                return View(introduction);
            }
        }
        public ActionResult IndexForContruction(int? pageSize, int? page)
        {
            SearchResult<tblNew> listAllNews = new SearchResult<tblNew>();
            ViewData["TypeNews"] = NguyenHiep.Common.NewsTypes.Contruction;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = _nguyenHiepService.GetAllNews(NguyenHiep.Common.Constants.DefautPagingSizeForContructionImages, (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.Contruction, true);
            }
            else
            {
                listAllNews = _nguyenHiepService.GetAllNews(NguyenHiep.Common.Constants.DefautPagingSizeForContructionImages, (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.Contruction, false);
            }
            return View(listAllNews);
        }
        public ActionResult IndexForProduct(int? pageSize, int? page)
        {
            SearchResult<tblProduct> listAllNews = new SearchResult<tblProduct>();
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.NormalProduct;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = _nguyenHiepService.GetAllProduct(NguyenHiep.Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1),true);
            }
            else
            {
                listAllNews = _nguyenHiepService.GetAllProduct(NguyenHiep.Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), false);
            }
            return View(listAllNews);
        }
        public ActionResult ViewNews(Guid? newsID,byte? typeNews)
        {
            ViewData["TypeNews"] = typeNews;
            if (!typeNews.HasValue)
            {
                typeNews = (byte)NguyenHiep.Common.NewsTypes.News;
            }
            if (newsID != null && !newsID.Equals(Guid.Empty))
            {
                if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                {
                    tblNew tblnews = _nguyenHiepService.GetNewsByID((Guid)newsID,true);
                    return View(tblnews);
                }
                else
                {
                    tblNew tblnews = _nguyenHiepService.GetNewsByID((Guid)newsID,false);
                    return View(tblnews);
                }
            }
            else if (TempData["NewsID"] != null)
            {
                if (TempData["Type"] == null)
                    typeNews = (byte)NguyenHiep.Common.NewsTypes.News;
                else
                    typeNews = (byte)TempData["Type"];
                if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                {
                    tblNew tblnews = _nguyenHiepService.GetNewsByID((Guid)TempData["NewsID"],true);
                    return View(tblnews);
                }
                else 
                {
                    tblNew tblnews = _nguyenHiepService.GetNewsByID((Guid)TempData["NewsID"],false);
                    return View(tblnews);

                }
            }
            return new EmptyResult();
        }
        public ActionResult ViewProduct(Guid? newsID, byte? type)
        {
            ViewData["Type"] = type;
            if (newsID != null && !newsID.Equals(Guid.Empty))
            {
                if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                {
                    tblProduct tblproduct = _nguyenHiepService.GetProductByID((Guid)newsID,true);
                    return View(tblproduct);
                }
                else
                {
                    tblProduct tblproduct = _nguyenHiepService.GetProductByID((Guid)newsID,false);
                    return View(tblproduct);
                }
                
            }
            else if (TempData["ProductID"] != null)
            {
                if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                {
                    tblProduct tblproduct = _nguyenHiepService.GetProductByID((Guid)TempData["ProductID"],true);
                    return View(tblproduct);
                }
                else
                {
                    tblProduct tblproduct = _nguyenHiepService.GetProductByID((Guid)TempData["ProductID"],false);
                    return View(tblproduct);
                }
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
                listAllNews = _nguyenHiepService.GetAllNews(NguyenHiep.Common.Constants.DefautPagingSizeForNews, (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.News, true);
            }
            else
            {
                listAllNews = _nguyenHiepService.GetAllNews(NguyenHiep.Common.Constants.DefautPagingSizeForNews, (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.News, false);
            }
            return View(listAllNews);
        }
        public ActionResult ListHotNews(int? pageSize, int? page)
        {
            SearchResult<tblNew> listAllNews = new SearchResult<tblNew>();
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.HotNew;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = _nguyenHiepService.GetAllNews(NguyenHiep.Common.Constants.DefautPagingSizeForHotNew, (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.HotNew, true);
            }
            else
            {
                listAllNews = _nguyenHiepService.GetAllNews(NguyenHiep.Common.Constants.DefautPagingSizeForHotNew, (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.HotNew, false);
            }
            return View(listAllNews);
        }
        public ActionResult ListAllContruction(int? pageSize, int? page)
        {
            SearchResult<tblNew> listAllNews = new SearchResult<tblNew>();
            ViewData["Type"] = NguyenHiep.Common.NewsTypes.Contruction;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = _nguyenHiepService.GetAllNews(NguyenHiep.Common.Constants.DefautPagingSizeForContructionImages, (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.Contruction, true);
            }
            else
            {
                listAllNews = _nguyenHiepService.GetAllNews(NguyenHiep.Common.Constants.DefautPagingSizeForContructionImages, (page.HasValue ? (int)page : 1), NguyenHiep.Common.NewsTypes.Contruction, false);
            }
            return View(listAllNews);
        }
        public ActionResult ListAllProduct(int? pageSize, int? page)
        {
            SearchResult<tblProduct> listAllNews = new SearchResult<tblProduct>();
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllNews = _nguyenHiepService.GetAllProduct(NguyenHiep.Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1),true);
            }
            else
            {
                listAllNews = _nguyenHiepService.GetAllProduct(NguyenHiep.Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1),false);
            }
            return View(listAllNews);
        }
        public ActionResult IndexForProductByCategory(int? pageSize, int? page, Guid? categoryID)
        {
            SearchResult<tblProduct> listAllNews = new SearchResult<tblProduct>();
            if (TempData["CategoryID"] != null)
            {
                categoryID = (Guid)TempData["CategoryID"];
            }
            if (categoryID.HasValue && !categoryID.Value.Equals(Guid.Empty))
            {
                ViewData["CategoryID"] = categoryID;
                listAllNews = _nguyenHiepService.GetAllProductByCategory(NguyenHiep.Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), (Guid)categoryID);
            }

            return View(listAllNews);
        }
        public ActionResult ListAllProductByCategory(int? pageSize, int? page,Guid? categoryID)
        {
            SearchResult<tblProduct> listAllNews = new SearchResult<tblProduct>();
            if (categoryID.HasValue && !categoryID.Value.Equals(Guid.Empty))
            {
                ViewData["CategoryID"] = categoryID;
                listAllNews = _nguyenHiepService.GetAllProductByCategory(NguyenHiep.Common.Constants.DefautPagingSizeForProduct, (page.HasValue ? (int)page : 1), (Guid)categoryID);
            }
            
            return View(listAllNews);
        }
        public ActionResult ListCategory(int? pageSize, int? page)
        {
            SearchResult<tblCategory> listAllCategory = new SearchResult<tblCategory>();
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                listAllCategory = _nguyenHiepService.GetAllCategory(NguyenHiep.Common.Constants.DefautPagingSizeForCategory, (page.HasValue ? (int)page : 1),true);
            }
            else 
            {
                listAllCategory = _nguyenHiepService.GetAllCategory(NguyenHiep.Common.Constants.DefautPagingSizeForCategory, (page.HasValue ? (int)page : 1),false);
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
            byte tmpType = NguyenHiep.Common.NewsTypes.News;
            if (type.HasValue)
            {
                tmpType = (byte)type;
            }
            #region delete
            if (Request["Delete"] != null)
            {
                if (newsID.HasValue && !newsID.Equals(Guid.Empty))
                {
                    _nguyenHiepService.DeleteNews((Guid)newsID);

                    if (tmpType == NguyenHiep.Common.NewsTypes.News)
                    {
                        return RedirectToAction("IndexForNews");
                    }
                    else if (tmpType == NguyenHiep.Common.NewsTypes.Contruction)
                    {
                        return RedirectToAction("IndexForContruction");
                    }
                    else if (tmpType == NguyenHiep.Common.NewsTypes.HotNew)
                    {
                        return RedirectToAction("IndexForNews");
                    }
                    else if (tmpType == NguyenHiep.Common.NewsTypes.Introduction)
                    {
                        return RedirectToAction("IndexForIntroduction");
                    }
                    else if (tmpType == NguyenHiep.Common.NewsTypes.Recruitment)
                    {
                        return RedirectToAction("IndexForRecruitment");
                    }
                    else if (tmpType == NguyenHiep.Common.NewsTypes.PromotionNew)
                    {
                        return RedirectToAction("IndexForNews");
                    }
                    else
                    {
                        return RedirectToAction("IndexForNews");
                    }
                }
            }
            #endregion
            List<SelectListItem> lsEN = new List<SelectListItem>();
            List<SelectListItem> lsVN = new List<SelectListItem>();
            tblNew tblnew = null;
            if (newsID.HasValue && !newsID.Value.Equals(Guid.Empty))
            {
                if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                {
                    tblnew = _nguyenHiepService.GetNewsByID((Guid)newsID,true);
                }
                else
                {
                    tblnew = _nguyenHiepService.GetNewsByID((Guid)newsID,false);
                }
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
                if (lsVN.Count<=0)
                {
                    lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = true }));
                    lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString(), Selected = false }));

                    lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString(), Selected = true }));
                }
                if (lsEN.Count <= 0)
                {

                    lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString(), Selected = false }));
                    lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString(), Selected = false }));
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
        public ActionResult EditCategory(Guid? categoryID)
        {
            if (Request["Delete"] != null)
            {
                if (categoryID.HasValue && !categoryID.Value.Equals(Guid.Empty))
                {
                    _nguyenHiepService.DeleteCategory((Guid)categoryID);
                    return RedirectToAction("IndexForProduct");
                }
            }
            if (categoryID.HasValue && !categoryID.Value.Equals(Guid.Empty))
            {
                tblCategory tblCategory = new tblCategory();
                if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                {
                    tblCategory = _nguyenHiepService.GetCategoryByID((Guid)categoryID, true);
                }
                else
                {
                    tblCategory = _nguyenHiepService.GetCategoryByID((Guid)categoryID, false);
                }

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
        public ActionResult EditCategory(Guid? categoryID, [Bind(Exclude = "ID")] tblCategory tblcategory, byte? type)
        {
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                if (tblcategory != null && String.IsNullOrEmpty(tblcategory.CategoryNameEN))
                {
                    ModelState.AddModelError("CategoryNameEN", "Category name is required");
                }
                else if (tblcategory != null && tblcategory.CategoryNameEN.Length >= 100)
                {
                    ModelState.AddModelError("CategoryNameEN", "Input no more than 100 characters");
                }
                if (tblcategory != null && !String.IsNullOrEmpty(tblcategory.DescriptionEN) && tblcategory.DescriptionEN.Length >= 250)
                {
                    ModelState.AddModelError("CategoryNameEN", "Input no more than 250 characters");
                }
            }
            else
            {
                if (tblcategory != null && String.IsNullOrEmpty(tblcategory.CategoryNameVN))
                {
                    ModelState.AddModelError("CategoryNameVN", "Cần nhập tên loại sản phẩm");
                }
                else if (tblcategory != null && tblcategory.CategoryNameVN.Length >= 100)
                {
                    ModelState.AddModelError("CategoryNameVN", "Không nhập quá 100 ký tự");
                }
                if (tblcategory != null && !String.IsNullOrEmpty(tblcategory.DescriptionVN) && tblcategory.DescriptionVN.Length >= 250)
                {
                    ModelState.AddModelError("DescriptionVN", "Không nhập quá 250 ký tự");
                }
            }
            if (categoryID.HasValue && !categoryID.Value.Equals(Guid.Empty) && ModelState.IsValid)
            {
                tblcategory.ID = (Guid)categoryID;
                _nguyenHiepService.UpdateCategory(tblcategory);
                TempData["CategoryID"] = categoryID;
                //todo: view one category
                return RedirectToAction("IndexForProductByCategory");
            }
            else if ((!categoryID.HasValue || categoryID.Value.Equals(Guid.Empty)) && ModelState.IsValid)
            {         
                tblcategory.ID = Guid.NewGuid();
                categoryID = tblcategory.ID;

                TempData["CategoryID"] = categoryID;
                _nguyenHiepService.InsertCategory(tblcategory);
                //todo: view one category
                return RedirectToAction("IndexForProductByCategory");
            }


            if (categoryID == null)
            {
                ViewData["AddNews"] = true;
            }

            return View(tblcategory);
        }
        public ActionResult EditProduct(Guid? newsID, byte? type)
        {
            ViewData["Type"] = type;
            byte tmpType = NguyenHiep.Common.NewsTypes.NormalProduct;
            if (type.HasValue)
            {
                tmpType = (byte)type;
            }
            #region delete
            if (Request["Delete"] != null)
            {
                if (newsID.HasValue && !newsID.Equals(Guid.Empty))
                {
                    _nguyenHiepService.DeleteProduct((Guid)newsID);

                    if (tmpType == NguyenHiep.Common.NewsTypes.NormalProduct)
                    {
                        return RedirectToAction("IndexForProduct");
                    }else if (tmpType == NguyenHiep.Common.NewsTypes.PromotionNew)
                    {
                        return RedirectToAction("IndexForPromotionNews");
                    }
                    else
                    {
                        return RedirectToAction("IndexForProduct");
                    }
                }
            }
            #endregion
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
            promotionVN.Add((new SelectListItem { Text = "Không có khuyến mãi", Value = Promoted.NotHas.ToString() }));
            promotionVN.Add((new SelectListItem { Text = "Có khuyến mãi", Value = Promoted.Has.ToString() }));
            

            List<SelectListItem> promotionEN = new List<SelectListItem>();
            promotionEN.Add((new SelectListItem { Text = "Not Promoted", Value = Promoted.NotHas.ToString() }));
            promotionEN.Add((new SelectListItem { Text = "Promoted", Value = Promoted.Has.ToString() }));
            
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
                tblProduct tblproduct = new tblProduct();
                if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                {
                    tblproduct = _nguyenHiepService.GetProductByID((Guid)newsID,true);
                }
                else
                {
                    tblproduct = _nguyenHiepService.GetProductByID((Guid)newsID,false);
                }
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
        public ActionResult EditNews(Guid? newsID, [Bind(Exclude = "ID")] tblNew tblnew, byte? typeNews)
        {
            if (tblnew != null)
            {
                if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                {
                    ViewData["ContentEN"] = tblnew.ContentEN;
                }
                else
                {
                    ViewData["ContentVN"] = tblnew.ContentVN;
                }
            }
            byte tmpType = NguyenHiep.Common.NewsTypes.News;
            if (tblnew.Type.HasValue)
            {
                tmpType = (byte)tblnew.Type;
            }
            else if (typeNews.HasValue)
            {
                tmpType = (byte)typeNews;
            }
            
           
            ViewData["CurrentType"] = tmpType;
            string pathFolder = Server.MapPath(ConfigurationManager.AppSettings["ImagesNews"]);
            string pathFolderThumb = Server.MapPath(ConfigurationManager.AppSettings["ThumbImagesNews"]);
            string pathFolderThumbSmallest = Server.MapPath(ConfigurationManager.AppSettings["ThumbImagesNewsSmallest"]);
            bool flag = false;
            bool insert = false;
            if (!Directory.Exists(pathFolder)) Directory.CreateDirectory(pathFolder);
            if (!Directory.Exists(pathFolderThumb)) Directory.CreateDirectory(pathFolderThumb);
            if (!Directory.Exists(pathFolderThumbSmallest)) Directory.CreateDirectory(pathFolderThumbSmallest);
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
                    else if (tblnew.ContentEN.Length >= 16000)
                    {
                        ModelState.AddModelError("ContentEN", "Input no more than 16000 characters");
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
                    else if (tblnew.ContentVN.Length >= 16000)
                    {
                        ModelState.AddModelError("ContentVN", "Tiêu đề nhập không quá 16000 ký tự");
                    }
                }
                if (file != null && file.ContentLength > 0 && newsID != null && !newsID.Value.Equals(Guid.Empty) && ModelState.IsValid)
                {
                    tblnew.ID = (Guid)newsID;
                    string pathImage;
                    string pathImageThumb;
                    string pathImageThumbSmallest;
                    if (file != null && Utility.File.File.SaveFile(file, out pathImage, out pathImageThumb, out pathImageThumbSmallest, (Guid)newsID, pathFolder, Request.PhysicalApplicationPath))
                    {
                        flag = true;
                        if (tblnew.Type == NguyenHiep.Common.NewsTypes.HotNew)
                        {
                            tblnew.Image = pathImageThumbSmallest;
                        }
                        else
                        {
                            tblnew.Image = pathImageThumb;
                        }
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
                            return RedirectToAction("ViewNews");
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
                    string pathImageThumb;
                    string pathImageThumbSmallest;
                    if (file != null && Utility.File.File.SaveFile(file, out pathImage, out pathImageThumb, out pathImageThumbSmallest, (Guid)newsID, pathFolder, Request.PhysicalApplicationPath))
                    {
                        if (tblnew.Type == NguyenHiep.Common.NewsTypes.HotNew)
                        {
                            tblnew.Image = pathImageThumbSmallest;
                        }
                        else
                        {
                            tblnew.Image = pathImageThumb;
                        }
                        _nguyenHiepService.InsertNews(tblnew);
                        ModelState.Clear();
                        insert = true;
                        TempData["Type"] = tblnew.Type;
                        if (!typeNews.HasValue && !tblnew.Type.HasValue)
                            typeNews = (byte)NguyenHiep.Common.NewsTypes.News;
                        if (typeNews == NguyenHiep.Common.NewsTypes.News)
                        {
                            return RedirectToAction("IndexForNews");
                        }
                        else if (typeNews == NguyenHiep.Common.NewsTypes.Contruction)
                        {
                            return RedirectToAction("IndexForContruction");
                        }
                        else if (typeNews == NguyenHiep.Common.NewsTypes.HotNew)
                        {
                            return RedirectToAction("IndexForNews");
                        }
                        else if (typeNews == NguyenHiep.Common.NewsTypes.Introduction)
                        {
                            return RedirectToAction("IndexForIntroduction");
                        }
                        else if (typeNews == NguyenHiep.Common.NewsTypes.Recruitment)
                        {
                            return RedirectToAction("IndexForRecruitment");
                        }
                        else if (typeNews == NguyenHiep.Common.NewsTypes.PromotionNew)
                        {
                            return RedirectToAction("IndexForNews");
                        }
                    }

                }

            }
            if (tmpType != NguyenHiep.Common.NewsTypes.Recruitment && tmpType != NguyenHiep.Common.NewsTypes.Introduction )
            {
                if (!flag && tblnew != null && String.IsNullOrEmpty(tblnew.Image) )
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
                        if (!typeNews.HasValue && !tblnew.Type.HasValue)
                            typeNews = (byte)NguyenHiep.Common.NewsTypes.News;
                        if (typeNews == NguyenHiep.Common.NewsTypes.News)
                        {
                            return RedirectToAction("IndexForNews");
                        }
                        else if (typeNews == NguyenHiep.Common.NewsTypes.Contruction)
                        {
                            return RedirectToAction("IndexForContruction");
                        }
                        else if (typeNews == NguyenHiep.Common.NewsTypes.HotNew)
                        {
                            return RedirectToAction("IndexForNews");
                        }
                        else if (typeNews == NguyenHiep.Common.NewsTypes.Introduction)
                        {
                            return RedirectToAction("IndexForIntroduction");
                        }
                        else if (typeNews == NguyenHiep.Common.NewsTypes.Recruitment)
                        {
                            return RedirectToAction("IndexForRecruitment");
                        }
                        else if (typeNews == NguyenHiep.Common.NewsTypes.PromotionNew)
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
                            return RedirectToAction("ViewNews");
                        }
                        else if (tblnew.Type == NguyenHiep.Common.NewsTypes.Introduction)
                        {
                            return RedirectToAction("IndexForIntroduction");
                        }
                        else if (tblnew.Type == NguyenHiep.Common.NewsTypes.Recruitment)
                        {
                            return RedirectToAction("IndexForRecruitment");
                        }
                        else if (tblnew.Type == NguyenHiep.Common.NewsTypes.PromotionNew)
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
                        else if (tblnew.ContentEN.Length >= 16000)
                        {
                            ModelState.AddModelError("ContentEN", "Input no more than 16000 characters");
                        }

                        
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(tblnew.ContentVN))
                        {
                            ModelState.AddModelError("ContentVN", "Cần nhập nội dung");
                        }
                        else if (tblnew.ContentVN.Length >= 16000)
                        {
                            ModelState.AddModelError("ContentVN", "Tiêu đề nhập không quá 16000 ký tự");
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
                    if (tmpType == NguyenHiep.Common.NewsTypes.Recruitment)
                    {
                        return RedirectToAction("IndexForRecruitment");
                    }
                    else if (tmpType == NguyenHiep.Common.NewsTypes.Introduction)
                    {
                        return RedirectToAction("IndexForIntroduction");
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
                if (typeNews.HasValue && typeNews.Value == NewsTypes.News)
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
                    if (typeNews.HasValue && typeNews.Value == NewsTypes.Contruction)
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
                    else if (typeNews.HasValue && typeNews.Value == NewsTypes.HotNew)
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
                    else if (typeNews.HasValue && typeNews.Value == NewsTypes.Introduction)
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
                    else if (typeNews.HasValue && typeNews.Value == NewsTypes.NormalProduct)
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
                    else if (typeNews.HasValue && typeNews.Value == NewsTypes.PromotionNew)
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
                    else if (typeNews.HasValue && typeNews.Value == NewsTypes.Recruitment)
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
            if (lsEN.Count <= 0)
            {
                

                lsEN.Add((new SelectListItem { Text = "News", Value = NewsTypes.News.ToString(), Selected = true }));
                lsEN.Add((new SelectListItem { Text = " Construction Images", Value = NewsTypes.Contruction.ToString() }));
                lsEN.Add((new SelectListItem { Text = "Hot New", Value = NewsTypes.HotNew.ToString() }));
                lsEN.Add((new SelectListItem { Text = "About Us", Value = NewsTypes.Introduction.ToString() }));
                lsEN.Add((new SelectListItem { Text = "Products", Value = NewsTypes.NormalProduct.ToString() }));
                lsEN.Add((new SelectListItem { Text = "Promotion Program", Value = NewsTypes.PromotionNew.ToString() }));
                lsEN.Add((new SelectListItem { Text = "Recruitment", Value = NewsTypes.Recruitment.ToString() }));

            }
            if (lsVN.Count <= 0)
            {
                lsVN.Add((new SelectListItem { Text = "Tin Tức", Value = NewsTypes.News.ToString(), Selected = true }));
                lsVN.Add((new SelectListItem { Text = "Công trình", Value = NewsTypes.Contruction.ToString() }));
                lsVN.Add((new SelectListItem { Text = "Tin nóng", Value = NewsTypes.HotNew.ToString() }));
                lsVN.Add((new SelectListItem { Text = "Giới thiệu", Value = NewsTypes.Introduction.ToString() }));
                lsVN.Add((new SelectListItem { Text = "Sản phẩm", Value = NewsTypes.NormalProduct.ToString() }));
                lsVN.Add((new SelectListItem { Text = "Tin tức khuyến mãi", Value = NewsTypes.PromotionNew.ToString() }));
                lsVN.Add((new SelectListItem { Text = "Tuyển dụng", Value = NewsTypes.Recruitment.ToString() }));
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
        public ActionResult EditProduct(Guid? newsID, [Bind(Exclude = "ID")] tblProduct tblproduct)
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
                else if (tblproduct.Description.Length > 16000)
                {
                    ModelState.AddModelError("Description", "Input no more than 16000 characters");
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
                else if (tblproduct.Description.Length > 16000)
                {
                    ModelState.AddModelError("Description", "Không nhập quá 16000 ký tự");
                }
            }
            string pathFolder = Server.MapPath(ConfigurationManager.AppSettings["ImagesNews"]);
            string pathFolderThumb = Server.MapPath(ConfigurationManager.AppSettings["ThumbImagesNews"]);
            string pathFolderThumbSmallest = Server.MapPath(ConfigurationManager.AppSettings["ThumbImagesNewsSmallest"]);
            bool flag = false;
            if (!Directory.Exists(pathFolder)) Directory.CreateDirectory(pathFolder);
            if (!Directory.Exists(pathFolderThumb)) Directory.CreateDirectory(pathFolderThumb);
            if (!Directory.Exists(pathFolderThumbSmallest)) Directory.CreateDirectory(pathFolderThumbSmallest);

            foreach (string inputTagName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[inputTagName];

                if (newsID != null && !newsID.Value.Equals(Guid.Empty) && ModelState.IsValid)
                {
                    tblproduct.ID = (Guid)newsID;
                    string pathImage;
                    string pathImageThumb;
                    string pathImageThumbSmallest;
                    if (file != null && Utility.File.File.SaveFile(file, out pathImage, out pathImageThumb, out pathImageThumbSmallest, (Guid)newsID, pathFolder, Request.PhysicalApplicationPath))
                    {
                        flag = true;
                        tblproduct.Image = pathImageThumb;

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

                        promotionVN.Add((new SelectListItem { Text = "Không có khuyến mãi", Value = Promoted.NotHas.ToString() }));
                        promotionVN.Add((new SelectListItem { Text = "Có khuyến mãi", Value = Promoted.Has.ToString() }));
                        
                        
                        promotionEN.Add((new SelectListItem { Text = "NotPromoted", Value = Promoted.NotHas.ToString() }));
                        promotionEN.Add((new SelectListItem { Text = "Promoted", Value = Promoted.Has.ToString() }));
                        
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
                    string pathImageThumb;
                    string pathImageThumbSmallest;
                    if (file != null && Utility.File.File.SaveFile(file, out pathImage, out pathImageThumb, out pathImageThumbSmallest, (Guid)newsID, pathFolder, Request.PhysicalApplicationPath ))
                    {
                        tblproduct.Image = pathImageThumb;

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

                        promotionVN.Add((new SelectListItem { Text = "Không có khuyến mãi", Value = Promoted.NotHas.ToString() }));
                        promotionVN.Add((new SelectListItem { Text = "Có khuyến mãi", Value = Promoted.Has.ToString() }));
                        

                        promotionEN.Add((new SelectListItem { Text = "Not promoted", Value = Promoted.NotHas.ToString() }));
                        promotionEN.Add((new SelectListItem { Text = "Promoted", Value = Promoted.Has.ToString() }));
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


            promotionVN.Add((new SelectListItem { Text = "Không có khuyến mãi", Value = Promoted.NotHas.ToString() }));
            promotionVN.Add((new SelectListItem { Text = "Có khuyến mãi", Value = Promoted.Has.ToString() }));
            


            promotionEN.Add((new SelectListItem { Text = "Not Promoted", Value = Promoted.NotHas.ToString() }));
            promotionEN.Add((new SelectListItem { Text = "Promoted", Value = Promoted.Has.ToString() }));
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
                if (tblinfor == null || string.IsNullOrEmpty(tblinfor.ContactVN))
                {
                    ModelState.AddModelError("ContactVN", "Cần nhập thông tin");
                }
                else if (tblinfor != null && tblinfor.ContactVN.Length >= 250)
                {
                    ModelState.AddModelError("ContactVN", "Nhập không quá 250 ký tự");
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
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                tblNew recruitment = _nguyenHiepService.GetSpecialNew(NguyenHiep.Common.NewsTypes.Recruitment,true);
                return View(recruitment);
            }
            else
            {
                tblNew recruitment = _nguyenHiepService.GetSpecialNew(NguyenHiep.Common.NewsTypes.Recruitment,false);
                return View(recruitment);
            }
        }
        public ActionResult ViewIntroduction(byte? type)
        {
            ViewData["Type"] = type;
            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
            {
                tblNew introduction = _nguyenHiepService.GetSpecialNew(NguyenHiep.Common.NewsTypes.Introduction,true);
                return View(introduction);
            }
            else
            {
                tblNew introduction = _nguyenHiepService.GetSpecialNew(NguyenHiep.Common.NewsTypes.Introduction,false);
                return View(introduction);
            }
        }
       
       

        public ActionResult SetCulture(string id)
        {

            HttpCookie userCookie = Request.Cookies["Culture"];

            userCookie.Value = id;
            userCookie.Expires = DateTime.Now.AddYears(100);
            Response.SetCookie(userCookie);

            return Redirect(Request.UrlReferrer.ToString());
        }
        #region Send Email
        private List<SelectListItem> LoadDataForDropDownList()
        {
            List<SelectListItem> lsEN = new List<SelectListItem>();
            List<SelectListItem> lsVN = new List<SelectListItem>();

            lsVN.Add((new SelectListItem { Text = "Ban giám đốc", Value = Department.Managers.ToString(), Selected = true }));
            lsVN.Add((new SelectListItem { Text = "Phòng kỹ thuật", Value = Department.Techonology.ToString(), Selected = false }));
            lsVN.Add((new SelectListItem { Text = "Phòng marketing", Value = Department.Marketing.ToString(), Selected = false }));
            lsVN.Add((new SelectListItem { Text = "Phòng kinh doanh", Value = Department.Sales.ToString(), Selected = false }));
            lsVN.Add((new SelectListItem { Text = "Phòng kế toán", Value = Department.Accounts.ToString(), Selected = false }));

            lsEN.Add((new SelectListItem { Text = "Managers Department", Value = Department.Managers.ToString(), Selected = true }));
            lsEN.Add((new SelectListItem { Text = "Technology Department", Value = Department.Techonology.ToString(), Selected = false }));
            lsEN.Add((new SelectListItem { Text = "Marketing Department", Value = Department.Marketing.ToString(), Selected = false }));
            lsEN.Add((new SelectListItem { Text = "Sales Department", Value = Department.Sales.ToString(), Selected = false }));
            lsEN.Add((new SelectListItem { Text = "Accounts Department", Value = Department.Accounts.ToString(), Selected = false }));

            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                return lsEN;
            else
                return lsVN;

        }
    [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Send()
        {
           //Step 1: Insert to tblEmail
            bool isValid = true;
            tblEmail email = new tblEmail();
            email.ID = Guid.NewGuid();
            if (Request["sender"] != null && !String.IsNullOrEmpty(Request["sender"]))
            {
                email.Sender = Request["sender"].ToString();
            }
            else
            {
                isValid = false;
                if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                {
                    TempData["Sender"] = "Please enter Sender";
                }
                else
                {
                    TempData["Sender"] = "Cần nhập người gửi";
                }
            }
            if (Request["email"] != null && !String.IsNullOrEmpty(Request["email"]))
            {
              email.Email = Request["email"].ToString();
              if (!isEmail(email.Email))
              {
                isValid = false;
                if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                {
                  TempData["EmailInvalid"] = "Email is invalid";
                }
                else
                {
                  TempData["EmailInvalid"] = "Email không hợp lệ";
                }
              }
               
            }
            else
            {
              isValid = false;
              if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
              {
                TempData["EmailInvalid"] = "Email is invalid";
              }
              else
              {
                TempData["EmailInvalid"] = "Email không hợp lệ";
              }
            }
            email.SendDate = DateTime.Now;
            if (Request["department"] != null)
            {
                email.SendTo = byte.Parse(Request["department"].ToString());
            }
            if (Request["title"] != null && !String.IsNullOrEmpty(Request["title"]))
            {
                email.Title = Request["title"].ToString();
            }
            else 
            {
                isValid = false;
                if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                {
                    TempData["Title"] = "Please enter Title";
                }
                else
                {
                    TempData["Title"] = "Cần nhập tiêu đề";
                }
            }
            if (Request["content"] != null && !String.IsNullOrEmpty(Request["content"]))
            {
                email.Content = Request["content"].ToString();
            }
            else
            {
                isValid = false;
                if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                {
                    TempData["Content"] = "Please enter Content";
                }
                else
                {
                    TempData["Content"] = "Cần nhập nội dung";
                }
            }
            
            if (isValid &&  _nguyenHiepService.InsertEmail(email))
            {
                //Step 2: Send Email
                List<tblUser> allUser = new List<tblUser>();
                allUser = _nguyenHiepService.GetUserByDepartment(byte.Parse(Request["department"].ToString()));
                /*Hung implement sending mail by SMTP via google*/
                #region Send mail
                //set up SMTP client
                SmtpClient smpt = new SmtpClient("smtp.gmail.com", 587);
                string mailFromAccount = "admin.nguyen.hiep@gmail.com";
                string mailFromPass = "nguyenhiep123";
                smpt.UseDefaultCredentials = false;
                NetworkCredential cred = new NetworkCredential(mailFromAccount, mailFromPass);
                smpt.Credentials = cred; 
                smpt.EnableSsl = true;
                smpt.Timeout = 20000;

                //Build up email message
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("admin.nguyen.hiep@gmail.com", "Nguyen Hiep site Admin");
                if (allUser != null && allUser.Count > 0)
                {
                    foreach (tblUser user in allUser)
                    {
                        if (user.Email != null)
                        {
                            mail.To.Add(user.Email);
                        }
                    }
                }
                mail.Subject = email.Title;
                mail.Body = String.Format("<b>Customer Name:</b> {0} <br/><b>Date:</b> {1}<br/> <b>From email address:</b> {2}<br/> <b>Person in charge:</b> {3}<br/><br/> <b>Content detail:<b><br/><hr> {4}",
                                     email.Sender, email.SendDate, email.Email, Request["departmentname"].ToString(), email.Content);
                mail.IsBodyHtml = true;
                mail.BodyEncoding = Encoding.UTF8;
                #endregion Send mail
                try
                {
                    if (mail.From != null && !String.IsNullOrEmpty(mail.From.Address) && mail.To != null && mail.To.ToList().Count > 0)
                    {
                        smpt.Send(mail);
                        if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                        {
                            TempData["Message"] = "Send successful!";
                        }
                        else
                        {
                            TempData["Message"] = "Gửi mail thành công!";
                        }
                        email = new tblEmail();
                    }
                    else
                    {
                        if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                        {
                            TempData["Message"] = "Send Unsuccessful!";
                        }
                        else 
                        {
                            TempData["Message"] = "Không gửi mail thành công!";
                        }
                    }
                }
                catch(SmtpException ex)
                {
                    if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                    {
                        TempData["Message"] = "Send Unsuccessful!";
                    }
                    else
                    {
                        TempData["Message"] = "Không gửi mail thành công!";
                    }
                }
                
                
            }
            TempData["Department"] = LoadDataForDropDownList();
            TempData["EmailReload"] = email;
            return RedirectToAction("ViewContact");
        }
    public ActionResult ViewContact()
    {
        tblInformation contact = new tblInformation();
        ViewData["Department"] = LoadDataForDropDownList();
        if (TempData["EmailReload"] != null)
        {
            ViewData["EmailReload"] = TempData["EmailReload"];
        }
        if (TempData["Title"] != null)
        {
            ViewData["Title"] = TempData["Title"];
        }
        if (TempData["Sender"] != null)
        {
            ViewData["Sender"] = TempData["Sender"];
        }
        if (TempData["Content"] != null)
        {
            ViewData["Content"] = TempData["Content"];
        }
        if (TempData["EmailInvalid"] != null)
        {
            ViewData["EmailInvalid"] = TempData["EmailInvalid"];
        }
        if (TempData["Message"] != null)
        {
            ViewData["Message"] = TempData["Message"];
        }
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

    public bool isEmail(string inputEmail)
    {
        if (inputEmail != null)
        {
            //inputEmail = NulltoString(inputEmail);
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        else
            return false;
    }
        #endregion
    }
}
