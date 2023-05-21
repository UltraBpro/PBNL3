using Guna.UI2.WinForms;
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
    public partial class FormThongKeTheoNgay : Form
    {
        public event EventHandler<List<DateTime>> GuiNgayDi;       
        public FormThongKeTheoNgay()
        {            
            InitializeComponent();           
        }   
        private void ButtonXacNhan_Click(object sender, EventArgs e)
        {
            DateTime batDau = guna2DateTimePicker1.Value;
            DateTime ketThuc = guna2DateTimePicker2.Value;
            List<DateTime> list = new List<DateTime>();           
            list.Add(batDau);
            list.Add(ketThuc);             
            if(batDau <= ketThuc)
            {
                FormThongKe formThongKe = new FormThongKe();
                GuiNgayDi?.Invoke(this, list);              
                this.Close();
            }
            else
            {
                MessageBox.Show("Thời gian bắt đầu phải nhỏ hơn hoặc bằng kết thúc!");
            }
        }
        //Lên đi mà fennnnnnnn 
    }
}
