using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABDHFramework.Services.LinqClient;
using ABDHFramework.Models;
using ABDHFramework.Data;

namespace ABDHFramework.Services
{
    public class ABDHFrameworkService
    {
        ABDHFrameworkDA _da = new ABDHFrameworkDA();
        public static ABDHFrameworkService Instance
        {
            get
            {
                return new ABDHFrameworkService();
            }
        }
       
        
        
        
       
        
       

        #region Service tblUser
        public bool Logon(String userName, String password)
        {
            return _da.Logon(userName, password);
        }

        public bool DuplicateUsername(string username)
        {
            return _da.DuplicateUsername(username);
        }
        
        public bool DuplicateEmail(string email)
        {
            return _da.DuplicateEmail(email);
        }
        public void Logoff()
        {
           _da.Logoff();
        }

        public tblUser GetUser(String userName,String password)
        {
            return _da.GetUser(userName,password);
        }

        public List<tblUser> GetUserByDepartment(byte department)
        {
            return _da.GetUserByDepartment(department);
        }

        public bool InsertUser(tblUser tbluser)
        {
            return _da.InsertUser(tbluser);
        }

        public bool ChangePassword(string username,string oldpassword, string newpassword)
        {
            return _da.ChangePassword(username,oldpassword,newpassword);
        }
        #endregion

        #region Service tblEmail
        public bool InsertEmail(tblEmail email)
        {
            if(email.Sender!="" && email.Email!="" && email.Title!="" && email.Content!="")
                return _da.InsertEmail(email);
            return false;
        }
        #endregion

      
        
        public SearchResult<tblNew> SearchNews(int pageSize, int page, String sortColunm, String sortOption)
        {
          return _da.SearchNews(pageSize, page, sortColunm, sortOption);
        }
        public SearchResult<tblNew> SearchNewsByCriteria(int pageSize, int page, String criteria, String sortColunm, String sortOption)
        {
          return _da.SearchNewsByCriteria(pageSize,page,criteria,sortColunm,sortOption);
        }
        public void Delete(Guid id)
        {
             _da.Delete(id);
        }
        #region Category
        public List<tblCategory> GetAllCategory(bool isEN)
        {
          return _da.GetAllCategory(isEN);
        }
        public SearchResult<tblCategory> GetAllCategory(int pageSize, int page, bool isEN,String criteria, String sortColunm, String sortOption)
        {
          return _da.GetAllCategory(pageSize, page, isEN,criteria, sortColunm,sortOption);
        }
        public SearchResult<tblProduct> GetAllProductByCategory(int pageSize, int page, Guid? categoryID)
        {
            return _da.GetAllProductByCategory(pageSize, page, categoryID);
        }
        public tblCategory GetCategoryByID(Guid categoryID)
        {
            return _da.GetCategoryByID(categoryID);
        }
        public void DeleteCategory(Guid categoryID)
        {
            _da.DeleteCategory(categoryID);
        }
        public void UpdateCategory(tblCategory tblnew)
        {
          _da.UpdateCategory(tblnew);
        }
        public void InsertCategory(tblCategory tblnew)
        {
          _da.InsertCategory(tblnew);
        }

       
        #endregion

      #region Product
        public SearchResult<tblProduct> GetAllProduct(int pageSize, int page, bool isEN, String criteria, String sortColunm, String sortOption)
        {
          return _da.GetAllProduct(pageSize, page, isEN,criteria,sortColunm,sortOption);
        }
        public tblProduct GetProductByID(Guid productID, bool isEN)
        {
          return _da.GetProductByID(productID, isEN);
        }
        public void DeleteProduct(Guid productID)
        {
          _da.DeleteProduct(productID);
        }
        public void InsertProduct(tblProduct tblProduct)
        {
          _da.InsertProduct(tblProduct);
        }
        public void UpdateProduct(tblProduct tblproduct)
        {
          _da.UpdateProduct(tblproduct);
        }
        public IList<tblProduct> ProductSuggestForField(string value, int limit)
        {
          return _da.ProductSuggestForField(value, limit);
        }
      #endregion
    }
}
