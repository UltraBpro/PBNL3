
namespace PBNL3
{
    partial class FormChonNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ButtonConfirm = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.TextBoxChucVu = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelNgayNhan = new System.Windows.Forms.Label();
            this.labelNVMoi = new System.Windows.Forms.Label();
            this.SwitchNVMoi = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RadioButtonNu = new Guna.UI2.WinForms.Guna2RadioButton();
            this.radioButtonNam = new Guna.UI2.WinForms.Guna2RadioButton();
            this.DateTimePickerNgaySinh = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.TextBoxHoVaTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.TextBoxLuong = new Guna.UI2.WinForms.Guna2TextBox();
            this.ButtonXoa = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.guna2GradientPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonConfirm
            // 
            this.ButtonConfirm.Animated = true;
            this.ButtonConfirm.AutoRoundedCorners = true;
            this.ButtonConfirm.BackColor = System.Drawing.Color.Transparent;
            this.ButtonConfirm.BorderRadius = 17;
            this.ButtonConfirm.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonConfirm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ButtonConfirm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ButtonConfirm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ButtonConfirm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ButtonConfirm.ForeColor = System.Drawing.Color.White;
            this.ButtonConfirm.Location = new System.Drawing.Point(460, 247);
            this.ButtonConfirm.Name = "ButtonConfirm";
            this.ButtonConfirm.Size = new System.Drawing.Size(128, 36);
            this.ButtonConfirm.TabIndex = 4;
            this.ButtonConfirm.Text = "Confirm";
            this.ButtonConfirm.UseTransparentBackground = true;
            this.ButtonConfirm.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // guna2DataGridView1
            // 
            this.guna2DataGridView1.AllowUserToAddRows = false;
            this.guna2DataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.guna2DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.guna2DataGridView1.ColumnHeadersHeight = 40;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.guna2DataGridView1.EnableHeadersVisualStyles = true;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(11, 12);
            this.guna2DataGridView1.MultiSelect = false;
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.ReadOnly = true;
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.Size = new System.Drawing.Size(576, 229);
            this.guna2DataGridView1.TabIndex = 3;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 40;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = true;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 22;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.ButtonXoa);
            this.guna2GradientPanel1.Controls.Add(this.TextBoxChucVu);
            this.guna2GradientPanel1.Controls.Add(this.guna2DataGridView1);
            this.guna2GradientPanel1.Controls.Add(this.labelNgayNhan);
            this.guna2GradientPanel1.Controls.Add(this.labelNVMoi);
            this.guna2GradientPanel1.Controls.Add(this.ButtonConfirm);
            this.guna2GradientPanel1.Controls.Add(this.SwitchNVMoi);
            this.guna2GradientPanel1.Controls.Add(this.groupBox1);
            this.guna2GradientPanel1.Controls.Add(this.DateTimePickerNgaySinh);
            this.guna2GradientPanel1.Controls.Add(this.TextBoxHoVaTen);
            this.guna2GradientPanel1.Controls.Add(this.TextBoxLuong);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.DarkCyan;
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(602, 297);
            this.guna2GradientPanel1.TabIndex = 5;
            // 
            // TextBoxChucVu
            // 
            this.TextBoxChucVu.Animated = true;
            this.TextBoxChucVu.AutoRoundedCorners = true;
            this.TextBoxChucVu.BackColor = System.Drawing.Color.Transparent;
            this.TextBoxChucVu.BorderRadius = 17;
            this.TextBoxChucVu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxChucVu.DefaultText = "";
            this.TextBoxChucVu.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBoxChucVu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBoxChucVu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBoxChucVu.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBoxChucVu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBoxChucVu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TextBoxChucVu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBoxChucVu.Location = new System.Drawing.Point(122, 352);
            this.TextBoxChucVu.Name = "TextBoxChucVu";
            this.TextBoxChucVu.PasswordChar = '\0';
            this.TextBoxChucVu.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.TextBoxChucVu.PlaceholderText = "Nhập chức vụ";
            this.TextBoxChucVu.SelectedText = "";
            this.TextBoxChucVu.Size = new System.Drawing.Size(221, 36);
            this.TextBoxChucVu.TabIndex = 45;
            // 
            // labelNgayNhan
            // 
            this.labelNgayNhan.AutoSize = true;
            this.labelNgayNhan.BackColor = System.Drawing.Color.Transparent;
            this.labelNgayNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.labelNgayNhan.Location = new System.Drawing.Point(357, 278);
            this.labelNgayNhan.Name = "labelNgayNhan";
            this.labelNgayNhan.Size = new System.Drawing.Size(81, 17);
            this.labelNgayNhan.TabIndex = 44;
            this.labelNgayNhan.Text = "Ngày nhận:";
            this.labelNgayNhan.Visible = false;
            // 
            // labelNVMoi
            // 
            this.labelNVMoi.AutoSize = true;
            this.labelNVMoi.BackColor = System.Drawing.Color.Transparent;
            this.labelNVMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.labelNVMoi.Location = new System.Drawing.Point(59, 259);
            this.labelNVMoi.Name = "labelNVMoi";
            this.labelNVMoi.Size = new System.Drawing.Size(98, 17);
            this.labelNVMoi.TabIndex = 43;
            this.labelNVMoi.Text = "Nhân viên mới";
            // 
            // SwitchNVMoi
            // 
            this.SwitchNVMoi.Animated = true;
            this.SwitchNVMoi.BackColor = System.Drawing.Color.Transparent;
            this.SwitchNVMoi.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SwitchNVMoi.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SwitchNVMoi.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.SwitchNVMoi.CheckedState.InnerColor = System.Drawing.Color.White;
            this.SwitchNVMoi.Location = new System.Drawing.Point(18, 256);
            this.SwitchNVMoi.Name = "SwitchNVMoi";
            this.SwitchNVMoi.Size = new System.Drawing.Size(35, 20);
            this.SwitchNVMoi.TabIndex = 42;
            this.SwitchNVMoi.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.SwitchNVMoi.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.SwitchNVMoi.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.SwitchNVMoi.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.SwitchNVMoi.CheckedChanged += new System.EventHandler(this.SwitchNVMoi_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.RadioButtonNu);
            this.groupBox1.Controls.Add(this.radioButtonNam);
            this.groupBox1.Location = new System.Drawing.Point(12, 344);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(104, 44);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Giới tính";
            // 
            // RadioButtonNu
            // 
            this.RadioButtonNu.AutoSize = true;
            this.RadioButtonNu.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.RadioButtonNu.CheckedState.BorderThickness = 0;
            this.RadioButtonNu.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.RadioButtonNu.CheckedState.InnerColor = System.Drawing.Color.White;
            this.RadioButtonNu.CheckedState.InnerOffset = -4;
            this.RadioButtonNu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.RadioButtonNu.Location = new System.Drawing.Point(59, 19);
            this.RadioButtonNu.Name = "RadioButtonNu";
            this.RadioButtonNu.Size = new System.Drawing.Size(39, 17);
            this.RadioButtonNu.TabIndex = 1;
            this.RadioButtonNu.Text = "Nữ";
            this.RadioButtonNu.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.RadioButtonNu.UncheckedState.BorderThickness = 2;
            this.RadioButtonNu.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.RadioButtonNu.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // radioButtonNam
            // 
            this.radioButtonNam.AutoSize = true;
            this.radioButtonNam.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioButtonNam.CheckedState.BorderThickness = 0;
            this.radioButtonNam.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.radioButtonNam.CheckedState.InnerColor = System.Drawing.Color.White;
            this.radioButtonNam.CheckedState.InnerOffset = -4;
            this.radioButtonNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.radioButtonNam.Location = new System.Drawing.Point(6, 19);
            this.radioButtonNam.Name = "radioButtonNam";
            this.radioButtonNam.Size = new System.Drawing.Size(47, 17);
            this.radioButtonNam.TabIndex = 0;
            this.radioButtonNam.Text = "Nam";
            this.radioButtonNam.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.radioButtonNam.UncheckedState.BorderThickness = 2;
            this.radioButtonNam.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.radioButtonNam.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // DateTimePickerNgaySinh
            // 
            this.DateTimePickerNgaySinh.Animated = true;
            this.DateTimePickerNgaySinh.AutoRoundedCorners = true;
            this.DateTimePickerNgaySinh.BackColor = System.Drawing.Color.Transparent;
            this.DateTimePickerNgaySinh.BorderRadius = 19;
            this.DateTimePickerNgaySinh.Checked = true;
            this.DateTimePickerNgaySinh.CustomFormat = " dd/MM/yyyy HH:mm";
            this.DateTimePickerNgaySinh.FillColor = System.Drawing.Color.Cyan;
            this.DateTimePickerNgaySinh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DateTimePickerNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimePickerNgaySinh.Location = new System.Drawing.Point(360, 298);
            this.DateTimePickerNgaySinh.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DateTimePickerNgaySinh.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DateTimePickerNgaySinh.Name = "DateTimePickerNgaySinh";
            this.DateTimePickerNgaySinh.ShowUpDown = true;
            this.DateTimePickerNgaySinh.Size = new System.Drawing.Size(227, 40);
            this.DateTimePickerNgaySinh.TabIndex = 41;
            this.DateTimePickerNgaySinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DateTimePickerNgaySinh.UseTransparentBackground = true;
            this.DateTimePickerNgaySinh.Value = new System.DateTime(2023, 4, 7, 23, 16, 46, 538);
            // 
            // TextBoxHoVaTen
            // 
            this.TextBoxHoVaTen.Animated = true;
            this.TextBoxHoVaTen.AutoRoundedCorners = true;
            this.TextBoxHoVaTen.BackColor = System.Drawing.Color.Transparent;
            this.TextBoxHoVaTen.BorderRadius = 17;
            this.TextBoxHoVaTen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxHoVaTen.DefaultText = "";
            this.TextBoxHoVaTen.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBoxHoVaTen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBoxHoVaTen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBoxHoVaTen.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBoxHoVaTen.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBoxHoVaTen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TextBoxHoVaTen.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBoxHoVaTen.Location = new System.Drawing.Point(12, 302);
            this.TextBoxHoVaTen.Name = "TextBoxHoVaTen";
            this.TextBoxHoVaTen.PasswordChar = '\0';
            this.TextBoxHoVaTen.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.TextBoxHoVaTen.PlaceholderText = "Nhập họ và tên";
            this.TextBoxHoVaTen.SelectedText = "";
            this.TextBoxHoVaTen.Size = new System.Drawing.Size(331, 36);
            this.TextBoxHoVaTen.TabIndex = 38;
            // 
            // TextBoxLuong
            // 
            this.TextBoxLuong.Animated = true;
            this.TextBoxLuong.AutoRoundedCorners = true;
            this.TextBoxLuong.BackColor = System.Drawing.Color.Transparent;
            this.TextBoxLuong.BorderRadius = 17;
            this.TextBoxLuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBoxLuong.DefaultText = "";
            this.TextBoxLuong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TextBoxLuong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TextBoxLuong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBoxLuong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TextBoxLuong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBoxLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TextBoxLuong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TextBoxLuong.Location = new System.Drawing.Point(360, 352);
            this.TextBoxLuong.Name = "TextBoxLuong";
            this.TextBoxLuong.PasswordChar = '\0';
            this.TextBoxLuong.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.TextBoxLuong.PlaceholderText = "Nhập lương";
            this.TextBoxLuong.SelectedText = "";
            this.TextBoxLuong.Size = new System.Drawing.Size(227, 36);
            this.TextBoxLuong.TabIndex = 39;
            // 
            // ButtonXoa
            // 
            this.ButtonXoa.Animated = true;
            this.ButtonXoa.AutoRoundedCorners = true;
            this.ButtonXoa.BackColor = System.Drawing.Color.Transparent;
            this.ButtonXoa.BorderRadius = 17;
            this.ButtonXoa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonXoa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ButtonXoa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ButtonXoa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ButtonXoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ButtonXoa.ForeColor = System.Drawing.Color.White;
            this.ButtonXoa.Location = new System.Drawing.Point(163, 247);
            this.ButtonXoa.Name = "ButtonXoa";
            this.ButtonXoa.Size = new System.Drawing.Size(68, 36);
            this.ButtonXoa.TabIndex = 48;
            this.ButtonXoa.Text = "Xóa";
            this.ButtonXoa.UseTransparentBackground = true;
            this.ButtonXoa.Click += new System.EventHandler(this.ButtonXoa_Click);
            // 
            // FormChonNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 297);
            this.Controls.Add(this.guna2GradientPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormChonNhanVien";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button ButtonConfirm;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.Label labelNVMoi;
        private Guna.UI2.WinForms.Guna2ToggleSwitch SwitchNVMoi;
        private System.Windows.Forms.GroupBox groupBox1;
        private Guna.UI2.WinForms.Guna2RadioButton RadioButtonNu;
        private Guna.UI2.WinForms.Guna2RadioButton radioButtonNam;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateTimePickerNgaySinh;
        private Guna.UI2.WinForms.Guna2TextBox TextBoxHoVaTen;
        private Guna.UI2.WinForms.Guna2TextBox TextBoxLuong;
        private Guna.UI2.WinForms.Guna2TextBox TextBoxChucVu;
        private System.Windows.Forms.Label labelNgayNhan;
        private Guna.UI2.WinForms.Guna2Button ButtonXoa;
    }
}