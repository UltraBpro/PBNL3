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
    public partial class DTHD : Form
    {
        public DTHD(int type)
        {
            InitializeComponent();
            SetLable(type);
            SetCBBItem();
        }
        private void SetLable(int type)
        {
            switch (type)
            {
                case 0:
                    label1.Text = "Doanh thu hóa đơn";

                    break;
                case 1:
                    label1.Text = "Doanh thu tiền phòng";
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
        private void cbbsetday_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (cbbsetday.SelectedItem.ToString() == "Tùy chọn")
            {
                SetCBBItem();
                PickDayDTHD selectDateForm = new PickDayDTHD();
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
            BaoCaoHD baoCaoHD = new BaoCaoHD(cbbsetday.SelectedIndex, start, end);
            baoCaoHD.Show();
            this.Hide();
        }       
    }
}
