using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class FormChonPhong : Form
    {
        public event EventHandler<int> GuiPhongDi;
        public FormChonPhong(string kieuload)
        {
            InitializeComponent();
            LoadForm(kieuload);
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            int selectedPhong = -1;
            foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
            {
                selectedPhong = Convert.ToInt32(row.Cells["MaPhong"].Value);
            }
            GuiPhongDi?.Invoke(this, selectedPhong);
            this.Close();
        }
        private void LoadForm(string kieuload)
        {
            using (DBEntities db = new DBEntities())
            {
                var DSPhong = db.Phongs
                      .Join(db.LoaiPhongs,
                phong => phong.MaLoaiPhong,
                loaiPhong => loaiPhong.MaLoaiPhong,
                (phong, loaiPhong) => new
                {
                    phong.MaPhong,
                    loaiPhong.TenLoaiPhong,
                    loaiPhong.DienTich,
                    loaiPhong.SoGiuong,
                    loaiPhong.GiaTien,
                    phong.TinhTrang,
                    phong.Tang,
                    phong.ThuTu
                })
              .Select(p => new
              {
                  p.MaPhong,
                  p.TinhTrang,
                  p.Tang,
                  p.ThuTu,
                  p.TenLoaiPhong,
                  p.DienTich,
                  p.SoGiuong,
                  p.GiaTien
              });
                switch (kieuload)
                {
                    case "DatPhong":
                        guna2DataGridView1.DataSource = DSPhong.Where(p => p.TinhTrang == "Trống").ToList();
                        break;
                    case "GoiDichVu":
                        guna2DataGridView1.DataSource = DSPhong.Where(p => p.TinhTrang == "Kín").ToList();
                        break;
                    case "LietKe":
                        guna2DataGridView1.DataSource = DSPhong.ToList();
                        break;
                }

            }
        }

        private void ButtonDoiLoaiPhong_Click(object sender, EventArgs e)
        {
            using (DBEntities db = new DBEntities())
            {
                if (db.NhanViens.Find(NhanVienThucHien.MaNhanVien).ChucVu == "Quản lý")
                {
                    int selectedPhong = 0;
                    foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
                    {
                        selectedPhong = Convert.ToInt32(row.Cells["MaPhong"].Value);
                    }
                    FormChonLoaiPhong DoiLP = new FormChonLoaiPhong(selectedPhong);
                    DoiLP.FormClosed += ReloadForm;
                    DoiLP.ShowDialog();
                }
                else MessageBox.Show("Bạn không đủ quyền hạn thực hiện chức năng này.");
            }
        }
        public void ReloadForm(object sender, FormClosedEventArgs e)
        {
            LoadForm("LietKe");
        }
    }
}
