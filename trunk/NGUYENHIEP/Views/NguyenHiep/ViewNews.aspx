<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblNew>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">
<%if (Model != null)
  { %>
<div id="mainCtentSpRight">
<div class="boxCtentSp">
            	<div class="boxCtentSpTop">
                	<div class="boxCtentSpBtom">
                    	<div class="boxCtentSpCtent">
                        	<div class="textLeft">
                        	<%if (!String.IsNullOrEmpty(Model.Image))
                           { %>
                           <span style="float:left">
                            	<a href="#"><img class="imgGthieu" src='<%= Url.Content("~"+Model.Image)%>' /></a>
                            	</span>
                            <%} %>
                              <div class="paddingTb4 bold"><a class="color2" href="#"></a>
                                
                                <%=((Model.ContentVN != null) ? Model.ContentVN : "")%>
                            </div>
                            <div class="clear"></div>
                        </div>
                    </div>
                </div>

            </div>
</div>
<%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "EditNews", "Sửa", (new UrlHelper(ViewContext.RequestContext)).Action("EditNews", "NguyenHiep") + "?newsID=" + Model.ID)%>
</div>
<%} %>
</asp:Content>


