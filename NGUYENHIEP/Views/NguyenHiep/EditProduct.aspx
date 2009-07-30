<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblProduct>" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="NguyenHiep.Utility" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">
    <form id="form1" runat="server"  method='POST' enctype='multipart/form-data' action="#">
    <%if (ViewData["AddProduct"] != null)
          { %>
            <h2><%=Resources.Global.AddProduct %></h2>
        <%}
          else
          { %>
        <h2><%=Resources.Global.EditProduct %></h2>
        <%} %>
    

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

  

    <table width="100%">
    <tr>
        <td>
            <label for="ProductNameVN"><%=Resources.Global.ProductName %></label>
        </td>
        
        <td>
            <%= Html.TextBox("ProductNameVN", Model.ProductNameVN, new { @size = "50" })%>
            <%= Html.ValidationMessage("ProductNameVN", "*")%>
        </td>
    </tr>
    <tr>
        <td>
            <label for="Promoted"><%=Resources.Global.Promoted %>:</label>
        </td>
        
        <td>
            <%=Html.DropDownList("Promoted", ((List<SelectListItem>)ViewData["Promotion"]).AsEnumerable())%>
                                                <%= Html.ValidationMessage("Promoted", "*")%>
        </td>
    </tr>
    <tr>
        <td>
            <label ><%=Resources.Global.Warranty %>:</label>
        </td>
        
        <td>
        <%=Html.TextBox("WarrantyTime","")%>
        </td>
        
     </tr>
     <tr>
        <td>
            <label ><%=Resources.Global.Store %>:</label>
        </td>
        
        <td>
        <%=Html.DropDownList("StoreStatus", ((List<SelectListItem>)ViewData["StoreStatus"]).AsEnumerable())%>
        </td>
        
     </tr>
     <tr>
        <td>
            <label ><%=Resources.Global.TypeName %>:</label>
        </td>
        
        <td>
        <%=Html.DropDownList("CategoryID", ((List<SelectListItem>)ViewData["Categories"]).AsEnumerable())%>
        </td>
        
     </tr>
     <tr>
        <td>
            <label ><%=Resources.Global.Price %>:</label>
        </td>
        
        <td>
        <%=Html.TextBox("PriceVN", "", new  {style="width:100%" })%>VNÐ </div>
        </td>
        
     </tr>
      <tr>
        <td>
            <label ><%=Resources.Global.ShortDescription %>:</label>
        </td>
        
        <td>
         <%=Html.TextArea("Property", "", new { rows=5,cols=20})%>
        </td>
      </tr>
     <tr>
        <td>
            <label ><%=Resources.Global.Details %>:</label>
        </td>
        
        <td>
        <%=Html.FckTextBox("Description")%>
        </td>
        
     </tr>
    
    <tr>
        <td>
            <%=Html.Hidden("ImageBackup",(Model.Image!=null)?Model.Image:"") %>
            <label ><%=Resources.Global.Image %>:</label>
        </td>
        <td>
        <p><input type="file" id="UploadFile" name="UploadFile" size="23"/> </p>
      </td>
    
       
    </tr>
    <tr>
        <td colspan="2">
        <%if (ViewData["AddProduct"] != null)
          { %>
            <input type="submit" value="<%=Resources.Global.AddProduct %>" />
        <%}
          else
          { %>
        <input type="submit" value="<%=Resources.Global.Edit %>" />
        <%} %>
        </td>
    </tr>
    </table>
    
    </form>

</asp:Content>


