using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class EmployeeStatus : Common.DomainTypeCode
  {
    private bool _inactive;
    private static IDictionary<int, EmployeeStatus> _employeeStatuses;
    public static IDictionary<int, EmployeeStatus> EmployeeStatuses
    {
      get
      {
        if (_employeeStatuses == null)
        {
          _employeeStatuses = new Dictionary<int, EmployeeStatus>();
        }
        return EmployeeStatus._employeeStatuses;
      }
      set
      {
        _employeeStatuses= value;
      }
    }

    public bool Inactive
    {
      get
      {
        return _inactive;
      }
      set
      {
        _inactive = value;
      }
    }
  }
}

