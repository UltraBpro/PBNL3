﻿using System;
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
        public FormDungDichVu(int? MaPhong = null)
        {
            InitializeComponent();
            if (MaPhong != null)
            {
                ButtonChonPhong.Enabled = false;
                ButtonChonPhong.Text = "Mã phòng đã chọn: " + MaPhong + ".";
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
                ButtonThemDichVu.Enabled = false;labelDonVi.Text = "ĐƠN VỊ";ButtonChonDichVu.Text = "Chọn dịch vụ";
            }
        }

        private void ButtonXacNhan_Click(object sender, EventArgs e)
        {
            using (DBEntities db = new DBEntities())
            {
                int phongduochon= Convert.ToInt32(ButtonChonPhong.Text.Substring(0, ButtonChonPhong.Text.Length - 1).Split(':')[1].Trim());
                var TimDonDatDichVu = db.DonDatPhongs.Join(db.ChiTietPhongDats,
              don => don.MaDonDatPhong,
              phongdat => phongdat.MaDonDatPhong,
              (don, phongdat) => new
              {
                  don.MaDonDatPhong,
                  phongdat.MaPhong,
                  don.TinhTrangThanhToan
              }).Where(p => p.TinhTrangThanhToan != "Đã thanh toán"&&p.MaPhong==phongduochon).FirstOrDefault();
                foreach(DataRow dtr in dt.Rows)
                {
                    ChiTietDichVuDat datdichvuchodon = new ChiTietDichVuDat();
                    datdichvuchodon.MaDonDatPhong = TimDonDatDichVu.MaDonDatPhong;
                    datdichvuchodon.MaDichVu = Convert.ToInt32(dtr["Mã dịch vụ"]);
                    datdichvuchodon.SoLuong = Convert.ToInt32(dtr["Số lượng"]);
                    datdichvuchodon.GiaDichVuDat = Convert.ToInt32(dtr["Đơn giá"]);
                    db.ChiTietDichVuDats.Add(datdichvuchodon);db.SaveChanges();
                }
                dt.Clear();
            }
        }
    }
}
