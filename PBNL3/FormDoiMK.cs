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
            using (DBEntities db = new DBEntities())
            {
                var TKcu = db.TaiKhoans.Where(p => p.MaNhanVien == NhanVienThucHien.MaNhanVien).FirstOrDefault();
                if (TKcu.password == TextBoxMKCu.Text)
                {
                    if (TextBoxMKMoi.Text == TextBoxXacNhan.Text) TKcu.password = TextBoxMKMoi.Text;
                    else MessageBox.Show("Mật khẩu xác nhận không đúng.");
                    db.SaveChanges();
                    this.Close();
                }
                else MessageBox.Show("Mật khẩu cũ không đúng.");
            }
        }
    }
}
