using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Identifiers
{
  class DefaultIdGenerator<T>: IdGenerator<T>
  {
    public override T GenerateId()
    {
      return default(T);
    }
  }
}
