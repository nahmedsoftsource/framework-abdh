<%@ Page Title="Manage Product"  Language="C#" Inherits="ABDHFramework.Controllers.BaseViewPage<ABDHFramework.Data.SearchResult<ABDHFramework.Models.tblProduct>>" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="ABDHFramework.Lib" %>
<%@ Import Namespace="ABDHFramework.Lib.Pager" %>
<%@ Import Namespace="ABDHFramework.Models" %>
<form>
<div>
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
   function Confirm() {
     return confirm('Do you realy want to delete this item?');
   }
  </script>
 
<div >
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

  <%
    int? Page = (ViewData["Page"]!= null)?ViewData["Page"] as int?:1;
   %>
   <%=Html.Hidden("listIDToDelete") %>
   <%= Html.SimpleGrid(Model.Items, new[]{ 
    new ColumnOption<tblProduct>{
      Name = "All",
      
        Action=(item =>@"<input  id=""" +item.ID.ToString()+ @""" type=""checkbox""/>")
    }, 
  new ColumnOption<tblProduct>{
    Name = "Product Name",
    IsSort=true,
    FieldName="ProductNameVN",
    Action = (item => @"<a href=""#"" onclick=""return Jump('" + item.ID.ToString() + @"')"" title='"+ item.ProductNameVN +"'>" + (item.ProductNameVN.Length > 15 ? item.ProductNameVN.Substring(0,15) + "..." : item.ProductNameVN) + "</a>" )
  },
 new ColumnOption<tblProduct>{
    Name = "Description",
    FieldName="Description",
    Action = (item => @"<a href=""#"" onclick=""return Jump('" + item.ID.ToString() + @"')"" title='"+ item.Description +"'>" + (item.Description.Length > 50 ? item.Description.Substring(0,50) + "..." : item.Description) + "</a>" )
  },
  new ColumnOption<tblProduct>
  {
    Name = "Edit",
    
    Action = (item=>ABDHFramework.Lib.Javascripts.Javascript.EditToRemoteForList("",new RemoteOption
      {
        URL = Routing.Product.UrlForEditProduct(item.ID,null),
        Update = "ListID",
        Method = "GET"
      })
      
    )
  },
  new ColumnOption<tblProduct>
  {
    Name = "Delete",
    
    Action = (item=>Html.LinkDeleteForList(new RemoteOption
    {
      CallBefore = "Confirm()",
      URL = Routing.Product.UrlForDeleteProduct(item.ID),
      
      Update = "ListID",
      
    })
    )
  }
}, new GridOption<tblProduct>
{
  DefaultSortColumn = "CategoryNameVN",
  DefaultSortOption = ABDHFramework.Data.SortOption.Asc.ToString(),
  URL = Routing.Product.UrlForAdminListProduct(1),
  HtmlID = "ListID"
  })%>
<%= Html.AjaxPager(new PagingOption
{
        PagingStatOption = PagingOption.PagingStatOptions.AbovePager,
        CurrentPage = Model.GetPage(),
        PageSize = Model.GetMaxResults(),
        TotalRows = Model.TotalRows,
        UrlMaker = (page) => (Routing.Product.UrlForAdminListProduct(page)),
        ShowIfEmpty = true,
      }, new AjaxPaginationOption
{
  HtmlID = "ListID",
})%>
 <div >
 <span style="float:left">
  <%=Html.ButtonToRemote("Delete", new RemoteOption
        {
            CallBefore = "confirmDelete()",
            URL = Routing.Product.UrlForDeleteListProduct(),
            IsForm=true,
            CausesValidation = false,
            Update = "ListID",
            
            
        }
        )%>
 </span>
 <span style="float:right">
 <%=Html.ButtonToRemote(Resources.Global.AddProduct,new RemoteOption
   {
     Method = "GET",
     URL = Routing.Product.UrlForEditProduct(null,null),
     Update = "ListID",
   }) %>
 </span>
</div>
</div>
</form>
