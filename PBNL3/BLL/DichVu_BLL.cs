using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBNL3.BLL
{
    internal class DichVu_BLL
    {
        private DBEntities db;

        public DichVu_BLL()
        {
            db = new DBEntities();
        }
        public List<LoaiDichVu> LayDSDichVu()
        {
            return db.LoaiDichVus.ToList();
        }
        public List<ChiTietDichVuDat> LayDSDichVuDaSuDung(int MaDonDatPhong)
        {
            return db.ChiTietDichVuDats.Where(p => p.MaDonDatPhong == MaDonDatPhong).ToList();
        }
        public int ThemDichVu(string tenDichVu, double donGia, string donVi)
        {

            LoaiDichVu newDV = new LoaiDichVu();
            newDV.MaLoaiDichVu = (db.LoaiDichVus.Max(x => (int?)x.MaLoaiDichVu) ?? 0) + 1;
            newDV.TenDichVu = tenDichVu;
            newDV.DonGia = donGia;
            newDV.DonVi = donVi.ToUpper();
            db.LoaiDichVus.Add(newDV);
            db.SaveChanges();
            return newDV.MaLoaiDichVu;

        }
        public LoaiDichVu TimDV(int MaDVDangChon)
        {

            return db.LoaiDichVus.Find(MaDVDangChon);

        }
        public void DatDichVu(DataTable dt, int phongDuocChon)
        {

            var TimDonDatDichVu = db.DonDatPhongs.Join(db.ChiTietPhongDats,
              don => don.MaDonDatPhong,
              phongdat => phongdat.MaDonDatPhong,
              (don, phongdat) => new
              {
                  don.MaDonDatPhong,
                  phongdat.MaPhong,
                  don.TinhTrangThanhToan
              }).Where(p => p.TinhTrangThanhToan != "Đã thanh toán" && p.MaPhong == phongDuocChon).FirstOrDefault();
            foreach (DataRow dtr in dt.Rows)
            {
                int MaDV = Convert.ToInt32(dtr["Mã dịch vụ"]);
                var DichvuDaDat = db.ChiTietDichVuDats.Where(p => p.MaDonDatPhong == TimDonDatDichVu.MaDonDatPhong && p.MaDichVu == MaDV).FirstOrDefault();
                if (DichvuDaDat == null)
                {
                    ChiTietDichVuDat datdichvuchodon = new ChiTietDichVuDat();
                    datdichvuchodon.MaDonDatPhong = TimDonDatDichVu.MaDonDatPhong;
                    datdichvuchodon.MaDichVu = MaDV;
                    datdichvuchodon.SoLuong = Convert.ToInt32(dtr["Số lượng"]);
                    datdichvuchodon.GiaDichVuDat = Convert.ToInt32(dtr["Đơn giá"]);
                    db.ChiTietDichVuDats.Add(datdichvuchodon);
                }
                else DichvuDaDat.SoLuong += Convert.ToInt32(dtr["Số lượng"]);
                db.SaveChanges();
            }
        }
        public double GetTotalDV(int selectedMonth, int selectedYear, bool type)
        {

            double totalDV = 0;
            if (type)
            {
                foreach (var ddv in db.DonDatPhongs
                    .Where(d => d.TinhTrangThanhToan == "Đã thanh toán" && d.NgayTra.Value.Month == selectedMonth && d.NgayTra.Value.Year == selectedYear)
                    .Join(db.ChiTietDichVuDats, d => d.MaDonDatPhong, dv => dv.MaDonDatPhong, (d, dv) => new { d, dv })
                    .Select(ddv => new { ddv.dv.GiaDichVuDat, ddv.dv.SoLuong }))
                {
                    totalDV += ddv.GiaDichVuDat * ddv.SoLuong;
                }
            }
            else
            {
                for (int i = 1; i <= 12; i++)
                {
                    foreach (var ddv in db.DonDatPhongs
                        .Where(d => d.TinhTrangThanhToan == "Đã thanh toán" && d.NgayTra.Value.Month == i && d.NgayTra.Value.Year == selectedYear)
                        .Join(db.ChiTietDichVuDats, d => d.MaDonDatPhong, dv => dv.MaDonDatPhong, (d, dv) => new { d, dv })
                        .Select(ddv => new { ddv.dv.GiaDichVuDat, ddv.dv.SoLuong }))
                    {
                        totalDV += ddv.GiaDichVuDat * ddv.SoLuong;
                    }
                }
            }
            return totalDV;

        }
        public DataTable GetDGV(int selectedMonth, int selectedYear, bool type)
        {

            if (type)
            {
                var p = db.DonDatPhongs
                                    .Where(d => d.TinhTrangThanhToan == "Đã thanh toán" && (selectedMonth == 0 || d.NgayTra.Value.Month == selectedMonth) && d.NgayTra.Value.Year == selectedYear)
                                    .Join(db.ChiTietPhongDats, d => d.MaDonDatPhong, p1 => p1.MaDonDatPhong, (d, p1) => new { d, p1 })
                                    .Join(db.Phongs, dp1 => dp1.p1.MaPhong, p2 => p2.MaPhong, (dp1, p2) => new { dp1, p2 })
                                    .Join(db.LoaiPhongs, dp2 => dp2.p2.MaLoaiPhong, p3 => p3.MaLoaiPhong, (dp2, p3) => new { dp2, p3 })
                                    .GroupBy(x => x.dp2.dp1.p1.MaPhong)
                                    .Select(g => new
                                    {
                                        MaPhong = g.Key,
                                        TenLoaiPhong = g.FirstOrDefault().p3.TenLoaiPhong,
                                        Tang = g.FirstOrDefault().dp2.p2.Tang,
                                        ThuTu = g.FirstOrDefault().dp2.p2.ThuTu,
                                        GiaPhongDat = g.FirstOrDefault().dp2.dp1.p1.GiaPhongDat,
                                    });
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Mã phòng", typeof(int));
                dataTable.Columns.Add("Tên loại phòng", typeof(string));
                dataTable.Columns.Add("Tầng", typeof(int));
                dataTable.Columns.Add("Thứ tự", typeof(int));
                dataTable.Columns.Add("Giá phòng đặt", typeof(float));
                foreach (var item in p)
                {
                    DataRow row = dataTable.NewRow();
                    row["Mã phòng"] = item.MaPhong;
                    row["Tên loại phòng"] = item.TenLoaiPhong;
                    row["Tầng"] = item.Tang;
                    row["Thứ tự"] = item.ThuTu;
                    row["Giá phòng đặt"] = item.GiaPhongDat;
                    dataTable.Rows.Add(row);
                }
                return dataTable;
            }
            else
            {
                var dv = db.DonDatPhongs
                        .Where(d => d.TinhTrangThanhToan == "Đã thanh toán" && (selectedMonth == 0 || d.NgayTra.Value.Month == selectedMonth) && d.NgayTra.Value.Year == selectedYear)
                        .Join(db.ChiTietDichVuDats, d => d.MaDonDatPhong, ctdv => ctdv.MaDonDatPhong, (d, ctdv) => new { d, ctdv })
                        .Join(db.LoaiDichVus, dv1 => dv1.ctdv.MaDichVu, ldv => ldv.MaLoaiDichVu, (dv1, ldv) => new { dv1, ldv })
                        .GroupBy(x => x.ldv.MaLoaiDichVu)
                        .Select(g => new
                        {
                            MaLoaiDichVu = g.Key,
                            TenDichVu = g.FirstOrDefault().ldv.TenDichVu,
                            Gia = g.FirstOrDefault().dv1.ctdv.GiaDichVuDat,
                            SoLuongDaDat = g.Sum(x => x.dv1.ctdv.SoLuong)                         
                        });
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Mã loại dịch vụ", typeof(int));
                dataTable.Columns.Add("Tên dịch vụ", typeof(string));
                dataTable.Columns.Add("Giá dịch vụ đặt", typeof(float));
                dataTable.Columns.Add("Số lượng đã đặt", typeof(int));               
                foreach (var item in dv)
                {
                    DataRow row = dataTable.NewRow();
                    row["Mã loại dịch vụ"] = item.MaLoaiDichVu;
                    row["Tên dịch vụ"] = item.TenDichVu;
                    row["Giá dịch vụ đặt"] = item.Gia;
                    row["Số lượng đã đặt"] = item.SoLuongDaDat;                   
                    dataTable.Rows.Add(row);
                }
                return dataTable;
            }          
        }
    }
}
