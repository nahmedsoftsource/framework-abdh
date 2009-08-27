<%@ Page  Language="C#"  Inherits="ABDHFramework.Controllers.BaseViewPage" %>
<%@ Import Namespace="ABDHFramework.Utility" %>
<%@ Import Namespace="ABDHFramework.Lib" %>
<%@ Import Namespace="ABDHFramework.Lib.FluentHtml" %>
<%@ Import Namespace="ABDHFramework.Lib.Javascripts" %>

<script type="text/javascript">
  function Jump(id) {
    var url = "<%= Routing.Product.UrlForViewProduct()%>" + "?ProductID=" + id;
    $("#ListAllID").load(url);
    return false;
  }
  function CheckWhiteFields() {

    return true;
  }

  function reloadAfterSelect(data) {

 } 

</script>
<form method="post" id="SearchForm">
  <table class="table-form maxwidth" border="0" cellpadding="0" cellspacing="0" >
	  <tr class="field">
		  <td><span class="field-label" style="width:70px;">Name</span></td>
	    <td><span class="field-input"><%=FluentHtml.TextBox("ProductNameVN").Id("QuickSearch_ID").Style("width:100%")%></span></td>
    </tr>
    <%= Html.AutoCompleteFor("QuickSearch_ID", new AutoCompleteOption
          {
            URL = Routing.Product.UrlForSuggestForField("ProductNameVN"),
            Result = "Jump(info.data.ProductID)",
          })%>
  </table>
 
<div class="buttonpane">
	 	<%= Html.ButtonToRemote("Show All", "form-button ui-corner-all", new RemoteOption
    {
      URL = Routing.Product.UrlForListProduct(null, null, null, "", ""),
      Update = "ListAllID",
      Data = new { HtmlID = "ListAllID", Command = "SearchAll" },
      IsForm = true,
      CausesValidation = false
      
    })%>


	 	<%= Html.ButtonToRemote("Search", "form-button ui-corner-all", new RemoteOption
    {
      
      URL = Routing.Product.UrlForListProduct(null,null,null,"",""),
      Update = "ListAllID",
      Data = new { HtmlID = "ListAllID", Command = "Search" },
      IsForm = true,
      CausesValidation = false
    })%>


</div>
</form>




