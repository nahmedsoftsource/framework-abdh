using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NGUYENHIEP.Models;
using NGUYENHIEP.Services;

namespace NGUYENHIEP.Controllers
{
    [HandleError]
    public class NguyenHiepController : Controller
    {
        NguyenHiepService _nguyenHiepService = NguyenHiepService.Instance;
        public ActionResult ViewNews(Guid? newsID)
        {
            if (newsID != null && !newsID.Equals(Guid.Empty))
            {
                tblNew tblnews = _nguyenHiepService.GetNewsByID((Guid)newsID);
                return View(tblnews);
            }
            return new EmptyResult();
        }
        public ActionResult ListAllNews()
        {
            List<tblNew> listAllNews = _nguyenHiepService.GetAllNews();
            return View(listAllNews);
        }
    }
}
