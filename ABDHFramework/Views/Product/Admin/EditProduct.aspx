<%@ Page  Title="Edit Product" Language="C#" Inherits="ABDHFramework.Controllers.BaseViewPage<ABDHFramework.Models.tblProduct>" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="ABDHFramework.Lib" %>
<%@ Import Namespace="ABDHFramework.Lib.Pager" %>
<%@ Import Namespace="ABDHFramework.Models" %>
    <link href="~/Content/Style.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/theme/jquery-ui-1.7.1.custom.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src='<%= Url.Content("~/Scripts/jquery-1.3.2.js")%>'></script>
    <script type="text/javascript" src='<%= Url.Content("~/Scripts/MicrosoftAjax.js")%>'></script>
     <script type="text/javascript" src='<%= Url.Content("~/Scripts/MicrosoftMvcAjax.js")%>'></script>
    <script type="text/javascript" src='<%= Url.Content("~/Scripts/Core.js")%>'></script>
     <script type="text/javascript" src='<%= Url.Content("~/Scripts/jquery-ui-1.7.2.custom.min.js")%>'></script>
    <script type="text/javascript" language="javascript" src='<%= Url.Content("~/Admin/fckeditor/fckeditor.js")%>'></script>
<script type="text/javascript" language="javascript">
    var sBasePath = '<%= Url.Content("~/Admin/fckeditor/")%>';
</script>

<form id="form1" runat="server"  method='POST' enctype='multipart/form-data' action="#">
    <%if (Model.ID == null || Model.ID.Equals(Guid.Empty))
          { %>
            <h2><%=Resources.Global.AddProduct %></h2>
        <%}
          else
          { %>
        <h2><%=Resources.Global.EditProduct %></h2>
        <%} %>
    
    <table  width="100%" cellspacing="2" cellpadding="0" border="0">
    <tr>
        <td>
            <label for="ProductName"><%=Resources.Global.ProductName %></label>
        </td>
        
        <td>
        
            <%= Html.TextBox("ProductName", (Model != null && Model.ProductName != null) ? Model.ProductName : "", new { style = "width:100%" })%>
            <%= Html.ValidationMessage("ProductName")%>
        
        </td>
    </tr>
    
    
     
     <tr>
        <td>
            <label ><%=Resources.Global.TypeName %>:</label>
        </td>
        
        <td>
        <%=Html.DropDownList("CategoryID", ((List<SelectListItem>)ViewData["Categories"]).AsEnumerable(), new { style = "width:100%" })%>
        <%= Html.ValidationMessage("CategoryID")%>
        </td>
        
     </tr>
     <tr>
        <td>
            <label ><%=Resources.Global.Price %>:</label>
        </td>
        
        <td>
       
        <%=Html.TextBox("Price", (Model != null && Model.Price.HasValue && String.IsNullOrEmpty(Model.Price.ToString())) ? Model.Price.ToString() : "0", new { style = "width:100%" })%>USD 
        <%= Html.ValidationMessage("Price","Value is invalid")%>
       
        </td>
        
     </tr>
      <tr>
        <td>
            <label ><%=Resources.Global.ShortDescription %>:</label>
        </td>
        
        <td>
         <%=Html.TextArea("Property",(Model!=null && !String.IsNullOrEmpty(Model.Property))?Model.Property:"", new { rows=5, style="width:100%" })%>
         <%= Html.ValidationMessage("Property")%>
        </td>
      </tr>
     <tr>
        <td>
            <label ><%=Resources.Global.Details %>:</label>
        </td>
        
        <td>
        <%=Html.FckTextBox("Description")%>
        <%= Html.ValidationMessage("Description")%>
        </td>
        
     </tr>
    
    <tr>
        <td>
            <label ><%=Resources.Global.Image %>:</label>
        </td>
        <td>
        <p><input type="file" id="UploadFile" name="UploadFile" style="width:100%"/> </p>
       <%=Html.Hidden("Image",((Model != null && !String.IsNullOrEmpty(Model.Image))?Model.Image:"")) %>
                <%=Html.ValidationMessage("Image")%>
      </td>
      <%if (Model != null && !String.IsNullOrEmpty(Model.Image) )
        { %>
      <tr>
        <td>
            Hình hiện tại:
        </td>
        <td >
         <span style="float:left">
    	<a href="#"><img class="imgGthieu" src='<%= Url.Content("~"+Model.Image)%>' /></a>
    	</span>
        </td>
      </tr>
      <%} %>
    
       
    </tr>
    <tr>
        <td colspan="2">
        <%String label = "";
          if (Model != null && (Model.ID == null || Model.ID.Equals(Guid.Empty)))
          {
            label = Resources.Global.AddCategory;
          }
          else
          {
            label = Resources.Global.Update;
          }
           %>
       
          <span style="float:right">
          <%--<input type="submit" class="abutton" value="<%=label%>" />--%>
            <%=Html.SubmitToRemote(label, new RemoteOption
            {
              
              CausesValidation=false,
              Method = "POST",
              URL = Routing.Product.UrlForEditProduct(Model.ID),
              Update = "ListID",
              
            }) %>
            </span>
        </td>
    </tr>
    </table>
    
    </form>





