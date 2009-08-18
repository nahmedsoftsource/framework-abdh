<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<% if (Session["Culture"].ToString() == "en-CA") {%>
    <a href="/Home/SetCulture/fr-CA">[ Français ]</a>
<% } else if (Session["Culture"].ToString() == "fr-CA") { %>
    <a href="/Home/SetCulture/en-CA">[ English ]</a> 
<% } %>