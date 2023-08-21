using Document_Office.Net.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Document_Office.Net
{
    public class DOTable : IDOElement
    {
        public string Type { get; } = "Table";
        public DOTableProp TableProperties { get; set; }
        public DOTableGrid TableGrid { get; set; }
        private List<DOTableRow> dOTableRows = new List<DOTableRow>();
        public DOTableRow[] TableRows { get { return dOTableRows.ToArray(); } }
        public Guid IDOElementGuid { get; set; }
        public string Target { get; set; }

        private int index = 0;
        public DOTable() { }
        public DOTable(DocumentFormat.OpenXml.Wordprocessing.Table table)
        {
            IDOElementGuid = Guid.NewGuid();

            foreach (DocumentFormat.OpenXml.Wordprocessing.TableProperties tablePro in table.Elements<DocumentFormat.OpenXml.Wordprocessing.TableProperties>())
                TableProperties = new DOTableProp(tablePro);

            foreach (DocumentFormat.OpenXml.Wordprocessing.TableGrid tableGrid in table.Elements<DocumentFormat.OpenXml.Wordprocessing.TableGrid>())
                TableGrid = new DOTableGrid(tableGrid);

            foreach (DocumentFormat.OpenXml.Wordprocessing.TableRow tableRow in table.Elements<DocumentFormat.OpenXml.Wordprocessing.TableRow>())
                dOTableRows.Add(new DOTableRow(tableRow));
            }
        public void AddTableRow(DOTableRow tableRow) => dOTableRows.Add(tableRow);
        public void generateTableUI(NewEditorConcept rootWindow, int startX, int startY)
        {
            Panel Table = new Panel()
            {
                Location = new Point(startX, startY),
                Size = new Size(1175, 40),
                AutoSize = true,
            };

            int x = 46;
            int y = 3;

            foreach(var table_row in this.TableRows)
            {
                this.generateTableRowUI(Table, table_row, ref x, ref y);
            }

            rootWindow.Controls.Add(Table);
        }
        private void generateTableRowUI(Panel table_root, DOTableRow table_row, ref int x, ref int y)
        {
            foreach(var table_grid_columns in this.TableGrid.GridColumns)
            {
                Panel row = new Panel()
                {
                    Location = new Point(x, y),
                    BorderStyle = BorderStyle.FixedSingle,
                    Size = new Size(100, 40),
                    AutoSize = true,
                };
                this.CheckIndex(ref this.index, table_row.TableCells.Length - 1);
                this.generateTableColumnsUI(row, table_row.TableCells[this.index]);
                table_root.Controls.Add(row);
                x += 100;
            }
            y += 40;
            x = 46;
        }
        private void generateTableColumnsUI(Panel table_row_root, DOTableCell table_cell)
        {
            foreach(var tableParag in table_cell.TableParagraphs)
            {
                int xParag = 0;
                int yParag = 0;
                Label label = new Label
                {
                    Location = new Point(xParag + 30, yParag + 10),
                };

                /*
                 foreach (var tableRun in tableParag.ListRuns)
                 {
                     foreach (var tableText in tableRun.ListText)
                     {
                        label.Text = tableText;
                     }
                 }
                 label.Click += new EventHandler(TableEventClick);
                 */

                table_row_root.Controls.Add(label);
            }
        }
        private void CheckIndex(ref int idx, int max_value)
        {
            if (idx >= max_value)
            {
                idx = 0;
            }
            else
            {
                idx++;
            }
        }
    } 
    public class DOTableGrid
    {
        private List<DOGridColumn> dOGridColumns = new List<DOGridColumn>();
        public DOGridColumn[] GridColumns { get { return dOGridColumns.ToArray(); } }
        public DOTableGrid(DocumentFormat.OpenXml.Wordprocessing.TableGrid tableGrid)
        {
            foreach (DocumentFormat.OpenXml.Wordprocessing.GridColumn gridColumn in tableGrid.Elements<DocumentFormat.OpenXml.Wordprocessing.GridColumn>())
            {
                DOGridColumn tGridColumn = new DOGridColumn(gridColumn);
                dOGridColumns.Add(tGridColumn);
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
}
