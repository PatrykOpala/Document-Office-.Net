using Document_Office.Net.Forms;
using System;
using System.Windows.Forms;
using System.Threading;

namespace Document_Office.Net
{
    public partial class StartWindow : Form
    {
        string filePath = "";
        ushort countFile = 0;

        public StartWindow()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Thread DialogStartThread = new Thread(() =>
            {
                Application.Run(new DialogStartWindow());
            });
            DialogStartThread.SetApartmentState(ApartmentState.STA);
            DialogStartThread.Start();
            this.Close();
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
