using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class UserControlChiTietDonHang : UserControl
    {
        DataTable dt=new DataTable();
        public UserControlChiTietDonHang()
        {
            InitializeComponent();
            dt.Columns.Add("Mã dịch vụ", typeof(int));
            dt.Columns.Add("Tên dịch vụ", typeof(string));
            dt.Columns.Add("Đơn giá", typeof(float));
            dt.Columns.Add("Đơn vị", typeof(string));
            dt.Columns.Add("Số lượng", typeof(int));
            guna2DataGridView1.DataSource = dt;
        }

        public void LoadDon(int MaDon)
        {
            dt.Clear();
            labelMaDon.Text = "Chi tiết đơn: " + MaDon;
            using(DBEntities db=new DBEntities())
            {
                var Don=db.DonDatPhongs.Find(MaDon);
                var DSDichVu = db.ChiTietDichVuDats.Where(p => p.MaDonDatPhong == MaDon);
                var PhongDat = db.ChiTietPhongDats.Where(p => p.MaDonDatPhong == MaDon).FirstOrDefault();
                var Phong = db.Phongs.Find(PhongDat.MaPhong);
                var LoaiPhong = db.LoaiPhongs.Find(Phong.MaLoaiPhong);
                var Khach = db.Khaches.Find(Don.MaKhach);
                var NhanVienDat = db.NhanViens.Find(Don.MaNhanVienThucHien);
                labelMaPhong.Text = "Mã phòng: "+Phong.MaPhong;labelTenLoaiPhong.Text = "Loại phòng: " + LoaiPhong.TenLoaiPhong;
                labelTang.Text = "Tầng: " + Phong.Tang;labelThuTu.Text = "Thứ tự: " + Phong.ThuTu;labelGiaPhong.Text = PhongDat.GiaPhongDat.ToString();
                labelMaKhach.Text = "Mã khách: " + Khach.MaKhach;labelTenKhach.Text = "Họ và tên: " + Khach.TenKhach;labelGioiTinhKhach.Text = "Giới tính: " + Khach.GioiTinh;
                labelNgaySinhKhach.Text = "Ngày sinh: " + Khach.NgaySinh.Date;labelSDTKhach.Text = "SDT: " + Khach.SoDienThoai;
                labelNgayNhan.Text = "Ngày nhận: "+Don.NgayDat;labelMaNVDat.Text = "Mã nhân viên đặt            : " + NhanVienDat.MaNhanVien;
                labelTenNVDat.Text = "Họ và tên: "+NhanVienDat.TenNhanVien;labelGTNVDat.Text = "Giới tính: "+NhanVienDat.GioiTinh;labelChucVuNVDat.Text = "Chức vụ: "+NhanVienDat.ChucVu;
                if (Don.NgayTra != null)
                {
                    var NhanVienThanhToan = db.NhanViens.Find(Don.MaNhanVienThanhToan);
                    labelNgayTra.Text = "Ngày trả    : " + Don.NgayTra; labelMaNVThanhToan.Text = "Mã nhân viên thanh toán: " + NhanVienThanhToan.MaNhanVien;
                    labelTenNVThanhToan.Text = "Họ và tên: " + NhanVienThanhToan.TenNhanVien; labelGTNVThanhToan.Text = "Giới tính: "+NhanVienThanhToan.GioiTinh; labelChucVuNVThanhToan.Text = "Chức vụ: " + NhanVienThanhToan.ChucVu;
                    labelTongTien.Text = "Tổng tiền: "+Don.TongTien.ToString();
                }
                labelTinhTrangTToan.Text= "Tình trạng thanh toán: "+Don.TinhTrangThanhToan;
                foreach(ChiTietDichVuDat DVvaSL in DSDichVu) {
                    var DVDaChon = db.LoaiDichVus.Find(DVvaSL.MaDichVu);
                    DataRow KtraDVDaCoChua = dt.Rows.Cast<DataRow>().FirstOrDefault(row => Convert.ToInt32(row["Mã dịch vụ"]) == DVvaSL.MaDichVu);
                    if (KtraDVDaCoChua == null)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["Mã dịch vụ"] = DVvaSL.MaDichVu;
                        newRow["Tên dịch vụ"] = DVDaChon.TenDichVu;
                        newRow["Đơn giá"] = DVDaChon.DonGia;
                        newRow["Đơn vị"] = DVDaChon.DonVi;
                        newRow["Số lượng"] = DVvaSL.SoLuong;
                        dt.Rows.Add(newRow);
                    }
                    else KtraDVDaCoChua["Số lượng"] = Convert.ToInt32(KtraDVDaCoChua["Số lượng"]) + DVvaSL.SoLuong;
                }
            }
        }
    }
}
