using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.ComponentModel;
using System.Web.UI.WebControls;
using ABDHFramework.Lib.FluentHtml;

namespace ABDHFramework.Lib.FluentHtml
{
  public class HtmlStyle: HtmlStyleBase<HtmlStyle>
  {
    public static readonly HtmlStyle Empty = new HtmlStyle();

    public HtmlStyle() { }
    public HtmlStyle(string styles) : base(styles) { }
  }
}
