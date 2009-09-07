using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Superior.MobileMedics.Common.Domain
{
  public class PermissionTypeGroup : DomainTypeCode
  {
    public int ModuleID { get; set; }

    public Module Module { get; set; }
  }
}
