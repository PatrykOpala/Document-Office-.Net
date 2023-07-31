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
        List<IDOElement> IDOElements = new List<IDOElement>();
        Dictionary<string, DODocumentTemplate> documentTemplateDictionary = new Dictionary<string, DODocumentTemplate>();
        Dictionary<string, DODocumentTemplate> tableDocumentTemplateDictionary = new Dictionary<string, DODocumentTemplate>();
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
                        DOParagraph paragrapgh = new DOParagraph((Paragraph)bd);
                        if (paragrapgh.IsEmpty)
                            comboBox1.Items.Add(new DOItem(paragrapgh.IDOElementGuid, "[Pusty Akapit]", "[Pusty Akapit]"));
                        else
                        {
                            string m = "Wiersz: ";
                            foreach (DORun run in paragrapgh.ListRuns)
                            {
                                foreach (string str in run.ListText)
                                    m += str;
                            }
                            comboBox1.Items.Add(new DOItem(paragrapgh.IDOElementGuid, m, m));
                        }
                        IDOElements.Add(paragrapgh);
                    }
                    if (bd.LocalName == "tbl")
                    {
                        o++;
                        DOTable table = new DOTable((Table)bd);
                        comboBox1.Items.Add(new DOItem(table.IDOElementGuid, $"Tabela: {o}", $"Tabela: {o}"));
                        IDOElements.Add(table);
                    }
                }
                var ctrP = IDOElements;
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
            //DOEngine(ref textBox, label.Text);
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
                dOParagraph.IDOElementGuid = docParag.IDOElementGuid;

                foreach (DORun doc in docParag.ListRuns)
                {
                    DORun oRun = new DORun();
                    oRun.DORunGuid = doc.DORunGuid;

                    oRun.Properties = doc.Properties;

                    foreach (string oText in doc.ListText)
                    {
                        if (oText != null)
                        {
                            if (oText != oldV)
                                oRun.AddText(oText);

                            if (oText == oldV)
                                oRun.AddText(newValue);
                        }
                    }
                    dOParagraph.AddRun(oRun);
                }
                dODocumentTemplate.NewDocsElements.Add(dOParagraph);
                documentTemplateDictionary.Add(DocTmpName, dODocumentTemplate);
            }
            else
            {
                DODocumentTemplate documentTemplate2 = documentTemplateDictionary[j];
                DODocumentTemplate dODocumentTemplate3 = new DODocumentTemplate();
                dODocumentTemplate3.NameDocument = documentTemplate2.NameDocument;
                dODocumentTemplate3.FullPathWithFileName = documentTemplate2.FullPathWithFileName;

                foreach (DOParagraph dOParagraph1 in documentTemplate2.NewDocsElements)
                {
                    DOParagraph dOParagraph2 = new DOParagraph();
                    dOParagraph2.IDOElementGuid = dOParagraph1.IDOElementGuid;
                    dOParagraph2.ParagraphProperties = dOParagraph1.ParagraphProperties;

                    foreach (DORun dORun in dOParagraph1.ListRuns)
                    {
                        DORun dO = new DORun();
                        dO.DORunGuid = dORun.DORunGuid;
                        dO.Properties = dORun.Properties;

                        foreach (string dOText2 in dORun.ListText)
                        {
                            if (dOText2 != oldV)
                                dO.AddText(dOText2);

                            if (dOText2 == oldV)
                                dO.AddText(newValue);
                        }
                        dOParagraph2.AddRun(dO);
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
                Tag = FindedRun.DORunGuid,
                Font = FindedRun.Properties.Font
            };
            LabelRun.Click += new EventHandler(LabelRun_Event_Click);
            foreach (string FindedStr in FindedRun.ListText)
            {
                LabelRun.Text = FindedStr;
                if (LabelRun.Text == " ")
                {
                    LabelRun.Location = new Point(x + 4, 0);
                    x += 17;
                    LabelRun.Text = "[Spacja]";
                    LabelRun.Padding = new Padding(0, 0, 0, 5);
                }
            }
            DOElementContainer.Controls.Add(LabelRun);
            if (LabelRun.Size.Width <= 20)
                x += LabelRun.Size.Width - 13;
            else
                x += LabelRun.Size.Width + 4;
        }
        void MapDOTableObject(DOTable dOTable, ref int x, ref string oldValue, string newValue)
        {
            if (x > NeededCountFile)
                x = 1;

            string DocTmpName = $"{DocumentTmpName} {x}{Path.GetExtension(FileFullName)}";
            j = DocTmpName;

            if (!tableDocumentTemplateDictionary.ContainsKey(j))
            {
                DODocumentTemplate dODocumentTemplate =
                    new DODocumentTemplate();
                dODocumentTemplate.NameDocument = DocTmpName;
                dODocumentTemplate.FullPathWithFileName =
                    Path.GetDirectoryName(FileFullName);

                DOTable table = new DOTable();
                table.IDOElementGuid = dOTable.IDOElementGuid;
                table.TableProperties = dOTable.TableProperties;
                table.TableGrid = dOTable.TableGrid;

                foreach (DOTableRow rowList in dOTable.TableRows)
                {
                    DOTableRow row = new DOTableRow();
                    row.TableRowGuid = rowList.TableRowGuid;
                    row.TableRowProperties = rowList.TableRowProperties;

                    foreach (DOTableCell cell in rowList.TableCells)
                    {
                        DOTableCell dOTableCell = new DOTableCell();
                        dOTableCell.TableCellGuid = cell.TableCellGuid;
                        dOTableCell.TableCellProperties = cell.TableCellProperties;

                        foreach (DOParagraph pa in cell.TableParagraphs)
                        {
                            DOParagraph dOParagraph = new DOParagraph();
                            dOParagraph.IDOElementGuid = pa.IDOElementGuid;
                            dOParagraph.ParagraphProperties = pa.ParagraphProperties;

                            foreach (DORun doc in pa.ListRuns)
                            {
                                DORun oRun = new DORun();
                                oRun.DORunGuid = doc.DORunGuid;
                                oRun.Properties = doc.Properties;

                                foreach (string oText in doc.ListText)
                                {
                                    if (oText != null)
                                    {
                                        if (oText != oldValue)
                                            oRun.AddText(oText);

                                        if (oText == oldValue)
                                            oRun.AddText(newValue);
                                    }
                                }
                                dOParagraph.AddRun(oRun);
                            }
                            dOTableCell.AddParagraph(dOParagraph);
                        }
                        row.AddCell(dOTableCell);
                    }
                    table.AddTableRow(row);
                }
                dODocumentTemplate.NewDocsElements.Add(table);
                tableDocumentTemplateDictionary.Add(DocTmpName, dODocumentTemplate);
            }
            else
            {
                DODocumentTemplate documentTemplate2 = tableDocumentTemplateDictionary[j];
                DODocumentTemplate dODocumentTemplate3 = new DODocumentTemplate();
                dODocumentTemplate3.NameDocument = documentTemplate2.NameDocument;
                dODocumentTemplate3.FullPathWithFileName = documentTemplate2.FullPathWithFileName;
                
                foreach (DOTable idoelement in documentTemplate2.NewDocsElements)
                {
                    DOTable dOTable2 = new DOTable();
                    dOTable2.TableGrid = idoelement.TableGrid;
                    dOTable2.IDOElementGuid = idoelement.IDOElementGuid;
                    dOTable2.TableProperties = idoelement.TableProperties;

                    foreach (DOTableRow row2 in idoelement.TableRows)
                    {
                        DOTableRow row3 = new DOTableRow();
                        row3.TableRowGuid = row2.TableRowGuid;
                        row3.TableRowProperties = row2.TableRowProperties;

                        foreach (DOTableCell dOTableCell in row2.TableCells)
                        {
                            DOTableCell dOTableCell2 = new DOTableCell();
                            dOTableCell2.TableCellGuid = dOTableCell.TableCellGuid;
                            dOTableCell2.TableCellProperties = dOTableCell.TableCellProperties;

                            foreach (DOParagraph dOParagraph in dOTableCell.TableParagraphs)
                            {
                                DOParagraph dOParagraph2 = new DOParagraph();
                                dOParagraph2.ParagraphProperties = dOParagraph.ParagraphProperties;
                                dOParagraph2.IDOElementGuid = dOParagraph.IDOElementGuid;

                                foreach (DORun dORun2 in dOParagraph.ListRuns)
                                {
                                    DORun dO = new DORun();
                                    dO.DORunGuid = dORun2.DORunGuid;
                                    dO.Properties = dORun2.Properties;

                                    foreach (string dOText2 in dORun2.ListText)
                                    {
                                        if (dOText2 != oldValue)
                                            dO.AddText(dOText2);

                                        if (dOText2 == oldValue)
                                            dO.AddText(newValue);
                                    }
                                    dOParagraph2.AddRun(dO);
                                }
                                dOTableCell2.AddParagraph(dOParagraph2);
                            }
                            row3.AddCell(dOTableCell2);
                        }
                        dOTable2.AddTableRow(row3);
                    }
                    dODocumentTemplate3.NewDocsElements.Add(dOTable2);
                    tableDocumentTemplateDictionary[j].NewDocsElements = dODocumentTemplate3.NewDocsElements;
                    var ctrPoint = tableDocumentTemplateDictionary[j].NewDocsElements;
                    var jjjjjj = ctrPoint;
                    return;
                }

                    /*

                    DOTable table2 = new DOTable();
                    table2.IDOElementGuid = table1.IDOElementGuid;
                    table2.TableProperties = table1.TableProperties;
                    table2.TableGrid = table1.TableGrid;
                    
                    foreach(DOTableRow row2 in table1.TableRows)
                    {
                        DOTableRow row3 = new DOTableRow();
                        row3.TableRowGuid = row2.TableRowGuid;
                        row3.TableRowProperties = row2.TableRowProperties;
                        
                        foreach(DOTableCell dOTableCell in row2.TableCells)
                        {
                            DOTableCell dOTableCell2 = new DOTableCell();
                            dOTableCell2.TableCellGuid = dOTableCell.TableCellGuid;
                            dOTableCell2.TableCellProperties = dOTableCell.TableCellProperties;
                            
                            foreach(DOParagraph dOParagraph in dOTableCell.TableParagraphs)
                            {
                                DOParagraph dOParagraph2 = new DOParagraph();
                                dOParagraph2.ParagraphProperties = dOParagraph.ParagraphProperties;
                                dOParagraph2.IDOElementGuid = dOParagraph.IDOElementGuid;
                                
                                foreach(DORun dORun2 in dOParagraph.ListRuns)
                                {
                                    DORun dO = new DORun();
                                    dO.DORunGuid = dORun2.DORunGuid;
                                    dO.Properties = dORun2.Properties;

                                    foreach (string dOText2 in dORun2.ListText)
                                    {
                                        if (dOText2 != oldValue)
                                            dO.AddText(dOText2);

                                        if (dOText2 == oldValue)
                                            dO.AddText(newValue);
                                    }
                                    dOParagraph2.AddRun(dO);
                                }
                                dOTableCell2.AddParagraph(dOParagraph2);
                            }
                            row3.AddCell(dOTableCell2);
                        }
                        table2.AddTableRow(row3);
                    }
                    dODocumentTemplate3.NewDocsElements.Add(table2);
                }
                documentTemplateDictionary[j] = dODocumentTemplate3;*/
              }
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
                Location = new Point(41, PanelNewspaperHeight + 20),
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
                            MapDOTableObject(docTable, ref t, ref oldV, Box1.Text);
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
        void CreateTable(DOTable table)
        {
            DOElementContainer.Controls.Clear();
            int x = 4;
            int y = 0;
            int width = 100;
            int height = 40;
            foreach (var tableY in table.TableRows)
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
                            Tag = tableParag.IDOElementGuid
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
                    CheckIndex(ref index, tableY.TableCells.Length);
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
                    IDOElement dOElement = IDOElements.Find(el => el.IDOElementGuid == ((DOItem)combo.SelectedItem).itemID);
                    DOParagraph paragraph = (DOParagraph)dOElement;
                    docParag = paragraph;
                    int x = 60;
                    foreach (DORun FindedRun in paragraph.ListRuns)
                        CreateLabel(FindedRun, ref x);
                }
                if (combo.SelectedItem.ToString().StartsWith("Tabela"))
                {
                    DOElementContainer.AutoScroll = true;
                    IDOElement dOElementTable = IDOElements.Find(el => el.IDOElementGuid == ((DOItem)combo.SelectedItem).itemID);
                    DOTable tableElement = (DOTable)dOElementTable;
                    docTable = tableElement;
                    //int tableWidth = table.TableProperties.TableWidth.getCalculateWidth(DOElementContainer.Size.Width);
                    if(tableElement != null)
                        CreateTable(tableElement);
                }
            }
        }
        void button1_Click(object sender, EventArgs e)
        {
            //var ctrP = documentTemplateDictionary;
        }
        void DOEngine(ref TextBox textBox, string labelText) 
        {
            string placeholder = $"Z({labelText})N()W()";
            textBox.Text = placeholder;
        }
    }
}
