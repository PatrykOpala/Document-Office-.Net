using System.Windows.Forms;

namespace Document_Office.Net.CustomUserControls
{
    public partial class ParagraphContainer : UserControl
    {
        private int x = 0;
        public ParagraphContainer()
        {
            InitializeComponent();
        }

        public void AddItem(PhItem item)
        {
            var phButtton = new ParagraphButton(x, 0);
            phButtton.SetHeader(item._Header);
            phButtton.SetHeaderColor(item._Color);
            phButtton.SetBody(item._Body);

            Controls.Add(phButtton);
            x += 250;
        }
    }
}
