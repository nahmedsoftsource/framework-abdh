<%@ Control Language="C#" Inherits="ABDHFramework.Controllers.BaseViewUserControl<ABDHFramework.Data.SearchResult<ABDHFramework.Models.tblNew>>" %>
<%@ Import Namespace="ABDHFramework.Lib" %>
<%@ Import Namespace="ABDHFramework.Lib.Pager" %>
<%@ Import Namespace="ABDHFramework.Models" %>
<form method="post" id="ListResult">
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
  <div id="List" >
   
   <%= Html.SimpleGrid(Model.Items, new[]{  
  new ColumnOption<tblNew>{
    Name = "New Name",
    IsSort=true,
    FieldName="TitleEN",
    Action = (item => @"<a href=""#"" onclick=""return Jump('" + item.ID.ToString() + @"')"" title='"+ item.TitleEN +"'>" + (item.TitleEN.Length > 15 ? item.TitleEN.Substring(0,15) + "..." : item.TitleEN) + "</a>" )
  },
 
  new ColumnOption<tblNew>
  {
    Name = "X",
   
  }
}, new GridOption<tblNew>
{
  DefaultSortColumn = "TitleEN",
  DefaultSortOption = ABDHFramework.Data.SortOption.Asc.ToString(),
  URL = Routing.Demo.UrlForListResutl(),
  HtmlID = "List"
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
  HtmlID = "List",
})%>

  </div>
</form>
