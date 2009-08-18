<%@ Page Title="" Language="C#" Inherits="ABDHFramework.Controllers.BaseViewPage<ABDHFramework.Data.SearchResult<ABDHFramework.Models.tblProduct>>" %>

<div class="barCterTab">
    <div class="barCterTabLleft">
        <div class="barCterTabRight">
            <div style="line-height: 23px;" class="ctentBarTab">
                <%=Resources.Global.Products %>
            </div>
        </div>
    </div>
</div>
<div class="boxCtentSp">
    <div class="boxCtentSpTop">
        <div class="boxCtentSpBtom">
            <div class="boxCtentSpCtent">
                <div class="textLeft">
                    <%int counter = 0; %>
                    <%int counter2=0; %>
                    <% foreach (var item in Model.Items)
                       { %>
                        <%if (String.IsNullOrEmpty(item.ProductNameVN)) item.ProductNameVN = Resources.Global.NoTitle; %>
                        <div class="subSp">
                                <div class="clear">
                                    <a href="#">
                                        <img src='<%= Url.Content("~"+item.Image)%>' /></a>
                                </div>
                                <div class="paddingTb4 paddingLr18px bold">
                                    <%if (HttpContext.Current.Response.Cookies["Culture"] != null && !String.IsNullOrEmpty(HttpContext.Current.Response.Cookies["Culture"].Value) && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
                                     { %>
                                    <%=Html.ActionLink(item.ProductNameEN, "ViewProduct", new { newsID = item.ID }, new { @class = "color2" })%>
                                    <%}
                                    else
                                    { %>
                                    <%=Html.ActionLink(item.ProductNameVN, "ViewProduct", new { newsID = item.ID }, new { @class = "color2" })%>
                                    <%} %>
                                </div>
                                <div class="clear">
                                </div>
                        </div>
                        <%counter++; %>
                        <%counter2++; %>
                        <%if (counter == ABDHFramework.Common.Constants.NumberImagesInRow || counter2 >= Model.Items.Count)
                          {
                            counter = 0; %>
                            <div class="clear"></div>
                        <%}%>
                    <% } %>
                </div>
               
            </div>
        </div>
    </div>
</div>

 <div class="prevNext">
 <%if (HttpContext.Current.Response.Cookies["Culture"] != null && !String.IsNullOrEmpty(HttpContext.Current.Response.Cookies["Culture"].Value) &&  HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
   { %>
    <%=
          ABDHFramework.Utility.PagerExtensions.AjaxPager
          (this.Html,
            new ABDHFramework.Utility.Pager.PagingOption
            {
                CurrentPage = Model.GetPage(),
                PageSize = Model.GetMaxResults(),
                TotalRows = Model.TotalRows,
                //UrlMaker = ((page) => (new ABDHFramework.Controllers.ABDHFrameworkController()).ListAllNews((int)ABDHFramework.Common.Constants.DefautPagingSize,(int)page)),
                //UrlMaker = ((page) => (new UrlHelper(ViewContext.RequestContext)).Action("ListAllProduct", "ABDHFramework") + "?pageSize=" + (int)ABDHFramework.Common.Constants.DefautPagingSize + "&page=" + page + ((ViewData["Type"] != null) ? ("&Type" + ViewData["Type"]) : ""))
                UrlMaker=(page)=>Routing.Product.UrlForListAllProduct()
            },
            new ABDHFramework.Utility.Pager.AjaxPaginationOption
            {
                HtmlID = "ListAllProductID"
              ,
            }
          )
    %>
    <%}
   else
   { %>
   <%=
          ABDHFramework.Utility.PagerExtensions.AjaxPager
          (this.Html,
            new ABDHFramework.Utility.Pager.PagingOption
            {
                CurrentPage = Model.GetPage(),
                PageSize = Model.GetMaxResults(),
                TotalRows = Model.TotalRows,
                //UrlMaker = ((page) => (new ABDHFramework.Controllers.ABDHFrameworkController()).ListAllNews((int)ABDHFramework.Common.Constants.DefautPagingSize,(int)page)),
                UrlMaker = ((page) => (new UrlHelper(ViewContext.RequestContext)).Action("ListAllProduct", "ABDHFramework") + "?pageSize=" + (int)ABDHFramework.Common.Constants.DefautPagingSize + "&page=" + page + ((ViewData["Type"] != null) ? ("&Type" + ViewData["Type"]) : ""))

            },
            new ABDHFramework.Utility.Pager.AjaxPaginationOption
            {
                HtmlID = "ListAllProductID"
              ,
            }
                 ).Replace("First", "Trang đầu").Replace("Last", "Trang cuối").Replace("Previous", "Trang trước").Replace("Next", "Trang sau")
    %>
    <%} %>
</div>
<%if (HttpContext.Current.Session["username"] != null)
  { %>
 <div>
 
                <span style="float: right">
                    <%=ABDHFramework.Utility.UIHelper.ButtonTo(Html, "AddProduct", Resources.Global.AddProduct, (new UrlHelper(ViewContext.RequestContext)).Action("EditProduct", "ABDHFramework") + "?newsID=" + null + ((ViewData["Type"] != null) ? ("&Type=" + ViewData["Type"]) : ""))%>
                </span>
                </div>
                <%} %>