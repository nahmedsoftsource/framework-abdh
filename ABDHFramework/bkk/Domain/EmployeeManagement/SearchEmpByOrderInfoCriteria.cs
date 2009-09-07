using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.Data;

namespace Superior.MobileMedics.Domain.EmployeeManagement
{
  public class SearchEmpByOrderInfoCriteria : SearchCriteria
  {
    public static uint SEARCH_BY_CASE_MANAGER = 1;
    public static uint SEARCH_BY_ORDER_REP = 2;

    public DateTime FromOrderDate { get; set; }
    public DateTime ToOrderDate { get; set; }
    public int OrderStatus { get; set; }
    public List<Object> ListOfOrderStatus { get; set; }
    /*Search by Case Manager or Order Rep*/
    public uint SearchBy { get;set;}
    public Guid DepartmentID { get; set; }
  }
}
