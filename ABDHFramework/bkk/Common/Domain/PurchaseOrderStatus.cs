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
	/// PurChaseOrderStatus object for NHibernate mapped table 'PurchaseOrderStatus'.
	/// </summary>
	[Serializable]
  public class PurchaseOrderStatus : DomainTypeCode
	{
    private static IDictionary<int, PurchaseOrderStatus> _purchaseOrderStatuses;
    public static IDictionary<int, PurchaseOrderStatus> PurchaseOrderStatuses
    {
      get
      {
        if (_purchaseOrderStatuses == null)
        {
          _purchaseOrderStatuses = new Dictionary<int, PurchaseOrderStatus>();          
        }
        return _purchaseOrderStatuses;
      }

      set
      {
        _purchaseOrderStatuses = value;
      }
    }

    public static IDictionary<int, PurchaseOrderStatus> GetPurchaseOrderStatuses(int statusIndex, bool isExcluded)
    {
      IDictionary<int, PurchaseOrderStatus> _poStatuses;
      if (isExcluded)
        _poStatuses = _purchaseOrderStatuses.Values.Where(os => os.ID != statusIndex).ToDictionary(p => p.ID);
      else
        _poStatuses = _purchaseOrderStatuses.Values.Where(os => os.ID == statusIndex).ToDictionary(p => p.ID);
      return _poStatuses;
    }

    public static IDictionary<int, PurchaseOrderStatus> GetListPurchaseOrderStatuses(int statusIndex)
    {
      IDictionary<int, PurchaseOrderStatus> _poStatuses;
      _poStatuses = _purchaseOrderStatuses.Values.Where(os => os.ID >= statusIndex).ToDictionary(p => p.ID);
      return _poStatuses;
    }

    public static IDictionary<int, PurchaseOrderStatus> GetListPurchaseOrderStatuses(IList<int> lstStatusIndex)
    {
      IDictionary<int, PurchaseOrderStatus> _poStatuses = new Dictionary<int, PurchaseOrderStatus>();
      IDictionary<int, PurchaseOrderStatus> temp;
      for (int i = 0; i < lstStatusIndex.Count; i++)
      {
        temp = _purchaseOrderStatuses.Values.Where(os => os.ID == lstStatusIndex[i]).ToDictionary(p => p.ID);
        _poStatuses.Add(temp.Keys.First(), temp.Values.First());
      }
      return _poStatuses;
    }


    public struct PURCHASEORDER_STATUS_ID
    {
      public const int Canceled = 4;
      public const int Completed = 3;
      public const int Processing = 2;
      public const int New = 1;
    }

    public struct PURCHASEORDER_STATUS_NAME
    {
      public const string Completed = "Completed";
      public const string New = "New";
      public const string Processing = "Processing";
      public const string Canceled = "Canceled";
    }
	}
}
