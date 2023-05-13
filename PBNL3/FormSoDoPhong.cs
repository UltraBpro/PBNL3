using PBNL3.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class FormSoDoPhong : Form
    {
        List<Button> buttonList = new List<Button>();
        public FormSoDoPhong()
        {
            InitializeComponent();
            buttonList.Add(buttonChonPhong1); buttonList.Add(buttonChonPhong2); buttonList.Add(buttonChonPhong3);
            buttonList.Add(buttonChonPhong4); buttonList.Add(buttonChonPhong5); buttonList.Add(buttonChonPhong6);
            buttonList.Add(buttonChonPhong7); buttonList.Add(buttonChonPhong8); buttonList.Add(buttonChonPhong9);
            CheckTTrangPhong(null, null);
        }
        public void CheckTTrangPhong(object sender, FormClosedEventArgs e)
        {

            foreach (Button ButtonPhong in buttonList)
            {
                if (Phong_BLL.GetTTrangPhong(ButtonPhong) == "Trống") ButtonPhong.BackColor = Color.Green;
                else ButtonPhong.BackColor = Color.Red;
            }

        }
        private void ButtonPhong_Click(object sender, EventArgs e)
        {
            int MaPhong = int.Parse(((Button)sender).Name.Substring(15));
            Color TTrangPhong = ((Button)sender).BackColor;
            string TrangThaiForm2 = ((FormManHinhChinh)this.Parent.Parent.Parent).labelTrangThai.Text;
            switch (TrangThaiForm2)
            {
                case "Đặt phòng":
                    if (TTrangPhong != Color.Green) MessageBox.Show("Phòng này đã kín.");
                    else
                    {
                        FormDatPhong DatPhong = new FormDatPhong(MaPhong);
                        DatPhong.Show();
                        ((FormManHinhChinh)this.Parent.Parent.Parent).Enabled = false;
                        DatPhong.FormClosed += ((FormManHinhChinh)this.Parent.Parent.Parent).FormHoiSinh;
                        DatPhong.FormClosed += CheckTTrangPhong;
                    }
                    break;

                case "Sử dụng dịch vụ":
                    if (TTrangPhong != Color.Red) MessageBox.Show("Phòng này còn trống.");
                    else
                    {
                        FormDungDichVu DungDichVu = new FormDungDichVu(MaPhong);
                        DungDichVu.Show();
                        ((FormManHinhChinh)this.Parent.Parent.Parent).Enabled = false;
                        DungDichVu.FormClosed += ((FormManHinhChinh)this.Parent.Parent.Parent).FormHoiSinh;
                        DungDichVu.FormClosed += CheckTTrangPhong;
                    }
                    break;
                case "Trả phòng":
                    if (TTrangPhong != Color.Red) MessageBox.Show("Phòng này còn trống.");
                    else
                    {
                        FormTraPhong TraPhong = new FormTraPhong(MaPhong);
                        TraPhong.Show();
                        ((FormManHinhChinh)this.Parent.Parent.Parent).Enabled = false;
                        TraPhong.FormClosed += ((FormManHinhChinh)this.Parent.Parent.Parent).FormHoiSinh;
                        TraPhong.FormClosed += CheckTTrangPhong;
                    }
                    break;
                default:
                    MessageBox.Show("Chưa chọn chức năng để thao tác trên sơ đồ phòng\nChọn ở tay trái màn hình hoặc sử dụng các chức năng ở thanh trên cùng.");
                    break;
            }
        }

    }
}
