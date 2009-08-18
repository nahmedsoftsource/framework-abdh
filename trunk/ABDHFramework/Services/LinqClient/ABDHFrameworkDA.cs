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
        //ABDHFrameworkDataContext _dataContext = new ABDHFrameworkDataContext(@"Data Source=VUBAO-PC\SQLEXPRESS;Initial Catalog=ABDHFramework;User ID=sa;Password=vubao29");
      ABDHFrameworkDataContext _dataContext = new ABDHFrameworkDataContext();
       
        public tblProduct GetProductByID(Guid newID,bool isEN)
        {
            if (isEN)
            {
                var query = _dataContext.tblProducts.Where("ID.ToString()=@0 and ProductNameEN != null", newID.ToString());
                if (query.ToList().Count() > 0)
                {
                    tblProduct tblnew = query.ToList().First();
                    return tblnew;
                }
            }
            else
            {
                var query = _dataContext.tblProducts.Where("ID.ToString()=@0 and ProductNameVN != null", newID.ToString());
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
                    query.First().PriceEN = tblproduct.PriceEN;
                    query.First().PriceVN = tblproduct.PriceVN;
                    query.First().ProductNameEN = tblproduct.ProductNameEN;
                    query.First().ProductNameVN = tblproduct.ProductNameVN;
                    query.First().ProductNo = tblproduct.ProductNo;
                    //query.First().tblCategory= tblproduct.tblCategory;
                    query.First().UpdatedBy = tblproduct.UpdatedBy;
                    query.First().UpdatedDate = DateTime.Now;
                    query.First().CreatedBy = tblproduct.CreatedBy;
                    query.First().CategoryID = tblproduct.CategoryID;
                    query.First().Description = tblproduct.Description;
                    query.First().Image = tblproduct.Image;
                    query.First().StoreStatus = tblproduct.StoreStatus;
                    query.First().Promoted = tblproduct.Promoted;
                    query.First().WarrantyTime = tblproduct.WarrantyTime;
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
       
        public SearchResult<tblProduct> GetAllProduct(int pageSize, int page,bool isEN)
        {
            SearchResult<tblProduct> searchResult = new SearchResult<tblProduct>();
            if (isEN)
            {
                var query1 = _dataContext.tblProducts.Where("ProductNameEN!=null");
                var query = _dataContext.tblProducts.Where("ProductNameEN!=null").Take(pageSize * page).Skip((page - 1) * pageSize);
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
                var query1 = _dataContext.tblProducts.Where("ProductNameVN!=null");
                var query = _dataContext.tblProducts.Where("ProductNameVN!=null").Take(pageSize * page).Skip((page - 1) * pageSize);
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
        public SearchResult<tblProduct> SearchProduct(int pageSize, int page,String sortColunm,String sortOption)
        {
          SearchResult<tblProduct> searchResult = new SearchResult<tblProduct>();
          var query1 = _dataContext.tblProducts.Where("ProductNameVN!=null");
          var query = _dataContext.tblProducts
                      .Where("ProductNameVN!=null")
                      .Take(pageSize * page)
                      .Skip((page - 1) * pageSize)
                      .OrderBy(sortColunm);
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
