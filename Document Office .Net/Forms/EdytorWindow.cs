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
        private static float FONT_SIZE = 20.0F;
        private ushort NeededCountFile = 0;
        private ushort DuplicateCount = 0;
        private int ParagraphID = 0;
        private int x = 60;
        private int rID = 0;
        private int RunID = 0;
        private string FileFullName = "";
        private string DocumentTmpName = "";

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
            ButtonElementsCopy = ButtonElements;
            DOParagraph FindParagraph = (DOParagraph)ButtonElementsCopy.Find(el => el.DOID == ParagraphID);
            int Index = ButtonElementsCopy.FindIndex(ee => ee.DOID == ParagraphID);
            for(int inter = 0; inter < FindParagraph.Arrayruns.Rank; inter++)
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
            var nu = ButtonElementsCopy;
        }

        private DOParagraph ReturnParagraph(Paragraph b, int doID)
        {
            DOParagraph paragraph = new DOParagraph(doID);
            List<DORun> rune = new List<DORun>();
            //ReturnParagraphProperties(b.ParagraphProperties, paragraph);
            foreach (DocumentFormat.OpenXml.Wordprocessing.Run r in b.Elements<DocumentFormat.OpenXml.Wordprocessing.Run>())
            {
                DORun run = new DORun();
                List<DOText> list1 = new List<DOText>();
                DORunProp props = CreateRunPropFromRunProperties(r.RunProperties);
                run.Properties = props;

                foreach (Text rText in r.Elements<DocumentFormat.OpenXml.Wordprocessing.Text>())
                {
                    DOText DOtext = new DOText()
                    {
                        Value = rText.Text
                    };
                    run.ListText.Add(DOtext);
                    list1.Add(DOtext);
                }
                run.Text = list1.ToArray();
                rID += doID + 1;
                run.DORunID = rID;
                paragraph.ListRuns.Add(run);
                rune.Add(run);
            }
            paragraph.Arrayruns = rune.ToArray();
            return paragraph;
        }

        private void ReturnParagraphProperties(ParagraphProperties paragraphProperties, DOParagraph dOParagraph)
        {

        }

        private DOTable ReturnTable(Table table, int doID)
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
            return rPro;
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

            DODocumentTemplate dODocumentTemplate = new DODocumentTemplate();
            string DocTmpName = $"{DocumentTmpName} {t}";
            DocTmpName += Path.GetExtension(FileFullName);
            dODocumentTemplate.NameDocument = DocTmpName;
            dODocumentTemplate.FullPathWithFileName = Path.GetDirectoryName(FileFullName);
            DOParagraph dOParagraph = new DOParagraph();
            DORun FindedRun = docParag.ListRuns.Find(runn => runn.DORunID == RunID);

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

                foreach(DOText oText in doc.Text)
                {
                    if(oText.Value != oldV)
                    {
                        DOText oText1 = new DOText();
                        oText1.Value = oText.Value;
                        oRun.ListText.Add(oText1);
                    }

                    if(oText.Value == oldV)
                    {
                        DOText oText1 = new DOText();
                        oText1.Value = newValue;
                        oRun.ListText.Add(oText1);
                    }
                }
                dOParagraph.ListRuns.Add(oRun);
            }
            dODocumentTemplate.NewDocsElements.Add(dOParagraph);
            temp.Add(dODocumentTemplate);
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
            
            foreach (DOText FindedStr in FindedRun.Text)
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
                foreach (DORun FindedRun in element.Arrayruns)
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
