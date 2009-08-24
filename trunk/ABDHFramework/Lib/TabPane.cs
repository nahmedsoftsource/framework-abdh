using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABDHFramework.Lib
{
  public class TabPane
  {
    public string ID { get; set; }
    public string Title { get; set; }
    public string ViewName { get; set; }
    public string Url { get; set; }
    public bool IsActive { get; set; }
    public object Model { get; set; }
    public bool Visible { get; set; }
    public Action RenderMethod { get; set; }
    public ViewDataDictionary ViewData { get; set; }
    public TabPane()
    {
      Visible = true;
    }
  }
}
