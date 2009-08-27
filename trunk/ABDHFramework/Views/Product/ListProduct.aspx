<%@ Page Title="" Language="C#" Inherits="ABDHFramework.Controllers.BaseViewPage<ABDHFramework.Data.SearchResult<ABDHFramework.Models.tblProduct>>" %>
<%@ Import Namespace="ABDHFramework.Lib" %>
<%@ Import Namespace="ABDHFramework.Lib.Pager" %>
<%@ Import Namespace="ABDHFramework.Models" %>
<div class="barCterTab">
    <div class="barCterTabLleft">
        <div class="barCterTabRight">
            <div style="line-height: 23px;" class="ctentBarTab">
                <%=Resources.Global.Products %>
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
                    <%int counter2=0; %>
                    <% foreach (var item in Model.Items)
                       { %>
                        <%if (String.IsNullOrEmpty(item.ProductName)) item.ProductName = Resources.Global.NoTitle; %>
                        <div class="subSp">
                                <div class="clear">
                                    <a href="#">
                                        <img src='<%= Url.Content("~"+item.Image)%>' /></a>
                                </div>
                                <div class="paddingTb4 paddingLr18px bold">
                                   
                                     <%=Html.LinkToRemote(item.ProductName,new RemoteOption
                                       {
                                         Update = "ListAllID",
                                         URL = Routing.Product.UrlForViewProduct(item.ID,null)
                                         })%>
                                </div>
                                <div class="clear">
                                </div>
                        </div>
                        <%counter++; %>
                        <%counter2++; %>
                        <%if (counter == ABDHFramework.Common.Constants.NumberImagesInRow || counter2 >= Model.Items.Count)
                          {
                            counter = 0; %>
                            <div class="clear"></div>
                        <%}%>
                    <% } %>
                </div>
               
            </div>
        </div>
    </div>
</div>

 <div class="prevNext">
 <%if (HttpContext.Current.Response.Cookies["Culture"] != null && !String.IsNullOrEmpty(HttpContext.Current.Response.Cookies["Culture"].Value) &&  HttpContext.Current.Response.Cookies["Culture"].Value.Equals("en-US"))
   { %>
    <%=
          PagerExtensions.AjaxPager
          (this.Html,
            new PagingOption
            {
                CurrentPage = Model.GetPage(),
                PageSize = Model.GetMaxResults(),
                TotalRows = Model.TotalRows,

                UrlMaker=(page)=>Routing.Product.UrlForListProduct(null,null,page,"","")
            },
            new AjaxPaginationOption
            {
                HtmlID = "ListAllID"
              ,
            }
          )
    %>
    <%}
   else
   { %>
   <%=
          PagerExtensions.AjaxPager
          (this.Html,
            new PagingOption
            {
                CurrentPage = Model.GetPage(),
                PageSize = Model.GetMaxResults(),
                TotalRows = Model.TotalRows,
                //UrlMaker = ((page) => (new ABDHFramework.Controllers.ABDHFrameworkController()).ListAllNews((int)ABDHFramework.Common.Constants.DefautPagingSize,(int)page)),
                UrlMaker = (page) => Routing.Product.UrlForListProduct(null,null, page, "", "")

            },
            new AjaxPaginationOption
            {
                HtmlID = "ListAllID"
              ,
            }
                 ).Replace("First", "Trang đầu").Replace("Last", "Trang cuối").Replace("Previous", "Trang trước").Replace("Next", "Trang sau")
    %>
    <%} %>
</div>
