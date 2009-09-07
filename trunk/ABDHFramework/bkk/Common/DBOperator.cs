using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Superior.MobileMedics.Common
{
  /// <summary>
  /// operator for database.
  /// 
  /// Usage: new {InsuranceID = DBOperator.In(new {})
  /// </summary>
  public class DBOperator
  {
    //const string In = "In";
    //const string NotIn = "NotIn";

    public enum OperatorType
    {
      In,
      NotIn
    }

    public OperatorType Operator { get; set; }
    public Object Value { get; private set; }

    private DBOperator(OperatorType op, Object val)
    {
      Operator = op;
      Value = val;
    }

    /// <summary>
    /// in operator
    /// </summary>
    /// <param name="objects"></param>
    /// <returns></returns>
    public static DBOperator In(ICollection objects){
      return new DBOperator(OperatorType.In, objects);
    }

    /// <summary>
    /// not in operator
    /// </summary>
    /// <param name="objects"></param>
    /// <returns></returns>
    public static DBOperator NotIn<T>(ICollection<T> objects)
    {
      return new DBOperator(OperatorType.NotIn, objects);
    }
  }
}
