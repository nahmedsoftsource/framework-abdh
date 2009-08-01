<%@ Page Title="" Language="C#"  Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblNew>" %>


<%if (Model != null)
  { %>
  <div class="barCterTab">
    <div class="barCterTabLleft">
        <div class="barCterTabRight">
            <div style="line-height: 23px;" class="ctentBarTab">
                <%=Resources.Global.AboutUs %>
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
                        	
                              <div class="paddingTb4 bold"><a class="color2" href="#"></a>
                                <%if (HttpContext.Current.Response.Cookies["Culture"] != null && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
                                  { %>
                                <%=((Model.ContentEN != null) ? Model.ContentEN : "")%>
                                <%}
                                  else
                                  { %>
                                  <%=((Model.ContentVN != null) ? Model.ContentVN : "")%>
                                <%} %>
                            </div>
                            <div class="clear"></div>
                        </div>
                    </div>
                </div>

            </div>
</div>
<span style="float:right">
<%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "EditNews", Resources.Global.Edit, (new UrlHelper(ViewContext.RequestContext)).Action("EditNews", "NguyenHiep") + "?newsID=" + Model.ID + "&Type=" + NguyenHiep.Common.NewsTypes.Introduction.ToString())%>
</span>
</div>
<%} %>


