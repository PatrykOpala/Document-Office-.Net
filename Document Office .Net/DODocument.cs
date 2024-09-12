using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Office.Net
{
    internal struct DODocument
    {
        public DOParagProp ParagraphProperties;
        public bool IsEmpty;
        public Guid IDOElementGuid;
        public string Target;
        public Replaceable Replaceable;
        public List<DORun> listRuns;

        private int tableIndex;
        public DOTableProp TableProperties;
        public DOTableGrid TableGrid;
        private List<DOTableRow> TableRows;

        public DODocument(DocumentFormat.OpenXml.Wordprocessing.Paragraph wordParagraph)
        {
            listRuns = new List<DORun>();
            IsEmpty = true;
            IDOElementGuid = Guid.NewGuid();
            Target = "";
            Replaceable = new Replaceable();

            tableIndex = 0;
            TableProperties = new DOTableProp();
            TableGrid = new DOTableGrid();
            TableRows = new List<DOTableRow>();

            foreach (DocumentFormat.OpenXml.Wordprocessing.Run r in wordParagraph.Elements<DocumentFormat.OpenXml.Wordprocessing.Run>())
            {
                IsEmpty = String.IsNullOrEmpty(r.InnerText);
                IDOElementGuid = Guid.NewGuid();
                listRuns.Add(new DORun(r));
            }
        }

        public DODocument(DocumentFormat.OpenXml.Wordprocessing.Paragraph wordParagraph, DOParagProp paragProp)
        {
            listRuns = new List<DORun>();
            IsEmpty = true;
            IDOElementGuid = Guid.NewGuid();
            Target = "";
            Replaceable = new Replaceable();
            ParagraphProperties = paragProp;

            tableIndex = 0;
            TableProperties = new DOTableProp();
            TableGrid = new DOTableGrid();
            TableRows = new List<DOTableRow>();

            foreach (DocumentFormat.OpenXml.Wordprocessing.Run r in wordParagraph.Elements<DocumentFormat.OpenXml.Wordprocessing.Run>())
            {
                IsEmpty = String.IsNullOrEmpty(r.InnerText);
                IDOElementGuid = Guid.NewGuid();
                listRuns.Add(new DORun(r));
            }
        }

        public DODocument(DocumentFormat.OpenXml.Wordprocessing.Table wordTable)
        {
            listRuns = new List<DORun>();
            IsEmpty = true;
            IDOElementGuid = Guid.NewGuid();
            Target = "";
            Replaceable = new Replaceable();

            tableIndex = 0;
            TableProperties = new DOTableProp();
            TableGrid = new DOTableGrid();
            TableRows = new List<DOTableRow>();

            foreach (DocumentFormat.OpenXml.Wordprocessing.TableProperties tablePro in wordTable.Elements<DocumentFormat.OpenXml.Wordprocessing.TableProperties>())
                TableProperties = new DOTableProp(tablePro);

            foreach (DocumentFormat.OpenXml.Wordprocessing.TableGrid tableGrid in wordTable.Elements<DocumentFormat.OpenXml.Wordprocessing.TableGrid>())
                TableGrid = new DOTableGrid(tableGrid);

            foreach (DocumentFormat.OpenXml.Wordprocessing.TableRow tableRow in wordTable.Elements<DocumentFormat.OpenXml.Wordprocessing.TableRow>())
                TableRows.Add(new DOTableRow(tableRow));
        }
    }

    public struct DOTableProp
    {
        public object BiDiVisual { get; set; }
        public object Shading { get; set; }
        public object TableBorders { get; set; }
        public object TableCaption { get; set; }
        public DOTableCellMarginDefault? TableCellMarginDefault { get; set; }
        public object TableCellSpacing { get; set; }
        public object TableDescription { get; set; }
        public DOTableIndentation? TableIndentation { get; set; }
        public DOTableJustification? TableJustification { get; set; }
        public DOTableLayout? TableLayout { get; set; }
        public object TableLook { get; set; }
        public object TableOverlap { get; set; }
        public object TablePositionProperties { get; set; }
        public object TablePropertiesChange { get; set; }
        public object TableStyle { get; set; }
        public DOTableWidth? TableWidth { get; set; }
        public DOTableProp(DocumentFormat.OpenXml.Wordprocessing.TableProperties tableProperties)
        {
            BiDiVisual = tableProperties.BiDiVisual ?? null;
            Shading = tableProperties.Shading ?? null;
            TableBorders = tableProperties.TableBorders ?? null;
            TableCaption = tableProperties.TableCaption ?? null;
            TableCellMarginDefault = null;
            TableCellSpacing = tableProperties.TableCellSpacing ?? null;
            TableDescription = tableProperties.TableDescription ?? null;
            TableIndentation = null;
            TableJustification = null;
            TableLayout = null;
            TableLook = tableProperties.TableLook ?? null;
            TableOverlap = tableProperties.TableOverlap ?? null;
            TablePositionProperties = tableProperties.TablePositionProperties ?? null;
            TablePropertiesChange = tableProperties.TablePropertiesChange ?? null;
            TableStyle = tableProperties.TableStyle ?? null;
            TableWidth = null;

            if (tableProperties.TableCellMarginDefault != null)
            {
                DOTableCellMarginDefault tableCellMarginDefault = new DOTableCellMarginDefault();
                if (tableProperties.TableCellMarginDefault.BottomMargin != null)
                {
                    DOMargin bottomMargin = new DOMargin();
                    bottomMargin.Unit = tableProperties.TableCellMarginDefault.BottomMargin.Type.InnerText;
                    bottomMargin.BottomMargin = tableProperties.TableCellMarginDefault.BottomMargin.Width.Value;
                    tableCellMarginDefault.Margin = bottomMargin;
                }

                if (tableProperties.TableCellMarginDefault.EndMargin != null)
                {
                    DOMargin endMargin = new DOMargin();
                    endMargin.Unit = tableProperties.TableCellMarginDefault.BottomMargin.Type;
                    endMargin.EndMargin = tableProperties.TableCellMarginDefault.BottomMargin.Width;
                    tableCellMarginDefault.Margin = endMargin;
                }

                if (tableProperties.TableCellMarginDefault.StartMargin != null)
                {
                    DOMargin startMargin = new DOMargin();
                    startMargin.Unit = tableProperties.TableCellMarginDefault.BottomMargin.Type;
                    startMargin.StartMargin = tableProperties.TableCellMarginDefault.BottomMargin.Width;
                    tableCellMarginDefault.Margin = startMargin;

                }

                if (tableProperties.TableCellMarginDefault.TableCellLeftMargin != null)
                {
                    DOMargin tableCellLeftMargin = new DOMargin();
                    tableCellLeftMargin.Unit = tableProperties.TableCellMarginDefault.BottomMargin.Type;
                    tableCellLeftMargin.TableCellLeftMargin = tableProperties.TableCellMarginDefault.BottomMargin.Width;
                    tableCellMarginDefault.Margin = tableCellLeftMargin;

                }

                if (tableProperties.TableCellMarginDefault.TableCellRightMargin != null)
                {
                    DOMargin tableCellRightMargin = new DOMargin();
                    tableCellRightMargin.Unit = tableProperties.TableCellMarginDefault.BottomMargin.Type;
                    tableCellRightMargin.TableCellRightMargin = tableProperties.TableCellMarginDefault.BottomMargin.Width;
                    tableCellMarginDefault.Margin = tableCellRightMargin;

                }

                if (tableProperties.TableCellMarginDefault.TopMargin != null)
                {
                    DOMargin topMargin = new DOMargin();
                    topMargin.Unit = tableProperties.TableCellMarginDefault.BottomMargin.Type;
                    topMargin.TopMargin = tableProperties.TableCellMarginDefault.BottomMargin.Width;
                    tableCellMarginDefault.Margin = topMargin;
                }
                TableCellMarginDefault = tableCellMarginDefault;
            }

            if (tableProperties.TableIndentation != null)
            {
                DOTableIndentation tableIndentation = new DOTableIndentation(tableProperties.TableIndentation);
                TableIndentation = tableIndentation;
            }

            if (tableProperties.TableJustification != null)
            {
                DOTableJustification tableJustification = new DOTableJustification(tableProperties.TableJustification);
                TableJustification = tableJustification;
            }

            if (tableProperties.TableLayout != null)
            {
                DOTableLayout tableLayout = new DOTableLayout(tableProperties.TableLayout);
                TableLayout = tableLayout;
            }

            if (tableProperties.TableWidth != null)
            {
                DOTableWidth tableWidth = new DOTableWidth(tableProperties.TableWidth);
                TableWidth = tableWidth;
            }
        }
    }

    public struct DOTableGrid
    {
        private List<DOGridColumn> GridColumns;
        public DOTableGrid(DocumentFormat.OpenXml.Wordprocessing.TableGrid tableGrid)
        {
            GridColumns = new List<DOGridColumn>();
            foreach (DocumentFormat.OpenXml.Wordprocessing.GridColumn gridColumn in tableGrid.Elements<DocumentFormat.OpenXml.Wordprocessing.GridColumn>())
            {
                DOGridColumn tGridColumn = new DOGridColumn(gridColumn);
                GridColumns.Add(tGridColumn);
            }
        }
    }
    public struct DOGridColumn
    {
        private string _width;
        public string Width { get { return _width; } }

        public DOGridColumn(DocumentFormat.OpenXml.Wordprocessing.GridColumn gridColumn)
        {
            _width = gridColumn.Width;
        }
    }
    public struct DORsid
    {
        //DocumentFormat.OpenXml.HexBinaryValue
        public object ParagraphId { get; set; }
        public object RsidTableRowAddition { get; set; }
        public object RsidTableRowDeletion { get; set; }
        public object RsidTableRowMarkRevision { get; set; }
        public object RsidTableRowProperties { get; set; }
        public object TablePropertyExceptions { get; set; }
        public object TableRowProperties { get; set; }
        public object TextId { get; set; }
    }
    public class DOTableRow
    {
        private object _tableRowProperties;
        public object TableRowProperties { get { return _tableRowProperties; } set { _tableRowProperties = value; } }
        private List<DOTableCell> _tableCells = new List<DOTableCell>();
        public DOTableCell[] TableCells { get { return _tableCells.ToArray(); } }
        private Guid _tableRowGuid;
        public Guid TableRowGuid { get { return _tableRowGuid; } set { _tableRowGuid = value; } }
        public DOTableRow() { }
        public DOTableRow(DocumentFormat.OpenXml.Wordprocessing.TableRow tableRow)
        {
            _tableRowGuid = Guid.NewGuid();

            foreach (DocumentFormat.OpenXml.Wordprocessing.TableRowProperties tableRowProperties in tableRow.Elements<DocumentFormat.OpenXml.Wordprocessing.TableRowProperties>())
                _tableRowProperties = new DOTableRowProp(tableRowProperties);

            foreach (DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell in tableRow.Elements<DocumentFormat.OpenXml.Wordprocessing.TableCell>())
                _tableCells.Add(new DOTableCell(tableCell));
        }
        public void AddCell(DOTableCell cell) => _tableCells.Add(cell);
    }
    public struct DOTableRowProp
    {
        public DOTableRowProp(DocumentFormat.OpenXml.Wordprocessing.TableRowProperties tableRowProperties)
        {

        }
    }
    public class DOTableCell
    {
        private DOTableCellProp _tableCellProperties;
        public DOTableCellProp TableCellProperties { get { return _tableCellProperties; } set { _tableCellProperties = value; } }
        private List<DOParagraph> _tableParagraphs = new List<DOParagraph>();
        public DOParagraph[] TableParagraphs { get { return _tableParagraphs.ToArray(); } }
        private Guid _tableCellGuid;
        public Guid TableCellGuid { get { return _tableCellGuid; } set { _tableCellGuid = value; } }
        public DOTableCell() { }
        public DOTableCell(DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell)
        {
            _tableCellGuid = Guid.NewGuid();
            foreach (DocumentFormat.OpenXml.Wordprocessing.TableCellProperties tCellProp in tableCell.Elements<DocumentFormat.OpenXml.Wordprocessing.TableCellProperties>())
                _tableCellProperties = new DOTableCellProp(tCellProp);
            foreach (DocumentFormat.OpenXml.Wordprocessing.Paragraph TCellParagraph in tableCell.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>())
                _tableParagraphs.Add(new DOParagraph(TCellParagraph));
        }
        public void AddParagraph(DOParagraph paragraph) => _tableParagraphs.Add(paragraph);
    }
    public struct DOTableCellProp
    {
        public object GridSpan { get; set; }
        public object HideMark { get; set; }
        public object HorizontalMerge { get; set; }
        public object NoWrap { get; set; }
        public object Shading { get; set; }
        public DOTableCellBorders? TableCellBorders { get; set; }
        public object TableCellFitText { get; set; }
        public object TableCellMargin { get; set; }
        public object TableCellVerticalAlignment { get; set; }
        public DOTableCellWidth? TableCellWidth { get; set; }
        public object TextDirection { get; set; }
        public object VerticalMerge { get; set; }

        public DOTableCellProp(DocumentFormat.OpenXml.Wordprocessing.TableCellProperties tableCellProperties)
        {
            GridSpan = tableCellProperties.GridSpan;
            HideMark = tableCellProperties.HideMark;
            HorizontalMerge = tableCellProperties.HorizontalMerge;
            NoWrap = tableCellProperties.NoWrap;
            Shading = tableCellProperties.Shading;
            TableCellFitText = tableCellProperties.TableCellFitText;
            TableCellMargin = tableCellProperties.TableCellMargin;
            TableCellVerticalAlignment = tableCellProperties.TableCellVerticalAlignment;
            TextDirection = tableCellProperties.TextDirection;
            VerticalMerge = tableCellProperties.VerticalMerge;
            TableCellBorders = null;
            TableCellWidth = null;

            if (tableCellProperties.TableCellBorders != null)
            {
                DOTableCellBorders tableCellBorders = new DOTableCellBorders(tableCellProperties.TableCellBorders);
                TableCellBorders = tableCellBorders;
            }
            if (tableCellProperties.TableCellWidth != null)
            {
                DOTableCellWidth tableCellWidth = new DOTableCellWidth(tableCellProperties.TableCellWidth);
                TableCellWidth = tableCellWidth;
            }
        }
    }
    public struct DOTableCellBorders
    {
        public DOBottomBorder BottomBorder { get; private set; }
        public DOEndBorder EndBorder { get; private set; }
        public object InsideHorinzontalBorder { get; private set; }
        public object InsideVerticalBorder { get; private set; }
        public DOLeftBorder LeftBorder { get; private set; }
        public DORightBorder RightBorder { get; private set; }
        public DOStartBorder StartBorder { get; private set; }
        public DOTopBorder TopBorder { get; private set; }
        public object TopLeftToBottomRightCellBorder { get; private set; }
        public object TopRightToBottomLeftCellBorder { get; private set; }

        public DOTableCellBorders(DocumentFormat.OpenXml.Wordprocessing.TableCellBorders tableCellBorders)
        {
            BottomBorder = null;
            EndBorder = null;
            InsideHorinzontalBorder = null;
            InsideVerticalBorder = null;
            LeftBorder = null;
            RightBorder = null;
            StartBorder = null;
            TopBorder = null;
            TopLeftToBottomRightCellBorder = null;
            TopRightToBottomLeftCellBorder = null;

            if (tableCellBorders.BottomBorder != null)
            {
                DOBottomBorder bottomBorder = new DOBottomBorder(tableCellBorders.BottomBorder);
                BottomBorder = bottomBorder;
            }
            if (tableCellBorders.EndBorder != null)
            {
                DOEndBorder endBorder = new DOEndBorder(tableCellBorders.EndBorder);
                EndBorder = endBorder;
            }
            if (tableCellBorders.LeftBorder != null)
            {
                DOLeftBorder leftBorder = new DOLeftBorder(tableCellBorders.LeftBorder);
                LeftBorder = leftBorder;
            }
            if (tableCellBorders.RightBorder != null)
            {
                DORightBorder rightBorder = new DORightBorder(tableCellBorders.RightBorder);
                RightBorder = rightBorder;
            }
            if (tableCellBorders.StartBorder != null)
            {
                DOStartBorder startBorder = new DOStartBorder(tableCellBorders.StartBorder);
                StartBorder = startBorder;
            }
            if (tableCellBorders.TopBorder != null)
            {
                DOTopBorder topBorder = new DOTopBorder(tableCellBorders.TopBorder);
                TopBorder = topBorder;
            }
        }
    }
    public struct DOTableCellWidth
    {
        public string Type { get; private set; }
        public string Width { get; private set; }

        public DOTableCellWidth(DocumentFormat.OpenXml.Wordprocessing.TableCellWidth tableCellWidth)
        {
            Type = tableCellWidth.Type;
            Width = tableCellWidth.Width;
        }
    }

    public struct DOTableCellMarginDefault
    {
        public DOMargin Margin { get; set; }
    }

    public struct DOMargin
    {
        public string Unit { get; set; }
        public string BottomMargin { get; set; }
        public string EndMargin { get; set; }
        public string StartMargin { get; set; }
        public string TableCellLeftMargin { get; set; }
        public string TableCellRightMargin { get; set; }
        public string TopMargin { get; set; }
    }

    public struct DOTableIndentation
    {
        public string Unit { get; set; }
        public string Width { get; set; }
        public DOTableIndentation(DocumentFormat.OpenXml.Wordprocessing.TableIndentation tableIndentation)
        {
            Unit = tableIndentation.Type;
            Width = tableIndentation.Width;
        }
    }

    public struct DOTableJustification
    {
        public string Val { get; set; }
        public DOTableJustification(DocumentFormat.OpenXml.Wordprocessing.TableJustification tableJustification)
        {
            Val = tableJustification.Val.Value.ToString();
        }
    }

    public struct DOTableLayout
    {
        public string Type { get; set; }
        public DOTableLayout(DocumentFormat.OpenXml.Wordprocessing.TableLayout tableLayout)
        {
            Type = tableLayout.Type;
        }
    }
    public struct DOTableWidth
    {
        public string Unit { get; set; }
        public string Width { get; set; }

        public DOTableWidth(DocumentFormat.OpenXml.Wordprocessing.TableWidth tableWidth)
        {
            Unit = tableWidth.Type;
            Width = tableWidth.Width;
        }
    }
}
