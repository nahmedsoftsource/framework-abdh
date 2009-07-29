<%@ Page Title="" Language="C#"  Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblNew>" %>


<%if (Model != null)
  { %>
<div id="mainCtentSpRight">
<div class="barCterTab">
            	<div class="barCterTabLleft">
                	<div class="barCterTabRight">
                    	<div style="line-height:23px;" class="ctentBarTab">
                        	Tuyển dụng
                        </div>

                    </div>
                </div>
            </div>

<div class="boxCtentSp">
            	<div class="boxCtentSpTop">
                	<div class="boxCtentSpBtom">
                    	<div class="boxCtentSpCtent">
                        	<div class="textLeft">
                              <div class="paddingTb4 bold"><a class="color2" href="#"></a>
                                
                                <%=((Model.ContentVN != null) ? Model.ContentVN : "")%>
                            </div>
                            <div class="clear"></div>
                        </div>
                    </div>
                </div>

            </div>
</div>
<%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "EditNews", "Sửa", (new UrlHelper(ViewContext.RequestContext)).Action("EditNews", "NguyenHiep") + "?newsID=" + Model.ID+"&Type="+NguyenHiep.Common.NewsTypes.Recruitment.ToString())%>
<input type="hidden" id="SelectedMenuId" name="SelectedMenuId" value="6" />
</div>
<%} %>

