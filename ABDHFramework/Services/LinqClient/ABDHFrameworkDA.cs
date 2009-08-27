using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABDHFramework.Models;
using System.Linq.Dynamic;
using ABDHFramework.Data.Queries;
using ABDHFramework.Data;
using System.Configuration.Provider;
namespace ABDHFramework.Services.LinqClient
{
    public class ABDHFrameworkDA
    {
        ABDHFrameworkDataContext _dataContext = new ABDHFrameworkDataContext();
        public SearchResult<tblNew> SearchNews(int pageSize, int page, String sortColunm, String sortOption)
        {
          SearchResult<tblNew> searchResult = new SearchResult<tblNew>();
          var query1 = _dataContext.tblNews.Where("Title!=null");
          var query = query1;
          if (sortColunm == "Title")
          {
            if (sortOption == ABDHFramework.Data.SortOption.Desc.ToString())
            {
              query = _dataContext.tblNews
                .Where("Title!=null")
                .OrderByDescending(o => o.Title)
                .Take(pageSize * page)
                .Skip((page - 1) * pageSize)
                ;
            }
            else
            {
              query = _dataContext.tblNews
                .Where("Title!=null")
                .OrderBy(o => o.Title)
                .Take(pageSize * page)
                .Skip((page - 1) * pageSize)
                ;
            }
          }
          else
          {
              query = _dataContext.tblNews
              .Where("Title!=null")
              .Take(pageSize * page)
              .Skip((page - 1) * pageSize);
          }
          if (query != null && query1 != null && query.ToList().Count > 0)
          {
            searchResult.Items = query.ToList();
            searchResult.Query = query;
            searchResult.SetMaxResults(pageSize);
            searchResult.SetPage(page);
            searchResult.TotalRows = query1.Count();
          }
          return searchResult;
        }
        public SearchResult<tblNew> SearchNewsByCriteria(int pageSize, int page,String criteria, String sortColunm, String sortOption)
        {
          SearchResult<tblNew> searchResult = new SearchResult<tblNew>();
          //criteria = "%" + criteria + "%";
          //var query1 = _dataContext.tblNews.Where("Title like  @0", criteria);
          var query1 = _dataContext.tblNews.Where(op=>op.Title.Contains(criteria));
          var query = query1;
          if (sortColunm == "Title")
          {
            if (sortOption == ABDHFramework.Data.SortOption.Desc.ToString())
            {
              query = _dataContext.tblNews
                .Where(op => op.Title.Contains(criteria))
                .OrderByDescending(o => o.Title)
                .Take(pageSize * page)
                .Skip((page - 1) * pageSize)
                ;
            }
            else
            {
              query = _dataContext.tblNews
                .Where(op => op.Title.Contains(criteria))
                .OrderBy(o => o.Title)
                .Take(pageSize * page)
                .Skip((page - 1) * pageSize)
                ;
            }
          }
          else
          {
            query = _dataContext.tblNews
            .Where(op => op.Title.Contains(criteria))
            .Take(pageSize * page)
            .Skip((page - 1) * pageSize);
          }
          if (query != null && query1 != null && query.ToList().Count > 0)
          {
            searchResult.Items = query.ToList();
            searchResult.Query = query;
            searchResult.SetMaxResults(pageSize);
            searchResult.SetPage(page);
            searchResult.TotalRows = query1.Count();
          }
          return searchResult;
        }
        public void Delete(Guid id)
        {
            var query = _dataContext.tblNews.Where("ID.ToString()=@0", id.ToString());
            if (query != null && query.ToList().Count > 0)
            {
                try
                {
                    _dataContext.tblNews.DeleteOnSubmit(query.ToList().First());
                    _dataContext.SubmitChanges();
                }
                catch
                {
                }
            }
        }
        

        #region Category
        public void UpdateCategory(tblCategory tblcategory)
        {
            if (tblcategory != null && tblcategory.ID != null && !tblcategory.ID.Equals(Guid.Empty))
            {
                var query = _dataContext.tblCategories.Where("ID.ToString()=@0", tblcategory.ID.ToString());
                if (query != null && query.ToList().Count > 0)
                {
                    query.First().CategoryName = tblcategory.CategoryName;
                    query.First().CategoryName = tblcategory.CategoryName;
                    query.First().Description = tblcategory.Description;
                    query.First().Description = tblcategory.Description;
                    query.First().UpdatedDate = DateTime.Now;
                    _dataContext.SubmitChanges();
                }
            }
        }
        public void DeleteCategory(Guid categoryID)
        {
            if (categoryID != null && !categoryID.Equals(Guid.Empty))
            {
                var query = _dataContext.tblCategories.Where("ID.ToString()=@0", categoryID.ToString());
                if (query != null && query.ToList().Count > 0)
                {
                    try
                    {
                        _dataContext.tblCategories.DeleteOnSubmit(query.ToList().First());
                        _dataContext.SubmitChanges();
                    }
                    catch
                    {
                    }
                }
            }
        }
        public void InsertCategory(tblCategory tblnew)
        {
            if (tblnew != null && tblnew.ID != null && !tblnew.ID.Equals(Guid.Empty))
            {
                tblnew.CreatedDate = DateTime.Now;
                //todo: auto increment catagoryNo
                tblnew.CategoryNo = "1";
                _dataContext.tblCategories.InsertOnSubmit(tblnew);
                _dataContext.SubmitChanges();
            }
        }
        public List<tblCategory> GetAllCategory(bool isEN)
        {
            if (isEN)
            {
                var query = _dataContext.tblCategories.Where("CategoryName!=null");
                return ((query != null) ? query.ToList() : (new List<tblCategory>()));
            }
            else
            {
                var query = _dataContext.tblCategories.Where("CategoryName!=null");
                return ((query != null) ? query.ToList() : (new List<tblCategory>()));
            }


        }
        public List<tblCategory> GetAllCategory(bool isEN,byte level)
        {
            if (isEN)
            {
                var query = _dataContext.tblCategories.Where(item=>(item.Language.HasValue && item.Language.Value.Equals(ABDHFramework.Common.Languages.EN) && item.Level.Equals(level)));
                return ((query != null) ? query.ToList() : (new List<tblCategory>()));
            }
            else
            {
                var query = _dataContext.tblCategories.Where(item => (item.Language.HasValue && item.Language.Value.Equals(ABDHFramework.Common.Languages.VN) && item.Level.Equals(level)));
                return ((query != null) ? query.ToList() : (new List<tblCategory>()));
            }


        }
        public SearchResult<tblCategory> GetAllCategory(int pageSize, int page, bool isEN, string criteria, String sortColunm, String sortOption)
        {
            isEN = false;
            SearchResult<tblCategory> searchResult = new SearchResult<tblCategory>();
            if (!isEN)
            {
              var query1 = _dataContext.tblCategories.Where("CategoryName!=null");
                var query = query1;
                if (sortColunm == "CategoryName")
                {
                  if (sortOption == ABDHFramework.Data.SortOption.Desc.ToString())
                  {
                    query = _dataContext.tblCategories
                    .Where(op => op.CategoryName.Contains(criteria))
                    .OrderByDescending(o => o.CategoryName)
                    .Take(pageSize * page)
                    .Skip((page - 1) * pageSize)
                    ;
                  }
                  else
                  {
                    query = _dataContext.tblCategories
                   .Where(op => op.CategoryName.Contains(criteria))
                   .OrderBy(o => o.CategoryName)
                   .Take(pageSize * page)
                   .Skip((page - 1) * pageSize)
                   ;
                  }
                  
                  
                }
                else
                {

                    query = _dataContext.tblCategories
                    .Where(op => op.CategoryName.Contains(criteria))
                    .OrderByDescending(o => o.CategoryName)
                    .Take(pageSize * page)
                    .Skip((page - 1) * pageSize)
                    ;
                }
                if (query != null && query1 != null && query.ToList().Count > 0)
                {
                  searchResult.Items = query.ToList();
                  searchResult.Query = query;
                  searchResult.SetMaxResults(pageSize);
                  searchResult.SetPage(page);
                  searchResult.TotalRows = query1.Count();
                }
            }
            else
            {
                var query1 = _dataContext.tblCategories.Where("CategoryName!=null");
                var query = _dataContext.tblCategories.Where("CategoryName!=null").Take(pageSize * page).Skip((page - 1) * pageSize);
                if (query != null && query1 != null && query.ToList().Count > 0)
                {
                    searchResult.Items = query.ToList();
                    searchResult.Query = query;
                    searchResult.SetMaxResults(pageSize);
                    searchResult.SetPage(page);
                    searchResult.TotalRows = query1.Count();
                }
            }
            return searchResult;
        }
        public SearchResult<tblProduct> GetAllProductByCategory(int pageSize, int page, Guid? categoryID)
        {
            SearchResult<tblProduct> searchResult = new SearchResult<tblProduct>();

            var query1 = _dataContext.tblProducts.Where("CategoryID.HasValue and CategoryID.Value.ToString()=@0", ((Guid)categoryID).ToString());
            var query = _dataContext.tblProducts.Where("CategoryID.HasValue and CategoryID.Value.ToString()=@0", ((Guid)categoryID).ToString()).Take(pageSize * page).Skip((page - 1) * pageSize);
            if (query != null && query1 != null && query.ToList().Count > 0)
            {
                searchResult.Items = query.ToList();
                searchResult.Query = query;
                searchResult.SetMaxResults(pageSize);
                searchResult.SetPage(page);
                searchResult.TotalRows = query1.Count();
            }

            return searchResult;
        }
        public tblCategory GetCategoryByID(Guid categoryID)
        {
            
            var query = _dataContext.tblCategories.Where("ID.ToString()=@0", categoryID.ToString());
            if (query != null && query.ToList().Count > 0)
            {
                return query.ToList().First();
            }
            return new tblCategory();
        }
        
        #endregion
        #region Product
        public tblProduct GetProductByID(Guid productID, bool isEN)
        {
          if (isEN)
          {
            var query = _dataContext.tblProducts.Where("ID.ToString()=@0 and ProductName != null", productID.ToString());
            if (query.ToList().Count() > 0)
            {
              tblProduct tblnew = query.ToList().First();
              return tblnew;
            }
          }
          else
          {
            var query = _dataContext.tblProducts.Where("ID.ToString()=@0 and ProductName != null", productID.ToString());
            if (query.ToList().Count() > 0)
            {
              tblProduct tblnew = query.ToList().First();
              return tblnew;
            }
          }
          return null;
        }
        public void UpdateProduct(tblProduct tblproduct)
        {
          if (tblproduct != null && tblproduct.ID != null && !tblproduct.ID.Equals(Guid.Empty))
          {
            var query = _dataContext.tblProducts.Where("ID.ToString()=@0", tblproduct.ID.ToString());
            if (query != null && query.ToList().Count > 0)
            {
              query.First().Price = tblproduct.Price;
              query.First().Price = tblproduct.Price;
              query.First().ProductName = tblproduct.ProductName;
              query.First().ProductName = tblproduct.ProductName;
              query.First().ProductNo = tblproduct.ProductNo;
              //query.First().tblCategory= tblproduct.tblCategory;
              query.First().UpdatedBy = tblproduct.UpdatedBy;
              query.First().UpdatedDate = DateTime.Now;
              query.First().CreatedBy = tblproduct.CreatedBy;
              query.First().CategoryID = tblproduct.CategoryID;
              query.First().Description = tblproduct.Description;
              query.First().Image = tblproduct.Image;
              query.First().Property = tblproduct.Property;
              _dataContext.SubmitChanges();
            }
          }
        }
        public void DeleteProduct(Guid productID)
        {
          if (productID != null && !productID.Equals(Guid.Empty))
          {
            var query = _dataContext.tblProducts.Where("ID.ToString()=@0", productID.ToString());
            if (query != null && query.ToList().Count > 0)
            {
              try
              {
                _dataContext.tblProducts.DeleteOnSubmit(query.ToList().First());
                _dataContext.SubmitChanges();
              }
              catch
              {
              }
            }
          }
        }
        public void InsertProduct(tblProduct tblproduct)
        {
          if (tblproduct != null && tblproduct.ID != null && !tblproduct.ID.Equals(Guid.Empty))
          {

            tblproduct.CreatedDate = DateTime.Now;
            _dataContext.tblProducts.InsertOnSubmit(tblproduct);
            _dataContext.SubmitChanges();
          }
        }
        public SearchResult<tblProduct> GetAllProduct(int pageSize, int page, bool isEN, String criteria, String sortColunm, String sortOption)
        {
          SearchResult<tblProduct> searchResult = new SearchResult<tblProduct>();
          if (isEN)
          {
            var query1 = _dataContext.tblProducts.Where(item=>item.ProductName.Contains(criteria));
            var query = _dataContext.tblProducts.Where(item => item.ProductName.Contains(criteria)).Take(pageSize * page).Skip((page - 1) * pageSize);
            if (query != null && query1 != null && query.ToList().Count > 0)
            {
              searchResult.Items = query.ToList();
              searchResult.Query = query;
              searchResult.SetMaxResults(pageSize);
              searchResult.SetPage(page);
              searchResult.TotalRows = query1.Count();
            }
          }
          else
          {
            var query1 = _dataContext.tblProducts.Where(item=>item.ProductName.Contains(criteria));
            var query = _dataContext.tblProducts.Where(item => item.ProductName.Contains(criteria)).Take(pageSize * page).Skip((page - 1) * pageSize);
            if (query != null && query1 != null && query.ToList().Count > 0)
            {
              searchResult.Items = query.ToList();
              searchResult.Query = query;
              searchResult.SetMaxResults(pageSize);
              searchResult.SetPage(page);
              searchResult.TotalRows = query1.Count();
            }
          }
          return searchResult;
        }
        public IList<tblProduct> ProductSuggestForField(string value, int limit)
        {
          var query = _dataContext.tblProducts.Where(item => item.ProductName.Contains(value)).Take(limit);
          if (query != null)return query.ToList();
          return new List<tblProduct>();
        }
        #endregion
        #region Data Access tblUser

        public bool Logon(String userName, String password)
        {
            var query = _dataContext.tblUsers.Where("UserName=@0 and Password=@1", userName, password);
            HttpContext.Current.Session["UserName"] = null;
            if (query.ToList().Count() > 0)
            {
                tblUser tbluser = query.ToList().First();
                HttpContext.Current.Session["UserName"] = tbluser.UserName;
                return true;
            }
            return false;
        }

        public bool DuplicateUsername(String username)
        {
            var query = _dataContext.tblUsers.Where("UserName=@0", username);
            if (query.ToList().Count() > 0)
                return true;
            else
                return false;
        }

        public bool DuplicateEmail(String email)
        {
            var query = _dataContext.tblUsers.Where("Email=@0", email);
            if (query.ToList().Count() > 0)
                return true;
            else
                return false;
        }

        public void Logoff()
        {
            HttpContext.Current.Session["UserName"] = null;
        }

        public tblUser GetUser(String userName,string password)
        {
            var query = _dataContext.tblUsers.Where("UserName=@0 and Password=@1", userName, password);
            if (query.ToList().Count() > 0)
            {
                tblUser tbluser = query.ToList().First();
                return tbluser;
            }
            return null;
        }

        public List<tblUser> GetUserByDepartment(byte department)
        {
            var query = _dataContext.tblUsers.Where("Department=@0", department);
            if (query.ToList().Count() > 0)
            {
                return ((query != null) ? query.ToList() : (new List<tblUser>()));
            }
            return null;
        }

        public bool ChangePassword(string username, string oldpassword, string newpassword)
        {
            tblUser tbluser = new tblUser();
            tbluser = GetUser(username, oldpassword);
            if (tbluser != null && tbluser.ID != null && !tbluser.ID.Equals(Guid.Empty))
            {
                var query = _dataContext.tblUsers.Where("ID.ToString()=@0", tbluser.ID.ToString());
                if (query != null && query.ToList().Count > 0)
                {
                    query.First().Password = newpassword;
                    _dataContext.SubmitChanges();
                }
                return true;
            }
            return false;
        }

        public bool InsertUser(tblUser tbluser)
        {
            if (tbluser != null && tbluser.ID != null && !tbluser.ID.Equals(Guid.Empty))
            {
                _dataContext.tblUsers.InsertOnSubmit(tbluser);
                _dataContext.SubmitChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region Data Access tblEmail
        public bool InsertEmail(tblEmail email)
        {
            if (email != null && email.ID != null && !email.ID.Equals(Guid.Empty))
            {
                _dataContext.tblEmails.InsertOnSubmit(email);
                _dataContext.SubmitChanges();
                return true;
            }
            return false;
        }
        #endregion

        
    }
}
