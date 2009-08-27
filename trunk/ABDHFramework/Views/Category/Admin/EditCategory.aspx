<%@ Page Title="" Language="C#"  Inherits="ABDHFramework.Controllers.BaseViewPage<ABDHFramework.Models.tblCategory>" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Import Namespace="ABDHFramework.Lib" %>
<%@ Import Namespace="ABDHFramework.Lib.Pager" %>
<%@ Import Namespace="ABDHFramework.Models" %>
  
    <div class="ui-tabs-panel ui-widget-content ui-corner-bottom">
    <form id="form2" runat="server"  method='POST' enctype='multipart/form-data' action="#" style="width:100%">
    <div class="TitleAction">
    <%if (ViewData["AddNews"] != null)
          { %>
            <h2><%=Resources.Global.AddCategory %></h2>
        <%}
          else
          { %>
        <h2><%=Resources.Global.EditCategory %></h2>
        <%} %>
        </div>

    <table class="layout-form  maxwidth" cellspacing="2" cellpadding="0" border="0">
    <tr>
        <td>
        Cấp
        </td>
        <td>
        <span>
        <%if(ViewData["ListLevelCategory"] != null){ %>
        <%=Html.DropDownList("Level",((List<SelectListItem>)ViewData["ListLevelCategory"]).AsEnumerable()) %>
        <%} %>
        </span>
        
        <span>
        <div id="ListCategoryByLevel"></div> 
        </span>
        </td>
    </tr>
    <tr>
        <td class="l" style="width:30%">
            <label for="CategoryName"><%=Resources.Global.Name %>:</label>
        </td>
        
        <td class="l">
        
            <%= Html.TextBox("CategoryName", Model.CategoryName, new {  style = "width:100%", @class = "noidung" })%>
            <%= Html.ValidationMessage("CategoryName")%>
        
        </td>
    </tr>
    
    
    
    <tr>
        <td class="l"  style="width:30%">
            <label for="DescriptionVN"><%=Resources.Global.Description %>:</label>
        </td>
        
        <td class="l">
        
            <%= Html.TextBox("Description", Model.Description, new { rows="5", style = "width:100%", @class = "noidung" })%>
            <%= Html.ValidationMessage("Description")%>
        
        </td>
    </tr>
    
        
    <tr>
        <td colspan="2" class="c"  style="width:30%">
        
        <span style="float:right">
        <%if (Model != null && (Model.ID == null || Model.ID.Equals(Guid.Empty)) )
          { %>
          <%=Html.SubmitToRemote(Resources.Global.AddCategory, new RemoteOption
            {
              CausesValidation=false,
              Method = "POST",
              URL = Routing.Category.UrlForEditCategory(Model.ID),
              Update = "ListID",
              
            }) %>
        <%}
          else
          { %>
          <span style="float:right">
        <%--<input type="submit" class="abutton" value="<%=Resources.Global.Update %>" />--%>
        <%=Html.SubmitToRemote(Resources.Global.Update,new RemoteOption
            {
              CausesValidation=false,
              Method = "POST",
              URL = Routing.Category.UrlForEditCategory(Model.ID),
              Update = "ListID",
              
            }) %>
          
        </span>
        <%} %>
        </span>
        </td>
    </tr>
    
    </table>
<script language="javascript" type="text/javascript">
    $(document).ready(function() {
        var content = "";

        $("select").change(function() {
            var options = document.getElementsByTagName("option");
            var level;
            for (i = 0; i < options.length; i++)
                if (options[i].selected)
                level = options[i].value;
            content = $.ajax({
                url: '<%=Routing.Category.UrlForListCategoryByLevel() %>',
                data: "level=" + level,
                global: false,
                type: "POST",
                dataType: "html",
                async: false,
                success: function(msg) {
                    if (document.layers) {
                        document.getElementById('ListCategoryByLevel').open();
                        document.getElementById('ListCategoryByLevel').write(msg);
                        document.getElementById('ListCategoryByLevel').close();
                        document.getElementById('ListCategoryByLevel').innerHTML = msg;
                    }
                    else {
                        document.getElementById('ListCategoryByLevel').innerHTML = msg;
                    }

                }
            }).responseText;
        })
    })
    </script>    
    </form>
    
    
</div>


