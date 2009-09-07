using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common
{
  public class EmailFactory
  {
    public static EmailProvider CreateEmailProvider()
    {
      return new EmailProvider();
    }
  }
}
