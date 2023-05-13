using PBNL3.BLL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class FormDoiMK : Form
    {
        public FormDoiMK()
        {
            InitializeComponent();
        }

        private void TextBoxMKMoi_TextChanged(object sender, EventArgs e)
        {
            TextBoxXacNhan.Clear();
        }

        private void ButtonXacNhan_Click(object sender, EventArgs e)
        {

            try
            {
                Account_BLL account_BLL = new Account_BLL();
                account_BLL.DoiMatKhau(TextBoxMKCu.Text, TextBoxMKMoi.Text, TextBoxXacNhan.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
