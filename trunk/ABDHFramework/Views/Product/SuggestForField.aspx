<%@ Page Language="C#"  Inherits="ABDHFramework.Controllers.BaseViewPage<IEnumerable<ABDHFramework.Lib.Javascripts.AutoCompleteDataItem>>" %>
<%@ Import Namespace="ABDHFramework.Lib" %>
<%= Html.RenderAutoCompleteData(ViewData.Model) %>

