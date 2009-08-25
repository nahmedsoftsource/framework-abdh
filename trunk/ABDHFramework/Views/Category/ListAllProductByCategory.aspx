<%@ Page Title="" Language="C#" Inherits="ABDHFramework.Controllers.BaseViewPage<ABDHFramework.Data.SearchResult<ABDHFramework.Models.tblProduct>>" %>
<%@ Import Namespace="ABDHFramework.Lib" %>
<%@ Import Namespace="ABDHFramework.Lib.Pager" %>
<%@ Import Namespace="ABDHFramework.Models" %>
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
                    <% foreach (var item in Model.Items)
                       { %>
                    <%if (String.IsNullOrEmpty(item.ProductNameVN)) item.ProductNameVN = Resources.Global.NoTitle; %>
                    <div class="subSp">
                        <div class="clear">
                            <a href="#">
                                <img src='<%= Url.Content("~"+item.Image)%>' /></a></div>
                        <div class="paddingTb4 paddingLr18px bold">
                        <%if (HttpContext.Current.Response.Cookies["Culture"] != null && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
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
                    <%if (counter == ABDHFramework.Common.Constants.NumberImagesInRow || counter >= Model.Items.Count)
                      {
                          counter = 0; %>
                    <div class="clear">
                    </div>
                    <%} %>
                    <% } %>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="prevNext">
<%
    Guid? categoryID = (ViewData["CategoryID"] != null)?ViewData["CategoryID"] as Guid? :Guid.Empty;
     %>
 <%if (HttpContext.Current.Response.Cookies["Culture"] != null && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
   { %>
    <%=
          PagerExtensions.AjaxPager
          (this.Html,
            new PagingOption
            {
                CurrentPage = Model.GetPage(),
                PageSize = Model.GetMaxResults(),
                TotalRows = Model.TotalRows,
                UrlMaker = ((page)=> Routing.Category.UrlForListAllProductByCategory(page,categoryID))

            },
            new AjaxPaginationOption
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
          PagerExtensions.AjaxPager
          (this.Html,
            new PagingOption
            {
                CurrentPage = Model.GetPage(),
                PageSize = Model.GetMaxResults(),
                TotalRows = Model.TotalRows,
                UrlMaker = ((page) => Routing.Category.UrlForListAllProductByCategory(page, categoryID))

            },
            new AjaxPaginationOption
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
  <span style="float: right">
    <%=UIHelper.ButtonTo(Html, "AddProduct", Resources.Global.AddProduct, (new UrlHelper(ViewContext.RequestContext)).Action("EditProduct", "NguyenHiep") + "?newsID=" + null + ((ViewData["Type"] != null) ? ("&Type=" + ViewData["Type"]) : "")+"&CategoryID="+((ViewData["CategoryID"]!=null)?((Guid)ViewData["CategoryID"]).ToString():Guid.Empty.ToString()))%>
</span>
  <%} %>