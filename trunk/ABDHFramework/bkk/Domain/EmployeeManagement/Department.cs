using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.MobileMedics.Common;

namespace Superior.MobileMedics.Domain.EmployeeManagement
{
  public class Department:DomainBase<Guid>
  {
    #region Member Variables
    protected string _name;
    protected string _description;
    #endregion

    #region Constructors
    public Department() { }
    public Department(string name)
    {
      this._name = name;
    }
    #endregion

    #region Public Properties
    public string Name
    {
      get { return _name; }
      set
      {
        _name = value;
      }
    }
    public string Description
    {
      get { return _description; }
      set
      {
        _description = value;
      }
    }
    #endregion
  }
}
