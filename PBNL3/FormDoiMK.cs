using PBNL3.BLL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class FormDoiMK : Form
    {
        int? MaNVdangcap=null;
        public FormDoiMK(int? MaNV=null)
        {
            InitializeComponent();
            if (MaNV != null)
            {
                MaNVdangcap = MaNV;
                labelDong1.Text = "Tên tài khoản";
                labelDong2.Text = "Mật khẩu";
            }
            else TextBoxMKCu.UseSystemPasswordChar = true;
        }

        private void TextBoxMKMoi_TextChanged(object sender, EventArgs e)
        {
            TextBoxXacNhan.Clear();
        }

        private void ButtonXacNhan_Click(object sender, EventArgs e)
        {
                Account_BLL account_BLL = new Account_BLL();
            try
            {
                if (MaNVdangcap == null) account_BLL.DoiMatKhau(TextBoxMKCu.Text, TextBoxMKMoi.Text, TextBoxXacNhan.Text);
                else
                    if (TextBoxMKMoi.Text == TextBoxXacNhan.Text) account_BLL.ThemTaiKhoan((int)MaNVdangcap, TextBoxMKCu.Text, TextBoxMKMoi.Text);
                else MessageBox.Show("Mật khẩu nhập lại sai.");
                    this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
