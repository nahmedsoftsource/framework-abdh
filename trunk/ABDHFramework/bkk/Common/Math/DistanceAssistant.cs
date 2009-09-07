using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common
{
  public class DistanceAssistant
  {
    private const int EARTH_RADIUS_MILES = 3963;
    public double Distance(double dblLat1, double dblLong1, double dblLat2, double dblLong2)
    {
      dblLat1 = dblLat1 * System.Math.PI / 180;
      dblLong1 = dblLong1 * System.Math.PI / 180;
      dblLat2 = dblLat2 * System.Math.PI / 180;
      dblLong2 = dblLong2 * System.Math.PI / 180;
      double dist = 0;
      if (dblLat1 != dblLat2 || dblLong1 != dblLong2)
      {
        dist = System.Math.Sin(dblLat1) * System.Math.Sin(dblLat2) + System.Math.Cos(dblLat1) * System.Math.Cos(dblLat2) * System.Math.Cos(dblLong2 - dblLong1);
        dist = EARTH_RADIUS_MILES * (-1 * System.Math.Atan(dist / System.Math.Sqrt(1 - dist * dist)) + System.Math.PI / 2);
      }
      return dist;
    }
  }
}
