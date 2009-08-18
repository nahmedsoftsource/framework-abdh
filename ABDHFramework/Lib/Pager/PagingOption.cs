using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABDHFramework.Data;

namespace ABDHFramework.Lib.Pager
{
  public class PagingOption
  {
    /// <summary>
    /// Gets or sets the current page.
    /// </summary>
    /// <value>The current page.</value>
    public int CurrentPage { get; set; }

    /// <summary>
    /// Gets or sets the total rows.
    /// </summary>
    /// <value>The total rows.</value>
    public int TotalRows { get; set; }

    /// <summary>
    /// Gets or sets the size of page
    /// </summary>
    /// <value>The size of page</value>
    public int PageSize { get; set; }

    /// <summary>
    /// Gets or sets the URL maker. 
    /// For example: 
    ///   UrlMaker = ((currentPage) => String.Format("/List?ID={0}", currentPage))
    ///   UrlMaker = ((currentPage) => Routing.AgencyInsurance.UrlFor(agencyID, currentPage))
    /// </summary>
    /// <value>The URL maker.</value>
    public Func<int, string> UrlMaker { get; set; }

    public bool ShowIfEmpty { get; set; }
    public PagingStatOptions PagingStatOption { get; set; }

    public enum PagingStatOptions
    {
      AbovePager,
      BelowPager,
      None
    }

    public PagingOption()
    {
      PagingStatOption = PagingStatOptions.None;
    }
  }
}
