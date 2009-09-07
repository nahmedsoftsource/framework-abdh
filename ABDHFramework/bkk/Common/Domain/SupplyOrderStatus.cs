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
    /// SupplyOrderStatus object for NHibernate mapped table 'PurChaseOrderStatus'.
    /// </summary>
    [Serializable]
    public class SupplyOrderStatus : DomainTypeCode
    {
        private static IDictionary<int, SupplyOrderStatus> _orderStatuses;
        public static IDictionary<int, SupplyOrderStatus> OrderStatuses
        {
            get
            {
                if (_orderStatuses == null)
                {
                    _orderStatuses = new Dictionary<int, SupplyOrderStatus>();
                }
                return _orderStatuses;
            }

            set
            {
                _orderStatuses = value;
            }
        }

        public struct Codes
        {
          public const int New = 1;
          public const int Processing = 2;
          public const int Completed = 4;
          public const int Canceled = 5;
        }
        
        //#region Member Variables

        ////protected int _supplyOrderStatusID;
        ////private string _name;
        //private IList _statusSupplyOrders;

        //#endregion

        //#region Constructors

        //public SupplyOrderStatus() { }

        //#endregion

        //#region Public Properties

        ////public int SupplyOrderStatusID
        ////{
        ////        get { return _supplyOrderStatusID; }
        ////        set { _supplyOrderStatusID = value; }
        ////}

        ////public string Name
        ////{
        ////  get { return _name; }
        ////  set { _name = value; }
        ////}

        //public IList StatusSupplyOrders
        //{
        //  get
        //  {
        //    if (_statusPurchaseOrders==null)
        //    {
        //      _statusPurchaseOrders = new ArrayList();
        //    }
        //    return _statusPurchaseOrders;
        //  }
        //  set { _statusPurchaseOrders = value; }
        //}

        //#endregion



    }

}
