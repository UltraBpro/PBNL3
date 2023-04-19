using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using FontAwesome.Sharp;

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
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
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

        private void iconButton5_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else 
                WindowState = FormWindowState.Normal;
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ResetMouseEventArgs();
            labelTrangThai.Text = "Trang chủ";
            iconPictureBox1.IconChar = IconChar.Home;
        }
        // Đoạn sau được viết bởi thằng l*n Tuấn
        private void LoadNhanVien(int MaTaiKhoan)
        {
            using (DBEntities db = new DBEntities())
            {
                var TK = db.TaiKhoans.Find(MaTaiKhoan);
                var NV = db.NhanViens.Find(TK.MaNhanVien);
                NhanVienThucHien.MaNhanVien = NV.MaNhanVien;
                labelMaNV.Text = NV.MaNhanVien.ToString();
                labelTenNV.Text = NV.TenNhanVien;
                labelChucVu.Text = NV.ChucVu;if (NV.ChucVu == "Quản lý" || NV.ChucVu == "Admin") quảnLýToolStripMenuItem.Enabled = true;
            }
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
        public void FormHoiSinh(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
            this.Focus();
        }
    }
    // Lồn Bơ Đầu Buồi bias chúa
    public static class NhanVienThucHien
    {
        public static int MaNhanVien { get; set; }
        static NhanVienThucHien()
        {
            // Tạm thời 
            MaNhanVien = -1;
        }
    }
}
