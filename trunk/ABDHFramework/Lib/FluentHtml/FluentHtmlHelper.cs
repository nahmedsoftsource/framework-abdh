using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

namespace Framework.Lib
{
  public class FluentHtmlHelper: HtmlHelper
  {
    public FluentHtmlHelper(ViewContext viewContext, IViewDataContainer viewDataContainer)
      : base(viewContext, viewDataContainer, RouteTable.Routes)
    {
      Url = new UrlHelper(ViewContext.RequestContext);
    }

    public FluentHtmlHelper(HtmlHelper html):this(html.ViewContext, html.ViewDataContainer) { }

    public UrlHelper Url
    {
      get;
      private set;
    }
  }
}
