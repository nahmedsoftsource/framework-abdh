<%@ Page Title="" Language="C#"  Inherits="ABDHFramework.Controllers.BaseViewPage<ABDHFramework.Models.tblProduct>" %>
<%@ Import Namespace="ABDHFramework.Lib" %>
<%@ Import Namespace="ABDHFramework.Lib.Pager" %>
<%@ Import Namespace="ABDHFramework.Models" %>
<%if (Model != null)
  { %>
<div  class="mainCtentSpRight">
        	<div class="barCterTab">
            	<div class="barCterTabLleft">
                	<div class="barCterTabRight">
                    	<div style="line-height:23px;" class="ctentBarTab">
                        	<%=Resources.Global.ProductDetails %>
                        </div>

                    </div>
                </div>
            </div>
            <div class="boxCtentSp">
            	<div class="boxCtentSpTop">
                	<div class="boxCtentSpBtom">
                    	<div class="boxCtentSpCtent">
                            <div class="paddingTb4">
				                <div class="floatLeft" style="width:150px;">

                                    <a href="#"><img class="imgGthieu" src='<%= Url.Content("~"+((Model.Image != null)?Model.Image.Replace("ThumbImagesNewsSmallest", "ThumbImagesNews"):""))%>' /></a>
                                </div>
		                        <div class="floatLeft" style="width:530px;">
		                         
                             <div class="bold fontsize13 textLine"><a href="#" class="color2"><%=(!string.IsNullOrEmpty(Model.ProductName) ? Model.ProductName : "Không có tiêu đề")%></a></div>
				                    
			                        
                              
                              <div class="textLine"><span class="bold"><%=Resources.Global.ProductType%>:</span> <a href="#" class="color1"><%=((Model.tblCategory != null) ? Model.tblCategory.CategoryName : Resources.Global.NotAvailable)%></a> </div>
                                   
			                        <div class="bold textLine"><span class="bold color1"><%=Resources.Global.Price%>: </span><%=(((Model.Price.HasValue) ? Model.Price.ToString() : " ") + "USD")%></div>
			                       
				                    <div><%=(Model.Property != null) ? Model.Property : ""%></div>

		                        </div>
					            <div class="clear"></div>
			                </div>
                            <div class="bold fontsize13" style=" border-bottom:2px solid #487DBD; background:#99C8E1; margin-bottom:20px; padding: 2px 0 2px 2px;"><%=Resources.Global.Details%></div>
                            <div class="paddingTb4"><a class="color2" href="#"></a>
                                
                                <%=((Model.Description != null) ? Model.Description : "")%>
                            </div>
                  
                        </div>
                    </div>
                </div>
            </div>
           
</div>
<%} %>




