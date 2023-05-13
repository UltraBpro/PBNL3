using PBNL3.BLL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class FormDatPhong : Form
    {
        public FormDatPhong(int? MaPhong = null)
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
            Phong_BLL phong_BLL = new Phong_BLL();
            phong_BLL.DatPhong(NhanVienThucHien.MaNhanVien, khachduocchon, phongduocchon, guna2DateTimePicker1.Value);
            this.Close();
        }
        private void NhanDSKhach(object sender, int e)
        {
            ButtonChonKhach.Text = "Mã khách đã chọn: " + e.ToString() + ".";
            if (ButtonChonKhach.Text != "Chọn khách" && ButtonChonPhong.Text != "Chọn phòng") ButtonXacNhan.Enabled = true;
        }
        private void NhanDSPhong(object sender, int e)
        {
            ButtonChonPhong.Text = "Mã phòng đã chọn: " + e.ToString() + ".";
            if (ButtonChonKhach.Text != "Chọn khách" && ButtonChonPhong.Text != "Chọn phòng") ButtonXacNhan.Enabled = true;
        }
        private void FormHoiSinh(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
