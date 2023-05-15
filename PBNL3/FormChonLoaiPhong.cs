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

namespace PBNL3
{
    public partial class FormChonLoaiPhong : Form
    {
        public event EventHandler<int> GuiLoaiPhongDi;
        int? MaPhong = null;
        public FormChonLoaiPhong(int? MPhg = null)
        {
            InitializeComponent();
            MaPhong = MPhg;

            Phong_BLL phong_BLL = new Phong_BLL();
            List<LoaiPhong> loaiPhongs = phong_BLL.LayDSLoaiPhong();
            guna2DataGridView1.DataSource = loaiPhongs.Select(p => new
            {
                p.MaLoaiPhong,
                p.TenLoaiPhong,
                p.SoGiuong,
                p.DienTich,
                p.GiaTien,
                p.GhiChu
            }).ToList();
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
                    Phong_BLL phong_BLL = new Phong_BLL();
                    selectedLP = phong_BLL.ThemLoaiPhong(TextBoxTenLoaiPhong.Text, Convert.ToInt32(TextBoxSoGiuong.Text), Convert.ToInt32(TextBoxDienTich.Text), TextBoxNote.Text, Convert.ToDouble(TextBoxGiaTien.Text));
                
            }
            else
                foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
                {
                    selectedLP = Convert.ToInt32(row.Cells["MaLoaiPhong"].Value);
                }
            if(MaPhong!=null) 
                {
                    Phong_BLL phong_BLL = new Phong_BLL();
                    phong_BLL.GanMaLoaiPhongChoPhong(MaPhong, selectedLP);
                }
            GuiLoaiPhongDi?.Invoke(this, selectedLP);
            this.Close();
        }
    }
}
