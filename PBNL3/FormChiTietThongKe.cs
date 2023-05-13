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
        public void SetDGV(int selectedMonth, int selectedYear, bool type)
        {
            if (type)
            {
                labeTitle.Text = "Chi tiết phòng: ";
            }
            else
            {
                labeTitle.Text = "Chi tiết dịch vụ: ";
            }
            DichVu_BLL dichVu_BLL = new DichVu_BLL();
            DataTable dataTable = dichVu_BLL.GetDGV(selectedMonth, selectedYear, type);
            dgvThongKe.DataSource = dataTable;
        }
        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
