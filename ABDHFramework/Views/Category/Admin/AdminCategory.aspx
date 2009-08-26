<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="ABDHFramework.Controllers.BaseViewPage<ABDHFramework.Data.SearchResult<ABDHFramework.Models.tblCategory>>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">
<div class="detail-title">
    Management Category
</div>
<br />
<div id="ListID" >
<%Html.RenderPartial("Admin/AdminListCategory",ViewData); %>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenu" runat="server">

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="LowerMainContent" runat="server">
</asp:Content>

