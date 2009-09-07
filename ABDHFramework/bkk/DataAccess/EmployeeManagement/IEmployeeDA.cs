using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.MobileMedics.Domain.EmployeeManagement;
using Superior.MobileMedics.Common.DataAccess;
using Superior.Data;

namespace Superior.MobileMedics.DataAccess.EmployeeManagement
{
  public interface IEmployeeDA:IBaseDA<Guid,Employee>
  {
    SearchResult<Employee> SearchEmpByOrderInfo(DateTime? fromOrderDate,
                                                DateTime? toOrderDate, int statusID,
                                                uint searchBy, Guid? departmentID, int currPage
                                                );
    SearchResult<Employee> SearchEmpByOrderInfo(DateTime? fromOrderDate,
                                                DateTime? toOrderDate, List<Object> listOfStatusID,
                                                uint searchBy, Guid? departmentID, int currPage
                                                );
  }
}
