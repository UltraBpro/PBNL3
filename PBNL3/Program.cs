using System;
using System.Windows.Forms;

namespace PBNL3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var StartingForm = new FormLogin();
            if (!StartingForm.IsDisposed) StartingForm.Show();
            Application.Run();
        }
    }
}
