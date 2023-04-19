using System;
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
    public partial class FormSoDoPhong : Form
    {
        public FormSoDoPhong()
        {
            InitializeComponent();
        }

        private void ButtonPhong_Click(object sender, EventArgs e)
        {
            int MaPhong = int.Parse(((Button)sender).Name.Substring("ButtonChonPhong".Length));
            string TrangThaiForm2 = ((FormManHinhChinh)this.Parent.Parent.Parent).labelTrangThai.Text;
            switch (TrangThaiForm2)
            {
                case "Đặt phòng":
                    FormDatPhong DatPhong = new FormDatPhong(MaPhong);
                    DatPhong.Show();
                    ((FormManHinhChinh)this.Parent.Parent.Parent).Enabled = false;
                    DatPhong.FormClosed += ((FormManHinhChinh)this.Parent.Parent.Parent).FormHoiSinh;
                    break;
                case "Sử dụng dịch vụ":
                    FormDungDichVu DungDichVu = new FormDungDichVu(MaPhong);
                    DungDichVu.Show();
                    ((FormManHinhChinh)this.Parent.Parent.Parent).Enabled = false;
                    DungDichVu.FormClosed += ((FormManHinhChinh)this.Parent.Parent.Parent).FormHoiSinh;
                    break;
                case "Trả phòng":
                    FormTraPhong TraPhong = new FormTraPhong();
                    TraPhong.Show();
                    ((FormManHinhChinh)this.Parent.Parent.Parent).Enabled = false;
                    TraPhong.FormClosed += ((FormManHinhChinh)this.Parent.Parent.Parent).FormHoiSinh;
                    break;
                default:
                    MessageBox.Show("Chưa chọn chức năng để thao tác trên sơ đồ phòng\nChọn ở tay trái màn hình hoặc sử dụng các chức năng ở thanh trên cùng.");
                    break;
            }
        }
    }
}
