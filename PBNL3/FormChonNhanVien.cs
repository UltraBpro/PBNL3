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
        public event EventHandler<int> GuiNVDi;
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
            int selectedNV = -1;
            if (SwitchNVMoi.Checked)
            {
                NhanVien_BLL nhanVien_BLL = new NhanVien_BLL();
                selectedNV=nhanVien_BLL.ThemNhanVien(TextBoxHoVaTen.Text, radioButtonNam.Checked, DateTimePickerNgaySinh.Value, Convert.ToDouble(TextBoxLuong.Text), TextBoxChucVu.Text);       
            }
            else
            {
                foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
                {
                    selectedNV = Convert.ToInt32(row.Cells["MaNhanVien"].Value);
                }
            }
            GuiNVDi?.Invoke(this, selectedNV);
            this.Close();
        }

        private void SwitchNVMoi_CheckedChanged(object sender, EventArgs e)
        {
            if (SwitchNVMoi.Checked) { this.Size = new Size(618, 430); labelNgayNhan.Visible = true; }
            else { this.Size = new Size(618, 332); labelNgayNhan.Visible = false; }
            this.CenterToScreen();
        }

        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            NhanVien_BLL nhanVien_BLL = new NhanVien_BLL();
            if (nhanVien_BLL.TimChucVu() != "Quản lý") MessageBox.Show("Bạn không đủ quyền hạn thực hiện chức năng này.");
            else
            {
                Account_BLL account_BLL = new Account_BLL();
                TaiKhoan tempAcc = account_BLL.CheckTK(Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["MaNhanVien"].Value));
                if (tempAcc != null)
                {
                    MessageBox.Show("Có tài khoản đã được cấp cho nhân viên này, vui lòng liên hệ admin để xóa tài khoản trước.");
                }
                else nhanVien_BLL.XoaNhanVien(Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["MaNhanVien"].Value));
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
        }
    }
}
