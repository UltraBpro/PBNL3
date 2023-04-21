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
    public partial class FormChonNhanVien : Form
    {
        public FormChonNhanVien()
        {
            InitializeComponent();
            using (DBEntities db = new DBEntities())
            {
                guna2DataGridView1.DataSource = db.NhanViens.Select(p => new
                {
                    p.MaNhanVien,p.TenNhanVien,p.GioiTinh,p.NgayNhanViec,p.ChucVu,p.Luong
                }).ToList();
            }
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
