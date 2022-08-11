
using System;
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
        public Int16 _y = 100;
        protected OpenXmlElement select { get; set; }
        //OpenXmlCompositeElement
        public EdytorWindow(string file)
        {
            InitializeComponent();
            createParagraph();
            //openDocx(file);
        }

        // DocumentFormat.OpenXml.Wordprocessing.Paragraph
        // DocumentFormat.OpenXml.Wordprocessing.Table

        private void createParagraph()
        {
            var p1 = new CustomUserControls.ParagraphButton();
            var p2 = new CustomUserControls.ParagraphButton();
            p2.Location = new System.Drawing.Point(300, 0);
            var p3 = new CustomUserControls.ParagraphButton();
            p3.Location = new System.Drawing.Point(600, 0);
            var p4 = new CustomUserControls.ParagraphButton();
            p4.Location = new System.Drawing.Point(900, 0);

            paragraphContainer1.Controls.Add(p1);
            paragraphContainer1.Controls.Add(p2);
            paragraphContainer1.Controls.Add(p3);
            paragraphContainer1.Controls.Add(p4);
        }

        private void openDocx(string f)
        {
            using (WordprocessingDocument word = WordprocessingDocument.Open(f, true))
            {
                Body body = word.MainDocumentPart.Document.Body;

                //var reg = new Regex(@"^[\s\p{L}\d\•\-\►]");

                // body.Descendants<Paragraph>().Where<Paragraph>(somethingElse =>
                //reg.IsMatch(somethingElse.InnerText)

                foreach(Paragraph by in body.Elements<Paragraph>())
                {
                    Panel parag = new Panel();
                    parag.Location = new System.Drawing.Point(100, _y);
                    foreach (Run v in by.Elements<Run>())
                    {
                        Label lbl = new Label();
                        lbl.Text = v.InnerText;
                        foreach (RunProperties rP in v.Elements<RunProperties>())
                        {
                            if (rP.Color is Color)
                            {
                                lbl.ForeColor = System.Drawing.ColorTranslator.FromHtml("#" + rP.Color.Val.Value);
                            }
                        }
                        parag.Controls.Add(lbl);
                    }
                    panelNewspaper.Controls.Add(parag);
                    _y+=30;
                }
            }
        }
    }
}
