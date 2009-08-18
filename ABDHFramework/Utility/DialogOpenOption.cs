using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABDHFramework.Data;
using System.Text;
using System.Web.UI.WebControls;
using ABDHFramework.Utility;
using ABDHFramework.Common;

namespace Framework.Lib
{
  /// <summary>
  /// contain options for open dialog
  /// </summary>
  public class DialogOpenOption
  {
    /// <summary>
    /// Gets or sets the ID of the dialog.
    /// </summary>
    /// <value>The ID.</value>
    public string ID { get; set; }

    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    /// <value>The title.</value>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the event handler for beforeClose event.
    /// </summary>
    /// <value>The before close.</value>
    public string BeforeClose { get; set; }

    /// <summary>
    /// Gets or sets the javascript when close.
    /// </summary>
    /// <value>The JS when close.</value>
    public string AfterClose { get; set; }

    /// <summary>
    /// Gets or sets the javascript before open.
    /// </summary>
    /// <value>The before open.</value>
    public string BeforeOpen { get; set; }

    /// <summary>
    /// Gets or sets the javascript after open.
    /// </summary>
    /// <value>The before open.</value>
    public string AfterOpen { get; set; }

    /// <summary>
    /// Gets or sets the URL, for compatibility.
    /// </summary>
    /// <value>The URL.</value>
    public String URL { get ; set ; }

    private String _reloadID;
    /// <summary>
    /// Gets or sets the html id to reload when dialog close
    /// </summary>
    /// <value>The reload ID.</value>
    public String ReloadID { get { return _reloadID; } set { _reloadID = value; } }

    private String _reloadURL;
    /// <summary>
    /// Gets or sets the url to reload when dialog close.
    /// </summary>
    /// <value>The reload URL.</value>
    public String ReloadURL { get { return _reloadURL; } set { _reloadURL = value; } }

    /// <summary>
    ///   Open this in a popup window
    /// </summary>
    public bool IsPopup { get; set; }

    public RemoteOption RemoteOptions { get; set; }

    public DataDictionary BindEvents { get; set; }

    public Unit Width { get; set; }
    public Unit Height { get; set; }

    public DialogOpenOption()
    {
      Title = "Form";
      BeforeOpen = "undefined";
      AfterOpen = "undefined";
      BeforeClose = "undefined";
      AfterClose = "undefined";
      RemoteOptions = new RemoteOption { Method = "GET" };
    }

    public string ToJSon()
    {
      // for compatibility
      if (String.IsNullOrEmpty(RemoteOptions.URL))
      {
        RemoteOptions.URL = URL;
      }
      // TODO: clean up the string before serialized
      StringBuilder json = new StringBuilder();
      json.AppendFormat(
        "{{\"id\": \"{0}\", \"title\": \"{1}\", \"beforeOpen\": {2}, \"afterOpen\": {3}, \"beforeClose\": {4}, \"afterClose\": {5}, \"reloadId\": \"{6}\", \"reloadUrl\": {7}, \"remoteOptions\": {8}, \"isPopup\": {9} ",
        ID, Title, BeforeOpen, AfterOpen, BeforeClose, AfterClose, ReloadID, Json.Encode(ReloadURL), RemoteOptions.ToJSON(), Json.Encode(IsPopup)
        );

      if (BindEvents != null && BindEvents.Count > 0)
      {
        json.Append(",");
        json.Append(Json.Encode("bindEvents"));
        json.Append(":{");
        foreach (var item in BindEvents)
        {
          json.Append(Json.Encode(item.Key));
          json.Append(":");
          json.Append(item.Value);
          json.Append(",");
        }
        json.Remove(json.Length - 1, 1);
        json.Append("}");
      }
      if (Width != Unit.Empty)
      {
        json.Append(",");
        json.Append(Json.Encode("width"));
        json.Append(":");
        json.Append(Json.Encode(Width.ToString()));
      }
      if (Height != Unit.Empty)
      {
        json.Append(",");
        json.Append(Json.Encode("height"));
        json.Append(":");
        json.Append(Json.Encode(Height.ToString()));
      }

      json.Append("}");
      return json.ToString();
    }
  }
}
