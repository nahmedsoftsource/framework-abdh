<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ABDH_Demo.Models.tblTaiLieu>" %>
<%@ Import Namespace= ABDH_Demo.Models%>
<%@ Import Namespace=ABDH_Demo.Utility %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>
    <table>
            <tr>
                <td>
                  <label for="MaTaiLieu">MaTaiLieu:</label>
                </td>
                <td>
                  <%= Html.TextBox("MaTaiLieu", Model.MaTaiLieu) %>
                  <%= Html.ValidationMessage("MaTaiLieu", "*") %>
                </td>
                
            </tr>
            <tr>
                <td>
                    <label for="TenTaiLieu">TenTaiLieu:</label>
                </td>
                <td>
                    <%= Html.TextBox("TenTaiLieu", Model.TenTaiLieu) %>
                <%= Html.ValidationMessage("TenTaiLieu", "*") %>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="VongDoi_StartDate">VongDoi_StartDate:</label>
                </td>
                <td>
                    <%if(Model.VongDoi_StartDate ==null)Model.VongDoi_StartDate = DateTime.Now; %>
                    <%=Html.DatePickerTextBox("VongDoi_StartDate",((DateTime)Model.VongDoi_StartDate).ToShortDateString()) %>
                    <%= Html.ValidationMessage("VongDoi_StartDate", "*") %>
                </td>
                
                <%--<%= Html.TextBox("VongDoi_StartDate", String.Format("{0:g}", Model.VongDoi_StartDate)) %>--%>
                
                
            </tr>
            <tr>
                <td>
                    <label for="VongDoi_EndDate">VongDoi_EndDate:</label>
                </td>
                <td>
                    <%if(Model.VongDoi_EndDate ==null)Model.VongDoi_EndDate = DateTime.Now; %>
                    <%=Html.DatePickerTextBox("VongDoi_EndDate", ((DateTime)Model.VongDoi_EndDate).ToShortDateString())%>
                    <%= Html.ValidationMessage("VongDoi_EndDate", "*") %>
                </td>
                
                <%--<%= Html.TextBox("VongDoi_EndDate", String.Format("{0:g}", Model.VongDoi_EndDate)) %>--%>
                
            </tr>
            <tr>
                <td>
                    <label for="TomTatNoiDung">TomTatNoiDung:</label>
                </td>
                <td>
                    <%= Html.TextBox("TomTatNoiDung", Model.TomTatNoiDung) %>
                    <%= Html.ValidationMessage("TomTatNoiDung", "*") %>
                </td>
                
                
            </tr>
            <tr>
                <td>
                    <label for="SoLanXem">SoLanXem:</label>
                </td>
                <td>
                    <%= Html.TextBox("SoLanXem", Model.SoLanXem) %>
                    <%= Html.ValidationMessage("SoLanXem", "*") %>
                </td>
                
                
            </tr>
            <tr>
                <td>
                    <label for="NhomTaiLieuID">NhomTaiLieuID:</label>
                </td>
                <td>
                    <%
                  
                        SelectList list = (SelectList)ViewData["NhomTaiLieu"];
                    %>
                    <%=Html.DropDownList("NhomTaiLieuID",ViewData["NhomTaiLieu"] as IEnumerable<SelectListItem>)%>
                    <%= Html.ValidationMessage("NhomTaiLieuID", "*") %>
                </td>
                
                
                
            </tr>
            <tr>
                <td>
                    <label for="TrangThaiTaiLieu">TrangThaiTaiLieu:</label>
                </td>
                <td>
                    <%= Html.TextBox("TrangThaiTaiLieu", Model.TrangThaiTaiLieu) %>
                    <%= Html.ValidationMessage("TrangThaiTaiLieu", "*") %>
                </td>
                
                
            </tr>
            <tr>
                <td>
                    <label for="TacGia">TacGia:</label>
                </td>
                <td>
                    <%= Html.TextBox("TacGia", Model.TacGia) %>
                    <%= Html.ValidationMessage("TacGia", "*") %>
                </td>
                
                
            </tr>
            <tr>
                <td>
                    <label for="NgonNgu">NgonNgu:</label>
                </td>
                <td>
                    <%= Html.TextBox("NgonNgu", Model.NgonNgu) %>
                    <%= Html.ValidationMessage("NgonNgu", "*") %>
                </td>
                
                
            </tr>
            <tr>
                <td>
                    <label for="TuKhoa">TuKhoa:</label>
                </td>
                <td>
                    <%= Html.TextBox("TuKhoa", Model.TuKhoa) %>
                    <%= Html.ValidationMessage("TuKhoa", "*") %>
                </td>
                
                
            </tr>
            <tr>
                <td colspan="2">
                    <input type="submit" value="Save" />
                </td>
                
            </tr>
    </table>
    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "List") %>
    </div>
<%Html.EndForm();%>
</asp:Content>

