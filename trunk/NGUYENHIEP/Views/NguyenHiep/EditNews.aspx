<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblNew>" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">

<script src="/Editor/fckeditor.js" type="text/javascript"></script>
    <form id="form1" runat="server"  method='POST' enctype='multipart/form-data' action="#">
    <%if (ViewData["AddNews"] != null)
          { %>
            <h2>Thêm tin t&#7913;c</h2>
        <%}
          else
          { %>
        <h2>Ch&#7881;nh s&#7917;a tin t&#7913;c</h2>
        <%} %>
    

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <%--<% using (Html.BeginForm()) {%>--%>

    <table width="100%">
    <tr>
        <td>
            <label for="TitleVN">Tiêu &#273;&#7873;:</label>
        </td>
        
        <td>
            <%= Html.TextBox("TitleVN", Model.TitleVN, new { @size="50"})%>
            <%= Html.ValidationMessage("TitleVN", "*") %>
        </td>
    </tr>
    <tr>
        <td>
            <label for="SubjectVN">Ch&#7911; &#273;&#7873;:</label>
        </td>
        
        <td>
            <%= Html.TextBox("SubjectVN", Model.SubjectVN, new { @size = "50" })%>
                <%= Html.ValidationMessage("SubjectVN", "*") %>
        </td>
    </tr>
    <tr>
        <td>
            <label >N&#7897;i Dung:</label>
        </td>
        
        <td>
            <%=Html.FckTextBox("ContentVN")%>
        </td>
    </tr>
    <tr>
        <td>
            <label >Lo&#7841;i:</label>
        </td>
        
        <td>
            <%=Html.DropDownList("Model.Type",((List<SelectListItem>)ViewData["NewsType"]).AsEnumerable()) %>
                <%= Html.ValidationMessage("Type", "*") %>
        </td>
    </tr>
    <tr>
        <td>
            <label >Hình &#7843;nh:</label>
        </td>
        
        <td>
            <%--<%= Html.TextBox("Image", Model.Image)%>
                <%= Html.ValidationMessage("Image", "*")%>--%>
             <input type="file" name="UploadFile" size="50"/>   
        </td>
    </tr>
    <tr>
        <td colspan="2">
        <%if (ViewData["AddNews"] != null)
          { %>
            <input type="submit" value="Thêm tin t&#7913;c" />
        <%}
          else
          { %>
        <input type="submit" value="S&#7917;a" />
        <%} %>
        </td>
    </tr>
    </table>
    
    </form>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightMenu" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LowerMainContent" runat="server">
</asp:Content>

