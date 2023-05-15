using PBNL3.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class FormTraPhong : Form
    {
        public FormTraPhong(int? MaPhong = null)
        {
            InitializeComponent();
            if (MaPhong != null)
            {
                ButtonChonPhong.Enabled = false;
                NhanDSPhongVaTinhTien(null,(int)MaPhong);
            }
        }

        private void ButtonChonPhong_Click(object sender, EventArgs e)
        {
            FormChonPhong chonPhong = new FormChonPhong("GoiDichVu");
            chonPhong.GuiPhongDi += NhanDSPhongVaTinhTien;
            chonPhong.FormClosed += FormHoiSinh;
            this.Hide();
            chonPhong.Show();
        }
        DateTime thoigiantinh;
        private void NhanDSPhongVaTinhTien(object sender, int e)
        {
            ButtonChonPhong.Text = "Mã phòng đã chọn: " + e.ToString() + ".";
            ButtonXacNhan.Enabled = true;            
                Don_BLL don_BLL =  new Don_BLL();
                DichVu_BLL dichVu_BLL = new DichVu_BLL();
                Phong_BLL phong_BLL = new Phong_BLL();
                int phongduochon = Convert.ToInt32(ButtonChonPhong.Text.Substring(0, ButtonChonPhong.Text.Length - 1).Split(':')[1].Trim());
                userControlChiTietDonHang1.LoadPhong(phongduochon);
                int maDonThaoTac = don_BLL.GetMaDonDatPhongThongQuaPhong(phongduochon);
                var DonDat = don_BLL.GetDonDat(maDonThaoTac);
                var DSDichVuSD = dichVu_BLL.LayDSDichVuDaSuDung(maDonThaoTac);
                var PhongDat = phong_BLL.GetPhongDat(maDonThaoTac);
                thoigiantinh = DateTime.Now;
                int songay = (int)DateTime.Now.Subtract(DonDat.NgayDat).TotalDays + 1;
                double TongTien = songay * PhongDat.GiaPhongDat;
                TextBoxTienPhong.Text = songay.ToString() + " ngày: " + (songay * PhongDat.GiaPhongDat).ToString();
                int sodichvu = 0;
                don_BLL.LuuTongTien(maDonThaoTac, TongTien);
                foreach (ChiTietDichVuDat DVSD in DSDichVuSD) { TongTien += DVSD.GiaDichVuDat * DVSD.SoLuong; sodichvu++; }          
                TextBoxTienDV.Text = sodichvu.ToString() + " dịch vụ: " + (TongTien - songay * PhongDat.GiaPhongDat).ToString();
                guna2TextBox1.Text = DonDat.TongTien.ToString();           
        }
        private void ButtonXacNhan_Click(object sender, EventArgs e)
        {
            using (DBEntities db = new DBEntities())
            {
                Don_BLL don_BLL = new Don_BLL();
                Phong_BLL phong_BLL= new Phong_BLL(); 
                int phongduochon = Convert.ToInt32(ButtonChonPhong.Text.Substring(0, ButtonChonPhong.Text.Length - 1).Split(':')[1].Trim());               
                int maDonThaoTac = don_BLL.GetMaDonDatPhongThongQuaPhong(phongduochon);                
                don_BLL.LuuThongTinThanhToan(maDonThaoTac, thoigiantinh, NhanVienThucHien.MaNhanVien);
                phong_BLL.TraPhong(phongduochon);
                this.Close();
            }
        }
        private void FormHoiSinh(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

    }
}
