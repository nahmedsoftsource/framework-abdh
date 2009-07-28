using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGUYENHIEP.Models;
using System.Linq.Dynamic;
using NguyenHiep.Data.Queries;
using NguyenHiep.Data;
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
        public void InsertProduct(tblProduct tblproduct)
        {
            if (tblproduct != null && tblproduct.ID != null && !tblproduct.ID.Equals(Guid.Empty))
            {
                tblproduct.CreatedDate = DateTime.Now;
                _dataContext.tblProducts.InsertOnSubmit(tblproduct);
                _dataContext.SubmitChanges();
            }
        }
        public SearchResult<tblNew> GetAllNews(int pageSize, int page,byte type)
        {
            SearchResult<tblNew> searchResult = new SearchResult<tblNew>();
            var query1 = _dataContext.tblNews.Where("Type=@0", type);
            var query = _dataContext.tblNews.Where("Type=@0",type).Take(pageSize*page).Skip((page - 1) * pageSize);
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
        public SearchResult<tblProduct> GetAllProduct(int pageSize, int page)
        {
            SearchResult<tblProduct> searchResult = new SearchResult<tblProduct>();
            var query1 = _dataContext.tblProducts;
            var query = _dataContext.tblProducts.Take(pageSize * page).Skip((page - 1) * pageSize);
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
        public List<tblCategory> GetAllCategory()
        {
            var query = _dataContext.tblCategories;
           
            return ((query!=null)?query.ToList():(new List<tblCategory>()));
        }
    }
}
