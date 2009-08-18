using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABDHFramework.Lib
{
  /// <summary>
  /// options for dialog submit button
  /// </summary>
  public class DialogSubmitOption
  {
    // button name
    private String _name = "Save";
    public String Name { get { return _name; } set { _name = value; } }

    /// <summary>
    /// one and only data
    /// </summary>
    public String Data
    { get; set; }

    public String ID
    { get; set; }

    // url
    private String _url;
    public String URL { get { return _url; } set { _url = value; } }

    // confirm message
    private String _confirmMessage;
    public String ConfirmMessage { get { return _confirmMessage; } set { _confirmMessage = value; } }

    // callBefore function (using to validate form using javascript).
    // if this function return true, the form will be submitted and vice versa
    private String _callBefore;
    public String CallBefore { get { return _callBefore; } set { _callBefore = value; } }

    public bool CausesValidation { get; set; }

    public DialogSubmitOption()
    {
      CausesValidation = true;
    }
  }
}
