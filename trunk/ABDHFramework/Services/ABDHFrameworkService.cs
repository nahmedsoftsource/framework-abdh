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
       
    }
}
