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
    public partial class FormTraPhong : Form
    {
        public FormTraPhong(int? MaPhong = null)
        {
            InitializeComponent();
            if (MaPhong != null)
            {
                ButtonChonPhong.Enabled = false;
                ButtonChonPhong.Text = "Mã phòng đã chọn: " + MaPhong + ".";
            }
        }

        private void ButtonChonPhong_Click(object sender, EventArgs e)
        {
            FormChonPhong chonPhong = new FormChonPhong("GoiDichVu");
            chonPhong.GuiPhongDi += NhanDSPhongVaTinhTien;
            chonPhong.FormClosed += FormHoiSinh;
            this.Hide();
            chonPhong.Show();
        }
        private void NhanDSPhongVaTinhTien(object sender, int e)
        {
            ButtonChonPhong.Text = "Mã phòng đã chọn: " + e.ToString() + ".";
            using (DBEntities db = new DBEntities())
            {
                int phongduochon = Convert.ToInt32(ButtonChonPhong.Text.Substring(0, ButtonChonPhong.Text.Length - 1).Split(':')[1].Trim());
                var TimDonDatDichVu = db.DonDatPhongs.Join(db.ChiTietPhongDats,
              don => don.MaDonDatPhong,
              phongdat => phongdat.MaDonDatPhong,
              (don, phongdat) => new
              {
                  don.MaDonDatPhong,
                  phongdat.MaPhong,
                  don.TinhTrangThanhToan
              }).Where(p => p.TinhTrangThanhToan != "Đã thanh toán" && p.MaPhong == phongduochon).FirstOrDefault();
                var DonDat = db.DonDatPhongs.Find(TimDonDatDichVu.MaDonDatPhong);
                var DSDichVuSD = db.ChiTietDichVuDats.Where(p => p.MaDonDatPhong == TimDonDatDichVu.MaDonDatPhong);
                var PhongDat=db.ChiTietPhongDats.Where(p => p.MaDonDatPhong == TimDonDatDichVu.MaDonDatPhong).FirstOrDefault();
                DonDat.NgayTra = DateTime.Now;
                int songay = (int)DateTime.Now.Subtract(DonDat.NgayDat).TotalDays;
                DonDat.TongTien = songay * PhongDat.GiaPhongDat;
                foreach (ChiTietDichVuDat DVSD in DSDichVuSD) DonDat.TongTien += DVSD.GiaDichVuDat*DVSD.SoLuong;
                guna2TextBox1.Text = DonDat.TongTien.ToString();
            }
        }
        private void ButtonXacNhan_Click(object sender, EventArgs e)
        {
            using (DBEntities db = new DBEntities())
            {
                int phongduochon = Convert.ToInt32(ButtonChonPhong.Text.Substring(0, ButtonChonPhong.Text.Length - 1).Split(':')[1].Trim());
                var TimDonDatDichVu = db.DonDatPhongs.Join(db.ChiTietPhongDats,
              don => don.MaDonDatPhong,
              phongdat => phongdat.MaDonDatPhong,
              (don, phongdat) => new
              {
                  don.MaDonDatPhong,
                  phongdat.MaPhong,
                  don.TinhTrangThanhToan
              }).Where(p => p.TinhTrangThanhToan != "Đã thanh toán" && p.MaPhong == phongduochon).FirstOrDefault();
                var DonDat = db.DonDatPhongs.Find(TimDonDatDichVu.MaDonDatPhong);
                DonDat.TinhTrangThanhToan = "Đã thanh toán";db.SaveChanges();
                db.Phongs.Find(phongduochon).TinhTrang = "Trống"; db.SaveChanges();
                this.Close();
                }
            }
        private void FormHoiSinh(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }


    }
}
