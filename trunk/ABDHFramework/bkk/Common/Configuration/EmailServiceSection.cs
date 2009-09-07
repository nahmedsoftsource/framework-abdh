using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ComponentModel;

namespace Superior.MobileMedics.Common.Configuration
{
  public class EmailServiceSection : ConfigurationSection
  {
    public static EmailServiceSection Default
    {
      get
      {
        return (EmailServiceSection)ConfigurationManager.GetSection("superior/emailService");
      }
    }

    [ConfigurationProperty("interval", IsRequired = true)]
    public int Interval
    {
      get
      {
        return int.Parse(this["interval"].ToString());
      }
    }
  }
}
