<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ABDH_Demo.Models.tblTaiLieu>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            TaiLieuID: 
            <%= Html.Encode(Model.TaiLieuID) %>
        </p>
        <p>
            MaTaiLieu: 
            <%= Html.Encode(Model.MaTaiLieu) %>
        </p>
        <p>
            TenTaiLieu: 
            <%= Html.Encode(Model.TenTaiLieu) %>
        </p>
        <p>
            VongDoi_StartDate: 
            <%= Html.Encode(Model.VongDoi_StartDate) %>
        </p>
        <p>
            VongDoi_EndDate: 
            <%= Html.Encode(Model.VongDoi_EndDate) %>
        </p>
        <p>
            TomTatNoiDung: 
            <%= Html.Encode(Model.TomTatNoiDung) %>
        </p>
        <p>
            SoLanXem: 
            <%= Html.Encode(Model.SoLanXem) %>
        </p>
        <p>
            NhomTaiLieuID: 
            <%= Html.Encode(Model.NhomTaiLieuID) %>
        </p>
        <p>
            TrangThaiTaiLieu: 
            <%= Html.Encode(Model.TrangThaiTaiLieu) %>
        </p>
        <p>
            TacGia: 
            <%= Html.Encode(Model.TacGia) %>
        </p>
        <p>
            NgonNgu: 
            <%= Html.Encode(Model.NgonNgu) %>
        </p>
        <p>
            TuKhoa: 
            <%= Html.Encode(Model.TuKhoa) %>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { id = Model.TaiLieuID })%> |
        <%=Html.ActionLink("Back to List", "List") %>
    </p>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

