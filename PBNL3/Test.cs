using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class Test : Form
    {      
        public Test(DateTime ngayden, DateTime ngaydi)
        {
            InitializeComponent();       
            label8.Text = ngayden.ToString("dd/MM/yyyy");
            label7.Text = ngaydi.ToString("dd/MM/yyyy");
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
