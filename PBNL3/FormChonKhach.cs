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
        public event EventHandler<List<int>> GuiKhachDi;
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
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            List<int> selectedKhachList = new List<int>();
            foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
            {
                selectedKhachList.Add(Convert.ToInt32(row.Cells["MaKhach"].Value));
            }
            GuiKhachDi?.Invoke(this,selectedKhachList);
            this.Close();
        }
    }
}
