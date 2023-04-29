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
    public partial class FormChonKhach : Form
    {
        public event EventHandler<int> GuiKhachDi;
        public FormChonKhach()
        {
            InitializeComponent();
            using (DBEntities db = new DBEntities()) {
                guna2DataGridView1.DataSource = db.Khaches.Select(p => new
                {
                    p.MaKhach,
                    p.TenKhach,
                    p.GioiTinh,
                    p.NgaySinh,
                    p.SoDienThoai
                }).ToList();
            }
            guna2DataGridView1.AllowUserToAddRows = true;
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            int selectedKhach=-1;
            if (SwitchKhachMoi.Checked) {
                using (DBEntities db= new DBEntities())
                {
                    Khach newKhach = new Khach();
                    newKhach.MaKhach=(db.Khaches.Max(x => (int?)x.MaKhach) ?? 0) + 1;
                    newKhach.TenKhach = TextBoxHoVaTen.Text;
                    newKhach.GioiTinh=radioButtonNam.Checked ? "Nam":"Nữ";
                    newKhach.NgaySinh = DateTimePickerNgaySinh.Value;
                    newKhach.SoDienThoai = TextBoxSDT.Text;
                    db.Khaches.Add(newKhach);db.SaveChanges();
                    selectedKhach = newKhach.MaKhach;
                }
            }
            else
            foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
            {
                selectedKhach=Convert.ToInt32(row.Cells["MaKhach"].Value);
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
