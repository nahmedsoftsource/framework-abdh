using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class ReminderTime : DomainTypeCode
  {
    private static IDictionary<int, ReminderTime> _reminderTimes;

    public static IDictionary<int, ReminderTime> ReminderTimes
    {
      get
      {
        if (_reminderTimes == null)
        {
          _reminderTimes = new Dictionary<int, ReminderTime>();
        }
        return _reminderTimes;
      }
      set
      {
        _reminderTimes = value;
      }
    }
    public int Capability { get; set; }
  }
}
