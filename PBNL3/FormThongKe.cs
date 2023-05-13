using PBNL3.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PBNL3
{
    public partial class FormThongKe : Form
    {
        public FormThongKe()
        {
            InitializeComponent();
            SetCBBMonths();
            SetCBBYears();
        }
        private void SetCBBMonths()
        {
            cbbsetmonths.Enabled = false;
            cbbsetmonths.Items.Clear();
            cbbsetmonths.Items.Add("Chọn tháng");
            for (int i = 1; i <= 12; i++)
            {
                var month = i.ToString("D2");
                cbbsetmonths.Items.Add(month);
            }
            cbbsetmonths.SelectedIndex = 0;
        }
        private void SetCBBYears()
        {
            cbbsetyears.Items.Clear();
            cbbsetyears.Items.Add("Chọn năm");
            var year = DateTime.Now.Year;
            for (int i = 4; i >= 0; i--)
            {
                cbbsetyears.Items.Add((year - i).ToString());
            }
            cbbsetyears.SelectedIndex = 0;
        }
        
        private void SetText(bool type)
        {           
            try
            {
                cbbsetyears.Items.Remove("Chọn năm");
                if (type)
                {
                    int selectedMonth = int.Parse(cbbsetmonths.SelectedItem.ToString());
                    int selectedYear = int.Parse(cbbsetyears.SelectedItem.ToString());
                    moneyP.Text = Phong_BLL.GetTotalPhong(selectedMonth, selectedYear, type).ToString();
                    moneyDV.Text = DichVu_BLL.GetTotalDV(selectedMonth, selectedYear, type).ToString();
                    BillCount.Text = Don_BLL.GetTotalBill(selectedMonth, selectedYear, type).ToString();
                    SetBDT();
                    SetBDD();
                }
                else
                {
                    SetBDD();
                    int selectedYear = int.Parse(cbbsetyears.SelectedItem.ToString());
                    moneyP.Text = Phong_BLL.GetTotalPhong(0, selectedYear, type).ToString();
                    moneyDV.Text = DichVu_BLL.GetTotalDV(0, selectedYear, type).ToString();
                    BillCount.Text = Don_BLL.GetTotalBill(0, selectedYear, type).ToString();
                    chartBDT.Series["DTP"].Points.Clear();
                }
            }
            catch
            {
                SetCBBMonths();
                moneyP.Text = "0";
                moneyDV.Text = "0";
                BillCount.Text = "0";
                chartBDT.Series["DTP"].Points.Clear();
                chartBDD.Series["DTP"].Points.Clear();
                chartBDD.Series["DTDV"].Points.Clear();
            }
        }
        private void SetBDT()
        {
            chartBDT.Series["DTP"].Points.Clear();
            double p = double.Parse(moneyP.Text);
            double dv = double.Parse(moneyDV.Text);
            double total = p + dv;
            chartBDT.Series["DTP"].Points.AddXY(Math.Round((p / total) * 100, 2) + "%", moneyP.Text);
            chartBDT.Series["DTP"].Points[0].LegendText = "Doanh thu phòng";
            chartBDT.Series["DTP"].Points.AddXY(Math.Round((dv / total) * 100, 2) + "%", moneyDV.Text);
            chartBDT.Series["DTP"].Points[1].LegendText = "Doanh thu dịch vụ";
        }
        private void AddNewSeries(string seriesName, List<double> data)
        {
            chartBDD.Series[seriesName].Points.Clear();
            chartBDD.ChartAreas[0].AxisX.Interval = 1;
            for (int i = 0; i < data.Count; i++)
            {
                chartBDD.Series[seriesName].Points.AddXY((i + 1).ToString(), data[i]);
            }
        }
        private void SetBDD()
        {
            int selectedYear = int.Parse(cbbsetyears.SelectedItem.ToString());
            List<Double> dataDTP = new List<double>();
            for (int i = 1; i <= 12; i++)
            {
                double totalP = Phong_BLL.GetTotalPhong(i, selectedYear, true);
                dataDTP.Add(totalP);
            }
            AddNewSeries("DTP", dataDTP);
            List<Double> dataDTDV = new List<double>();
            for (int i = 1; i <= 12; i++)
            {
                double totalDV = DichVu_BLL.GetTotalDV(i, selectedYear, true);
                dataDTDV.Add(totalDV);
            }
            AddNewSeries("DTDV", dataDTDV);
            cbbsetmonths.Enabled = true;
        }
        private void cbb_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            SetText(cbbsetmonths.SelectedIndex != 0);          
        }
        private void GetPDVDetails(bool type)
        {
            try
            {
                int selectedMonth = cbbsetmonths.SelectedIndex == 0 ? 0 : int.Parse(cbbsetmonths.SelectedItem.ToString());
                int selectedYear = int.Parse(cbbsetyears.SelectedItem.ToString());
                FormChiTietThongKe formChiTietThongKe = new FormChiTietThongKe(selectedMonth, selectedYear, type);
                formChiTietThongKe.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Chọn năm hợp lệ");
            }
        }        
        private void ButtonPhong_Click(object sender, EventArgs e)
        {
            GetPDVDetails(true);
        }
        private void ButtonDV_Click(object sender, EventArgs e)
        {
            GetPDVDetails(false);
        }
        private void ButtonBill_Click(object sender, EventArgs e)
        {            
            try
            {
                int selectedMonth = cbbsetmonths.SelectedIndex == 0 ? 0 : int.Parse(cbbsetmonths.SelectedItem.ToString());
                int selectedYear = int.Parse(cbbsetyears.SelectedItem.ToString());
                Don_BLL don_BLL = new Don_BLL();
                DataTable dataTable = don_BLL.GetBillDetails(selectedMonth, selectedYear);
                FormChonDon formChonDon = new FormChonDon(dataTable);
                formChonDon.ShowDialog();
            }
            catch 
            {
                MessageBox.Show("Chọn năm hợp lệ!");
            }
        }
    }
}