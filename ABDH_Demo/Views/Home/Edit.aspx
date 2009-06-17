<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ABDH_Demo.Models.tblTaiLieu>" %>
<%@ Import Namespace= ABDH_Demo.Models%>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="TaiLieuID">TaiLieuID:</label>
                <%= Html.TextBox("TaiLieuID", Model.TaiLieuID) %>
                <%= Html.ValidationMessage("TaiLieuID", "*") %>
            </p>
            <p>
                <label for="MaTaiLieu">MaTaiLieu:</label>
                <%= Html.TextBox("MaTaiLieu", Model.MaTaiLieu) %>
                <%= Html.ValidationMessage("MaTaiLieu", "*") %>
            </p>
            <p>
                <label for="TenTaiLieu">TenTaiLieu:</label>
                <%= Html.TextBox("TenTaiLieu", Model.TenTaiLieu) %>
                <%= Html.ValidationMessage("TenTaiLieu", "*") %>
            </p>
            <p>
                <label for="VongDoi_StartDate">VongDoi_StartDate:</label>
                <%= Html.TextBox("VongDoi_StartDate", String.Format("{0:g}", Model.VongDoi_StartDate)) %>
                <%= Html.ValidationMessage("VongDoi_StartDate", "*") %>
            </p>
            <p>
                <label for="VongDoi_EndDate">VongDoi_EndDate:</label>
                <%= Html.TextBox("VongDoi_EndDate", String.Format("{0:g}", Model.VongDoi_EndDate)) %>
                <%= Html.ValidationMessage("VongDoi_EndDate", "*") %>
            </p>
            <p>
                <label for="TomTatNoiDung">TomTatNoiDung:</label>
                <%= Html.TextBox("TomTatNoiDung", Model.TomTatNoiDung) %>
                <%= Html.ValidationMessage("TomTatNoiDung", "*") %>
            </p>
            <p>
                <label for="SoLanXem">SoLanXem:</label>
                <%= Html.TextBox("SoLanXem", Model.SoLanXem) %>
                <%= Html.ValidationMessage("SoLanXem", "*") %>
            </p>
            <p>
                <label for="NhomTaiLieuID">NhomTaiLieuID:</label>
                
                <%
                  
                  SelectList list = (SelectList)ViewData["NhomTaiLieu"];
                %>
                <%=Html.DropDownList("NhomTaiLieuID",ViewData["NhomTaiLieu"] as IEnumerable<SelectListItem>)%>
                <%= Html.ValidationMessage("NhomTaiLieuID", "*") %>
            </p>
            <p>
                <label for="TrangThaiTaiLieu">TrangThaiTaiLieu:</label>
                <%= Html.TextBox("TrangThaiTaiLieu", Model.TrangThaiTaiLieu) %>
                <%= Html.ValidationMessage("TrangThaiTaiLieu", "*") %>
            </p>
            <p>
                <label for="TacGia">TacGia:</label>
                <%= Html.TextBox("TacGia", Model.TacGia) %>
                <%= Html.ValidationMessage("TacGia", "*") %>
            </p>
            <p>
                <label for="NgonNgu">NgonNgu:</label>
                <%= Html.TextBox("NgonNgu", Model.NgonNgu) %>
                <%= Html.ValidationMessage("NgonNgu", "*") %>
            </p>
            <p>
                <label for="TuKhoa">TuKhoa:</label>
                <%= Html.TextBox("TuKhoa", Model.TuKhoa) %>
                <%= Html.ValidationMessage("TuKhoa", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "List") %>
    </div>

</asp:Content>

