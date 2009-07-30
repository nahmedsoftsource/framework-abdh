<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblCategory>" %>


<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="NguyenHiep.Utility" %>

<asp:Content ID="Content2" ContentPlaceHolderID="UpperMainContent" runat="server">

    <script src="/Editor/fckeditor.js" type="text/javascript"></script>
    <form id="form2" runat="server"  method='POST' enctype='multipart/form-data' action="#">
    <%if (ViewData["AddNews"] != null)
          { %>
            <h2><%=Resources.Global.AddCategory %></h2>
        <%}
          else
          { %>
        <h2><%=Resources.Global.EditCategory %></h2>
        <%} %>

    <table width="100%">
    <tr>
        <td class="l">
            <label for="CategoryNameVN"><%=Resources.Global.VNName %>:</label>
        </td>
        
        <td class="l">
            <%= Html.TextBox("CategoryNameVN", Model.CategoryNameVN, new { @size = "50" })%>
            <%= Html.ValidationMessage("CategoryNameVN", "*")%>
        </td>
    </tr>
    <tr>
        <td class="l">
            <label for="CategoryNameEN"><%=Resources.Global.ENName %>:</label>
        </td>
        
        <td class="l">
            <%= Html.TextBox("CategoryNameEN", Model.CategoryNameEN, new { @size = "50" })%>
            <%= Html.ValidationMessage("CategoryNameEN", "*")%>
        </td>
    </tr>
    
    
    <tr>
        <td class="l">
            <label for="DescriptionVN"><%=Resources.Global.VNDescription %>:</label>
        </td>
        
        <td class="l">
            <%= Html.TextBox("DescriptionVN", Model.DescriptionVN, new { @size = "50" })%>
            <%= Html.ValidationMessage("DescriptionVN", "*")%>
        </td>
    </tr>
    <tr>
        <td class="l">
            <label for="CategoryNameEN"><%=Resources.Global.ENDescription %>:</label>
        </td>
        
        <td class="l">
            <%= Html.TextBox("DescriptionEN", Model.DescriptionEN, new { @size = "50" })%>
            <%= Html.ValidationMessage("DescriptionEN", "*")%>
        </td>
    </tr>
        
    <tr>
        <td colspan="2" class="c">
        <%if (ViewData["AddNews"] != null)
          { %>
            <input type="submit" value="<%=Resources.Global.AddCategory %>" />
        <%}
          else
          { %>
        <input type="submit" value="<%=Resources.Global.Edit %>">" />
        <%} %>
        </td>
    </tr>
    </table>
    
    </form>
</asp:Content>


