﻿using FontAwesome.Sharp;
using PBNL3.BLL;
using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace PBNL3
{

    public partial class FormManHinhChinh : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        public FormManHinhChinh(int MaTaiKhoan)
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 40);
            panel2.Controls.Add(leftBorderBtn);
            OpenChildForm();
            LoadNhanVien(MaTaiKhoan);
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm()
        {
            panel4.Controls.Clear();
            FormSoDoPhong childForm = new FormSoDoPhong();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel4.Controls.Add(childForm);
            panel4.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(172, 126, 241));
            iconPictureBox1.IconChar = iconButton1.IconChar;
            labelTrangThai.Text = iconButton1.Text;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(249, 118, 176));
            iconPictureBox1.IconChar = iconButton2.IconChar;
            labelTrangThai.Text = iconButton2.Text;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(253, 138, 114));
            iconPictureBox1.IconChar = iconButton3.IconChar;
            labelTrangThai.Text = iconButton3.Text;
        }
        private void iconButton6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //private void iconButton5_Click(object sender, EventArgs e)
        //{
        //    if (WindowState == FormWindowState.Normal)
        //        WindowState = FormWindowState.Maximized;
        //    else
        //        WindowState = FormWindowState.Normal;
        //}

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void LoadNhanVien(int MaTaiKhoan)
        {
            NhanVien_BLL nhanVien_BLL = new NhanVien_BLL();
            var NV = nhanVien_BLL.TimNhanVien(MaTaiKhoan);
            NhanVienThucHien.MaNhanVien = NV.MaNhanVien;
            labelMaNV.Text = NV.MaNhanVien.ToString();
            labelTenNV.Text = NV.TenNhanVien;
            labelChucVu.Text = NV.ChucVu; if (NV.ChucVu == "Quản lý") quảnLýToolStripMenuItem.Enabled = true;
        }
        private void DatPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDatPhong DatPhong = new FormDatPhong();
            DatPhong.Show();
            this.Enabled = false;
            DatPhong.FormClosed += FormHoiSinh;
        }

        private void DungDichVuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDungDichVu DungDichVu = new FormDungDichVu();
            DungDichVu.Show();
            this.Enabled = false;
            DungDichVu.FormClosed += FormHoiSinh;
        }

        private void TraPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTraPhong TraPhong = new FormTraPhong();
            TraPhong.Show();
            this.Enabled = false;
            TraPhong.FormClosed += FormHoiSinh;
        }


        private void DSKhachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChonKhach DSKhach = new FormChonKhach();
            DSKhach.Show();
            this.Enabled = false;
            DSKhach.FormClosed += FormHoiSinh;
        }

        private void DSPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChonPhong DSPhong = new FormChonPhong("LietKe");
            DSPhong.Show();
            this.Enabled = false;
            DSPhong.FormClosed += FormHoiSinh;
        }
        private void DanhSachDVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChonDichVu DSDichVu = new FormChonDichVu();
            DSDichVu.Show();
            this.Enabled = false;
            DSDichVu.FormClosed += FormHoiSinh;
        }

        private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Delete("LoginInfo.txt");
            FormLogin LoginLai = new FormLogin();
            LoginLai.Show();
            this.Close();
        }

        private void DoiMKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDoiMK doiMK = new FormDoiMK();
            doiMK.Show();
            this.Enabled = false;
            doiMK.FormClosed += FormHoiSinh;
        }


        private void DSDonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormChonDon ListDon = new FormChonDon();
            ListDon.Show();
            this.Enabled = false;
            ListDon.FormClosed += FormHoiSinh;
        }

        private void QuanLyNVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChonNhanVien ListNV = new FormChonNhanVien();
            ListNV.Show();
            this.Enabled = false;
            ListNV.FormClosed += FormHoiSinh;
        }

        private void ThongKeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormThongKe ThongKhe = new FormThongKe();
            ThongKhe.Show();
            this.Enabled = false;
            ThongKhe.FormClosed += FormHoiSinh;
        }

        public void FormHoiSinh(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            this.Focus();
            OpenChildForm();
        }

        private void LoaiPhongtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChonLoaiPhong loaiP = new FormChonLoaiPhong();
            loaiP.Show();
            this.Enabled = false;
            loaiP.FormClosed += FormHoiSinh;
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            labelTrangThai.Text = "Trang chủ";
            iconPictureBox1.IconChar = IconChar.Home;
            DisableButton(); leftBorderBtn.Visible = false;
        }
    }
    public static class NhanVienThucHien
    {
        public static int MaNhanVien { get; set; }
    }
}
