<%@ Page Title="" Language="C#"  Inherits="System.Web.Mvc.ViewPage<NguyenHiep.Data.SearchResult<NGUYENHIEP.Models.tblNew>>" %>


    <div class="barCterTab">
    	<div class="barCterTabLleft">
        	<div class="barCterTabRight">
            	<div style="line-height:23px;" class="ctentBarTab">
                	Ảnh công trình
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
    <% foreach (var item in Model.Items) { %>
        <%if (String.IsNullOrEmpty(item.TitleVN)) item.TitleVN = "Không tiêu đề"; %>
            <div class="subSp">

            	<div class="clear"><a href="#"><img src='<%= Url.Content("~"+ (!String.IsNullOrEmpty(item.Image)?item.Image:""))%>' /></a></div>
                <div class="paddingTb4 paddingLr18px bold">
                	<%=Html.ActionLink(item.TitleVN, "ViewNews", new { newsID = item.ID, type = NguyenHiep.Common.NewsTypes.Contruction }, new { @class = "color2" })%>
                </div>
                <div class="clear"></div>
            </div>
        <%counter++; %>
        <%if (counter == NguyenHiep.Common.Constants.NumberImagesInRow || counter >= Model.Items.Count)
          {
              counter = 0; %>
        <div class="clear"></div>
        <%} %>
        
    
    <% } %>
    </div>
    </div>
    </div>
    </div>
    </div>
   <div class="prevNext">
<%=
          NguyenHiep.Utility.PagerExtensions.AjaxPager
          (this.Html,
            new NguyenHiep.Utility.Pager.PagingOption
            {
              CurrentPage = Model.GetPage(),
              PageSize = Model.GetMaxResults(),
              TotalRows = Model.TotalRows,
              //UrlMaker = ((page) => (new NGUYENHIEP.Controllers.NguyenHiepController()).ListAllNews((int)NguyenHiep.Common.Constants.DefautPagingSize,(int)page)),
              UrlMaker = ((page) => (new UrlHelper(ViewContext.RequestContext)).Action("ListAllContruction", "NguyenHiep") + "?pageSize=" + (int)NguyenHiep.Common.Constants.DefautPagingSize+"&page="+page)

            },
            new NguyenHiep.Utility.Pager.AjaxPaginationOption
            {
              HtmlID = "ListAllContructionID"
              ,
            }
          )
       %>
 </div>
 <span style="float:right">
 <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "AddContruction", "Thêm công trình", (new UrlHelper(ViewContext.RequestContext)).Action("EditNews", "NguyenHiep") + "?newsID=" + null)%>
 </span>