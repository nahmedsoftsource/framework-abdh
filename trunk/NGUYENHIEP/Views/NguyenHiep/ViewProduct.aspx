<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblProduct>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">
<div  class="mainCtentSpRight">
        	<div class="barCterTab">
            	<div class="barCterTabLleft">
                	<div class="barCterTabRight">
                    	<div style="line-height:23px;" class="ctentBarTab">
                        	Sản phẩm chi tiết
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

                                    <a href="#"><img class="imgGthieu" src="../..<%=((Model.Image != null)?Model.Image:"")%>" /></a>
                                </div>
		                        <div class="floatLeft" style="width:530px;">
				                    <div class="bold fontsize13"><a href="#" class="color2">Butyl Carbitol (BC)</a></div>
				                    <div><span class="bold">Khuyến Mãi:</span><%=(Model.Promoted.HasValue && Model.Promoted.Value)?"Có khuyến mãi":"Không có khuyến mãi" %> </div>
				                    <div><span class="bold">Bảo hành:</span><%=((Model.WarrantyTime!=null)?Model.WarrantyTime:"")%></div>

			                        <div><span class="bold">Kho:</span><%=((Model.StoreStatus.HasValue && Model.StoreStatus.Value)?"Trong kho còn hàng":"Trong kho hết hàng") %></div>
                                    <div><span class="bold">Tên loại sản phẩm:</span> <a href="#" class="color1"><%=((Model.tblCategory!=null)?Model.tblCategory.CategoryNameVN:"Chưa cập nhật")%></a> </div>
			                        <div class="bold"><span class="bold color1">Giá: </span><%=(((Model.PriceVN.HasValue)?Model.PriceVN.ToString():" ")+ "VND")%></div>
				                    <div><%=(Model.Property!=null)?Model.Property:""%></div>

		                        </div>
					            <div class="clear"></div>
			                </div>
                            <div class="bold fontsize13" style=" border-bottom:2px solid #487DBD; background:#99C8E1; margin-bottom:20px; padding: 2px 0 2px 2px;">Thông tin chi tiết</div>
                            <div class="paddingTb4"><a class="color2" href="#"></a>
                                
                                <%=((Model.Description!=null)?Model.Description:"")%>
                            </div>
                  
                        </div>
                    </div>
                </div>
            </div>
<%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "EditProduct", "Sửa", (new UrlHelper(ViewContext.RequestContext)).Action("EditProduct", "NguyenHiep") + "?newsID=" + Model.ID)%>
<input type="hidden" id="SelectedMenuId" name="SelectedMenuId" value="6" />
</div>
</asp:Content>


