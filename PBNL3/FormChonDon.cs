using PBNL3.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class FormChonDon : Form
    {
        public FormChonDon(DataTable dataTable = null)
        {
            InitializeComponent();
            if (dataTable != null)
            {
                guna2DataGridView1.DataSource = dataTable;
            }
            else
            {
                Phong_BLL phong_BLL = new Phong_BLL();
                List<ChiTietPhongDat> chiTietPhongDats = phong_BLL.LayDSChiTietPhongDat();
                guna2DataGridView1.DataSource = chiTietPhongDats.Select(p => new { p.MaDonDatPhong, p.MaPhong }).ToList();
            }
        }
        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try { userControlChiTietDonHang1.LoadDon(Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["MaDonDatPhong"].Value)); }
            catch { }
        }
    }
}
