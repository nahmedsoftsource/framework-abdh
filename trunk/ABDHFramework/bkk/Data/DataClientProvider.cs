using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using Superior.Data.Configuration;
using System.Diagnostics;
using System.Configuration.Provider;
using System.Configuration;
using System.Web.Configuration;

namespace Superior.Data
{
  /// <summary>
  /// For every ORM module, we will inherit 
  /// </summary>
  public abstract class DataClientProvider : ProviderBase
  {
    private static ProviderCollection _providers;
    private static object _syncRoot;
    private static bool _initialized;
    private static DataClientProviderSection _config;
  
    /// <summary>
    /// Gets the default instance.
    /// </summary>
    /// <value>The instance.</value>
    public static DataClientProvider Instance
    {
      get
      {
        return GetInstance(null);
      }
    }

    static DataClientProvider()
    {
      _providers = new ProviderCollection();
      _syncRoot = new object();
      _initialized = false;
    }

    /// <summary>
    /// Returns an appropriate instance of CRMExchangeProvider basing on the provider name. 
    /// </summary>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static DataClientProvider GetInstance(string providerName)
    {
      Initialize();

      if (providerName == null)
      {
        providerName = _config.DefaultProvider;
      }

      DataClientProvider provider = _providers[providerName] as DataClientProvider;
      if (provider == null)
      {
        throw new ArgumentException("providerName is incorrect");
      }

      return provider;
    }

    /// <summary>
    /// Parses the configuration file
    /// </summary>
    private static void Initialize()
    {
      lock (_syncRoot)
      {
        if (_initialized)
          return;

        _config = DataClientProviderSection.Default;
        if (_config == null)
        {
          throw new ProviderException("DataClientProvider config section is missing");
        }
        try
        {
          ProvidersHelper.InstantiateProviders(_config.ProviderSettings, _providers,
            typeof(DataClientProvider));
        }
        catch(Exception ex)
        {
          if (_providers.Count > 0)
          {
            _providers.Clear();
          }
          throw new ProviderException("Error in instantiating DataClientProvider collection", ex);
        }

        if (_providers == null || _providers.Count == 0)
        {
          throw new ProviderException("Error in instantiating DataClientProvider collection");
        }

        _providers.SetReadOnly();
        _initialized = true;
      }
    }

    public abstract ConnectionContext CreateConnectionContext();

    public abstract TransactionContext CreateTransactionContext();

    public ISearchQuery CreateQuery()
    {
      return new Queries.SearchQuery();
    }
  }
}
