﻿using System;
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
                using (DBEntities db = new DBEntities())
                {
                    guna2DataGridView1.DataSource = db.ChiTietPhongDats.Select(p => new { p.MaDonDatPhong, p.MaPhong }).ToList();
                }
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
