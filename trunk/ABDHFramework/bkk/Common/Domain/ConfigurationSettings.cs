using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.MobileMedics.Common.Configuration;

namespace Superior.MobileMedics.Common.Domain
{
  /// <summary>
  /// use this class to get all configurations
  /// </summary>
  public static class ConfigurationSettings
  {

    #region Const for Prefix Orders
    public const string SaleOrderPrefixName = "SO";
    public const string PurchaseOrderPrefixName = "PO";
    #endregion
    /// <summary>
    /// all propertises of configuration
    /// </summary>
    private static IDictionary<string, Configuration> _configuration;
    public static IDictionary<string, Configuration> Configuration
    {
      get
      {
        return _configuration;
      }
      set
      {
        _configuration = value;
      }
    }

    private static string GetValue(string name)
    {
      if (!_configuration.ContainsKey(name))
      {
        throw new InvalidOperationException(
          String.Format("Cannot find the configuration entry for {0}. Please check the database version.", name));
      }
      return _configuration[name].Value;
    }

    public static void Refresh()
    {
      _adminEmail = null;
      _alertDateBeforeCredentialingExpiration = -1;
      _defaultPageSize = null;
      _expiredDaysForInvoice = -1;
      _orderAssignmentPageSize = null;
      _smmFaxToInstruction = null;
      _smmMailToInstruction = null;
      _orderStatusHistoryPageSize = null;
      _orderAssignmentPageSize = null;
      _expiredDaysForInvoice = -1;
      _supplyDepartment = null;
    }

    private static string _smmMailToInstruction;
    public static string SmmMailToInstruction
    {
      get
      {
        if (_smmFaxToInstruction == null)
        {
          _smmMailToInstruction = GetValue("SmmMailToInstruction");
        }
        return _smmMailToInstruction;
      }
      set
      {
        _smmMailToInstruction = value;
      }
    }

    private static int? _defaultPageSize;
    public static int DefaultPageSize
    {
      get
      {
        int pageSize;
        if (!_defaultPageSize.HasValue)
        {
          if (int.TryParse(GetValue("DefaultPageSize"), out pageSize))
          {
            _defaultPageSize = pageSize;
          }
          else
          {
            _defaultPageSize = 20;
          }
        }
        return _defaultPageSize.Value;
      }
      set
      {
        _defaultPageSize = value;
      }
    }

    private static int? _roundNumber;
    public static int RoundNumber
    {
      get
      {
        int roundNumber;
        if (!_roundNumber.HasValue)
        {
          if (int.TryParse(GetValue("RoundNumber"), out roundNumber))
          {
            _roundNumber = roundNumber;
          }
          else
          {
            _roundNumber = 2;
          }
        }
        return _roundNumber.Value;
      }
      set
      {
        _roundNumber = value;
      }
    }

    private static int? _orderAssignmentStatusPageSize;
    public static int OrderAssignmentStatusPageSize
    {
      get
      {
        int pageSize;
        if (!_orderAssignmentStatusPageSize.HasValue)
        {
          if (int.TryParse(GetValue("OrderAssignmentStatusPageSize"), out pageSize))
          {
            _orderAssignmentStatusPageSize = pageSize;
          }
          else
          {
            _orderAssignmentStatusPageSize = 3;
          }
        }
        return _orderAssignmentStatusPageSize.Value;
      }
      set
      {
        _orderAssignmentStatusPageSize = value;
      }
    }

    private static int? _orderStatusHistoryPageSize;
    public static int OrderStatusHistoryPageSize
    {
      get
      {
        int pageSize;
        if (!_orderStatusHistoryPageSize.HasValue)
        {
          if (int.TryParse(GetValue("OrderStatusHistoryPageSize"), out pageSize))
          {
            _orderStatusHistoryPageSize = pageSize;
          }
          else
          {
            _orderStatusHistoryPageSize = 5;
          }
        }
        return _orderStatusHistoryPageSize.Value;
      }
      set
      {
        _orderStatusHistoryPageSize = value;
      }
    }

    private static int? _orderStatusPageSize;
    public static int OrderStatusPageSize
    {
      get
      {
        int pageSize;
        if (!_orderStatusPageSize.HasValue)
        {
          if (int.TryParse(GetValue("OrderStatusPageSize"), out pageSize))
          {
            _orderStatusPageSize = pageSize;
          }
          else
          {
            _orderStatusPageSize = 3;
          }
        }
        return _orderStatusPageSize.Value;
      }
      set
      {
        _orderStatusPageSize = value;
      }
    }

    private static int? _orderAssignmentPageSize;
    public static int OrderAssignmentPageSize
    {
      get
      {
        int pageSize;
        if (!_orderAssignmentPageSize.HasValue)
        {
          if (int.TryParse(GetValue("OrderAssignmentPageSize"), out pageSize))
          {
            _orderAssignmentPageSize = pageSize;
          }
          else
          {
            _orderAssignmentPageSize = 5;
          }
        }
        return _orderAssignmentPageSize.Value;
      }
      set
      {
        _orderAssignmentPageSize = value;
      }
    }

    private static int? _reminderDefaultPageSize;
    public static int ReminderDefaultPageSize
    {
      get
      {
        int pageSize;
        if (!_reminderDefaultPageSize.HasValue)
        {
          if (int.TryParse(GetValue("ReminderDefaultPageSize"), out pageSize))
          {
            _reminderDefaultPageSize = pageSize;
          }
          else
          {
            _reminderDefaultPageSize = 5;
          }
        }
        return _reminderDefaultPageSize.Value;
      }
      set
      {
        _reminderDefaultPageSize = value;
      }
    }
    private static string _smmFaxToInstruction;
    public static string SmmFaxToInstruction
    {
      get
      {
        if (_smmFaxToInstruction == null)
        {
          _smmFaxToInstruction = GetValue("SmmFaxToInstruction");
        }
        return _smmFaxToInstruction;
      }
      set
      {
        _smmFaxToInstruction = value;
      }      
    }
    private static int _alertDateBeforeCredentialingExpiration = -1;
    public static int AlertDateBeforeCredentialingExpiration
    {
      get
      {
        if (_alertDateBeforeCredentialingExpiration == -1)
        {
          int ret;
          if (int.TryParse(GetValue("AlertDateBeforeCredentialingExpiration"), out ret))
          {
            _alertDateBeforeCredentialingExpiration = ret;
          }
        }
        return _alertDateBeforeCredentialingExpiration;
      }
      set
      {
        _alertDateBeforeCredentialingExpiration = value;
      }
    }
    /// <summary>
    /// path of insurance
    /// </summary>
    private static string _insuranceFormFolder;
    public static string InsuranceFormFolder
    {
      get
      {
        if (_insuranceFormFolder == null)
        {
          _insuranceFormFolder = GlobalSettingsSection.Default.InsuranceFormFolder;
        }
        return _insuranceFormFolder;
      }
      set
      {
        _insuranceFormFolder = value;
      }
    }

    /// <summary>
    /// Path of order document
    /// </summary>
    private static string _orderDocumentFolder;
    public static string OrderDocumentFolder
    {
      get
      {
        if (_orderDocumentFolder == null)
        {
          _orderDocumentFolder = GlobalSettingsSection.Default.OrderDocumentFolder;
        }
        return _orderDocumentFolder;
      }
      set
      {
        _orderDocumentFolder = value;
      }
    }

    /// <summary>
    /// path of credential
    /// </summary>
    private static string _credentialFolder;
    public static string CredentialFolder
    {
      get
      {
        if (_credentialFolder == null)
        {
          _credentialFolder = GlobalSettingsSection.Default.CredentialFolder;
        }
        return _credentialFolder;
      }
      set
      {
        _credentialFolder = value;
      }
    }

    /// <summary>
    /// Interval to send email
    /// </summary>
    private static TimeSpan _emailInterval;
    public static TimeSpan EmailInterval
    {
      get
      {
        if (_emailInterval == TimeSpan.Zero)
        {
          _emailInterval = new TimeSpan(0,0,EmailServiceSection.Default.Interval);
        }
        return _emailInterval;
      }
      set
      {
        _emailInterval = value;
      }
    }

    /// <summary>
    /// Email of SMM system
    /// </summary>
    private static string _adminEmail;
    public static string AdminEmail
    {
      get
      {
        if (_adminEmail == null)
        {
          _adminEmail = GetValue("AdminEmail");
        }
        return _adminEmail;
      }
      set
      {
        _adminEmail = value;
      }
    }

    /// <summary>
    /// return the host name
    /// </summary>
    private static string _hostName;
    public static string HostName
    {
      get
      {
        if (_hostName == null)
        {
          _hostName = GlobalSettingsSection.Default.HostName;
        }
        return _hostName;
      }
      set
      {
        _hostName = value;
      }
    }
    private static int _intervalReminder = -1;
    public static int IntervalReminder
    {
      get
      {
        if (_intervalReminder == -1)
        {
          _intervalReminder = GlobalSettingsSection.Default.IntervalReminder;
        }
        return _intervalReminder;
      }
      set
      {
        if (value < 5)
        {
          _intervalReminder = GlobalSettingsSection.Default.IntervalReminder;
        }
        else
        {
          _intervalReminder = value;
        }
      }
    }
    public const string SmmOrgID = "3E0F8350-C6F0-46E5-8469-9B372AACC91E";

    private static int _orderDocumentMaxSize;
    public static int OrderDocumentMaxSize
    {
      get
      {
        if (_orderDocumentMaxSize == 0)
        {
          _orderDocumentMaxSize = GlobalSettingsSection.Default.OrderDocumentMaxSize;
        }
        return _orderDocumentMaxSize;
      }
      set
      {
        _orderDocumentMaxSize = value;
      }
    }

    /// <summary>
    /// Number of expired days for Invoice
    /// </summary>
    private static int _expiredDaysForInvoice;
    public static int ExpiredDaysForInvoice
    {
      get
      {
        if (_expiredDaysForInvoice <=0)
        {
          int temp = 0;
          int.TryParse(GetValue("ExpiredDaysForInvoice"), out temp);
          if (temp <= 0)
            temp = 14;
          _expiredDaysForInvoice = temp;
        }
        return _expiredDaysForInvoice;
      }
      set
      {
        _expiredDaysForInvoice = value;
      }
    }

    private static DateTime _credentialingExpiredCheckingTime = new DateTime(1753, 1, 1);
    public static DateTime CredentialingExpiredCheckingTime
    {
      get
      {
        if (_credentialingExpiredCheckingTime == null || _credentialingExpiredCheckingTime.Equals(new DateTime(1753, 1, 1)))
        {
          _credentialingExpiredCheckingTime = GlobalSettingsSection.Default.CredentialingExpiredCheckingTime;
          return _credentialingExpiredCheckingTime;
        }
        return _credentialingExpiredCheckingTime;
      }
      set
      {
        _credentialingExpiredCheckingTime = value;
      }
    }

    private static string _supplyDepartment;
    public static string SupplyDepartment
    {
      get
      {
        if (String.IsNullOrEmpty(_supplyDepartment))
        {
          _supplyDepartment = GetValue("SupplyDeparment");
        }
        return _supplyDepartment;
      }
      set
      {
        _supplyDepartment = value;
      }
    }
    private static string _customerServiceRepresentative;
    public static string CustomerServiceRepresentative
    {
      get
      {
        if (String.IsNullOrEmpty(_customerServiceRepresentative))
        {
          _customerServiceRepresentative = GetValue("CustomerServiceRepresentative");
        }
        return _customerServiceRepresentative;
      }
      set
      {
        _customerServiceRepresentative = value;
      }
    }

    /// <summary>
    /// return the host name
    /// </summary>
    private static string _orderDetailURL;
    public static string OrderDetailURL
    {
      get
      {
        if (_orderDetailURL == null)
        {
          _orderDetailURL = GlobalSettingsSection.Default.OrderDetailURL;
        }
        return _orderDetailURL;
      }
      set
      {
        _orderDetailURL = value;
      }
    }
    private static string _webServiceUsername;
    public static string WebServiceUsername
    {
      get
      {
        if (_webServiceUsername == null)
        {
          _webServiceUsername = GlobalSettingsSection.Default.WebServiceUsername;
        }
        return _webServiceUsername;
      }
      set
      {
        _webServiceUsername = value;
      }
    }
    private static string _webServicePassword;
    public static string WebServicePassword
    {
      get
      {
        if (_webServicePassword == null)
        {
          _webServicePassword = GlobalSettingsSection.Default.WebServicePassword;
        }
        return _webServicePassword;
      }
      set
      {
        _webServicePassword = value;
      }
    }
    private static string _webServiceDebug;
    public static string WebServiceDebug
    {
      get
      {
        if (_webServiceDebug == null)
        {
          _webServiceDebug = GlobalSettingsSection.Default.WebServiceDebug;
        }
        return _webServiceDebug;
      }
      set
      {
        _webServiceDebug = value;
      }
    }

    private static string _SMMVendorCode;
    public static string SMMVendorCode
    {
      get
      {
        if (_SMMVendorCode == null)
        {
          _SMMVendorCode = GlobalSettingsSection.Default.SMMVendorCode;
        }
        return _SMMVendorCode;
      }
      set
      {
        _SMMVendorCode = value;
      }
    }

    private static string _serviceFeeCode;
    public static string ServiceFeeCode
    {
      get
      {
        if (_serviceFeeCode == null)
        {
          _serviceFeeCode = GlobalSettingsSection.Default.ServiceFeeCode;
        }
        return _serviceFeeCode;
      }
      set
      {
        _serviceFeeCode = value;
      }
    }
    private static string _kitFeeCode;
    public static string KitFeeCode
    {
      get
      {
        if (_kitFeeCode == null)
        {
          _kitFeeCode = GlobalSettingsSection.Default.KitFeeCode;
        }
        return _kitFeeCode;
      }
      set
      {
        _kitFeeCode = value;
      }
    }
    private static string _webSerivceLogFolder;
    public static string WebSerivceLogFolder
    {
      get
      {
        if (_webSerivceLogFolder == null)
        {
          _webSerivceLogFolder = GlobalSettingsSection.Default.WebSerivceLogFolder;
        }
        return _webSerivceLogFolder;
      }
      set
      {
        _webSerivceLogFolder = value;
      }
    }
    private static int _dayBeforeReimbursementExpired = -1;
    public static int DayBeforeReimbursementExpired
    {
      get
      {
        if (_dayBeforeReimbursementExpired == -1)
        {
          int ret;
          if (int.TryParse(GetValue("DayBeforeReimbursementExpired"), out ret))
          {
            _dayBeforeReimbursementExpired = ret;
          }
        }
        return _dayBeforeReimbursementExpired;
      }
      set
      {
        _dayBeforeReimbursementExpired = value;
      }
    }
	
	private static int _declined = -1;
    public static int Declined
    {
      get 
      {
        return _declined = GlobalSettingsSection.Default.Declined;
      }
      set
      {
        _declined = value;
      }
    }
  }
}
