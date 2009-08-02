<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblCategory>" %>


<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="NguyenHiep.Utility" %>

<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">

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
            <label for="CategoryNameVN"><%=Resources.Global.Name %>:</label>
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
            <label for="DescriptionVN"><%=Resources.Global.Description %>:</label>
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
        <%if (Model != null && Model.ID != null && !Model.ID.Equals(Guid.Empty))
              {%>
                
            <span style="float: left">
    <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "Delete", Resources.Global.Delete, (new UrlHelper(ViewContext.RequestContext)).Action("EditCategory") + "?categoryID=" + Model.ID +"&Delete=true")%>
</span>
<%} %>
        <span style="float:right">
        <%if (ViewData["AddNews"] != null)
          { %>
            <input type="submit" value="<%=Resources.Global.AddCategory %>" />
        <%}
          else
          { %>
          <span style="float:right">
        <input type="submit" value="<%=Resources.Global.Edit %>" />
        </span>
        <%} %>
        </span>
        </td>
    </tr>
    </table>
    
    </form>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenu" runat="server">
<script language="javascript" type="text/javascript">

    var content = "";
    $(document).ready(function() {
        content = $.ajax({
            url: '<%=Url.Content("~/NguyenHiep/ListCategory") %>',
            global: false,
            type: "POST",
            async: false,
            dataType: "html",
            success: function(msg) {

                if (document.layers) {
                    document.getElementById('ListCategoryID').open();
                    document.getElementById('ListCategoryID').write(msg);
                    document.getElementById('ListCategoryID').close();
                    document.getElementById('ListCategoryID').innerHTML = msg;
                }
                else {
                    document.getElementById('ListCategoryID').innerHTML = msg;
                }

            }

        }).responseText;
    })
                    </script>
                    <div id="ListCategoryID">
                    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PromotionAnnoucement" runat="server">
                   
<script language="javascript" type="text/javascript">

    var content = "";
    $(document).ready(function() {
        content = $.ajax({
            url: '<%=Url.Content("~/NguyenHiep/ListPromotionNews") %>',
            global: false,
            type: "POST",
            async: false,
            dataType: "html",
            success: function(msg) {

                if (document.layers) {
                    document.getElementById('ListNewsPromotionID').open();
                    document.getElementById('ListNewsPromotionID').write(msg);
                    document.getElementById('ListNewsPromotionID').close();
                    document.getElementById('ListNewsPromotionID').innerHTML = msg;
                }
                else {
                    document.getElementById('ListNewsPromotionID').innerHTML = msg;
                }

            }

        }).responseText;
    })
                    </script>
                    <div id="ListNewsPromotionID">
                    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RiightNewsEvent" runat="server">
<script language="javascript" type="text/javascript">

    var content3 = "";
    $(document).ready(function() {

        content3 = $.ajax({
            url: '<%=Url.Content("~/NguyenHiep/ListHotNews") %>',
            global: false,
            type: "POST",
            async: false,
            dataType: "html",
            success: function(msg) {

                if (document.layers) {
                    document.getElementById('ListHotNewsID').open();
                    document.getElementById('ListHotNewsID').write(msg);
                    document.getElementById('ListHotNewsID').close();
                    document.getElementById('ListHotNewsID').innerHTML = msg;
                }
                else {
                    document.getElementById('ListHotNewsID').innerHTML = msg;
                }

            }

        }).responseText;
    })
                    </script>
                    <div id="ListHotNewsID">                    </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="LowerMainContent" runat="server">
</asp:Content>



