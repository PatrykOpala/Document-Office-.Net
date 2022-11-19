using System.Windows.Forms;

namespace Document_Office.Net
{
    public class PhButton
    {
        private int x = 0;
        public PhButton(Panel root, PhItem phItem)
        {
            var phButtton = new Button();
            phButtton.Location = new System.Drawing.Point(x, 0);
            phButtton.Text = $"{phItem._Header}\n\n\n\n{phItem._Body}";
            phButtton.Size = new System.Drawing.Size(244, 140);

            root.Controls.Add(phButtton);
            x += 250;
        }
    }
}
