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
    //InsuranceReloadRecentList();dsdsds
    //return false;--%>
 }

 function checkAll() {

     var checkboxs = document.getElementsByTagName('input');
//     for (var i = 0, inp; inp = checkboxs[i]; i++) if (inp.type.toLowerCase() == 'checkbox' && inp.name.indexOf(cname) == 0) inp.checked = (this.className.search('uncheckall') == -1);
     for (i = 0; i < checkboxs.length; i++)
         checkboxs[i].checked = true;
 }

 function uncheckAll() {
     var checkboxs = document.getElementsByTagName('input');
     for (i = 0; i < checkboxs.length; i++)
         checkboxs[i].checked = false;
 }

  </script>
  <div>
  Select: 
  <span>
  <%=Html.LinkToRemote("All",new RemoteOption
    {
        CallBefore = "checkAll()"
    })%>
  </span>, 
  <span >
     <%=Html.LinkToRemote("None",new RemoteOption
    {
        CallBefore = "uncheckAll()"
    })%>
  </span>
  </div>
  <div id="List" >
   
   <%= Html.SimpleGrid(Model.Items, new[]{ 
    new ColumnOption<tblNew>{
        Action=(item =>@"<input id=""chkbx_0"" type=""checkbox""/>")
    }, 
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
  <div>
    
  </div>
</form>
