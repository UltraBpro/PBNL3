using PBNL3.BLL;
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
                BLL.Khach_BLL editBLL = new BLL.Khach_BLL();
                selectedKhach = editBLL.ThemKhachMoi(TextBoxHoVaTen.Text, radioButtonNam.Checked ? "Nam" : "Nữ", DateTimePickerNgaySinh.Value, TextBoxSDT.Text, TextBoxCCCD.Text);
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
    }
}
