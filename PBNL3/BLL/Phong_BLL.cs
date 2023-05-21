
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
        private DBEntities db;

        public Phong_BLL()
        {
            db = new DBEntities();
        }
        public Phong GetPhong(int MaPhong)
        {

            return db.Phongs.Find(MaPhong);

        }
        public LoaiPhong GetLoaiPhong(int MaLoaiPhong)
        {
            return db.LoaiPhongs.Find(MaLoaiPhong);
        }
        public List<ChiTietPhongDat> LayDSChiTietPhongDat()
        {
            return db.ChiTietPhongDats.ToList();
        }
        public List<LoaiPhong> LayDSLoaiPhong()
        {
            return db.LoaiPhongs.Where(p => p.Activated == true).ToList();
        }
        public void XoaLoaiPhong(int MaLoaiP)
        {
            db.LoaiPhongs.Find(MaLoaiP).Activated = false;
            db.SaveChanges();
        }
        public IEnumerable<object> LoadPhong(string kieuload)
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
        public ChiTietPhongDat GetPhongDat(int MaDonDatPhong)
        {

            return db.ChiTietPhongDats.Where(p => p.MaDonDatPhong == MaDonDatPhong).FirstOrDefault();

        }
        public int ThemLoaiPhong(string tenLoaiPhong, int soGiuong, int dienTich, string ghiChu, double giaTien)
        {

            LoaiPhong newLP = new LoaiPhong();
            newLP.MaLoaiPhong = (db.LoaiPhongs.Max(x => (int?)x.MaLoaiPhong) ?? 0) + 1;
            newLP.TenLoaiPhong = tenLoaiPhong;
            newLP.SoGiuong = soGiuong;
            newLP.DienTich = dienTich;
            newLP.GhiChu = ghiChu;
            newLP.GiaTien = giaTien;
            newLP.Activated = true;
            db.LoaiPhongs.Add(newLP); db.SaveChanges();
            return newLP.MaLoaiPhong;

        }
        public void GanMaLoaiPhongChoPhong(int? maPhong, int maLoaiPhong)
        {
            if (maPhong != null)
            {
                Phong phong = db.Phongs.Find(maPhong);
                if (phong != null)
                {
                    phong.MaLoaiPhong = maLoaiPhong;
                    db.SaveChanges();
                }
            }
        }
        public void DatPhong(int maNhanVien, int maKhach, int maPhong, DateTime ngayDat)
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
        public void TraPhong(int maPhong)
        {

            var Phong = db.Phongs.Find(maPhong);
            Phong.TinhTrang = "Trống";
            db.SaveChanges();

        }
        public string GetTTrangPhong(Button ButtonPhong)
        {
            return db.Phongs.Find(Convert.ToInt32(ButtonPhong.Name.Substring(15))).TinhTrang.ToString();
        }
        public double GetTotalPhong(int selectedMonth, int selectedYear, bool type)
        {
            double totalP = 0;
            if (type)
            {
                foreach (var dp in db.DonDatPhongs
                    .Where(d => d.TinhTrangThanhToan == "Đã thanh toán" && d.NgayTra.Value.Month == selectedMonth && d.NgayTra.Value.Year == selectedYear)
                    .Join(db.ChiTietPhongDats, d => d.MaDonDatPhong, p => p.MaDonDatPhong, (d, p) => new { d, p })
                    .Select(dp => new { dp.p.GiaPhongDat, dp.d.NgayDat, dp.d.NgayTra }))
                {
                    totalP += dp.GiaPhongDat * ((int)(dp.NgayTra.Value - dp.NgayDat).TotalDays+1);
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
                        totalP += dp.GiaPhongDat * ((int)(dp.NgayTra.Value - dp.NgayDat).TotalDays + 1);
                    }
                }
            }
            return totalP;
        }
        public double GetTotalPhongByDay(DateTime Start, DateTime End)
        {
            double totalP = 0;
            foreach (var dp in db.DonDatPhongs
                    .Where(d => d.TinhTrangThanhToan == "Đã thanh toán" && d.NgayTra >= Start && d.NgayTra <= End)
                    .Join(db.ChiTietPhongDats, d => d.MaDonDatPhong, p => p.MaDonDatPhong, (d, p) => new { d, p })
                    .Select(dp => new { dp.p.GiaPhongDat, dp.d.NgayDat, dp.d.NgayTra }))
            {
                totalP += dp.GiaPhongDat * ((int)(dp.NgayTra.Value - dp.NgayDat).TotalDays + 1);
            }
            return totalP;
        }
    }
}
