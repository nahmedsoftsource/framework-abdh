using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Superior.MobileMedics.Common.Domain
{
  public class EmailStatus : Common.DomainBase<int>
  {
    #region Member Variables

    protected string _name;
    protected string _description;
    private static IDictionary<int, EmailStatus> _emailStatus;

    #endregion

    #region Constructors

    public EmailStatus() { }

    #endregion

    #region Public Properties

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public string Description
    {
      get { return _description; }
      set { _description = value; }
    }

    public static IDictionary<int, EmailStatus> EmailStatuses
    {
      get
      {
        if (_emailStatus == null)
        {
          _emailStatus = new Dictionary<int, EmailStatus>();
        }
        return _emailStatus;
      }
      set
      {
        _emailStatus = value;
      }
    }

    public struct Codes
    {
      public const int New = 1;
      public const int Sent = 2;
      public const int Error = -1;
    }

    #endregion
  }
}
