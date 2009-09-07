using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common
{
  public class RadiusAssistant
  {
    private const double EQUATOR_LAT_MILE = 69.172;
    private double maxLat;
    private double minLat;
    private double maxLong;
    private double minLong;

    public RadiusAssistant(double Latitude, double Longitude, double Miles)
    {
      maxLat = Latitude + Miles / EQUATOR_LAT_MILE;
      minLat = Latitude - (maxLat - Latitude);
      maxLong = Longitude + Miles / (Math.Cos(minLat * Math.PI / 180) * EQUATOR_LAT_MILE);
      minLong = Longitude - (maxLong - Longitude);
    }

    public double MaxLatitude
    {
      get { return maxLat; }
    }
    public double MinLatitude
    {
      get { return minLat; }
    }
    public double MaxLongitude
    {
      get { return maxLong; }
    }
    public double MinLongitude
    {
      get { return minLong; }
    }
  }
}
