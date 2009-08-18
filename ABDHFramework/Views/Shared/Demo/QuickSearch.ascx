<%@ Control Language="C#" Inherits="ABDHFramework.Controllers.BaseViewUserControl" %>
<%@ Import Namespace="ABDHFramework.Utility" %>

<script type="text/javascript">
  function CheckWhiteFields() {
    var name = $("#Agent_QuickSearch_Name").val();
    if (name.length == 0) {
      alert('Please input search criteria');
      return false;
    }
    else {
      return true;
    }

  }

  function reloadAfterSelect(data) {
    var agentId = data;
    Core.SubmitToRemote(this, { "url": '<%=Routing.Agent.UrlForRefreshAgentInfo()%>', "update": "AgentDetailAndInsurance", "method": "POST", "isForm": false, "data": { "ID": agentId }, "with": null });
  } 

</script>

<form method="post" id="AgentSearchForm">
  <table class="table-form maxwidth" border="0" cellpadding="0" cellspacing="0" >
	  <tr class="field">
		  <td><span class="field-label" style="width:70px;">Name</span></td>
	    <td><span class="field-input"><%= FluentHtml.TextBox("FullName").Id("Agent_QuickSearch_Name").Style("width:200px")%></span></td>
    </tr>
    <tr>
      <td class="field" colspan="2">
          <span class="field-label"style="width:100%">
	        <%= FluentHtml.CheckBox("Shared").LabelAfter("Include Shared")%>
          </span>
      </td>
    </tr>
    <tr class="field">
      <td colspan="2">
	        <span class="field-label" style="width:100%;">
	        <%= FluentHtml.RadioButton("Inactive").Id("Agent_QuickSearch_Active").Value(false).LabelAfter("Active")%>
	        <%= FluentHtml.RadioButton("Inactive").Id("Agent_QuickSearch_Inactive").Value(true).LabelAfter("Inactive")%>
	        <%= FluentHtml.RadioButton("Inactive").Id("Agent_QuickSearch_Both").Value("").Checked(true).LabelAfter("Both")%>
        </span>
      </td>
    </tr>
  </table>
 <%-- <%= Html.AutoCompleteFor("Agent_QuickSearch_Name", new AutoCompleteOption
          {
            URL = Routing.Agent.UrlForSuggestForField("Name"),
            Result = "reloadAfterSelect(info.data.AgentID)",
            MinChars = 2
          })%>--%>

<div class="buttonpane">
	 	<%= Html.ButtonToRemote("Show All", "form-button ui-corner-all", new RemoteOption
    {
      URL = Routing.Demo.UrlForSearchAll(),
      Update = "ListSearchResult",
      Data = new { HtmlID = "ListSearchResult" }
    })%>


	 	<%= Html.SubmitToRemote("Search", "form-button ui-corner-all", new RemoteOption
    {
      URL = Routing.Agent.UrlForQuickSearch(),
      Update = "divListResult_body",
      Data = new { HtmlID = "divListResult_body" },
      CallBefore = "CheckWhiteFields()"
    })%>


</div>
</form>