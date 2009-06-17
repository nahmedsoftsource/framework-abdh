﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Dynamic;
using ABDH_Demo.Models;
namespace ABDH_Demo.Services.LinqClient
{
    public class DinhKemDA
    {
        public List<Models.tblDinhKem> GetDinhKems()
        {
            ABDH_DemoDataContext _libraryContext = new ABDH_DemoDataContext();
            
            var query = _libraryContext.tblDinhKems;

            return query.ToList();
        }
        public tblTaiLieu GetTailieuByID(int id)
        {
            ABDH_DemoDataContext _libraryContext = new ABDH_DemoDataContext();
            var query = _libraryContext.tblTaiLieus.Where("TailieuID=@0", id);
            return query.ToList().First();
        }
        public void SaveTaiLieu(tblTaiLieu tailieu)
        {
            ABDH_DemoDataContext _libraryContext = new ABDH_DemoDataContext();
            var query = _libraryContext.tblTaiLieus.Where("TailieuID=@0", tailieu.TaiLieuID);
            tblTaiLieu tmp = (tblTaiLieu)query.ToList().First();
            tmp.MaTaiLieu = tailieu.MaTaiLieu;
            tmp.NgonNgu = tailieu.NgonNgu;
            tmp.NhomTaiLieuID = tailieu.NhomTaiLieuID;
            tmp.SoLanXem = tailieu.SoLanXem;
            tmp.TacGia = tailieu.TacGia;
            tmp.TaiLieuID = tailieu.TaiLieuID;
            tmp.TenTaiLieu = tailieu.TenTaiLieu;
            tmp.TomTatNoiDung = tailieu.TomTatNoiDung;
            tmp.TrangThaiTaiLieu = tailieu.TrangThaiTaiLieu;
            tmp.TuKhoa = tailieu.TuKhoa;
            tmp.VongDoi_EndDate = tailieu.VongDoi_EndDate;
            tmp.VongDoi_StartDate = tailieu.VongDoi_StartDate;
            _libraryContext.SubmitChanges();
        }
    }
}
