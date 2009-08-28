<%@ Page    Title="Manage Product" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="ABDHFramework.Controllers.BaseViewPage<ABDHFramework.Data.SearchResult<ABDHFramework.Models.tblProduct>>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">
<div class="detail-title">
    Manage Product
</div>
<br />
<div id="ListID" class="content-border">
<%Html.RenderPartial("Admin/AdminListProduct",ViewData); %>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenu" runat="server">

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="LowerMainContent" runat="server">
</asp:Content>

