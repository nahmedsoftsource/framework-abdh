<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<NguyenHiep.Data.SearchResult<NGUYENHIEP.Models.tblNew>>" %>
<%@ Import Namespace="NguyenHiep.Utility" %>
<div class="boxNews">
    <div class="boxNewsTop">
        <div class="boxNewsBtom">
            <div class="boxNewsCtent">
                 <div class="boxTabNews">
                    <div class="boxTabNewsLeft">
                        <div class="boxTabNewsRight">
                            <div class="ctentBarTab">
                                <%=Resources.Global.NewsEvent %>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clear" >
                <%if (Model != null && Model.Items != null)
                  { %>
                    <%int counter = 0; %>
                    <% foreach (NGUYENHIEP.Models.tblNew item in Model.Items)
                       {
                           counter++;
                           if (counter % 2 != 0)
                               Response.Write("<div class='boxSubTin1'>");%>
                                
                           <%else
                        Response.Write("<div class='boxSubTin1' style='background: transparent none repeat scroll 0% 0%; -moz-background-clip: border; -moz-background-origin: padding; -moz-background-inline-policy: continuous;'>");%>
                                
                        
                        
                        <%if (!String.IsNullOrEmpty(item.Image))
                          { %>
                            <a href="#">
                                <img class="imgSubNews"  src='<%= Url.Content("~"+((item.Image!=null)?item.Image:""))%>' />
                                </a>
                        
                        <%} %>
                        
                        <%if (HttpContext.Current.Response.Cookies["Culture"] != null && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
                          { %>
                            <%if (String.IsNullOrEmpty(item.TitleEN)) item.TitleEN = Resources.Global.NoTitle;  %>
                            <%=Html.ActionLink(item.TitleEN, "ViewNews", new { newsID = item.ID, type = NguyenHiep.Common.NewsTypes.HotNew }, new { @class = "color1" })%>
                        <%}
                          else
                          { %>
                        <%if (String.IsNullOrEmpty(item.TitleVN)) item.TitleVN = Resources.Global.NoTitle; %>
                        <%=Html.ActionLink(item.TitleVN, "ViewNews", new { newsID = item.ID, type = NguyenHiep.Common.NewsTypes.HotNew }, new { @class = "color1" })%>
                                <%} %>
                        
                        </div>
                        <%} %>
                     <%} %>
                    
                </div>
            </div>
        </div>
    </div>
</div>
<%if(Model != null && Model.Items != null){ %>
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
                  UrlMaker = ((page) => (new UrlHelper(ViewContext.RequestContext)).Action("ListHotNews") + "?pageSize=" + (int)NguyenHiep.Common.Constants.DefautPagingSize + "&page=" + page + "&Type=" + NguyenHiep.Common.NewsTypes.HotNew.ToString())

                },
                new NguyenHiep.Utility.Pager.AjaxPaginationOption
                {
                    HtmlID = "ListHotNewsID"
                  ,
                }
            )
    %>
</div>
<%} %>
<%if (HttpContext.Current.Session["username"] != null)
  { %>
    <span style="float: right">
    <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "AddHotNews", Resources.Global.AddNews, (new UrlHelper(ViewContext.RequestContext)).Action("EditNews") + "?newsID=" + Guid.Empty.ToString() + "&Type="+NguyenHiep.Common.NewsTypes.HotNew.ToString())%>
</span>
  <%} %>
  
