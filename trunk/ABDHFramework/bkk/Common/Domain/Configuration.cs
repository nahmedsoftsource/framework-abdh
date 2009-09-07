using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class Configuration: Common.DomainBase<int>
  {
    private string _value;
    private string _name;
    private string _description;

    /// <summary>
    /// set name propertise of configuration
    /// </summary>
    public string Name
    {
      get
      {
        return _name;
      }
      set
      {
        _name = value;
      }
    }

    /// <summary>
    /// set value properties of configuration
    /// </summary>
    public string Value
    {
      get
      {
        return _value;
      }
      set
      {
        _value = value;
      }
    }    

    /// <summary>
    /// set description propertise of configuration
    /// </summary>
    public string Description
    {
      get
      {
        return _description;
      }
      set
      {
        _description = value;
      }
    }
    public struct Codes
    {
      public const String AlertDateBeforeCredentialingExpiration = "AlertDateBeforeCredentialingExpiration";
      public const String SuppDept = "SupplyDeparment";
      public const String CustomerServiceRepresentative = "CustomerServiceRepresentative";
    }
  }
}
