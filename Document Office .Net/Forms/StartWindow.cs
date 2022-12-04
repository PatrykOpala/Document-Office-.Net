using Document_Office.Net.Forms;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Document_Office.Net
{
    public partial class StartWindow : Form
    {
        string filePath = "";
        ushort countFile = 0;

        private void changeCounter(ushort count, string upDown)
        {
            if(upDown == "up")
            {
                countFile += count;
                countFilesLabel.Text = countFile.ToString();
            }

            if(upDown == "down")
            {
                if (countFile == 0) return;

                countFile -= count;
                countFilesLabel.Text = countFile.ToString();
            }
            
        }
        public StartWindow()
        {
            InitializeComponent();
            buttonNext.Enabled = false;
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
                Application.Run(new EdytorWindow(filePath, countFile));
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
            if(countFile > 0)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Pliki docx (*.docx)|*.docx";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = fileDialog.FileName;
                    labelFileName.Text = fileDialog.FileName;
                    buttonNext.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Wybierz ile chcesz zrobić kopii.", "Podaj liczbę", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void plusTen_Click(object sender, EventArgs e)
        {
            changeCounter(10, "up");
        }

        private void plusOne_Click(object sender, EventArgs e)
        {
            changeCounter(1, "up");
        }

        private void minusOne_Click(object sender, EventArgs e)
        {
            changeCounter(1, "down");
        }

        private void minusTen_Click(object sender, EventArgs e)
        {
            changeCounter(10, "down");
        }
    }
}
