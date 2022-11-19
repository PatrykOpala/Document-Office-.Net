﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Document_Office.Net.Forms
{
    public partial class EdytorWindow : Form
    {
		// ./WriteDocxObjectToJSON -f='C:\Users\patry\Desktop\test.docx'
        private List<DOElement> ButtonElements = new List<DOElement>();
        private List<DOElement> NewDocsElements = new List<DOElement>();
        private static float FONT_SIZE = 20.0F;
        private ushort NeededCountFile = 0;
        private int x = 60;
        private int rID = 0;
        private string OldValue = "";
        private int RunID = 0;

        public EdytorWindow(string file, ushort countFile)
        {
            InitializeComponent();
            InitializeValues();
            NeededCountFile = countFile;
            OpenDocx(file);
        }

        private void InitializeValues()
        {
            panelNewspaper.Location = new System.Drawing.Point((int)(panelEdytor.Size.Width / 4), (int)(panelEdytor.Size.Height / 7));
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
                        ButtonElements.Add(ReturnParagraph((Paragraph)bd, w));
                        w++;
                    }
                    if (bd.LocalName == "tbl")
                    {
                        ButtonElements.Add(ReturnTable((Table)bd, w));
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
                            foreach (string str in run.Text)
                            {
                                 label += str;
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

        private void ParseOldObjectReturnedNewObject(string id, string text)
        {

        }

        private DOParagraph ReturnParagraph(DocumentFormat.OpenXml.Wordprocessing.Paragraph b, int doID)
        {
            DOParagraph paragraph = new DOParagraph(doID);
            List<DORun> rune = new List<DORun>();
            foreach (DocumentFormat.OpenXml.Wordprocessing.Run r in b.Elements<DocumentFormat.OpenXml.Wordprocessing.Run>())
            {
                DORun run = new DORun();
                List<string> list1 = new List<string>();
                List<DORunProp> props = new List<DORunProp>();
                foreach (DocumentFormat.OpenXml.Wordprocessing.RunProperties rProp in r.Elements<DocumentFormat.OpenXml.Wordprocessing.RunProperties>())
                {
                    props.Add(CreateRunPropFromRunProperties(rProp));
                }
                run.Properties = props.ToArray();

                foreach (DocumentFormat.OpenXml.Wordprocessing.Text rText in r.Elements<DocumentFormat.OpenXml.Wordprocessing.Text>())
                {
                    list1.Add(rText.Text);
                }
                run.Text = list1.ToArray();
                rID += doID + 1;
                run.DORunID = rID;
                rune.Add(run);
            }
            paragraph.Arrayruns = rune.ToArray();
            return paragraph;
        }

        private DOTable ReturnTable(DocumentFormat.OpenXml.Wordprocessing.Table table, int doID)
        {
            DOTable T = new DOTable(doID);
            foreach (DocumentFormat.OpenXml.Wordprocessing.TableProperties tablePro in table.Elements<DocumentFormat.OpenXml.Wordprocessing.TableProperties>())
            {
                DOTableProp TProp = new DOTableProp();
                if (tablePro.BiDiVisual != null)
                {
                    TProp.BiDiVisual = tablePro.BiDiVisual;
                }

                if (tablePro.Shading != null)
                {
                    TProp.Shading = tablePro.Shading;
                }

                if (tablePro.TableBorders != null)
                {
                    TProp.TableBorders = tablePro.TableBorders;
                }

                if (tablePro.TableCaption != null)
                {
                    TProp.TableCaption = tablePro.TableCaption;
                }

                if (tablePro.TableCellMarginDefault != null)
                {
                    DOTableCellMarginDefault tableCellMarginDefault = new DOTableCellMarginDefault();
                    if (tablePro.TableCellMarginDefault.BottomMargin != null)
                    {
                        DOBottomMargin bottomMargin = new DOBottomMargin();
                        bottomMargin.Type = tablePro.TableCellMarginDefault.BottomMargin.Type.InnerText;
                        bottomMargin.Width = tablePro.TableCellMarginDefault.BottomMargin.Width.Value;
                        tableCellMarginDefault.BottomMargin = bottomMargin;

                    }

                    if (tablePro.TableCellMarginDefault.EndMargin != null)
                    {
                        DOEndMargin endMargin = new DOEndMargin();
                        endMargin.Type = tablePro.TableCellMarginDefault.BottomMargin.Type;
                        endMargin.Width = tablePro.TableCellMarginDefault.BottomMargin.Width;
                        tableCellMarginDefault.EndMargin = endMargin;

                    }

                    if (tablePro.TableCellMarginDefault.StartMargin != null)
                    {
                        DOStartMargin startMargin = new DOStartMargin();
                        startMargin.Type = tablePro.TableCellMarginDefault.BottomMargin.Type;
                        startMargin.Width = tablePro.TableCellMarginDefault.BottomMargin.Width;
                        tableCellMarginDefault.StartMargin = startMargin;

                    }

                    if (tablePro.TableCellMarginDefault.TableCellLeftMargin != null)
                    {
                        DOTableCellLeftMargin tableCellLeftMargin = new DOTableCellLeftMargin();
                        tableCellLeftMargin.Type = tablePro.TableCellMarginDefault.BottomMargin.Type;
                        tableCellLeftMargin.Width = tablePro.TableCellMarginDefault.BottomMargin.Width;
                        tableCellMarginDefault.TableCellLeftMargin = tableCellLeftMargin;

                    }

                    if (tablePro.TableCellMarginDefault.TableCellRightMargin != null)
                    {
                        DOTableCellRightMargin tableCellRightMargin = new DOTableCellRightMargin();
                        tableCellRightMargin.Type = tablePro.TableCellMarginDefault.BottomMargin.Type;
                        tableCellRightMargin.Width = tablePro.TableCellMarginDefault.BottomMargin.Width;
                        tableCellMarginDefault.TableCellRightMargin = tableCellRightMargin;

                    }

                    if (tablePro.TableCellMarginDefault.TopMargin != null)
                    {
                        DOTopMargin topMargin = new DOTopMargin();
                        topMargin.Type = tablePro.TableCellMarginDefault.BottomMargin.Type;
                        topMargin.Width = tablePro.TableCellMarginDefault.BottomMargin.Width;
                        tableCellMarginDefault.TopMargin = topMargin;

                    }
                    TProp.TableCellMarginDefault = tableCellMarginDefault;
                }

                if (tablePro.TableCellSpacing != null)
                {
                    TProp.TableCellSpacing = tablePro.TableCellSpacing;
                }

                if (tablePro.TableDescription != null)
                {
                    TProp.TableDescription = tablePro.TableDescription;
                }

                if (tablePro.TableIndentation != null)
                {
                    DOTableIndentation tableIndentation = new DOTableIndentation();
                    tableIndentation.Type = tablePro.TableIndentation.Type;
                    tableIndentation.Width = tablePro.TableIndentation.Width;
                    TProp.TableIndentation = tableIndentation;
                }

                if (tablePro.TableJustification != null)
                {
                    DOTableJustification tableJustification = new DOTableJustification();
                    tableJustification.Val = tablePro.TableJustification.Val.Value.ToString();
                    TProp.TableJustification = tableJustification;
                }

                if (tablePro.TableLayout != null)
                {
                    DOTableLayout tableLayout = new DOTableLayout();
                    tableLayout.Type = tablePro.TableLayout.Type;
                    TProp.TableLayout = tableLayout;
                }

                if (tablePro.TableLook != null)
                {
                    TProp.TableLook = tablePro.TableLook;
                }

                if (tablePro.TableOverlap != null)
                {
                    TProp.TableOverlap = tablePro.TableOverlap;
                }

                if (tablePro.TablePositionProperties != null)
                {
                    TProp.TablePositionProperties = tablePro.TablePositionProperties;
                }

                if (tablePro.TablePropertiesChange != null)
                {
                    TProp.TablePropertiesChange = tablePro.TablePropertiesChange;
                }

                if (tablePro.TableStyle != null)
                {
                    TProp.TableStyle = tablePro.TableStyle;
                }

                if (tablePro.TableWidth != null)
                {
                    DOTableWidth tableWidth = new DOTableWidth();
                    tableWidth.Type = tablePro.TableWidth.Type;
                    tableWidth.Width = tablePro.TableWidth.Width;
                    TProp.TableWidth = tableWidth;
                }
                T.TableProperties = TProp;
            }

            foreach (DocumentFormat.OpenXml.Wordprocessing.TableGrid tableGrid in table.Elements<DocumentFormat.OpenXml.Wordprocessing.TableGrid>())
            {
                DOTableGrid TGrid = new DOTableGrid();
                List<DOGridColumn> listsGColumn = new List<DOGridColumn>();

                foreach (DocumentFormat.OpenXml.Wordprocessing.GridColumn gridColumn in tableGrid.Elements<DocumentFormat.OpenXml.Wordprocessing.GridColumn>())
                {
                    DOGridColumn tGridColumn = new DOGridColumn();
                    tGridColumn.Width = gridColumn.Width;
                    listsGColumn.Add(tGridColumn);
                }
                TGrid.GridColumns = listsGColumn.ToArray();
                T.TableGrid = TGrid;
            }

            List<DOTableRow> tableRows = new List<DOTableRow>();

            foreach (DocumentFormat.OpenXml.Wordprocessing.TableRow tableRow in table.Elements<DocumentFormat.OpenXml.Wordprocessing.TableRow>())
            {
                DOTableRow TRow = new DOTableRow();

                foreach (DocumentFormat.OpenXml.Wordprocessing.TableRowProperties tableRowProperties in tableRow.Elements<DocumentFormat.OpenXml.Wordprocessing.TableRowProperties>())
                {
                    DOTableRowProp TRowProp = new DOTableRowProp();
                    TRow.TableRowProperties = TRowProp;
                }

                List<DOTableCell> tableCells = new List<DOTableCell>();

                foreach (DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell in tableRow.Elements<DocumentFormat.OpenXml.Wordprocessing.TableCell>())
                {
                    DOTableCell TCell = new DOTableCell();

                    foreach (DocumentFormat.OpenXml.Wordprocessing.TableCellProperties tCellProp in tableCell.Elements<DocumentFormat.OpenXml.Wordprocessing.TableCellProperties>())
                    {
                        DOTableCellProp tCellProperties = new DOTableCellProp();
                        tCellProperties.GridSpan = tCellProp.GridSpan;
                        tCellProperties.HideMark = tCellProp.HideMark;
                        tCellProperties.HorizontalMerge = tCellProp.HorizontalMerge;
                        tCellProperties.NoWrap = tCellProp.NoWrap;
                        tCellProperties.Shading = tCellProp.Shading;
                        if (tCellProp.TableCellBorders != null)
                        {
                            DOTableCellBorders tableCellBorders = new DOTableCellBorders();
                            if (tCellProp.TableCellBorders.BottomBorder != null)
                            {
                                DOBottomBorder bottomBorder = new DOBottomBorder();
                                bottomBorder.Color = tCellProp.TableCellBorders.BottomBorder.Color;
                                bottomBorder.Frame = tCellProp.TableCellBorders.BottomBorder.Frame;
                                bottomBorder.Shadow = tCellProp.TableCellBorders.BottomBorder.Shadow;
                                bottomBorder.Size = tCellProp.TableCellBorders.BottomBorder.Size;
                                bottomBorder.Space = tCellProp.TableCellBorders.BottomBorder.Space;
                                bottomBorder.ThemeColor = tCellProp.TableCellBorders.BottomBorder.ThemeColor;
                                bottomBorder.ThemeShade = tCellProp.TableCellBorders.BottomBorder.ThemeShade;
                                bottomBorder.ThemeTint = tCellProp.TableCellBorders.BottomBorder.ThemeTint;
                                bottomBorder.Val = tCellProp.TableCellBorders.BottomBorder.Val.InnerText;
                                tableCellBorders.BottomBorder = bottomBorder;
                            }
                            if (tCellProp.TableCellBorders.EndBorder != null)
                            {
                                DOEndBorder endBorder = new DOEndBorder();
                                endBorder.Color = tCellProp.TableCellBorders.EndBorder.Color;
                                endBorder.Frame = tCellProp.TableCellBorders.EndBorder.Frame;
                                endBorder.Shadow = tCellProp.TableCellBorders.EndBorder.Shadow;
                                endBorder.Size = tCellProp.TableCellBorders.EndBorder.Size;
                                endBorder.Space = tCellProp.TableCellBorders.EndBorder.Space;
                                endBorder.ThemeColor = tCellProp.TableCellBorders.EndBorder.ThemeColor;
                                endBorder.ThemeShade = tCellProp.TableCellBorders.EndBorder.ThemeShade;
                                endBorder.ThemeTint = tCellProp.TableCellBorders.EndBorder.ThemeTint;
                                endBorder.Val = tCellProp.TableCellBorders.EndBorder.Val.InnerText;
                                tableCellBorders.EndBorder = endBorder;
                            }
                            if (tCellProp.TableCellBorders.LeftBorder != null)
                            {
                                DOLeftBorder leftBorder = new DOLeftBorder();
                                leftBorder.Color = tCellProp.TableCellBorders.LeftBorder.Color;
                                leftBorder.Frame = tCellProp.TableCellBorders.LeftBorder.Frame;
                                leftBorder.Shadow = tCellProp.TableCellBorders.LeftBorder.Shadow;
                                leftBorder.Size = tCellProp.TableCellBorders.LeftBorder.Size;
                                leftBorder.Space = tCellProp.TableCellBorders.LeftBorder.Space;
                                leftBorder.ThemeColor = tCellProp.TableCellBorders.LeftBorder.ThemeColor;
                                leftBorder.ThemeShade = tCellProp.TableCellBorders.LeftBorder.ThemeShade;
                                leftBorder.ThemeTint = tCellProp.TableCellBorders.LeftBorder.ThemeTint;
                                leftBorder.Val = tCellProp.TableCellBorders.LeftBorder.Val.InnerText;
                                tableCellBorders.LeftBorder = leftBorder;
                            }
                            if (tCellProp.TableCellBorders.RightBorder != null)
                            {
                                DORightBorder rightBorder = new DORightBorder();
                                rightBorder.Color = tCellProp.TableCellBorders.RightBorder.Color;
                                rightBorder.Frame = tCellProp.TableCellBorders.RightBorder.Frame;
                                rightBorder.Shadow = tCellProp.TableCellBorders.RightBorder.Shadow;
                                rightBorder.Size = tCellProp.TableCellBorders.RightBorder.Size;
                                rightBorder.Space = tCellProp.TableCellBorders.RightBorder.Space;
                                rightBorder.ThemeColor = tCellProp.TableCellBorders.RightBorder.ThemeColor;
                                rightBorder.ThemeShade = tCellProp.TableCellBorders.RightBorder.ThemeShade;
                                rightBorder.ThemeTint = tCellProp.TableCellBorders.RightBorder.ThemeTint;
                                rightBorder.Val = tCellProp.TableCellBorders.RightBorder.Val.InnerText;
                                tableCellBorders.RightBorder = rightBorder;
                            }
                            if (tCellProp.TableCellBorders.StartBorder != null)
                            {
                                DOStartBorder startBorder = new DOStartBorder();
                                startBorder.Color = tCellProp.TableCellBorders.StartBorder.Color;
                                startBorder.Frame = tCellProp.TableCellBorders.StartBorder.Frame;
                                startBorder.Shadow = tCellProp.TableCellBorders.StartBorder.Shadow;
                                startBorder.Size = tCellProp.TableCellBorders.StartBorder.Size;
                                startBorder.Space = tCellProp.TableCellBorders.StartBorder.Space;
                                startBorder.ThemeColor = tCellProp.TableCellBorders.StartBorder.ThemeColor;
                                startBorder.ThemeShade = tCellProp.TableCellBorders.StartBorder.ThemeShade;
                                startBorder.ThemeTint = tCellProp.TableCellBorders.StartBorder.ThemeTint;
                                startBorder.Val = tCellProp.TableCellBorders.StartBorder.Val.InnerText;
                                tableCellBorders.StartBorder = startBorder;
                            }
                            if (tCellProp.TableCellBorders.TopBorder != null)
                            {
                                DOTopBorder topBorder = new DOTopBorder();
                                topBorder.Color = tCellProp.TableCellBorders.TopBorder.Color;
                                topBorder.Frame = tCellProp.TableCellBorders.TopBorder.Frame;
                                topBorder.Shadow = tCellProp.TableCellBorders.TopBorder.Shadow;
                                topBorder.Size = tCellProp.TableCellBorders.TopBorder.Size;
                                topBorder.Space = tCellProp.TableCellBorders.TopBorder.Space;
                                topBorder.ThemeColor = tCellProp.TableCellBorders.TopBorder.ThemeColor;
                                topBorder.ThemeShade = tCellProp.TableCellBorders.TopBorder.ThemeShade;
                                topBorder.ThemeTint = tCellProp.TableCellBorders.TopBorder.ThemeTint;
                                topBorder.Val = tCellProp.TableCellBorders.TopBorder.Val.InnerText;
                                tableCellBorders.TopBorder = topBorder;
                            }
                            tCellProperties.TableCellBorders = tableCellBorders;
                        }
                        tCellProperties.TableCellFitText = tCellProp.TableCellFitText;
                        tCellProperties.TableCellMargin = tCellProp.TableCellMargin;
                        tCellProperties.TableCellVerticalAlignment = tCellProp.TableCellVerticalAlignment;
                        if (tCellProp.TableCellWidth != null)
                        {
                            DOTableCellWidth tableCellWidth = new DOTableCellWidth();
                            tableCellWidth.Type = tCellProp.TableCellWidth.Type;
                            tableCellWidth.Width = tCellProp.TableCellWidth.Width;
                            tCellProperties.TableCellWidth = tableCellWidth;

                        }
                        tCellProperties.TextDirection = tCellProp.TextDirection;
                        tCellProperties.VerticalMerge = tCellProp.VerticalMerge;
                        TCell.TableCellProperties = tCellProperties;
                    }
                    List<DOParagraph> TableParagraph = new List<DOParagraph>();

                    foreach (DocumentFormat.OpenXml.Wordprocessing.Paragraph TCellParagraph in tableCell.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>())
                    {
                        TableParagraph.Add(ReturnParagraph(TCellParagraph, doID));
                    }
                    TCell.TableParagraphs = TableParagraph.ToArray();
                    tableCells.Add(TCell);
                }
                TRow.TableCells = tableCells.ToArray();
                tableRows.Add(TRow);
            }

            T.TableRowArray = tableRows.ToArray();
            return T;
        }

        private DORunProp CreateRunPropFromRunProperties(RunProperties runProperties)
        {
            DORunProp rPro = new DORunProp();
            /*
            rPro.Border = false;
            rPro.Caps = false;
            rPro.CharakterScale = true;
            rPro.ComplexScript = false;
            rPro.NumberSpacing = false;
            rPro.Outline = false;
            rPro.SmallCaps = false;
            rPro.Spacing = false;
            */

            if (runProperties.Bold != null && runProperties.BoldComplexScript != null)
            {
                rPro.Bold = true;
                rPro.BoldComplexScript = true;
            }

            if(runProperties.FontSize != null)
            {
                rPro.FontSize = runProperties.FontSize.Val.Value;
            }

            if (runProperties.Color != null)
            {
                rPro._Color = ColorTranslator.FromHtml("#" + runProperties.Color.Val);
            }

            if (runProperties.Italic != null && runProperties.ItalicComplexScript != null)
            {
                rPro.Italic = true;
                rPro.ItalicComplexScript = true;
            }

            if (runProperties.Strike != null)
            {
                rPro.Strike = true;
            }

            if (runProperties.Underline != null)
            {
                rPro.Underline = runProperties.Underline.Val;
            }

            /*rPro.Bold = runProperties.Bold;
            rPro.BoldComplexScript = runProperties.BoldComplexScript;
            rPro.Border = runProperties.Border;
            rPro.Caps = runProperties.Caps;
            rPro.CharakterScale = runProperties.CharacterScale;
            rPro._Color = runProperties.Color;
            rPro.ComplexScript = runProperties.ComplexScript;
            rPro.NumberSpacing = runProperties.NumberSpacing;
            rPro.Outline = runProperties.Outline;
            rPro.SmallCaps = runProperties.SmallCaps;
            rPro.Spacing = runProperties.Spacing;*/

            return rPro;
        }

        private void LabelRun_Event_Click(object sender, EventArgs e)
        {
            Label label = (Label)sender;

            OldValue = label.Text;
            RunID = int.Parse(label.Tag.ToString());

            string NewValue = "";

            int pNewsWidth = (int)(panelNewspaper.Size.Width / 1.2) + 10;
            int pNewsHeight = (int)(panelNewspaper.Size.Height / 1.5);

            TextBox textBox = new TextBox()
            {
                Size = new Size(pNewsWidth, 70),
                Location = new Point(59, pNewsHeight),
                Text = "PlaceHolder",
                Font = new System.Drawing.Font("Microsoft Sans Serif", FONT_SIZE, FontStyle.Regular,
                        GraphicsUnit.Point, ((byte)(238))),
            };

            textBox.KeyDown += new KeyEventHandler((object keySender, KeyEventArgs keyArgs) =>
            {
                var enter = keyArgs;
                TextBox Box1 = (TextBox)keySender;

                if(keyArgs.KeyValue == 13)
                {
                    keyArgs.SuppressKeyPress = true;
                    NewValue = Box1.Text;
                    Box1.Text = "";
                }
            }
            );

            panelNewspaper.Controls.Add(textBox);
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
        
            /*LabelRun.Location = new Point(x, 141);
            LabelRun.BorderStyle = BorderStyle.FixedSingle;
            LabelRun.Cursor = Cursors.Hand;
            LabelRun.AutoSize = true;
            LabelRun.Tag = FindedRun.DORunID;*/
            LabelRun.Click += new System.EventHandler(this.LabelRun_Event_Click);
            foreach (DORunProp p in FindedRun.Properties)
            {
                if (p.FontSize != null)
                {
                    LabelRun.Font = new System.Drawing.Font("Microsoft Sans Serif", float.Parse(p.FontSize), System.Drawing.FontStyle.Regular,
                        System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                }
            }
            foreach (string FindedStr in FindedRun.Text)
            {
                LabelRun.Text = FindedStr;
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
                foreach(DORun FindedRun in element.Arrayruns)
                {
                   x = CreateLabel(FindedRun, x);
                }
            }
        }
    }
}
