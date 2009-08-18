using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABDHFramework.Common;

namespace ABDHFramework.Utility.Javascripts
{
  public class AutoCompleteDataItem
  {
    private String _html;
    /// <summary>
    /// content will display in list
    /// </summary>
    public String Html { get { return _html; } set { _html = value; } }

    private String _text;
    /// <summary>
    /// content will be select
    /// </summary>
    public String Text { get { return _text; } set { _text = value; } }

    private Object _data;
    /// <summary>
    /// other data which you want to send to client
    /// </summary>
    public Object Data { get { return _data; } set { _data = value; } }

    /// <summary>
    /// to json
    /// </summary>
    /// <returns></returns>
    public String ToJSON()
    {
      return Json.Encode(new { html = _html, text = _text, data = _data });
    }
  }
}
