<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblCategory>" %>


<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="NguyenHiep.Utility" %>

<asp:Content ID="Content2" ContentPlaceHolderID="UpperMainContent" runat="server">

    <script src="/Editor/fckeditor.js" type="text/javascript"></script>
    <form id="form2" runat="server"  method='POST' enctype='multipart/form-data' action="#" style="width:100%">
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
        <td class="l" style="width:30%">
            <label for="CategoryNameVN"><%=Resources.Global.VNName %>:</label>
        </td>
        
        <td class="l">
        <%if (HttpContext.Current.Response.Cookies["Culture"] != null && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
          { %>
            <%= Html.TextBox("CategoryNameEN", Model.CategoryNameEN, new {  style = "width:100%", @class = "noidung" })%>
            <%= Html.ValidationMessage("CategoryNameEN")%>
            <%}
          else
          { %>
          <%= Html.TextBox("CategoryNameVN", Model.CategoryNameVN, new {  style = "width:100%", @class = "noidung" })%>
            <%= Html.ValidationMessage("CategoryNameVN")%>
            <%} %>
        </td>
    </tr>
    
    
    
    <tr>
        <td class="l"  style="width:30%">
            <label for="DescriptionVN"><%=Resources.Global.VNDescription %>:</label>
        </td>
        
        <td class="l">
        <%if (HttpContext.Current.Response.Cookies["Culture"] != null && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
          { %>
            <%= Html.TextBox("DescriptionEN", Model.DescriptionEN, new { rows="5", style = "width:100%", @class = "noidung" })%>
            <%= Html.ValidationMessage("DescriptionEN")%>
            <%}else{ %>
            <%= Html.TextArea("DescriptionVN", Model.DescriptionVN, new { rows="5",style="width:100%",@class="noidung" })%>
            <%= Html.ValidationMessage("DescriptionVN")%>
            <%} %>
        </td>
    </tr>
    
        
    <tr>
        <td colspan="2" class="c"  style="width:30%">
        <span style="float:right">
        <%if (ViewData["AddNews"] != null)
          { %>
            <input type="submit" value="<%=Resources.Global.AddCategory %>" />
        <%}
          else
          { %>
          <span style="float:right">
        <input type="submit" value="<%=Resources.Global.Edit %>">" />
        </span>
        <%} %>
        </span>
        </td>
    </tr>
    </table>
    
    </form>
</asp:Content>


