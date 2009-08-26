using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using ABDHFramework.Lib;
using ABDHFramework.Data;
using ABDHFramework.Common;
using ABDHFramework.Lib.Javascripts;

namespace ABDHFramework.Lib
{

  public static class SelectHelper
  {
    static public void SelectMultiple(this HtmlHelper html, SelectMultipleOption option)
    {
      if (option.DestinationList == null)
        option.DestinationList = new SelectList(new List<SelectListItem>());

      if (option.SourceList == null)
        option.SourceList = new SelectList(new List<SelectListItem>());

      //exclude item of source that exist in destination
      option.SourceList = new SelectList(option.SourceList.Where(pt => !option.DestinationList
        .Any(dest => pt.Value == dest.Value)), "Value", "Text");

      string destinationList1 = html.ListBox(option.DestinationListID, option.DestinationList, option.HtmlAttributes);
      string sourceList1 = html.ListBox(option.SourceListID,option.SourceList, option.HtmlAttributes);

      string htmlListBox = @"
      <table>
          <tr>
            <td>{SourceText}</td>
            <td>&nbsp;</td>
            <td>{DestinationText}</td>
          </tr>
          <tr>
            <td>{SourceList}</td>
            <td>
              <input type=""button"" id=""{AddButtonID}"" value=""►""/>
              <br/>
              <input type=""button"" id=""{DelButtonID}"" value=""◄""/>
            </td>
            <td>{DestinationList}</td>
          </tr>
      </table>
       <script type=""text/javascript"">
       $(document).ready(function(){
        $(""#{AddButtonID}"").click(function()
        {
          SelectListBoxItems(""{SourceListID}"",""{DestinationListID}"");
        });
        $(""#{DelButtonID}"").click(function()
        {
          UnSelectListBox(""{SourceListID}"",""{DestinationListID}"");
        });
      });
      </script>";
      htmlListBox = htmlListBox.Replace("{SourceList}", sourceList1);
      htmlListBox = htmlListBox.Replace("{AddButtonID}", option.AddButtonID);
      htmlListBox = htmlListBox.Replace("{DelButtonID}", option.DelButtonID);
      htmlListBox = htmlListBox.Replace("{DestinationList}", destinationList1);
      htmlListBox = htmlListBox.Replace("{SourceListID}", option.SourceListID);
      htmlListBox = htmlListBox.Replace("{DestinationListID}", option.DestinationListID);
      htmlListBox = htmlListBox.Replace("{SourceText}", option.SourceText);
      htmlListBox = htmlListBox.Replace("{DestinationText}", option.DestinationText);

      html.ViewContext.HttpContext.Response.Write(htmlListBox);
    }
    /*
    static public void SelectMultiple_2Column(this HtmlHelper html,
                                        string selectList_Name,
                                        string selectAll_Name,
                                        IDictionary<int, Common.Domain.State> data,
                                        IDictionary<int, Common.Domain.State> dataSelected)
    {      
      int selectControlSize = 8;
      string options = "";

      //create option tag
      TagBuilder tag = new TagBuilder("option");

      //duyet qua danh sach cac data
      foreach (var item in data)
      {
        if (dataSelected.Keys.Contains(item.Key)==true)
        {
          continue;
        }
        tag.MergeAttribute("value",item.Key.ToString(), true);
        tag.InnerHtml = item.Value.Abbr+ " - "+item.Value.Name;
        options += tag.ToString();
      }
      string optionsSelected = "";
      foreach (var itemSelected in dataSelected)
      {
        tag.MergeAttribute("value", itemSelected.Key.ToString(), true);
        tag.InnerHtml = itemSelected.Value.Abbr+ " - "+itemSelected.Value.Name;
        optionsSelected += tag.ToString();
      }

      #region htmlform
      string sket =
      @"<TABLE>
        <TR>
          <input type=""checkBox"" 
                  Name=""" + selectAll_Name + @""" 
                  id=""" + selectAll_Name + @""" >
            Select All
          </input>
        </TR>
        <TR>
          <TD>
            <select id=""SelectSource"" 
                    name=""SelectSource"" 
                    multiple=""multiple"" length=""1"" 
                    size=""" + selectControlSize + @""">
                    " + options + @"
                    class=""list_multiple""
            </select>
          </TD>
          <TD>
            <input type=""button"" value=""->"" id=""btnSelect""/>
            <BR/>
            <input type=""button"" value=""<-""id=""btnRemove""/>
          </TD>
          <TD>
            <select id=""" + selectList_Name + @""" 
                    name=""" + selectList_Name + @"""
                    multiple=""multiple"" 
                    length=""1"" 
                    class=""list_multiple""
                    onchange=""SelectAll()""
                    size=""" + selectControlSize + @""">
                    " + optionsSelected + @"
                    class=""list_multiple""
          </TD>
        </TR>
      </TABLE>";
      #endregion

      #region scriptOnLoad
      string scriptOnLoad =
            @"$(document).ready(function(){
	              $(""#btnSelect"").click(function()
	              {
		              SelectListBoxItems();
	              });
	              $(""#btnRemove"").click(function()
	              {
		              UnSelectListBox();
	              });
		            ToggleSelectAll();  
	              $(""#" + selectAll_Name + @""").change(function()
	              {
		              ToggleSelectAll();
	              });
              });";
      #endregion

      #region scriptFuntions
      string scriptFuntions =
  @"function ToggleSelectAll()
	{
    var checked=$(""#" + selectAll_Name + @""").attr(""checked"");
		var select=$(""select[id$='SelectSource']"");
		var selected=$(""select[id$='" + selectList_Name + @"']"");
		if(checked==true)
		{
			select.attr(""disabled"", true); 
			selected.attr(""disabled"", true); 
			$(""#btnSelect"").attr(""disabled"", true); 
			$(""#btnRemove"").attr(""disabled"", true); 
		}
		else
		{
			select.removeAttr(""disabled""); 
			selected.removeAttr(""disabled""); 
			$(""#btnSelect"").removeAttr(""disabled""); 
			$(""#btnRemove"").removeAttr(""disabled""); 
		}
	} 
	  function SelectAll()
    {   
    }
   function SelectListBoxItems()
	  {
		  var select=$(""select[id$='SelectSource']"");
		  var selected=$(""select[id$='" + selectList_Name + @"']"");
		  var OptionSelected=$(""select[id$='SelectSource'] option:selected"");
		  if(selected.children(""*"").length>0)
		  {
			  selected.children(""*"").attr(""selected"",""selected""); 
		  }
		  selected.append(OptionSelected);
	  }

   function UnSelectListBox()
	  {
		  var select=$(""select[id$='SelectSource']"");
		  var selected=$(""select[id$='" + selectList_Name + @"']"");
		  var OptionSelected=$(""select[id$='" + selectList_Name + @"'] option:selected"");
		  for(var i=0;i<OptionSelected.length;i++)
		  {
			  insertToListBox(select,OptionSelected[i]);
		  }
	  }
  function insertToListBox(listbox, optionToInsert)
	{
		if($(listbox).is(""select[type$='multiple']"")==true)
		{
			if($(optionToInsert).is(""option"")==true)
			{
					var insert=false;
					var options=$(listbox).children(""option"");
					for(var i=0;i<options.length;i++)
					{	

						var cur=parseInt(options.eq(i).val());
						var value=parseInt($(optionToInsert).val());
						if(cur>value)
						{
							$(optionToInsert).insertBefore(options.eq(i));
							insert=true;
							break;
						}
					}
					if(insert==false)
					{						
						listbox.append(optionToInsert);
					}
			}
		}
	}";
      #endregion

      html.ViewContext.HttpContext.Response.Write(UIHelper.JavascriptTag(scriptOnLoad));
      html.ViewContext.HttpContext.Response.Write(UIHelper.JavascriptTag(scriptFuntions));
      html.ViewContext.HttpContext.Response.Write(sket);
    }
    */
    static public string DataRequireValidator(this HtmlHelper html, string controlName, string strError)
    {
      string rs = "";
      return rs;
    }

    /// <summary>
    /// select list 2 columns
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static String SelectList2Column(this HtmlHelper html, String name){
      if (html.ViewData[name] == null || !(html.ViewData[name] is IEnumerable<SelectListItem>)){
        throw new Exception(String.Format("Can not find ViewData for key {0} or ViewData[{0}] is not IEnumerable<SelectListItem>", name));
      }
      return SelectList2Column(html, name, html.ViewData[name] as IEnumerable<SelectListItem>);
    }

    /// <summary>
    /// select list 2 columns
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="selectList"></param>
    /// <returns></returns>
    public static String SelectList2Column(this HtmlHelper html, String name, IEnumerable<SelectListItem> selectList)
    {
      return SelectList2Column(html, name, selectList, null);
    }

    public static String SelectList2Column(this HtmlHelper html, String name, IEnumerable<SelectListItem> selectList, Object attribute)
    {
      return SelectList2Column(html, name, selectList, attribute,200);
    }

    /// <summary>
    /// render select list 2 columns
    /// </summary>
    /// <param name="html"></param>
    /// <param name="name"></param>
    /// <param name="selectList"></param>
    /// <param name="attribute"></param>
    /// <returns></returns>
    public static String SelectList2Column(this HtmlHelper html, String name, IEnumerable<SelectListItem> selectList, Object attribute,int width){
      var items = Json.EncodeDictionary(selectList.ToDictionary(item => item.Value, item => item.Text));
      var selectedItems = Json.Encode(selectList.Where(item => item.Selected).Select(item => item.Value).ToArray());

      var itemsStr = items.Substring(0, items.Length);
      var selectedItemsStr = selectedItems.Substring(0, selectedItems.Length);

      var htmlID = name.Replace(".", "_")+"Container";

      var containertag = new TagBuilder("div");
      containertag.MergeAttribute("id", htmlID);

      var script = String.Format(@"new SelectList2Column({{
htmlID: {0},
name: {1},
items: {2},
selectedItems: {3},
width: {4}
}}).render();",
              Json.Encode(htmlID),
              Json.Encode(name),
              itemsStr,
              selectedItemsStr,
              width
      );
      return containertag.ToString() + Javascript.AddToJavascriptTag(script);
    }
  }
}
