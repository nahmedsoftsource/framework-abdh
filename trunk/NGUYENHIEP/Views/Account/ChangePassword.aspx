<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="changePasswordContent" ContentPlaceHolderID="UpperMainContent" runat="server">     
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
        <%=Resources.Global.WarningPasswordLength %>
    </p>
    
    <% using (Html.BeginForm()){
    %>
        <div>
            <fieldset>
                <legend><%=Resources.Global.AccountInfor%></legend>
                      <table width="100%">
                       <tr>
                            <td width:"20%" style="width: 131px">
                                <label for="email"><%=Resources.Global.CurrentPassword%>:</label>
                            </td>                           
                            <td>
                                <%= Html.Password("currentPassword")%>
                                <%= Html.ValidationMessage("currentPassword")%>
                            </td>
                        </tr>
                        <tr>
                            <td width:"20%" style="width: 131px">
                                <label for="newPassword"><%=Resources.Global.NewPassword%>:</label>
                            </td>
                            
                            <td>
                                <%= Html.Password("newPassword")%>
                                <%= Html.ValidationMessage("newPassword")%>
                            </td>
                        </tr>
                        <tr>
                            <td width:"20%" style="width: 131px">
                                <label for="confirmPassword"><%=Resources.Global.ConfirmPassword%>:</label>
                            </td>
                            
                            <td>                                
                                <%= Html.Password("confirmPassword")%>
                                <%= Html.ValidationMessage("confirmPassword")%>
                            </td>
                        </tr>
                         <tr>
                            <td width:"20%" style="width: 131px">
                            </td>                            <td>                                
                                <input type="submit" value="<%=Resources.Global.ChangePassword %>" />
                            </td>
                        </tr>
                     </table>                
            </fieldset>
        </div>
    <% }%>
</asp:Content>
