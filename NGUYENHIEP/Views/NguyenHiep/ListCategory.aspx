<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<NguyenHiep.Data.SearchResult<NGUYENHIEP.Models.tblCategory>>" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="NguyenHiep.Utility" %>
<div id="mainMnuLeft">
    <div class="mainMnuLeftTOp">
        <div class="mainMnuLeftBtom">
            <div class="mainMnuContent">
                <div class="barTabMnu">
                    <div class="barTabMnuLeft">
                        <div class="barTabMnuRight">
                            <div class="ctentBarTab">
                                <%=Resources.Global.Products %>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="contentMnu">
                    <ul>
                        <% foreach (var item in Model.Items)
                           {%>
                        <li>
                            <%if (HttpContext.Current.Response.Cookies["Culture"] != null && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
                              { %>
                            <%=Html.ActionLink((item.CategoryNameEN!=null)?item.CategoryNameEN:"No Name", "IndexForProductByCategory", new { categoryID = item.ID }, new { @class = "color2" })%>
                            <%}
                              else
                              { %>
                            <%=Html.ActionLink((item.CategoryNameVN != null) ? item.CategoryNameVN : "Không có tên", "IndexForProductByCategory", new { categoryID = item.ID }, new { @class = "color2" })%>
                            <%} %>
                        </li>
                        <%} %>
                    </ul>
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
              UrlMaker = ((page) => (new UrlHelper(ViewContext.RequestContext)).Action("ListCategory", "NguyenHiep") + "?pageSize=" + (int)NguyenHiep.Common.Constants.DefautPagingSize + "&page=" + page + ((ViewData["Type"] != null) ? ("&Type=" + ViewData["Type"]) : ""))

            },
            new NguyenHiep.Utility.Pager.AjaxPaginationOption
            {
                HtmlID = "ListCategoryID"
              ,
            }
          )
    %>
    <br />
    <span style="float: right">
        <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "AddCategory", Resources.Global.AddCategory, (new UrlHelper(ViewContext.RequestContext)).Action("EditCategory", "NguyenHiep") + "?newsID=" + Guid.Empty.ToString() + ((ViewData["Type"] != null) ? ("&Type=" + ViewData["Type"]) : ""))%>
    </span>
    <br />
</div>
