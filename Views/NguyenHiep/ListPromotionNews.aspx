<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<NguyenHiep.Data.SearchResult<NGUYENHIEP.Models.tblNew>>" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="NguyenHiep.Utility" %>
    <div class="boxNews" style="float:none;">
            	<div class="boxNewsTop">
                	<div class="boxNewsBtom">
                    	<div class="boxNewsCtent">
                        <div class="boxTabNews">
                        	<div class="boxTabNewsLeft">
                            	<div class="boxTabNewsRight">

                                	<div class="ctentBarTab">
                                    	<%=Resources.Global.PromotionProgram %>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="boxKhuyenmai" >
                    <ul>
                        <% foreach (NGUYENHIEP.Models.tblNew item in Model.Items)
                           {%>
                        <li>
                        <%if (HttpContext.Current.Response.Cookies["Culture"] != null && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
                          { %>
                            <%=Html.ActionLink((item!=null && item.TitleEN != null) ? item.TitleEN : "No Name", "ViewNews", new { newsID = item.ID }, new { @class = "color2" })%>
                            <%}
                          else
                          { %>
                          <%=Html.ActionLink((item != null && item.TitleVN != null) ? item.TitleVN : "Không có tên", "ViewNews", new { newsID = item.ID }, new { @class = "color2" })%>
                            <%} %>
                        </li>
                        <%} %>
                    </ul>
                </div>
                        </div>
                    </div>

                </div>
    </div>

                
                            
    

 <div class="prevNext">
 <%if (HttpContext.Current.Response.Cookies["Culture"] != null && HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
   { %>
    <%=
          NguyenHiep.Utility.PagerExtensions.AjaxPager
          (this.Html,
            new NguyenHiep.Utility.Pager.PagingOption
            {
                CurrentPage = Model.GetPage(),
                PageSize = Model.GetMaxResults(),
                TotalRows = Model.TotalRows,
                UrlMaker = ((page) => (new UrlHelper(ViewContext.RequestContext)).Action("ListPromotionNews", "NguyenHiep") + "?pageSize=" + (int)NguyenHiep.Common.Constants.DefautPagingSize + "&page=" + page + ((ViewData["Type"] != null) ? ("&Type=" + ViewData["Type"]) : ""))

            },
            new NguyenHiep.Utility.Pager.AjaxPaginationOption
            {
                HtmlID = "ListNewsPromotionID"
              ,
            }
          )
       %>
       <%}
   else
   { %>
   <%=
          NguyenHiep.Utility.PagerExtensions.AjaxPager
          (this.Html,
            new NguyenHiep.Utility.Pager.PagingOption
            {
                CurrentPage = Model.GetPage(),
                PageSize = Model.GetMaxResults(),
                TotalRows = Model.TotalRows,
                UrlMaker = ((page) => (new UrlHelper(ViewContext.RequestContext)).Action("ListPromotionNews", "NguyenHiep") + "?pageSize=" + (int)NguyenHiep.Common.Constants.DefautPagingSize + "&page=" + page + ((ViewData["Type"] != null) ? ("&Type=" + ViewData["Type"]) : ""))

            },
            new NguyenHiep.Utility.Pager.AjaxPaginationOption
            {
                HtmlID = "ListNewsPromotionID"
              ,
            }
                 ).Replace("First", "Trang đầu").Replace("Last", "Trang cuối").Replace("Previous", "Trang trước").Replace("Next", "Trang sau")
       %>
       <%} %>
       <br />
 <%if (HttpContext.Current.Session["username"] != null)
  { %>
      <span style="float:right">
 <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "AddNews", Resources.Global.AddPromotion, (new UrlHelper(ViewContext.RequestContext)).Action("EditNews", "NguyenHiep") + "?newsID=" + Guid.Empty.ToString() + ((ViewData["Type"] != null) ? ("&Type=" + ViewData["Type"]) : ""))%>
 </span>
  <%} %>       
 <br />
  </div>
                

    
