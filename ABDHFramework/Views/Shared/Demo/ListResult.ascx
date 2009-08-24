<%@ Control Language="C#" Inherits="ABDHFramework.Controllers.BaseViewUserControl<ABDHFramework.Data.SearchResult<ABDHFramework.Models.tblNew>>" %>
<%@ Import Namespace="ABDHFramework.Lib" %>
<%@ Import Namespace="ABDHFramework.Lib.Pager" %>
<%@ Import Namespace="ABDHFramework.Models" %>
<form method="post" >
<div id="ListResult">
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
 function confirmDelete() {
     var checkboxs = document.getElementsByTagName('input');
     var count = 0;
     var listID = "";
     for (i = 0; i < checkboxs.length; i++) {
         if (checkboxs[i].checked == true) {
             //alert(checkboxs[i].id);
             
                 count = count + 1;
                 listID = listID + checkboxs[i].id;
                 listID = listID + "|";
             }
             }
             document.getElementById('<%=Html.IdFor("listIDToDelete")%>').value = listID;
         
         if (count > 0)
             return confirm('Do you realy want to delete this item?')
     
     return confirm('You must select at least one item?');
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
   <%=Html.Hidden("listIDToDelete") %>
   <%= Html.SimpleGrid(Model.Items, new[]{ 
    new ColumnOption<tblNew>{
        Action=(item =>@"<input  id=""" +item.ID.ToString()+ @""" type=""checkbox""/>")
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
  HtmlID = "ListResult"
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
  HtmlID = "ListResult",
})%>

  </div>
  <div>
  
    
    <%=Html.ButtonToRemote("Delete", new RemoteOption
        {
            CallBefore = "confirmDelete()",
            URL = Routing.Demo.UrlForDelete(),
            IsForm=true,
            CausesValidation = false,
            Update = "ListResult",
            
            
        }
        )%>
  </div>
  </div>
</form>
