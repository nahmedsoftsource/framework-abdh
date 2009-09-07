using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.Data;

namespace Superior.MobileMedics.Common.Service
{
  public interface ICommonService
  {
    /// <summary>
    /// Loads the global settings.
    /// </summary>
    void LoadGlobalSettings();
    IDictionary<int, Domain.State> GetStatesOfCountry(int CountryID);
    Domain.ZipCode GetZipCode(string zipCode);
    bool IsGuid(string candidate);
    bool IsGuid(string candidate, out Guid guid);
    T GetMetataObject<T>(int id);
    Domain.DocumentFormat GetDocumentFormatByName(string name);

    SearchResult<T> Search<T>(ISearchQuery query);
  }
}
