using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ComponentModel;

namespace Superior.MobileMedics.Common.Configuration
{
  public class GlobalSettingsSection : ConfigurationSection
  {
    /// <summary>
    /// Return an instance of <see cref="AccountContextSection"/> from the default location in configuration file
    /// </summary>
    public static GlobalSettingsSection Default
    {
      get
      {
        return (GlobalSettingsSection)ConfigurationManager.GetSection("superior/globalSettings");
      }
    }

    [ConfigurationProperty("insuranceFormFolder", IsRequired = true)]    
    public string InsuranceFormFolder
    {
      get
      {
        return (string)this["insuranceFormFolder"] ?? "C:\\Upload";
      }
    }

    [ConfigurationProperty("SuperAdminID", IsRequired = true)]
    public Guid SuperAdminID
    {
      get
      {
        return Tool.IsGuid(this["SuperAdminID"].ToString()) ? new Guid(this["SuperAdminID"].ToString()) : Guid.Empty;
      }
    }

    [ConfigurationProperty("orderDocumentFolder", IsRequired = true)]
    public string OrderDocumentFolder
    {
      get
      {
        return (string)this["orderDocumentFolder"] ?? "C:\\OrderUpload";
      }
    }


    [ConfigurationProperty("credentialFolder", IsRequired = true)]
    public string CredentialFolder
    {
      get
      {
        return (string)this["credentialFolder"] ?? "C:\\Upload";
      }
    }

    [ConfigurationProperty("hostName", IsRequired = true)]
    public string HostName
    {
      get
      {
        return (string)this["hostName"] ?? "localhost";
      }
    }

    [ConfigurationProperty("orderDetailURL", IsRequired = true)]
    public string OrderDetailURL
    {
      get
      {
        return (string)this["orderDetailURL"] ?? "OrderManagement/Detail?OrderID=";
      }
    }

    [ConfigurationProperty("WebServiceUsername", IsRequired = true)]
    public string WebServiceUsername
    {
      get
      {
        return (string)this["WebServiceUsername"] ?? "admin";
      }
    }
    [ConfigurationProperty("WebServicePassword", IsRequired = true)]
    public string WebServicePassword
    {
      get
      {
        return (string)this["WebServicePassword"] ?? "admin";
      }
    }
    [ConfigurationProperty("WebServiceDebug", IsRequired = true)]
    public string WebServiceDebug
    {
      get
      {
        return (string)this["WebServiceDebug"] ?? "1";
      }
    }

    [ConfigurationProperty("SMMVendorCode", IsRequired = true)]
    public string SMMVendorCode
    {
      get
      {
        return (string)this["SMMVendorCode"] ?? "SMM";
      }
    }

    [ConfigurationProperty("ServiceFeeCode", IsRequired = true)]
    public string ServiceFeeCode
    {
      get
      {
        return (string)this["ServiceFeeCode"] ?? "10";
      }
    }
    [ConfigurationProperty("KitFeeCode", IsRequired = true)]
    public string KitFeeCode
    {
      get
      {
        return (string)this["KitFeeCode"] ?? "11";
      }
    }
    [ConfigurationProperty("WebSerivceLogFolder", IsRequired = true)]
    public string WebSerivceLogFolder
    {
      get
      {
        return (string)this["WebSerivceLogFolder"] ?? "c:\\smm-logs\\";
      }
    }
    

    /// <summary>
    /// document format id will use to create transition document.
    /// 
    /// Default document format id is 0 (unknown)
    /// </summary>
    [ConfigurationProperty("DefaultDocumentFormatID", IsRequired = true)]
    public int DefaultDocumentFormatID
    {
      get
      {
        return (int)this["DefaultDocumentFormatID"];
      }
    }

    /// <summary>
    /// document type id will use to create transition document.
    /// 
    /// Default document format id is 19 (other)
    /// </summary>
    [ConfigurationProperty("DefaultDocumentTypeID", IsRequired = true)]
    public int DefaultDocumentTypeID
    {
      get
      {
        var ID = (int)this["DefaultDocumentTypeID"];
        if (ID == 0){
          // there is no 0 ID
          return 19;
        }

        return ID;
      }
    }

    [ConfigurationProperty("OrderRelationshipOtherID", IsRequired = true)]
    public int OrderRelationshipOtherID
    {
      get
      {
        return (int)this["OrderRelationshipOtherID"];
      }
    }

    /// <summary>
    /// order status when create new order
    /// </summary>
    [ConfigurationProperty("OrderStatusNewID", IsRequired = true)]
    public int OrderStatusNewID
    {
      get
      {
        return (int)this["OrderStatusNewID"];
      }
    }

    /// <summary>
    /// direct order type id
    /// </summary>
    [ConfigurationProperty("OrderTypeDirectID", IsRequired = true)]
    public int OrderTypeDirectID
    {
      get
      {
        return (int)this["OrderTypeDirectID"];
      }
    }

    /// <summary>
    /// complete status id of order assignment
    /// </summary>
    [ConfigurationProperty("OrderAssignmentCompleteStatusID", IsRequired = true)]
    public int OrderAssignmentCompleteStatusID
    {
      get
      {
        return (int)this["OrderAssignmentCompleteStatusID"];
      }
    }

    /// <summary>
    /// paramed order type id
    /// </summary>
    [ConfigurationProperty("OrderTypeParamedID", IsRequired = true)]
    public int OrderTypeParamedID
    {
      get
      {
        return (int)this["OrderTypeParamedID"];
      }
    }

    [ConfigurationProperty("IntervalReminder", IsRequired = true)]
    public int IntervalReminder
    {
      get
      {
        var intervalReminder = (int)this["IntervalReminder"];
        if (intervalReminder < 5)
        {
          
          return 5;
        }

        return intervalReminder;
      }
    }
    [ConfigurationProperty("CredentialingExpiredCheckingTime", IsRequired = true)]
    public DateTime CredentialingExpiredCheckingTime
    {
      get
      {
       return (DateTime)this["CredentialingExpiredCheckingTime"];
      }
    }
    [ConfigurationProperty("OrderDocumentMaxSize", IsRequired = true)]
    public int OrderDocumentMaxSize
    {
      get
      {
        var maxsize = (int)this["OrderDocumentMaxSize"];
        if (maxsize == 0)
        {
          return 2097152;
        }
        return maxsize;
      }
    }

    [ConfigurationProperty("Declined", IsRequired = true)]
    public int Declined
    {
      get
      {
        var declined = (int)this["Declined"];
        if (declined == 0)
        {
          return 3;
        }
        return declined;
      }
    }
  }
}
