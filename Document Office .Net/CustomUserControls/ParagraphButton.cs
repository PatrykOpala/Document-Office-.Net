using DocumentFormat.OpenXml.Office2010.Excel;
using System.Windows.Forms;

namespace Document_Office.Net.CustomUserControls
{
    public partial class ParagraphButton : UserControl
    {
        public ParagraphButton()
        {
            InitializeComponent();
        }

        public ParagraphButton(int x, int y)
        {
            InitializeComponent();
            Location = new System.Drawing.Point(x, y);
        }

        public void SetHeader(string h)
        {
            labelContent.Text = h;
        }

        public void SetHeaderColor(System.Drawing.Color headerColor)
        {
            labelContent.ForeColor = headerColor;
        }

        public void SetBody(string b)
        {
            labelParagraph.Text = b;
        }
    }
}
