<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblNew>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">
<div id="mainCtentSpRight">
<div class="boxCtentSp">
            	<div class="boxCtentSpTop">
                	<div class="boxCtentSpBtom">
                    	<div class="boxCtentSpCtent">
                        	<div class="textLeft">
                            	<a href="#"><img class="imgGthieu" src="../..<%=Model.Image%>" /></a>

                              <div class="paddingTb4 bold"><a class="color2" href="#"></a>
                                
                                <%=Model.ContentVN %>
                            </div>
                            <div class="clear"></div>
                        </div>
                    </div>
                </div>

            </div>
</div>
<%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "Sửa", "EditNews", (new UrlHelper(ViewContext.RequestContext)).Action("EditNews", "NguyenHiep") + "?newsID=" + Model.ID)%>
</div>
</asp:Content>


