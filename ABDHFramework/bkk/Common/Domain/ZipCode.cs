using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class ZipCode : DomainBase<int>
  {
    private string _zipCodeName;
    private string _city;
    private string _state;

    public string ZipCodeName
    {
      get
      {
        return _zipCodeName;
      }
      set
      {
        _zipCodeName = value;
      }
    }

    public string City
    {
      get
      {
        return _city;
      }
      set
      {
        _city = value;
      }
    }

    public string State
    {
      get
      {
        return _state;
      }
      set
      {
        _state = value;
      }
    }

    public string ZipCodeType { get; set; }
    public string CityType { get; set; }
    public string County { get; set; }
    public string CountyFIPS { get; set; }
    public string StateCode { get; set; }
    public string StateFIPS { get; set; }
    public string MSA { get; set; }
    public string AreaCode { get; set; }
    public string TimeZone { get; set; }
    public int GMTOffset { get; set; }
    public string DST { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
  }
}
