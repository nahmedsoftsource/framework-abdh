using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NguyenHiep.Common;

namespace NguyenHiep.Utility
{
  public class RemoteOption
  {
    private String _url;
    /// <summary>
    /// url used to send data
    /// </summary>
    public String URL { get { return _url; } set { _url = value; } }

    private String _update;
    /// <summary>
    /// htmlID will be updated
    /// </summary>
    public String Update { get { return _update; } set { _update = value; } }

    private String _method;
    /// <summary>
    /// method to send data: default is POST
    /// </summary>
    public String Method { get { return _method; } set { _method = value; } }

    private Boolean _isForm = true;
    /// <summary>
    /// is form: default is false. If it is true, form fields will be serialized and send
    /// </summary>
    public Boolean IsForm { get { return _isForm; } set { _isForm = value; } }
    public Boolean CausesValidation { get; set; }

    private Object _data;
    /// <summary>
    /// addition data. Ex: new {key1 = value1, key2 = value2}. 
    /// </summary>
    public Object Data { get { return _data; } set { _data = value; } }

    private IDictionary<string, object> _dataDictionary;
    /// <summary>
    /// Gets the data dictionary. To be implemented
    /// </summary>
    /// <value>The data dictionary.</value>
    public IDictionary<string, object> DataDictionary
    {
      get
      {
        if (_dataDictionary == null)
        {
          _dataDictionary = new Dictionary<string, object>();
        }
        return _dataDictionary;
      }
      set
      {
        _dataDictionary = value;
      }
    }

    private String[] _with;
    /// <summary>
    /// html id value will be send
    /// </summary>
    public String[] With { get { return _with; } set { _with = value; } }

    public String OnSuccess { get; set; }

    public RemoteOption()
    {
      Method = "POST";
      IsForm = false;
      OnSuccess = "";
      CausesValidation = true;
    }

    /// <summary>
    /// to json
    /// </summary>
    /// <returns></returns>
    public String ToJSON()
    {
      return Json.Encode(new
      {
        url = _url,
        update = _update,
        method = _method,
        isForm = _isForm,
        data = _data,
        with = _with,
        causesValidation = CausesValidation,
      });
    }
    /// <summary>
    /// Call before submit
    /// </summary>
    private String _callBefore;
    public String CallBefore { get { return _callBefore; } set { _callBefore = value; } }
  }
}
