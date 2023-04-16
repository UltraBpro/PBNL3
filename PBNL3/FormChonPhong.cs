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
    public partial class FormChonPhong : Form
    {
        public event EventHandler<int> GuiPhongDi;
        public FormChonPhong()
        {
            InitializeComponent();
            using (DBEntities db = new DBEntities())
            {
                guna2DataGridView1.DataSource = db.Phongs
                    .Join(db.LoaiPhongs,
              phong => phong.MaLoaiPhong,
              loaiPhong => loaiPhong.MaLoaiPhong,
              (phong, loaiPhong) => new {
                  phong.MaPhong,
                  loaiPhong.TenLoaiPhong,
                  loaiPhong.DienTich,
                  loaiPhong.SoGiuong,
                  loaiPhong.GiaTien,
                  phong.TinhTrang,
                  phong.Tang,
                  phong.ThuTu
              })
            .Select(p => new {
                p.MaPhong,
                p.TinhTrang,
                p.Tang,
                p.ThuTu,
            p.TenLoaiPhong,
            p.DienTich,
            p.SoGiuong,
            p.GiaTien           
        })
        .ToList();
            }
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            int selectedPhong = -1;
            foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
            {
                selectedPhong=Convert.ToInt32(row.Cells["MaPhong"].Value);
            }
            GuiPhongDi?.Invoke(this, selectedPhong);
            this.Close();
        }
    }
}
