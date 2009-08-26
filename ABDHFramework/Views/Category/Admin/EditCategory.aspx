<%@ Page Title="" Language="C#"  Inherits="ABDHFramework.Controllers.BaseViewPage<ABDHFramework.Models.tblCategory>" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="ABDHFramework.Lib" %>
<%@ Import Namespace="ABDHFramework.Lib.Pager" %>
<%@ Import Namespace="ABDHFramework.Models" %>
  
    <div class="ui-tabs-panel ui-widget-content ui-corner-bottom">
    <form id="form2" runat="server"  method='POST' enctype='multipart/form-data' action="#" style="width:100%">
    <div class="TitleAction">
    <%if (ViewData["AddNews"] != null)
          { %>
            <h2><%=Resources.Global.AddCategory %></h2>
        <%}
          else
          { %>
        <h2><%=Resources.Global.EditCategory %></h2>
        <%} %>
        </div>

    <table class="layout-form  maxwidth" cellspacing="2" cellpadding="0" border="0">
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
        
        <span style="float:right">
        <%if (Model != null && (Model.ID == null || Model.ID.Equals(Guid.Empty)) )
          { %>
          <%=Html.SubmitToRemote(Resources.Global.AddCategory, new RemoteOption
            {
              CausesValidation=false,
              Method = "POST",
              URL = Routing.Category.UrlForEditCategory(Model.ID),
              Update = "ListID",
              
            }) %>
        <%}
          else
          { %>
          <span style="float:right">
        <%--<input type="submit" class="abutton" value="<%=Resources.Global.Update %>" />--%>
        <%=Html.SubmitToRemote(Resources.Global.Update,new RemoteOption
            {
              CausesValidation=false,
              Method = "POST",
              URL = Routing.Category.UrlForEditCategory(Model.ID),
              Update = "ListID",
              
            }) %>
          
        </span>
        <%} %>
        </span>
        </td>
    </tr>
    </table>
    
    </form>
</div>


