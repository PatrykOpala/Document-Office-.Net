using Document_Office.Net.Environment;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Windows.Forms;

namespace Document_Office.Net.Forms
{
    public partial class EdytorWindow2 : Form
    {
        private DOEnvironment Environment = new DOEnvironment();

        public EdytorWindow2(string file, ushort countFile)
        {
            InitializeComponent();
            OpenDocx(file);
            Environment.AddEnvironmentFileName(file);
            Environment.AddCountCopies(countFile);
            Environment.AddRootWindowToEnvironment(this);
            Environment.InitUI(Size.Width, Size.Height);
        }

        void OpenDocx(string f)
        {
            using (WordprocessingDocument word = WordprocessingDocument.Open(f, true))
            {
                foreach (var bd in word.MainDocumentPart.Document.Body.ChildElements)
                {
                    if (bd.LocalName == "p")
                    {
                        DOParagraph paragrapgh = new DOParagraph((Paragraph)bd);
                        Environment.AddParagraph(paragrapgh, paragrapgh.IDOElementGuid);
                    }
                    if (bd.LocalName == "tbl")
                    {
                        DOTable table = new DOTable((Table)bd);
                        Environment.AddTable(table, table.IDOElementGuid);
                    }
                }
            }
        }
    }
}
