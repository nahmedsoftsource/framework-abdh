using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Superior.MobileMedics.Common.Domain
{
  public class ObjectType : Common.DomainTypeCode
  {

    #region Member Variables

    private static IDictionary<int, ObjectType> _objectTypes;

    public static IDictionary<int, ObjectType> ObjectTypes
    {
      get
      {
        if (_objectTypes == null)
        {
          _objectTypes = new Dictionary<int, ObjectType>();
        }
        return _objectTypes;
      }
      set
      {
        _objectTypes = value;
      }
    }

    #endregion

    #region Constructors

    public ObjectType() { }

    #endregion

    #region Public Properties


    public struct Codes
    {
      public const uint Unknown = 0;
      public const uint Insurance = 1;
      public const uint ServiceProvider = 2;
      public const uint OrderingParty = 3;
      public const uint Order = 4;
      public const uint BillingCompany = 5;
      public const uint Employee = 6;
      public const uint Partner = 7;
      public const uint Payment = 8;
      public const uint Supplier = 9;
      public const uint MedicalItem = 10;
      public const uint SupplyOrder = 11;
      public const uint SaleOrder = 12;
      public const uint PurchaseOrder = 13;
      public const uint Agency = 14;
    }

    #endregion

  }
}
