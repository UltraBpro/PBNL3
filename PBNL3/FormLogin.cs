using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            LoadDangNhap();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void LuuDangNhap(string username, string password)
        {
            byte[] encryptedData = ProtectedData.Protect(Encoding.UTF8.GetBytes(username + "|" + password), null, DataProtectionScope.CurrentUser);
            File.WriteAllBytes("LoginInfo.txt", encryptedData);
        }
        private bool LoadDangNhap()
        {
            try
            {
                byte[] encryptedData = File.ReadAllBytes("LoginInfo.txt");
                byte[] decryptedData = ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser);
                string[] loginInfo = Encoding.UTF8.GetString(decryptedData).Split('|');
                if (loginInfo.Length == 2)
                {
                    string username = loginInfo[0];
                    string password = loginInfo[1];
                    Login(username, password);
                }
            }
            catch {}
            return false;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string username = TextBoxUsername.Text;
            string password = TextBoxPass.Text;
            Login(username, password);
        }
        private void Login(string username,string password)
        {
            using (DBEntities db = new DBEntities())
            {
                try
                {
                    var s = db.TaiKhoans.Single(p => p.username == username);
                    if (s.password == password)
                    {
                        if (SwitchRemember.Checked) LuuDangNhap(username, password);
                        MessageBox.Show("Đăng nhập thành công, sẽ thêm hàm gọi form các thứ sau.");
                    }
                    else MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
                }
                catch (Exception) { MessageBox.Show("Sai tài khoản hoặc mật khẩu."); }
            }
        }
    }
}
