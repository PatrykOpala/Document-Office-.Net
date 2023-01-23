using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Office2010.Word;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Document_Office.Net.Forms
{
    public partial class EdytorWindow : Form
    {
		// ./WriteDocxObjectToJSON -f='C:\Users\patry\Desktop\test.docx'
        private List<DOElement> ButtonElements = new List<DOElement>();
        private List<DOElement> ButtonElementsCopy = new List<DOElement>();
        private List<DODocumentTemplate> temp = new List<DODocumentTemplate>();
        private Dictionary<string, DODocumentTemplate> documentTemplateDictionary = new Dictionary<string, DODocumentTemplate>();
        private static float FONT_SIZE = 20.0F;
        private ushort NeededCountFile = 0;
        private ushort DuplicateCount = 0;
        private int ParagraphID = 0;
        private int x = 60;
        private int RunID = 0;
        private string FileFullName = "";
        private string DocumentTmpName = "";
        private string j = "";

        private DOParagraph docParag = new DOParagraph();

        public EdytorWindow(string file, ushort countFile)
        {
            InitializeComponent();
            NeededCountFile = countFile;
            DuplicateCount = countFile;
            InitializeValues();
            OpenDocx(file);
            InitializeDocumentTemplate(file);
        }

        private void InitializeDocumentTemplate(string FileName)
        {
            FileFullName = FileName;
            DocumentTmpName = Path.GetFileNameWithoutExtension(FileName);
            /*while(t <= NeededCountFile)
            {
                DODocumentTemplate dODocumentTemplate = new DODocumentTemplate();
                string DocTmpName = $"{DocumentTmpName} {t + 1}";
                DocTmpName += Path.GetExtension(FileName);
                dODocumentTemplate.NameDocument = DocTmpName;
                dODocumentTemplate.FullPathWithFileName = Path.GetDirectoryName(FileName);
                temp.Add(dODocumentTemplate);
                OldValue.Add(DocTmpName);
            }
            */
        }

        private void InitializeValues()
        {
            duplicateLabel.Text = $"Liczba kopii możliwych do zrobienia: {DuplicateCount}";
            panelNewspaper.Location = new System.Drawing.Point((panelEdytor.Size.Width / 4), (panelEdytor.Size.Height / 7));
            comboBox1.Items.Add("Wybierz linie");
            comboBox1.Text = "Wybierz Linie";
        }

        private void OpenDocx(string f)
        {
            using (WordprocessingDocument word = WordprocessingDocument.Open(f, true))
            {
                int w = 0;

                foreach (var bd in word.MainDocumentPart.Document.Body.ChildElements)
                {
                    if (bd.LocalName == "p")
                    {
                        DOParagraph paragrapgh = new DOParagraph((Paragraph)bd,w);
                        ButtonElements.Add(paragrapgh);
                        w++;
                    }
                    if (bd.LocalName == "tbl")
                    {
                        DOTable table = new DOTable((Table)bd, w);
                        ButtonElements.Add(table);
                        w++;
                    }
                }

                foreach (var p in ButtonElements)
                {
                    if(p.GetType().ToString() != "Document_Office.Net.DOTable")
                    {
                        string label = "Linia: ";

                        DOParagraph parag = (DOParagraph)ButtonElements.Find(par => par.DOID == p.DOID);
                        
                        /**/
                        foreach (DORun run in parag.Arrayruns)
                        {
                            foreach (DOText str in run.Text)
                            {
                                 label += str.Value;
                            }
                        }
                        comboBox1.Items.Add(new DOItem(p.DOID, label, label));
                    }
                    else
                    {
                        DOTable tabl = (DOTable)ButtonElements.Find(par => par.DOID == p.DOID);

                        /*
                        foreach (DORun run in parag.Arrayruns)
                        {
                            foreach (string str in run.Text)
                            {
                                label += str;
                            }
                        }*/

                        comboBox1.Items.Add(new DOItem(p.DOID, "Tabela", "Tabela"));
                    }
                }
            }
        }

        private void ParseOldObjectCreatedNewObject()
        {
            /*ButtonElementsCopy = ButtonElements;
            DOParagraph FindParagraph = (DOParagraph)ButtonElementsCopy.Find(el => el.DOID == ParagraphID);
            int Index = ButtonElementsCopy.FindIndex(ee => ee.DOID == ParagraphID);
            for(int inter = 0; inter < FindParagraph.ListRuns.Rank; inter++)
            {
                if (FindParagraph.Arrayruns[inter].DORunID == RunID)
                {
                    DORun oRun = FindParagraph.Arrayruns[inter];
                    foreach(DOText oldVal in oRun.Text)
                    {
                        //oldVal.SetNewValue(OldValue, text);
                    }
                    FindParagraph.Arrayruns[inter] = oRun;
                }
            }
            ButtonElementsCopy[Index] = FindParagraph;
            var nu = ButtonElementsCopy;*/
        }

        private void ReturnParagraphProperties(ParagraphProperties paragraphProperties, DOParagraph dOParagraph)
        {

        }

        private void LabelRun_Event_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if(DuplicateCount == 0)
            {
                DuplicateCount = NeededCountFile;
                duplicateLabel.Text = $"Liczba kopii możliwych do zrobienia: {DuplicateCount}";
            }
            RunID = int.Parse(label.Tag.ToString());
            string oldV = label.Text;

            int pNewsWidth = (int)(panelNewspaper.Size.Width / 1.2) + 10;
            int pNewsHeight = (int)(panelNewspaper.Size.Height / 1.5);
            TextBox textBox = new TextBox()
            {
                Size = new Size(pNewsWidth, 70),
                Location = new Point(59, pNewsHeight),
                Text = "PlaceHolder",
                Font = new System.Drawing.Font("Microsoft Sans Serif", FONT_SIZE, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)))
            };
            
            int t = 0;

            textBox.KeyDown += new KeyEventHandler((object keySender, KeyEventArgs keyArgs) =>
            {
                TextBox Box1 = (TextBox)keySender;
                if(keyArgs.KeyValue == 13)
                {
                    keyArgs.SuppressKeyPress = true;

                    if (docParag != null)
                    {
                        if (DuplicateCount > 0)
                        {
                            t++;
                            DuplicateCount = DuplicateCount -= 1;
                            duplicateLabel.Text = $"Liczba kopii możliwych do zrobienia: {DuplicateCount}";

                            MapDODocumentObject(docParag, t, oldV, Box1.Text);
                            
                            Box1.Text = "";

                            var b = temp;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nieznaleziono elementu");
                    }
                }
            });

            panelNewspaper.Controls.Add(textBox);
        }

        private void MapDODocumentObject(DOParagraph docParag, int t, string oldV, string newValue)
        {
            /**/

            MessageBox.Show(documentTemplateDictionary.ContainsKey(j).ToString());

            if (!documentTemplateDictionary.ContainsKey(j))
            {
                DODocumentTemplate dODocumentTemplate = new DODocumentTemplate();
                string DocTmpName = $"{DocumentTmpName} {t}";
                DocTmpName += Path.GetExtension(FileFullName);
                j = DocTmpName;
                dODocumentTemplate.NameDocument = DocTmpName;
                dODocumentTemplate.FullPathWithFileName = Path.GetDirectoryName(FileFullName);
                DOParagraph dOParagraph = new DOParagraph();

                foreach (DORun doc in docParag.ListRuns)
                {
                    DORun oRun = new DORun();

                    DORunProp newRunProp = new DORunProp()
                    {
                        Bold = doc.Properties.Bold,
                        BoldComplexScript = doc.Properties.BoldComplexScript,
                        Border = doc.Properties.Border,
                        Caps = doc.Properties.Caps,
                        _Color = doc.Properties._Color,
                        CharakterScale = doc.Properties.CharakterScale,
                        ComplexScript = doc.Properties.ComplexScript,
                        Highlight = doc.Properties.Highlight,
                        Italic = doc.Properties.Italic,
                        ItalicComplexScript = doc.Properties.ItalicComplexScript,
                        NumberSpacing = doc.Properties.NumberSpacing,
                        Outline = doc.Properties.Outline,
                        FontSize = doc.Properties.FontSize,
                        SmallCaps = doc.Properties.SmallCaps,
                        Spacing = doc.Properties.Spacing,
                        Strike = doc.Properties.Strike,
                        Underline = doc.Properties.Underline
                    };

                    oRun.Properties = newRunProp;

                    foreach (DOText oText in doc.ListText)
                    {
                        if (oText.Value != oldV)
                        {
                            DOText oText1 = new DOText();
                            oText1.Value = oText.Value;
                            oRun.ListText.Add(oText1);
                        }

                        if (oText.Value == oldV)
                        {
                            DOText oText1 = new DOText();
                            oText1.Value = newValue;
                            oRun.ListText.Add(oText1);
                        }
                    }
                    dOParagraph.ListRuns.Add(oRun);
                }
                dODocumentTemplate.NewDocsElements.Add(dOParagraph);
                documentTemplateDictionary.Add(DocTmpName, dODocumentTemplate);
            }
            else
            {
                string DocTmpName2 = $"{DocumentTmpName} {t}";
                DocTmpName2 += Path.GetExtension(FileFullName);
                var documentTemplate = documentTemplateDictionary[j];

                foreach (DOParagraph dOParagraph1 in documentTemplate.NewDocsElements)
                {
                    DOParagraph dOParagraph2 = new DOParagraph();

                    foreach (DORun dORun in dOParagraph1.ListRuns)
                    {
                        DORun dO = new DORun();
                        DORunProp newRunProp2 = new DORunProp()
                        {
                            Bold = dORun.Properties.Bold,
                            BoldComplexScript = dORun.Properties.BoldComplexScript,
                            Border = dORun.Properties.Border,
                            Caps = dORun.Properties.Caps,
                            _Color = dORun.Properties._Color,
                            CharakterScale = dORun.Properties.CharakterScale,
                            ComplexScript = dORun.Properties.ComplexScript,
                            Highlight = dORun.Properties.Highlight,
                            Italic = dORun.Properties.Italic,
                            ItalicComplexScript = dORun.Properties.ItalicComplexScript,
                            NumberSpacing = dORun.Properties.NumberSpacing,
                            Outline = dORun.Properties.Outline,
                            FontSize = dORun.Properties.FontSize,
                            SmallCaps = dORun.Properties.SmallCaps,
                            Spacing = dORun.Properties.Spacing,
                            Strike = dORun.Properties.Strike,
                            Underline = dORun.Properties.Underline
                        };
                        dO.Properties = newRunProp2;

                        foreach (DOText dOText2 in dORun.ListText)
                        {
                            if (dOText2.Value != oldV)
                            {
                                DOText oText1 = new DOText();
                                oText1.Value = dOText2.Value;
                                dO.ListText.Add(oText1);
                            }

                            if (dOText2.Value == oldV)
                            {
                                DOText oText1 = new DOText();
                                oText1.Value = newValue;
                                dO.ListText.Add(oText1);
                            }
                        }
                        dOParagraph2.ListRuns.Add(dO);
                    }
                    documentTemplate.NewDocsElements.Clear();
                    documentTemplate.NewDocsElements.Add(dOParagraph2);
                }
                documentTemplateDictionary[DocTmpName2] = documentTemplate;
            }
            var wkfhwbfhwbfhwfeb = documentTemplateDictionary;
        }

        private int CreateLabel(DORun FindedRun, int x)
        {
            Label LabelRun = new Label()
            {
                Location = new Point(x, 141),
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
                AutoSize = true,
                Tag = FindedRun.DORunID,
            };
            LabelRun.Click += new EventHandler(this.LabelRun_Event_Click);
            
            if (FindedRun.Properties.FontSize != null)
            {
                LabelRun.Font = new System.Drawing.Font("Microsoft Sans Serif", float.Parse(FindedRun.Properties.FontSize), FontStyle.Regular, GraphicsUnit.Point, 238);
            }
            
            foreach (DOText FindedStr in FindedRun.ListText)
            {
                LabelRun.Text = FindedStr.Value;
                if (LabelRun.Text == " ")
                {
                    LabelRun.Text = "[spacja]";
                }
            }
            panelNewspaper.Controls.Add(LabelRun);
            if (LabelRun.Size.Width <= 20)
            {
                return x += LabelRun.Size.Width - 13;
            }
            else
            {
                return x += LabelRun.Size.Width + 4;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            if (combo.SelectedItem.ToString() != "Wybierz linie")
            {
                DOItem selectItem = (DOItem)combo.SelectedItem;
                DOParagraph element = (DOParagraph)ButtonElements.Find(el => el.DOID == selectItem.itemID);
                ParagraphID = element.DOID;
                docParag = element;
                foreach (DORun FindedRun in element.ListRuns)
                {
                   x = CreateLabel(FindedRun, x);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ParseOldObjectCreatedNewObject();
        }
    }
}
