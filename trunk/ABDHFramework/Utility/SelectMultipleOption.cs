using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Framework.Lib
{
  public class SelectMultipleOption
  {
    public SelectMultipleOption()
    {
      AddButtonID = "btnAdd";
      DelButtonID = "btnDel";
      SourceListID = "lstSource";
      DestinationListID = "lstDestination";
      HtmlAttributes = new
      {
        style = "width:150px",
        size = "8"
      };

    }
    public object HtmlAttributes { get; set; }
    public string AddButtonID { get; set; }
    public string DelButtonID { get; set; }
    public SelectList SourceList { get; set; }
    public SelectList DestinationList { get; set; }
    public string SourceListID { get; set; }
    public string DestinationListID { get; set; }
    public string SourceText { get; set; }
    public string DestinationText { get; set; }

  }
}
