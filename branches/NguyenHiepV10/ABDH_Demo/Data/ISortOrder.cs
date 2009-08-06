using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABDH_Demo.Data
{
  public interface ISortOrder
  {
    /// <summary>
    /// Gets or sets the name of the property.
    /// </summary>
    /// <value>The name of the property.</value>
    string PropertyName { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether this instance is ascending.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is ascending; otherwise, <c>false</c>.
    /// </value>
    bool IsAscending { get; set; }
  }
}
