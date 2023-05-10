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
    public partial class FormChonLoaiPhong : Form
    {
        public event EventHandler<int> GuiLoaiPhongDi;
        int? MaPhong = null;
        public FormChonLoaiPhong(int? MPhg=null)
        {
            InitializeComponent();
            MaPhong = MPhg;
            using (DBEntities db = new DBEntities())
            {
                guna2DataGridView1.DataSource = db.LoaiPhongs.Select(p => new
                {
                    p.MaLoaiPhong,
                    p.TenLoaiPhong,
                    p.SoGiuong,
                    p.DienTich,
                    p.GiaTien,
                    p.GhiChu
                }).ToList();
            }
        }

        private void SwitchKhachMoi_CheckedChanged(object sender, EventArgs e)
        {
            if (SwitchLoaiPhong.Checked) { this.Size = new Size(618, 430); }
            else { this.Size = new Size(618, 332); }
            this.CenterToScreen();
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            int selectedLP = -1;
            if (SwitchLoaiPhong.Checked)
            {
                using (DBEntities db = new DBEntities())
                {
                    LoaiPhong newLP = new LoaiPhong();
                    newLP.MaLoaiPhong = (db.LoaiPhongs.Max(x => (int?)x.MaLoaiPhong) ?? 0) + 1;
                    newLP.TenLoaiPhong = TextBoxTenLoaiPhong.Text;
                    newLP.SoGiuong = Convert.ToInt32(TextBoxSoGiuong.Text);
                    newLP.DienTich = Convert.ToInt32(TextBoxDienTich.Text);
                    newLP.GhiChu = TextBoxNote.Text;
                    newLP.GiaTien = Convert.ToDouble(TextBoxGiaTien.Text);
                    db.LoaiPhongs.Add(newLP); db.SaveChanges();
                    selectedLP = newLP.MaLoaiPhong;
                }
            }
            else
                foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
                {
                    selectedLP = Convert.ToInt32(row.Cells["MaLoaiPhong"].Value);
                }
            if(MaPhong!=null) using (DBEntities db = new DBEntities())
                {
                    db.Phongs.Find(MaPhong).MaLoaiPhong=selectedLP;db.SaveChanges();
                }
            GuiLoaiPhongDi?.Invoke(this, selectedLP);
            this.Close();
        }
    }
}
