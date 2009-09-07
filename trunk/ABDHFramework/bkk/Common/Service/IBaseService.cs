using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.Data;
using Superior.MobileMedics.Common.Domain;

namespace Superior.MobileMedics.Common.Service
{
  public interface IBaseService<TIdentifier, T> where T: DomainBase<TIdentifier>, new ()
  {
    T GetByID(TIdentifier id);
    T GetByID(TIdentifier id, string[] nestedPathsToInitialize);
    T Insert(T obj);
    bool Insert(IList<T> objs);
    bool Update(IList<T> objs);
    T Update(T obj);
    IList<T> GetAll();
    void Delete(T obj);
    void Delete(TIdentifier id);
    SearchResult<T> Search(ISearchQuery query);
    T CreateNewTransientDomain();

    /// <summary>
    /// get by dictionary
    /// 
    /// Ex: GetByKeys(new {InsuranceID = new Guid("11111111111"});
    /// </summary>
    /// <param name="dic"></param>
    /// <returns></returns>
    IList<T> GetByKeys(Object dic);


    /// <summary>
    /// get pager by dictionary
    /// </summary>
    /// <param name="dic"></param>
    /// <param name="page"></param>
    /// <param name="limit"></param>
    /// <returns></returns>
    BasePager<T> GetPagerByKeys(object dic, int page, int limit);

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
    /// delete by dictionary
    /// 
    /// Ex: DeleteByKeys(new {InsuranceID = new Guid("11111111111"});
    /// </summary>
    /// <param name="dic"></param>
    void DeleteByKeys(Object dic);

    /// <summary>
    /// update by keys
    /// 
    /// Ex: UpdateByKey(new {Property1 = "Value 1", Property2 = "Value 1"}, new {InsuranceID = "1111"})
    /// </summary>
    /// <param name="where"></param>
    /// <param name="set"></param>
    void UpdateByKeys(object set, object where);
    
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
