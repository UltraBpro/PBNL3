
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBNL3.BLL
{
    internal class Phong_BLL
    {
        public Phong GetPhong(int MaPhong)
        {
            using (DBEntities db = new DBEntities())
            {
                return db.Phongs.Find(MaPhong);
            }
        }
        public LoaiPhong GetLoaiPhong(int MaLoaiPhong)
        {
            using (DBEntities db = new DBEntities())
            {
                return db.LoaiPhongs.Find(MaLoaiPhong);
            }
        }
        public List<ChiTietPhongDat> LayDSChiTietPhongDat()
        {
            using (DBEntities db = new DBEntities())
            {
                return db.ChiTietPhongDats.ToList();
            }
        }
        public List<LoaiPhong> LayDSLoaiPhong()
        {
            using (DBEntities db = new DBEntities())
            {
                return db.LoaiPhongs.ToList();
            }
        }
        public IEnumerable<object> LoadPhong(string kieuload)
        {
            using (DBEntities db = new DBEntities())
            {
                var DSPhong = db.Phongs
                    .Join(db.LoaiPhongs,
                    phong => phong.MaLoaiPhong,
                    loaiPhong => loaiPhong.MaLoaiPhong,
                    (phong, loaiPhong) => new
                    {
                        phong.MaPhong,
                        loaiPhong.TenLoaiPhong,
                        loaiPhong.DienTich,
                        loaiPhong.SoGiuong,
                        loaiPhong.GiaTien,
                        phong.TinhTrang,
                        phong.Tang,
                        phong.ThuTu
                    })
                    .Select(p => new
                    {
                        p.MaPhong,
                        p.TinhTrang,
                        p.Tang,
                        p.ThuTu,
                        p.TenLoaiPhong,
                        p.DienTich,
                        p.SoGiuong,
                        p.GiaTien
                    });

                switch (kieuload)
                {
                    case "DatPhong":
                        return DSPhong.Where(p => p.TinhTrang == "Trống").ToList();
                    case "GoiDichVu":
                        return DSPhong.Where(p => p.TinhTrang == "Kín").ToList();
                    case "LietKe":
                        return DSPhong.ToList();
                    default:
                        return null;
                }
            }
        }
        public ChiTietPhongDat GetPhongDat(int MaDonDatPhong)
        {
            using (DBEntities db = new DBEntities())
            {
                return db.ChiTietPhongDats.Where(p => p.MaDonDatPhong == MaDonDatPhong).FirstOrDefault();
            }
        }
        public int ThemLoaiPhong(string tenLoaiPhong, int soGiuong, int dienTich, string ghiChu, double giaTien)
        {
            using (DBEntities db = new DBEntities())
            {
                LoaiPhong newLP = new LoaiPhong();
                newLP.MaLoaiPhong = (db.LoaiPhongs.Max(x => (int?)x.MaLoaiPhong) ?? 0) + 1;
                newLP.TenLoaiPhong = tenLoaiPhong;
                newLP.SoGiuong = soGiuong;
                newLP.DienTich = dienTich;
                newLP.GhiChu = ghiChu;
                newLP.GiaTien = giaTien;
                db.LoaiPhongs.Add(newLP); db.SaveChanges();
                return newLP.MaLoaiPhong;
            }
        }
        public void GanMaLoaiPhongChoPhong(int? maPhong, int maLoaiPhong)
        {
            if (maPhong != null)
            {
                using (DBEntities db = new DBEntities())
                {
                    Phong phong = db.Phongs.Find(maPhong);
                    if (phong != null)
                    {
                        phong.MaLoaiPhong = maLoaiPhong;
                        db.SaveChanges();
                    }
                }
            }
        }
        public void DatPhong(int maNhanVien, int maKhach, int maPhong, DateTime ngayDat)
        {
            using (DBEntities db = new DBEntities())
            {
                DonDatPhong newBooking = new DonDatPhong();
                newBooking.MaDonDatPhong = (db.DonDatPhongs.Max(x => (int?)x.MaDonDatPhong) ?? 0) + 1;
                newBooking.MaNhanVienThucHien = maNhanVien;
                newBooking.NgayDat = ngayDat;
                newBooking.MaKhach = maKhach;
                newBooking.TinhTrangThanhToan = "Chưa thanh toán";
                db.DonDatPhongs.Add(newBooking);
                db.SaveChanges();

                ChiTietPhongDat roomBooking = new ChiTietPhongDat();
                roomBooking.MaDonDatPhong = newBooking.MaDonDatPhong;
                roomBooking.MaPhong = maPhong;
                var room = db.Phongs.Find(roomBooking.MaPhong);
                roomBooking.GiaPhongDat = db.LoaiPhongs.Find(room.MaLoaiPhong).GiaTien;
                db.ChiTietPhongDats.Add(roomBooking);
                db.SaveChanges();

                room.TinhTrang = "Kín";
                db.SaveChanges();
            }
        }
        public void TraPhong(int maPhong)
        {
            using (DBEntities db = new DBEntities())
            {
                var Phong = db.Phongs.Find(maPhong);
                Phong.TinhTrang = "Trống";
                db.SaveChanges();
            }
        }
        public static string GetTTrangPhong(Button ButtonPhong)
        {
            using (DBEntities db = new DBEntities())
            {
                return db.Phongs.Find(Convert.ToInt32(ButtonPhong.Name.Substring(15))).TinhTrang.ToString();                                   
            }
        }

        public static double GetTotalPhong(int selectedMonth, int selectedYear, bool type)
        {
            using (DBEntities db = new DBEntities())
            {
                double totalP = 0;
                if (type)
                {
                    foreach (var dp in db.DonDatPhongs
                        .Where(d => d.TinhTrangThanhToan == "Đã thanh toán" && d.NgayTra.Value.Month == selectedMonth && d.NgayTra.Value.Year == selectedYear)
                        .Join(db.ChiTietPhongDats, d => d.MaDonDatPhong, p => p.MaDonDatPhong, (d, p) => new { d, p })
                        .Select(dp => new { dp.p.GiaPhongDat, dp.d.NgayDat, dp.d.NgayTra }))
                    {
                        totalP += dp.GiaPhongDat * ((dp.NgayTra.Value - dp.NgayDat).TotalDays);
                    }
                }
                else
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        foreach (var dp in db.DonDatPhongs
                            .Where(d => d.TinhTrangThanhToan == "Đã thanh toán" && d.NgayTra.Value.Month == i && d.NgayTra.Value.Year == selectedYear)
                            .Join(db.ChiTietPhongDats, d => d.MaDonDatPhong, p => p.MaDonDatPhong, (d, p) => new { d, p })
                            .Select(dp => new { dp.p.GiaPhongDat, dp.d.NgayDat, dp.d.NgayTra }))
                        {
                            totalP += dp.GiaPhongDat * ((dp.NgayTra.Value - dp.NgayDat).TotalDays);
                        }
                    }
                }
                return totalP;
            }
        }                      
    }
}
