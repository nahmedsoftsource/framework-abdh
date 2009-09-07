using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  [Flags]
  public enum WeekDay
  {
    None = 0,
    Monday = 1,
    Tuesday = 2,
    Wednesday = 4,
    Thursday = 8,
    Friday = 16,
    Saturday = 32,
    Sunday = 64,
    Weekdays = 31
  }


  public class DayOfWeek
  {
    public const int Monday = 1 << 1;
    public const int Tuesday = 1 << 2;
    public const int Wednesday = 1 << 3;
    public const int Thusday = 1 << 4;
    public const int Friday = 1 << 5;
    public const int Saturday = 1 << 6;
    public const int Sunday = 1 << 7;

    public static int WorkingDay
    {
      get
      {
        return Monday | Tuesday | Wednesday | Thusday | Friday;
      }
    }

    public String ToString(int index)
    {
      switch(1 << index)
      {
        case Monday:
          return "Monday";
        case Tuesday:
          return "Tuesday";
        case Wednesday:
          return "Wednesday";
        case Thusday:
          return "Thusday";
        case Friday:
          return "Friday";
        case Saturday:
          return "Saturday";
        case Sunday:
          return "Sunday";
        default:
          return "None";
      }
    }

    /// <summary>
    /// TO string the day of week for int value
    /// </summary>
    /// <param name="day"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public String ToString(int day, int index)
    {
      if ((day & 1 << index) != 0)
      {
        return ToString(1 << index);
      }
      else
      {
        return "";
      }
    }

    /// <summary>
    /// determine whether the day of week is set or not
    /// </summary>
    /// <param name="day"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public bool GetValue(int day, int index)
    {
      if ((day & 1 << index) != 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public int AccumulateWeekDate(int weekDay, int index)
    {
      return weekDay | (1 << index);
    }

  }
}
