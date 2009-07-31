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
        public tblNew GetNewsByID(Guid newID)
        {
            return _da.GetNewsByID(newID);
        }
        public tblProduct GetProductByID(Guid newID)
        {
            return _da.GetProductByID(newID);
        }
        public SearchResult<tblNew> GetAllNews(int pageSize, int page, byte type, bool isEN)
        {
            return _da.GetAllNews(pageSize,page,type,isEN);
        }
        public tblNew GetSpecialNew(byte type)
        {
            return _da.GetSpecialNew(type);
        }
        public tblInformation GetInformation()
        {
            return _da.GetInformation();
        }
        public bool UpdateInformation(tblInformation infor)
        {
            return _da.UpdateInformation(infor);
        }
        public bool InsertInformation(tblInformation infor)
        {
            return _da.InsertInformation(infor);
        }
        public tblInformation GetInformation(Guid id)
        {
            return _da.GetInformation(id);
        }
        public List<tblCategory> GetAllCategory()
        {
            return _da.GetAllCategory();
        }
        public SearchResult<tblCategory> GetAllCategory(int pageSize, int page)
        {
            return _da.GetAllCategory(pageSize, page);
        }
        public SearchResult<tblProduct> GetAllProduct(int pageSize, int page)
        {
            return _da.GetAllProduct(pageSize, page);
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

        public tblUser GetUser(String userName,String password)
        {
            return _da.GetUser(userName,password);
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

        public void UpdateCategory(tblCategory tblnew)
        {
            _da.UpdateCategory(tblnew);
        }
        public void InsertCategory(tblCategory tblnew)
        {
            _da.InsertCategory(tblnew);
        }

    }
}
