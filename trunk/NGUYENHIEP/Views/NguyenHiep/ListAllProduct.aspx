﻿<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<NguyenHiep.Data.SearchResult<NGUYENHIEP.Models.tblProduct>>" %>

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
                    <%if (counter == NguyenHiep.Common.Constants.NumberImagesInRow || counter >= Model.Items.Count)
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
    <%=
          NguyenHiep.Utility.PagerExtensions.AjaxPager
          (this.Html,
            new NguyenHiep.Utility.Pager.PagingOption
            {
              CurrentPage = Model.GetPage(),
              PageSize = Model.GetMaxResults(),
              TotalRows = Model.TotalRows,
              //UrlMaker = ((page) => (new NGUYENHIEP.Controllers.NguyenHiepController()).ListAllNews((int)NguyenHiep.Common.Constants.DefautPagingSize,(int)page)),
              UrlMaker = ((page) => (new UrlHelper(ViewContext.RequestContext)).Action("ListAllProduct", "NguyenHiep") + "?pageSize=" + (int)NguyenHiep.Common.Constants.DefautPagingSize + "&page=" + page + ((ViewData["Type"] != null) ? ("&Type" + ViewData["Type"]) : ""))

            },
            new NguyenHiep.Utility.Pager.AjaxPaginationOption
            {
                HtmlID = "ListAllProductID"
              ,
            }
          )
    %>
</div>
<span style="float: right">
    <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "AddProduct", Resources.Global.AddProduct, (new UrlHelper(ViewContext.RequestContext)).Action("EditProduct", "NguyenHiep") + "?newsID=" + null + ((ViewData["Type"] != null) ? ("&Type=" + ViewData["Type"]) : ""))%>
</span>