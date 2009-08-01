<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblInformation>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">

    <%--<%NguyenHiep.Utility.UIHelper.RenderRemotePartial(Html, "ListAllNewsID", "", (new UrlHelper(ViewContext.RequestContext)).Action("ListAllNews", "NguyenHiep") + "?pageSize=" + (int)NguyenHiep.Common.Constants.DefautPagingSize + "&page=1");%>--%>
    
    <%Html.RenderPartial("ViewContact",ViewData); %>
    <input type="hidden" id="SelectedMenuId" name="SelectedMenuId" value="6" />
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
                                document.getElementById('ListCategoryID').innerHTML = msg;
                                if (document.layers) {
                                    document.getElementById('ListCategoryID').className = "mainMnuLeft";
                                    document.getElementById('ListCategoryID').open();
                                    document.getElementById('ListCategoryID').write(msg);
                                    document.getElementById('ListCategoryID').close();
                                    document.getElementById('ListCategoryID').innerHTML = msg;
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
            async: false,
            dataType: "html",
            success: function(msg) {
                document.getElementById('ListNewsPromotionID').innerHTML = msg
                if (document.layers) {
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
                document.getElementById('ListHotNewsID').innerHTML = msg;
                if (document.layers) {
                    document.getElementById('ListHotNewsID').open();
                    document.getElementById('ListHotNewsID').write(msg);
                    document.getElementById('ListHotNewsID').close();
                    document.getElementById('ListHotNewsID').innerHTML = msg;
                }
                else {
                    document.all['ListHotNewsID'].innerHTML = msg;
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
