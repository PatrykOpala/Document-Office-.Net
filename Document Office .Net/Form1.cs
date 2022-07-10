using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Document_Office.Net
{
    public partial class StartWindow : Form
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            step2.Visible = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            step2.Visible = false;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            step2.Visible = false;
            MainPanel.Visible = false;
            this.WindowState = FormWindowState.Maximized;
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
