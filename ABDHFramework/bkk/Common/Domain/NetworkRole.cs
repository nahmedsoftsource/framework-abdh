using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Superior.MobileMedics.Common.Domain
{
  public class NetworkRole: DomainTypeCode
  {
    private static IDictionary<int, NetworkRole> _networkRoles;
    public static IDictionary<int, NetworkRole> NetworkRoles
    {
      get
      {
        if (_networkRoles == null)
        {
          _networkRoles = new Dictionary<int, NetworkRole>();
        }
        return _networkRoles;
      }
      set
      {
        _networkRoles = value;
      }
    }

    public const int Unknown = 1;
    public const int Group = 2;
    public const int GroupContact = 3;
    public const int GroupMember = 4;
    public const int Other = 5;
  }
}
