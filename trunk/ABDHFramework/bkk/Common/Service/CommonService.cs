using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.MobileMedics.Common.Domain;
using Superior.MobileMedics.Common.DataAccess.NHibernateClient;
using Superior.MobileMedics.Common.DataAccess;
using Superior.Data;
using Superior.Data.Queries;
using System.Text.RegularExpressions;
using Superior.Data.Collection;
using System.IO;
using Superior.MobileMedics.Common.Configuration;

namespace Superior.MobileMedics.Common.Service
{
  public class CommonService : ICommonService
  {
    #region Private members
    private Superior.MobileMedics.Common.DataAccess.NHibernateClient.ICommonDA _CommonDA = new CommonDA();
    private static Regex _guidExpression = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}(\-){0,1}[0-9a-fA-F]{4}(\-){0,1}[0-9a-fA-F]{4}(\-){0,1}[0-9a-fA-F]{4}(\-){0,1}[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);
    #endregion

    private static CommonService _instance;
    public static CommonService Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new CommonService();
        }
        return _instance;
      }
    }

    #region Public Methods
    public bool IsGuid(string candidate)
    {
      if (candidate != null && _guidExpression.IsMatch(candidate) == true)
      {
        return true;
      }
      return false;
    }

    public bool IsGuid(string candidate, out Guid guid)
    {
      if (candidate != null && _guidExpression.IsMatch(candidate) == true)
      {
        guid = new Guid(candidate);
        return true;
      }
      guid = new Guid();
      return false;
    }

    public Dictionary<int, EmployeeTitle> GetEmployeeTitles()
    {
      return _CommonDA.GetMetadataDomains<EmployeeTitle>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, EmployeeStatus> GetEmployeeStatus()
    {
      return _CommonDA.GetMetadataDomains<EmployeeStatus>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, PartyType> GetPartyTypes()
    {
      return _CommonDA.GetMetadataDomains<PartyType>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, AddressType> GetAddressTypes()
    {
      return _CommonDA.GetMetadataDomains<AddressType>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, PaymentType> GetPaymentTypes()
    {
      return _CommonDA.GetMetadataDomains<PaymentType>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, DocumentType> GetDocumentTypes()
    {
      return _CommonDA.GetMetadataDomains<DocumentType>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, Country> GetCountries()
    {
      return _CommonDA.GetMetadataDomains<Country>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, State> GetStates()
    {
      return _CommonDA.GetMetadataDomains<State>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, EmailFormat> GetEmailFormats()
    {
      return _CommonDA.GetMetadataDomains<EmailFormat>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, EmailType> GetEmailTypes()
    {
      return _CommonDA.GetMetadataDomains<EmailType>().ToDictionary(p => p.ID);
    }

    public IDictionary<int, Domain.State> GetStatesOfCountry(int CountryID)
    {
      ISearchQuery query = SearchQueryBuilder.CreateQuery()
                          .Where("CountryID").Equals(CountryID);
      return _CommonDA.Search<State>(query).Items.ToDictionary(p => p.ID);
    }

    public Dictionary<int, DocumentClassifier> GetDocumentClassifiers()
    {
      return _CommonDA.GetMetadataDomains<DocumentClassifier>().ToDictionary(p => p.ID);
    }

    public IDictionary<int, SmokeStatus> GetSmokeStatuses()
    {
      return _CommonDA.GetMetadataDomains<SmokeStatus>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, PermissionType> GetPermissionTypes()
    {
      return _CommonDA.GetMetadataDomains<PermissionType>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, PermissionTypeGroup> GetPermissionTypeGroups()
    {
      return _CommonDA.GetMetadataDomains<PermissionTypeGroup>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, Module> GetModules()
    {
      return _CommonDA.GetMetadataDomains<Module>().ToDictionary(p => p.ID);
    }

    public ZipCode GetZipCode(string zipCode)
    {
      ISearchQuery query = SearchQueryBuilder.CreateQuery()
                          .Where("ZipCodeName").Equals(zipCode);
      SearchResult<ZipCode> zipCodes = _CommonDA.Search<ZipCode>(query);

      if (zipCodes.Items.Count > 0)
        return zipCodes.Items[0];
      return null;
    }

    public Dictionary<int, OrderPriority> GetOrderPriorities()
    {
      return _CommonDA.GetMetadataDomains<OrderPriority>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, OrderStatus> GetOrderStatus()
    {
      return _CommonDA.GetMetadataDomains<OrderStatus>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, DocumentFormat> GetDocumentFormats()
    {
      return _CommonDA.GetMetadataDomains<DocumentFormat>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, Gender> GetGenders()
    {
      return _CommonDA.GetMetadataDomains<Gender>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, OrderType> GetOrderTypes()
    {
      return _CommonDA.GetMetadataDomains<OrderType>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, GovIDType> GetGovIDTypes()
    {
      return _CommonDA.GetMetadataDomains<GovIDType>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, Language> GetLanguages()
    {
      return _CommonDA.GetMetadataDomains<Language>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, CredentialingStatus> GetCredentialingStatus()
    {
      return _CommonDA.GetMetadataDomains<CredentialingStatus>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, ApprovalStatus> GetApprovalStatuses()
    {
      return _CommonDA.GetMetadataDomains<ApprovalStatus>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, PricingUnit> GetPricingUnits()
    {
      return _CommonDA.GetMetadataDomains<PricingUnit>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, PhoneType> GetPhoneTypes()
    {
      return _CommonDA.GetMetadataDomains<PhoneType>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, SubmissionType> GetSubmissionTypes()
    {
      return _CommonDA.GetMetadataDomains<SubmissionType>().ToDictionary(p => p.ID);
    }

    public IDictionary<int, EmployeeStatus> GetEmployeeStatuses()
    {
      return _CommonDA.GetMetadataDomains<EmployeeStatus>().ToDictionary(p => p.ID);
    }

    public IDictionary<string, Domain.Configuration> GetConfigurations()
    {
      return _CommonDA.GetMetadataDomains<Domain.Configuration>().ToDictionary(p => p.Name);
    }

    public IDictionary<int, OrderAssignmentStatus> GetOrderAssignmentStatuses()
    {
      return _CommonDA.GetMetadataDomains<OrderAssignmentStatus>().ToDictionary(p => p.ID);
    }

    public IDictionary<int, PurchaseOrderStatus> GetPurchaseOrderStatuses()
    {
      return _CommonDA.GetMetadataDomains<PurchaseOrderStatus>().ToDictionary(p => p.ID);
    }

    public IDictionary<int, SaleOrderStatus> GetSaleOrderStatuses()
    {
      return _CommonDA.GetMetadataDomains<SaleOrderStatus>().ToDictionary(p => p.ID);
    }

    public IDictionary<int, ItemType> GetItemTypes()
    {
      return _CommonDA.GetMetadataDomains<ItemType>().ToDictionary(p => p.ID);
    }

    public IDictionary<int, SupplyOrderStatus> GetSupplyOrderStatuses()
    {
      return _CommonDA.GetMetadataDomains<SupplyOrderStatus>().ToDictionary(p => p.ID);
    }
    public IDictionary<int, ReminderType> GetReminderTypes()
    {
      return _CommonDA.GetMetadataDomains<ReminderType>().ToDictionary(p => p.ID);
    }
    public IDictionary<int, ReminderTime> GetReminderTimes()
    {
      return _CommonDA.GetMetadataDomains<ReminderTime>().ToDictionary(p => p.ID);
    }
    public Dictionary<int, Priority> GetPriorities()
    {
      return _CommonDA.GetMetadataDomains<Priority>().ToDictionary(p => p.ID);
    }
    public Dictionary<int, ObjectType> GetObjectTypes()
    {
      return _CommonDA.GetMetadataDomains<ObjectType>().ToDictionary(p => p.ID);
    }
    public Dictionary<int, PaymentCode> GetPaymentCodes()
    {
      return _CommonDA.GetMetadataDomains<PaymentCode>().ToDictionary(p => p.ID);
    }
    public Dictionary<int, PaymentStatus> GetPaymentStatus()
    {
      return _CommonDA.GetMetadataDomains<PaymentStatus>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, PaperworkStatus> GetPaperWorkStatuses()
    {
      return _CommonDA.GetMetadataDomains<PaperworkStatus>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, RequestStatus> GetRequestStatus()
    {
      return _CommonDA.GetMetadataDomains<RequestStatus>().ToDictionary(p => p.ID);
    }
    public Dictionary<int, OrderAssignmentFeeType> GetOrderAssignmentFeeType()
    {
      return _CommonDA.GetMetadataDomains<OrderAssignmentFeeType>().ToDictionary(p => p.ID);
    }
    public IDictionary<int, EmailStatus> GetEmailStatus()
    {
      return _CommonDA.GetMetadataDomains<EmailStatus>().ToDictionary(p => p.ID);
    }

    public T GetMetataObject<T>(int id)
    {
      return _CommonDA.GetObject<T>(id);
    }

    public Dictionary<int, SurchargeType> GetSurchargeTypes()
    {
      return _CommonDA.GetMetadataDomains<SurchargeType>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, OrderRelationship> GetOrderRelationships()
    {
      return _CommonDA.GetMetadataDomains<OrderRelationship>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, NetworkRole> GetNetworkRoles()
    {
      return _CommonDA.GetMetadataDomains<NetworkRole>().ToDictionary(p => p.ID);
    }

    public Dictionary<int, OrderAssignmentStatus> GetSPOrderAssignmentStatuses()
    {
      ISearchQuery query = SearchQueryBuilder.CreateQuery()
                          .Where("IsServiceProviderInput").Equals(true);
      SearchResult<OrderAssignmentStatus> result = _CommonDA.Search<OrderAssignmentStatus>(query);

      return result.Items.ToDictionary(p => p.ID);
    }

    public DocumentFormat GetDocumentFormatByName(string name)
    {
      ISearchQuery query = SearchQueryBuilder.CreateQuery()
                          .Where("Name").Equals(name);
      SearchResult<DocumentFormat> result = _CommonDA.Search<DocumentFormat>(query);

      if (result.Items.Count > 0)
        return result.Items.First();
      return null;
    }

    /// <summary>
    /// get document format by file name
    /// </summary>
    /// <param name="FileName"></param>
    /// <returns></returns>
    public DocumentFormat GetDocumentFormatByFileName(string FileName)
    {
      var Extension = Path.GetExtension(FileName).ToLower();

      var DefaultDocumentFormat = DocumentFormat.DocumentFormats[GlobalSettingsSection.Default.DefaultDocumentFormatID];

      if (Extension == "")
      {
        return DefaultDocumentFormat;
      }

      var ret = DocumentFormat.DocumentFormats
        .Where(kvp => kvp.Value.FileExtension != null && kvp.Value.FileExtension.ToLower().Contains(Extension))
        .Select(kvp => kvp.Value).FirstOrDefault();

      if (ret == null)
      {
        return DefaultDocumentFormat;
      }
      else
      {
        return ret;
      }
    }

    public OrderAssignmentStatus UpdateOrderAssignmentStatus(OrderAssignmentStatus status)
    {
      OrderAssignmentStatus obj;
      using (var txn = TransactionScope.Enter())
      {
        obj = _CommonDA.GetObject<OrderAssignmentStatus>(status.ID);
        obj.IsNotifySupervisor = status.IsNotifySupervisor;
        obj.IsNotifyOrderingParty = status.IsNotifyOrderingParty;
        txn.Commit();
      }
      return obj;
    }

    public OrderStatus UpdateOrderStatus(OrderStatus status)
    {
      OrderStatus obj;
      using (var txn = TransactionScope.Enter())
      {
        obj = _CommonDA.GetObject<OrderStatus>(status.ID);
        obj.IsNotifySupervisor = status.IsNotifySupervisor;
        obj.IsNotifyOrderingParty = status.IsNotifyOrderingParty;
        txn.Commit();
      }
      return obj;
    }

    public PaperworkStatus UpdateOrderPaperworkStatus(PaperworkStatus status)
    {
      PaperworkStatus obj;
      using (var txn = TransactionScope.Enter())
      {
        obj = _CommonDA.GetObject<PaperworkStatus>(status.ID);
        obj.IsNotifySupervisor = status.IsNotifySupervisor;
        obj.IsNotifyOrderingParty = status.IsNotifyOrderingParty;
        txn.Commit();
      }
      return obj;
    }

    public void UpdateConfiguration(Common.Domain.Configuration config)
    {
      using (var txn = TransactionScope.Enter())
      {

        Common.Domain.Configuration obj = _CommonDA.GetObject<Common.Domain.Configuration>(config.ID);
        obj.Value = config.Value;
        txn.Commit();

        ConfigurationSettings.Refresh();
        ConfigurationSettings.CustomerServiceRepresentative = "";
      }
    }

    #endregion

    public void LoadGlobalSettings()
    {
      using (ConnectionScope.Enter())
      {
        using (ConnectionScope.Enter())
        {
          Domain.AddressType.AddressTypes = new LazyDictionary<int, Domain.AddressType>(this.GetAddressTypes);
          Domain.DocumentType.DocumentTypes = new LazyDictionary<int, Domain.DocumentType>(this.GetDocumentTypes);
          Domain.Country.Countries = new LazyDictionary<int, Domain.Country>(this.GetCountries);
          Domain.State.States = new LazyDictionary<int, Domain.State>(this.GetStates);
          Domain.SubmissionType.SubmissionTypes = new LazyDictionary<int, Domain.SubmissionType>(this.GetSubmissionTypes);
          Domain.DocumentClassifier.DocumentClassifiers = new LazyDictionary<int, Domain.DocumentClassifier>(this.GetDocumentClassifiers);
          Domain.DocumentFormat.DocumentFormats = new LazyDictionary<int, Domain.DocumentFormat>(this.GetDocumentFormats);
          Domain.PhoneType.PhoneTypes = new LazyDictionary<int, Domain.PhoneType>(this.GetPhoneTypes);
          Domain.EmailType.EmailTypes = new LazyDictionary<int, Domain.EmailType>(this.GetEmailTypes);
          Domain.EmailFormat.EmailFormats = new LazyDictionary<int, Domain.EmailFormat>(this.GetEmailFormats);
          Domain.GovIDType.GovIDTypes = new LazyDictionary<int, Domain.GovIDType>(this.GetGovIDTypes);
          Domain.PartyType.PartyTypes = new LazyDictionary<int, Domain.PartyType>(this.GetPartyTypes);
          Domain.ApprovalStatus.ApprovalStatuses = new LazyDictionary<int, Domain.ApprovalStatus>(this.GetApprovalStatuses);
          Domain.PricingUnit.PricingUnits = new LazyDictionary<int, Domain.PricingUnit>(this.GetPricingUnits);
          Domain.Gender.Genders = new LazyDictionary<int, Domain.Gender>(this.GetGenders);
          Domain.SmokeStatus.SmokeStatuses = new LazyDictionary<int, Domain.SmokeStatus>(this.GetSmokeStatuses);
          Domain.ConfigurationSettings.Configuration = new LazyDictionary<string, Domain.Configuration>(this.GetConfigurations);
          Domain.OrderType.OrderTypes = new LazyDictionary<int, Domain.OrderType>(this.GetOrderTypes);
          Domain.Language.Languages = new LazyDictionary<int, Domain.Language>(this.GetLanguages);
          Domain.CredentialingStatus.CredentialingStatuses = new LazyDictionary<int, Domain.CredentialingStatus>(this.GetCredentialingStatus);
          Domain.PermissionType.PermissionTypes = new LazyDictionary<int, Domain.PermissionType>(this.GetPermissionTypes);
          Domain.OrderStatus.OrderStatuses = new LazyDictionary<int, Domain.OrderStatus>(this.GetOrderStatus);
          Domain.OrderAssignmentStatus.OrderAssignmentStatuses = new LazyDictionary<int, Domain.OrderAssignmentStatus>(this.GetOrderAssignmentStatuses);
          Domain.EmployeeStatus.EmployeeStatuses = new LazyDictionary<int, Domain.EmployeeStatus>(this.GetEmployeeStatus);
          Domain.EmployeeTitle.EmployeeTitles = new LazyDictionary<int, Domain.EmployeeTitle>(this.GetEmployeeTitles);
          Domain.PurchaseOrderStatus.PurchaseOrderStatuses = new LazyDictionary<int, Domain.PurchaseOrderStatus>(this.GetPurchaseOrderStatuses);
          Domain.SaleOrderStatus.SaleOrderStatuses = new LazyDictionary<int, Domain.SaleOrderStatus>(this.GetSaleOrderStatuses);
          Domain.ItemType.Type = new LazyDictionary<int, Domain.ItemType>(this.GetItemTypes);
          Domain.SupplyOrderStatus.OrderStatuses = new LazyDictionary<int, Domain.SupplyOrderStatus>(this.GetSupplyOrderStatuses);
          Domain.EmailStatus.EmailStatuses = new LazyDictionary<int, Domain.EmailStatus>(this.GetEmailStatus);
          Domain.ReminderType.ReminderTypes = new LazyDictionary<int, Domain.ReminderType>(this.GetReminderTypes);
          Domain.ReminderTime.ReminderTimes = new LazyDictionary<int, Domain.ReminderTime>(this.GetReminderTimes);
          Domain.OrderPriority.OrderPriorities = new LazyDictionary<int, Domain.OrderPriority>(this.GetOrderPriorities);
          Domain.Priority.Priorities = new LazyDictionary<int, Domain.Priority>(this.GetPriorities);
          Domain.PaymentType.PaymentTypes = new LazyDictionary<int, Domain.PaymentType>(this.GetPaymentTypes);
          Domain.SurchargeType.SurchargeTypes = new LazyDictionary<int, Domain.SurchargeType>(this.GetSurchargeTypes);
          Domain.ObjectType.ObjectTypes = new LazyDictionary<int, Domain.ObjectType>(this.GetObjectTypes);
          Domain.PaymentCode.PaymentCodes = new LazyDictionary<int, Domain.PaymentCode>(this.GetPaymentCodes);
          Domain.OrderAssignmentFeeType.OrderAssignmentFeeTypes = new LazyDictionary<int, Domain.OrderAssignmentFeeType>(this.GetOrderAssignmentFeeType);
          Domain.PaymentStatus.PaymentStatuses = new LazyDictionary<int, Domain.PaymentStatus>(this.GetPaymentStatus);
          Domain.RequestStatus.RequestStatuses = new LazyDictionary<int, Domain.RequestStatus>(this.GetRequestStatus);
          Domain.PaperworkStatus.PaperworkStatuses = new LazyDictionary<int, Domain.PaperworkStatus>(this.GetPaperWorkStatuses);
          Domain.OrderAssignmentStatus.SPOrderAssignmentStatuses = new LazyDictionary<int, Domain.OrderAssignmentStatus>(this.GetSPOrderAssignmentStatuses);
          Domain.NetworkRole.NetworkRoles = new LazyDictionary<int, Domain.NetworkRole>(this.GetNetworkRoles);
        }
      }
    }

    public SearchResult<T> Search<T>(ISearchQuery query)
    {
      return _CommonDA.Search<T>(query);
    }
  }
}
