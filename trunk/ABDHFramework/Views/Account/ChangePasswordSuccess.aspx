<%@Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="changePasswordSuccessContent" ContentPlaceHolderID="UpperMainContent" runat="server">     
<div class="barCterTab">
    	<div class="barCterTabLleft">
        	<div class="barCterTabRight">
            	<div style="line-height:23px;" class="ctentBarTab">
                	    <%=Resources.Global.ChangePassword %>
                </div>

            </div>
        </div>
    </div>
    <p>
        <%=Resources.Global.ChangePasswordSuccess %>
    </p>
</asp:Content>
