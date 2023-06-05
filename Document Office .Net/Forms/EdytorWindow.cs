using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Label = System.Windows.Forms.Label;

namespace Document_Office.Net.Forms
{
    public partial class EdytorWindow : Form
    {
        // ./WriteDocxObjectToJSON -f='C:\Users\patry\Desktop\test.docx'
        List<IDOElement> ButtonElements = new List<IDOElement>();
        Dictionary<string, DODocumentTemplate> documentTemplateDictionary = new Dictionary<string, DODocumentTemplate>();
        TextBox textBox1 = null;
        int PanelNewspaperHeight = 0;
        static float FONT_SIZE = 20.0F;
        static string INITIALIZE_COMBOBOX_VALUE = "Wybierz Wiersz";
        ushort NeededCountFile = 0;
        ushort DuplicateCount = 0;
        string FileFullName = "";
        string DocumentTmpName = "";
        string j = "";
        string oldV = "";

        DOParagraph docParag = new DOParagraph();
        DOTable docTable = new DOTable();

        public EdytorWindow(string file, ushort countFile)
        {
            InitializeComponent();
            NeededCountFile = countFile;
            DuplicateCount = countFile;
            InitializeValues();
            OpenDocx(file);
            InitializeDocumentTemplate(file);
        }

        void InitializeDocumentTemplate(string FileName)
        {
            FileFullName = FileName;
            DocumentTmpName = Path.GetFileNameWithoutExtension(FileName);
        }

        void InitializeValues()
        {
            duplicateLabel.Text = $"Liczba kopii możliwych do zrobienia: {DuplicateCount}";
            panelNewspaper.Location = new Point((panelEdytor.Size.Width / 4), (panelEdytor.Size.Height / 7));
            comboBox1.Items.Add(INITIALIZE_COMBOBOX_VALUE);
            comboBox1.Text = INITIALIZE_COMBOBOX_VALUE;
            PanelNewspaperHeight = (int)(panelNewspaper.Size.Height / 1.3);
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
                        DOParagraph paragrapgh = new DOParagraph((Paragraph)bd, Guid.NewGuid());
                        if (paragrapgh.GetIsEmpty())
                            comboBox1.Items.Add(new DOItem(paragrapgh.GetDOID(), "Wiersz: [Pusty]", "Wiersz: [Pusty]"));
                        else
                        {
                            string m = "Wiersz: ";
                            foreach (DORun run in paragrapgh.ListRuns)
                            {
                                foreach (string str in run.ListText)
                                    m += str;
                            }
                            comboBox1.Items.Add(new DOItem(paragrapgh.GetDOID(), m, m));
                        }
                        ButtonElements.Add(paragrapgh);
                    }
                    if (bd.LocalName == "tbl")
                    {
                        o++;
                        DOTable table = new DOTable((Table)bd, Guid.NewGuid());
                        comboBox1.Items.Add(new DOItem(table.GetDOID(), $"Tabela: {o}", $"Tabela: {o}"));
                        ButtonElements.Add(table);
                    }
                }
            }
        }

        void LabelRun_Event_Click(object sender, EventArgs e)
        {
            if (textBox1 != null)
            {
                panelNewspaper.Controls.Remove(textBox1);
            }
            Label label = (Label)sender;
            if (DuplicateCount == 0)
            {
                DuplicateCount = NeededCountFile;
                duplicateLabel.Text = $"Liczba kopii możliwych do zrobienia: {DuplicateCount}";
            }
            oldV = label.Text;
            TextBox textBox = new TextBox()
            {
                Size = new Size((int)((panelNewspaper.Size.Width / 1.2) + 10), 70),
                Location = new Point(59, PanelNewspaperHeight),
                Font = new System.Drawing.Font("Microsoft Sans Serif", FONT_SIZE, FontStyle.Regular, GraphicsUnit.Point, 238)
            };
            int t = 0;
            textBox.KeyDown += new KeyEventHandler((object keySender, KeyEventArgs keyArgs) =>
            {
                TextBox Box1 = (TextBox)keySender;
                if (keyArgs.KeyValue == 13)
                {
                    keyArgs.SuppressKeyPress = true;
                    if (docParag != null)
                    {
                        if (DuplicateCount > 0)
                        {
                            t++;
                            DuplicateCount = DuplicateCount -= 1;
                            duplicateLabel.Text = $"Liczba kopii możliwych do zrobienia: {DuplicateCount}";
                            MapDODocumentObject(docParag, ref t, ref oldV, Box1.Text);
                            Box1.Text = "";
                        }
                        else { return; }
                    }
                    else { MessageBox.Show("Nieznaleziono elementu"); }
                }
            });
            panelNewspaper.Size = new Size(793, 552);
            button1.Location = new Point(610, 474);
            panelNewspaper.Controls.Add(textBox);
            textBox1 = textBox;
        }

        void MapDODocumentObject(DOParagraph docParag, ref int t, ref string oldV, string newValue)
        {
            if (t > NeededCountFile)
                t = 1;

            string DocTmpName = $"{DocumentTmpName} {t}{Path.GetExtension(FileFullName)}";
            j = DocTmpName;

            if (!documentTemplateDictionary.ContainsKey(j))
            {
                DODocumentTemplate dODocumentTemplate = new DODocumentTemplate();
                dODocumentTemplate.NameDocument = DocTmpName;
                dODocumentTemplate.FullPathWithFileName = Path.GetDirectoryName(FileFullName);
                DOParagraph dOParagraph = new DOParagraph();

                foreach (DORun doc in docParag.ListRuns)
                {
                    DORun oRun = new DORun();

                    DORunProp newRunProp = doc.Properties;

                    oRun.Properties = newRunProp;

                    foreach (string oText in doc.ListText)
                    {
                        if (oText != null)
                        {
                            if (oText != oldV)
                                oRun.ListText.Add(oText);

                            if (oText == oldV)
                                oRun.ListText.Add(newValue);
                        }
                    }
                    dOParagraph.ListRuns.Add(oRun);
                }
                dODocumentTemplate.NewDocsElements.Add(dOParagraph);
                documentTemplateDictionary.Add(DocTmpName, dODocumentTemplate);
            }
            else
            {
                DODocumentTemplate documentTemplate2 = documentTemplateDictionary[j];
                DODocumentTemplate dODocumentTemplate3 = new DODocumentTemplate();
                dODocumentTemplate3.NameDocument = j;

                foreach (DOParagraph dOParagraph1 in documentTemplate2.NewDocsElements)
                {
                    DOParagraph dOParagraph2 = new DOParagraph();

                    foreach (DORun dORun in dOParagraph1.ListRuns)
                    {
                        DORun dO = new DORun();
                        DORunProp newRunProp2 = dORun.Properties;
                        dO.Properties = newRunProp2;

                        foreach (string dOText2 in dORun.ListText)
                        {
                            if (dOText2 != oldV)
                                dO.ListText.Add(dOText2);

                            if (dOText2 == oldV)
                                dO.ListText.Add(newValue);
                        }
                        dOParagraph2.ListRuns.Add(dO);
                    }
                    dODocumentTemplate3.NewDocsElements.Add(dOParagraph2);
                }
                documentTemplateDictionary[j] = dODocumentTemplate3;
            }
        }

        void CheckIndex(ref int idx, int maxCount)
        {
            if (idx < maxCount)
            {
                idx++;
            }
            else
            {
                idx = 0;
            }
        }

        void CreateLabel(DORun FindedRun, ref int x)
        {
            Label LabelRun = new Label()
            {
                Location = new Point(x, 0),
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
                AutoSize = true,
                Tag = FindedRun.DORunID,
                Font = FindedRun.Properties.FontSize
            };
            LabelRun.Click += new EventHandler(LabelRun_Event_Click);
            foreach (string FindedStr in FindedRun.ListText)
            {
                LabelRun.Text = FindedStr;
                if (LabelRun.Text == " ")
                    x += 17;
            }
            DOElementContainer.Controls.Add(LabelRun);
            if (LabelRun.Size.Width <= 20)
                x += LabelRun.Size.Width - 13;
            else
                x += LabelRun.Size.Width + 4;
        }
        void TableEventClick(object sender, EventArgs tableEventArgs)
        {
            if (textBox1 != null)
            {
                panelNewspaper.Controls.Remove(textBox1);
            }
            var tableL = (Label)sender;
            if (DuplicateCount == 0)
            {
                DuplicateCount = NeededCountFile;
                duplicateLabel.Text = $"Liczba kopii możliwych do zrobienia: {DuplicateCount}";
            }
            oldV = tableL.Text;
            TextBox textBox = new TextBox()
            {
                Size = new Size((int)((panelNewspaper.Size.Width / 1.2) + 10), 70),
                Location = new Point(59, PanelNewspaperHeight),
                Font = new System.Drawing.Font("Microsoft Sans Serif", FONT_SIZE, FontStyle.Regular, GraphicsUnit.Point, 238)
            };
            int t = 0;
            textBox.KeyDown += new KeyEventHandler((object keySender, KeyEventArgs keyArgs) =>
            {
                TextBox Box1 = (TextBox)keySender;
                if (keyArgs.KeyValue == 13)
                {
                    keyArgs.SuppressKeyPress = true;
                    if (docParag != null)
                    {
                        if (DuplicateCount > 0)
                        {
                            t++;
                            DuplicateCount = DuplicateCount -= 1;
                            duplicateLabel.Text = $"Liczba kopii możliwych do zrobienia: {DuplicateCount}";
                            //MapDODocumentObject(docParag, ref t, ref oldV, Box1.Text);
                            Box1.Text = "";
                        }
                        else { return; }
                    }
                    else { MessageBox.Show("Nieznaleziono elementu"); }
                }
            });
            panelNewspaper.Size = new Size(793, 552);
            button1.Location = new Point(610, 474);
            panelNewspaper.Controls.Add(textBox);
            textBox1 = textBox;






            /*ButtonElements.ForEach((f) =>
            {
                //Console.WriteLine(f.GetType());
                if(f.GetType() == "Table")
                {
                    //Console.WriteLine(f.ToString());

                }
                else
                {
                    return;
                }
            }
            );*/

            //Console.WriteLine(tableL.Tag);
        }
        void CreateTable(DOTable table)
        {
            DOElementContainer.Controls.Clear();
            int x = 4;
            int y = 0;
            int width = 100;
            int height = 40;
            foreach (var tableY in table.TableRowList)
            {
                int index = 0;
                foreach (var tableX in table.TableGrid.GridColumns)
                {
                    Panel panel = new Panel
                    {
                        Location = new Point(x, y),
                        Size = new System.Drawing.Size(width, height),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    foreach (var tableParag in tableY.TableCells[index].TableParagraphs)
                    {
                        int xParag = 0;
                        int yParag = 0;
                        Label label = new Label
                        {
                            Location = new Point(xParag + 30, yParag + 10),
                            Tag = tableParag.GetDOID()
                        };
                        foreach (var tableRun in tableParag.ListRuns)
                        {
                            foreach (var tableText in tableRun.ListText)
                            {
                                label.Text = tableText;
                            }
                        }
                        label.Click += new EventHandler(TableEventClick);
                        panel.Controls.Add(label);
                    }
                    DOElementContainer.Controls.Add(panel);
                    x += 100;
                    CheckIndex(ref index, tableY.TableCells.Count);
                }
                y += 40;
                x = 4;
            }
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            if (combo.SelectedItem.ToString() != INITIALIZE_COMBOBOX_VALUE)
            {
                if (combo.SelectedItem.ToString().StartsWith("Wiersz") && combo.SelectedItem.ToString().Contains("[Pusty]"))
                {
                    return;
                }
                else if(combo.SelectedItem.ToString().StartsWith("Wiersz"))
                {
                    DOElementContainer.Controls.Clear();
                    IDOElement dOElement = ButtonElements.Find(el => el.DOID == ((DOItem)combo.SelectedItem).itemID);
                    DOParagraph paragraph = (DOParagraph)dOElement;
                    docParag = paragraph;
                    int x = 60;
                    foreach (DORun FindedRun in paragraph.ListRuns)
                        CreateLabel(FindedRun, ref x);
                }
                if (combo.SelectedItem.ToString().StartsWith("Tabela"))
                {
                    DOElementContainer.AutoScroll = true;
                    IDOElement dOElementTable = ButtonElements.Find(el => el.DOID == ((DOItem)combo.SelectedItem).itemID);
                    DOTable tableElement = (DOTable)dOElementTable;
                    docTable = tableElement;
                    //int tableWidth = table.TableProperties.TableWidth.getCalculateWidth(DOElementContainer.Size.Width);

                    CreateTable(tableElement);
                }
            }
        }

        void button1_Click(object sender, EventArgs e){}
    }
}
