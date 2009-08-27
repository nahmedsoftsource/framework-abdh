<%@ Page Title="" Language="C#" Inherits="ABDHFramework.Controllers.BaseViewPage<ABDHFramework.Data.SearchResult<ABDHFramework.Models.tblCategory>>" %>

<%--<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>--%>
<%@ Import Namespace="ABDHFramework.Lib" %>
<%@ Import Namespace="ABDHFramework.Lib.Pager" %>
<%@ Import Namespace="ABDHFramework.Models" %>

<link href="~/Content/Style.css" rel="stylesheet" type="text/css" />
<link href="~/Content/fontsize.css" rel="stylesheet" type="text/css" />
  

<div class="msg_list">
        <%if(Model.Items.Count > 0){%>
        <%
              foreach(tblCategory category in Model.Items)
              {
                  %>
                  <%if (!category.ParentID.HasValue)
                    { %>
                    <p class="msg_head"><%=category.CategoryName%></p>  
                    <%} %>
                    <%if(category.tblCategories != null && category.tblCategories.Count > 0){ %>  
                    <div class="msg_body">
                        <%foreach(tblCategory  subCategory in category.tblCategories){ %>
                            <div class="sub_msg_body">
                                <%=Html.LinkToRemote(subCategory.CategoryName,new RemoteOption
                                  {
                                    Update = "ListAllID",
                                    URL=Routing.Product.UrlForListProduct(subCategory.ID,null,null,"","")
                                  })%>
                                
		                    </div>                        
                        <%} %>
                        </div>      
                    <%} %>
                  <%
              }
               %>
        <%} %>
</div>

    
