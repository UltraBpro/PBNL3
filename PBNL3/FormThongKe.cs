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
using System.Windows.Forms.DataVisualization.Charting;
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
            Phong_BLL phong_BLL = new Phong_BLL();
            DichVu_BLL dichVu_BLL = new DichVu_BLL();
            Don_BLL don_BLL = new Don_BLL();
            StartLB.Visible = false;
            EndLB.Visible = false;
            if (type)
            {
                int selectedMonth = int.Parse(cbbsetmonths.SelectedItem.ToString());
                int selectedYear = int.Parse(cbbsetyears.SelectedItem.ToString());
                moneyP.Text = phong_BLL.GetTotalPhong(selectedMonth, selectedYear, type).ToString();
                moneyDV.Text = dichVu_BLL.GetTotalDV(selectedMonth, selectedYear, type).ToString();
                BillCount.Text = don_BLL.GetTotalBill(selectedMonth, selectedYear, type).ToString();
                SetBDT();
                SetBDD();
            }
            else
            {
                int selectedYear = int.Parse(cbbsetyears.SelectedItem.ToString());
                moneyP.Text = phong_BLL.GetTotalPhong(0, selectedYear, type).ToString();
                moneyDV.Text = dichVu_BLL.GetTotalDV(0, selectedYear, type).ToString();
                BillCount.Text = don_BLL.GetTotalBill(0, selectedYear, type).ToString();
                SetBDD();
                chartBDT.Series["DTP"].Points.Clear();
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
        private void AddNewSeriesDate(string seriesName, DateTime startDate, List<double> data)
        {
            chartBDD.Series[seriesName].Points.Clear();
            chartBDD.ChartAreas[0].AxisX.Interval = 1;
            DateTime currentDate = startDate;
            foreach (double value in data)
            {
                chartBDD.Series[seriesName].Points.AddXY(currentDate.ToString("dd/MM"), value);
                currentDate = currentDate.AddDays(1);
            }
        }
        private void SetBDD()
        {
            int selectedYear = int.Parse(cbbsetyears.SelectedItem.ToString());
            List<Double> dataDTP = new List<double>();
            for (int i = 1; i <= 12; i++)
            {
                Phong_BLL phong_BLL = new Phong_BLL();
                double totalP = phong_BLL.GetTotalPhong(i, selectedYear, true);
                dataDTP.Add(totalP);
            }
            AddNewSeries("DTP", dataDTP);
            List<Double> dataDTDV = new List<double>();
            for (int i = 1; i <= 12; i++)
            {
                DichVu_BLL dichVu_BLL = new DichVu_BLL();
                double totalDV = dichVu_BLL.GetTotalDV(i, selectedYear, true);
                dataDTDV.Add(totalDV);
            }
            AddNewSeries("DTDV", dataDTDV);
            cbbsetmonths.Enabled = true;
        }
        private void SetBDDByDay()
        {
            try
            {
                List<double> dataDTP = new List<double>();
                for (DateTime date = Start; date <= End.AddDays(-1); date = date.AddDays(1))
                {
                    Phong_BLL phong_BLL = new Phong_BLL();
                    double totalP = phong_BLL.GetTotalPhongByDay(date, End);
                    dataDTP.Add(totalP);
                }
                AddNewSeriesDate("DTP", Start, dataDTP);
                List<double> dataDTDV = new List<double>();
                for (DateTime date = Start; date <= End.AddDays(-1); date = date.AddDays(1))
                {
                    DichVu_BLL dichVu_BLL = new DichVu_BLL();
                    double totalDV = dichVu_BLL.GetTotalDVByDay(date, End);
                    dataDTDV.Add(totalDV);
                }
                AddNewSeriesDate("DTDV", Start, dataDTDV);
            }
            catch
            {
                SetCBBMonths();
                SetCBBYears();               
                chartBDT.Series["DTP"].Points.Clear();
                chartBDD.Series["DTP"].Points.Clear();
                chartBDD.Series["DTDV"].Points.Clear();
            }
        }
        private void cbb_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            SetText(cbbsetmonths.SelectedIndex != 0);          
        }
        private void GetPDVDetails(bool type)
        {
            try
            {
                if (cbbsetmonths.Enabled)
                {
                    int selectedMonth = cbbsetmonths.SelectedIndex == 0 ? 0 : int.Parse(cbbsetmonths.SelectedItem.ToString());
                    int selectedYear = int.Parse(cbbsetyears.SelectedItem.ToString());
                    FormChiTietThongKe formChiTietThongKe = new FormChiTietThongKe(selectedMonth, selectedYear, type);
                    formChiTietThongKe.ShowDialog();
                }
                else
                {
                    FormThongKeTheoNgay formThongKeTheoNgay = new FormThongKeTheoNgay();
                    formThongKeTheoNgay.GuiNgayDi += GetDay;
                    FormChiTietThongKe formChiTietThongKe = new FormChiTietThongKe(Start, End, type);
                    formChiTietThongKe.SetDGVByDay(Start, End, type);
                    formChiTietThongKe.ShowDialog();
                }
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
                if (cbbsetmonths.Enabled)
                {
                    int selectedMonth = cbbsetmonths.SelectedIndex == 0 ? 0 : int.Parse(cbbsetmonths.SelectedItem.ToString());
                    int selectedYear = int.Parse(cbbsetyears.SelectedItem.ToString());
                    Don_BLL don_BLL = new Don_BLL();
                    DataTable dataTable = don_BLL.GetBillDetails(selectedMonth, selectedYear);
                    FormChonDon formChonDon = new FormChonDon(dataTable);
                    formChonDon.ShowDialog();
                }
                else
                {
                    FormThongKeTheoNgay formThongKeTheoNgay = new FormThongKeTheoNgay();
                    formThongKeTheoNgay.GuiNgayDi += GetDay;
                    Don_BLL don_BLL = new Don_BLL();
                    DataTable dataTable = don_BLL.GetBillDetailsByDay(Start, End);
                    FormChonDon formChonDon = new FormChonDon(dataTable);
                    formChonDon.ShowDialog();
                }
            }
            catch 
            {
                MessageBox.Show("Chọn năm hợp lệ!");
            }
        }

        private void cbbsetyears_DropDown(object sender, EventArgs e)
        {           
            cbbsetyears.Items.Remove("Chọn năm");
            cbbsetyears.SelectedIndex = 0;
        }
        private void ButtonTKNgay_Click(object sender, EventArgs e)
        {
            FormThongKeTheoNgay formThongKeTheoNgay = new FormThongKeTheoNgay();
            formThongKeTheoNgay.GuiNgayDi += GetDay;
            formThongKeTheoNgay.ShowDialog();
            SetTextByDay();
        }
        private DateTime Start;
        private DateTime End;
        private void GetDay(object sender, List<DateTime> e)
        {
            Start = e[0].Date;
            End = e[1].AddDays(1).AddTicks(-1);
        }
        public void SetTextByDay()
        {
            SetCBBMonths();
            SetCBBYears();
            SetLable();           
            Phong_BLL phong_BLL = new Phong_BLL();
            DichVu_BLL dichVu_BLL = new DichVu_BLL();
            Don_BLL don_BLL = new Don_BLL();
            moneyP.Text = phong_BLL.GetTotalPhongByDay(Start, End.AddDays(1)).ToString();
            moneyDV.Text = dichVu_BLL.GetTotalDVByDay(Start, End).ToString();
            BillCount.Text = don_BLL.GetTotalBillByDay(Start, End).ToString();
            SetBDT();
            SetBDDByDay();
        }
        private void SetLable()
        {
            try
            {
                StartLB.Visible = true;
                EndLB.Visible = true;
                if (Start.Date == End.AddDays(-1).Date)
                {
                    StartLB.Text = " Trong ngày " + Start.Date.ToString("dd/MM/yyyy");
                    EndLB.Visible = false;
                }
                else
                {
                    StartLB.Text = " Từ " + Start.Date.ToString("dd/MM/yyyy");
                    EndLB.Text = " Đến " + End.AddDays(-1).Date.ToString("dd/MM/yyyy");
                }
            }
            catch 
            {
                StartLB.Visible = false;
                EndLB.Visible = false;
            }
        }
        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            this.Close();           
        }
    }
}