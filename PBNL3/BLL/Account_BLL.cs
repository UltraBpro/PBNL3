using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBNL3.BLL
{
    internal class Account_BLL
    {
        private DBEntities db;

        public Account_BLL()
        {
            db = new DBEntities();
        }
        public TaiKhoan GetAccount(string username)
        {
            return db.TaiKhoans.Single(p => p.username == username&&p.Activated==true) ;
        } 
        public void DoiMatKhau(string matKhauCu, string matKhauMoi, string xacNhanMatKhauMoi)
        {
            var TKcu = db.TaiKhoans.Where(p => p.MaNhanVien == NhanVienThucHien.MaNhanVien).FirstOrDefault();
            if (TKcu.password == matKhauCu)
            {
                if (matKhauMoi == xacNhanMatKhauMoi)
                {
                    TKcu.password = matKhauMoi;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Mật khẩu xác nhận không đúng.");
                }
            }
            else
            {
                throw new Exception("Mật khẩu cũ không đúng.");
            }
        }
        public TaiKhoan CheckTK(int MaNhanVien)
        {
            return db.TaiKhoans.Where(p => p.MaNhanVien == MaNhanVien&&p.Activated==true).FirstOrDefault();
        }
        public void ThemTaiKhoan(int MaNhanVien,string usn,string pass)
        {
            if (db.TaiKhoans.Where(p => p.username == usn).FirstOrDefault() == null)
            {
                TaiKhoan newTK = new TaiKhoan();
                newTK.MaTK = (db.TaiKhoans.Max(x => (int?)x.MaTK) ?? 0) + 1;
                newTK.username = usn;
                newTK.password = pass;
                newTK.MaNhanVien = MaNhanVien;
                newTK.Activated = true;
                db.TaiKhoans.Add(newTK); db.SaveChanges();
            }
            else throw new Exception("Username này đã tồn tại.");
        }
        public void XoaTaiKhoan(int MaNhanVien)
        {
            db.TaiKhoans.Where(p => p.MaNhanVien == MaNhanVien).FirstOrDefault().Activated = false;
            db.SaveChanges();
        }
    }
}

