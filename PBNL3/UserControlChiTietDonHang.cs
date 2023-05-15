using PBNL3.BLL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class UserControlChiTietDonHang : UserControl
    {
        DataTable dt = new DataTable();
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
                Don_BLL don_BLL = new Don_BLL();
                DichVu_BLL dichVu_BLL = new DichVu_BLL();
                Phong_BLL phong_BLL = new Phong_BLL();
                Khach_BLL khach_BLL = new Khach_BLL();
                NhanVien_BLL nhanVien_BLL = new NhanVien_BLL();
                var Don = don_BLL.GetDonDat(MaDon);
                var DSDichVu = dichVu_BLL.LayDSDichVuDaSuDung(MaDon);
                var PhongDat = phong_BLL.GetPhongDat(MaDon);
                var Phong = phong_BLL.GetPhong(PhongDat.MaPhong);
                var LoaiPhong = phong_BLL.GetLoaiPhong(Phong.MaLoaiPhong);
                var Khach = khach_BLL.GetKhach(Don.MaKhach);
                var NhanVienDat = nhanVien_BLL.GetNV(Don.MaNhanVienThucHien);
                labelMaPhong.Text = "Mã phòng: " + Phong.MaPhong; labelTenLoaiPhong.Text = "Loại phòng: " + LoaiPhong.TenLoaiPhong;
                labelTang.Text = "Tầng: " + Phong.Tang; labelThuTu.Text = "Thứ tự: " + Phong.ThuTu; labelGiaPhong.Text = "Giá/Ngày: " + PhongDat.GiaPhongDat;
                labelMaKhach.Text = "Mã khách: " + Khach.MaKhach; labelTenKhach.Text = "Họ và tên: " + Khach.TenKhach; labelGioiTinhKhach.Text = "Giới tính: " + Khach.GioiTinh;
                labelNgaySinhKhach.Text = "Ngày sinh: " + Khach.NgaySinh.Date; labelSDTKhach.Text = "SDT: " + Khach.SoDienThoai;
                labelNgayNhan.Text = "Ngày nhận: " + Don.NgayDat; labelMaNVDat.Text = "Mã nhân viên đặt            : " + NhanVienDat.MaNhanVien;
                labelTenNVDat.Text = "Họ và tên: " + NhanVienDat.TenNhanVien; labelGTNVDat.Text = "Giới tính: " + NhanVienDat.GioiTinh; labelChucVuNVDat.Text = "Chức vụ: " + NhanVienDat.ChucVu;
                if (Don.NgayTra != null)
                {
                    var NhanVienThanhToan = nhanVien_BLL.GetNV((int)Don.MaNhanVienThanhToan);
                    labelNgayTra.Text = "Ngày trả    : " + Don.NgayTra; labelMaNVThanhToan.Text = "Mã nhân viên thanh toán: " + NhanVienThanhToan.MaNhanVien;
                    labelTenNVThanhToan.Text = "Họ và tên: " + NhanVienThanhToan.TenNhanVien; labelGTNVThanhToan.Text = "Giới tính: " + NhanVienThanhToan.GioiTinh; labelChucVuNVThanhToan.Text = "Chức vụ: " + NhanVienThanhToan.ChucVu;
                    labelTongTien.Text = "Tổng tiền: " + Don.TongTien;
                }
                else
                {
                    labelNgayTra.Text = "Ngày trả    : "; labelMaNVThanhToan.Text = "Mã nhân viên thanh toán: ";
                    labelTenNVThanhToan.Text = "Họ và tên: "; labelGTNVThanhToan.Text = "Giới tính: "; labelChucVuNVThanhToan.Text = "Chức vụ: ";
                    int songay = (int)DateTime.Now.Subtract(Don.NgayDat).TotalDays + 1;
                    Don.TongTien = songay * PhongDat.GiaPhongDat;
                    foreach (ChiTietDichVuDat DVSD in DSDichVu) Don.TongTien += DVSD.GiaDichVuDat * DVSD.SoLuong;
                    labelTongTien.Text = "Tổng tiền: " + Don.TongTien;
                }
                labelTinhTrangTToan.Text = "Tình trạng thanh toán: " + Don.TinhTrangThanhToan;
            foreach (ChiTietDichVuDat DVvaSL in DSDichVu)
            {               
                var DVDaChon = dichVu_BLL.TimDV(DVvaSL.MaDichVu);
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
        public void LoadPhong(int MaPhong)
        {
           Don_BLL don_BLL = new Don_BLL();
                this.LoadDon(don_BLL.GetMaDonDatPhongThongQuaPhong(MaPhong));
            
        }
    }
}
