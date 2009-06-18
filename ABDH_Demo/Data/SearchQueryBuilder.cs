using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABDH_Demo.Data
{
  public class SearchQueryBuilder
  {
    public static ISearchQuery CreateQuery()
    {
      return DataClientProvider.Instance.CreateQuery();
    }
  }
}
