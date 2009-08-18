using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Html;

namespace ABDHFramework.Utility
{
  public static class UIHelper
  {
    private static Dictionary<string, string> Dialogs
    {
      get
      {
        if (HttpContext.Current.Items["UIDialogs"] == null)
        {
          HttpContext.Current.Items["UIDialogs"] = new Dictionary<string, string>();
        }
        return HttpContext.Current.Items["UIDialogs"] as Dictionary<string, string>;
      }
    }

    /**
     * button to link
     * */
    static public string ButtonToJavascriptAction(this HtmlHelper html, string name, string value, string action)
    {
      return String.Format("<input type=\"button\" name=\"{0}\" value=\"{1}\" onclick=\"{2}()\" class=\"form-button ui-state-default ui-corner-all\"/>", name, value, action);
    }

    static public string ButtonTo(this HtmlHelper html, string name, string value, string url)
    {
      return String.Format("<input type=\"button\" name=\"{0}\" value=\"{1}\" onclick=\"window.location='{2}'\" class=\"form-button ui-state-default ui-corner-all\"/>", name, value, url);
    }

    static public string LinkTo(this HtmlHelper html, string name, string value, string url)
    {
      return String.Format("<a href=\"{0}\" class=\"form-button ui-state-default ui-corner-all\">{1}</a>", url, name);
    }

    static public string LinkToWithStyle(this HtmlHelper html, string name, string value, string url, String sClass)
    {
      return String.Format("<a href=\"{0}\" class=\"{2}\">{1}</a>", url, name, sClass);
    }

    public static string ButtonToDialog(this HtmlHelper html, string name, string url)
    {
      return String.Format("<input type=\"button\" value=\"{0}\" url=\"{1}\" class=\"ajaxWindow\" />", name, url);
    }

    public static string ToolbarButton(this HtmlHelper html, string name, string url)
    {
      return String.Format("<a href=\"{1}\" class=\"toolbar-button toolbar-icon-task-add\">{0}</a>", name, url);
    }

    public static string ToolbarButton(this HtmlHelper html, string name, string url, string confirm)
    {
      return String.Format("<a href=\"{1}\" class=\"toolbar-button toolbar-icon-task-add\" onclick='return confirm(\"{2}\")'>{0}</a>", name, url, confirm);
    }

    public static string ToolbarButton(this HtmlHelper html, string name, string url, string confirm, string css)
    {
      return String.Format("<a href=\"{1}\" class=\"{3}\" onclick='return confirm(\"{2}\")'>{0}</a>", name, url, confirm, css);
    }

    public static string ToolbarButton(this HtmlHelper html, string id, string name, string url, string confirm, string css, string style)
    {
      return String.Format("<a href=\"{1}\" id=\"{5}\" style=\"{4}\" class=\"{3}\" onclick='return confirm(\"{2}\")'>{0}</a>", name, url, confirm, css, style, id);
    }

    static public string SelectGovType(this HtmlHelper html, string name, string defaultValue, object htmlAttr)
    {
      Dictionary<int, string> govList = new Dictionary<int, string>();
      for (int i = 1; i < 18; i++)
      {
        govList.Add(i, "Type - " + i.ToString());
      }

      IEnumerable<SelectListItem> list = govList.Select(govType => new SelectListItem { Value = govType.Key.ToString(), Text = govType.Value, Selected = (govType.Key.ToString() == defaultValue) });
      return html.DropDownList(name, list, "--- Select ---", htmlAttr);
    }

    static public string BeginListTable(this HtmlHelper html, object htmlAttr)
    {
      TagBuilder builder = new TagBuilder("table");
      builder.MergeAttributes(GetRouteValues(htmlAttr));
      builder.AddCssClass("ui-widget ui-widget-content ui-corner-all");
      return builder.ToString(TagRenderMode.StartTag);
    }

    static public string EndListTable(this HtmlHelper html)
    {
      return "</table>";
    }

    static public string BeginListTableHeader(this HtmlHelper html, object htmlAttr)
    {
      TagBuilder builder = new TagBuilder("tr");
      builder.MergeAttributes(GetRouteValues(htmlAttr));
      builder.AddCssClass("ui-widget-header");
      return builder.ToString(TagRenderMode.StartTag);
    }

    static public string EndListTableHeader(this HtmlHelper html)
    {
      return "</tr>";
    }

    static public void RenderDialog(this HtmlHelper html, string id, string title, String viewName)
    {
      RenderDialog(html, id, title, viewName, "");
    }
    static public void RenderDialog(this HtmlHelper html, string id, string title, String viewName, object model)
    {
      RenderDialog(html, id, title, viewName, "", model);
    }

    static public void RenderDialog(this HtmlHelper html, string id, string title, String viewName, string nextAction)
    {
      if (Dialogs.ContainsKey(id))
      {
        return;
      }
      if (String.IsNullOrEmpty(nextAction))
      {
        nextAction = "$('#" + id + "').dialog('close');";
      }
      html.ViewContext.HttpContext.Response.Write(
    @"<script type='text/javascript'>
  $(document).ready(function(){
    $('#" + id + @"').dialog({autoOpen: false, width: 600, draggable:false,modal:true,resizable:false});
    $('#" + id + @" .close').click(function(){
      $('#" + id + @"').dialog('close');
    });
    $('#" + id + @" .next').click(function(){
      " + nextAction + @"
    });
  });
</script>
");

      html.ViewContext.HttpContext.Response.Write("<div id='" + id + "' title='" + html.Encode(title) + "'>");
      html.RenderPartial(viewName);
      html.ViewContext.HttpContext.Response.Write("</div>");
      Dialogs.Add(id, "");
    }

    static public void RenderDialog(this HtmlHelper html, string id, string title, String viewName, string nextAction, object model)
    {
      if (Dialogs.ContainsKey(id))
      {
        return;
      }
      if (String.IsNullOrEmpty(nextAction))
      {
        nextAction = "$('#" + id + "').dialog('close');";
      }
      html.ViewContext.HttpContext.Response.Write(
    @"<script type='text/javascript'>
  $(document).ready(function(){
    $('#" + id + @"').dialog({autoOpen: false, width: 600, draggable:false,modal:true,resizable:false});
    $('#" + id + @" .close').click(function(){
      $('#" + id + @"').dialog('close');
    });
    $('#" + id + @" .next').click(function(){
      " + nextAction + @"
    });
  });
</script>
");

      html.ViewContext.HttpContext.Response.Write("<div id='" + id + "' title='" + html.Encode(title) + "'>");
      html.RenderPartial(viewName, model);
      html.ViewContext.HttpContext.Response.Write("</div>");
      Dialogs.Add(id, "");
    }

    static private RouteValueDictionary GetRouteValues(object htmlAttr)
    {
      return (htmlAttr == null) ? new RouteValueDictionary() : new RouteValueDictionary(htmlAttr);
    }

    public static String ButtonToRemote()
    {
      return "";
    }

    public static String JavascriptTag(String Content)
    {
      return String.Format(@"<script type=""text/javascript"">{0}</script>", Content);
    }

    public static String JavascriptFile(String url)
    {
      return String.Format(@"<script type=""text/javascript"" src=""{0}""></script>", url);
    }

    static public String ErrorTag(this HtmlHelper html, string msg)
    {
      return String.Format(@"<DIV class=""ErrorLabel""> -{0}</DIV>", msg);
    }

    static public void RenderRemotePartial(this HtmlHelper html, string id, string title, string url)
    {
      RenderRemotePartial(html, id, title, url, "");
    }

    static public void RenderRemotePartial(this HtmlHelper html, string id, string title, string url, string nextAction)
    {
      if (Dialogs.ContainsKey(id))
      {
        return;
      }
      if (String.IsNullOrEmpty(nextAction))
      {
        nextAction = "$('#" + id + "').dialog('close');";
      }
      html.ViewContext.HttpContext.Response.Write(
@"<script type='text/javascript'>
  $(document).ready(function(){
    $('#" + id + @"').dialog({autoOpen: false, width: 600, draggable:false,modal:true,resizable:false, title: '" + title + @"'
      , open: function(){ 
          if ($(this).get(0).isLoaded) return;
          $.ajax({ method:'POST', dataType: 'html', url: '" + url + @"' 
            , success: function(html) { $('#" + id + @"').get(0).isLoaded = true;$('#" + id + @"').dialog('close'); $('#" + id + @"_content').html(html); $('#" + id + @"').dialog('open'); }
            }); 
        }
      });
    $('#" + id + @" .close').click(function(){
      $('#" + id + @"').dialog('close');
    });
    $('#" + id + @" .next').click(function(){ " + nextAction + @" });
  });
</script>
");

      string imgLoading = html.ViewContext.HttpContext.Request.ApplicationPath + "/Content/images/loading.gif";
      html.ViewContext.HttpContext.Response.Write("<div id='" + id + "'>");
      html.ViewContext.HttpContext.Response.Write("<div id='" + id + "_content' style='display:none'><img src='" + imgLoading + @"' alt='Loading'/> Loading...</div>");
      html.ViewContext.HttpContext.Response.Write("</div>");
      Dialogs.Add(id, "");
    }

    public static string SuggestionBox(this HtmlHelper html, string name, object value, string suggestUrl, object htmlAttributes)
    {
      string id = name.Replace(".", HtmlHelper.IdAttributeDotReplacement);
      string result = JavascriptTag(
@"$(document).ready(function(){
    $('#" + id + @"').
");
      result += html.TextBox(name, value, htmlAttributes);
      return result;
    }

    /// <summary>
    /// Generates the id from name by MVC method.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns></returns>
    public static string GenerateId(string name)
    {
      return name.Replace(".", HtmlHelper.IdAttributeDotReplacement);
    }

    /// <summary>
    /// Display the type of currency
    /// </summary>
    /// <param name="amount">Amount of money</param>
    /// <param name="pricingUnit">Type of pricing unit</param>
    /// <returns></returns>
    public static string FormatCurrency(decimal amount, int pricingUnit)
    {
      //if (pricingUnit == Common.Domain.PricingUnit.Codes.Percent)
      if (pricingUnit == 2)
      {
        return Math.Round(amount, 2).ToString() + "%";
      }
      else
      {
        if (amount == 0)
        {
          amount = decimal.Zero;
        }
        return "$" + Math.Round(amount, 2).ToString();
      }
    }

    /// <summary>
    /// Display the type currency
    /// </summary>
    /// <param name="amount">Amount of money</param>
    /// <returns></returns>
    public static string FormatCurrency(decimal amount)
    {
      //return FormatCurrency(amount, Common.Domain.PricingUnit.Codes.USD);
      return FormatCurrency(amount, 1);
    }

    /// <summary>
    /// Display the type currency
    /// </summary>
    /// <param name="amount">Amount of money</param>
    /// <returns></returns>
    public static string FormatCurrency(decimal? amount)
    {
      if (amount != null)
      {
        //return FormatCurrency(amount.Value, Common.Domain.PricingUnit.Codes.USD);
        return FormatCurrency(amount.Value,1);
      }
      else
      {
        return "";
      }
    }
    /// <summary>
    /// Display the currency for user to edit (ex: display in a textbox)
    /// </summary>
    /// <param name="html"></param>
    /// <param name="amount">Amount of money</param>
    /// <returns></returns>
    public static string FormatCurrencyForEditing(decimal amount)
    {
      return Math.Round(amount, 2).ToString();
    }

    /// <summary>
    /// Display the currency for user to edit (ex: display in a textbox)
    /// </summary>
    /// <param name="html"></param>
    /// <param name="amount">Amount of money</param>
    /// <returns></returns>
    public static string FormatCurrencyForEditing(decimal? amount)
    {
      if (amount == null)
      {
        return "";
      }
      return Math.Round(amount.Value, 2).ToString();
    }

    public static string FormatBoolValue(bool value)
    {
      return value ? "Yes" : "No";
    }

    public static String FormatBoolValue(Nullable<Boolean> value)
    {
      if (value.HasValue == false)
      {
        return "NOT SET";
      }
      else
      {
        return value.Value ? "Yes" : "No";
      }
    }

    public static String CreateStringFromNullableDateTime(System.Nullable<DateTime> dateTime)
    {
      if (dateTime == null)
      {
        return "";
      }
      else
      {
        return dateTime.ToString();
      }
    }

    public static String CreateDateStringFromNullableDateTime(System.Nullable<DateTime> dateTime)
    {
      if (dateTime.HasValue == false)
      {
        return "";
      }
      else
      {
        return dateTime.Value.ToString("MM/dd/yyyy");
      }
    }

    public static String CreateTimeStringFromNullableDateTime(System.Nullable<DateTime> dateTime)
    {
      if (dateTime.HasValue == false)
      {
        return "";
      }
      else
      {
        return dateTime.Value.ToShortTimeString();
      }
    }

    public static String CreateCheckBoxValueFromBooleanValue(bool value)
    {
      String result = "";

      if (value == true)
      {
        result = " checked='checked' ";
      }
      else
      {
        result = "";
      }

      return result;
    }

    public static String CreateCheckBoxFromBooleanValue(bool value, String name, String id)
    {
      String result = "";

      result += "<input type='checkbox' " + UIHelper.CreateCheckBoxValueFromBooleanValue(value) + " name='" + name + "' id='" + id + "'/>";

      return result;
    }

    public static String CreateCheckBoxFromBooleanValue(bool value, String name, String id, bool isDisable)
    {

      String sDisabled = isDisable == true ? "disabled='disabled'" : "";
      String result = "";

      result += "<input type='checkbox' " + UIHelper.CreateCheckBoxValueFromBooleanValue(value) + " name='" + name + "' id='" + id + "'" + sDisabled + "/>";

      return result;
    }
  }
}
