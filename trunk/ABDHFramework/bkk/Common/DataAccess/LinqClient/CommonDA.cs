using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataMapper = Superior.MobileMedics.DataMappers.LinqDataMapper;
using Superior.Data;
using Superior.Data.LinqClient;
using System.Collections;

namespace Superior.MobileMedics.Common.DataAccess.LinqClient
{
  public class CommonDA: ICommonDA
  {
    private static CommonDA _instance;
    public static CommonDA Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new CommonDA();
        }
        return _instance;
      }
    }

    /// <summary>
    ///   Prevent creation of the singleton object
    /// </summary>
    private CommonDA()
    {
    }

    /// <summary>
    /// Gets the address types.
    /// </summary>
    /// <returns></returns>
    public Dictionary<int, Domain.AddressType> GetAddressTypes()
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
        return context.AddressTypes.Select(row => row.GetDomainObject()).ToDictionary(obj => obj.ID);
      }
    }

    public Dictionary<int, Domain.DocumentType> GetDocumentTypes()
    {
        using (ConnectionScope.Enter())
        {
            DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
            return context.DocumentTypes.Select(row => row.GetDomainObject()).ToDictionary(obj => obj.ID);
        }
    }

    public Dictionary<int, Domain.Country> GetCountries()
    {
        using (ConnectionScope.Enter())
        {
            DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
            return context.Countries.Select(row => row.GetDomainObject()).ToDictionary(obj => obj.ID);
        }
    }

    public Dictionary<int, Domain.Gender> GetGenders()
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
        return context.Genders.Select(row => row.GetDomainObject()).ToDictionary(obj => obj.ID);
      }
    }

    public Dictionary<int, Domain.CredentialingStatus> GetCredentialingStatus()
    {
        using (ConnectionScope.Enter())
        {
            DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
            return context.CredentialingStatus.Select(row => row.GetDomainObject()).ToDictionary(obj => obj.ID);
        }
    }

    public Dictionary<int, Domain.PricingUnit> GetPricingUnits()
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
        return context.PricingUnits.Select(row => row.GetDomainObject()).ToDictionary(obj => obj.ID);
      }
    }

    public Dictionary<int, Domain.ApprovalStatus> GetApprovalStatuses()
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
        return context.ApprovalStatus.Select(row => row.GetDomainObject()).ToDictionary(obj => obj.ID);
      }
    }

    public Dictionary<int, Domain.Language> GetLanguages()
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
        return context.Languages.Select(row => row.GetDomainObject()).ToDictionary(obj => obj.ID);
      }
    }

    public Dictionary<int, Domain.State> GetStates()
    {
        using (ConnectionScope.Enter())
        {
            DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
            return context.States.Select(row => row.GetDomainObject()).ToDictionary(obj => obj.ID);
        }
    }

    public Dictionary<int, Domain.OrderStatus> GetOrderStatus()
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
        return context.OrderStatus.Select(row => new Domain.OrderStatus { ID=row.ID,Name=row.Name}).ToDictionary(obj => obj.ID);
      }
    }

    public Dictionary<int, Domain.OrderAssignmentStatus> GetOrderAssignmentStatus()
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
        return context.OrderAssignmentStatus.Select(row => new Domain.OrderAssignmentStatus { ID = row.ID, Name = row.Name, IsNoteRequired = row.NoteRequired }).OrderBy(obj=>obj.Name).ToDictionary(obj => obj.ID);
      }
    }

    public Dictionary<int, Domain.OrderPriority> GetOrderPriorities()
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
        return context.OrderPriorities.Select(row => new Domain.OrderPriority { ID = row.ID, Name = row.Name }).ToDictionary(obj => obj.ID);
      }
    }

    public Dictionary<int, Domain.State> GetStates(int CountryID)
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
        //return context.States.Select(row => row.GetDomainObject()).Where(row=>row.CountryID==CountryID).ToDictionary(obj => obj.ID);
        return context.States.Select(
          row=>new Domain.State { 
            Abbr=row.Abbr,
            CountryID=row.CountryID,
            ID=row.ID,
            Inactive=row.Inactive,
            Name=row.Name})
          .Where(row => (row.CountryID == CountryID&&row.Inactive==false) )
          .ToDictionary(obj => obj.ID);
      }
    }

    public Dictionary<int, Domain.SubmissionType> GetSubmissionTypes()
    {
        using (ConnectionScope.Enter())
        {
            DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
            return context.SubmissionTypes.Select(row => row.GetDomainObject()).ToDictionary(obj => obj.ID);
        }
    }

    public Dictionary<int, Domain.DocumentClassifier> GetDocumentClassifiers()
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
        return context.DocumentClassifiers.Select(row=>new Domain.DocumentClassifier { ID=row.ID,Name=row.Name}).ToDictionary(obj => obj.ID);
      }
    }

    public Dictionary<int, Domain.DocumentFormat> GetDocumentFormats()
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
        return context.DocumentFormats.Select(row => new Domain.DocumentFormat { ID = row.ID, Name = row.Name, FileExtension=row.FileExtension}).ToDictionary(obj => obj.ID);
      }
    }
    public Dictionary<int, Domain.PhoneType> GetPhoneTypes()
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
        return context.PhoneTypes.Select(row => new Domain.PhoneType { ID = row.ID, Name = row.Name,}).ToDictionary(obj => obj.ID);
      }
    }
    public Dictionary<int, Domain.EmailType> GetEmailTypes()
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
        return context.EmailTypes.Select(row => new Domain.EmailType { ID = row.ID, Name = row.Name, }).ToDictionary(obj => obj.ID);
      }
    }
    public Dictionary<int, Domain.EmailFormat> GetEmailFormats()
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
        return context.EmailFormats.Select(row => new Domain.EmailFormat { ID = row.ID, Name = row.Name, }).ToDictionary(obj => obj.ID);
      }
    }
    public Dictionary<int, Domain.GovIDType> GetGovIDTypes()
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
        return context.GovIDTypes.Select(row => new Domain.GovIDType { ID = row.ID, Name = row.Name, AbbrName = row.AbbrName }).ToDictionary(obj => obj.ID);
      }
    }
    public Dictionary<int, Domain.PartyType> GetPartyTypes()
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
        return context.PartyTypes.Select(row => new Domain.PartyType { ID = row.ID, Name = row.Name, }).ToDictionary(obj => obj.ID);
      }
    }

    public Domain.ZipCode GetZipCode(string zipCode)
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();        
        //var query = context.ZipCodes.Where(z => z.ZIPCode == zipCode);
        var linqZip = context.ZipCodes.SingleOrDefault(z => z.ZIPCode == zipCode);
        if (linqZip != null)
        {
          Domain.ZipCode zip = new Domain.ZipCode();
          zip.ID = linqZip.ID;
          zip.ZipCodeName = linqZip.ZIPCode;
          zip.State = linqZip.State;
          zip.City = linqZip.City;
          return zip;
        }
        else
        {
          Domain.ZipCode zip = new Domain.ZipCode();
          zip.City = "Not Found";
          return zip;
        }        
      }
    }

    /// <summary>
    /// return all of configurations of website.
    /// </summary>
    /// <returns></returns>
    public Dictionary<string, Domain.Configuration> GetConfigurations()
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();        
        return context.Configurations.Select(row => new Domain.Configuration { ID = row.ID, Name = row.Name, Value = row.Value, Description= row.Description}).ToDictionary(obj => obj.Name);
      }
    }

    public Dictionary<int, Domain.OrderType> GetOrderTypes()
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
        return context.OrderTypes.Select(row => new Domain.OrderType { ID = row.ID, Name = row.Name, }).ToDictionary(obj => obj.ID);
      }
    }

    public Dictionary<int, Domain.PermissionType> GetPermissionTypes()
    {
      using (ConnectionScope.Enter())
      {
        DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
        return context.PermissionTypes.Select(row => new Domain.PermissionType { ID = row.ID, Name = row.Name }).ToDictionary(obj => obj.ID);
      }
    }

    //public Dictionary<int, Domain.OrderAssignmentStatus> GetOrderAssignmentStatus()
    //{
    //  using (ConnectionScope.Enter())
    //  {
    //    DataMapper.EntitiesDataContext context = DataMapper.DataHelper.CreateDataContext();
    //    return context.OrderAssignmentStatus.Select(row => new Domain.OrderAssignmentStatus { ID = row.ID, Name = row.Name, IsNoteRequired = row.NoteRequired }).ToDictionary(obj => obj.ID);
    //  }
    //}

    #region ICommonDA Members


    public IDictionary<int, Superior.MobileMedics.Common.Domain.SmokeStatus> GetSmokeStatuses()
    {
      using (ConnectionScope.Enter())
      {
        var context = DataMapper.DataHelper.CreateDataContext();
        return context.SmokeStatus.Select(row => new Domain.SmokeStatus{ID = row.ID, Name = row.Name}).ToDictionary(obj => obj.ID);
      }
    }

    #endregion
  }
}
