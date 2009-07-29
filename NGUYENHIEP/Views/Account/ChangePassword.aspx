<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="changePasswordContent" ContentPlaceHolderID="UpperMainContent" runat="server">     
<div class="barCterTab">
    	<div class="barCterTabLleft">
        	<div class="barCterTabRight">
            	<div style="line-height:23px;" class="ctentBarTab">
                	    Change Password
                </div>

            </div>
        </div>
    </div>
    <p>
        New passwords are required to be a minimum of <%=Html.Encode(ViewData["PasswordLength"])%> characters in length.
    </p>
    <%= Html.ValidationSummary("Password change was unsuccessful. Please correct the errors and try again.")%>

    <% using (Html.BeginForm()) { %>
        <div>
            <fieldset>
                <legend>Account Information</legend>
                      <table width="100%">
                       <tr>
                            <td width:"20%" style="width: 131px">
                                <label for="email">Current Password:</label>
                            </td>                           
                            <td>
                                <%= Html.Password("currentPassword") %>
                                <%= Html.ValidationMessage("currentPassword") %>
                            </td>
                        </tr>
                        <tr>
                            <td width:"20%" style="width: 131px">
                                <label for="password">New Password:</label>
                            </td>
                            
                            <td>
                                <%= Html.Password("newPassword") %>
                                <%= Html.ValidationMessage("newPassword") %>
                            </td>
                        </tr>
                        <tr>
                            <td width:"20%" style="width: 131px">
                                <label for="confirmPassword">Confirm password:</label>
                            </td>
                            
                            <td>                                
                                <%= Html.Password("confirmPassword") %>
                                <%= Html.ValidationMessage("confirmPassword") %>
                            </td>
                        </tr>
                     </table>                
                <p>
                    <input type="submit" value="Change Password" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
