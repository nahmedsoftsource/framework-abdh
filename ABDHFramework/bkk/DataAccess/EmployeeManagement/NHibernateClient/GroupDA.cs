using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.MobileMedics.DataAccess.EmployeeManagement;
using Superior.MobileMedics.Common.DataAccess.NHibernateClient;
using Superior.MobileMedics.Domain.EmployeeManagement;

namespace Superior.MobileMedics.DataAccess.EmployeeManagement.NHibernateClient
{
  public class GroupDA:BaseDA<Guid,Group>,IGroupDA
  {
  }
}
