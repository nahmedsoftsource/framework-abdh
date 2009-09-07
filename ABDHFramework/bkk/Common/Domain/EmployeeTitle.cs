using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class EmployeeTitle : DomainTypeCode
    {
    private static IDictionary<int, EmployeeTitle> _employeeTitles;
    public static IDictionary<int, EmployeeTitle> EmployeeTitles
      {
        get
        {
          if (_employeeTitles == null)
          {
            _employeeTitles = new Dictionary<int, EmployeeTitle>();
          }
          return EmployeeTitle._employeeTitles;
        }
        set
        {
          _employeeTitles = value;
        }
      }
    
    public struct EMPLOYEE_TITLE
    {
      public const int Case_Manager = 5;
    }
  }
}
