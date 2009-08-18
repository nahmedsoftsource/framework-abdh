<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ABDHFramework.Models.tblUser>" %>

<asp:Content ID="registerContent" ContentPlaceHolderID="UpperMainContent" runat="server">
       <div class="barCterTab">
    	<div class="barCterTabLleft">
        	<div class="barCter
        	TabRight">
            	<div style="line-height:23px;" class="ctentBarTab">
                	<%=Resources.Global.CreateAccount %>
                </div>

            </div>
        </div>
    </div>
    
    <p>
        <%=Resources.Global.WarningPasswordLength %>
    </p>
    
    <% using (Html.BeginForm()) { %>
        <div>
            <fieldset>
                <legend><%=Resources.Global.AccountInfor %></legend>
                      <table width="100%">
                        <tr>
                            <td width:"20%" style="width: 131px">
                                <label for="username"><%=Resources.Global.UserName %>:</label>
                            </td>
                            
                            <td>
                                <%= Html.TextBox("Username") %>
                                <%= Html.ValidationMessage("Username") %>
                            </td>
                        </tr>
                        <tr>
                            <td class="l">
                                <label>
                                   <%=Resources.Global.Department %>:</label>
                            </td>
                            <td class="l">
                                <%=Html.DropDownList("Department", ((List<SelectListItem>)ViewData["Department"]).AsEnumerable())%>
                                <%= Html.ValidationMessage("Department", "*")%>
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
                                <label for="password"><%=Resources.Global.Password %>:</label>
                            </td>
                            
                            <td>
                                <%= Html.Password("Password") %>
                                <%= Html.ValidationMessage("Password") %>
                            </td>
                        </tr>
                        <tr>
                            <td width:"20%" style="width: 131px">
                                <label for="confirmPassword"><%=Resources.Global.ConfirmPassword %>:</label>
                            </td>
                            
                            <td>                                
                                <%= Html.Password("confirmPassword") %>
                                <%= Html.ValidationMessage("confirmPassword") %>
                            </td>
                        </tr>
                        <tr>
                            <td width:"20%" style="width: 131px">
                            </td>
                            
                            <td>                                
                            <input type="submit" class="abutton" value="<%=Resources.Global.Create %>" />
                            </td>
                        </tr>
                     </table>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
