<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<link href="~/Content/Style.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/fontsize.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src='<%= Url.Content("~/Scripts/Menu/jquery-1.3.1.min.js")%>'></script>
    <script type="text/javascript" src='<%= Url.Content("~/Scripts/Menu/jquery.multi-ddm.js")%>'></script>
    <script type='text/javascript'>
      $(document).ready(function() {
        //hide the all of the element with class msg_body
        $(".msg_body").hide();
        //toggle the componenet with class msg_body
        $(".msg_head").click(function() {
          $(this).next(".msg_body").slideToggle(600);
        });
      });
</script>
<div class="msg_list">
		<p class="msg_head">Header-1 </p>
		<div class="msg_body">
			orem ipsum dolor sit amet, consectetuer adipiscing elit orem ipsum dolor sit amet, consectetuer adipiscing elit
		</div>

	
		<p class="msg_head">Header-2</p>
		<div class="msg_body">
			orem ipsum dolor sit amet, consectetuer adipiscing elit orem ipsum dolor sit amet, consectetuer adipiscing elit

		</div>
	

		<p class="msg_head">Header-3</p>
		<div class="msg_body">
			orem ipsum dolor sit amet, consectetuer adipiscing elit orem ipsum dolor sit amet, consectetuer adipiscing elit
		</div>
	
	
</div>
   