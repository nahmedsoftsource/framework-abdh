using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGUYENHIEP.Services.LinqClient;
using NGUYENHIEP.Models;
using NguyenHiep.Data;

namespace NGUYENHIEP.Services
{
    public class NguyenHiepService
    {
        NguyenHiepDA _da = new NguyenHiepDA();
        public static NguyenHiepService Instance
        {
            get
            {
                return new NguyenHiepService();
            }
        }
        public tblNew GetNewsByID(Guid newID,bool isEN)
        {
            return _da.GetNewsByID(newID,isEN);
        }
        public tblProduct GetProductByID(Guid newID,bool isEN)
        {
            return _da.GetProductByID(newID,isEN);
        }
        public SearchResult<tblNew> GetAllNews(int pageSize, int page, byte type, bool isEN)
        {
            return _da.GetAllNews(pageSize,page,type,isEN);
        }
        public tblNew GetSpecialNew(byte type,bool isEN)
        {
            return _da.GetSpecialNew(type, isEN);
        }
        public tblInformation GetInformation(bool isEN)
        {
            return _da.GetInformation(isEN);
        }
        public bool UpdateInformation(tblInformation infor)
        {
            return _da.UpdateInformation(infor);
        }
        public bool InsertInformation(tblInformation infor)
        {
            return _da.InsertInformation(infor);
        }
        public tblInformation GetInformation(Guid id,bool isEN)
        {
            return _da.GetInformation(id,isEN);
        }
        public List<tblCategory> GetAllCategory(bool isEN)
        {
            return _da.GetAllCategory(isEN);
        }
        public SearchResult<tblCategory> GetAllCategory(int pageSize, int page,bool isEN)
        {
            return _da.GetAllCategory(pageSize, page,isEN);
        }
        public SearchResult<tblProduct> GetAllProduct(int pageSize, int page,bool isEN)
        {
            return _da.GetAllProduct(pageSize, page,isEN);
        }
        public SearchResult<tblProduct> GetAllProductByCategory(int pageSize, int page, Guid? categoryID)
        {
            return _da.GetAllProductByCategory(pageSize, page, categoryID);
        }
        public void UpdateNews(tblNew tblnew)
        {
             _da.UpdateNews(tblnew);
        }
        public void UpdateProduct(tblProduct tblproduct)
        {
            _da.UpdateProduct(tblproduct);
        }
        public void InsertNews(tblNew tblnew)
        {
            _da.InsertNews(tblnew);
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

        public void UpdateCategory(tblCategory tblnew)
        {
            _da.UpdateCategory(tblnew);
        }
        public void InsertCategory(tblCategory tblnew)
        {
            _da.InsertCategory(tblnew);
        }
        public void DeleteInformation(Guid informationID)
        {
             _da.DeleteInformation(informationID);
        }
        public void DeleteCategory(Guid categoryID)
        {
            _da.DeleteCategory(categoryID);
        }
        public void DeleteNews(Guid newsID)
        {
            _da.DeleteNews(newsID);
        }
        public void DeleteProduct(Guid productID)
        {
            _da.DeleteProduct(productID);
        }
    }
}
