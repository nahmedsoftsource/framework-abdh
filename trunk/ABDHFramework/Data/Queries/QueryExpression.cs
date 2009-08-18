using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABDHFramework.Data.Queries
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
  }

  public class QueryExpression : IQueryExpression
  {
    //private IQueryable _query;
    //private string _propertyName;
    //private string _otherPropertyName;
    //private ExpressionType _expressionType;
    //private object _value;
    //private object[] _collectionValues;

    //public object[] CollectionValues
    //{
    //  get { return _collectionValues; }
    //  set { _collectionValues = value; }
    //}

    //public string PropertyName
    //{
    //  get { return _propertyName; }
    //  set { _propertyName = value; }
    //}

    //public string OtherPropertyName
    //{
    //  get { return _otherPropertyName; }
    //  set { _otherPropertyName = value; }
    //}

    //public ExpressionType ExpressionType
    //{
    //  get { return _expressionType; }
    //  set { _expressionType = value; }
    //}

    //public object Value
    //{
    //  get { return _value; }
    //  set { _value = value; }
    //}

    //public QueryExpression(IQueryable query, string propertyName)
    //{
    //  _query = query;
    //  _propertyName = propertyName;
    //}

    //#region IQueryExpression Members

    //public new IQueryable Equals(object value)
    //{
    //  _expressionType = ExpressionType.Equals;
    //  _value = value;
    //  return _query;
    //}

    //public IQueryable EqualsProperty(string propertyName)
    //{
    //  _expressionType = ExpressionType.EqualsProperty;
    //  _otherPropertyName = propertyName;
    //  return _query;
    //}

    //public IQueryable NotEquals(object value)
    //{
    //  _expressionType = ExpressionType.NotEquals;
    //  _value = value;
    //  return _query;
    //}

    //public IQueryable NotEqualsProperty(string propertyName)
    //{
    //  _expressionType = ExpressionType.NotEqualsProperty;
    //  _otherPropertyName = propertyName;
    //  return _query;
    //}

    //public IQueryable GreaterThanOrEquals(object value)
    //{
    //  _expressionType = ExpressionType.GreaterThanOrEquals;
    //  _value = value;
    //  return _query;
    //}

    //public IQueryable GreaterThanOrEqualsProperty(string propertyName)
    //{
    //  _expressionType = ExpressionType.GreaterThanOrEqualsProperty;
    //  _otherPropertyName = propertyName;
    //  return _query;
    //}

    //public IQueryable GreaterThan(object value)
    //{
    //  _expressionType = ExpressionType.GreaterThan;
    //  _value = value;
    //  return _query;
    //}

    //public IQueryable GreaterThanProperty(string propertyName)
    //{
    //  _expressionType = ExpressionType.GreaterThanProperty;
    //  _otherPropertyName = propertyName;
    //  return _query;
    //}

    //public IQueryable LessThanOrEquals(object value)
    //{
    //  _expressionType = ExpressionType.LessThanOrEquals;
    //  _value = value;
    //  return _query;
    //}

    //public IQueryable LessThan(object value)
    //{
    //  _expressionType = ExpressionType.LessThan;
    //  _value = value;
    //  return _query;
    //}

    //public IQueryable LessThanProperty(string propertyName)
    //{
    //  _expressionType = ExpressionType.LessThanProperty;
    //  _otherPropertyName = propertyName;
    //  return _query;
    //}

    //public IQueryable LessThanOrEqualsProperty(string propertyName)
    //{
    //  _expressionType = ExpressionType.LessThanOrEqualsProperty;
    //  _otherPropertyName = propertyName;
    //  return _query;
    //}

    //public IQueryable Contains(object value)
    //{
    //  _expressionType = ExpressionType.Contains;
    //  _value = value;
    //  return _query;
    //}

    //public IQueryable NotContains(object value)
    //{
    //  _expressionType = ExpressionType.NotContaints;
    //  _value = value;
    //  return _query;
    //}

    //public IQueryable IsNull()
    //{
    //  _expressionType = ExpressionType.IsNull;
    //  _value = "";
    //  return _query;
    //}

    //public IQueryable IsNotNull()
    //{
    //  _expressionType = ExpressionType.IsNotNull;
    //  _value = "";
    //  return _query;
    //}

    //public IQueryable IsEmpty()
    //{
    //  _expressionType = ExpressionType.IsEmpty;
    //  _value = "";
    //  return _query;
    //}

    //public IQueryable IsNotEmpty()
    //{
    //  _expressionType = ExpressionType.IsNotEmpty;
    //  _value = "";
    //  return _query;
    //}
    //public IQueryable In(object[] values)
    //{
    //  _expressionType = ExpressionType.In;
    //  _collectionValues = values;
    //  return _query;
    //}
    //public IQueryable Between(object value1, object value2)
    //{
    //  _expressionType = ExpressionType.Between;
    //  _collectionValues = new object[2];
    //  _collectionValues[0] = value1;
    //  _collectionValues[1] = value2;
    //  return _query;
    //}
    //#endregion

  }
}
