using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGUYENHIEP.Models;
using System.Linq.Dynamic;

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
        public List<tblNew> GetAllNews()
        {
            var query = _dataContext.tblNews;
            return (List<tblNew>)query.ToList();
        }
    }
}
