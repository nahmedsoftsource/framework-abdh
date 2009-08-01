﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblNew>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">
    <%if (Model != null)
      { %>
      <div class="barCterTab">
    <div class="barCterTabLleft">
        <div class="barCterTabRight">
            <div style="line-height: 23px;" class="ctentBarTab">
                <%=Resources.Global.News%>
            </div>
        </div>
    </div>
</div>
    <div id="mainCtentSpRight">
        <div class="boxCtentSp">
            <div class="boxCtentSpTop">
                <div class="boxCtentSpBtom">
                    <div class="boxCtentSpCtent">
                        <div class="textLeft">
                        
                            <%if (!String.IsNullOrEmpty(Model.Image))
                              { %>
                            <span style="float: left"><a href="#">
                                <img class="imgGthieu" src='<%= Url.Content("~"+Model.Image)%>' /></a> </span>
                            <%} %>
                            <div class="paddingTb4 bold"><%--<a class="color2" href="#">--%>
                            <%if (HttpContext.Current.Response.Cookies["Culture"] != null && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
                              { %>
                            <%=(!String.IsNullOrEmpty(Model.TitleEN)) ? Model.TitleEN : Resources.Global.NoTitle%>
                            <%--</a>--%>
                            <%}else{ %>
                            <%=(!String.IsNullOrEmpty(Model.TitleVN)) ? Model.TitleVN : Resources.Global.NoTitle%>
                            <%} %>
                            </div>

                            <p>
                            <%if (HttpContext.Current.Response.Cookies["Culture"] != null && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
                              { %>
                              <%=(!String.IsNullOrEmpty(Model.SubjectEN)) ? Model.SubjectEN : Resources.Global.NoSubject%>
                                  <%}
                              else
                              { %>
                              <%=(!String.IsNullOrEmpty(Model.SubjectVN)) ? Model.SubjectVN : Resources.Global.NoSubject%>
                                  <%} %>
                            </p>
                            <p>
                                <%if (HttpContext.Current.Response.Cookies["Culture"] != null && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
                                  { %>
                                <%=((Model.ContentEN != null) ? Model.ContentEN : "")%>
                                <%}
                                  else
                                  { %>
                                <%=((Model.ContentVN != null) ? Model.ContentVN : "")%>
                                <%} %>
                                </p>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <span style="float:right">
        <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "EditNews", Resources.Global.Edit, (new UrlHelper(ViewContext.RequestContext)).Action("EditNews", "NguyenHiep") + "?newsID=" + Model.ID)%>
        </span>
    </div>
    <%} %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenu" runat="server">
<script language="javascript" type="text/javascript">
    var a = "";
    $(document).ready(function() {
        $.ajaxSetup();
        $.ajax({
            url: '<%=Url.Content("~/NguyenHiep/ListCategory") %>',
            global: false,
            type: "POST",
            dataType: "html",
            success: function(msg) {
                document.getElementById('ListCategoryID').innerHTML = msg;
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

        });
        //                    $("#ListCategoryID").load('<%=Url.Content("~/NguyenHiep/ListCategory") %>');
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
<script language="javascript" type="text/javascript">

    var content3 = "";
    $(document).ready(function() {

        content3 = $.ajax({
        url: '<%=Url.Content("~/NguyenHiep/ListHotNews") %>',
            global: false,
            type: "POST",
            dataType: "html",
            success: function(msg) {
            document.getElementById('ListHotNewsID').innerHTML = msg
                if (document.layers) {
                    alert(document.getElementById('ListHotNewsID').innerHTML);
                    document.getElementById('ListHotNewsID').open();
                    document.getElementById('ListHotNewsID').write(msg);
                    document.getElementById('ListHotNewsID').close();
                    document.getElementById('ListHotNewsID').innerHTML = msg
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