<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<NGUYENHIEP.Models.tblNew>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="UpperMainContent" runat="server">

<div class="mainCtentSpRight">

	
    <div class="barCterTab">
    	<div class="barCterTabLleft">
        	<div class="barCterTabRight">
            	<div style="line-height:23px;" class="ctentBarTab">
                	Ảnh công trình
                </div>

            </div>
        </div>
    </div>

    <div class="boxCtentSp">
            	<div class="boxCtentSpTop">
                	<div class="boxCtentSpBtom">
                    	<div class="boxCtentSpCtent">
                        <div class="textLeft">
    <%int counter = 0; %>
    <% foreach (var item in Model) { %>
        <%--<%if (counter == 0)
          { %>
        <tr>
        <%} %>--%>
        
        <%--<td class="clear">--%>
            <div class="subSp">

            	<div class="clear"><a href="#"><img src="../..<%=item.Image%>" /></a></div>
                <div class="paddingTb4 paddingLr18px bold">
                	<%=Html.ActionLink(item.TitleVN, "ViewNews", new { newsID = item.ID},new {@class="color2"})%>
                </div>
                <div class="clear"></div>
            </div>
        <%counter++; %>
        <%--</td>--%>
        <%if (counter == 4)
          { %>
        <div class="clear"></div>
        <%} %>
        <%if (counter == 4) counter = 0; %>
    
    <% } %>
    </div>
    </div>
    </div>
    </div>
    </div>
    

</div>
<div class="barCterTab">
    	<div class="barCterTabLleft">
        	<div class="barCterTabRight">
            	<div style="line-height:23px;" class="ctentBarTab">
                	<%= Html.ActionLink("Create New", "Create") %>
                </div>

            </div>
        </div>
</div>

</asp:Content>

