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
    public partial class FormDungDichVu : Form
    {
        DataTable dt = new DataTable();
        public FormDungDichVu()
        {
            InitializeComponent();
            dt.Columns.Add("Mã dịch vụ", typeof(int));
            dt.Columns.Add("Tên dịch vụ", typeof(string));
            dt.Columns.Add("Đơn giá", typeof(float));
            dt.Columns.Add("Đơn vị", typeof(string));
            dt.Columns.Add("Số lượng", typeof(int));
            guna2DataGridView1.DataSource = dt;
            foreach (DataGridViewColumn col in guna2DataGridView1.Columns) col.ReadOnly = true;
            guna2DataGridView1.Columns["Số lượng"].ReadOnly = false;
        }

        private void ButtonChonPhong_Click(object sender, EventArgs e)
        {
            FormChonPhong chonPhong = new FormChonPhong("GoiDichVu");
            chonPhong.GuiPhongDi += NhanDSPhong;
            chonPhong.FormClosed += FormHoiSinh;
            this.Hide();
            chonPhong.Show();
        }
        private void NhanDSPhong(object sender, int e)
        {
            ButtonChonPhong.Text = "Mã phòng đã chọn: " + e.ToString() + ".";
        }
        private void ButtonChonDichVu_Click(object sender, EventArgs e)
        {
            FormChonDichVu chonDichVu = new FormChonDichVu();
            chonDichVu.GuiDichVuDi += NhanDSDichVu;
            chonDichVu.FormClosed += FormHoiSinh;
            this.Hide();
            chonDichVu.Show();
        }
        int MaDVDangChon;
        private void NhanDSDichVu(object sender, int e)
        {
            MaDVDangChon = e;
            using (DBEntities db = new DBEntities())
            {
                var DVDaChon=db.LoaiDichVus.Find(e);
                ButtonChonDichVu.Text =  DVDaChon.TenDichVu;labelDonVi.Text = DVDaChon.DonVi;
                ButtonThemDichVu.Enabled = true;
            }
        }
        private void FormHoiSinh(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void ButtonThemDichVu_Click(object sender, EventArgs e)
        {
            using (DBEntities db = new DBEntities())
            {
                var DVDaChon = db.LoaiDichVus.Find(MaDVDangChon);
                DataRow newRow = dt.NewRow();
                newRow["Mã dịch vụ"] = MaDVDangChon;
                newRow["Tên dịch vụ"] = DVDaChon.TenDichVu;
                newRow["Đơn giá"] = DVDaChon.DonGia;
                newRow["Đơn vị"] = DVDaChon.DonVi;
                newRow["Số lượng"] = guna2NumericUpDown1.Value;
                dt.Rows.Add(newRow);
                ButtonThemDichVu.Enabled = false;
            }
        }
    }
}
