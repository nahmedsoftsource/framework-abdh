<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblUser>" %>

<asp:Content ID="registerContent" ContentPlaceHolderID="UpperMainContent" runat="server">
       <div class="barCterTab">
    	<div class="barCterTabLleft">
        	<div class="barCterTabRight">
            	<div style="line-height:23px;" class="ctentBarTab">
                	Create a New Account
                </div>

            </div>
        </div>
    </div>
    
    <p>
        Use the form below to create a new account. 
    </p>
    <p>
        Passwords are required to be a minimum of <%=Html.Encode(ViewData["PasswordLength"])%> characters in length.
    </p>
    <%= Html.ValidationSummary("Account creation was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) { %>
        <div>
            <fieldset>
                <legend>Account Information</legend>
                      <table width="100%">
                        <tr>
                            <td width:"20%" style="width: 131px">
                                <label for="username">Username:</label>
                            </td>
                            
                            <td>
                                <%= Html.TextBox("Username") %>
                                <%= Html.ValidationMessage("Username") %>
                            </td>
                        </tr>
                       <tr>
                            <td width:"20%" style="width: 131px">
                                <label for="email">Email:</label>
                            </td>                           
                            <td>
                                <%= Html.TextBox("Email") %>
                                <%= Html.ValidationMessage("Email") %>
                            </td>
                        </tr>
                        <tr>
                            <td width:"20%" style="width: 131px">
                                <label for="password">Password:</label>
                            </td>
                            
                            <td>
                                <%= Html.Password("Password") %>
                                <%= Html.ValidationMessage("Password") %>
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
                    <input type="submit" value="Register" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
