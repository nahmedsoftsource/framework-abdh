﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABDHFramework.Utility;
using ABDHFramework.Lib;

namespace ABDHFramework.Controllers
{
    [HandleError]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (HttpContext.Session["UserName"] != null)
            {
                return View("Admin/Admin");
            }
            else
            {
                return View();
            }
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
