using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.MobileMedics.Common;
using Superior.MobileMedics.Common.Domain;

namespace Superior.MobileMedics.Domain.EmployeeManagement
{
  public class Employee:DomainBase<Guid>
  {
    #region Member Variables
    protected Department _department;
    private System.Guid _personID;
    private PartyManagement.Person _person;
    private bool _isSupervisor;
    private System.Nullable<System.Guid> _supervisorID;
    protected EmployeeStatus _employeeStatus;
    protected EmployeeTitle _employeeTitle;
    #endregion

    #region Constructors
    public Employee()
    {
      base.ID = Guid.Empty;
      _personID = Guid.Empty;
      _person = new PartyManagement.Person();
    }
    #endregion

    #region Public Properties
    public string FullName
    {
      get
      {
        if(Person.MiddleName.Trim().Length>0)
          return Person.FirstName.Trim() + " " + Person.MiddleName.Trim() + " " + Person.LastName.Trim();
        else
          return Person.FirstName.Trim() + " " + Person.LastName.Trim();
      }
    }

    public System.Guid PersonID
    {
      get
      {
        return _personID;
      }
      set
      {
        _personID = value;
      }
    }

    public PartyManagement.Person Person
    {
      get
      {
        if (_person == null)
        {
          _person = new Domain.PartyManagement.Person();
        }
        return _person;
      }
      set
      {
        _person = value;
      }
    }

    public bool IsSupervisor
    {
      get
      {
        return _isSupervisor;
      }
      set
      {
        _isSupervisor = value;
      }
    }

    public System.Nullable<System.Guid> SupervisorID
    {
      get
      {
        return _supervisorID;
      }
      set
      {
        _supervisorID = value;
      }
    }

    public EmployeeStatus EmployeeStatus
    {
      get { return _employeeStatus; }
      set { _employeeStatus = value; }
    }

    public EmployeeTitle EmployeeTitle
    {
      get { return _employeeTitle; }
      set { _employeeTitle = value; }
    }

    public Department Department
    {
      get { return _department; }
      set { _department = value; }
    }
    #endregion
  }
}
