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
    public partial class FormDatPhong : Form
    {
        public FormDatPhong()
        {
            InitializeComponent();
        }

    private void LoadFormDatPhong()
        {
            guna2DateTimePicker1.TextAlign = HorizontalAlignment.Center;
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FormChonKhach chonKhach = new FormChonKhach();
            chonKhach.GuiKhachDi += NhanDSKhach;
            chonKhach.FormClosed += FormHoiSinh;
            this.Hide();
            chonKhach.Show();
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            FormChonPhong chonPhong = new FormChonPhong();
            chonPhong.GuiPhongDi += NhanDSPhong;
            chonPhong.FormClosed += FormHoiSinh;
            this.Hide();           
            chonPhong.Show();
        }
        private void NhanDSKhach(object sender, int e)
        {
            guna2Button2.Text = "Mã khách đã chọn: " + e.ToString()+".";
        }
        private void NhanDSPhong(object sender, int e)
        {
            guna2Button3.Text = "Mã phòng đã chọn: "+e.ToString() + ".";
        }
        private void FormHoiSinh(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
