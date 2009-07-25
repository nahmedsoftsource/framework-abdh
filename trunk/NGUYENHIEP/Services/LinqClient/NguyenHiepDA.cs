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
        public SearchResult<tblNew> GetAllNews(int pageSize, int page)
        {
            SearchResult<tblNew> searchResult = new SearchResult<tblNew>();
            var query1 = _dataContext.tblNews;
            var query = _dataContext.tblNews.Take(pageSize*page).Skip((page - 1) * pageSize);
            if (query != null && query1 != null)
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
