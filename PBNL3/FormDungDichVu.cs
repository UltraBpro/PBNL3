using PBNL3.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class FormDungDichVu : Form
    {
        DataTable dt = new DataTable();
        public FormDungDichVu(int? MaPhong = null)
        {
            InitializeComponent();
            if (MaPhong != null)
            {
                ButtonChonPhong.Enabled = false;
                NhanDSPhong(null, (int)MaPhong);
            }
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
            ButtonXacNhan.Enabled = true;
            userControlChiTietDonHang1.LoadPhong(Convert.ToInt32(ButtonChonPhong.Text.Substring(0, ButtonChonPhong.Text.Length - 1).Split(':')[1].Trim()));
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
            var DVDaChon = DichVu_BLL.TimMaDV(e);
            ButtonChonDichVu.Text = DVDaChon.TenDichVu; labelDonVi.Text = DVDaChon.DonVi;
            ButtonThemDichVu.Enabled = true;
        }
        private void FormHoiSinh(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void ButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ButtonThemDichVu_Click(object sender, EventArgs e)
        {
            var DVDaChon = DichVu_BLL.TimMaDV(MaDVDangChon);
            DataRow KtraDVDaCoChua = dt.Rows.Cast<DataRow>().FirstOrDefault(row => Convert.ToInt32(row["Mã dịch vụ"]) == MaDVDangChon);
            if (KtraDVDaCoChua == null)
            {
                DataRow newRow = dt.NewRow();
                newRow["Mã dịch vụ"] = MaDVDangChon;
                newRow["Tên dịch vụ"] = DVDaChon.TenDichVu;
                newRow["Đơn giá"] = DVDaChon.DonGia;
                newRow["Đơn vị"] = DVDaChon.DonVi;
                newRow["Số lượng"] = guna2NumericUpDown1.Value;
                dt.Rows.Add(newRow);
            }
            else KtraDVDaCoChua["Số lượng"] = Convert.ToInt32(KtraDVDaCoChua["Số lượng"]) + guna2NumericUpDown1.Value;
                ButtonThemDichVu.Enabled = false; labelDonVi.Text = "ĐƠN VỊ"; ButtonChonDichVu.Text = "Chọn dịch vụ"; guna2NumericUpDown1.Value = 1;
            }


        private void ButtonXacNhan_Click(object sender, EventArgs e)
        {
            int phongduochon = Convert.ToInt32(ButtonChonPhong.Text.Substring(0, ButtonChonPhong.Text.Length - 1).Split(':')[1].Trim());
            DichVu_BLL dichVu_BLL = new DichVu_BLL();
            dichVu_BLL.DatDichVu(dt, phongduochon);
            this.Close();
        }      

        private void SwitchChiTiet_CheckedChanged(object sender, EventArgs e)
        {
            if (SwitchChiTiet.Checked) { this.Size = new Size(1337, 447); userControlChiTietDonHang1.Visible = true; }
            else { this.Size = new Size(539, 389); userControlChiTietDonHang1.Visible = false; }
            this.CenterToScreen();
        }
    }
}