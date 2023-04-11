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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BCHDButton_Click(object sender, EventArgs e)
        {
            DTHD dTHD = new DTHD(0);
            dTHD.ShowDialog();
        }

        private void BCPButton_Click(object sender, EventArgs e)
        {
            DTHD dTHD = new DTHD(1);
            dTHD.ShowDialog();
        }
    }
}
