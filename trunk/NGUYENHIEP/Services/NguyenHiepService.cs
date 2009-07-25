using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NGUYENHIEP.Services.LinqClient;
using NGUYENHIEP.Models;

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
        public List<tblNew> GetAllNews()
        {
            return _da.GetAllNews();
        }
    }
}
