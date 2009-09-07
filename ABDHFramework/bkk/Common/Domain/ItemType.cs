using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.MobileMedics.Common;
using Superior.MobileMedics.Common.Domain;

namespace Superior.MobileMedics.Common.Domain
{
	/// <summary>
	/// ItemType object for NHibernate mapped table 'ItemType'.
	/// </summary>
	[Serializable]
  public class ItemType : DomainTypeCode
	{
		#region Properties

    private static IDictionary<int, ItemType> _itemType;

    public static IDictionary<int, ItemType> Type
    {
      get
      {
        if (_itemType == null)
        {
          _itemType = new Dictionary<int, ItemType>();
        }
        return _itemType;
      }

      set
      {
        _itemType = value;
      }
    }

    public struct Types
    {
      public const int MedicalItem = 1;
      public const int Others = 2;
    }

    public struct TypeName
    {
      public const string MedicalItem = "Medical-Item";
      public const string Others = "Others";
    }
		#endregion
		
		#region Support Functions
			
		#endregion		
	}

}
