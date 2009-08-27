<%@ Page Title="Product"  Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="ABDHFramework.Controllers.BaseViewPage<ABDHFramework.Data.SearchResult<ABDHFramework.Models.tblProduct>>" %>
<%@ Import Namespace="ABDHFramework.Lib" %>
<%@ Import Namespace="ABDHFramework.Lib.Pager" %>
<%@ Import Namespace="ABDHFramework.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">
    <div class="mainCtentSpRight" id="ListAllID">
        <%Html.RenderPartial("ListProduct", ViewData); %>
        <input type="hidden" id="SelectedMenuId" name="SelectedMenuId" value="3" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenu" runat="server">
  
  <% Html.RenderTabPanel("LeftTabs",
      new TabPane[]{
        new TabPane{ ID="L_QuickFind", Title="Search",ViewName="QuickSearch"}
      }
        
      ); %>
      <div>
      <br />
      </div>
      <div class="detail-title">
        Category
      </div>
   <script language="javascript" type="text/javascript">
    var a= "";
    $(document).ready(function() {
        $.ajaxSetup();
        $.ajax({
            url: '<%=Url.Content("~/Category/ListCategory") %>',
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

        });
        $(".msg_body").hide();
        //toggle the componenet with class msg_body
        $(".msg_head").click(function() {
        $(this).next(".msg_body").slideToggle(600);
        });
    })
    
    
    </script>
    <div id="ListCategoryID" class="content-border" >
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PromotionAnnoucement" runat="server">
<script language="javascript" type="text/javascript">

    var content = "";
    $(document).ready(function() {
        content = $.ajax({
            url: '<%=Url.Content("~/ABDHFramework/ListPromotionNews") %>',
            global: false,
            type: "POST",
            dataType: "html",
            async: false,
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
            url: '<%=Url.Content("~/ABDHFramework/ListHotNews") %>',
            global: false,
            type: "POST",
            dataType: "html",
            async: false,
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
                   <div id="ListHotNewsID" class="boxNews">
                    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LowerMainContent" runat="server">
</asp:Content>
