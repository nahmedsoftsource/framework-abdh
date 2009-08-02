<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblProduct>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">
<%if (Model != null)
  { %>
<div  class="mainCtentSpRight">
        	<div class="barCterTab">
            	<div class="barCterTabLleft">
                	<div class="barCterTabRight">
                    	<div style="line-height:23px;" class="ctentBarTab">
                        	<%=Resources.Global.ProductDetails %>
                        </div>

                    </div>
                </div>
            </div>
            <div class="boxCtentSp">
            	<div class="boxCtentSpTop">
                	<div class="boxCtentSpBtom">
                    	<div class="boxCtentSpCtent">
                            <div class="paddingTb4">
				                <div class="floatLeft" style="width:150px;">

                                    <a href="#"><img class="imgGthieu" src='<%= Url.Content("~"+((Model.Image != null)?Model.Image.Replace("ThumbImagesNewsSmallest", "ThumbImagesNews"):""))%>' /></a>
                                </div>
		                        <div class="floatLeft" style="width:530px;">
				                    <div class="bold fontsize13 textLine"><a href="#" class="color2">Butyl Carbitol (BC)</a></div>
				                    <div class="textLine"><span class="bold"><%=Resources.Global.PromotionProgram %>:</span><%=(Model.Promoted.HasValue && Model.Promoted.Value) ? Resources.Global.IsPromoted : Resources.Global.NotPromoted%> </div>
				                    <div class="textLine"><span class="bold"><%=Resources.Global.Warranty %>:</span><%=((Model.WarrantyTime != null) ? Model.WarrantyTime : "")%></div>

			                        <div class="textLine"><span class="bold"><%=Resources.Global.Store %>:</span><%=((Model.StoreStatus.HasValue && Model.StoreStatus.Value) ? Resources.Global.AvailableInStore : Resources.Global.EmptyInStore)%></div>
			                         <%if (HttpContext.Current.Response.Cookies["Culture"] != null && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
                              { %>
                                    <div class="textLine"><span class="bold"><%=Resources.Global.ProductType%>:</span> <a href="#" class="color1"><%=((Model.tblCategory != null) ? Model.tblCategory.CategoryNameEN : Resources.Global.NotAvailable)%></a> </div>
                                    <%}
                              else
                              { %>
                              <div class="textLine"><span class="bold"><%=Resources.Global.ProductType%>:</span> <a href="#" class="color1"><%=((Model.tblCategory != null) ? Model.tblCategory.CategoryNameVN : Resources.Global.NotAvailable)%></a> </div>
                                    <%} %>
			                        <div class="bold textLine"><span class="bold color1"><%=Resources.Global.Price %>: </span><%=(((Model.PriceVN.HasValue) ? Model.PriceVN.ToString() : " ") + "VND")%></div>
				                    <div><%=(Model.Property != null) ? Model.Property : ""%></div>

		                        </div>
					            <div class="clear"></div>
			                </div>
                            <div class="bold fontsize13" style=" border-bottom:2px solid #487DBD; background:#99C8E1; margin-bottom:20px; padding: 2px 0 2px 2px;"><%=Resources.Global.Details%></div>
                            <div class="paddingTb4"><a class="color2" href="#"></a>
                                
                                <%=((Model.Description != null) ? Model.Description : "")%>
                            </div>
                  
                        </div>
                    </div>
                </div>
            </div>
       <span style="float:right">
        <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "EditProduct", Resources.Global.Edit, (new UrlHelper(ViewContext.RequestContext)).Action("EditProduct", "NguyenHiep") + "?newsID=" + Model.ID+ ((ViewData["Type"] != null) ? ("&Type" + ViewData["Type"]) : ""))%>
        </span>
</div>
<%} %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenu" runat="server">
<script language="javascript" type="text/javascript">
    var a= "";
    $(document).ready(function() {
        $.ajaxSetup();
        $.ajax({
            url: '<%=Url.Content("~/NguyenHiep/ListCategory") %>',
            global: false,
            type: "POST",
            dataType: "html",
            async: false,
            success: function(msg) {
                
                if (document.layers) {
                    alert(document.getElementById('ListCategoryID').innerHTML);
                    document.getElementById('ListCategoryID').open();
                    document.getElementById('ListCategoryID').write(msg);
                    document.getElementById('ListCategoryID').close();
                    document.getElementById('ListCategoryID').innerHTML = msg
                }
                else {
                    document.getElementById('ListCategoryID').innerHTML = msg;
                }

            }

        });
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
            async: false,
            success: function(msg) {

                if (document.layers) {
                    alert(document.getElementById('ListNewsPromotionID').innerHTML);
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
            dataType: "html",
            async: false,
            success: function(msg) {

                if (document.layers) {
                    alert(document.getElementById('ListHotNewsID').innerHTML);
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
                    <div id="ListHotNewsID">
                    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LowerMainContent" runat="server">
</asp:Content>



