using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABDHFramework.Common;

namespace ABDHFramework.Lib.Pager
{
  public class WebPager<T>: BasePager<T>
  {
    public const string PageName = "__PAGE_NAME__";
    public const string PageValue = "__PAGE_VALUE__";

    /// <summary>
    /// pattern to render link
    /// </summary>
    protected String _linkPattern;
    public String LinkPattern { get { return _linkPattern; } set { _linkPattern = value; } }

    /// <summary>
    /// current link pattern
    /// </summary>
    private String _currentLinkPattern;
    public String CurrentLinkPattern { get { return _currentLinkPattern; } set { _currentLinkPattern = value; } }

    /// <summary>
    /// number link
    /// </summary>
    protected int _chunk = 5;
    public int Chunk { get { return _chunk; } set { _chunk = value; } }

    public WebPager(BasePager<T> pager)
      :base(pager)
    {
    }

    public List<string> GetLinks()
    {
      var ret = new List<String>();

      var before = (int)Math.Ceiling((double)(_chunk / 2));
      var after = _chunk - before;
      var startPage = Math.Max(1, _page - before);
      var endPage = Math.Min(GetLastPage(), _page + after);
      for (int i = startPage; i <= endPage; i++)
      {
        if (i == _page)
        {
          ret.Add(GetCurrentLink());
        }
        else
        {
          ret.Add(GetLink(i));
        }
      }

      return ret;
    }

    public string GetLink(int page)
    {
      return _linkPattern.Replace(PageValue, page.ToString());
    }

    public string GetCurrentLink()
    {
      return _currentLinkPattern.Replace(PageValue, _page.ToString());
    }
  }
}
