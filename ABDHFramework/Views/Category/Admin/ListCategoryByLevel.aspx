<%@ Page Title="" Language="C#" Inherits="ABDHFramework.Controllers.BaseViewPage" %>
<span>
    Chọn cha
</span>
<span>
<%=Html.DropDownList("ParentID", ((List<SelectListItem>)ViewData["ListCategory"]).AsEnumerable())%>
  </span>



    
