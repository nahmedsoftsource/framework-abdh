using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABDHFramework.Common;

namespace ABDHFramework.Utility.Javascripts
{
  public class AutoCompleteOption
  {
    private String _url;
    public String URL { get { return _url; } set { _url = value; } }

    private int _minChars = 1;
    /// <summary>
    /// The minimum number of characters a user has to type before the autocompleter activates.
    /// </summary>
    public int MinChars { get { return _minChars; } set { _minChars = value; } }

    private String _result;
    /// <summary>
    /// result command (for quick update): function(event, data, formatted)
    /// </summary>
    public String Result { get { return _result; } set { _result = value; } }

    private String _resultFunc;
    /// <summary>
    /// result method: function(event, data, formatted)
    /// </summary>
    public String ResultFunc { get { return _resultFunc; } set { _resultFunc = value; } }

    private String[] _with;
    /// <summary>
    /// html id value will be send
    /// </summary>
    public String[] With { get { return _with; } set { _with = value; } }

    /// <summary>
    /// to json
    /// </summary>
    /// <returns></returns>
    public String ToJSON()
    {
      return Json.Encode(new { minChars = _minChars, formatItem = "Core.formatSuggestItem", formatResult = "Core.formatSuggestResult", with = _with });
    }
  }
}
