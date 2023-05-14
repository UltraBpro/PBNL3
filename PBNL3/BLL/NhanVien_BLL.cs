using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBNL3.BLL
{
    internal class NhanVien_BLL
    {
        private DBEntities db;

        public NhanVien_BLL()
        {
            db = new DBEntities();
        }
        public NhanVien GetNV(int MaNV)
        {

            return db.NhanViens.Find(MaNV);

        }
        public List<NhanVien> LayDSNhanVien()
        {
            return db.NhanViens.ToList();
        }
        public void ThemNhanVien(string tenNhanVien, bool gioiTinh, DateTime ngayNhanViec, double luong, string chucVu)
        {

            NhanVien newNhanVien = new NhanVien();
            newNhanVien.MaNhanVien = (db.NhanViens.Max(x => (int?)x.MaNhanVien) ?? 0) + 1;
            newNhanVien.TenNhanVien = tenNhanVien;
            newNhanVien.GioiTinh = gioiTinh ? "Nam" : "Nữ";
            newNhanVien.NgayNhanViec = ngayNhanViec;
            newNhanVien.Luong = luong;
            newNhanVien.ChucVu = chucVu;
            db.NhanViens.Add(newNhanVien);
            db.SaveChanges();

        }
        public NhanVien TimNhanVien(int MaTaiKhoan)
        {

            return db.TaiKhoans.Find(MaTaiKhoan).NhanVien;

        }
        public string TimChucVu()
        {

            return db.NhanViens.Find(NhanVienThucHien.MaNhanVien).ChucVu.ToString();

        }       
    }
}
