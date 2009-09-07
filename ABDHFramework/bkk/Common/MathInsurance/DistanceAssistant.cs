using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.MathInsurance
{
  public class DistanceAssistant
  {
    private const int EARTH_RADIUS_MILES = 3963;
    public double Distance(double dblLat1, double dblLong1, double dblLat2, double dblLong2)
    {
      dblLat1 = dblLat1 * Math.PI / 180;
      dblLong1 = dblLong1 * Math.PI / 180;
      dblLat2 = dblLat2 * Math.PI / 180;
      dblLong2 = dblLong2 * Math.PI / 180;
      double dist = 0;
      if (dblLat1 != dblLat2 || dblLong1 != dblLong2)
      {
        dist = Math.Sin(dblLat1) * Math.Sin(dblLat2) + Math.Cos(dblLat1) * Math.Cos(dblLat2) * Math.Cos(dblLong2 - dblLong1);
        dist = EARTH_RADIUS_MILES * (-1 * Math.Atan(dist / Math.Sqrt(1 - dist * dist)) + Math.PI / 2);
      }
      return dist;
    }
  }
}
