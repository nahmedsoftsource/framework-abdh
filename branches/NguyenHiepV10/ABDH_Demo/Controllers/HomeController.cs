using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABDH_Demo.Services;
using ABDH_Demo.Models;
using ABDH_Demo.Data;
namespace ABDH_Demo.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        DinhKemService _service = new DinhKemService();
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            RedirectToAction("List");
            return View();

        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult List()
        {
           
            List<tblDinhKem> list =  _service.GetDinhKems();
            return View(list);
        }
        public ActionResult Edit(int id)
        {
          ViewData["NhomTaiLieu"] = new SelectList( _service.GetNhomTaiLieus().AsEnumerable(),"NhomTaiLieuID", "TenNhomTaiLieu");
            tblTaiLieu tailieu =  _service.GetTailieuByID(id);
            return View(tailieu);
        }

        //
        // POST: /Library/Edit/5

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, [Bind(Exclude = "TaiLieuID")] tblTaiLieu tailieu, FormCollection collection)
        {
          if (id != 0)
          {
            tblTaiLieu doc = _service.GetTailieuByID(id);
            try
            {

              UpdateModel(doc);
              // TODO: Add update logic here
              //UpdateModel<tblTaiLieu>(doc, collection);
              _service.SaveTaiLieu(doc);
              return RedirectToAction("List");
            }
            catch
            {
              return View(doc);
            }
          }
          else
          {
            _service.InsertTailieu(tailieu);
            return RedirectToAction("List");
          }
        }
        public ActionResult Details(int id)
        {
          tblTaiLieu tailieu = _service.GetTailieuByID(id);
          return View(tailieu);
        }
    }
    
}
