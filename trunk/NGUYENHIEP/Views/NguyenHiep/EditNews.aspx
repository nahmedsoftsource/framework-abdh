<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblNew>" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="NguyenHiep.Utility" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">
<script type="text/javascript" language="javascript">
    var sBasePath = '<%= Url.Content("~/fckeditor/")%>';
</script>

<%Html.ValidationSummary(); %>
    <form id="form1" runat="server" method='POST' enctype='multipart/form-data' action="#">
    <%if (ViewData["AddNews"] != null)
      { %>
    <h2>
        <%=Resources.Global.AddNews %></h2>
    <%}
      else
      { %>
    <h2>
        <%=Resources.Global.EditNew %></h2>
    <%} %>
    <table width="100%">
        <tr>
            <td class="l">
                <label for="TitleVN">
                    <%=Resources.Global.Title %>:</label>
            </td>
            <td class="l">
                <%= Html.TextBox("TitleVN", Model.TitleVN, new { @size="50"})%>
                <%= Html.ValidationMessage("TitleVN", "*") %>
            </td>
        </tr>
        <tr>
            <td class="l">
                <label for="SubjectVN">
                    <%=Resources.Global.Subject %>:</label>
            </td>
            <td class="l">
                <%= Html.TextBox("SubjectVN", Model.SubjectVN, new { @size = "50" })%>
                <%= Html.ValidationMessage("SubjectVN", "*") %>
            </td>
        </tr>
        <tr>
            <td class="l">
                <label>
                    <%=Resources.Global.Content %>:</label>
            </td>
            <td>
                <div style="border:solid 1px">
                    <%=Html.FckTextBox("ContentVN")%>
                </div>
            </td>
        </tr>
        <tr>
            <td class="l">
                <label>
                   <%=Resources.Global.Type %>:</label>
            </td>
            <td class="l">
                <%=Html.DropDownList("Type",((List<SelectListItem>)ViewData["Type"]).AsEnumerable()) %>
                <%= Html.ValidationMessage("Type", "*") %>
            </td>
        </tr>
        <tr>
            <td class="l">
                <label>
                    <%=Resources.Global.Image %>:</label>
            </td>
            <td class="l">
                <p>
                    <input type="file" id="UploadFile" name="UploadFile" size="23" />
                    <%Html.ValidationMessage("UploadFile"); %>
                </p>
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
        <tr>
            <td colspan="2" class="c">
                <%if (ViewData["AddNews"] != null)
                  { %>
                <input type="submit" value="<%=Resources.Global.AddNews %>" />
                <%}
                  else
                  { %>
                <input type="submit" value="<%=Resources.Global.Update %>" />
                <%} %>
            </td>
        </tr>
    </table>
    </form>
</asp:Content>
