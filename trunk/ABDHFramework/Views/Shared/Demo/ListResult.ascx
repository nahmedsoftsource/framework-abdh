<%@ Control Language="C#" Inherits="ABDHFramework.Controllers.BaseViewUserControl<ABDHFramework.Data.SearchResult<ABDHFramework.Models.tblProduct>>" %>
<%@ Import Namespace="ABDHFramework.Lib" %>
<%@ Import Namespace="ABDHFramework.Lib.Pager" %>
<%@ Import Namespace="ABDHFramework.Models" %>
<form method="post" id="ProductListResult">
<script>
 function Jump(id) {
    //<%--var urlMain = "<%= Routing.InsuranceManagement.UrlForDetails() %>" + "?InsuranceID=" + id;
    //var urlRight = "<%= Routing.InsuranceManagement.UrlForRightDetail() %>" + "?InsuranceID=" + id;
    //$("#Details").load(urlMain);
    //$("#RightDetails").load(urlRight);    
    //Core.refreshPager('#divInsuranceList');
    //InsuranceReloadRecentList();
    //return false;--%>
  }
  </script>
  <div id="ProductList" >
   
   <%= Html.SimpleGrid(Model.Items, new[]{  
  new ColumnOption<tblProduct>{
    Name = "Product Name",
    IsSort=true,
    FieldName="ProductNameVN",
    Action = (item => @"<a href=""#"" onclick=""return Jump('" + item.ID.ToString() + @"')"" title='"+ item.ProductNameVN +"'>" + (item.ProductNameVN.Length > 15 ? item.ProductNameVN.Substring(0,15) + "..." : item.ProductNameVN) + "</a>" )
  },
  //new ColumnOption<Employee>{
  //  Name = "Abbr",
  //  IsSort=true,
  //  FieldName="Organization.AbbrName",
  //  Action = (item => @"<span title='" + item.Organization.AbbrName + "'>" + item.Person.AbbrName + "</span>&nbsp;")
  //},
  new ColumnOption<tblProduct>
  {
    Name = "X",
    //Action = (item => "<span title='" + (item.Person.Inactive?"Inactive":"Active") + "'>" + (item.Person.Inactive? "X" : "&nbsp;") + "</span>") 
  }
}, new GridOption<tblProduct>
{
  DefaultSortColumn = "ProductNameVN",
  DefaultSortOption = ABDHFramework.Data.SortOption.Asc.ToString(),
  URL = Routing.Demo.UrlForListResutl(),
  HtmlID = "ProductList"
  })%>
<%= Html.AjaxPager(new PagingOption
{
        PagingStatOption = PagingOption.PagingStatOptions.AbovePager,
        CurrentPage = Model.GetPage(),
        PageSize = Model.GetMaxResults(),
        TotalRows = Model.TotalRows,
        UrlMaker = (page) => (Routing.Demo.UrlFor("ListResult", new { page = page })),
        ShowIfEmpty = true,
      }, new AjaxPaginationOption
{
  HtmlID = "ProductList",
})%>

  </div>
</form>
