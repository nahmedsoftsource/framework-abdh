using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABDHFramework.Lib.FluentHtml
{
  public class TextElement: IElement
  {
    private string _innerText;
    #region IElement Members

    public System.Web.Mvc.TagBuilder Builder
    {
      get { return null; }
    }

    public void SetAttr(string name, object value){ }

    public string GetAttr(string name)
    {
      return String.Empty;
    }

    public HtmlStyle Style()
    {
      return HtmlStyle.Empty;
    }

    public TextElement InnerText(string text)
    {
      _innerText = text;
      return this;
    }

    public override string ToString()
    {
      return _innerText;
    }
    #endregion
  }
}
