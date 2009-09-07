using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class SubmissionType : DomainTypeCode
  {
    private static IDictionary<int, SubmissionType> _SubmissionTypes;

    public static IDictionary<int, SubmissionType> SubmissionTypes
    {
      get
      {
        if (_SubmissionTypes == null)
        {
          _SubmissionTypes = new Dictionary<int, SubmissionType>();
        }
        return _SubmissionTypes;
      }
      set
      {
        _SubmissionTypes = value;
      }
    }
  }
}
