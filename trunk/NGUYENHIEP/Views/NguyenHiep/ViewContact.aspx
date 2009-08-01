<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblInformation>" %>
<form method="post" id="twat">
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
                            <%if (HttpContext.Current.Session["username"] != null)
                              { %>
                            <span style="float: right">
                                <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "EditContact", "Sửa", (new UrlHelper(ViewContext.RequestContext)).Action("EditContact", "NguyenHiep") + "?newsID=" + ((Model != null ? Model.ID : Guid.Empty)))%>
                            </span>
                            <%} %>
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
                                <%=Html.TextBox("Sender") %>
                                <%=Html.ValidationMessage("Sender","*") %>
                            </td>
                        </tr>
                        <tr>
                            <td class="bold" valign="top">
                                <%=Resources.Global.EmailAddress %>:
                            </td>
                            <td valign="top">
                                <%=Html.TextBox("Email") %>
                                <%=Html.ValidationMessage("Email","*") %>
                            </td>
                        </tr>
                        <tr>
                            <td class="bold" valign="top">
                                <%=Resources.Global.To %>:
                            </td>
                            <td valign="top">
                                <%=Html.DropDownList("Department", ((List<SelectListItem>)ViewData["Department"]).AsEnumerable())%>
                                <%= Html.ValidationMessage("Department", "*")%>

                            </td>
                        </tr>
                        <tr>
                            <td class="bold" valign="top">
                                <%=Resources.Global.Title %>:
                            </td>
                            <td valign="top">
                                <%=Html.TextBox("Title") %>
                                <%=Html.ValidationMessage("Title", "*")%>
                            </td>
                        </tr>
                        <tr>
                            <td class="bold" valign="top">
                                <%=Resources.Global.Content %>:
                            </td>
                            <td valign="top">
                                <%=Html.TextArea("Content", new { @width="500px",@height="200px"})%>
                                <%=Html.ValidationMessage("Content", "*")%>
                                
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                &nbsp;
                            </td>
                            <td class="paddingTb4">
                            <span style="float:center">
                                <input id="send" name="Send" type="button" value="<%=Resources.Global.Send %>" />
                                </span>                               
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" colspan=2>
                                <asp:label runat="server" ID="lblMsg" style="color: #FF0000"></asp:label>   
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
<script language="javascript" >
$("#send").click(function () { 
    $(document).ready(function() 
    {
        $.ajax({
            url: '<%=Url.Content("~/NguyenHiep/Send") %>',
            global: false,
            data:{sender : document.getElementById("sender").value,
                  email : document.getElementById("email").value,
                  department : document.getElementById("department").value,
                  title : document.getElementById("title").value,
                  content : document.getElementById("content").value},
            type: "POST",
            dataType: "html",
            success: function(msg) {

            }
            })})
      
    }
    );

</script>
                    </form>
