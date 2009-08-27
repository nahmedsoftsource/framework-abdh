﻿<%@ Page Title="Edit Product" Language="C#" Inherits="ABDHFramework.Controllers.BaseViewPage<ABDHFramework.Models.tblProduct>" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="ABDHFramework.Lib" %>
<%@ Import Namespace="ABDHFramework.Lib.Pager" %>
<%@ Import Namespace="ABDHFramework.Models" %>


<script type="text/javascript" language="javascript">
    var sBasePath = '<%= Url.Content("~/Admin/fckeditor/")%>';
</script>

    <form id="form1" runat="server"  method='POST' enctype='multipart/form-data' action="#">
    <%if (ViewData["AddProduct"] != null)
          { %>
            <h2><%=Resources.Global.AddProduct %></h2>
        <%}
          else
          { %>
        <h2><%=Resources.Global.EditProduct %></h2>
        <%} %>
    
    <table  class="layout-form  maxwidth" cellspacing="2" cellpadding="0" border="0">
    <tr>
        <td>
            <label for="ProductNameVN"><%=Resources.Global.ProductName %></label>
        </td>
        
        <td>
        <%if (HttpContext.Current.Response.Cookies["Culture"] != null && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
          { %>
            <%= Html.TextBox("ProductNameEN", (Model != null && Model.ProductNameEN != null) ? Model.ProductNameEN : "", new { style = "width:100%" })%>
            <%= Html.ValidationMessage("ProductNameEN")%>
            <%}
          else
          { %>
          <%= Html.TextBox("ProductNameVN", (Model != null && Model.ProductNameVN != null) ? Model.ProductNameVN : "", new { style = "width:100%" })%>
            <%= Html.ValidationMessage("ProductNameVN")%>
            <%} %>
        </td>
    </tr>
    <tr>
        <td>
        <label ><%=Resources.Global.Promoted %>:</label>
        </td>
        <td>
        <%=Html.DropDownList("Promoted", ((List<SelectListItem>)ViewData["Promotion"]).AsEnumerable(), new { style = "width:100%" })%>
        <%= Html.ValidationMessage("Promoted")%>
        </td>
    </tr>
    <tr>
        <td>
            <label ><%=Resources.Global.Warranty %>:</label>
        </td>
        
        <td>
        <%=Html.TextBox("WarrantyTime", ((Model != null && Model.WarrantyTime != null) ? Model.WarrantyTime : ""), new { style = "width:100%" })%>
        <%= Html.ValidationMessage("WarrantyTime")%>
        </td>
        
     </tr>
     <tr>
        <td>
            <label ><%=Resources.Global.Store %>:</label>
        </td>
        
        <td>
        <%=Html.DropDownList("StoreStatus", ((List<SelectListItem>)ViewData["StoreStatus"]).AsEnumerable(), new { style = "width:100%" })%>
        <%= Html.ValidationMessage("StoreStatus")%>
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
        <%if (HttpContext.Current.Response.Cookies["Culture"] != null && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
          { %>
        <%=Html.TextBox("PriceEN", (Model != null && Model.PriceEN.HasValue && String.IsNullOrEmpty(Model.PriceEN.ToString())) ? Model.PriceEN.ToString() : "0", new { style = "width:100%" })%>USD 
        <%= Html.ValidationMessage("PriceEN","Value is invalid")%>
        <%}
          else
          { %>
          <%=Html.TextBox("PriceVN", (Model != null && Model.PriceVN.HasValue && String.IsNullOrEmpty(Model.PriceVN.ToString())) ? Model.PriceVN.ToString() : "0", new { style = "width:100%" })%>VNÐ 
        <%= Html.ValidationMessage("PriceVN", "Giá trị nhập không hợp lệ")%>
        <%} %>
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
         <%if (Model != null && Model.ID != null && !Model.ID.Equals(Guid.Empty))
              {%>
              <%
                  byte type = ABDHFramework.Common.NewsTypes.NormalProduct;
                  if (ViewData["CurrentType"] != null) 
                {
                    
                    try
                    {
                        type = byte.Parse(ViewData["CurrentType"].ToString());
                    }
                    catch
                    {
                        type = ABDHFramework.Common.NewsTypes.NormalProduct;
                    }
                } 
                   %>
        
<%} %>
        <%if (Model != null && (Model.ID == null || Model.ID.Equals(Guid.Empty)))
          { %>
          <span style="float:right">
            <%=Html.SubmitToRemote(Resources.Global.AddCategory, new RemoteOption
            {
              CausesValidation=false,
              Method = "POST",
              URL = Routing.Product.UrlForEditProduct(Model.ID, null),
              Update = "ListID",
              
            }) %>
            </span>
        <%}
          else
          { %>
          <span style="float:right">
                <%=Html.SubmitToRemote(Resources.Global.Update,new RemoteOption
            {
              CausesValidation=false,
              Method = "POST",
              URL = Routing.Product.UrlForEditProduct(Model.ID,null),
              Update = "ListID",
              
            }) %>

        </span>
        <%} %>
        </td>
    </tr>
    </table>
    
    </form>





