using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Identifiers
{
  class GuidIdGenerator: IdGenerator<Guid>
  {
    public override Guid GenerateId()
    {
      return Guid.NewGuid();
    }
  }
}
