using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using ABDHFramework.Lib.FluentHtml;
using System.Web.Mvc;

namespace ABDHFramework.Lib.Pager
{
  public class GridOption<T>
  {
    private String _htmlID;
    public String HtmlID { get { return _htmlID; } set { _htmlID = value; } }

    private String _url;
    public String URL { get { return _url; } set { _url = value; } }

    private String _defaultSortColumn;

    public String DefaultSortColumn
    {
      get { return _defaultSortColumn; }
      set { _defaultSortColumn = value; }
    }

    private String _defaultSortOption;

    public String DefaultSortOption
    {
      get { return _defaultSortOption; }
      set { _defaultSortOption = value; }
    }

    public HtmlStyle Style { get; set; }

    public Func<T, bool> OnRowPreferChecking { get; set; }

  }
}
