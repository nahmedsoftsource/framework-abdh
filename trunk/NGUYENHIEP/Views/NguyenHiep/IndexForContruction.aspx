<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NguyenHiep.Data.SearchResult<NGUYENHIEP.Models.tblNew>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">

    <%--<%NguyenHiep.Utility.UIHelper.RenderRemotePartial(Html, "ListAllNewsID", "", (new UrlHelper(ViewContext.RequestContext)).Action("ListAllNews", "NguyenHiep") + "?pageSize=" + (int)NguyenHiep.Common.Constants.DefautPagingSize + "&page=1");%>--%>
    <div class="mainCtentSpRight" id="ListAllContructionID">
    <%Html.RenderPartial("ListAllContruction",ViewData); %>
    <input type="hidden" id="SelectedMenuId" name="SelectedMenuId" value="5" />
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenu" runat="server">
<script language="javascript" type="text/javascript">

    var content = "";
    $(document).ready(function() {
        content = $.ajax({
            url: '<%=Url.Content("~/NguyenHiep/ListCategory") %>',
            global: false,
            type: "POST",
            dataType: "html",
            success: function(msg) {
                document.getElementById('ListCategoryID').innerHTML = msg
                if (document.layers) {
                    alert(document.getElementById('ListCategoryID').innerHTML);
                    document.getElementById('ListCategoryID').open();
                    document.getElementById('ListCategoryID').write(msg);
                    document.getElementById('ListCategoryID').close();
                    document.getElementById('ListCategoryID').innerHTML = msg
                }
                else {
                    document.all['ListCategoryID'].innerHTML = msg;
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
            dataType: "html",
            success: function(msg) {
                document.getElementById('ListNewsPromotionID').innerHTML = msg
                if (document.layers) {
                    alert(document.getElementById('ListNewsPromotionID').innerHTML);
                    document.getElementById('ListNewsPromotionID').open();
                    document.getElementById('ListNewsPromotionID').write(msg);
                    document.getElementById('ListNewsPromotionID').close();
                    document.getElementById('ListNewsPromotionID').innerHTML = msg
                }
                else {
                    document.all['ListNewsPromotionID'].innerHTML = msg;
                }

            }

        }).responseText;
    })
                    </script>
                    <div id="ListNewsPromotionID">
                    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="RiightNewsEvent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="LowerMainContent" runat="server">
</asp:Content>
