using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.MobileMedics.Common;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using Superior.MobileMedics.Domain.PartyManagement;

namespace Superior.MobileMedics.Domain.EmployeeManagement
{
  /// <summary>
  /// Group object for NHibernate mapped table 'Group'.
  /// </summary>
  public class Group : Common.DomainBase<Guid>
  {
    #region Member Variables
    protected string _name;
    protected string _description;
    protected IList _groupUsers;
    protected Guid? _ownerID;
    #endregion

    #region Constructors
    public Group() { }

    public Group(string name, string description)
    {
      this._name = name;
      this._description = description;
    }
    #endregion

    #region Public Properties

    [Required(ErrorMessage = " ")]
    [StringLength(100)]
    public string Name
    {
      get { return _name; }
      set
      {
        _name = value;
      }
    }

    [StringLength(255)]
    public string Description
    {
      get { return _description; }
      set
      {
        _description = value;
      }
    }

    public Guid? OwnerID
    {
      get { return _ownerID; }
      set 
      {
        _ownerID = value;
      }
    }

    public IList GroupUsers
    {
      get
      {
        if (_groupUsers == null)
        {
          _groupUsers = new ArrayList();
        }
        return _groupUsers;
      }
      set { _groupUsers = value; }
    }

    #endregion

    public void AddUser(PartyManagement.Party party)
    {
      if (_groupUsers == null)
        _groupUsers = new List<PartyManagement.Party>();
      if(!_groupUsers.Contains(party))
        _groupUsers.Add(party);
    }

    public void RemoveUser(PartyManagement.Party party)
    {
      _groupUsers.Remove(party);
    }

    public IList PersonListForJson()
    {
      for (int i = 0; i < GroupUsers.Count; i++)
      {
        if (GroupUsers[i].GetType() == typeof(Person))
        {
          ((Person)GroupUsers[i]).Groups = null;
          ((Person)GroupUsers[i]).User = null;
        }
      }
      return GroupUsers;
    }
  }
}
