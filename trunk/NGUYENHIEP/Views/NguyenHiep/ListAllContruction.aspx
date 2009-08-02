<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<NguyenHiep.Data.SearchResult<NGUYENHIEP.Models.tblNew>>" %>

<div class="barCterTab">
    <div class="barCterTabLleft">
        <div class="barCterTabRight">
            <div style="line-height: 23px;" class="ctentBarTab">
                <%=Resources.Global.ConstructionImages %>
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
                      
                    <%if (String.IsNullOrEmpty(item.TitleEN)) item.TitleEN = Resources.Global.NoTitle; %>
                    
                    <div class="subSp">
                        <div class="clear">
                            <a href="#">
                                <img src='<%= Url.Content("~"+ (!String.IsNullOrEmpty(item.Image)?item.Image:""))%>' /></a></div>
                        <div class="paddingTb4 paddingLr18px bold">
                        <%if (HttpContext.Current.Response.Cookies["Culture"] != null && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
                          { %>
                            <%=Html.ActionLink(item.TitleEN, "ViewNews", new { newsID = item.ID, TypeNews = NguyenHiep.Common.NewsTypes.Contruction }, new { @class = "color2" })%>
                            <%}else{ %>
                            <%=Html.ActionLink(item.TitleVN, "ViewNews", new { newsID = item.ID, TypeNews = NguyenHiep.Common.NewsTypes.Contruction }, new { @class = "color2" })%>
                            <%} %>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                    <%counter++; %>
                    <%if (counter == NguyenHiep.Common.Constants.NumberImagesInRow || counter >= Model.Items.Count)
                      {
                          counter = 0; %>
                    <div class="clear">
                    </div>
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
              UrlMaker = ((page) => (new UrlHelper(ViewContext.RequestContext)).Action("ListAllContruction", "NguyenHiep") + "?pageSize=" + (int)NguyenHiep.Common.Constants.DefautPagingSize + "&page=" + page+"&Type=" + NguyenHiep.Common.NewsTypes.Contruction)

            },
            new NguyenHiep.Utility.Pager.AjaxPaginationOption
            {
              HtmlID = "ListAllContructionID"
              ,
            }
          )
    %>
</div>
<%if (HttpContext.Current.Session["username"] != null)
  { %>
  <span style="float: right">
    <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "AddContruction", Resources.Global.AddConstruction, (new UrlHelper(ViewContext.RequestContext)).Action("EditNews", "NguyenHiep") + "?newsID=" + Guid.Empty.ToString()+"&Type=" + NguyenHiep.Common.NewsTypes.Contruction)%>
</span>
  <%} %>