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
            foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
            {
                selectedDichVu = Convert.ToInt32(row.Cells["MaLoaiDichVu"].Value);
            }
            GuiDichVuDi?.Invoke(this, selectedDichVu);
            this.Close();
        }
    }
}
