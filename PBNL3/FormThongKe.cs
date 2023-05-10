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
        private double GetTotalPhong(int selectedMonth, int selectedYear, bool type)
        {
            using (DBEntities db = new DBEntities())
            {
                double totalP = 0;
                if (type)
                {
                    foreach (var dp in db.DonDatPhongs
                        .Where(d => d.TinhTrangThanhToan == "Đã thanh toán" && d.NgayTra.Value.Month == selectedMonth && d.NgayTra.Value.Year == selectedYear)
                        .Join(db.ChiTietPhongDats, d => d.MaDonDatPhong, p => p.MaDonDatPhong, (d, p) => new { d, p })
                        .Select(dp => new { dp.p.GiaPhongDat, dp.d.NgayDat, dp.d.NgayTra }))
                    {
                        totalP += dp.GiaPhongDat * ((int)(dp.NgayTra.Value - dp.NgayDat).TotalDays + 1);
                    }
                }
                else
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        foreach (var dp in db.DonDatPhongs
                            .Where(d => d.TinhTrangThanhToan == "Đã thanh toán" && d.NgayTra.Value.Month == i && d.NgayTra.Value.Year == selectedYear)
                            .Join(db.ChiTietPhongDats, d => d.MaDonDatPhong, p => p.MaDonDatPhong, (d, p) => new { d, p })
                            .Select(dp => new { dp.p.GiaPhongDat, dp.d.NgayDat, dp.d.NgayTra }))
                        {
                            totalP += dp.GiaPhongDat * ((int)(dp.NgayTra.Value - dp.NgayDat).TotalDays + 1);
                        }
                    }
                }
                return totalP;
            }
        }
        private double GetTotalDV(int selectedMonth, int selectedYear, bool type)
        {
            using (DBEntities db = new DBEntities())
            {
                double totalDV = 0;
                if (type)
                {
                    foreach (var ddv in db.DonDatPhongs
                        .Where(d => d.TinhTrangThanhToan == "Đã thanh toán" && d.NgayTra.Value.Month == selectedMonth && d.NgayTra.Value.Year == selectedYear)
                        .Join(db.ChiTietDichVuDats, d => d.MaDonDatPhong, dv => dv.MaDonDatPhong, (d, dv) => new { d, dv })
                        .Select(ddv => new { ddv.dv.GiaDichVuDat, ddv.dv.SoLuong }))
                    {
                        totalDV += ddv.GiaDichVuDat * ddv.SoLuong;
                    }
                }
                else
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        foreach (var ddv in db.DonDatPhongs
                            .Where(d => d.TinhTrangThanhToan == "Đã thanh toán" && d.NgayTra.Value.Month == i && d.NgayTra.Value.Year == selectedYear)
                            .Join(db.ChiTietDichVuDats, d => d.MaDonDatPhong, dv => dv.MaDonDatPhong, (d, dv) => new { d, dv })
                            .Select(ddv => new { ddv.dv.GiaDichVuDat, ddv.dv.SoLuong }))
                        {
                            totalDV += ddv.GiaDichVuDat * ddv.SoLuong;
                        }
                    }
                }
                return totalDV;
            }
        }
        private double GetTotalBill(int selectedMonth, int selectedYear, bool type)
        {
            using (DBEntities db = new DBEntities())
            {
                double totalBill = 0;
                if (type)
                {
                    foreach (var donDatPhong in db.DonDatPhongs
                        .Where(d => d.TinhTrangThanhToan == "Đã thanh toán" && d.NgayTra.Value.Month == selectedMonth && d.NgayTra.Value.Year == selectedYear))
                    {
                        totalBill++;
                    }
                }
                else
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        foreach (var donDatPhong in db.DonDatPhongs
                            .Where(d => d.TinhTrangThanhToan == "Đã thanh toán" && d.NgayTra.Value.Month == i && d.NgayTra.Value.Year == selectedYear))
                        {
                            totalBill++;
                        }
                    }
                }
                return totalBill;
            }
        }
        private void SetText(bool type)
        {
            try
            {
                if (type)
                {
                    int selectedMonth = int.Parse(cbbsetmonths.SelectedItem.ToString());
                    int selectedYear = int.Parse(cbbsetyears.SelectedItem.ToString());
                    moneyP.Text = GetTotalPhong(selectedMonth, selectedYear, type).ToString();
                    moneyDV.Text = GetTotalDV(selectedMonth, selectedYear, type).ToString();
                    BillCount.Text = GetTotalBill(selectedMonth, selectedYear, type).ToString();
                    SetBDT();
                    SetBDD();
                }
                else
                {
                    SetBDD();
                    int selectedYear = int.Parse(cbbsetyears.SelectedItem.ToString());
                    moneyP.Text = GetTotalPhong(0, selectedYear, type).ToString();
                    moneyDV.Text = GetTotalDV(0, selectedYear, type).ToString();
                    BillCount.Text = GetTotalBill(0, selectedYear, type).ToString();
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
                double totalP = GetTotalPhong(i, selectedYear, true);
                dataDTP.Add(totalP);
            }
            AddNewSeries("DTP", dataDTP);
            List<Double> dataDTDV = new List<double>();
            for (int i = 1; i <= 12; i++)
            {
                double totalDV = GetTotalDV(i, selectedYear, true);
                dataDTDV.Add(totalDV);
            }
            AddNewSeries("DTDV", dataDTDV);
            cbbsetmonths.Enabled = true;
        }
        private void cbb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetText(cbbsetmonths.SelectedIndex == 0 ? false : true);
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
                MessageBox.Show("Chọn tháng và năm hợp lệ");
            }
        }
        private void GetBillDetails()
        {
            try
            {
                DBEntities db = new DBEntities();
                int selectedMonth = cbbsetmonths.SelectedIndex == 0 ? 0 : int.Parse(cbbsetmonths.SelectedItem.ToString());
                int selectedYear = int.Parse(cbbsetyears.SelectedItem.ToString());
                var bill = db.DonDatPhongs
                            .Where(d => d.TinhTrangThanhToan == "Đã thanh toán" && (selectedMonth == 0 || d.NgayTra.Value.Month == selectedMonth) && d.NgayTra.Value.Year == selectedYear)
                            .Join(db.ChiTietPhongDats, d => d.MaDonDatPhong, p => p.MaDonDatPhong, (d, p) => new { d, p })
                            .Select(dp => new { dp.d.MaDonDatPhong, dp.p.MaPhong });
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("MaDonDatPhong", typeof(int));
                dataTable.Columns.Add("MaPhong", typeof(int));
                foreach (var item in bill)
                {
                    DataRow row = dataTable.NewRow();
                    row["MaDonDatPhong"] = item.MaDonDatPhong;
                    row["MaPhong"] = item.MaPhong;
                    dataTable.Rows.Add(row);
                }
                FormChonDon formChonDon = new FormChonDon(dataTable);
                formChonDon.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Chọn tháng và năm hợp lệ");
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
            GetBillDetails();
        }
    }
}