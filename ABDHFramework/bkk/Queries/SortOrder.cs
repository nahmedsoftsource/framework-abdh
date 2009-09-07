using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.Data.Queries
{
  public class SortOrder : ISortOrder
  {
    public SortOrder(string propertyName, bool isAscending)
    {
      PropertyName = propertyName;
      IsAscending = isAscending;
    }

    #region ISortOrder Members

    /// <summary>
    /// Gets or sets the name of the property.
    /// </summary>
    /// <value>The name of the property.</value>
    public string PropertyName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is ascending.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is ascending; otherwise, <c>false</c>.
    /// </value>
    public bool IsAscending { get; set; }

    #endregion
  }
}
