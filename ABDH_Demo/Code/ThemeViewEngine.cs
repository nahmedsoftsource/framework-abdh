using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ABDH_Demo
{
    public class ThemeViewEngine:WebFormViewEngine
    {
        public ThemeViewEngine()
        {
            base.ViewLocationFormats = new string[] {
            "~/Views/{1}/{0}.aspx",
            "~/Views/{1}/{0}.ascx",
            "~/Views/Shared/{0}.aspx",
            "~/Views/Shared/{0}.ascx"
        };

            base.MasterLocationFormats = new string[] {
            "~/Content/{2}/Site.master"
        };

            base.PartialViewLocationFormats = new string[] {
            "~/Views/{1}/{0}.aspx",
            "~/Views/{1}/{0}.ascx",
            "~/Views/Shared/{0}.aspx",
            "~/Views/Shared/{0}.ascx"
        };
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext,
                        string viewName, string masterName)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }
            if (string.IsNullOrEmpty(viewName))
            {
                throw new ArgumentException("Value is required.", "viewName");
            }

            string themeName = this.GetThemeToUse(controllerContext);

            string[] searchedViewLocations;
            string[] searchedMasterLocations;

            string controllerName =
              controllerContext.RouteData.GetRequiredString("controller");

            string viewPath = this.GetViewPath(this.ViewLocationFormats, viewName,
                              controllerName, out searchedViewLocations);
            string masterPath = this.GetMasterPath(this.MasterLocationFormats, viewName,
                                controllerName, themeName, out searchedMasterLocations);

            if (!(string.IsNullOrEmpty(viewPath)) &&
               (!(masterPath == string.Empty) || string.IsNullOrEmpty(masterName)))
            {
                return new ViewEngineResult(
                    (this.CreateView(controllerContext, viewPath, masterPath)), this);
            }
            return new ViewEngineResult(
              searchedViewLocations.Union<string>(searchedMasterLocations));
        }

        public override ViewEngineResult FindPartialView(ControllerContext controllerContext,
                                                         string partialViewName)
        {
            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }
            if (string.IsNullOrEmpty(partialViewName))
            {
                throw new ArgumentException("Value is required.", partialViewName);
            }

            string themeName = this.GetThemeToUse(controllerContext);

            string[] searchedLocations;

            string controllerName = controllerContext.RouteData.GetRequiredString("controller");

            string partialPath = this.GetViewPath(this.PartialViewLocationFormats,
                                 partialViewName, controllerName, out searchedLocations);

            if (string.IsNullOrEmpty(partialPath))
            {
                return new ViewEngineResult(searchedLocations);
            }
            return new ViewEngineResult(this.CreatePartialView(controllerContext,
                                        partialPath), this);
        }

        private string GetThemeToUse(ControllerContext controllerContext)
        {
            if (controllerContext.HttpContext.Request.QueryString.AllKeys.Contains("theme"))
            {
                string themeName = controllerContext.HttpContext.Request.QueryString["theme"];
                controllerContext.HttpContext.Session.Add("Theme", themeName);
            }
            else if (controllerContext.HttpContext.Session["Theme"] == null)
            {
                controllerContext.HttpContext.Session.Add("Theme", "Default");
            }
            return controllerContext.HttpContext.Session["Theme"].ToString();
        }

        private string GetViewPath(string[] locations, string viewName,
                       string controllerName, out string[] searchedLocations)
        {
            string path = null;

            searchedLocations = new string[locations.Length];

            for (int i = 0; i < locations.Length; i++)
            {
                path = string.Format(CultureInfo.InvariantCulture, locations[i],
                                     new object[] { viewName, controllerName });
                if (this.VirtualPathProvider.FileExists(path))
                {
                    searchedLocations = new string[0];
                    return path;
                }
                searchedLocations[i] = path;
            }
            return null;
        }

        private string GetMasterPath(string[] locations, string viewName,
                       string controllerName, string themeName, out string[] searchedLocations)
        {
            string path = null;

            searchedLocations = new string[locations.Length];

            for (int i = 0; i < locations.Length; i++)
            {
                path = string.Format(CultureInfo.InvariantCulture, locations[i],
                                     new object[] { viewName, controllerName, themeName });
                if (this.VirtualPathProvider.FileExists(path))
                {
                    searchedLocations = new string[0];
                    return path;
                }
                searchedLocations[i] = path;
            }
            return null;
        }

    }
}
