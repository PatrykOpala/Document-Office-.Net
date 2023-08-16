﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Label = System.Windows.Forms.Label;

namespace Document_Office.Net.Forms
{
    public partial class EdytorWindow : Form
    {
        // ./WriteDocxObjectToJSON -f='C:\Users\patry\Desktop\test.docx'

        // [#1, Przyjrzeć się czy nie trzeba trochę posprzątać w kodzie]
        // [#2, Zrobić generowanie właściwych plików]
        //Dictionary<string, DODocumentTemplate> documentTemplateDictionary = new Dictionary<string, DODocumentTemplate>();
        //Dictionary<string, DODocumentTemplate> tableDocumentTemplateDictionary = new Dictionary<string, DODocumentTemplate>();
        private List<(int, Guid)> idoTuples = new List<(int, Guid)>();
        private List<DOParagraph> DocsParagraphElements = new List<DOParagraph>();
        private List<DOTable> DocsTableElements = new List<DOTable>();
        private DODocumentTemplate documentTemplate = new DODocumentTemplate();
        TextBox textBox1 = null;
        int PanelNewspaperHeight = 0;
        static float FONT_SIZE = 20.0F;
        static string INITIALIZE_COMBOBOX_VALUE = "Wybierz Wiersz";
        ushort NeededCountFile = 0;
        ushort DuplicateCount = 0;
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
            string FileFullName = FileName;
            string DocumentTmpName = Path.GetFileNameWithoutExtension(FileName);
            DODocumentTemplate dOcumentTemplate = new DODocumentTemplate(DocumentTmpName, FileFullName);
            documentTemplate = dOcumentTemplate;
        }
        void InitializeValues()
        {
            duplicateLabel.Text = $"Liczba kopii możliwych do zrobienia: {DuplicateCount}";
            panelNewspaper.Location = new Point(panelEdytor.Size.Width / 4, panelEdytor.Size.Height / 7);
            comboBox1.Items.Add(INITIALIZE_COMBOBOX_VALUE);
            comboBox1.Text = INITIALIZE_COMBOBOX_VALUE;
            PanelNewspaperHeight = (int)(panelNewspaper.Size.Height / 1.3);
        }
        void OpenDocx(string f)
        {
            using (WordprocessingDocument word = WordprocessingDocument.Open(f, true))
            {
                int o = 0;
                int tIdx = 0;
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
                                m += run.Text;
                            }
                            comboBox1.Items.Add(new DOItem(paragrapgh.IDOElementGuid, m, m));
                        }
                        idoTuples.Add((tIdx, paragrapgh.IDOElementGuid));
                        DocsParagraphElements.Add(paragrapgh);
                        tIdx++;
                    }
                    if (bd.LocalName == "tbl")
                    {
                        o++;
                        DOTable table = new DOTable((Table)bd);
                        comboBox1.Items.Add(new DOItem(table.IDOElementGuid, $"Tabela: {o}", $"Tabela: {o}"));
                        idoTuples.Add((tIdx, table.IDOElementGuid));
                        DocsTableElements.Add(table);
                        tIdx++;
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
            int idx = 0;
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
                            idx++;
                            DuplicateCount = DuplicateCount -= 1;
                            duplicateLabel.Text = $"Liczba kopii możliwych do zrobienia: {DuplicateCount}";
                            MapDODocumentObject(docParag, ref idx, ref oldV, Box1.Text);
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
        void MapDODocumentObject(DOParagraph docParag, ref int idx, ref string oldV, string newValue)
        {
            if (idx > NeededCountFile)
                idx = 1;

            DOParagraph dOParagraph = new DOParagraph{IDOElementGuid = docParag.IDOElementGuid};
            string targetLabel = $"{documentTemplate.NameDocument} {idx}";
            documentTemplate.NameDocument = targetLabel;
            dOParagraph.AddTarget(targetLabel);
            Console.WriteLine(targetLabel);

            if (documentTemplate.NewDocsElements.Count == 0)
            {
                foreach (DORun doc in docParag.ListRuns)
                {
                    DORun oRun = new DORun
                    {
                        DORunGuid = doc.DORunGuid,
                        Properties = doc.Properties
                    };
                    if (doc.Text != null)
                    {
                        if (doc.Text != oldV)
                            oRun.Text = doc.Text;

                        if (doc.Text == oldV)
                            oRun.Text = newValue;
                    }
                    dOParagraph.AddRun(oRun);
                }
                documentTemplate.NewDocsElements.Add(dOParagraph);
            }
            else
            {
                int newDocsIdx = 0;
                DODocumentTemplate template = new DODocumentTemplate
                {
                    NameDocument = documentTemplate.NameDocument,
                    FullPathWithFileName = documentTemplate.FullPathWithFileName,
                    NewDocsElements = documentTemplate.NewDocsElements,
                };

                foreach (DOParagraph dOParagraph1 in documentTemplate.NewDocsElements)
                {
                    DOParagraph dOParagraph2 = new DOParagraph
                    {
                        IDOElementGuid = dOParagraph1.IDOElementGuid,
                        ParagraphProperties = dOParagraph1.ParagraphProperties
                    };
                    dOParagraph2.AddTarget(dOParagraph1.Target);
                    foreach (DORun dORun in dOParagraph1.ListRuns)
                    {
                        DORun dO = new DORun
                        {
                            DORunGuid = dORun.DORunGuid,
                            Properties = dORun.Properties
                        };
                        if (dORun.Text != oldV)
                            dO.Text = dORun.Text;

                        if (dORun.Text == oldV)
                            dO.Text = newValue;
                        dOParagraph2.AddRun(dO);
                    }
                    template.NewDocsElements.Add(dOParagraph2);
                    newDocsIdx++;
                    Console.WriteLine(idx);
                    var ctrlP = template;
                }
            }
        }
        void CheckIndex(ref int idx, int maxCount)
        {
            if (idx < maxCount)
                idx++;
            else
                idx = 0;
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
                Font = FindedRun.Properties.Font,
                ForeColor = FindedRun.Properties._Color
            };
            LabelRun.Click += new EventHandler(LabelRun_Event_Click);
            
            LabelRun.Text = FindedRun.Text;
            if (LabelRun.Text == " ")
            {
                LabelRun.Location = new Point(x + 4, 0);
                x += 17;
                LabelRun.Text = "[Spacja]";
                LabelRun.Padding = new Padding(0, 0, 0, 5);
            }

            DOElementContainer.Controls.Add(LabelRun);
            if (LabelRun.Size.Width <= 20)
                x += LabelRun.Size.Width - 13;
            else
                x += LabelRun.Size.Width + 4;
        }
        void MapDOTableObject(DOTable dOTable, ref string oldValue, string newValue)
        {
            if (documentTemplate.DocsTableElements.Count == 0)
            {
                DOTable table = new DOTable
                {
                    IDOElementGuid = dOTable.IDOElementGuid,
                    TableProperties = dOTable.TableProperties,
                    TableGrid = dOTable.TableGrid
                };

                foreach (DOTableRow rowList in dOTable.TableRows)
                {
                    DOTableRow row = new DOTableRow
                    {
                        TableRowGuid = rowList.TableRowGuid,
                        TableRowProperties = rowList.TableRowProperties
                    };

                    foreach (DOTableCell cell in rowList.TableCells)
                    {
                        DOTableCell dOTableCell = new DOTableCell
                        {
                            TableCellGuid = cell.TableCellGuid,
                            TableCellProperties = cell.TableCellProperties
                        };
                        foreach (DOParagraph pa in cell.TableParagraphs)
                        {
                            DOParagraph dOParagraph = new DOParagraph
                            {
                                IDOElementGuid = pa.IDOElementGuid,
                                ParagraphProperties = pa.ParagraphProperties
                            };
                            foreach (DORun doc in pa.ListRuns)
                            {
                                DORun oRun = new DORun
                                {
                                    DORunGuid = doc.DORunGuid,
                                    Properties = doc.Properties
                                };
                                if (doc.Text != null)
                                {
                                    if (doc.Text != oldValue)
                                        Text = doc.Text;

                                    if (doc.Text == oldValue)
                                        oRun.Text = newValue;
                                }
                                dOParagraph.AddRun(oRun);
                            }
                            dOTableCell.AddParagraph(dOParagraph);
                        }
                        row.AddCell(dOTableCell);
                    }
                    table.AddTableRow(row);
                }
                documentTemplate.DocsTableElements.Add(table);
            }
            else
            {
                int newDocsIdx2 = 0;

                foreach (DOTable idoelement in documentTemplate.DocsTableElements)
                {
                    DOTable dOTable2 = new DOTable
                    {
                        TableGrid = idoelement.TableGrid,
                        IDOElementGuid = idoelement.IDOElementGuid,
                        TableProperties = idoelement.TableProperties
                    };
                    foreach (DOTableRow row2 in idoelement.TableRows)
                    {
                        DOTableRow row3 = new DOTableRow
                        {
                            TableRowGuid = row2.TableRowGuid,
                            TableRowProperties = row2.TableRowProperties
                        };
                        foreach (DOTableCell dOTableCell in row2.TableCells)
                        {
                            DOTableCell dOTableCell2 = new DOTableCell
                            {
                                TableCellGuid = dOTableCell.TableCellGuid,
                                TableCellProperties = dOTableCell.TableCellProperties
                            };
                            foreach (DOParagraph dOParagraph in dOTableCell.TableParagraphs)
                            {
                                DOParagraph dOParagraph2 = new DOParagraph
                                {
                                    ParagraphProperties = dOParagraph.ParagraphProperties,
                                    IDOElementGuid = dOParagraph.IDOElementGuid
                                };
                                foreach (DORun dORun2 in dOParagraph.ListRuns)
                                {
                                    DORun dO = new DORun
                                    {
                                        DORunGuid = dORun2.DORunGuid,
                                        Properties = dORun2.Properties
                                    };
                                    if (dORun2.Text != oldValue)
                                        dO.Text = dORun2.Text;

                                    if (dORun2.Text == oldValue)
                                        dO.Text = newValue;
                                    dOParagraph2.AddRun(dO);
                                }
                                dOTableCell2.AddParagraph(dOParagraph2);
                            }
                            row3.AddCell(dOTableCell2);
                        }
                        dOTable2.AddTableRow(row3);
                    }
                    documentTemplate.DocsTableElements[newDocsIdx2] = dOTable2;
                    return;
                }
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
                            DuplicateCount = DuplicateCount -= 1;
                            duplicateLabel.Text = $"Liczba kopii możliwych do zrobienia: {DuplicateCount}";
                            MapDOTableObject(docTable, ref oldV, Box1.Text);
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
            if (textBox1 != null)
            {
                panelNewspaper.Controls.Remove(textBox1);
            }
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
                            Tag = tableParag.IDOElementGuid,
                        };
                        foreach (var tableRun in tableParag.ListRuns)
                        {
                            if(tableRun.Properties._Color != null)
                            {
                                label.ForeColor = tableRun.Properties._Color;
                            }
                            label.Text = tableRun.Text;
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
                if(combo.SelectedItem.ToString().StartsWith("Wiersz"))
                {
                    DOElementContainer.Controls.Clear();

                    var v = idoTuples;

                    var elementGuid = idoTuples.Find(el => el.Item2 == ((DOItem)combo.SelectedItem).itemID);
                    DOParagraph paragraph = DocsParagraphElements.Find((c) => c.IDOElementGuid == elementGuid.Item2);

                    docParag = paragraph;
                    int x = 60;
                    foreach (DORun FindedRun in paragraph.ListRuns)
                        CreateLabel(FindedRun, ref x);
                }
                if (combo.SelectedItem.ToString().StartsWith("Tabela"))
                {
                    DOElementContainer.AutoScroll = true;

                    var tableElementGuid = idoTuples.Find(el2 => el2.Item2 == ((DOItem)combo.SelectedItem).itemID);

                    DOTable tableElement = DocsTableElements.Find(el => el.IDOElementGuid == tableElementGuid.Item2);

                    docTable = tableElement;
                    int tableWidth = tableElement.TableProperties.TableWidth.getCalculateWidth(DOElementContainer.Size.Width);
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
