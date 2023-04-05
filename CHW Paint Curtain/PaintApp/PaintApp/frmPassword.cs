using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pilkngton.ProjectPaint.PaintApp
{
    public partial class frmPassword : Form
    {
        public frmPassword()
        {
            InitializeComponent();
        }

        public string Password
        {
            get
            {
                return txtPassword.Text;
            }
        }
        /// <summary>
        /// I am not sure why I had to explicitly wire the OK button up previously I just set the accept button property and it worked?!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPasswordOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}