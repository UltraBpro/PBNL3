﻿using PBNL3.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class FormChonKhach : Form
    {
        public event EventHandler<int> GuiKhachDi;
        public FormChonKhach()
        {
            InitializeComponent();
            Khach_BLL khach_BLL = new Khach_BLL();
            List<Khach> khaches= khach_BLL.LayDSKhach();
            guna2DataGridView1.DataSource = khaches.Select(p => new
            {
                p.MaKhach,
                p.TenKhach,
                p.GioiTinh,
                p.NgaySinh,
                p.SoDienThoai
            }).ToList();

        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            int selectedKhach = -1;            
            if (SwitchKhachMoi.Checked)
            {
                BLL.Khach_BLL khach_BLL = new BLL.Khach_BLL();
                selectedKhach = khach_BLL.ThemKhachMoi(TextBoxHoVaTen.Text, radioButtonNam.Checked ? "Nam" : "Nữ", DateTimePickerNgaySinh.Value, TextBoxSDT.Text, TextBoxCCCD.Text);
            }
            else
            {
                foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
                {
                    selectedKhach = Convert.ToInt32(row.Cells["MaKhach"].Value);
                }
            }
            GuiKhachDi?.Invoke(this, selectedKhach);
            this.Close();
        }

        private void SwitchKhachMoi_CheckedChanged(object sender, EventArgs e)
        {
            if (SwitchKhachMoi.Checked) { this.Size = new Size(618, 430); labelNgaySinh.Visible = true; }
            else { this.Size = new Size(618, 332); labelNgaySinh.Visible = false; }
            this.CenterToScreen();
        }

        private void ButtonXoa_Click(object sender, EventArgs e)
        {
            NhanVien_BLL nhanVien_BLL = new NhanVien_BLL();
            if (nhanVien_BLL.TimChucVu() != "Quản lý") MessageBox.Show("Bạn không đủ quyền hạn thực hiện chức năng này.");
            else
            {
                Khach_BLL khach_BLL = new Khach_BLL();
                khach_BLL.XoaKhach(Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["MaKhach"].Value));
                List<Khach> khaches = khach_BLL.LayDSKhach();
                guna2DataGridView1.DataSource = khaches.Select(p => new
                {
                    p.MaKhach,
                    p.TenKhach,
                    p.GioiTinh,
                    p.NgaySinh,
                    p.SoDienThoai
                }).ToList();
            }
        }
    }
}
