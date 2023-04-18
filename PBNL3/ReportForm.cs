using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class ReportForm : Form
    {                               
        public ReportForm(int s, int t, DateTime ngayden, DateTime ngaydi)
        {
            InitializeComponent();
            SetDGV(s, t, ngayden, ngaydi);
            SetLable(t);
        }
        private void SetLable(int type)
        {           
            switch (type)
            {
                case 0:
                    LableTitle.Text = "BÁO CÁO CHI TIẾT DOANH THU HÓA ĐƠN";
                    break;
                case 1:
                    LableTitle.Text = "BÁO CÁO CHI TIẾT DOANH THU PHÒNG";
                    break;
                default:
                    LableTitle.Text = "BÁO CÁO CHI TIẾT DOANH THU DỊCH VỤ";
                    break;
            }
        }
        private void LoadDGV(int s, int t, DateTime ngayden, DateTime ngaydi)
        {           
            if(s == 0)
            {
                LableToday.Text = "Trong ngày " + ngayden.ToString("dd/MM/yyyy");
                LableDate.Visible= false;
            }
            else {            
                LableDate.Text = "Từ ngày " + ngayden.ToString("dd/MM/yyyy") + " đến " + ngaydi.ToString("dd/MM/yyyy");
                LableToday.Visible= false;
                DBEntities db = new DBEntities();
                switch (t)
                {
                    case 0:
                        guna2DataGridView1.DataSource = db.DonDatPhongs
                                                        .Where(d => d.TinhTrangThanhToan == "Done" && d.NgayDat >= ngayden && d.NgayTra <= ngaydi)
                                                        .Join(db.Khaches, d => d.MaKhach, k => k.MaKhach, (d, k) => new { d, k })
                                                        .Join(db.ChiTietPhongDats, dk => dk.d.MaDonDatPhong, p => p.MaDonDatPhong, (dk, p) => new { dk, p })
                                                        .GroupJoin(db.ChiTietDichVuDats, dkp => dkp.dk.d.MaDonDatPhong, dv => dv.MaDonDatPhong, (dkp, dv) => new { dkp, dv })
                                                        .SelectMany(x => x.dv.DefaultIfEmpty(), (x, dv) => new
                                                        {
                                                            x.dkp.dk.d.MaDonDatPhong,
                                                            x.dkp.dk.k.TenKhach,
                                                            x.dkp.dk.d.NgayDat,
                                                            x.dkp.dk.d.NgayTra,
                                                            HasDichVu = dv != null,
                                                            GiaDichVuDat = dv != null ? dv.GiaDichVuDat : 0,
                                                            x.dkp.p.GiaPhongDat,
                                                            x.dkp.dk.d.TongTien,
                                                        }).ToList();
                        break;
                    case 1:
                        guna2DataGridView1.DataSource = db.DonDatPhongs
                                            .Where(d => d.TinhTrangThanhToan == "Done" && d.NgayDat >= ngayden && d.NgayTra <= ngaydi)
                                            .Join(db.ChiTietPhongDats, d => d.MaDonDatPhong, p1 => p1.MaDonDatPhong, (d, p1) => new { d, p1 })
                                            .Join(db.Phongs, dp1 => dp1.p1.MaPhong, p2 => p2.MaPhong, (dp1, p2) => new { dp1, p2 })
                                            .Join(db.LoaiPhongs, dp2 => dp2.p2.MaLoaiPhong, p3 => p3.MaLoaiPhong, (dp2, p3) => new
                                            {
                                                p3.MaLoaiPhong,
                                                p3.TenLoaiPhong,
                                                dp2.dp1.p1.MaPhong,
                                                p3.DienTich,
                                                p3.SoGiuong,
                                                p3.GiaTien,
                                                p3.GhiChu,
                                            }).ToList();
                        break;
                    default:
                        guna2DataGridView1.DataSource = db.DonDatPhongs
                                            .Where(d => d.TinhTrangThanhToan == "Done" && d.NgayDat >= ngayden && d.NgayTra <= ngaydi)
                                            .Join(db.ChiTietDichVuDats, d => d.MaDonDatPhong, ctdv => ctdv.MaDonDatPhong, (d, ctdv) => new { d, ctdv })
                                            .Join(db.LoaiDichVus, dv1 => dv1.ctdv.MaDichVu, ldv => ldv.MaLoaiDichVu, (dv1, ldv) => new
                                            {
                                                ldv.MaLoaiDichVu,
                                                ldv.TenDichVu,
                                                ldv.DonGia,
                                                dv1.ctdv.SoLuong,
                                                dv1.ctdv.GiaDichVuDat,
                                            }).ToList();
                        break;
                }
            }                                 
        }
        private void SetDGV(int s, int t, DateTime ngayden, DateTime ngaydi)
        {
            switch (s)
            {
                case 0:
                    ngayden = DateTime.Today;
                    ngaydi = DateTime.Now;                   
                    break;
                case 1:
                    ngayden = DateTime.Today.AddDays(-1);
                    ngaydi = DateTime.Today;                  
                    break;
                case 2:
                    ngayden = DateTime.Today.AddDays(-6);
                    ngaydi = DateTime.Now;
                    break;
                case 3:
                    ngayden = DateTime.Today.AddDays(-29);
                    ngaydi = DateTime.Now;
                    break;
                case 4:
                    ngayden = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    ngaydi = ngayden.AddMonths(1).AddDays(-1);                    
                    break;
                case 5:
                    ngayden = new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, 1);
                    ngaydi = ngayden.AddMonths(1).AddDays(-1);
                    break;
                case 6:
                    ngayden = DateTime.MinValue;
                    ngaydi = DateTime.MaxValue;
                    break;               
                default:                    
                    break;
            }            
            LoadDGV(s, t, ngayden, ngaydi);
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}
