﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGUYENHIEP.Models;
using System.Linq.Dynamic;
using NguyenHiep.Data.Queries;
using NguyenHiep.Data;
using System.Configuration.Provider;
namespace NGUYENHIEP.Services.LinqClient
{
    public class NguyenHiepDA
    {
        NguyenHiepDataContext _dataContext = new NguyenHiepDataContext();
        public tblNew GetNewsByID(Guid newID)
        {
            
            var query = _dataContext.tblNews.Where("ID.ToString()=@0", newID.ToString());
            if (query.ToList().Count() > 0)
            {
                tblNew tblnew = query.ToList().First();
                return tblnew;
            }
            return null;
        }
        public tblProduct GetProductByID(Guid newID)
        {
            var query = _dataContext.tblProducts.Where("ID.ToString()=@0", newID.ToString());
            if (query.ToList().Count() > 0)
            {
                tblProduct tblnew = query.ToList().First();
                return tblnew;
            }
            return null;
        }
        public void UpdateNews(tblNew tblnew)
        {
            if (tblnew != null && tblnew.ID != null && !tblnew.ID.Equals(Guid.Empty))
            {
                var query = _dataContext.tblNews.Where("ID.ToString()=@0", tblnew.ID.ToString());
                if (query != null && query.ToList().Count > 0)
                {
                    query.First().TitleVN = tblnew.TitleVN;
                    query.First().TitleEN = tblnew.TitleEN;
                    query.First().Type = tblnew.Type;
                    query.First().ContentVN = tblnew.ContentVN;
                    query.First().ContentVN = tblnew.ContentVN;
                    query.First().Image = tblnew.Image;
                    query.First().PostedBy = tblnew.PostedBy;
                    query.First().SubjectEN = tblnew.SubjectEN;
                    query.First().SubjectVN = tblnew.SubjectVN;
                    query.First().EndedBy = tblnew.EndedBy;
                    query.First().EndedDate = tblnew.EndedDate;
                    _dataContext.SubmitChanges();
                }
            }
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
                    query.First().tblCategory= tblproduct.tblCategory;
                    query.First().UpdatedBy = tblproduct.UpdatedBy;
                    query.First().UpdatedDate = DateTime.Now;
                    query.First().CreatedBy = tblproduct.CreatedBy;
                    query.First().CategoryID = tblproduct.CategoryID;
                    query.First().Description = tblproduct.Description;
                    query.First().Image = tblproduct.Image;
                    _dataContext.SubmitChanges();
                }
            }
        }
        public void UpdateCategory(tblCategory tblnew)
        {
            if (tblnew != null && tblnew.ID != null && !tblnew.ID.Equals(Guid.Empty))
            {
                var query = _dataContext.tblCategories.Where("ID.ToString()=@0", tblnew.ID.ToString());
                if (query != null && query.ToList().Count > 0)
                {
                    query.First().CategoryNameVN = tblnew.CategoryNameVN;
                    query.First().CategoryNameEN = tblnew.CategoryNameEN;
                    query.First().DescriptionVN = tblnew.DescriptionVN;
                    query.First().DescriptionEN = tblnew.DescriptionEN;
                    query.First().UpdatedDate = DateTime.Now;
                    _dataContext.SubmitChanges();
                }
            }
        }
        public void InsertNews(tblNew tblnew)
        {
            if (tblnew != null && tblnew.ID != null && !tblnew.ID.Equals(Guid.Empty))
            {
                tblnew.PostedDate = DateTime.Now;
                tblnew.CreatedDate = DateTime.Now;
                _dataContext.tblNews.InsertOnSubmit(tblnew);
                _dataContext.SubmitChanges();
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
        public void InsertProduct(tblProduct tblproduct)
        {
            if (tblproduct != null && tblproduct.ID != null && !tblproduct.ID.Equals(Guid.Empty))
            {
                tblproduct.CreatedDate = DateTime.Now;
                _dataContext.tblProducts.InsertOnSubmit(tblproduct);
                _dataContext.SubmitChanges();
            }
        }
        public SearchResult<tblNew> GetAllNews(int pageSize, int page,byte type,bool isEN)
        {
            SearchResult<tblNew> searchResult = new SearchResult<tblNew>();
            if (!isEN)
            {
                var query1 = _dataContext.tblNews.Where("Type=@0 and SubjectVN!=null", type);
                var query = _dataContext.tblNews.Where("Type=@0 and SubjectVN!=null", type).Take(pageSize * page).Skip((page - 1) * pageSize);
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
                var query1 = _dataContext.tblNews.Where("Type=@0 and SubjectEN!=null", type);
                var query = _dataContext.tblNews.Where("Type=@0 and SubjectEN!=null", type).Take(pageSize * page).Skip((page - 1) * pageSize);
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
        public tblNew GetSpecialNew(byte type)
        {
            SearchResult<tblNew> searchResult = new SearchResult<tblNew>();
            var query = _dataContext.tblNews.Where("Type=@0", type).OrderBy("CreatedDate");
            return ((query!= null && query.ToList().Count>0)?query.ToList().First():(new tblNew()));
        }
        public tblInformation GetInformation()
        {
            SearchResult<tblInformation> searchResult = new SearchResult<tblInformation>();
            var query = _dataContext.tblInformations.OrderBy("CreatedDate");
            return ((query != null && query.ToList().Count > 0) ? query.ToList().First() : (new tblInformation()));
        }
        public bool InsertInformation(tblInformation infor)
        {
            if (infor != null && !infor.ID.Equals(Guid.Empty))
            {
                try
                {
                    _dataContext.tblInformations.InsertOnSubmit(infor);
                    _dataContext.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        public tblInformation GetInformation(Guid id)
        {
            
            var query = _dataContext.tblInformations.Where("ID.ToString()=@0", id.ToString());
            return ((query != null && query.ToList().Count > 0) ? query.ToList().First() : (new tblInformation()));
        }
        public bool UpdateInformation(tblInformation infor)
        {
            if (infor != null && !infor.ID.Equals(Guid.Empty))
            {
                var query = _dataContext.tblInformations.Where("ID.ToString()=@0", infor.ID.ToString());
                if (query != null && query.ToList().Count > 0)
                {
                    if(!String.IsNullOrEmpty(infor.ContactVN))
                        query.ToList().First().ContactVN = infor.ContactVN;
                    if (!String.IsNullOrEmpty(infor.ContactEN))
                        query.ToList().First().ContactEN = infor.ContactEN;
                    try
                    {
                        _dataContext.SubmitChanges();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                
            }
            return false;
        }
        public SearchResult<tblProduct> GetAllProduct(int pageSize, int page,bool isEN)
        {
            SearchResult<tblProduct> searchResult = new SearchResult<tblProduct>();
            if (isEN)
            {
                var query1 = _dataContext.tblProducts.Where("ProductNameEN!=null");
                var query = _dataContext.tblProducts.Take(pageSize * page).Skip((page - 1) * pageSize).Where("ProductNameEN!=null");
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
                var query = _dataContext.tblProducts.Take(pageSize * page).Skip((page - 1) * pageSize).Where("ProductNameVN!=null");
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
        public List<tblCategory> GetAllCategory()
        {
            var query = _dataContext.tblCategories;
           
            return ((query!=null)?query.ToList():(new List<tblCategory>()));
        }

        #region Data Access tblUser

        public bool Logon(String userName, String password)
        {
            var query = _dataContext.tblUsers.Where("UserName=@0 and Password=@1", userName, password);
            HttpContext.Current.Items["UserName"] = null;
            if (query.ToList().Count() > 0)
            {
                tblUser tbluser = query.ToList().First();
                HttpContext.Current.Items["UserName"] = tbluser.UserName;
                return true;
            }
            return false;
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

        public SearchResult<tblCategory> GetAllCategory(int pageSize, int page)
        {
            SearchResult<tblCategory> searchResult = new SearchResult<tblCategory>();
            var query1 = _dataContext.tblCategories;
            var query = _dataContext.tblCategories.Take(pageSize * page).Skip((page - 1) * pageSize);
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
    }
}