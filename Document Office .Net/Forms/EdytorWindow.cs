using System.Collections.Generic;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Document_Office.Net.Forms
{
    public partial class EdytorWindow : Form
    {
        protected List<OpenXmlElement> docxElements = new List<OpenXmlElement>();
        protected OpenXmlElement select { get; set; }
        //OpenXmlCompositeElement
        public EdytorWindow(string file)
        {
            InitializeComponent();
            openDocx(file);
        }

        // DocumentFormat.OpenXml.Wordprocessing.Paragraph
        // DocumentFormat.OpenXml.Wordprocessing.Table

        private void openDocx(string f)
        {
            using (WordprocessingDocument word = WordprocessingDocument.Open(f, true))
            {
                int w = 0;
                //var reg = new Regex(@"^[\s\p{L}\d\•\-\►]");

                // body.Descendants<Paragraph>().Where<Paragraph>(somethingElse =>
                //reg.IsMatch(somethingElse.InnerText)

                foreach(Paragraph by in word.MainDocumentPart.Document.Body.Elements<Paragraph>())
                {
                    var parag = new PhItem();
                    parag._Body = $"Paragraph {w}";
                    foreach (Run v in by.Elements<Run>())
                    {
                        parag._Header = v.InnerText;
                        foreach (RunProperties rP in v.Elements<RunProperties>())
                        {
                            if (rP.Color is Color)
                            {
                                parag._Color = System.Drawing.ColorTranslator.FromHtml("#" + rP.Color.Val.Value);
                            }
                        }
                    }
                    paragraphContainer1.AddItem(parag);
                    w++;
                }
            }
        }
    }
}
