<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginContent" ContentPlaceHolderID="UpperMainContent" runat="server">
    <div class="barCterTab">
        <div class="barCterTabLleft">
            <div class="barCterTabRight">
                <div style="line-height: 23px;" class="ctentBarTab">
                    <%=Resources.Global.Logon %>
                </div>
            </div>
        </div>
    </div>
    <div class="boxKhuyenmai">
        <%= Html.ValidationSummary("") %>
        <% using (Html.BeginForm())
           { %>
        <div>
            <fieldset>
                <legend>
                    <%=Resources.Global.AccountInfor %></legend>
                <table width="100%">
                    <tr>
                        <td style="width: 165px">
                            <label for="username">
                                <%=Resources.Global.UserName %></label>
                        </td>
                        <td>
                            <%= Html.TextBox("username") %>
                            <%= Html.ValidationMessage("username") %>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 165px">
                            <label for="password">
                                <%=Resources.Global.Password %></label>
                        </td>
                        <td>
                            <%= Html.Password("password") %>
                            <%= Html.ValidationMessage("password") %>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 165px">
                            <%= Html.CheckBox("rememberMe") %>
                            <label class="inline" for="rememberMe">
                                <%=Resources.Global.RememberPassword %>?</label>
                        </td>
                        <td>
                            <input type="submit" value="<%=Resources.Global.Logon %>" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <% } %>
        </div>
    </div>
    <%-- <p>
        Nh&#7853;p username và password &#273;&#7875; &#273;&#259;ng nh&#7853;p vào h&#7879; th&#7889;ng. <%= Html.ActionLink("DangKi", "Register") %> N&#7871;u b&#7841;n ch&#432;a có tài kh&#7887;an.
    </p> 
--%>
</asp:Content>
