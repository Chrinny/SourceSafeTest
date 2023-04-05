using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace ASRE
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Directory.Exists(Properties.Settings.Default.scriptPath.ToString()))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            else
            {
                MessageBox.Show("Error: scripts folder ('" + Properties.Settings.Default.scriptPath.ToString() + "\\') not found, exiting...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}