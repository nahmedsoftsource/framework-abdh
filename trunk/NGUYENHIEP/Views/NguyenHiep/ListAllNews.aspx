<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<NguyenHiep.Data.SearchResult<NGUYENHIEP.Models.tblNew>>" %>

<div class="barCterTab">
    <div class="barCterTabLleft">
        <div class="barCterTabRight">
            <div style="line-height: 23px;" class="ctentBarTab">
                <%=Resources.Global.News %>
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
                        <%if (String.IsNullOrEmpty(item.TitleVN)) item.TitleVN = Resources.Global.NoTitle; %>
                        <%if (!String.IsNullOrEmpty(item.Image))
                          { %>
                        <a href="#">
                            <img class="imgGthieu" src='<%= Url.Content("~"+((item.Image!=null)?item.Image:""))%>' /></a>
                        <%} %>
                        <div class="paddingTb4 bold">
                            <a class="color1" href="#">
                                <%=(item.SubjectVN!=null)?item.SubjectVN:Resources.Global.NoSubject%>
                            </a>
                        </div>
                        <div class="textRight fontsize11">
                            <%=Html.ActionLink(Resources.Global.Next, "ViewNews", new { newsID = item.ID,type = NguyenHiep.Common.NewsTypes.News},new {@class="color2"})%>
                        </div>
                        <div class="clear">
                        </div>
                        <% } %>
                    </div>
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
              UrlMaker = ((page) => (new UrlHelper(ViewContext.RequestContext)).Action("ListAllNews") + "?pageSize=" + (int)NguyenHiep.Common.Constants.DefautPagingSize+"&page="+page)

            },
            new NguyenHiep.Utility.Pager.AjaxPaginationOption
            {
                HtmlID = "ListAllNewsID"
              ,
            }
          )
    %>
</div>
<span style="float: right">
    <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "AddNews", Resources.Global.AddNews, (new UrlHelper(ViewContext.RequestContext)).Action("EditNews") + "?newsID=" + null)%>
</span>