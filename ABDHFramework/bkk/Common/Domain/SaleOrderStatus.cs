using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.MobileMedics.Common;
using Superior.MobileMedics.Common.Domain;

namespace Superior.MobileMedics.Common.Domain
{
  /// <summary>
  /// PurChaseOrderStatus object for NHibernate mapped table 'SaleOrderStatus'.
  /// </summary>
  [Serializable]
  public class SaleOrderStatus : DomainTypeCode
  {
    private static IDictionary<int, SaleOrderStatus> _saleOrderStatuses;
    public static IDictionary<int, SaleOrderStatus> SaleOrderStatuses
    {
      get
      {
        if (_saleOrderStatuses == null)
        {
          _saleOrderStatuses = new Dictionary<int, SaleOrderStatus>();
        }
        return _saleOrderStatuses;
      }

      set
      {
        _saleOrderStatuses = value;
      }
    }


    public static IDictionary<int, SaleOrderStatus> GetSalesOrderStatuses(int statusIndex, bool isExcluded)
    {
      IDictionary<int, SaleOrderStatus> _soStatuses;
      if (isExcluded)
        _soStatuses = _saleOrderStatuses.Values.Where(os => os.ID != statusIndex).ToDictionary(p => p.ID);
      else
        _soStatuses = _saleOrderStatuses.Values.Where(os => os.ID == statusIndex).ToDictionary(p => p.ID);
      return _soStatuses;
    }

    public static IDictionary<int, SaleOrderStatus> GetListSalesOrderStatuses(int statusIndex)
    {
      IDictionary<int, SaleOrderStatus> _soStatuses;
      _soStatuses = _saleOrderStatuses.Values.Where(os => os.ID >= statusIndex).ToDictionary(p => p.ID);
      return _soStatuses;
    }

    public static IDictionary<int, SaleOrderStatus> GetListSalesOrderStatuses(IList<int> lstStatusIndex)
    {
      IDictionary<int, SaleOrderStatus> _soStatuses = new Dictionary<int, SaleOrderStatus>();
      IDictionary<int, SaleOrderStatus> temp;
      for (int i = 0; i < lstStatusIndex.Count; i++)
      {
        temp = _saleOrderStatuses.Values.Where(os => os.ID == lstStatusIndex[i]).ToDictionary(p => p.ID);
        _soStatuses.Add(temp.Keys.First(),temp.Values.First());
      }
      return _soStatuses;
    }

    public struct SALES_STATUS_ID
    {
      public const int New = 1;
      //public const int Pending = 2;
      public const int Shipping = 2;
      //public const int OnGoing = 3;
      public const int Completed = 3;
      //public const int Completed = 4;
      public const int Canceled = 4;
      //public const int Canceled = 5;
      //public const int Shipping = 6;
    }

    public struct SALES_STATUS_NAME
    {
      public const string Completed = "Completed";
      public const string New = "New";
      //public const string Pending = "Pending";
      //public const string Pending = "Pending";
      //public const string OnGoing = "On-going";
      public const string Canceled = "Canceled";
      public const string Shipping = "Shipping";
    }
  }

}
