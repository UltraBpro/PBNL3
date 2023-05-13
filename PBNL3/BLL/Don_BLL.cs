using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBNL3.BLL
{
    internal class Don_BLL
    {        
        public int GetMaDonDatPhongThongQuaPhong(int phongduochon)
        {
            using (DBEntities db = new DBEntities())
            {
                var TimDonDatDichVu = db.DonDatPhongs.Join(db.ChiTietPhongDats,
              don => don.MaDonDatPhong,
              phongdat => phongdat.MaDonDatPhong,
              (don, phongdat) => new
              {
                  don.MaDonDatPhong,
                  phongdat.MaPhong,
                  don.TinhTrangThanhToan
              }).Where(p => p.TinhTrangThanhToan != "Đã thanh toán" && p.MaPhong == phongduochon).FirstOrDefault();
                return TimDonDatDichVu.MaDonDatPhong;
            }
        }
        public DonDatPhong GetDonDat(int MaDonDatPhong)
        {
            using (DBEntities db = new DBEntities())
            {
                return db.DonDatPhongs.Find(MaDonDatPhong);
            }       
        }
        public static double GetTotalBill(int selectedMonth, int selectedYear, bool type)
        {
            using (DBEntities db = new DBEntities())
            {
                double totalBill = 0;
                if (type)
                {
                    foreach (var donDatPhong in db.DonDatPhongs
                        .Where(d => d.TinhTrangThanhToan == "Đã thanh toán" && d.NgayTra.Value.Month == selectedMonth && d.NgayTra.Value.Year == selectedYear))
                    {
                        totalBill++;
                    }
                }
                else
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        foreach (var donDatPhong in db.DonDatPhongs
                            .Where(d => d.TinhTrangThanhToan == "Đã thanh toán" && d.NgayTra.Value.Month == i && d.NgayTra.Value.Year == selectedYear))
                        {
                            totalBill++;
                        }
                    }
                }
                return totalBill;
            }
        }
        public void LuuTongTien(int MaDonThaoTac,double tongTien)
        {
            using(DBEntities db = new DBEntities())
            {
                DonDatPhong don = db.DonDatPhongs.Find(MaDonThaoTac);
                if (don != null)
                {
                    don.TongTien = tongTien;
                    db.SaveChanges();
                }
            }
        }
        public void LuuThongTinThanhToan(int MaDonThaoTac, DateTime ngayTra, int maNV)
        {
            using (DBEntities db = new DBEntities())
            {
                DonDatPhong don = db.DonDatPhongs.Find(MaDonThaoTac);
                if (don != null)
                {
                    don.TinhTrangThanhToan = "Đã thanh toán";
                    don.NgayTra = ngayTra;
                    don.MaNhanVienThanhToan= maNV;
                    db.SaveChanges();
                }
            }
        }
     
        public DataTable GetBillDetails(int selectedMonth, int selectedYear)
        {
            DBEntities db = new DBEntities();
            var bill = db.DonDatPhongs
                        .Where(d => d.TinhTrangThanhToan == "Đã thanh toán" && (selectedMonth == 0 || d.NgayTra.Value.Month == selectedMonth) && d.NgayTra.Value.Year == selectedYear)
                        .Join(db.ChiTietPhongDats, d => d.MaDonDatPhong, p => p.MaDonDatPhong, (d, p) => new { d, p })
                        .Select(dp => new { dp.d.MaDonDatPhong, dp.p.MaPhong });
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MaDonDatPhong", typeof(int));
            dataTable.Columns.Add("MaPhong", typeof(int));
            foreach (var item in bill)
            {
                DataRow row = dataTable.NewRow();
                row["MaDonDatPhong"] = item.MaDonDatPhong;
                row["MaPhong"] = item.MaPhong;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }
    }
}
