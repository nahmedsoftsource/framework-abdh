<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblNew>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">
    <%if (Model != null)
      { %>
      <div class="barCterTab">
    <div class="barCterTabLleft">
        <div class="barCterTabRight">
            <div style="line-height: 23px;" class="ctentBarTab">
                <%=Resources.Global.News%>
            </div>
        </div>
    </div>
</div>
    <div id="mainCtentSpRight">
        <div class="boxCtentSp">
            <div class="boxCtentSpTop">
                <div class="boxCtentSpBtom">
                    <div class="boxCtentSpCtent">
                        <div class="textLeft">
                        
                            <%if (!String.IsNullOrEmpty(Model.Image))
                              { %>
                            <span style="float: left"><a href="#">
                                <img class="imgGthieu" src='<%= Url.Content("~"+Model.Image)%>' /></a> </span>
                            <%} %>
                            <div class="paddingTb4 bold">
                                <a class="color2" href="#"></a>
                                <%if (HttpContext.Current.Response.Cookies["Culture"] != null && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
                                  { %>
                                <%=((Model.ContentEN != null) ? Model.ContentEN : "")%>
                                <%}
                                  else
                                  { %>
                                <%=((Model.ContentVN != null) ? Model.ContentVN : "")%>
                                <%} %>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "EditNews", Resources.Global.Edit, (new UrlHelper(ViewContext.RequestContext)).Action("EditNews", "NguyenHiep") + "?newsID=" + Model.ID)%>
    </div>
    <%} %>
</asp:Content>
