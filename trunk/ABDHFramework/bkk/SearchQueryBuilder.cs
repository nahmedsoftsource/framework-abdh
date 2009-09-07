using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.Data
{
  public class SearchQueryBuilder
  {
    public static ISearchQuery CreateQuery()
    {
      return DataClientProvider.Instance.CreateQuery();
    }
  }
}
