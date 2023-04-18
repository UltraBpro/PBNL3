namespace PBNL3
{
    partial class PickDate
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbbsetday = new Guna.UI2.WinForms.Guna2ComboBox();
            this.confirmbutton = new Guna.UI2.WinForms.Guna2Button();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Doanh thu hóa đơn ";
            // 
            // cbbsetday
            // 
            this.cbbsetday.AutoRoundedCorners = true;
            this.cbbsetday.BackColor = System.Drawing.Color.Transparent;
            this.cbbsetday.BorderRadius = 17;
            this.cbbsetday.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbsetday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbsetday.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbsetday.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbsetday.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbsetday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbsetday.ItemHeight = 30;
            this.cbbsetday.Location = new System.Drawing.Point(45, 50);
            this.cbbsetday.Name = "cbbsetday";
            this.cbbsetday.Size = new System.Drawing.Size(238, 36);
            this.cbbsetday.TabIndex = 2;
            this.cbbsetday.DropDown += new System.EventHandler(this.cbbsetday_DropDown);
            this.cbbsetday.SelectedIndexChanged += new System.EventHandler(this.cbbsetday_SelectedIndexChanged);
            // 
            // confirmbutton
            // 
            this.confirmbutton.Animated = true;
            this.confirmbutton.AutoRoundedCorners = true;
            this.confirmbutton.BackColor = System.Drawing.Color.Transparent;
            this.confirmbutton.BorderRadius = 15;
            this.confirmbutton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.confirmbutton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.confirmbutton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.confirmbutton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.confirmbutton.FillColor = System.Drawing.Color.Cyan;
            this.confirmbutton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.confirmbutton.ForeColor = System.Drawing.Color.Black;
            this.confirmbutton.Location = new System.Drawing.Point(112, 443);
            this.confirmbutton.Name = "confirmbutton";
            this.confirmbutton.Size = new System.Drawing.Size(107, 33);
            this.confirmbutton.TabIndex = 3;
            this.confirmbutton.Text = "Xác nhận";
            this.confirmbutton.UseTransparentBackground = true;
            this.confirmbutton.Click += new System.EventHandler(this.confirmbutton_Click);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.label1);
            this.guna2GradientPanel1.Controls.Add(this.pictureBox1);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.White;
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(332, 489);
            this.guna2GradientPanel1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::PBNL3.Properties.Resources.Bill1;
            this.pictureBox1.Location = new System.Drawing.Point(13, 136);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(307, 257);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PickDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 489);
            this.Controls.Add(this.confirmbutton);
            this.Controls.Add(this.cbbsetday);
            this.Controls.Add(this.guna2GradientPanel1);
            this.MaximizeBox = false;
            this.Name = "PickDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbbsetday;
        private Guna.UI2.WinForms.Guna2Button confirmbutton;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}