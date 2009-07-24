<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="UpperMainContent" runat="server">

    <script type="text/javascript">
        $(document).ready(function(){
                 LoadBanner('banners');
            });
        function enlarge(ctr)
        {
            var gridItem = $('#' + ctr.id);
            var className =gridItem.attr('class');
            
            
            if(gridItem.hasClass('gridItem'))
            {
                //grid
                
                gridItem.toggleClass('gridItem_on');
            }
            else
            {
                //list
                gridItem.toggleClass('gridItem_v_on');
            }
        }
        function displaySwitch(type)
        {
            var grid = $(".topic .grid");
            var list = $(".topic .list");
            if(type == 'grid')
            {
                if(grid.hasClass('grid_on'))
                    grid.removeClass('grid_on');
                else
                    grid.addClass('grid_on');
            }
            else
            {
                if(list.hasClass('list_on'))
                    list.removeClass('list_on');
                else
                    list.addClass('list_on');   
            }
        }
        function changeDisplay(ctr, id)
        {
            var source = $('#' + ctr.id);
            if(source.hasClass('listview'))
            {
                $('#' + id + ' .gridItem').removeClass('gridItem').addClass('gridItem_v');
            }
            else
            {
                $('#' + id + ' .gridItem_v').removeClass('gridItem_v').addClass('gridItem');
            }
        }
        function LoadBanner(ctr)
        {
            $('#' + ctr + ' .banner:gt(0) ').css("display","none");
            $('#' + ctr + ' ul li a').mouseover(function(){
                var index = $('#' + ctr + ' ul li a').index(this);
                $('#' + ctr + ' .banner').css("display","none");
                $('#' + ctr + ' .banner:eq(' + index+ ') ').fadeIn('slow');
            });
        }
    </script>

    <div class="barCterTab">
        <div class="barCterTabLleft">
            <div class="barCterTabRight">
                <div style="line-height: 23px;" class="ctentBarTab">
                    Sản phẩm
                </div>
            </div>
        </div>
    </div>
    <div class="boxCtentSp">
        <div class="boxCtentSpTop">
            <div class="boxCtentSpBtom">
                <div class="boxCtentSpCtent">
                </div>
            </div>
        </div>
    </div>
    <div class="barCterTab">
        <div class="barCterTabLleft">
            <div class="barCterTabRight">
                <div style="line-height: 23px;" class="ctentBarTab">
                    Giới thiệu
                </div>
            </div>
        </div>
    </div>
    <div class="boxCtentSp">
        <div class="boxCtentSpTop">
            <div class="boxCtentSpBtom">
                <div class="boxCtentSpCtent">
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
