<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblInformation>" %>

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
            <span style="float:right">
                <input type="submit" value="<%=Resources.Global.Update %>" />
                </span>
            </td>
        </tr>
    </table>
    </form>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenu" runat="server">
<script language="javascript" type="text/javascript">

    var content = "";
    $(document).ready(function() {
        content = $.ajax({
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

        }).responseText;
    })
                    </script>
                    <div id="ListCategoryID">
                    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PromotionAnnoucement" runat="server">
                   
<script language="javascript" type="text/javascript">

    var content = "";
    $(document).ready(function() {
        content = $.ajax({
            url: '<%=Url.Content("~/NguyenHiep/ListPromotionNews") %>',
            global: false,
            type: "POST",
            async: false,
            dataType: "html",
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
            async: false,
            dataType: "html",
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
                    <div id="ListHotNewsID">                    </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="LowerMainContent" runat="server">
</asp:Content>
