<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblInformation>" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="NguyenHiep.Utility" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">
<script type="text/javascript" language="javascript">
    var sBasePath = '<%= Url.Content("~/fckeditor/")%>';
</script>

    <form id="form1" runat="server" method='POST' enctype='multipart/form-data' action="#">
    
    <table width="100%">
        <tr>
            <td class="l">
                <label>
                    <%=Resources.Global.EnterContactInfo %>:</label>
            </td>
            </tr>
        <tr>
            <td><%if (HttpContext.Current.Response.Cookies["Culture"] != null && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
                  { %>
                    <%=Html.FckTextBox("ContactEN")%>
                    <%=Html.ValidationMessage("ContactEN") %>
                    <%}
                  else
                  { %>
                    <%=Html.FckTextBox("ContactVN")%>
                    <%=Html.ValidationMessage("ContactVN")%>
                    <%} %>
                <%--<%=Html.TextArea("contactVN", (((Model != null && String.IsNullOrEmpty(Model.ContactEN)) ? Model.ContactEN : "")), new { rows = 15, style = "width:100%" })%>--%>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="c">
                <input type="submit" value="<%=Resources.Global.Update %>" />
            </td>
        </tr>
    </table>
    </form>
</asp:Content>
