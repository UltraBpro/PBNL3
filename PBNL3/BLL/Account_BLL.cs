using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBNL3.BLL
{
    internal class Account_BLL
    {
        public TaiKhoan GetAccount(string username)
        {
            using (DBEntities db = new DBEntities())
            {
                return db.TaiKhoans.Single(p => p.username == username);
            }
        }
        public NhanVien FindAccount(int MaTaiKhoan)
        {
            using (DBEntities db = new DBEntities())
            {
                return db.TaiKhoans.Find(MaTaiKhoan).NhanVien;
            }
        }
        public void DoiMatKhau(string matKhauCu, string matKhauMoi, string xacNhanMatKhauMoi)
        {
            using (DBEntities db = new DBEntities())
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
        }
    }
}
