using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.MobileMedics.Common.Domain
{
  public class State : DomainTypeCode
  {
    public static int DEFAULT_STATE_ID = 1;
    public static int UNKNOWN_STATE_ID = 0;
    public static int ALL_STATE_ID = 1000;


    private string _abbr;
    private int _countryID;
    private bool _inactive;
    private static IDictionary<int, State> _states;

    /// <summary>
    /// get state by country id
    /// </summary>
    /// <param name="CountryID"></param>
    /// <returns></returns>
    public static IList<State> ByCountryID(int CountryID)
    {
      return States.Where(kvp => kvp.Value.CountryID == CountryID).Select(kvp => kvp.Value).ToList();
    }

    public string Abbr
    {
      get
      {
        return _abbr;
      }
      set
      {
        _abbr = value;
      }
    }

    public int CountryID
    {
      get
      {
        return _countryID;
      }
      set
      {
        _countryID = value;
      }
    }

    public bool Inactive
    {
      get
      {
        return _inactive;
      }
      set
      {
        _inactive = value;
      }
    }

    public static IDictionary<int, State> States
    {
      get
      {
        if (_states == null)
        {
          _states = new Dictionary<int, State>();
        }
        return _states;
      }
      set
      {
        _states = value;
      }
    }
  }
}
