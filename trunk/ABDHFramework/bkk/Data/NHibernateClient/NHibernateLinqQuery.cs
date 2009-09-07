using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Diagnostics;
using NHibernate;
using NHExpression = NHibernate.Expression.Expression;
using System.Reflection;

namespace Superior.Data.NHibernateClient
{
  public class NHibernateLinqQuery<TResult> : IQueryable<TResult>, IQueryProvider
  {
    ISession session;
    ICriteria rootCriteria;
    IDictionary<ExpressionType, Action<System.Linq.Expressions.Expression>> actions;
    Stack<IList<NHibernate.Expression.ICriterion>> criterionStack = new Stack<IList<NHibernate.Expression.ICriterion>>();
    IList<TResult> result;

    public IList<TResult> Result
    {
      get
      {
        if (result == null)
          result = rootCriteria.List<TResult>();
        return result;
      }
    }

    private NHibernateLinqQuery()
    {
      actions = CreateActions();
    }

    public NHibernateLinqQuery(ISession session)
      : this()
    {
      this.session = session;
      rootCriteria = session.CreateCriteria(typeof(TResult));
      criterionStack.Push(new List<NHibernate.Expression.ICriterion>());
    }

    protected NHibernateLinqQuery(ISession session, ICriteria rootCriteria, Stack<IList<NHibernate.Expression.ICriterion>> criterionStack)
      : this()
    {
      this.session = session;
      this.rootCriteria = rootCriteria;
      this.criterionStack = criterionStack;
    }

    public IList<NHibernate.Expression.ICriterion> CurrentCriterions
    {
      get
      {
        return criterionStack.Peek();
      }
    }

    private IDictionary<ExpressionType, Action<Expression>> CreateActions()
    {
      Dictionary<ExpressionType, Action<Expression>> actionsDic = new Dictionary<ExpressionType, Action<Expression>>();
      foreach (ExpressionType val in Enum.GetValues(typeof(ExpressionType)))
      {
        actionsDic[val] = (Action<Expression>)Delegate.CreateDelegate(typeof(Action<Expression>), this,
           this.GetType().GetMethod("Process" + val));
      }
      return actionsDic;
    }



    private void HandleWhereCall(MethodCallExpression call)
    {
      foreach (Expression expr in call.Arguments)
      {
        ProcessExpression(expr);
      }
    }

    private void HandleSelectCall(MethodCallExpression call)
    {
      LambdaExpression labmda = (LambdaExpression)((UnaryExpression)call.Arguments[1]).Operand;
      ParameterExpression parameter = labmda.Body as ParameterExpression;
      if (parameter != null)
      {
        if (parameter.Type == typeof(TResult) && parameter == labmda.Parameters[0])
          return;
        throw new NotImplementedException();
      }
      MemberInitExpression mie = labmda.Body as MemberInitExpression;
      if (mie != null)
      {
        HandleAnonymousProjectionOfType(mie);
        return;
      }
      NewExpression newExpr = labmda.Body as NewExpression;
      if (newExpr != null)
      {
        HandleKnownTypeProject(newExpr);
        return;
      }
      MemberExpression member = (MemberExpression)labmda.Body;
      rootCriteria.SetProjection(NHibernate.Expression.Projections.Property(member.Member.Name));
    }

    private void HandleKnownTypeProject(NewExpression newExpr)
    {
      NHibernate.Transform.AliasToBeanConstructorResultTransformer transformer = new NHibernate.Transform.AliasToBeanConstructorResultTransformer(newExpr.Constructor);

      NHibernate.Expression.ProjectionList projections = NHibernate.Expression.Projections.ProjectionList();
      foreach (MemberExpression member in newExpr.Arguments)
      {
        projections.Add(NHibernate.Expression.Projections.Property(member.Member.Name));
      }
      rootCriteria.SetProjection(projections);
      rootCriteria.SetResultTransformer(transformer);
    }

    private void HandleAnonymousProjectionOfType(MemberInitExpression mie)
    {
      LinqProjectionResultTransformer transformer = new LinqProjectionResultTransformer(mie.NewExpression.Type,
                                                        mie.Bindings.ToArray());
      NHibernate.Expression.ProjectionList projections = NHibernate.Expression.Projections.ProjectionList();
      foreach (MemberBinding binding in mie.Bindings)
      {
        projections.Add(NHibernate.Expression.Projections.Property(binding.Member.Name));
      }
      rootCriteria.SetProjection(projections);
      rootCriteria.SetResultTransformer(transformer);

    }

    public void ProcessExpression(Expression expr)
    {
      actions[expr.NodeType](expr);

    }

    public void ProcessAdd(Expression expr) { }
    public void ProcessAddChecked(Expression expr) { }
    public void ProcessAnd(Expression expr)
    {
    }
    public void ProcessAndAlso(Expression expr)
    {
      BinaryExpression and = (BinaryExpression)expr;
      ProcessExpression(and.Left);
      ProcessExpression(and.Right);
    }
    public void ProcessArrayIndex(Expression expr) { }
    public void ProcessArrayLength(Expression expr) { }
    public void ProcessCall(Expression expr) { }
    public void ProcessCallVirtual(Expression expr) { }
    public void ProcessCast(Expression expr) { }
    public void ProcessCoalesce(Expression expr) { }
    public void ProcessConditional(Expression expr) { }
    public void ProcessConstant(Expression expr) { }
    public void ProcessConvert(Expression expr) { }
    public void ProcessConvertChecked(Expression expr) { }
    public void ProcessDivide(Expression expr) { }
    public void ProcessEqual(Expression expr)
    {
      BinaryExpression equals = (BinaryExpression)expr;
      if (equals.Left is MemberExpression)
      {
        string name = ((MemberExpression)equals.Left).Member.Name;
        object value = GetExpressionValue(equals.Right);
        CurrentCriterions.Add(NHExpression.Eq(name, value));
      }
      else
      {
        throw new NotSupportedException("Complex access is not supported");
      }
    }
    public void ProcessExclusiveOr(Expression expr) { }
    public void ProcessFunclet(Expression expr)
    {

    }
    public void ProcessGreaterThan(Expression expr)
    {
      BinaryExpression gt = (BinaryExpression)expr;
      if (gt.Left is MemberExpression)
      {
        string name = ((MemberExpression)gt.Left).Member.Name;
        object value = GetExpressionValue(gt.Right);
        CurrentCriterions.Add(NHExpression.Gt(name, value));
      }
      else
      {
        throw new NotSupportedException("Complex access is not supported");
      }
    }
    public void ProcessGreaterThanOrEqual(Expression expr)
    {
      BinaryExpression ge = (BinaryExpression)expr;
      if (ge.Left is MemberExpression)
      {
        string name = ((MemberExpression)ge.Left).Member.Name;
        object value = GetExpressionValue(ge.Right);
        CurrentCriterions.Add(NHExpression.Ge(name, value));
      }
      else
      {
        throw new NotSupportedException("Complex access is not supported");
      }
    }
    public void ProcessInvoke(Expression expr) { }
    public void ProcessLambda(Expression expr)
    {
      LambdaExpression lambda = (LambdaExpression)expr;
      ProcessExpression(lambda.Body);
    }
    public void ProcessLeftShift(Expression expr) { }
    public void ProcessLessThan(Expression expr)
    {
      BinaryExpression lt = (BinaryExpression)expr;
      if (lt.Left is MemberExpression)
      {
        string name = ((MemberExpression)lt.Left).Member.Name;
        object value = GetExpressionValue(lt.Right);
        CurrentCriterions.Add(NHExpression.Lt(name, value));
      }
      else
      {
        throw new NotSupportedException("Complex access is not supported");
      }

    }
    public void ProcessLessThanOrEqual(Expression expr)
    {
      BinaryExpression le = (BinaryExpression)expr;
      if (le.Left is MemberExpression)
      {
        string name = ((MemberExpression)le.Left).Member.Name;
        object value = GetExpressionValue(le.Right);
        CurrentCriterions.Add(NHExpression.Le(name, value));
      }
      else
      {
        throw new NotSupportedException("Complex access is not supported");
      }
    }
    public void ProcessLift(Expression expr) { }
    public void ProcessLiftEqual(Expression expr) { }
    public void ProcessLiftFalse(Expression expr) { }
    public void ProcessLiftNotEqual(Expression expr) { }
    public void ProcessLiftTrue(Expression expr) { }
    public void ProcessListInit(Expression expr) { }
    public void ProcessMemberAccess(Expression expr) { }
    public void ProcessMemberInit(Expression expr) { }
    public void ProcessModulo(Expression expr) { }
    public void ProcessMultiply(Expression expr) { }
    public void ProcessMultiplyChecked(Expression expr) { }
    public void ProcessNegate(Expression expr) { }
    public void ProcessNegateChecked(Expression expr) { }
    public void ProcessNew(Expression expr) { }
    public void ProcessNewArrayBounds(Expression expr) { }
    public void ProcessNewArrayInit(Expression expr) { }
    public void ProcessNot(Expression expr) { }
    public void ProcessNotEqual(Expression expr) { }
    public void ProcessOr(Expression expr)
    {

    }
    public void ProcessOrElse(Expression expr)
    {
      BinaryExpression and = (BinaryExpression)expr;
      criterionStack.Push(new List<NHibernate.Expression.ICriterion>());
      ProcessExpression(and.Left);
      ProcessExpression(and.Right);
      IList<NHibernate.Expression.ICriterion> ors = criterionStack.Pop();

      NHibernate.Expression.Disjunction disjunction = new NHibernate.Expression.Disjunction();
      foreach (var crit in ors)
      {
        disjunction.Add(crit);
      }
      CurrentCriterions.Add(disjunction);
    }
    public void ProcessParameter(Expression expr) { }
    public void ProcessQuote(Expression expr)
    {
      UnaryExpression unaryExpression = (UnaryExpression)expr;
      ProcessExpression(unaryExpression.Operand);
    }
    public void ProcessRightShift(Expression expr) { }
    public void ProcessSubtract(Expression expr) { }
    public void ProcessSubtractChecked(Expression expr) { }
    public void ProcessTypeAs(Expression expr) { }
    public void ProcessTypeIs(Expression expr) { }

    public TElement First<TElement>()
    {
      return rootCriteria.SetFirstResult(0)
              .SetMaxResults(1)
              .UniqueResult<TElement>();
    }

    private object GetExpressionValue(Expression expression)
    {
      ConstantExpression constExpr = expression as ConstantExpression;
      if (constExpr != null)
        return constExpr.Value;

      return Expression.Lambda(typeof(Func<>).MakeGenericType(expression.Type), expression)
          .Compile().DynamicInvoke();
    }

    public IEnumerator<TResult> GetEnumerator()
    {
      return Result.GetEnumerator();
    }

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      return Result.GetEnumerator();
    }

    #region IQueryProvider Members

    IQueryable<TElement> IQueryProvider.CreateQuery<TElement>(Expression expression)
    {
      MethodCallExpression call = (MethodCallExpression)expression;
      switch (call.Method.Name)
      {
        case "Where":
          HandleWhereCall(call);
          break;
        case "Select":
          HandleSelectCall(call);
          break;
      }

      foreach (var crit in CurrentCriterions)
      {
        rootCriteria.Add(crit);
      }
      return new NHibernateLinqQuery<TElement>(session, rootCriteria, criterionStack);
    }

    IQueryable IQueryProvider.CreateQuery(Expression expression)
    {
      throw new NotImplementedException();
    }

    TElement IQueryProvider.Execute<TElement>(Expression expression)
    {
      MethodCallExpression call = (MethodCallExpression)expression;
      switch (call.Method.Name)
      {
        case "First":
          return First<TElement>();
      }

      throw new Exception("The method " + call.Method.Name + "is not implemented.");
    }

    object IQueryProvider.Execute(Expression expression)
    {
      MethodCallExpression call = (MethodCallExpression)expression;

      throw new Exception("The method " + call.Method.Name + "is not implemented.");
    }

    #endregion

    #region IEnumerable<TResult> Members

    IEnumerator<TResult> IEnumerable<TResult>.GetEnumerator()
    {
      throw new NotImplementedException();
    }

    #endregion

    #region IQueryable Members

    Type IQueryable.ElementType
    {
      get { return typeof(TResult); }
    }

    Expression IQueryable.Expression
    {
      get { return System.Linq.Expressions.Expression.Constant(this); }
    }

    IQueryProvider IQueryable.Provider
    {
      get { return this; }
    }

    #endregion
  }


}
