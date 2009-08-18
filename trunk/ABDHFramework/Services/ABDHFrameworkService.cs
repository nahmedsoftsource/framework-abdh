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
       
        public tblProduct GetProductByID(Guid newID,bool isEN)
        {
            return _da.GetProductByID(newID,isEN);
        }
        
        public SearchResult<tblProduct> GetAllProduct(int pageSize, int page,bool isEN)
        {
            return _da.GetAllProduct(pageSize, page,isEN);
        }
       
        
        public void UpdateProduct(tblProduct tblproduct)
        {
            _da.UpdateProduct(tblproduct);
        }
        
        public void InsertProduct(tblProduct tblProduct)
        {
            _da.InsertProduct(tblProduct);
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

      
        public void DeleteProduct(Guid productID)
        {
            _da.DeleteProduct(productID);
        }
       
    }
}
