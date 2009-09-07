
namespace Superior.MobileMedics.DataMappers.LinqDataMapper
{
    using Superior.Data.LinqClient;
    partial class DocumentType
  {
    public Superior.MobileMedics.Common.Domain.DocumentType GetDomainObject()
    {
      return new Superior.MobileMedics.Common.Domain.DocumentType
      {
        ID = this.ID,
        Name = this.Name,
        //DocumentClassifierID = this.DocumentClassifierID
        
      };
    }
  }
  partial class AddressType
  {
    public Superior.MobileMedics.Common.Domain.AddressType GetDomainObject()
    {
      return new Superior.MobileMedics.Common.Domain.AddressType
      {
        ID = this.ID,
        Name = this.Name
      };
    }
  }
  partial class Country
  {
    public Superior.MobileMedics.Common.Domain.Country GetDomainObject()
    {
      return new Superior.MobileMedics.Common.Domain.Country
      {
        ID = this._ID,
        Name = this._Name,
        CallingCode = this._CallingCode
      };
    }
  }

  partial class Gender
  {
    public Superior.MobileMedics.Common.Domain.Gender GetDomainObject()
    {
      return new Superior.MobileMedics.Common.Domain.Gender
      {
        ID = this._ID,
        Name = this._Name,
      };
    }
  }

  partial class PricingUnit
  {
    public Superior.MobileMedics.Common.Domain.PricingUnit GetDomainObject()
    {
      return new Superior.MobileMedics.Common.Domain.PricingUnit
      {
        ID = this._ID,
        Name = this._Name,
      };
    }
  }

  partial class CredentialingStatus
  {
    public Superior.MobileMedics.Common.Domain.CredentialingStatus GetDomainObject()
    {
      return new Superior.MobileMedics.Common.Domain.CredentialingStatus
      {
        ID = this._ID,
        Name = this._Name,
      };
    }
  }

  partial class ApprovalStatus
  {
    public Superior.MobileMedics.Common.Domain.ApprovalStatus GetDomainObject()
    {
      return new Superior.MobileMedics.Common.Domain.ApprovalStatus
      {
        ID = this._ID,
        Name = this._Name
      };
    }
  }

  partial class Language
  {
    public Superior.MobileMedics.Common.Domain.Language GetDomainObject()
    {
      return new Superior.MobileMedics.Common.Domain.Language
      {
        ID = this._ID,
        Name = this._Name,
      };
    }
  }
  partial class State
  {
    public Superior.MobileMedics.Common.Domain.State GetDomainObject()
    {
      return new Superior.MobileMedics.Common.Domain.State
      {
        ID = this._ID,
        Name = this._Name,
        Abbr = this._Abbr,
        CountryID = this._CountryID,
        Inactive = this._Inactive
      };
    }
  }
  partial class SubmissionType
  {
    public Superior.MobileMedics.Common.Domain.SubmissionType GetDomainObject()
    {
      return new Superior.MobileMedics.Common.Domain.SubmissionType
      {
        ID = this._ID,
        Name = this._Name
      };
    }
  }

  partial class Document
  {
    public Superior.MobileMedics.Domain.InsuranceManagement.DocumentItem GetDomainObject()
    {
      return new Superior.MobileMedics.Domain.InsuranceManagement.DocumentItem
      {
        DocName = this._Name

      };
    }
  }

  
  partial class Lab
  {
    public Superior.MobileMedics.Domain.InsuranceManagement.Lab GetDomainObject()
    {
      return new Superior.MobileMedics.Domain.InsuranceManagement.Lab
      {
        ID = this._ID,
        Name = this._Name
      };
    }
  }


}
