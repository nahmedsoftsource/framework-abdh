using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Superior.MobileMedics.Common.DataAccess.NHibernateClient;
using Superior.MobileMedics.Common.DataAccess;
using Superior.Data;
using System.Reflection;
using Superior.MobileMedics.Common.Validation;
using System.Web.Routing;
using Superior.Framework.Exception;
using System.ComponentModel;

namespace Superior.MobileMedics.Common.Service
{
  public class BaseService<TIdentifier, T> : IBaseService<TIdentifier, T> where T: DomainBase<TIdentifier>, new ()
  {
    #region Private members
    private Type _persitentType = typeof(T);
    #endregion

    #region Constructors
    protected BaseService()
    {
      SetBaseDA();
    }
    #endregion

    #region Properties
    protected IBaseDA<TIdentifier, T> _baseDA;
    public IBaseDA<TIdentifier, T> GetBaseDA()
    {
      return this._baseDA;
    }
    #endregion

    #region Implementation of methods from the interface
    public T GetByID(TIdentifier id)
    {
      using (ConnectionScope.Enter())
      {
        return _baseDA.GetByID(id);
      }
    }

    public T GetByID(TIdentifier id, string[] nestedPathsToInitialize)
    {
      using (ConnectionScope.Enter())
      {
        return _baseDA.GetByID(id, nestedPathsToInitialize);
      }
    }

    public T Insert(T obj)
    {
      bool isNew = false;
      try
      {
        using (var txn = TransactionScope.Enter())
        {
          BeforeInsert(obj);
          Validate(obj);
          if (obj.IsNew)
          {
            isNew = true;
            // force new id if the interface doesn't assign it
            obj.ID = Identifiers.IdGeneratorContainer.GetInstance<TIdentifier>().GenerateId();
          }
          T ret = _baseDA.Insert(obj);
          AfterInsert(obj);
          txn.Commit();
          return ret;
        }
      }
      catch
      {
        if (isNew)
        {
          obj.ID = default(TIdentifier);
        }
        throw;
      }
    }

    public bool Insert(IList<T> objs)
    {
      bool isNew = false;
      try
      {
        using (var txn = TransactionScope.Enter())
        {
          BeforeInsert(objs);
          foreach (var obj in objs)
          {
            BeforeInsert(obj);
            Validate(obj);
            if (obj.IsNew)
            {
              isNew = true;
              // force new id if the interface doesn't assign it
              obj.ID = Identifiers.IdGeneratorContainer.GetInstance<TIdentifier>().GenerateId();
            }
            T ret = _baseDA.Insert(obj);
            AfterInsert(obj);  
          }
          AfterInsert(objs);  
          txn.Commit();
          return true;
        }
      }
      catch
      {
        if (isNew)
        {
          foreach (var obj in objs)
          {
            obj.ID = default(TIdentifier);
          }
        }
        throw;
      }
    }

    public T Update(T obj)
    {
      using (var txn = TransactionScope.Enter())
      {
        BeforeUpdate(obj);
        Validate(obj);
        T ret = _baseDA.Update(obj);
        AfterUpdate(obj);
        txn.Commit();
        return ret;
      }
    }

    public bool Update(IList<T> objs)
    {
      try
      {
        using (var txn = TransactionScope.Enter())
        {
          BeforeUpdate(objs);
          foreach (var obj in objs)
          {
            BeforeUpdate(obj);
            Validate(obj);
            T ret = _baseDA.Update(obj);
            AfterUpdate(obj);
          }
          AfterUpdate(objs);
          txn.Commit();
          return true;
        }
      }
      catch
      {
        throw;
      }
    }

    public T InsertOrUpdate(T obj)
    {
      if (obj.IsNew)
      {
        return Insert(obj);
      }
      return Update(obj);
    }

    protected virtual void BeforeDelete(T obj)
    {
      //do nothing
    }

    public virtual void Delete(T obj)
    {
      using (var txn = TransactionScope.Enter())
      {
        ISoftDeletable deletableObj = obj as ISoftDeletable;
        if (obj == null || (deletableObj != null && deletableObj.DeletedDate.HasValue))
        {
          throw new ObjectNotFoundException();
        }
        BeforeDelete(obj);
        _baseDA.Delete(obj);
        txn.Commit();
      }
    }

    public virtual void Delete(TIdentifier id)
    {
      using (var txn = TransactionScope.Enter())
      {
        T obj = GetByID(id);
        ISoftDeletable deletableObj = obj as ISoftDeletable;
        if (obj == null || (deletableObj != null && deletableObj.DeletedDate.HasValue))
        {
          throw new ObjectNotFoundException();
        }
        BeforeDelete(obj);
        _baseDA.Delete(obj);
        txn.Commit();
      }
    }

    public IList<T> GetAll()
    {
      using (ConnectionScope.Enter())
      {
        return _baseDA.GetAll();
      }
    }

    public SearchResult<T> Search(ISearchQuery query)
    {
      using (ConnectionScope.Enter())
      {
        return _baseDA.Search(query);
      }
    }

    protected virtual void Validate(T obj)
    {
      ValidationErrorCollection errorCollection = new ValidationErrorCollection();
      errorCollection.Add(obj.Validate());
      OnValidating(obj, errorCollection);
      if (errorCollection.Count > 0)
      {
        throw new ValidationException(errorCollection);
      }
    }

    public IList<T> GetByKeys(object dic)
    {
      using (ConnectionScope.Enter())
      {
        return _baseDA.GetByKeys(dic);
      }
    }

    public BasePager<T> GetPagerByKeys(object dic, int page, int limit)
    {
      using (ConnectionScope.Enter())
      {
        return _baseDA.GetPagerByKeys(dic, page, limit);
      }
    }

    public BasePager<T> GetPagerByKeys(object dic, int page, int limit, string orderBy)
    {
      using (ConnectionScope.Enter())
      {
        return _baseDA.GetPagerByKeys(dic, page, limit, orderBy);
      }
    }

    public IList<T> GetNewestByKeys(object dic, int limit, string OrderBy)
    {
      using (ConnectionScope.Enter())
      {
        return _baseDA.GetNewestByKeys(dic, limit, OrderBy);
      }
    }

    public void DeleteByKeys(object dic)
    {
      using (ConnectionScope.Enter())
      {
        _baseDA.DeleteByKeys(dic);
      }
    }

    public void UpdateByKeys(object set, object where)
    {
      using (ConnectionScope.Enter())
      {
        var objs = GetByKeys(where);
        var values = new RouteValueDictionary(set);

        foreach (var obj in objs)
        {
          foreach (var prop in TypeDescriptor.GetProperties(obj).Cast<PropertyDescriptor>())
          {
            if (values.ContainsKey(prop.Name))
            {
              prop.SetValue(obj, values[prop.Name]);
            }
          }

          Update(obj);
        }
      }
    }

    #endregion

    #region Virtual Methods
    public virtual T CreateNewTransientDomain()
    {
      return new T();
    }

    protected virtual void SetBaseDA()
    {
      _baseDA = new BaseDA<TIdentifier, T>();
    }

    protected virtual void BeforeInsert(T obj)
    {
      //do nothing
    }

    protected virtual void AfterInsert(T obj)
    {
      //do nothing
    }

    protected virtual void BeforeUpdate(T obj)
    {
      //do nothing
    }

    protected virtual void AfterUpdate(T obj)
    {
      //do nothing
    }

    protected virtual void OnValidating(T obj, ValidationErrorCollection errorCollection)
    {
      //do nothing
    }

    protected virtual void BeforeInsert(IList<T> obj)
    {
      //do nothing
    }

    protected virtual void AfterInsert(IList<T> obj)
    {
      //do nothing
    }

    protected virtual void BeforeUpdate(IList<T> obj)
    {
      //do nothing
    }

    protected virtual void AfterUpdate(IList<T> obj)
    {
      //do nothing
    }

    #endregion



  }
}
