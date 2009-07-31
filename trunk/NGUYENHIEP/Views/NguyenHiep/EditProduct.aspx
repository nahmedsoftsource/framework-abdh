<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblProduct>" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="NguyenHiep.Utility" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">
<script type="text/javascript" language="javascript">
    var sBasePath = '<%= Url.Content("~/fckeditor/")%>';
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
    

    <%--<%= Html.ValidationSummary() %>--%>

  

    <table width="100%">
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
        <%=Html.TextBox("PriceEN", (Model != null && Model.PriceEN.HasValue && String.IsNullOrEmpty(Model.PriceEN.ToString())) ? Model.PriceEN.ToString() : "", new { style = "width:100%" })%>USD 
        <%= Html.ValidationMessage("PriceEN","Value is invalid")%>
        <%}
          else
          { %>
          <%=Html.TextBox("PriceVN", (Model != null && Model.PriceVN.HasValue && String.IsNullOrEmpty(Model.PriceVN.ToString())) ? Model.PriceVN.ToString() : "", new { style = "width:100%" })%>VNÐ 
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
        <%if (ViewData["AddProduct"] != null)
          { %>
          <span style="float:right">
            <input type="submit" value="<%=Resources.Global.AddProduct %>" />
            </span>
        <%}
          else
          { %>
          <span style="float:right">
        <input type="submit" value="<%=Resources.Global.Edit %>" />
        </span>
        <%} %>
        </td>
    </tr>
    </table>
    
    </form>

</asp:Content>


