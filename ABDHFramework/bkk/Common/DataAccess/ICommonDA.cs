using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.DataAccess
{
  public interface ICommonDA
  {
    /// <summary>
    /// Gets the address types.
    /// </summary>
    /// <returns></returns>
    Dictionary<int, Domain.AddressType> GetAddressTypes();
    Dictionary<int, Domain.DocumentType> GetDocumentTypes();
    Dictionary<int, Domain.Country> GetCountries();
    Dictionary<int, Domain.State> GetStates();
    Dictionary<int, Domain.State> GetStates(int CountryID);
    Dictionary<int, Domain.SubmissionType> GetSubmissionTypes();
    Dictionary<int, Domain.DocumentClassifier> GetDocumentClassifiers();
    Dictionary<int, Domain.DocumentFormat> GetDocumentFormats();
    Dictionary<int, Domain.PhoneType> GetPhoneTypes();
    Dictionary<int, Domain.EmailType> GetEmailTypes();
    Dictionary<int, Domain.EmailFormat> GetEmailFormats();
    Dictionary<int, Domain.GovIDType> GetGovIDTypes();
    Dictionary<int, Domain.PartyType> GetPartyTypes();
    Dictionary<int, Domain.Language> GetLanguages();
    Dictionary<string, Domain.Configuration> GetConfigurations();
    Dictionary<int, Domain.ApprovalStatus> GetApprovalStatuses();
    Dictionary<int, Domain.PricingUnit> GetPricingUnits();
    Dictionary<int, Domain.CredentialingStatus> GetCredentialingStatus();
    Dictionary<int, Domain.OrderType> GetOrderTypes();
    Dictionary<int, Domain.Gender> GetGenders();
    Dictionary<int, Domain.OrderStatus> GetOrderStatus();
    Dictionary<int, Domain.OrderAssignmentStatus> GetOrderAssignmentStatus();
    Domain.ZipCode GetZipCode(string zipCode);
    Dictionary<int, Domain.OrderPriority> GetOrderPriorities();    Dictionary<int, Domain.PermissionType> GetPermissionTypes();

    IDictionary<int, Domain.SmokeStatus> GetSmokeStatuses();
    //Dictionary<int, Domain.OrderAssignmentStatus> GetOderAssignmentStatus();
  }
}
