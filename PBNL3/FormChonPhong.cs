using PBNL3.BLL;
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
            Phong_BLL phong_BLL = new Phong_BLL();
            var DSPhong = phong_BLL.LoadPhong(kieuload);
            guna2DataGridView1.DataSource = DSPhong.ToList();
        }

        private void ButtonDoiLoaiPhong_Click(object sender, EventArgs e)
        {
            NhanVien_BLL nhanVien_BLL = new NhanVien_BLL();
            if (nhanVien_BLL.TimChucVu() == "Quản lý")
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
        public void ReloadForm(object sender, FormClosedEventArgs e)
        {
            LoadForm("LietKe");
        }
      
    }
}
