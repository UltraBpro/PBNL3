using System;
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
            using (DBEntities db = new DBEntities())
            {
                guna2DataGridView1.DataSource = db.NhanViens.Select(p => new
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

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (SwitchNVMoi.Checked)
            {
                using (DBEntities db = new DBEntities())
                {
                    NhanVien newNhanVien = new NhanVien();
                    newNhanVien.MaNhanVien = (db.NhanViens.Max(x => (int?)x.MaNhanVien) ?? 0) + 1;
                    newNhanVien.TenNhanVien = TextBoxHoVaTen.Text;
                    newNhanVien.GioiTinh = radioButtonNam.Checked ? "Nam" : "Nữ";
                    newNhanVien.NgayNhanViec = DateTimePickerNgaySinh.Value;
                    newNhanVien.Luong = Convert.ToDouble(TextBoxLuong.Text);
                    newNhanVien.ChucVu = TextBoxChucVu.Text;
                    db.NhanViens.Add(newNhanVien); db.SaveChanges();
                }
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
