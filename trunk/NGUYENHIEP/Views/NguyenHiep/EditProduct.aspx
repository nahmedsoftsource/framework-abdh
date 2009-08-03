<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblProduct>" %>
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
         <%if (Model != null && Model.ID != null && !Model.ID.Equals(Guid.Empty))
              {%>
              <%
                  byte type = NguyenHiep.Common.NewsTypes.NormalProduct;
                  if (ViewData["CurrentType"] != null) 
                {
                    
                    try
                    {
                        type = byte.Parse(ViewData["CurrentType"].ToString());
                    }
                    catch
                    {
                        type = NguyenHiep.Common.NewsTypes.NormalProduct;
                    }
                } 
                   %>
            <span style="float: left">
    <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "Delete", Resources.Global.Delete, (new UrlHelper(ViewContext.RequestContext)).Action("EditProduct") + "?newsID=" + Model.ID + "&Type=" + type+ "&Delete=true")%>
</span>
<%} %>
        <%if (ViewData["AddProduct"] != null)
          { %>
          <span style="float:right">
            <input type="submit" class="abutton" value="<%=Resources.Global.AddProduct %>" />
            </span>
        <%}
          else
          { %>
          <span style="float:right">
        <input type="submit" class="abutton" value="<%=Resources.Global.Edit %>" />
        </span>
        <%} %>
        </td>
    </tr>
    </table>
    
    </form>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenu" runat="server">
<script language="javascript" type="text/javascript">
    var a= "";
    $(document).ready(function() {
        $.ajaxSetup();
        $.ajax({
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

        });
    })
                    </script>
                    <div id="ListCategoryID">
                    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PromotionAnnoucement" runat="server">
<script language="javascript" type="text/javascript">

    var content2 = "";
    $(document).ready(function() {

        content2 = $.ajax({
            url: '<%=Url.Content("~/NguyenHiep/ListPromotionNews") %>',
            global: false,
            type: "POST",
            dataType: "html",
            async: false,
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
            dataType: "html",
            async: false,
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
                    <div id="ListHotNewsID">
                    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LowerMainContent" runat="server">
</asp:Content>


