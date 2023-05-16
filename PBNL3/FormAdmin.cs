using FontAwesome.Sharp;
using PBNL3.BLL;
using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace PBNL3
{

    public partial class FormAdmin : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        public FormAdmin(int MaTaiKhoan)
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
                panelChildForm.Controls.Clear();
                FormChonNhanVien childForm = new FormChonNhanVien();
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelChildForm.Controls.Add(childForm);
                panelChildForm.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            childForm.GuiNVDi += NhanDSNV;
        }
        private void NhanDSNV(object sender, int MaNVNhan)
        {
            switch (labelTrangThai.Text) {
                case "Cấp tài khoản":
                    {
                        Account_BLL account_BLL = new Account_BLL();
                        TaiKhoan tempAcc = account_BLL.CheckTK(MaNVNhan);
                        if (tempAcc != null)
                        {
                            MessageBox.Show("Đã có 1 tài khoản được cấp cho nhân viên này với username: " + tempAcc.username);
                        }
                        else { 
                            FormDoiMK ThatRaLaFormAddTK = new FormDoiMK(MaNVNhan);
                            ThatRaLaFormAddTK.ShowDialog();            
                        }
                        break;
                    }
                case "Thu hồi tài khoản":
                    {

                        Account_BLL account_BLL = new Account_BLL();
                        NhanVien_BLL nhanVien_BLL = new NhanVien_BLL();
                        TaiKhoan tempAcc = account_BLL.CheckTK(MaNVNhan);
                        if (tempAcc == null)
                        {
                            MessageBox.Show("Chưa có tài khoản nào được cấp cho nhân viên này");
                        }
                        else
                        {
                            account_BLL.XoaTaiKhoan(MaNVNhan);
                            nhanVien_BLL.XoaNhanVien(MaNVNhan);
                        }
                        break;
                    }
                default:
                    MessageBox.Show("Chưa chọn chức năng thực hiện.");
                    break;
            }
            OpenChildForm();
        }
        private void LoadNhanVien(int MaTaiKhoan)
        {
            NhanVien_BLL nhanVien_BLL = new NhanVien_BLL();
            var NV = nhanVien_BLL.TimNhanVien(MaTaiKhoan);
            NhanVienThucHien.MaNhanVien = NV.MaNhanVien;
            labelMaNV.Text = NV.MaNhanVien.ToString();
            labelTenNV.Text = NV.TenNhanVien;
            labelChucVu.Text = NV.ChucVu;
        }
        private void iconButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(249, 118, 176));
            iconPictureBox1.IconChar = iconButton2.IconChar;
            labelTrangThai.Text = iconButton2.Text;
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.FromArgb(172, 126, 241));
            iconPictureBox1.IconChar = iconButton1.IconChar;
            labelTrangThai.Text = iconButton1.Text;
        }
        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            FormDoiMK doiMK = new FormDoiMK();
            doiMK.ShowDialog();
        }
    }
}
