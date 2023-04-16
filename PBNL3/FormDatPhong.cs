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
            this.Hide();
            chonKhach.Show();
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            FormChonPhong chonPhong = new FormChonPhong();
            chonPhong.GuiPhongDi += NhanDSPhong;
            this.Hide();
            chonPhong.Show();
        }
        private void NhanDSKhach(object sender, List<int> e)
        {
            this.Show();
            guna2Button2.Text = "Mã khách đã chọn: ";
            foreach (int makhach in e)
            {
                guna2Button2.Text += makhach.ToString();
            }
        }
        private void NhanDSPhong(object sender, List<int> e)
        {
            this.Show();
            guna2Button3.Text = "Mã các phòng đã chọn: ";
            foreach (int maphong in e)
            {
                guna2Button3.Text += maphong.ToString()+", ";
            }
            guna2Button3.Text=guna2Button3.Text.Substring(0, guna2Button3.Text.Length - 2)+".";
        }
    }
}
