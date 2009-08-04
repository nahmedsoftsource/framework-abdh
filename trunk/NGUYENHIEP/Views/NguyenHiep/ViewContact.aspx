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
                            <%= ((Model != null && !String.IsNullOrEmpty(Model.ContactEN)) ? Model.ContactEN : "Information is not available")%>
                            <%}
                              else
                              { %>
                              <%= ((Model != null && !String.IsNullOrEmpty(Model.ContactVN)) ? Model.ContactVN : "Thông tin chưa cập nhật")%>
                            <%} %>
                        </div>
                        <div style="padding: 0 0 30px 0; line-height: 18px; margin-bottom: 20px; border-bottom: 1px solid #CCC"
                            class="clear">
                            <%if (HttpContext.Current.Session["username"] != null)
                              { %>
                            <span style="float: right">
                                <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "EditContact", Resources.Global.Edit, (new UrlHelper(ViewContext.RequestContext)).Action("EditContact", "NguyenHiep") + "?newsID=" + ((Model != null ? Model.ID : Guid.Empty)))%>
                                
                            </span>
                            <%} %>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <%NGUYENHIEP.Models.tblEmail email = new NGUYENHIEP.Models.tblEmail(); %>
                    <%if (ViewData["EmailReload"] != null) email = (NGUYENHIEP.Models.tblEmail)ViewData["EmailReload"];%>
                    <table style="line-height: 25px;" cellpadding="0" cellspacing="0" width="100%">
                    <%if (ViewData["Message"] != null)
                                  {
                          %>
                          <tr>
                              <td colspan="2" class="input-validation-error">
                                        <%
                                          Response.Write(ViewData["Message"].ToString()); 
                                          %>
                            </td>
                        </tr>  
                                      <%}%>
                        <tr>
                            <td width="20%" valign="top" class="bold">
                                
                                <%=Resources.Global.YourName %>:
                            </td>
                            <td width="64%" valign="top">
                                <%=Html.TextBox("Sender", (!String.IsNullOrEmpty(email.Sender)) ? email.Sender : "", new  {style="width:100%" })%>
                                <%if (ViewData["Sender"] != null)
                                  {%>
                                <span class="input-validation-error"><%=ViewData["Sender"]%></span>
                                <%} %>
                            </td>
                        </tr>
                        <tr>
                            <td class="bold" valign="top">
                                <%=Resources.Global.EmailAddress %>:
                            </td>
                            <td valign="top">
                                <%=Html.TextBox("Email", (!String.IsNullOrEmpty(email.Email)) ? email.Email : "", new { style = "width:100%" })%>
                                <%if(ViewData["EmailInvalid"] != null ){%>
                                <span class="input-validation-error"><%=ViewData["EmailInvalid"]%></span>
                                <%} %>
                            </td>
                        </tr>
                        <tr>
                            <td class="bold" valign="top">
                                <%=Resources.Global.To %>:
                            </td>
                            <td valign="top">
                                <%=Html.DropDownList("Department", ((List<SelectListItem>)ViewData["Department"]).AsEnumerable(), new { style = "width:100%" })%>
                                <%= Html.ValidationMessage("Department", "*")%>

                            </td>
                        </tr>
                        <tr>
                            <td class="bold" valign="top">
                                <%=Resources.Global.Title %>:
                            </td>
                            <td valign="top">
                                <%=Html.TextBox("Title", (!String.IsNullOrEmpty(email.Title)) ? email.Title : "", new { style = "width:100%" })%>
                                
                                <%if (ViewData["Title"] != null)
                                  {%>
                                <span class="input-validation-error"><%=ViewData["Title"]%></span>
                                <%} %>
                            </td>
                        </tr>
                        <tr>
                            <td class="bold" valign="top">
                                <%=Resources.Global.Content %>:
                            </td>
                            <td valign="top">
                                <%=Html.TextArea("Content", (!String.IsNullOrEmpty(email.Content)) ? email.Content : "", new {rows = "10", style = "width:100%" })%>
                                 <%if (ViewData["Content"] != null)
                                  {%>
                                <span class="input-validation-error"><%=ViewData["Content"]%></span>
                                <%} %>
                                
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                &nbsp;
                            </td>
                            <td class="paddingTb4">
                            <span style="text-align:center">
                                <input id="Send" class="abutton" name="Send" type="button" value="<%=Resources.Global.Send %>" />
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
<%NguyenHiep.Utility.UIHelper.JavascriptFile(Url.Content("~/Scripts/jquery-1.3.2.js")); %>
<%NguyenHiep.Utility.UIHelper.JavascriptFile(Url.Content("~/Scripts/Core.js")); %>
<%--<script type="text/javascript" src='<%= Url.Content("~/Scripts/Core.js")%>'></script>

    <script type="text/javascript" src='<%= Url.Content("~/Scripts/jquery-1.3.2.js")%>'></script>--%>
 <script language="javascript" type="text/javascript">
   $(document).ready(function() {
     //$("#Send").click(function() {
     $("#Send").bind('click', function() {
       $.ajax({
         url: '<%=Url.Content("~/NguyenHiep/Send") %>',
         global: true,
         data: { sender: document.getElementById("Sender").value,
           email: document.getElementById("Email").value,
           department: document.getElementById("Department").value,
           title: document.getElementById("Title").value,
           departmentname: document.getElementById("Department").options[document.getElementById("Department").selectedIndex].text,
           content: document.getElementById("Content").value
         },
         type: "POST",
         dataType: "html",
         success: function(msg) {

         document.getElementById("ContactID").innerHTML = msg;
         bindNewEvent();
           

         }
       })
     })

   }
    );
   function bindNewEvent() {
     $(document).ready(function() {
       //$("#Send").click(function() {
     $("#Send").bind('click', function() {
         

         $.ajax({
           url: '<%=Url.Content("~/NguyenHiep/Send") %>',
           global: true,
           data: { sender: document.getElementById("Sender").value,
             email: document.getElementById("Email").value,
             department: document.getElementById("Department").value,
             title: document.getElementById("Title").value,
             departmentname: document.getElementById("Department").options[document.getElementById("Department").selectedIndex].text,
             content: document.getElementById("Content").value
           },
           type: "POST",
           dataType: "html",
           success: function(msg) {

           document.getElementById("ContactID").innerHTML = msg;
           bindNewEvent();
             

           }
         })
       })

     }
    );
   }
</script>
</form>
