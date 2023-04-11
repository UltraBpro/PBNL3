using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class BaoCaoHD : Form
    {                  
        public BaoCaoHD(int s, DateTime ngayden, DateTime ngaydi)
        {
            InitializeComponent();
            Load_DGV(s, ngayden, ngaydi);
        }
        private void SetDGV(DateTime ngayden, DateTime ngaydi)
        {
            DBEntities db = new DBEntities();
            label8.Text = ngayden.ToString("dd/MM/yyyy");
            label7.Text = ngaydi.ToString("dd/MM/yyyy");
            guna2DataGridView1.DataSource = db.DonDatPhongs
                                        .Where(d => d.TinhTrangThanhToan == "Done" && d.NgayDat >= ngayden && d.NgayTra <= ngaydi)
                                        .Join(db.Khaches, d => d.MaKhach, k => k.MaKhach, (d, k) => new { d, k })
                                        .Join(db.ChiTietPhongDats, dk => dk.d.MaDonDatPhong, p => p.MaDonDatPhong, (dk, p) => new { dk, p })
                                        .Join(db.ChiTietDichVuDats, dkp => dkp.dk.d.MaDonDatPhong, dv => dv.MaDonDatPhong, (dkp, dv) => new
                                        {
                                            dkp.dk.d.MaDonDatPhong,
                                            dkp.dk.k.TenKhach,
                                            dkp.dk.d.NgayDat,
                                            dkp.dk.d.NgayTra,
                                            dv.GiaDichVuDat,
                                            dkp.p.GiaPhongDat,
                                            dkp.dk.d.GiaTien,
                                        }).ToList();                                        
        }
        private void Load_DGV(int s, DateTime ngayden, DateTime ngaydi)
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
            SetDGV(ngayden, ngaydi);
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}
