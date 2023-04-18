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
    public partial class FormSelectReportType : Form
    {
        public FormSelectReportType()
        {
            InitializeComponent();
        }

        private void BCHDButton_Click(object sender, EventArgs e)
        {
            PickDate dTHD = new PickDate(0);
            dTHD.ShowDialog();
        }

        private void BCPButton_Click(object sender, EventArgs e)
        {
            PickDate dTHD = new PickDate(1);
            dTHD.ShowDialog();
        }

        private void BCDVButton_Click(object sender, EventArgs e)
        {
            PickDate dTHD = new PickDate(2);
            dTHD.ShowDialog();
        }
    }
}
