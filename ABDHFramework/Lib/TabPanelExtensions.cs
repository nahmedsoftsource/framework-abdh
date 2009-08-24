using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ABDHFramework.Lib
{
  public static class TabPanelExtensions
  {
    static public void RenderTabPanel(this HtmlHelper html, string id, IEnumerable<TabPane> tabs)
    {
      html.ViewContext.HttpContext.Response.Write("<div id='" + id + "'><ul>");
      int iSetIndex = 0, iIndex = 0;
      foreach (TabPane tab in tabs)
      {
        if (tab.Visible)
        {
          if (String.IsNullOrEmpty(tab.Url))
          {
            html.ViewContext.HttpContext.Response.Write("<li><a href='#" + tab.ID + "'><span>" + tab.Title.ToString() + "</span></a></li>");
          }
          else
          {
            html.ViewContext.HttpContext.Response.Write("<li><a name='" + tab.ID + "' href='" + tab.Url + "'><span>" + tab.Title.ToString() + "</span></a></li>");
          }
          if (tab.IsActive)
            iIndex = iSetIndex;
          iSetIndex++;
        }

      }
      html.ViewContext.HttpContext.Response.Write("</ul>");
      foreach (TabPane tab in tabs)
      {
        if (tab.Visible)
        {
          html.ViewContext.HttpContext.Response.Write("<div id='" + tab.ID + "'>");
          if (tab.RenderMethod != null)
          {
            tab.RenderMethod();
          }
          else if (String.IsNullOrEmpty(tab.Url) && !String.IsNullOrEmpty(tab.ViewName))
          {
            html.RenderPartial(tab.ViewName, tab.Model, tab.ViewData);
          }
          html.ViewContext.HttpContext.Response.Write("</div>");
        }
      }
      html.ViewContext.HttpContext.Response.Write("</div>");
      html.ViewContext.HttpContext.Response.Write(UIHelper.JavascriptTag("$(document).ready(function(){$('#" + id + "').tabs({selected:" + iIndex.ToString() + ", collabsible:true, cache: true, spinner:''});});"));
    }

    /// <summary>
    ///   For testing only
    /// </summary>
    /// <param name="html"></param>
    /// <param name="id"></param>
    /// <param name="tabs"></param>
    static public void RenderTabControl(this HtmlHelper html, string id, IEnumerable<TabPane> tabs)
    {
      String beginTab = String.Format("<!-- begin tab -->\n" +
"      <div class=\"x-tab-panel\" id=\"{0}\">\n" +
"        <div class=\"x-tab-panel-header x-unselectable x-tab-panel-header-plain\">\n" +
"          <div class=\"x-tab-strip-wrap\">\n" +
"            <!-- begin child tabs -->\n" +
"            <ul class=\"x-tab-strip x-tab-strip-top\">", id);

      String endTabPanel = "<li class=\"x-tab-edge\" ></li>" +
"              <div class=\"x-clear\" ></div>" +
"            </ul>\n" +
"            <!-- end child tabs -->\n" +
"          </div>\n" +
"          <div class=\"x-tab-strip-spacer\"></div>\n" +
"        </div>\n" +
"      <!-- end tab panel -->";

      String beginTabContent = "<div class=\"x-tab-panel-bwrap\">\n" +
"          <div class=\"x-tab-panel-body x-tab-panel-body-top\">";
      String endTabContent = "          </div>\n" +
"        </div></div>";

      String beginTabItem = "<div class=\"x-panel x-panel-noborder {0}\" id=\"{1}\">\n" +
"              <div class=\"x-panel-bwrap\">\n" +
"                <div class=\"x-panel-body x-panel-body-noheader x-panel-body-noborder\">";
      String endTabItem = "</div></div></div>";

      html.ViewContext.HttpContext.Response.Write(UIHelper.JavascriptTag("$(document).ready(function(){Core.Tabs('#" + id + "');});"));
      html.ViewContext.HttpContext.Response.Write(beginTab);
      foreach (TabPane tab in tabs)
      {
        String activeClass = tab.IsActive ? "x-tab-strip-active" : "x-tab-strip";
        html.ViewContext.HttpContext.Response.Write(String.Format("<li class=\"{2}\" id=\"{0}\"><a onclick=\"return false;\" class=\"x-tab-strip-close\"/><a onclick=\"return false;\" href=\"#\" class=\"x-tab-right\"><em class=\"x-tab-left\"><span class=\"x-tab-strip-inner\"><span class=\"x-tab-strip-text\">{1}</span></span></em></a></li>", tab.ID, tab.Title, activeClass));
      }

      html.ViewContext.HttpContext.Response.Write(beginTabContent);
      foreach (TabPane tab in tabs)
      {
        String activeTabContent = tab.IsActive ? "x-tab-panel-active" : "x-tab-panel-inactive";
        html.ViewContext.HttpContext.Response.Write(String.Format(beginTabItem, activeTabContent, tab.ID + "_TabContent"));
        html.RenderPartial(tab.ViewName, tab.Model);
        html.ViewContext.HttpContext.Response.Write(endTabItem);
      }
      html.ViewContext.HttpContext.Response.Write(endTabContent);
      html.ViewContext.HttpContext.Response.Write(endTabPanel);
    }
  }
}
