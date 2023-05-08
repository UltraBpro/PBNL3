using System;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            timer.Interval = 500;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            LoadDangNhap();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            File.Delete("LoginInfo.txt");
            Application.Exit();
        }
        private void LuuDangNhap(string username, string password)
        {
            byte[] encryptedData = ProtectedData.Protect(Encoding.UTF8.GetBytes(username + "|" + password + "|" + SwitchRemember.Checked.ToString()), null, DataProtectionScope.CurrentUser);
            File.WriteAllBytes("LoginInfo.txt", encryptedData);
        }
        private bool LoadDangNhap()
        {
            try
            {
                byte[] encryptedData = File.ReadAllBytes("LoginInfo.txt");
                byte[] decryptedData = ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser);
                string[] loginInfo = Encoding.UTF8.GetString(decryptedData).Split('|');
                if (loginInfo.Length == 3)
                {
                    string username = loginInfo[0];
                    string password = loginInfo[1];
                    SwitchRemember.Checked = bool.Parse(loginInfo[2]);
                    Login(username, password);
                }
            }
            catch { }
            return false;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            string username = TextBoxUsername.Text;
            string password = TextBoxPass.Text;
            Login(username, password);
        }
        private void Login(string username, string password)
        {
            using (DBEntities db = new DBEntities())
            {
                try
                {
                    var s = db.TaiKhoans.Single(p => p.username == username);
                    if (s.password == password)
                    {
                        if (SwitchRemember.Checked) LuuDangNhap(username, password);
                        else File.Delete("LoginInfo.txt");
                        FormManHinhChinh fMainMenu = new FormManHinhChinh(s.MaTK);
                        fMainMenu.Show();
                        this.Close();
                    }
                    else MessageBox.Show("Sai tài khoản hoặc mật khẩu.");
                }
                catch (Exception) { MessageBox.Show("Sai tài khoản hoặc mật khẩu."); }
            }
        }
        private Timer timer = new Timer();
        bool nani = false;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (nani)
                guna2ImageButton1.Image = Properties.Resources.Cheems2;
            else guna2ImageButton1.Image = Properties.Resources.Cheems0;
            nani = !nani;
        }

        private void guna2ImageButton1_MouseDown(object sender, MouseEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.BonkSoundEffect);
            player.Play();
        }
    }
}
