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
        public SearchResult<tblNew> SearchNews(int pageSize, int page, String sortColunm, String sortOption)
        {
          SearchResult<tblNew> searchResult = new SearchResult<tblNew>();
          var query1 = _dataContext.tblNews.Where("TitleEN!=null");
          var query = query1;
          if (sortColunm == "TitleEN")
          {
            if (sortOption == ABDHFramework.Data.SortOption.Desc.ToString())
            {
              query = _dataContext.tblNews
                .Where("TitleEN!=null")
                .OrderByDescending(o => o.TitleEN)
                .Take(pageSize * page)
                .Skip((page - 1) * pageSize)
                ;
            }
            else
            {
              query = _dataContext.tblNews
                .Where("TitleEN!=null")
                .OrderBy(o => o.TitleEN)
                .Take(pageSize * page)
                .Skip((page - 1) * pageSize)
                ;
            }
          }
          else
          {
              query = _dataContext.tblNews
              .Where("TitleEN!=null")
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
          //var query1 = _dataContext.tblNews.Where("TitleEN like  @0", criteria);
          var query1 = _dataContext.tblNews.Where(op=>op.TitleEN.Contains(criteria));
          var query = query1;
          if (sortColunm == "TitleEN")
          {
            if (sortOption == ABDHFramework.Data.SortOption.Desc.ToString())
            {
              query = _dataContext.tblNews
                .Where(op => op.TitleEN.Contains(criteria))
                .OrderByDescending(o => o.TitleEN)
                .Take(pageSize * page)
                .Skip((page - 1) * pageSize)
                ;
            }
            else
            {
              query = _dataContext.tblNews
                .Where(op => op.TitleEN.Contains(criteria))
                .OrderBy(o => o.TitleEN)
                .Take(pageSize * page)
                .Skip((page - 1) * pageSize)
                ;
            }
          }
          else
          {
            query = _dataContext.tblNews
            .Where(op => op.TitleEN.Contains(criteria))
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
