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
    public partial class FormDatPhong : Form
    {
        public FormDatPhong(int? MaPhong=null)
        {
            InitializeComponent();
            guna2DateTimePicker1.Value = DateTime.Now;
            if (MaPhong != null)
            {
                ButtonChonPhong.Enabled = false;
                ButtonChonPhong.Text = "Mã phòng đã chọn: " + MaPhong + ".";
            }
        }

    private void LoadFormDatPhong()
        {
            guna2DateTimePicker1.TextAlign = HorizontalAlignment.Center;
            
        }

        private void ButtonChonKhach_Click(object sender, EventArgs e)
        {
            FormChonKhach chonKhach = new FormChonKhach();
            chonKhach.GuiKhachDi += NhanDSKhach;
            chonKhach.FormClosed += FormHoiSinh;
            this.Hide();
            chonKhach.Show();
        }
        private void ButtonChonPhong_Click(object sender, EventArgs e)
        {
            FormChonPhong chonPhong = new FormChonPhong("DatPhong");
            chonPhong.GuiPhongDi += NhanDSPhong;
            chonPhong.FormClosed += FormHoiSinh;
            this.Hide();           
            chonPhong.Show();
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
                int khachduocchon = Convert.ToInt32(ButtonChonKhach.Text.Substring(0, ButtonChonKhach.Text.Length - 1).Split(':')[1].Trim());
                int phongduocchon = Convert.ToInt32(ButtonChonPhong.Text.Substring(0, ButtonChonPhong.Text.Length - 1).Split(':')[1].Trim());
                using (DBEntities db = new DBEntities())
            {
                DonDatPhong newdon = new DonDatPhong();
                newdon.MaDonDatPhong = (db.DonDatPhongs.Max(x => (int?)x.MaDonDatPhong) ?? 0) + 1;
                newdon.MaNhanVienThucHien = NhanVienThucHien.MaNhanVien;
                newdon.NgayDat = guna2DateTimePicker1.Value;
                newdon.MaKhach=khachduocchon ;
                newdon.TinhTrangThanhToan = "Chưa thanh toán";
                db.DonDatPhongs.Add(newdon);db.SaveChanges();
                ChiTietPhongDat phongdat = new ChiTietPhongDat();
                phongdat.MaDonDatPhong = newdon.MaDonDatPhong;
                phongdat.MaPhong = phongduocchon;
                var PhongDangThaoTac=db.Phongs.Find(phongdat.MaPhong);
                phongdat.GiaPhongDat = db.LoaiPhongs.Find(PhongDangThaoTac.MaLoaiPhong).GiaTien;
                db.ChiTietPhongDats.Add(phongdat);db.SaveChanges();
                PhongDangThaoTac.TinhTrang = "Kín";db.SaveChanges();
            }
            this.Close();
        }
        private void NhanDSKhach(object sender, int e)
        {
            ButtonChonKhach.Text = "Mã khách đã chọn: " + e.ToString()+".";
        }
        private void NhanDSPhong(object sender, int e)
        {
            ButtonChonPhong.Text = "Mã phòng đã chọn: "+e.ToString() + ".";
        }
        private void FormHoiSinh(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
