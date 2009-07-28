<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblProduct>" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="NguyenHiep.Utility" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">
    <form id="form1" runat="server"  method='POST' enctype='multipart/form-data' action="#">
    <%if (ViewData["AddProduct"] != null)
          { %>
            <h2>Thêm tin t&#7913;c</h2>
        <%}
          else
          { %>
        <h2>Ch&#7881;nh s&#7917;a tin t&#7913;c</h2>
        <%} %>
    

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

  

    <table width="100%">
    <tr>
        <td>
            <label for="ProductNameVN">Tên sản phẩm:</label>
        </td>
        
        <td>
            <%= Html.TextBox("ProductNameVN", Model.ProductNameVN, new { @size = "50" })%>
            <%= Html.ValidationMessage("ProductNameVN", "*")%>
        </td>
    </tr>
    <tr>
        <td>
            <label for="Promoted">Khuyến Mãi:</label>
        </td>
        
        <td>
            <%=Html.DropDownList("Promoted", ((List<SelectListItem>)ViewData["Promotion"]).AsEnumerable())%>
                                                <%= Html.ValidationMessage("Promoted", "*")%>
        </td>
    </tr>
    <tr>
        <td>
            <label >Bảo hành:</label>
        </td>
        
        <td>
        <%=Html.TextBox("WarrantyTime","")%>
        </td>
        
     </tr>
     <tr>
        <td>
            <label >Kho:</label>
        </td>
        
        <td>
        <%=Html.DropDownList("StoreStatus", ((List<SelectListItem>)ViewData["StoreStatus"]).AsEnumerable())%>
        </td>
        
     </tr>
     <tr>
        <td>
            <label >Tên loại sản phẩm:</label>
        </td>
        
        <td>
        <%=Html.DropDownList("CategoryID", ((List<SelectListItem>)ViewData["Categories"]).AsEnumerable())%>
        </td>
        
     </tr>
     <tr>
        <td>
            <label >Giá:</label>
        </td>
        
        <td>
        <%=Html.TextBox("PriceVN", "", new  {style="width:100%" })%>VNÐ </div>
        </td>
        
     </tr>
      <tr>
        <td>
            <label >Mô tả ngắn </label>
        </td>
        
        <td>
         <%=Html.TextArea("Property", "", new { rows=5,cols=20})%>
        </td>
      </tr>
     <tr>
        <td>
            <label >Thông tin chi tiết</label>
        </td>
        
        <td>
        <%=Html.FckTextBox("Description")%>
        </td>
        
     </tr>
    
    <tr>
        <td>
            <%=Html.Hidden("ImageBackup",(Model.Image!=null)?Model.Image:"") %>
            <label >Hình Ảnh</label>
        </td>
        <td>
        <p><input type="file" id="UploadFile" name="UploadFile" size="23"/> </p>
      </td>
    
       
    </tr>
    <tr>
        <td colspan="2">
        <%if (ViewData["AddProduct"] != null)
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


