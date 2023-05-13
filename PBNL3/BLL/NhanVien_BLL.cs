using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBNL3.BLL
{
    internal class NhanVien_BLL
    {
        public NhanVien GetNV(int MaNV)
        {
            using (DBEntities db = new DBEntities())
            {
                return db.NhanViens.Find(MaNV);
            }
        }
        public List<NhanVien> LayDSNhanVien()
        {
            using (DBEntities db = new DBEntities())
            {
                return db.NhanViens.ToList();
            }
        }
        public void ThemNhanVien(string tenNhanVien, bool gioiTinh, DateTime ngayNhanViec, double luong, string chucVu)
        {
            using (DBEntities db = new DBEntities())
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
        }
        public NhanVien TimNhanVien(int MaTaiKhoan)
        {
            using (DBEntities db = new DBEntities())
            {
                return db.TaiKhoans.Find(MaTaiKhoan).NhanVien;
            }
        }
        public static string TimChucVu()
        {
            using (DBEntities db = new DBEntities())
            {
                return db.NhanViens.Find(NhanVienThucHien.MaNhanVien).ChucVu.ToString();
            }
        }       
    }
}
