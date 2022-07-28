using Document_Office.Net.Forms;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Document_Office.Net
{
    public partial class StartWindow : Form
    {
        string filePath = "";

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
            Thread edytorThread = new Thread(() =>
            {
                Application.Run(new EdytorWindow());
            });
            edytorThread.SetApartmentState(ApartmentState.STA);
            edytorThread.Start();
            this.Close();
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LocationButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = fileDialog.FileName;
                labelFileName.Text = fileDialog.FileName;
            }
            
        }
    }
}
