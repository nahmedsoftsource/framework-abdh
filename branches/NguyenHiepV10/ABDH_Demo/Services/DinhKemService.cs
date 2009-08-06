using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ABDH_Demo.Services.LinqClient;
using ABDH_Demo.Models;
namespace ABDH_Demo.Services
{
    public class DinhKemService
    {
        LinqClient.DinhKemDA _dinhkemDA = new DinhKemDA();
        public List<Models.tblNhomTaiLieu> GetNhomTaiLieus()
        {
          return _dinhkemDA.GetNhomTaiLieus();
        }
        public List<tblDinhKem> GetDinhKems()
        {
            return _dinhkemDA.GetDinhKems();
        }
        public tblTaiLieu GetTailieuByID(int id)
        {
            return _dinhkemDA.GetTailieuByID(id);
        }
        public void SaveTaiLieu(tblTaiLieu tailieu)
        {
           _dinhkemDA.SaveTaiLieu(tailieu);
        }
        public void InsertTailieu(tblTaiLieu tailieu)
        {
          _dinhkemDA.InsertTailieu(tailieu);
        }
    }
}
