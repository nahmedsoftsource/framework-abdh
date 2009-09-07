using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.Data;
using NHibernate;

namespace Superior.MobileMedics.Common.DataAccess
{
  public interface IBaseDA<TIdentifier, T> where T: DomainBase<TIdentifier>
  {
    T GetByID(TIdentifier id);
    T GetByID(TIdentifier id, string[] nestedPathsToInitialize);
    T Insert(T obj);
    T Update(T obj);
    void Delete(T obj);
    void DeleteByKeys(Object dic);
    void Delete(TIdentifier id);
    IList<T> GetAll();
    IList<T> GetAll(string[] nestedPathsToInitialize);
    SearchResult<T> Search(ISearchQuery query);
    SearchResult<T> Search(ISearchQuery query, string[] nestedPathsToInitialize);
    IList<Object> GetByQuery(String query);
    IList<T> GetDomainsByQuery(String query);

    /// <summary>
    /// get by dictionary
    /// 
    /// Ex: GetByFKs(new {InsuranceID = new Guid("11111111111"});
    /// </summary>
    /// <param name="dic"></param>
    /// <returns></returns>
    IList<T> GetByKeys(Object dic);

    /// <summary>
    /// Get pager by dictionary
    /// </summary>
    /// <param name="dic"></param>
    /// <param name="page"></param>
    /// <param name="limit"></param>
    /// <returns></returns>
    BasePager<T> GetPagerByKeys(Object dic, int page, int limit);
    
    /// <summary>
    /// Get pager by dictionary with sort to OrderBY
    /// </summary>
    /// <param name="dic"></param>
    /// <param name="page"></param>
    /// <param name="limit"></param>
    /// <param name="orderBy"></param>
    /// <returns></returns>
    BasePager<T> GetPagerByKeys(object dic, int page, int limit, string orderBy);

    /// <summary>
    /// Get number of latest<T> by set of property
    /// </summary>
    /// <param name="dic"></param>
    /// <param name="limit"></param>
    /// <param name="OrderBy"></param>
    /// <returns></returns>
    IList<T> GetNewestByKeys(object dic, int limit, string OrderBy);
  }
}
