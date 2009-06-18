using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABDH_Demo.Data
{
  public interface ISearchQuery
  {
    #region Criteria

    /// <summary>
    /// Gets the expressions.
    /// </summary>
    /// <value>The expressions.</value>
    IDictionary<string, IQueryExpression> Expressions { get; }

    /// <summary>
    /// Sets the criteria. Used for method chaining.
    /// </summary>
    /// <param name="criteria">The criteria.</param>
    /// <returns></returns>
    ISearchQuery SetCriteria(SearchCriteria criteria);

    /// <summary>
    /// Gets the criteria.
    /// </summary>
    /// <returns></returns>
    SearchCriteria GetCriteria();

    /// <summary>
    /// Adds an expression. Used for method chaining.
    /// </summary>
    /// <param name="propertyName">Name of the property.</param>
    /// <returns></returns>
    IQueryExpression Where(string propertyName);

    #endregion

    #region Order by

    /// <summary>
    /// Gets the order clauses.
    /// </summary>
    /// <value>The order clauses.</value>
    IList<ISortOrder> OrderClauses { get; }

    /// <summary>
    /// Orders by property.
    /// </summary>
    /// <param name="propertyName">Name of the property.</param>
    /// <returns></returns>
    ISearchQuery OrderBy(string propertyName);

    /// <summary>
    /// Orders descending by property.
    /// </summary>
    /// <param name="propertyName">Name of the property.</param>
    /// <returns></returns>
    ISearchQuery OrderByDescending(string propertyName);

    #endregion

    #region Paging

    /// <summary>
    /// Sets the page.
    /// </summary>
    /// <param name="page">The page.</param>
    /// <returns></returns>
    ISearchQuery SetPage(int page);


    /// <summary>
    /// Gets the page.
    /// </summary>
    /// <returns></returns>
    int GetPage();

    /// <summary>
    /// Sets the first result.
    /// </summary>
    /// <param name="firstResult">The first result.</param>
    /// <returns></returns>
    ISearchQuery SetFirstResult(int firstResult);

    /// <summary>
    /// Gets the first result.
    /// </summary>
    /// <returns></returns>
    int GetFirstResult();

    /// <summary>
    /// Sets the max results.
    /// </summary>
    /// <param name="maxResults">The max results.</param>
    /// <returns></returns>
    ISearchQuery SetMaxResults(int maxResults);

    /// <summary>
    /// Gets the max results.
    /// </summary>
    /// <returns></returns>
    int GetMaxResults();

    /// <summary>
    /// Gets a value indicating whether this instance has criteria.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has criteria; otherwise, <c>false</c>.
    /// </value>
    bool HasCriteria { get; }

    /// <summary>
    /// Gets a value indicating whether this instance has order clause.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has order clause; otherwise, <c>false</c>.
    /// </value>
    bool HasOrderClause { get; }

    /// <summary>
    /// Gets a value indicating whether this instance has paging.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance has paging; otherwise, <c>false</c>.
    /// </value>
    bool HasPaging { get; }

    #endregion
  }
}
