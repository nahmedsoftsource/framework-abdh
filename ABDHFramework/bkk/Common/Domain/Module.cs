﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Superior.MobileMedics.Common.Domain
{
  public class Module : DomainTypeCode
  {
    public IList<PermissionTypeGroup> PermissionTypeGroups { get; set; }
  }
}
