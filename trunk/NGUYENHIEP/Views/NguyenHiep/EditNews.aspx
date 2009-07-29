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
        Thêm tin t&#7913;c</h2>
    <%}
      else
      { %>
    <h2>
        Ch&#7881;nh s&#7917;a tin t&#7913;c</h2>
    <%} %>
    <table width="100%">
        <tr>
            <td class="l">
                <label for="TitleVN">
                    Tiêu &#273;&#7873;:</label>
            </td>
            <td class="l">
                <%= Html.TextBox("TitleVN", Model.TitleVN, new { @size="50"})%>
                <%= Html.ValidationMessage("TitleVN", "*") %>
            </td>
        </tr>
        <tr>
            <td class="l">
                <label for="SubjectVN">
                    Ch&#7911; &#273;&#7873;:</label>
            </td>
            <td class="l">
                <%= Html.TextBox("SubjectVN", Model.SubjectVN, new { @size = "50" })%>
                <%= Html.ValidationMessage("SubjectVN", "*") %>
            </td>
        </tr>
        <tr>
            <td class="l">
                <label>
                    N&#7897;i Dung:</label>
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
                    Lo&#7841;i:</label>
            </td>
            <td class="l">
                <%=Html.DropDownList("Type",((List<SelectListItem>)ViewData["NewsType"]).AsEnumerable()) %>
                <%= Html.ValidationMessage("Type", "*") %>
            </td>
        </tr>
        <tr>
            <td class="l">
                <label>
                    Hình &#7843;nh:</label>
            </td>
            <td class="l">
                <p>
                    <input type="file" id="UploadFile" name="UploadFile" size="23" />
                    <%Html.ValidationMessage("UploadFile"); %>
                </p>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="c">
                <%if (ViewData["AddNews"] != null)
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
