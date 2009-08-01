<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblInformation>" %>

<div id="mainCtentSpRight">
    <div class="barCterTab">
        <div class="barCterTabLleft">
            <div class="barCterTabRight">
                <div style="line-height: 23px;" class="ctentBarTab">
                    <%=Resources.Global.ContactUs %>
                </div>
            </div>
        </div>
    </div>
    <div class="boxCtentSp">
        <div class="boxCtentSpTop">
            <div class="boxCtentSpBtom">
                <div class="boxCtentSpCtent">
                    <div style="padding: 10px 0 30px 0;">
                        <div style="padding: 0 0 30px 0; line-height: 18px; margin-bottom: 20px; border-bottom: 1px solid #CCC"
                            class="clear">
                            <%if (HttpContext.Current.Response.Cookies["Culture"] != null && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
                              { %>
                            <%= ((Model != null && !String.IsNullOrEmpty(Model.ContactEN)) ? Model.ContactEN : "Thông tin chưa cập nhật")%>
                            <%}
                              else
                              { %>
                              <%= ((Model != null && !String.IsNullOrEmpty(Model.ContactVN)) ? Model.ContactVN : "Information is not available")%>
                            <%} %>
                        </div>
                        <div style="padding: 0 0 30px 0; line-height: 18px; margin-bottom: 20px; border-bottom: 1px solid #CCC"
                            class="clear">
                            <span style="float: right">
                                <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "EditContact", "Sửa", (new UrlHelper(ViewContext.RequestContext)).Action("EditContact", "NguyenHiep") + "?newsID=" + ((Model != null?Model.ID:Guid.Empty)))%>
                            </span>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <table style="line-height: 25px;" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td width="36%" valign="top" class="bold">
                                <%=Resources.Global.YourName %>:
                            </td>
                            <td width="64%" valign="top">
                                <input name="name" size="30" class="inputbox" value="" type="text">
                            </td>
                        </tr>
                        <tr>
                            <td class="bold" valign="top">
                                <%=Resources.Global.EmailAddress %>:
                            </td>
                            <td valign="top">
                                <input name="name" size="30" class="inputbox" value="" type="text">
                            </td>
                        </tr>
                        <tr>
                            <td class="bold" valign="top">
                                <%=Resources.Global.To %>:
                            </td>
                            <td valign="top">
                                <select name="con_id" class="inputbox">
                                    <option value="duchungpham12d2@gmail.com"><%=Resources.Global.ManagementBoard %></option>
                                    <option value="duchungpham12d2@gmail.com"><%=Resources.Global.TechnicalDept %></option>
                                    <option value="duchungpham12d2@gmail.com"><%=Resources.Global.MarketingDept%></option>
                                    <option value="duchungpham12d2@gmail.com"><%=Resources.Global.SaleDept %></option>
                                    <option value="duchungpham12d2@gmail.com"><%=Resources.Global.AccountingDept %></option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="bold" valign="top">
                                <%=Resources.Global.Title %>:
                            </td>
                            <td valign="top">
                                <input name="name" size="30" class="inputbox" value="" type="text">
                            </td>
                        </tr>
                        <tr>
                            <td class="bold" valign="top">
                                <%=Resources.Global.Content %>:
                            </td>
                            <td valign="top">
                                <textarea cols="35" rows="10" name="text" id="contact_text" class="inputbox"></textarea>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                &nbsp;
                            </td>
                            <td class="paddingTb4">
                                <input type="button" value="<%=Resources.Global.Send %>" />
                                <input type="reset" value="<%=Resources.Global.Send %>" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
