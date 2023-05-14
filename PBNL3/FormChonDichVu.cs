using PBNL3.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class FormChonDichVu : Form
    {
        public event EventHandler<int> GuiDichVuDi;
        public FormChonDichVu()
        {
            InitializeComponent();
            DichVu_BLL dichVu_BLL = new DichVu_BLL();
            List<LoaiDichVu> loaiDichVus = dichVu_BLL.LayDSDichVu();
            guna2DataGridView1.DataSource = loaiDichVus
                .Select(p => new
                {
                    p.MaLoaiDichVu,
                    p.TenDichVu,
                    p.DonGia,
                    p.DonVi,
                }).ToList();

        }
        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            int selectedDichVu = -1;
            if (SwitchDVmoi.Checked)
            {
                DichVu_BLL dichVu_BLL = new DichVu_BLL();
                selectedDichVu = dichVu_BLL.ThemDichVu(TextBoxTenDV.Text, Convert.ToDouble(TextBoxDonGia.Text), TextBoxDonVi.Text);
            }
            else
            {
                foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
                {
                    selectedDichVu = Convert.ToInt32(row.Cells["MaLoaiDichVu"].Value);
                }
            }
            GuiDichVuDi?.Invoke(this, selectedDichVu);
            this.Close();
        }

        private void SwitchDVmoi_CheckedChanged(object sender, EventArgs e)
        {
            NhanVien_BLL nhanVien_BLL = new NhanVien_BLL();
              if (SwitchDVmoi.Checked && nhanVien_BLL.TimChucVu() != "Quản lý") { SwitchDVmoi.Checked = false; MessageBox.Show("Bạn không đủ quyền hạn thực hiện chức năng này."); }
            
            if (SwitchDVmoi.Checked) { this.Size = new Size(618, 379); }
            else { this.Size = new Size(618, 332); }
            this.CenterToScreen();
        }
    }
}
