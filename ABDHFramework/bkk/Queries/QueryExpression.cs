using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superior.Data.Queries
{
  public enum ExpressionType
  {
    Equals,
    EqualsProperty,
    NotEquals,
    NotEqualsProperty,
    GreaterThanOrEquals,
    GreaterThanOrEqualsProperty,
    GreaterThan,
    GreaterThanProperty,
    LessThanOrEquals,
    LessThanOrEqualsProperty,
    LessThan,
    LessThanProperty,
    Contains,
    NotContaints,
    IsNull,
    IsNotNull,
    IsEmpty,
    IsNotEmpty,
    In,
    Between,
    SQL
  }

  public class QueryExpression: IQueryExpression
  {
    private string _querySQL;
    private ISearchQuery _query;
    private string _propertyName;
    private string _otherPropertyName;
    private ExpressionType _expressionType;
    private object _value;
    private object[] _collectionValues;

    public string QuerySQL
    {
      get { return _querySQL; }
      set { _querySQL = value; }
    }

    public object[] CollectionValues
    {
      get { return _collectionValues;}
      set { _collectionValues = value; }
    }

    public string PropertyName
    {
      get { return _propertyName; }
      set { _propertyName = value; }
    }

    public string OtherPropertyName
    {
      get { return _otherPropertyName; }
      set { _otherPropertyName = value; }
    }

    public ExpressionType ExpressionType
    {
      get { return _expressionType; }
      set { _expressionType = value; }
    }

    public object Value
    {
      get { return _value; }
      set { _value = value; }
    }

    public QueryExpression(ISearchQuery query, string propertyName)
    {
      _query = query;
      _propertyName = propertyName;
    }

    #region IQueryExpression Members

    public new ISearchQuery Equals(object value)
    {
      _expressionType = ExpressionType.Equals;
      _value = value;
      return _query;
    }

    public ISearchQuery EqualsProperty(string propertyName)
    {
      _expressionType = ExpressionType.EqualsProperty;
      _otherPropertyName = propertyName;
      return _query;
    }

    public ISearchQuery NotEquals(object value)
    {
      _expressionType = ExpressionType.NotEquals;
      _value = value;
      return _query;
    }

    public ISearchQuery NotEqualsProperty(string propertyName)
    {
      _expressionType = ExpressionType.NotEqualsProperty;
      _otherPropertyName = propertyName;
      return _query;
    }

    public ISearchQuery GreaterThanOrEquals(object value)
    {
      _expressionType = ExpressionType.GreaterThanOrEquals;
      _value = value;
      return _query;
    }

    public ISearchQuery GreaterThanOrEqualsProperty(string propertyName)
    {
      _expressionType = ExpressionType.GreaterThanOrEqualsProperty;
      _otherPropertyName = propertyName;
      return _query;
    }

    public ISearchQuery GreaterThan(object value)
    {
      _expressionType = ExpressionType.GreaterThan;
      _value = value;
      return _query;
    }

    public ISearchQuery GreaterThanProperty(string propertyName)
    {
      _expressionType = ExpressionType.GreaterThanProperty;
      _otherPropertyName = propertyName;
      return _query;
    }

    public ISearchQuery LessThanOrEquals(object value)
    {
      _expressionType = ExpressionType.LessThanOrEquals;
      _value = value;
      return _query;
    }

    public ISearchQuery LessThan(object value)
    {
      _expressionType = ExpressionType.LessThan;
      _value = value;
      return _query;
    }

    public ISearchQuery LessThanProperty(string propertyName)
    {
      _expressionType = ExpressionType.LessThanProperty;
      _otherPropertyName = propertyName;
      return _query;
    }

    public ISearchQuery LessThanOrEqualsProperty(string propertyName)
    {
      _expressionType = ExpressionType.LessThanOrEqualsProperty;
      _otherPropertyName = propertyName;
      return _query;
    }

    public ISearchQuery Contains(object value)
    {
      _expressionType = ExpressionType.Contains;
      _value = value;
      return _query;
    }

    public ISearchQuery NotContains(object value)
    {
      _expressionType = ExpressionType.NotContaints;
      _value = value;
      return _query;
    }

    public ISearchQuery IsNull()
    {
      _expressionType = ExpressionType.IsNull;
      _value = "";
      return _query;
    }

    public ISearchQuery IsNotNull()
    {
      _expressionType = ExpressionType.IsNotNull;
      _value = "";
      return _query;
    }

    public ISearchQuery IsEmpty()
    {
      _expressionType = ExpressionType.IsEmpty;
      _value = "";
      return _query;
    }

    public ISearchQuery IsNotEmpty()
    {
      _expressionType = ExpressionType.IsNotEmpty;
      _value = "";
      return _query;
    }

    public ISearchQuery SQL(string  querySQL)
    {
      _expressionType = ExpressionType.SQL;
      _querySQL = querySQL;
      return _query;
    }

    public ISearchQuery In(object[] values)
    {
      _expressionType = ExpressionType.In;
      _collectionValues = values;
      return _query;
    }
    public ISearchQuery Between(object value1, object value2)
    {
      _expressionType = ExpressionType.Between;
      _collectionValues = new object[2];
      _collectionValues[0] = value1;
      _collectionValues[1] = value2;
      return _query;
    }
    #endregion

  }
}
