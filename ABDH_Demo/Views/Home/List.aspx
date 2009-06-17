<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ABDH_Demo.Models.tblDinhKem>>" %>
<%@ Import Namespace= ABDH_Demo.Models %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>List</h2>
    <table>
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

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

