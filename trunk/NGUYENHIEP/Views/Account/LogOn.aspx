<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="loginContent" ContentPlaceHolderID="UpperMainContent" runat="server">
        <div class="barCterTab">
    	<div class="barCterTabLleft">
        	<div class="barCterTabRight">
            	<div style="line-height:23px;" class="ctentBarTab">
                	Thông tin &#273;&#259;ng nh&#7853;p
                </div>

            </div>
        </div>
    </div>
    
    <p>
        Nh&#7853;p username và password &#273;&#7875; &#273;&#259;ng nh&#7853;p vào h&#7879; th&#7889;ng. <%= Html.ActionLink("DangKi", "Register") %> N&#7871;u b&#7841;n ch&#432;a có tài kh&#7887;an.
    </p>
    <%= Html.ValidationSummary("") %>

    <% using (Html.BeginForm()) { %>
        <div>
            <fieldset>
                <legend>Thông tin &#273;&#259;ng nh&#7853;p</legend>
                    <table width="100%">
                        <tr>
                            <td width:"20%" style="width: 131px">
                                <label for="username">Username:</label>
                            </td>
                            
                            <td>
                                <%= Html.TextBox("username") %>
                                <%= Html.ValidationMessage("username") %>
                            </td>
                        </tr>
                       <tr>
                            <td width:"20%" style="width: 131px">
                                <label for="password">Password :</label>
                            </td>                           
                            <td>
                                <%= Html.Password("password") %>
                                <%= Html.ValidationMessage("password") %>
                            </td>
                        </tr>
                        </table>
                    <%= Html.CheckBox("rememberMe") %> <label class="inline" for="rememberMe">Nh&#7899; tôi?</label>
                    <input type="submit" value="Log On" />
            </fieldset>
        </div>
    <% } %>
</asp:Content>
