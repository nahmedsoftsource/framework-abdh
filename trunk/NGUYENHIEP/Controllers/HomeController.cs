﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NGUYENHIEP.Infrastructure;

namespace NGUYENHIEP.Controllers
{
    [HandleError]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
