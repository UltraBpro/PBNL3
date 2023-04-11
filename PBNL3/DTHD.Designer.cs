namespace PBNL3
{
    partial class DTHD
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbsetday = new Guna.UI2.WinForms.Guna2ComboBox();
            this.confirmbutton = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PBNL3.Properties.Resources.Bill;
            this.pictureBox1.Location = new System.Drawing.Point(12, 130);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(307, 307);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
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
            this.confirmbutton.BorderRadius = 15;
            this.confirmbutton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.confirmbutton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.confirmbutton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.confirmbutton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.confirmbutton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.confirmbutton.ForeColor = System.Drawing.Color.White;
            this.confirmbutton.Location = new System.Drawing.Point(112, 443);
            this.confirmbutton.Name = "confirmbutton";
            this.confirmbutton.Size = new System.Drawing.Size(107, 33);
            this.confirmbutton.TabIndex = 3;
            this.confirmbutton.Text = "Xác nhận";
            this.confirmbutton.Click += new System.EventHandler(this.confirmbutton_Click);
            // 
            // DTHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 489);
            this.Controls.Add(this.confirmbutton);
            this.Controls.Add(this.cbbsetday);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "DTHD";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbbsetday;
        private Guna.UI2.WinForms.Guna2Button confirmbutton;
    }
}