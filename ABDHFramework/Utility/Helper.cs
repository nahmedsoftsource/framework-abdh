using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ABDHFramework.Utility
{
  public class Helper
  {
    private HtmlHelper _html;

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="viewPage"></param>
    public Helper(HtmlHelper html)
    {
      _html = html;
    }

    /// <summary>
    /// dropdown list
    /// </summary>
    /// <param name="name"></param>
    /// <param name="selectList"></param>
    /// <returns></returns>
    public static string DropDownList(string name, IEnumerable<SelectListItem> selectList){
      return DropDownList(name, selectList, null, new { });
    }

    public static string DropDownList(string name, IEnumerable<SelectListItem> selectList, string optionLabel){
      return DropDownList(name, selectList, optionLabel, new { });
    }

    /// <summary>
    /// dropdown list
    /// </summary>
    /// <param name="name"></param>
    /// <param name="selectList"></param>
    /// <param name="optionLabel"></param>
    /// <param name="htmlAttributes"></param>
    /// <returns></returns>
    public static string DropDownList(string name, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
    {
      var b = new TagBuilder("select");

      b.MergeAttribute("name", name);
      b.MergeAttribute("id", name);
      b.MergeAttributes(new RouteValueDictionary(htmlAttributes));

      var ret = "";
      if (optionLabel != null){
        var option = new TagBuilder("option");
        option.MergeAttribute("value", "");
        option.InnerHtml = optionLabel;

        ret = option.ToString();
      }
      

      foreach (var item in selectList)
      {
        var o = new TagBuilder("option");
        o.MergeAttribute("value", item.Value);
        if (item.Selected){
          o.MergeAttribute("selected", "selected");
        }
        o.InnerHtml = item.Text;
        ret += o.ToString();
      }

      b.InnerHtml = ret;

      return b.ToString();
    }
  }
}
