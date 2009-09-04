<%@ Page  Title="Edit Product"   ValidateRequest=false Language="C#" Inherits="ABDHFramework.Controllers.BaseViewPage<ABDHFramework.Models.tblProduct>" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="ABDHFramework.Lib" %>
<%@ Import Namespace="ABDHFramework.Lib.Pager" %>
<%@ Import Namespace="ABDHFramework.Models" %>
<%--<head>
    
     
     <%=Html.LoadJavascript("MicrosoftAjax.js") %>
     <%=Html.LoadJavascript("jquery-1.3.2.js") %>
     <%=Html.LoadJavascript("Core.js") %>
     <%=Html.LoadJavascript("MicrosoftMvcAjax.js") %>
     <%=Html.LoadJavascript("jquery-ui-1.7.2.custom.min.js") %>
   
    <script type="text/javascript" language="javascript" src='<%= Url.Content("~/Admin/fckeditor/fckeditor.js")%>'></script>
    </head>--%>


<script language="javascript" type="text/javascript">

  $(document).ready(function() {
  new AjaxUpload('#upload_button_id', {
    // Location of the server-side upload script
    // NOTE: You are not allowed to upload files to another domain
  action: '<%=Routing.Product.UrlForEditProduct()%>',
  onComplete: function(file) {
    $('#').appendTo($('#example3 .files')).text(file);
  }
  
  });
  })
    function ReloadAfterEdit(data) {
      alert(data);
    
      //parent.document.getElementById("IframeEditProduct").style.display = 'none';
      $(document).ready(function() {
        var content;
        
//        if (data != null && data != undefined && data != '0') {
//          
//          if (parent.document.layers) {
//            parent.document.getElementById('IframeEditProduct').open();
//            parent.document.getElementById('IframeEditProduct').write(data);
//            parent.document.getElementById('IframeEditProduct').close();
//            parent.document.getElementById('IframeEditProduct').innerHTML = data;
//          }
//          else {
//            parent.document.getElementById('IframeEditProduct').innerHTML = data;
//          }
//        } else {
          parent.document.removeChild(parent.document.getElementById("IframeEditProduct"));
          //parent.document.getElementById("IframeEditProduct").style.display = 'none';
          //alert(parent.document.getElementById("IframeEditProduct"));
          content = $.ajax({
            url: '<%=Routing.Product.UrlForAdminListProduct() %>',
            type: "POST",
            dataType: "html",
            async: false,
            success: function(msg) {
              alert(msg);
              if (parent.document.layers) {
                parent.document.getElementById('ListID').open();
                parent.document.getElementById('ListID').write(msg);
                parent.document.getElementById('ListID').close();
                parent.document.getElementById('ListID').innerHTML = msg;
              }
              else {
                parent.document.getElementById('ListID').innerHTML = msg;
              }

            }
          }).responseText;
        //}
      })
    }
    function ShowProgress() {
        //parent.document.getElementById("IframeEditProduct").style.display = 'block';
        parent.document.getElementById("IframeEditProduct").style.display = 'none';
    }
</script>

<form   id="EditProductID"  method='POST' enctype='multipart/form-data' action="<%=Routing.Product.UrlForEditProduct(Model.ID)%>">

    <%if (Model.ID == null || Model.ID.Equals(Guid.Empty))
          { %>
            <h2><%=Resources.Global.AddProduct %></h2>
        <%}
          else
          { %>
        <h2><%=Resources.Global.EditProduct %></h2>
        <%} %>
    
    <table  class="layout-form maxwidth" cellspacing="2" cellpadding="0" border="0">
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
        <%=Html.FckTextBox("Description",Model.Description)%>
        <%= Html.ValidationMessage("Description")%>
        </td>
        
     </tr>
    
    <tr>
    
    <tr>
        <td>
            <label ><%=Resources.Global.Image %>:</label>
        </td>
        <td>
        
        <p>
        <%=Html.IdFor("FileUpload")%>
        <%=Html.TextBox("FileUpload") %>
        <%--<input type="file" id="UploadFile" name="UploadFile" style="width:100%"/> --%>
        </p>
       <%=Html.Hidden("Image",((Model != null && !String.IsNullOrEmpty(Model.Image))?Model.Image:"")) %>
                <%=Html.ValidationMessage("Image")%>
                
      </td>
      </tr>
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
        <input   type="submit" class="abutton" value="<%=label%> " />
           <%-- <%=Html.SubmitToRemote(label, new RemoteOption
            { 
              CausesValidation=false,
              Method = "POST",
              URL = Routing.Product.UrlForEditProduct(Model.ID),
              Update = "ListID",
              OnSuccess = "ReloadAfterEdit",
            }) %>--%>
            </span>
        </td>
    </tr>
    </table>
    
</form>





