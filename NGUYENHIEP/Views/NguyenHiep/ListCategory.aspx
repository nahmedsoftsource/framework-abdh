<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NguyenHiep.Data.SearchResult<NGUYENHIEP.Models.tblCategory>>" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="NguyenHiep.Utility" %>

<asp:Content ID="Content1" ContentPlaceHolderID="RightMenu" runat="server">
                        	

  	<ul>
        <% foreach (var item in Model.Items)
           {%>
            <li><%=Html.ActionLink(item.CategoryNameVN, "ViewNews", new { categoryID = item.ID }, new { @class = "color2" })%></li>
            <%} %>
    </ul>
                            
                      
<%=
          NguyenHiep.Utility.PagerExtensions.AjaxPager
          (this.Html,
            new NguyenHiep.Utility.Pager.PagingOption
            {
              CurrentPage = Model.GetPage(),
              PageSize = Model.GetMaxResults(),
              TotalRows = Model.TotalRows,
              UrlMaker = ((page) => (new UrlHelper(ViewContext.RequestContext)).Action("ListCategory", "NguyenHiep") + "?pageSize=" + (int)NguyenHiep.Common.Constants.DefautPagingSize+"&page="+page)

            },
            new NguyenHiep.Utility.Pager.AjaxPaginationOption
            {
                HtmlID = "ListCategoryID"
              ,
            }
          )
       %>
 <span style="float:right">
 <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "AddCategory", "Thêm", (new UrlHelper(ViewContext.RequestContext)).Action("EditCategory", "NguyenHiep") + "?newsID=" + null)%>
 </span>
 </asp:Content>