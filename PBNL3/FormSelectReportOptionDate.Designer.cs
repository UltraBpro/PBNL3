namespace PBNL3
{
    partial class FormSelectReportOptionDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectReportOptionDate));
            this.ActiveButton = new Guna.UI2.WinForms.Guna2Button();
            this.StartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.EndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ActiveButton
            // 
            this.ActiveButton.BackColor = System.Drawing.Color.White;
            this.ActiveButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.ActiveButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.ActiveButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.ActiveButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.ActiveButton.FillColor = System.Drawing.Color.DarkSlateGray;
            this.ActiveButton.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold);
            this.ActiveButton.ForeColor = System.Drawing.Color.LightCyan;
            this.ActiveButton.Location = new System.Drawing.Point(340, 389);
            this.ActiveButton.Name = "ActiveButton";
            this.ActiveButton.Size = new System.Drawing.Size(138, 31);
            this.ActiveButton.TabIndex = 6;
            this.ActiveButton.Text = "Tiến hành ";
            this.ActiveButton.Click += new System.EventHandler(this.ActiveButton_Click);
            this.ActiveButton.MouseEnter += new System.EventHandler(this.ActiveButton_MouseEnter);
            this.ActiveButton.MouseLeave += new System.EventHandler(this.ActiveButton_MouseLeave);
            // 
            // StartDate
            // 
            this.StartDate.Checked = true;
            this.StartDate.FillColor = System.Drawing.Color.Black;
            this.StartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.StartDate.ForeColor = System.Drawing.Color.White;
            this.StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.StartDate.Location = new System.Drawing.Point(56, 256);
            this.StartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.StartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(214, 36);
            this.StartDate.TabIndex = 7;
            this.StartDate.Value = new System.DateTime(2023, 4, 8, 0, 0, 0, 0);
            // 
            // EndDate
            // 
            this.EndDate.Checked = true;
            this.EndDate.FillColor = System.Drawing.Color.Black;
            this.EndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.EndDate.ForeColor = System.Drawing.Color.White;
            this.EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.EndDate.Location = new System.Drawing.Point(535, 256);
            this.EndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.EndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(212, 36);
            this.EndDate.TabIndex = 8;
            this.EndDate.Value = new System.DateTime(2023, 4, 8, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(230, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(307, 31);
            this.label3.TabIndex = 13;
            this.label3.Text = "Chọn thời gian cần khảo sát ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(603, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 31);
            this.label2.TabIndex = 12;
            this.label2.Text = "Kết thúc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = global::PBNL3.Properties.Resources.Screenshot_2023_04_07_002722;
            this.label1.Location = new System.Drawing.Point(107, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Bắt đầu ";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Black;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(0, 0);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(800, 450);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 3;
            this.guna2PictureBox1.TabStop = false;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExitButton.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.Color.LightCyan;
            this.ExitButton.Location = new System.Drawing.Point(770, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(30, 30);
            this.ExitButton.TabIndex = 14;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            // 
            // BaoCaoHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EndDate);
            this.Controls.Add(this.StartDate);
            this.Controls.Add(this.ActiveButton);
            this.Controls.Add(this.guna2PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BaoCaoHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaoCaoHoaDon";
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button ActiveButton;
        private Guna.UI2.WinForms.Guna2DateTimePicker StartDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker EndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ExitButton;
    }
}