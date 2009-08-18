<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ABDHFramework.Data.SearchResult<ABDHFramework.Models.tblProduct>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">
    <%--<%ABDHFramework.Utility.UIHelper.RenderRemotePartial(Html, "ListAllNewsID", "", (new UrlHelper(ViewContext.RequestContext)).Action("ListAllNews", "ABDHFramework") + "?pageSize=" + (int)ABDHFramework.Common.Constants.DefautPagingSize + "&page=1");%>--%>
    <div class="mainCtentSpRight" id="ListSearchResult">
        <%Html.RenderPartial("~/Views/Shared/Demo/ListResult.ascx", ViewData); %>
        <input type="hidden" id="SelectedMenuId" name="SelectedMenuId" value="3" />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenu" runat="server">
  
                    <div id="QuickSearchID">
                    
                    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PromotionAnnoucement" runat="server">

                    <div id="ListNewsPromotionID">
                    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RiightNewsEvent" runat="server">

                   <div id="ListHotNewsID" class="boxNews">
                    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="LowerMainContent" runat="server">
</asp:Content>
