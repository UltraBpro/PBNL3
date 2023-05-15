using PBNL3.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class FormChonNhanVien : Form
    {
        public FormChonNhanVien()
        {
            InitializeComponent();

            NhanVien_BLL nhanVien_BLL = new NhanVien_BLL();
            List<NhanVien> nhanViens = nhanVien_BLL.LayDSNhanVien();
            guna2DataGridView1.DataSource = nhanViens.Select(p => new
            {
                p.MaNhanVien,
                p.TenNhanVien,
                p.GioiTinh,
                p.NgayNhanViec,
                p.ChucVu,
                p.Luong
            }).ToList();
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (SwitchNVMoi.Checked)
            {
                NhanVien_BLL nhanVien_BLL = new NhanVien_BLL();
                nhanVien_BLL.ThemNhanVien(TextBoxHoVaTen.Text, radioButtonNam.Checked, DateTimePickerNgaySinh.Value, Convert.ToDouble(TextBoxLuong.Text), TextBoxChucVu.Text);       
            }
            this.Close();
        }

        private void SwitchNVMoi_CheckedChanged(object sender, EventArgs e)
        {
            if (SwitchNVMoi.Checked) { this.Size = new Size(618, 430); labelNgayNhan.Visible = true; }
            else { this.Size = new Size(618, 332); labelNgayNhan.Visible = false; }
            this.CenterToScreen();
        }
    }
}
