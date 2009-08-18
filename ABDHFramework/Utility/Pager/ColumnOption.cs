using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Framework.Lib.Pager
{
  public class ColumnOption<T>
  {
    /// <summary>
    /// name of header. If it is null, field name will be used instead
    /// </summary>
    private String _name;
    public String Name { get { return _name; } set { _name = value; } }

    /// <summary>
    /// field name of item
    /// </summary>
    private String _fieldName;
    public String FieldName { get { return _fieldName; } set { _fieldName = value; } }

    private bool _isSort;
    public bool IsSort
    {
      get { return _isSort; }
      set { _isSort = value; }
    }

    private String _defaultSortOption;
    public String DefaultSortOption
    {
      get { return _defaultSortOption; }
      set { _defaultSortOption = value; }
    }

    public object HeaderAttributes { get; set; }
    public object RowAttributes { get; set; }
    public object AltRowAttributes { get; set; }

    public delegate string ColumnOptionFunc(T item);
    private ColumnOptionFunc _action;
    public ColumnOptionFunc Action { get { return _action; } set { _action = value; } }
  }
}
