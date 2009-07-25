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
        public SearchResult<tblNew> GetAllNews(int pageSize, int page)
        {
            return _da.GetAllNews(pageSize,page);
        }
        public void UpdateNews(tblNew tblnew)
        {
             _da.UpdateNews(tblnew);
        }
        public void InsertNews(tblNew tblnew)
        {
            _da.InsertNews(tblnew);
        }
    }
}
