<%@ Control Language="C#" Inherits="ABDHFramework.Controllers.BaseViewUserControl" %>
<%@ Import Namespace="ABDHFramework.Utility" %>
<%@ Import Namespace="ABDHFramework.Lib" %>
<%@ Import Namespace="ABDHFramework.Lib.FluentHtml" %>


<script type="text/javascript">
  function CheckWhiteFields() {

    return true;
  }

  function reloadAfterSelect(data) {

 } 

</script>

<form method="post" id="AgentSearchForm">
  <table class="table-form maxwidth" border="0" cellpadding="0" cellspacing="0" >
	  <tr class="field">
		  <td><span class="field-label" style="width:70px;">Name</span></td>
	    <td><span class="field-input"><%=FluentHtml.TextBox("FullName").Id("Agent_QuickSearch_Name").Style("width:200px")%></span></td>
    </tr>
    
  </table>
 
<div class="buttonpane">
	 	<%= Html.ButtonToRemote("Show All", "form-button ui-corner-all", new RemoteOption
    {
      URL = Routing.Demo.UrlForSearchAll(),
      Update = "ListResult",
      Data = new { HtmlID = "ListResult" }
    })%>


	 	<%= Html.SubmitToRemote("Search", "form-button ui-corner-all", new RemoteOption
    {
      URL = Routing.Demo.UrlForSearchAll(),
      Update = "ListResult",
      Data = new { HtmlID = "ListResult" },
      CallBefore = "CheckWhiteFields()"
    })%>


</div>
</form>