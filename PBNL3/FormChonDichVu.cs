using System;
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
            using (DBEntities db = new DBEntities())
            {
                guna2DataGridView1.DataSource = db.LoaiDichVus
                    .Select(p => new
                    {
                        p.MaLoaiDichVu,
                        p.TenDichVu,
                        p.DonGia,
                        p.DonVi,
                    }).ToList();
            }
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            int selectedDichVu = -1;
            if (SwitchDVmoi.Checked)
            {
                using (DBEntities db = new DBEntities())
                {
                    LoaiDichVu newDV = new LoaiDichVu();
                    newDV.MaLoaiDichVu = (db.LoaiDichVus.Max(x => (int?)x.MaLoaiDichVu) ?? 0) + 1;
                    newDV.TenDichVu = TextBoxTenDV.Text;
                    newDV.DonGia = Convert.ToDouble(TextBoxDonGia.Text);
                    newDV.DonVi = TextBoxDonVi.Text.ToUpper();
                    db.LoaiDichVus.Add(newDV); db.SaveChanges();
                    selectedDichVu = newDV.MaLoaiDichVu;
                }
            }
            else
                foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
                {
                    selectedDichVu = Convert.ToInt32(row.Cells["MaLoaiDichVu"].Value);
                }
            GuiDichVuDi?.Invoke(this, selectedDichVu);
            this.Close();
        }

        private void SwitchDVmoi_CheckedChanged(object sender, EventArgs e)
        {
            using (DBEntities db = new DBEntities())
            {
                if (SwitchDVmoi.Checked && db.NhanViens.Find(NhanVienThucHien.MaNhanVien).ChucVu != "Quản lý") { SwitchDVmoi.Checked = false; MessageBox.Show("Bạn không đủ quyền hạn thực hiện chức năng này."); }
            }
            if (SwitchDVmoi.Checked) { this.Size = new Size(618, 379); }
            else { this.Size = new Size(618, 332); }
            this.CenterToScreen();
        }
    }
}
