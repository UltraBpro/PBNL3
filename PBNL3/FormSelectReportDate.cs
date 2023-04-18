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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBNL3
{
    public partial class PickDate : Form
    {        
        public PickDate(int type)
        {
            InitializeComponent();
            SetLable(type);
            SetCBBItem();
        }
        private void SetLable(int type)
        {
            t = type;
            switch (type)
            {
                case 0:
                    this.Text = "Bill";
                    label1.Text = "Doanh thu hóa đơn";
                    this.pictureBox1.Image = global::PBNL3.Properties.Resources.Bill1;             
                    break;
                case 1:
                    this.Text = "Room";
                    label1.Text = "Doanh thu phòng";
                    this.pictureBox1.Image = global::PBNL3.Properties.Resources.Room;                 
                    break;
                default:
                    this.Text = "Service";
                    label1.Text = "Doanh thu dịch vụ";
                    this.pictureBox1.Image = global::PBNL3.Properties.Resources.Service2;                  
                    break;
            }           
        }
        private void SetCBBItem()
        {
            cbbsetday.Items.Clear();
            cbbsetday.Items.AddRange(new object[]
            {
                "Vui lòng chọn ngày",
                "Hôm nay",
                "Hôm qua",
                "7 ngày trước",
                "30 ngày trước",
                "Tháng hiện tại",
                "Tháng trước",
                "Tất cả thời gian",
                "Tùy chọn"
            });           
            cbbsetday.SelectedIndex = 0;         
        }       

        private void cbbsetday_DropDown(object sender, EventArgs e)
        {
            cbbsetday.Items.Remove("Vui lòng chọn ngày");
        }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int t { get; set; }
        private void cbbsetday_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (cbbsetday.SelectedItem.ToString() == "Tùy chọn")
            {
                SetCBBItem();
                FormSelectReportOptionDate selectDateForm = new FormSelectReportOptionDate();
                selectDateForm.ShowDialog();
                if (selectDateForm.start != DateTime.MinValue && selectDateForm.end != DateTime.MinValue)
                {                      
                    start = selectDateForm.start;
                    end = selectDateForm.end;
                    string selectedDateRange = string.Format("{0} - {1}", selectDateForm.start.ToShortDateString(), selectDateForm.end.ToShortDateString());                    
                    cbbsetday.Items.Add(selectedDateRange);
                    cbbsetday.SelectedItem = selectedDateRange;                  
                }               
            }
        }

        private void confirmbutton_Click(object sender, EventArgs e)
        {
            if (cbbsetday.Text == "Vui lòng chọn ngày" || cbbsetday.Text == "")
            {
                MessageBox.Show("Vui lòng chọn ngày khảo sát!!!");
            }
            else
            {
                FormReport baoCaoHD = new FormReport(cbbsetday.SelectedIndex, t, start, end);
                baoCaoHD.Show();
                this.Hide();
            }
        }     
    }
}
