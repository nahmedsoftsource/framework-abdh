<%@ Page Title="" Language="C#"  Inherits="System.Web.Mvc.ViewPage<NguyenHiep.Data.SearchResult<NGUYENHIEP.Models.tblNew>>" %>


    <div class="barCterTab">
    	<div class="barCterTabLleft">
        	<div class="barCterTabRight">
            	<div style="line-height:23px;" class="ctentBarTab">
                	Tin tức
                </div>

            </div>
        </div>
    </div>

    <div class="boxCtentSp">
            	<div class="boxCtentSpTop">
                	<div class="boxCtentSpBtom">
                    	<div class="boxCtentSpCtent">
                        <div class="textLeft">
    <%int counter = 0; %>
    <% foreach (var item in Model.Items) 
       { %>
    
                          <div class="boxSubTin1">
                              <%if (String.IsNullOrEmpty(item.TitleVN)) item.TitleVN = "Không tiêu đề"; %>
                	            <a href="#"><img class="imgGthieu" src='<%= Url.Content("~"+((item.Image!=null)?item.Image:""))%>' /></a>
                              <div class="paddingTb4 bold"><a class="color1" href="#">
                              <%=(item.ContentVN != null && item.ContentVN.Length > 200) ? item.ContentVN.Substring(0, 200) : item.ContentVN%>
                              <div class="textRight fontsize11">
                              <%=Html.ActionLink("Xem tiếp", "ViewNews", new { newsID = item.ID},new {@class="color2"})%>
                              </div>
							            <div class="clear"></div>
    
   
    
    <% } %>
    </div>
    </div>
    </div>
    </div>
    </div>
   
<%=
          NguyenHiep.Utility.PagerExtensions.AjaxPager
          (this.Html,
            new NguyenHiep.Utility.Pager.PagingOption
            {
              CurrentPage = Model.GetPage(),
              PageSize = Model.GetMaxResults(),
              TotalRows = Model.TotalRows,
              //UrlMaker = ((page) => (new NGUYENHIEP.Controllers.NguyenHiepController()).ListAllNews((int)NguyenHiep.Common.Constants.DefautPagingSize,(int)page)),
              UrlMaker = ((page) => (new UrlHelper(ViewContext.RequestContext)).Action("ListAllNews") + "?pageSize=" + (int)NguyenHiep.Common.Constants.DefautPagingSize+"&page="+page)

            },
            new NguyenHiep.Utility.Pager.AjaxPaginationOption
            {
                HtmlID = "ListAllNewsID"
              ,
            }
          )
       %>
 <span style="float:right">
 <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "AddNews", "Thêm tin tức", (new UrlHelper(ViewContext.RequestContext)).Action("EditNews") + "?newsID=" + null)%>
 </span>