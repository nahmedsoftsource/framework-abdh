<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ABDH_Demo.Models.tblDinhKem>>" %>
<%@ Import Namespace= ABDH_Demo.Models %>
<%@ Import Namespace= ABDH_Demo.Utility %>
<%@ Import Namespace= ABDH_Demo.Utility.Pager %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>List</h2>
   <%-- <table>
        <tr>
            <th></th>
            <th>
                Ma tai lieu
            </th>
            <th>
                Ten tai lieu
            </th>
            <th>
                Tom tat noi dung
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.tblTaiLieu.TaiLieuID }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.tblTaiLieu.TaiLieuID })%>
            </td>
            <td>
                <%= Html.Encode(item.tblTaiLieu.MaTaiLieu) %>
            </td>
            <td>
                <%= Html.Encode(item.tblTaiLieu.TenTaiLieu)%>
            </td>
            <td>
                <%= Html.Encode(item.tblTaiLieu.TomTatNoiDung)%>
            </td>
        </tr>
    
    <% } %>

    </table>--%>
    <div id="ListTaiLieu">
        <%
          if (Model != null && Model.ToList().Count > 0)
          {
            List<tblTaiLieu> tlList = new List<tblTaiLieu>();
            foreach (tblDinhKem tmp in Model)
            {
              if (tmp.tblTaiLieu != null)
              {
                tlList.Add(tmp.tblTaiLieu);
              }
            }
            List<ColumnOption<tblTaiLieu>> listColumn = new List<ColumnOption<tblTaiLieu>>();
            listColumn.Add(new ColumnOption<tblTaiLieu>
            {
              Name = "Action",
              Action = (tl => Html.ActionLink("Details", "Details", new { id = tl.TaiLieuID })),
            });
            listColumn.Add(
                  new ColumnOption<tblTaiLieu>
                  {
                    Action = (tl => tl.MaTaiLieu == "" ?Html.ActionLink("Unknown", "Edit", new { id = tl.TaiLieuID }):Html.ActionLink(tl.MaTaiLieu, "Edit", new { id = tl.TaiLieuID })),
                    Name = "Ma tai lieu",
                  }
                );
            
            listColumn.Add(new ColumnOption<tblTaiLieu>
            {
              Name = "Ten tai lieu",
              FieldName = "TenTaiLieu"
            });
            listColumn.Add(new ColumnOption<tblTaiLieu>
            {
              Name = "Tom tat noi dung",
              FieldName = "TomTatNoiDung"
            });
            
            %>
             <%= GridExtensions.SimpleGrid<tblTaiLieu>(this.Html,tlList.AsEnumerable(),listColumn.AsEnumerable(), true)%>
            <%--<%=
          PagerExtensions.AjaxPager
          (this.Html,
            new PagingOption
            {
              CurrentPage = Model.Query.GetPage(),
              PageSize = Model.Query.GetMaxResults(),
              TotalRows = Model.TotalRows,
              UrlMaker = ((page) => Routing.Credentialing.UrlForListCredentialing(Request["ServiceProviderID"], page)),

            },
            new AjaxPaginationOption
            {
              HtmlID = "CredentialDownloadDiv"
              ,
            }
          )
       %>--%>
       <%
          }
        %>
    </div>
    <p>
        <%= Html.ActionLink("Create New", "Edit", new { id = 0 })%>
    </p>

</asp:Content>

