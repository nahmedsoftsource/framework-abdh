using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class OrderAssignmentStatus : Common.DomainTypeCode
  {
    public struct Status
    {
      public const int Scheduled = 69;
      public const int ReScheduled_app_date = 89;
      public const int ReScheduled_due_to_applicant = 90;
      public const int ReScheduled_due_to_Examiner_Interview = 91;
	  public const int Completed = 185;
      public const int Cancel = 184;
      public const int No_show_by_examiner = 63;

    }

    private String _notify;
    public String Notify
    {
      get
      {
        return _notify;
      }
      set
      {
        if (value == null)
        {
          _notify = "";
        }
        else
        {
          _notify = value;
        }
      }
    }

    public bool IsNoteRequired
    { get; set; }

    public bool IsNotifyOrderingParty { get; set; }
    public bool IsNotifySupervisor { get; set; }
    public bool IsScheduleRequired { get; set; }
    public bool IsServiceProviderInput { get; set; }

    public bool IsCompleted { get; set; }

    private static IDictionary<int, OrderAssignmentStatus> _orderAssignmentStatuses;
    public static IDictionary<int, OrderAssignmentStatus> OrderAssignmentStatuses
    {
      get
      {
        if (_orderAssignmentStatuses == null)
        {
          _orderAssignmentStatuses = new Dictionary<int, OrderAssignmentStatus>();
        }
        return _orderAssignmentStatuses;
      }
      set
      {
        _orderAssignmentStatuses = value;
      }
    }

    private static IDictionary<int, OrderAssignmentStatus> _spOrderAssignmentStatuses;
    public static IDictionary<int, OrderAssignmentStatus> SPOrderAssignmentStatuses
    {
      get
      {
        if (_spOrderAssignmentStatuses == null)
        {
          _spOrderAssignmentStatuses = new Dictionary<int, OrderAssignmentStatus>();
        }
        return _spOrderAssignmentStatuses;
      }
      set
      {
        _spOrderAssignmentStatuses = value;
      }
    }
  }
}
