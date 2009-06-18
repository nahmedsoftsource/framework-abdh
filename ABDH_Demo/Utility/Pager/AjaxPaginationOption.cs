using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABDH_Demo.Utility.Pager
{
  public class AjaxPaginationOption
  {
    private String _htmlID;
    public String HtmlID { get { return _htmlID; } set { _htmlID = value; } }

    private String _url;
    public String URL { get { return _url; } set { _url = value; } }

    private Object _data;
    public Object Data { get { return _data; } set { _data = value; } }

    /// <summary>
    /// auto load parameter (GET, POST) and put into data
    /// </summary>
    private Boolean _autoLoadParam = true;
    public Boolean AutoLoadParam { get { return _autoLoadParam; } set { _autoLoadParam = value; } }

    /// <summary>
    /// auto load html id from request
    /// </summary>
    private Boolean _autoLoadHtmlID = true;
    public Boolean AutoLoadHtmlID { get { return _autoLoadHtmlID; } set { _autoLoadHtmlID = value; } }

    public RemoteOption RemoteOptions { get; set; }
  }
}
