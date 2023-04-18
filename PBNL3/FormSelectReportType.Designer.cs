namespace PBNL3
{
    partial class FormSelectReportType
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
            this.BCHDButton = new Guna.UI2.WinForms.Guna2Button();
            this.BCPButton = new Guna.UI2.WinForms.Guna2Button();
            this.BCDVButton = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // BCHDButton
            // 
            this.BCHDButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BCHDButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BCHDButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BCHDButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BCHDButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BCHDButton.ForeColor = System.Drawing.Color.White;
            this.BCHDButton.Location = new System.Drawing.Point(287, 45);
            this.BCHDButton.Name = "BCHDButton";
            this.BCHDButton.Size = new System.Drawing.Size(180, 45);
            this.BCHDButton.TabIndex = 0;
            this.BCHDButton.Text = "Báo Cáo Hóa Đơn ";
            this.BCHDButton.Click += new System.EventHandler(this.BCHDButton_Click);
            // 
            // BCPButton
            // 
            this.BCPButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BCPButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BCPButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BCPButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BCPButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BCPButton.ForeColor = System.Drawing.Color.White;
            this.BCPButton.Location = new System.Drawing.Point(287, 143);
            this.BCPButton.Name = "BCPButton";
            this.BCPButton.Size = new System.Drawing.Size(180, 45);
            this.BCPButton.TabIndex = 1;
            this.BCPButton.Text = "Báo Cáo Phòng ";
            this.BCPButton.Click += new System.EventHandler(this.BCPButton_Click);
            // 
            // BCDVButton
            // 
            this.BCDVButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BCDVButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BCDVButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BCDVButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BCDVButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BCDVButton.ForeColor = System.Drawing.Color.White;
            this.BCDVButton.Location = new System.Drawing.Point(287, 235);
            this.BCDVButton.Name = "BCDVButton";
            this.BCDVButton.Size = new System.Drawing.Size(180, 45);
            this.BCDVButton.TabIndex = 2;
            this.BCDVButton.Text = "Báo Cáo Dịch Vụ";
            this.BCDVButton.Click += new System.EventHandler(this.BCDVButton_Click);
            // 
            // SelectReportTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BCDVButton);
            this.Controls.Add(this.BCPButton);
            this.Controls.Add(this.BCHDButton);
            this.Name = "SelectReportTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button BCHDButton;
        private Guna.UI2.WinForms.Guna2Button BCPButton;
        private Guna.UI2.WinForms.Guna2Button BCDVButton;
    }
}