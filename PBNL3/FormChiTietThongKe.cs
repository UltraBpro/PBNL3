using Guna.UI2.WinForms;
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
    public partial class FormChiTietThongKe : Form
    {
        public FormChiTietThongKe(int selectedMonth, int selectedYear, bool type)
        {
            InitializeComponent();
            SetDGV(selectedMonth, selectedYear, type);
        }
        public void SetDGV(int selectedMonth, int selectedYear, bool type)
        {
            using (DBEntities db = new DBEntities())
            {
                if (type)
                {
                    labeTitle.Text = "Chi tiết phòng: ";
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
                                        }).ToList();
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
                    dgvThongKe.DataSource = dataTable;
                }
                else
                {
                    labeTitle.Text = "Chi tiết dịch vụ: ";
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
                                SoLuongDaDat = g.Sum(x => x.dv1.ctdv.SoLuong),
                                Tong = g.Sum(x => x.dv1.ctdv.SoLuong * x.dv1.ctdv.GiaDichVuDat)
                            });
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Mã loại dịch vụ", typeof(int));
                    dataTable.Columns.Add("Tên dịch vụ", typeof(string));
                    dataTable.Columns.Add("Giá dịch vụ đặt", typeof(float));
                    dataTable.Columns.Add("Số lượng đã đặt", typeof(int));
                    dataTable.Columns.Add("Tổng", typeof(float));
                    foreach (var item in dv)
                    {
                        DataRow row = dataTable.NewRow();
                        row["Mã loại dịch vụ"] = item.MaLoaiDichVu;
                        row["Tên dịch vụ"] = item.TenDichVu;
                        row["Giá dịch vụ đặt"] = item.Gia;
                        row["Số lượng đã đặt"] = item.SoLuongDaDat;
                        row["Tổng"] = item.Tong;
                        dataTable.Rows.Add(row);
                    }
                    dgvThongKe.DataSource = dataTable;
                }                                  
            }
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
