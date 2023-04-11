using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBNL3
{
    public partial class PickDayDTHD : Form
    {
        public PickDayDTHD()
        {
            InitializeComponent();           
        }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        private void ActiveButton_Click(object sender, EventArgs e)
        {                       
            start = StartDate.Value;
            end = EndDate.Value;
            if (start.CompareTo(end) <= 0)
            {                    
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai ngày rồi kìa!!!");
            }
        }

        private void ActiveButton_MouseEnter(object sender, EventArgs e)
        {           
            ActiveButton.ForeColor = Color.Black;                 
        }

        private void ActiveButton_MouseLeave(object sender, EventArgs e)
        {          
            ActiveButton.ForeColor = Color.LightCyan;                  
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            start = DateTime.MinValue;
            end = DateTime.MinValue;
            this.Close();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            ExitButton.ForeColor = Color.Black;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.ForeColor = Color.LightCyan;
        }     
    }
}
