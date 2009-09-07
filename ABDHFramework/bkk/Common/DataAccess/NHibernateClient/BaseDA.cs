using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Expression;
using Superior.Data;
using Superior.Data.NHibernateClient;
using Superior.MobileMedics.Common.DataAccess.NHibernateClient;
using Superior.Data.Queries;
using System.Data;
using System.Web.Routing;
using System.Collections;
using Superior.Framework;

namespace Superior.MobileMedics.Common.DataAccess.NHibernateClient
{
  public class BaseDA<TIdentifier, T> : IBaseDA<TIdentifier, T> where T : DomainBase<TIdentifier>
  {
    #region Private members
    private Type persitentType = typeof(T);
    protected ISession NHibernateSession
    {
      get
      {
        // return NHibernateSessionManager.Instance.GetSession();
        return Superior.Data.NHibernateClient.NHibernateClientProvider.CurrentSession;
      }
    }
    #endregion

    #region Implement methods from the interface
    /// <summary>
    /// Get Domain by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public T GetByID(TIdentifier id)
    {
      using (ConnectionScope.Enter())
      {
        T entity;
        entity = (T)NHibernateSession.Get(persitentType, id);
        ISoftDeletable softDeletable = entity as ISoftDeletable;
        if (softDeletable != null && softDeletable.DeletedDate != null)
          entity = default(T);
        return entity;
      }
    }

    /// <summary>
    /// Get Domain by ID with 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="nestedPathsToInitialize"></param>
    /// <returns></returns>
    public T GetByID(TIdentifier id, string[] nestedPathsToInitialize)
    {
      using (ConnectionScope.Enter())
      {
        T obj = GetByID(id);
        NHibernateInitializer.Initialize(obj, nestedPathsToInitialize);

        return obj;
      }
    }

    /// <summary>
    /// Insert a domain
    /// </summary>
    /// <param name="obj">Domain</param>
    /// <returns></returns>
    public T Insert(T obj)
    {
      using (ConnectionScope.Enter())
      {
        ISoftDeletable softDeletable = obj as ISoftDeletable;
        if (softDeletable != null)
        {
          softDeletable.CreatedDate = DateTime.Now;
          softDeletable.ModifiedDate = DateTime.Now;
        }
        TIdentifier id = (TIdentifier)NHibernateSession.Save(obj);
        obj = GetByID(id);

        return obj;
      }
    }

    /// <summary>
    /// Update Domain
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public T Update(T obj)
    {
      using (ConnectionScope.Enter())
      {
        if (obj.IsNew)
        {
          throw new DataException("Cannot insert empty key into ID field");
        }
        ISoftDeletable softDeletable = obj as ISoftDeletable;
        if (softDeletable != null)
        {
          softDeletable.ModifiedDate = DateTime.Now;
        }
        NHibernateSession.Update(obj);
        return obj;
      }
    }

    /// <summary>
    /// Delete Domain
    /// </summary>
    /// <param name="obj"></param>
    public virtual void Delete(T obj)
    {
      using (ConnectionScope.Enter())
      {
        if (!typeof(ISoftDeletable).IsAssignableFrom(typeof(T)))
        {
          NHibernateSession.Delete(obj);
        }
        else
        {
          System.Reflection.PropertyInfo deletedDate = obj.GetType().GetProperty("DeletedDate");
          if (deletedDate != null)
            deletedDate.SetValue(obj, DateTime.Now, null);
          NHibernateSession.Update(obj);
        }
      }
    }

    /// <summary>
    /// Delete Domain by ID
    /// </summary>
    /// <param name="id"></param>
    public void Delete(TIdentifier id)
    {
      using (ConnectionScope.Enter())
      {
        T domain = GetByID(id);
        Delete(domain);
      }
    }

    public void DeleteByKeys(object dic)
    {
      using (ConnectionScope.Enter())
      {
        var values = new RouteValueDictionary(dic);
        var c = NHibernateSession.CreateCriteria(typeof(T));

        //var query = "DELETE FROM InsuranceForm WHERE ";
        //var terms = new List<String>();
        //var data = new List<Object>();
        // stupid solution
        foreach (var kvp in values)
        {
          if (kvp.Value is DBOperator)
          {
            var dbop = kvp.Value as DBOperator;
            switch (dbop.Operator)
            {
              case DBOperator.OperatorType.In:
                c.Add(Expression.In(kvp.Key, dbop.Value as ICollection));
                break;
              case DBOperator.OperatorType.NotIn:
                c.Add(Expression.Not(Expression.In(kvp.Key, dbop.Value as ICollection)));
                break;
              default:
                break;
            }
          }
          else if (kvp.Value is ICollection)
          {
            c.Add(Expression.In(kvp.Key, kvp.Value as ICollection));
          }
          else
          {
            c.Add(Expression.Eq(kvp.Key, kvp.Value));
          }
          //terms.Add(kvp.Key + " = :"+kvp.Key);
        }

        foreach (var item in c.List<T>())
        {
          NHibernateSession.Delete(item);
        }
        NHibernateSession.Flush();

        //query += String.Join(" AND ", terms.ToArray());

        //var q = NHibernateSession.CreateSQLQuery(query);
        //foreach (var kvp in values)
        //{
        //  q.SetParameter(kvp.Key, kvp.Value);
        //}

        //q.UniqueResult();
        //NHibernateSession.Delete(query);
        //, data.ToArray(), typeof(T));
      }
    }

    /// <summary>
    /// Search domains by Search Query (paging, sorting)
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public SearchResult<T> Search(ISearchQuery query)
    {
      using (ConnectionScope.Enter())
      {
        return Search(query, null);
      }
    }

    /// <summary>
    /// Search domains by Search Query with loading child domains
    /// </summary>
    /// <param name="query"></param>
    /// <param name="nestedPathsToInitialize"></param>
    /// <returns></returns>
    public SearchResult<T> Search(ISearchQuery query, string[] nestedPathsToInitialize)
    {
      using (ConnectionScope.Enter())
      {
        SearchResult<T> result = Search<T>(query);
        if (result.Items.Count == 0 && result.TotalRows > 0)
        {
          result = Search<T>(query.SetPage(result.LastPage));
        }
        return result;
      }
    }

    /// <summary>
    /// Get all domains
    /// </summary>
    /// <returns></returns>
    public IList<T> GetAll()
    {
      using (ConnectionScope.Enter())
      {
        if (typeof(ISoftDeletable).IsAssignableFrom(typeof(T)))
        {
          return this.Search(SearchQueryBuilder.CreateQuery()).Items;
        }
        else
        {
          return this.GetByCriteria();
        }
      }
    }

    /// <summary>
    /// Get all domain with loading child domains
    /// </summary>
    /// <param name="nestedPathsToInitialize"></param>
    /// <returns></returns>
    public IList<T> GetAll(string[] nestedPathsToInitialize)
    {
      return GetAll();
    }

    /// <summary>
    /// Get domains by using HQL
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public IList<Object> GetByQuery(String query)
    {
      using (ConnectionScope.Enter())
      {
        return NHibernateSession.CreateQuery(query).List<Object>();
      }
    }

    public IList<T> GetDomainsByQuery(String query)
    {
      using (ConnectionScope.Enter())
      {
        return NHibernateSession.CreateQuery(query).List<T>();
      }
    }

    #endregion

    #region Internal Methods
    internal ICriteria GenerateCriteria<Y>(ISearchQuery query, bool includeOrder, bool includePaging)
    {
      //build search criteria
      ICriteria criteria = NHibernateSession.CreateCriteria(typeof(Y));

      //criteria
      IList<string> completedAliases = new List<string>();
      if (query.HasCriteria)
      {
        criteria = ParseCriteria<Y>(query.GetCriteria());
        IList<IQueryExpression> expressions = new List<IQueryExpression>(query.Expressions.Values);
        foreach (QueryExpression expression in expressions)
        {
          switch (expression.ExpressionType)
          {
            case ExpressionType.Equals:
              criteria.Add(Expression.Eq(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName), expression.Value));
              break;
            case ExpressionType.EqualsProperty:
              criteria.Add(Expression.EqProperty(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName), expression.OtherPropertyName));
              break;
            case ExpressionType.GreaterThan:
              criteria.Add(Expression.Gt(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName), expression.Value));
              break;
            case ExpressionType.GreaterThanProperty:
              criteria.Add(Expression.GtProperty(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName), expression.OtherPropertyName));
              break;
            case ExpressionType.GreaterThanOrEquals:
              criteria.Add(Expression.Ge(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName), expression.Value));
              break;
            case ExpressionType.GreaterThanOrEqualsProperty:
              criteria.Add(Expression.GeProperty(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName), expression.OtherPropertyName));
              break;
            case ExpressionType.LessThan:
              criteria.Add(Expression.Lt(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName), expression.Value));
              break;
            case ExpressionType.LessThanProperty:
              criteria.Add(Expression.LtProperty(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName), expression.OtherPropertyName));
              break;
            case ExpressionType.LessThanOrEquals:
              criteria.Add(Expression.Le(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName), expression.Value));
              break;
            case ExpressionType.LessThanOrEqualsProperty:
              criteria.Add(Expression.LeProperty(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName), expression.OtherPropertyName));
              break;
            case ExpressionType.NotEquals:
              criteria.Add(Expression.Not(Expression.Eq(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName), expression.Value)));
              break;
            case ExpressionType.NotEqualsProperty:
              criteria.Add(Expression.Not(Expression.EqProperty(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName), expression.OtherPropertyName)));
              break;
            case ExpressionType.Contains:
              criteria.Add(Expression.Like(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName), "%" + expression.Value + "%"));
              break;
            case ExpressionType.NotContaints:
              criteria.Add(Expression.Not(Expression.Like((this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName)), "%" + expression.Value + "%")));
              break;
            case ExpressionType.IsNull:
              criteria.Add(Expression.IsNull(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName)));
              break;
            case ExpressionType.IsNotNull:
              criteria.Add(Expression.IsNotNull(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName)));
              break;
            case ExpressionType.In:
              criteria.Add(Expression.In(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName), expression.CollectionValues));
              break;
            case ExpressionType.IsEmpty:
              criteria.Add(Expression.IsEmpty(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName)));
              break;
            case ExpressionType.IsNotEmpty:
              criteria.Add(Expression.IsNotEmpty(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName)));
              break;
            case ExpressionType.Between:
              criteria.Add(Expression.Between(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName), expression.CollectionValues[0], expression.CollectionValues[1]));
              break;
            case ExpressionType.SQL:
              criteria.Add(Expression.Sql(expression.QuerySQL));
              break;
            default:
              criteria.Add(Expression.Like(this.CreateCriteriaAlias(completedAliases, criteria, expression.PropertyName), "%" + expression.Value + "%"));
              break;
          }
        }
      }
      criteria.SetResultTransformer(new NHibernate.Transform.DistinctRootEntityResultTransformer());


      //order
      if (includeOrder && query.HasOrderClause)
      {
        foreach (ISortOrder order in query.OrderClauses)
        {
          if (order.IsAscending)
            criteria.AddOrder(Order.Asc(this.CreateCriteriaAlias(completedAliases, criteria, order.PropertyName)));
          else
            criteria.AddOrder(Order.Desc(this.CreateCriteriaAlias(completedAliases, criteria, order.PropertyName)));
        }
      }

      //paging
      if (includePaging && query.HasPaging)
      {
        criteria.SetMaxResults(query.GetMaxResults());
        criteria.SetFirstResult(query.GetFirstResult());
      }

      return criteria;
    }

    internal SearchResult<Y> Search<Y>(ISearchQuery query)
    {
      using (ConnectionScope.Enter())
      {
        SearchResult<Y> result = new SearchResult<Y>();
        if (typeof(ISoftDeletable).IsAssignableFrom(typeof(T)) && !query.Expressions.ContainsKey("DeletedDate"))
        {
          query.Where("DeletedDate").IsNull();
        }
        BeforeSearch(query);

        //get total rows of search result for all pages
        ICriteria criteria = GenerateCriteria<Y>(query, false, false);
        result.TotalRows = criteria.SetProjection(Projections.RowCount()).UniqueResult<int>();

        criteria = GenerateCriteria<Y>(query, true, true);
        result.Items = criteria.List<Y>();
        result.Query = query;

        return result;
      }
    }

    protected virtual void BeforeSearch(ISearchQuery query)
    {

    }

    internal IList<Y> GetAll<Y>()
    {
      using (ConnectionScope.Enter())
      {
        ICriteria criteria = NHibernateSession.CreateCriteria(typeof(Y));
        return criteria.List<Y>() as List<Y>;
      }
    }

    internal Y GetMetadataObject<Y>(TIdentifier id)
    {
      using (ConnectionScope.Enter())
      {
        return (Y)NHibernateSession.Load(typeof(Y), id);
      }
    }
    #endregion

    #region Virtual Methods
    protected virtual ICriteria ParseCriteria<Y>(SearchCriteria searchCriteria)
    {
      return NHibernateSession.CreateCriteria(typeof(Y));
    }
    #endregion

    #region Private Methods
    private List<T> GetByCriteria(params ICriterion[] criterion)
    {
      ICriteria criteria = NHibernateSession.CreateCriteria(persitentType);

      foreach (ICriterion criterium in criterion)
      {
        criteria.Add(criterium);
      }

      return criteria.List<T>() as List<T>;
    }

    /// <summary>
    /// Create alias for searching by criteria
    /// </summary>
    /// <param name="criteria"></param>
    /// <param name="propertyName"></param>
    /// <returns></returns>
    private string CreateCriteriaAlias(IList<string> completedAliases, ICriteria criteria, string propertyName)
    {
      string aliasName = "";
      string pathName = "";
      string[] propertyNames = propertyName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
      if (propertyNames.Length <= 1)
        return propertyName;

      for (int i = 0; i < propertyNames.Length - 1; i++)
      {
        if (i > 0)
        {
          pathName = aliasName + "." + propertyNames[i];
          aliasName = aliasName + propertyNames[i];
        }
        else
        {
          pathName = propertyNames[i];
          aliasName = propertyNames[i];
        }
        if (!completedAliases.Contains(aliasName))
        {
          criteria = criteria.CreateAlias(pathName, aliasName, NHibernate.SqlCommand.JoinType.LeftOuterJoin);
          completedAliases.Add(aliasName);
        }
      }

      return aliasName + "." + propertyNames[propertyNames.Length - 1];
    }

    #endregion

    #region IBaseDA<TIdentifier,T> Members


    public IList<T> GetByKeys(object dic)
    {
      using (ConnectionScope.Enter())
      {
        var values = new RouteValueDictionary(dic);

        var c = NHibernateSession.CreateCriteria(typeof(T));

        foreach (var kvp in values)
        {
          if (kvp.Value is AnonymousObjectNull)
          {
            var value = kvp.Value as AnonymousObjectNull;

            if (value == AnonymousObjectNull.NullValue)
            {
              c.Add(Expression.IsNull(kvp.Key));
            }
            else if (value == AnonymousObjectNull.NotNullValue)
            {
              c.Add(Expression.IsNotNull(kvp.Key));
            }
          }
          else
          {
            c.Add(Expression.Eq(kvp.Key, kvp.Value));
          }
        }

        return c.List<T>();
      }
    }

    public BasePager<T> GetPagerByKeys(object dic, int page, int limit)
    {
      using (ConnectionScope.Enter())
      {
        var values = new RouteValueDictionary(dic);
        var c = NHibernateSession.CreateCriteria(typeof(T));
        foreach (var kvp in values)
        {
          if (kvp.Value is AnonymousObjectNull)
          {
            var value = kvp.Value as AnonymousObjectNull;

            if (value == AnonymousObjectNull.NullValue)
            {
              c.Add(Expression.IsNull(kvp.Key));
            }
            else if (value == AnonymousObjectNull.NotNullValue)
            {
              c.Add(Expression.IsNotNull(kvp.Key));
            }
          }
          else
          {
            c.Add(Expression.Eq(kvp.Key, kvp.Value));
          }
        }
        return new CriteriaPager<T>(c, page, limit);
      }
    }

    public BasePager<T> GetPagerByKeys(object dic, int page, int limit, string orderBy)
    {
      using (ConnectionScope.Enter())
      {
        var values = new RouteValueDictionary(dic);
        var c = NHibernateSession.CreateCriteria(typeof(T));
        foreach (var kvp in values)
        {
          c.Add(Expression.Eq(kvp.Key, kvp.Value));
        }
        if (!string.IsNullOrEmpty(orderBy))
        {
          c.AddOrder(Order.Desc(orderBy));
        }
        return new CriteriaPager<T>(c, page, limit);
      }
    }
    /// <summary>
    /// Get number of latest<T> by set of property
    /// </summary>
    /// <param name="dic"></param>
    /// <param name="limit"></param>
    /// <param name="OrderBy"></param>
    /// <returns></returns>
    public IList<T> GetNewestByKeys(object dic, int limit, string OrderBy)
    {
      using (ConnectionScope.Enter())
      {
        var values = new RouteValueDictionary(dic);
        var c = NHibernateSession.CreateCriteria(typeof(T));
        foreach (var kvp in values)
        {
          c.Add(Expression.Eq(kvp.Key, kvp.Value));
        }
        if (!string.IsNullOrEmpty(OrderBy))
        {
          c.AddOrder(Order.Desc(OrderBy));
        }
        c.SetMaxResults(limit);

        return c.List<T>();
      }
    }

    #endregion
  }
}
