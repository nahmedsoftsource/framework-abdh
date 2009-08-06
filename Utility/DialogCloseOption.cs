using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NguyenHiep.Utility
{
  /// <summary>
  /// contain options for closing dialog
  /// </summary>
  public class DialogCloseOption
  {
    // close dialog
    private Boolean _close;
    public Boolean Close { get { return _close; } set { _close = value; } }

    // message
    private String _message;
    public String Message { get { return _message; } set { _message = value; } }

    /// <summary>
    ///   The event when the button is clicked
    /// </summary>
    public string EventName { get; set; }

    /// <summary>
    ///   The event data when the button is clicked
    /// </summary>
    public object EventData { get; set; }

    // ReloadID
    private String _reloadID;
    public String ReloadID { get { return _reloadID; } set { _reloadID = value; } }

    // ReloadURL
    private String _reloadURL;
    public String ReloadURL { get { return _reloadURL; } set { _reloadURL = value; } }

    // RunJS
    private String _runJS;
    public String RunJS { get { return _runJS; } set { _runJS = value; } }

    // Data
    private Object _data;
    public Object Data { get { return _data; } set { _data = value; } }

    // RedirectURL
    private string _redirectURL;
    public string RedirectURL
    {
      get
      {
        return _redirectURL;
      }
      set
      {
        _redirectURL = value;
      }
    }

  }
}
