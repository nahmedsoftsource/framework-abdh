using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace ABDH_Demo.Data.Configuration
{
  public class DataClientProviderSection : ConfigurationSection
  {
    /// <summary>
    /// Return an instance of <see cref="AccountContextSection"/> from the default location in configuration file
    /// </summary>
    public static DataClientProviderSection Default
    {
      get
      {
        return (DataClientProviderSection)ConfigurationManager.GetSection("superior/dataClientProvider");
      }
    }

    /// <summary>
    /// Get or set the default provider
    /// </summary>
    [ConfigurationProperty("default", IsRequired = true)]
    public string DefaultProvider
    {
      get { return (string)base["default"]; }
      set { base["default"] = value; }
    }

    /// <summary>
    /// Get the collection of providers
    /// </summary>
    [ConfigurationProperty("providers")]
    public ProviderSettingsCollection ProviderSettings
    {
      get { return base["providers"] as ProviderSettingsCollection; }
    }
  }
}
