﻿using System;
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
        public SearchResult<tblNew> GetAllNews(int pageSize, int page)
        {
            return _da.GetAllNews(pageSize,page);
        }
        public List<tblCategory> GetAllCategory()
        {
            return _da.GetAllCategory();
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
    }
}
