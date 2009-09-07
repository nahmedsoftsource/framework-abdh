using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Identifiers
{
  public abstract class IdGenerator<T>
  {
    public abstract T GenerateId();
  }
}
