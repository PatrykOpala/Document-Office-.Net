using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Document_Office.Net.Forms
{
    public partial class NewEditorConcept : Form
    {
        List<IDOElement> IDOElements = new List<IDOElement>();
        private int Paragraph_Start_Point_X = 52;
        private int Paragraph_Start_Point_Y = 114;
        public NewEditorConcept(string file, ushort countFile)
        {
            InitializeComponent();
            OpenDocx(file);
            GenerateParagraph();
        }
        void OpenDocx(string f)
        {
            using (WordprocessingDocument word = WordprocessingDocument.Open(f, true))
            {
                int o = 0;
                foreach (var bd in word.MainDocumentPart.Document.Body.ChildElements)
                {
                    if (bd.LocalName == "p")
                    {
                        DOParagraph paragrapgh = new DOParagraph((Paragraph)bd);
                        
                        IDOElements.Add(paragrapgh);
                    }
                    if (bd.LocalName == "tbl")
                    {
                        o++;
                        DOTable table = new DOTable((Table)bd);
                        IDOElements.Add(table);
                    }
                }
                //var ctrP = IDOElements;
            }
        }

        void GenerateParagraph()
        {
            //NewEditorConcept
            foreach (IDOElement element in IDOElements)
            {
                if(element.Type == "Paragraph")
                {
                    DOParagraph dOParag = (DOParagraph)element;

                    dOParag.generateParagraphUI(this, Paragraph_Start_Point_X, Paragraph_Start_Point_Y);
                    Paragraph_Start_Point_Y += 110;
                }
                else
                {
                    return;
                }
            }
        }
    }
}
