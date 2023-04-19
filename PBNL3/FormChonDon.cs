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
    public partial class FormChonDon : Form
    {
        public FormChonDon()
        {
            InitializeComponent();
            using (DBEntities db = new DBEntities())
            {
                var result = db.DonDatPhongs
    .Join(db.ChiTietPhongDats, ddp => ddp.MaDonDatPhong, ctpd => ctpd.MaDonDatPhong, (ddp, ctpd) => new { ddp, ctpd })
    .Select(temp => new
    {
        MaDonDatPhong = temp.ddp.MaDonDatPhong,
        MaKhach = temp.ddp.MaKhach,
        TinhTrangThanhToan = temp.ddp.TinhTrangThanhToan,
        NgayDat = temp.ddp.NgayDat,
        NgayTra = temp.ddp.NgayTra,
        NhanVienThucHien = temp.ddp.MaNhanVienThucHien,
        NhanVienThanhToan = temp.ddp.MaNhanVienThanhToan,
        TongTien = temp.ddp.TongTien,
        MaPhongDat = temp.ctpd.MaPhong,
        GiaPhongDat = temp.ctpd.GiaPhongDat,
    }).ToList();
                guna2DataGridView1.DataSource = result;
            }
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
