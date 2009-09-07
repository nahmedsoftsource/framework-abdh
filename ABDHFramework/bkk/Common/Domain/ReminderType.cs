using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class ReminderType : DomainTypeCode
  {
    private static IDictionary<int, ReminderType> _reminderTypes;

    public static IDictionary<int, ReminderType> ReminderTypes
    {
      get
      {
        if (_reminderTypes == null)
        {
          _reminderTypes = new Dictionary<int, ReminderType>();
        }
        return _reminderTypes;
      }
      set
      {
        _reminderTypes = value;
      }
    }    

    public struct REMINDER_TYPE
    {
      public const uint Order = 1;
      public const uint Credentialing = 2;
      public const uint Reimbursement = 3;
    }
  }
}
