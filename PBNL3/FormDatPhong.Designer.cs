
namespace PBNL3
{
    partial class FormDatPhong
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
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.ButtonChonPhong = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonChonKhach = new Guna.UI2.WinForms.Guna2Button();
            this.ButtonXacNhan = new Guna.UI2.WinForms.Guna2Button();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.label2);
            this.guna2GradientPanel1.Controls.Add(this.guna2DateTimePicker1);
            this.guna2GradientPanel1.Controls.Add(this.ButtonChonPhong);
            this.guna2GradientPanel1.Controls.Add(this.label1);
            this.guna2GradientPanel1.Controls.Add(this.ButtonChonKhach);
            this.guna2GradientPanel1.Controls.Add(this.ButtonXacNhan);
            this.guna2GradientPanel1.Controls.Add(this.label4);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.DarkCyan;
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(471, 170);
            this.guna2GradientPanel1.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(23, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Thời gian nhận";
            // 
            // guna2DateTimePicker1
            // 
            this.guna2DateTimePicker1.Animated = true;
            this.guna2DateTimePicker1.AutoRoundedCorners = true;
            this.guna2DateTimePicker1.BackColor = System.Drawing.Color.Transparent;
            this.guna2DateTimePicker1.BorderRadius = 14;
            this.guna2DateTimePicker1.Checked = true;
            this.guna2DateTimePicker1.CustomFormat = " dd/MM/yyyy HH:mm";
            this.guna2DateTimePicker1.FillColor = System.Drawing.Color.Cyan;
            this.guna2DateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.guna2DateTimePicker1.Location = new System.Drawing.Point(142, 83);
            this.guna2DateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            this.guna2DateTimePicker1.ShowUpDown = true;
            this.guna2DateTimePicker1.Size = new System.Drawing.Size(310, 31);
            this.guna2DateTimePicker1.TabIndex = 34;
            this.guna2DateTimePicker1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guna2DateTimePicker1.Value = new System.DateTime(2023, 4, 7, 23, 16, 46, 538);
            // 
            // ButtonChonPhong
            // 
            this.ButtonChonPhong.Animated = true;
            this.ButtonChonPhong.AutoRoundedCorners = true;
            this.ButtonChonPhong.BackColor = System.Drawing.Color.Transparent;
            this.ButtonChonPhong.BorderRadius = 13;
            this.ButtonChonPhong.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonChonPhong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ButtonChonPhong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ButtonChonPhong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ButtonChonPhong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ButtonChonPhong.ForeColor = System.Drawing.Color.White;
            this.ButtonChonPhong.Location = new System.Drawing.Point(142, 48);
            this.ButtonChonPhong.Name = "ButtonChonPhong";
            this.ButtonChonPhong.Size = new System.Drawing.Size(310, 29);
            this.ButtonChonPhong.TabIndex = 33;
            this.ButtonChonPhong.Text = "Chọn phòng";
            this.ButtonChonPhong.Click += new System.EventHandler(this.ButtonChonPhong_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(23, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Danh sách phòng";
            // 
            // ButtonChonKhach
            // 
            this.ButtonChonKhach.Animated = true;
            this.ButtonChonKhach.AutoRoundedCorners = true;
            this.ButtonChonKhach.BackColor = System.Drawing.Color.Transparent;
            this.ButtonChonKhach.BorderRadius = 13;
            this.ButtonChonKhach.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonChonKhach.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ButtonChonKhach.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ButtonChonKhach.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ButtonChonKhach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ButtonChonKhach.ForeColor = System.Drawing.Color.White;
            this.ButtonChonKhach.Location = new System.Drawing.Point(142, 13);
            this.ButtonChonKhach.Name = "ButtonChonKhach";
            this.ButtonChonKhach.Size = new System.Drawing.Size(310, 29);
            this.ButtonChonKhach.TabIndex = 31;
            this.ButtonChonKhach.Text = "Chọn khách";
            this.ButtonChonKhach.Click += new System.EventHandler(this.ButtonChonKhach_Click);
            // 
            // ButtonXacNhan
            // 
            this.ButtonXacNhan.Animated = true;
            this.ButtonXacNhan.AutoRoundedCorners = true;
            this.ButtonXacNhan.BackColor = System.Drawing.Color.Transparent;
            this.ButtonXacNhan.BorderRadius = 19;
            this.ButtonXacNhan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ButtonXacNhan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ButtonXacNhan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ButtonXacNhan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ButtonXacNhan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ButtonXacNhan.ForeColor = System.Drawing.Color.White;
            this.ButtonXacNhan.Location = new System.Drawing.Point(272, 120);
            this.ButtonXacNhan.Name = "ButtonXacNhan";
            this.ButtonXacNhan.Size = new System.Drawing.Size(180, 41);
            this.ButtonXacNhan.TabIndex = 30;
            this.ButtonXacNhan.Text = "Xác nhận đặt";
            this.ButtonXacNhan.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(23, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Khách";
            // 
            // FormDatPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 170);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "FormDatPhong";
            this.Text = "FormDatPhong";
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2Button ButtonXacNhan;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button ButtonChonKhach;
        private Guna.UI2.WinForms.Guna2Button ButtonChonPhong;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
        private System.Windows.Forms.Label label2;
    }
}