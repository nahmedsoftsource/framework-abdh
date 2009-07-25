<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblNew>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">
    <%if (ViewData["AddNews"] != null)
          { %>
            <h2>Thêm tin tức</h2>
        <%}
          else
          { %>
        <h2>Chỉnh sửa tin tức</h2>
        <%} %>
    

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

    <table width="100%">
    <tr>
        <td>
            <label for="TitleVN">Tiêu đề:</label>
        </td>
        
        <td>
            <%= Html.TextBox("TitleVN", Model.TitleVN) %>
            <%= Html.ValidationMessage("TitleVN", "*") %>
        </td>
    </tr>
    <tr>
        <td>
            <label for="SubjectVN">Chủ đề:</label>
        </td>
        
        <td>
            <%= Html.TextBox("SubjectVN", Model.SubjectVN) %>
                <%= Html.ValidationMessage("SubjectVN", "*") %>
        </td>
    </tr>
    <tr>
        <td>
            <label for="ContentVN">Nội Dung:</label>
        </td>
        
        <td>
            <%= Html.TextBox("ContentVN", Model.ContentVN)%>
                <%= Html.ValidationMessage("ContentVN", "*")%>
        </td>
    </tr>
    <tr>
        <td>
            <label for="ContentVN">Loại:</label>
        </td>
        
        <td>
            <%=Html.DropDownList("Model.Type",((List<SelectListItem>)ViewData["NewsType"]).AsEnumerable()) %>
                <%= Html.ValidationMessage("Type", "*") %>
        </td>
    </tr>
    <tr>
        <td>
            <label for="ContentVN">Hình ảnh:</label>
        </td>
        
        <td>
            <%= Html.TextBox("Image", Model.Image)%>
                <%= Html.ValidationMessage("Image", "*")%>
        </td>
    </tr>
    <tr>
        <td colspan="2">
        <%if (ViewData["AddNews"] != null)
          { %>
            <input type="submit" value="Thêm tin tức" />
        <%}
          else
          { %>
        <input type="submit" value="Sửa" />
        <%} %>
        </td>
    </tr>
    </table>
      

    <% } %>

   


</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="RightMenu" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="LowerMainContent" runat="server">
</asp:Content>

