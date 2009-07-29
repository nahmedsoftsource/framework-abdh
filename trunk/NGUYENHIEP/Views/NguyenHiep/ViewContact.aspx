<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<NGUYENHIEP.Models.tblInformation>" %>


<div id="mainCtentSpRight">
	<div class="barCterTab">
    	<div class="barCterTabLleft">
        	<div class="barCterTabRight">
            	<div style="line-height:23px;" class="ctentBarTab">
                	Liên hệ
                </div>

            </div>
        </div>
    </div>
    <div class="boxCtentSp">
    	<div class="boxCtentSpTop">
        	<div class="boxCtentSpBtom">
            	<div class="boxCtentSpCtent">
      			    <div style="padding: 10px 0 30px 0;">
      			    
                        <div style="padding: 0 0 30px 0; line-height: 18px; margin-bottom: 20px; border-bottom: 1px solid #CCC" class="clear">
                        <%= ((Model != null && !String.IsNullOrEmpty(Model.ContactVN)) ? Model.ContactVN : "Thông tin chưa cập nhật")%>
                            
                        </div>
                        <div style="padding: 0 0 30px 0; line-height: 18px; margin-bottom: 20px; border-bottom: 1px solid #CCC" class="clear">
                        <span style="float:right">
                                 <%=NguyenHiep.Utility.UIHelper.ButtonTo(Html, "EditContact", "Sửa", (new UrlHelper(ViewContext.RequestContext)).Action("EditContact", "NguyenHiep") + "?newsID=" + ((Model != null?Model.ID:Guid.Empty)))%>
                            </span>
                            </div>
                        
                        <div class="clear">
                        
                        </div>
                    </div>
                    <table style="line-height:25px;" cellpadding="0" cellspacing="0" width="100%">
            	<tr>
                	<td width="36%" valign="top" class="bold">Nhập tên của bạn:</td>

                    <td width="64%" valign="top"><input name="name" size="30" class="inputbox" value="" type="text"></td>
            	</tr>
            	<tr>
            	  <td class="bold" valign="top">Gửi một địa chỉ email tới đầu mối liên lạc này:</td>
          	      <td valign="top">
                  
                  <select name="con_id" class="inputbox">
                  <option value="6">Ban giám đốc</option>
                  <option value="2">Phòng kỹ thuật</option>

                  <option value="3">Phòng Marketing</option>
                  <option value="4">Phòng kinh doanh</option>
                  <option value="5">Phonhf kế toán</option></select>
                  </td>
           	  </tr>
            	<tr>
            	  <td class="bold" valign="top">Địa chỉ email:</td>

          	      <td valign="top"><input name="name" size="30" class="inputbox" value="" type="text"></td>
           	  </tr>
            	<tr>
            	  <td class="bold" valign="top">Tiêu đề tin nhắn:</td>
          	      <td valign="top"><input name="name" size="30" class="inputbox" value="" type="text"></td>
           	  </tr>
            	<tr>
            	  <td class="bold" valign="top">Nội dung:</td>

          	      <td valign="top"><textarea cols="35" rows="10" name="text" id="contact_text" class="inputbox"></textarea></td>
           	  </tr>
            	<tr>
            	  <td valign="top">&nbsp;</td>
          	      <td class="paddingTb4"><input type="button" value="Gửi đi" />
                  	<input type="reset" value="Làm lại" />
                  </td>
           	  </tr>

            	<tr>
            	  <td>&nbsp;</td>
          	      <td>&nbsp;</td>
           	  </tr>
            </table>
                <div class="clear"></div>
         
          
			</div>
            </div>
        </div>
	</div>
</div>



