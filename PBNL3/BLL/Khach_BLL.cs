using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBNL3.BLL
{
    internal class Khach_BLL
    {
        private DBEntities db;

        public Khach_BLL()
        {
            db = new DBEntities();
        }
        public Khach GetKhach(int MaKhach)
        {

            return db.Khaches.Find(MaKhach);

        }
        public List<Khach> LayDSKhach()
        {

            return db.Khaches.Where(p => p.Activated == true).ToList();

        }
        public int ThemKhachMoi(string tenKhach, string gioiTinh, DateTime ngaySinh, string soDienThoai, string CCCD)
        {

            Khach newKhach = new Khach();
            newKhach.MaKhach = (db.Khaches.Max(x => (int?)x.MaKhach) ?? 0) + 1;
            newKhach.TenKhach = tenKhach;
            newKhach.GioiTinh = gioiTinh;
            newKhach.NgaySinh = ngaySinh;
            newKhach.SoDienThoai = soDienThoai;
            newKhach.CCCD = CCCD;
            db.Khaches.Add(newKhach);
            db.SaveChanges();
            return newKhach.MaKhach;
        }
        public void XoaKhach(int MaKhach)
        {
            db.Khaches.Find(MaKhach).Activated = false;
            db.SaveChanges();
        }
    }    
}
