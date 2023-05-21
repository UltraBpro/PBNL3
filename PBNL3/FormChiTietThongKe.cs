using PBNL3.BLL;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class FormChiTietThongKe : Form
    {
        public FormChiTietThongKe(int selectedMonth, int selectedYear, bool type)
        {
            InitializeComponent();
            SetDGV(selectedMonth, selectedYear, type);
        }
        public FormChiTietThongKe(DateTime Start, DateTime End, bool type)
        {
            InitializeComponent();
            SetDGVByDay(Start, End, type);
        }
        public void SetTitle(bool type)
        {
            if (type)
            {
                labeTitle.Text = "Chi tiết phòng: ";
            }
            else
            {
                labeTitle.Text = "Chi tiết dịch vụ: ";
            }
        }
        public void SetDGV(int selectedMonth, int selectedYear, bool type)
        {
            SetTitle(type);
            DichVu_BLL dichVu_BLL = new DichVu_BLL();
            DataTable dataTable = dichVu_BLL.GetDGV(selectedMonth, selectedYear, type);
            dgvThongKe.DataSource = dataTable;
        }
        public void SetDGVByDay(DateTime Start, DateTime End, bool type)
        {
            SetTitle(type);
            DichVu_BLL dichVu_BLL = new DichVu_BLL();
            DataTable dataTable = dichVu_BLL.GetDGVByDay(Start, End, type);
            dgvThongKe.DataSource = dataTable;
        }        
        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
