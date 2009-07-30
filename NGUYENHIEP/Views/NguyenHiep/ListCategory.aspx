<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<NguyenHiep.Data.SearchResult<NGUYENHIEP.Models.tblCategory>>" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="NguyenHiep.Utility" %>
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
                            <%=Html.ActionLink(item.CategoryNameVN, "ViewNews", new { categoryID = item.ID }, new { @class = "color2" })%></li>
                        <%} %>
                    </ul>
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
              UrlMaker = ((page) => (new UrlHelper(ViewContext.RequestContext)).Action("ListCategory", "NguyenHiep") + "?pageSize=" + (int)NguyenHiep.Common.Constants.DefautPagingSize + "&page=" + page + ((ViewData["Type"] != null) ? ("&Type" + ViewData["Type"]) : ""))

            },
            new NguyenHiep.Utility.Pager.AjaxPaginationOption
            {
                HtmlID = "ListCategoryID"
              ,
            }
          )
       %>
       <div class="prevNext">
 <span style="float:right">
 <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "AddCategory", Resources.Global.AddCategory, (new UrlHelper(ViewContext.RequestContext)).Action("EditCategory", "NguyenHiep") + "?newsID=" + null) + ((ViewData["Type"] != null) ? ("&Type" + ViewData["Type"]) : "")%>
 </span>
    %>
</div>
<div class="prevNext">
    <span style="float: right">
        <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "AddCategory", Resources.Global.AddCategory, (new UrlHelper(ViewContext.RequestContext)).Action("EditCategory", "NguyenHiep") + "?newsID=" + null)%>
    </span>
</div>
