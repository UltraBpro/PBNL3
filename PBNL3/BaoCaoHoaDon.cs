﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class BaoCaoHoaDon : Form
    {
        public BaoCaoHoaDon()
        {
            InitializeComponent();           
        }
        
        private void ActiveButton_Click(object sender, EventArgs e)
        {           
            DBEntities db = new DBEntities();
            DateTime start = StartDate.Value;
            DateTime end = EndDate.Value;
            if (start.CompareTo(end) < 0)
            {
                //var query = db.DonDatPhongs
                //    .Where(d => d.TinhTrangThanhToan == "Done" && d.NgayDat >= start && d.NgayTra < end.AddDays(1))
                //    .Join(db.Khaches, d => d.MaKhach, k => k.MaKhach,
                //    (d, k) => new {d.MaDonDatPhong, k.TenKhach, d.NgayDat, d.NgayTra, d.GiaTien}).ToList();
                Test test = new Test(start, end);                
                test.Show();
            }
            else
            {
                MessageBox.Show("Sai ngày rồi kìa!!!");
            }
        }        
    }
}
