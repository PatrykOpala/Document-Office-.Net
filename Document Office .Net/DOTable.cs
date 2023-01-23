﻿using System.Collections.Generic;

namespace Document_Office.Net
{
    public class DOTable : DOElement
    {
        public string Name { get; set; } = "Table";
        public DOTableProp TableProperties { get; set; }
        public DOTableGrid TableGrid { get; set; }
        public List<DOTableRow> TableRowList = new List<DOTableRow>();

        public DOTable(DocumentFormat.OpenXml.Wordprocessing.Table table, int id)
        {
            base.DOID = id;
            foreach (DocumentFormat.OpenXml.Wordprocessing.TableProperties tablePro in table.Elements<DocumentFormat.OpenXml.Wordprocessing.TableProperties>())
            {
                DOTableProp TProp = new DOTableProp(tablePro);
                TableProperties = TProp;
            }

            foreach (DocumentFormat.OpenXml.Wordprocessing.TableGrid tableGrid in table.Elements<DocumentFormat.OpenXml.Wordprocessing.TableGrid>())
            {
                DOTableGrid TGrid = new DOTableGrid(tableGrid);
                TableGrid = TGrid;
            }

            foreach (DocumentFormat.OpenXml.Wordprocessing.TableRow tableRow in table.Elements<DocumentFormat.OpenXml.Wordprocessing.TableRow>())
            {
                DOTableRow TRow = new DOTableRow(tableRow, id);
                TableRowList.Add(TRow);
            }
        }
    }

    public class DOTableProp
    {
        public object BiDiVisual { get; set; }
        public object Shading { get; set; }
        public object TableBorders { get; set; }
        public object TableCaption { get; set; }
        public DOTableCellMarginDefault TableCellMarginDefault { get; set; }
        public object TableCellSpacing { get; set; }
        public object TableDescription { get; set; }
        public DOTableIndentation TableIndentation { get; set; }
        public DOTableJustification TableJustification { get; set; }
        public DOTableLayout TableLayout { get; set; }
        public object TableLook { get; set; }
        public object TableOverlap { get; set; }
        public object TablePositionProperties { get; set; }
        public object TablePropertiesChange { get; set; }
        public object TableStyle { get; set; }
        public DOTableWidth TableWidth { get; set; }

        public DOTableProp() {}
        public DOTableProp(DocumentFormat.OpenXml.Wordprocessing.TableProperties tableProperties)
        {
            if (tableProperties.BiDiVisual != null)
            {
                BiDiVisual = tableProperties.BiDiVisual;
            }

            if (tableProperties.Shading != null)
            {
                Shading = tableProperties.Shading;
            }

            if (tableProperties.TableBorders != null)
            {
                TableBorders = tableProperties.TableBorders;
            }

            if (tableProperties.TableCaption != null)
            {
                TableCaption = tableProperties.TableCaption;
            }

            if (tableProperties.TableCellMarginDefault != null)
            {
                DOTableCellMarginDefault tableCellMarginDefault = new DOTableCellMarginDefault();
                if (tableProperties.TableCellMarginDefault.BottomMargin != null)
                {
                    DOBottomMargin bottomMargin = new DOBottomMargin();
                    bottomMargin.Type = tableProperties.TableCellMarginDefault.BottomMargin.Type.InnerText;
                    bottomMargin.Width = tableProperties.TableCellMarginDefault.BottomMargin.Width.Value;
                    tableCellMarginDefault.BottomMargin = bottomMargin;
                }

                if (tableProperties.TableCellMarginDefault.EndMargin != null)
                {
                    DOEndMargin endMargin = new DOEndMargin();
                    endMargin.Type = tableProperties.TableCellMarginDefault.BottomMargin.Type;
                    endMargin.Width = tableProperties.TableCellMarginDefault.BottomMargin.Width;
                    tableCellMarginDefault.EndMargin = endMargin;
                }

                if (tableProperties.TableCellMarginDefault.StartMargin != null)
                {
                    DOStartMargin startMargin = new DOStartMargin();
                    startMargin.Type = tableProperties.TableCellMarginDefault.BottomMargin.Type;
                    startMargin.Width = tableProperties.TableCellMarginDefault.BottomMargin.Width;
                    tableCellMarginDefault.StartMargin = startMargin;

                }

                if (tableProperties.TableCellMarginDefault.TableCellLeftMargin != null)
                {
                    DOTableCellLeftMargin tableCellLeftMargin = new DOTableCellLeftMargin();
                    tableCellLeftMargin.Type = tableProperties.TableCellMarginDefault.BottomMargin.Type;
                    tableCellLeftMargin.Width = tableProperties.TableCellMarginDefault.BottomMargin.Width;
                    tableCellMarginDefault.TableCellLeftMargin = tableCellLeftMargin;

                }

                if (tableProperties.TableCellMarginDefault.TableCellRightMargin != null)
                {
                    DOTableCellRightMargin tableCellRightMargin = new DOTableCellRightMargin();
                    tableCellRightMargin.Type = tableProperties.TableCellMarginDefault.BottomMargin.Type;
                    tableCellRightMargin.Width = tableProperties.TableCellMarginDefault.BottomMargin.Width;
                    tableCellMarginDefault.TableCellRightMargin = tableCellRightMargin;

                }

                if (tableProperties.TableCellMarginDefault.TopMargin != null)
                {
                    DOTopMargin topMargin = new DOTopMargin();
                    topMargin.Type = tableProperties.TableCellMarginDefault.BottomMargin.Type;
                    topMargin.Width = tableProperties.TableCellMarginDefault.BottomMargin.Width;
                    tableCellMarginDefault.TopMargin = topMargin;
                }
                TableCellMarginDefault = tableCellMarginDefault;
            }

            if (tableProperties.TableCellSpacing != null)
            {
                TableCellSpacing = tableProperties.TableCellSpacing;
            }

            if (tableProperties.TableDescription != null)
            {
                TableDescription = tableProperties.TableDescription;
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

            if (tableProperties.TableLook != null)
            {
                TableLook = tableProperties.TableLook;
            }

            if (tableProperties.TableOverlap != null)
            {
                TableOverlap = tableProperties.TableOverlap;
            }

            if (tableProperties.TablePositionProperties != null)
            {
                TablePositionProperties = tableProperties.TablePositionProperties;
            }

            if (tableProperties.TablePropertiesChange != null)
            {
                TablePropertiesChange = tableProperties.TablePropertiesChange;
            }

            if (tableProperties.TableStyle != null)
            {
                TableStyle = tableProperties.TableStyle;
            }

            if (tableProperties.TableWidth != null)
            {
                DOTableWidth tableWidth = new DOTableWidth(tableProperties.TableWidth);
                TableWidth = tableWidth;
            }
        }
    }

    public class DOTableGrid
    {
        public List<DOGridColumn> GridColumns { get; set; }
        public DOTableGrid(DocumentFormat.OpenXml.Wordprocessing.TableGrid tableGrid)
        {
            foreach (DocumentFormat.OpenXml.Wordprocessing.GridColumn gridColumn in tableGrid.Elements<DocumentFormat.OpenXml.Wordprocessing.GridColumn>())
            {
                DOGridColumn tGridColumn = new DOGridColumn(gridColumn);
                GridColumns.Add(tGridColumn);
            }
        }
    }

    public class DOGridColumn
    {
        public string Width { get; set; }

        public DOGridColumn(DocumentFormat.OpenXml.Wordprocessing.GridColumn gridColumn)
        {
            Width = gridColumn.Width;
        }
    }

    public class DORsid
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
        public object TableRowProperties { get; set; }
        public List<DOTableCell> TableCells = new List<DOTableCell>();
        public DOTableRow(){}

        public DOTableRow(DocumentFormat.OpenXml.Wordprocessing.TableRow tableRow, int doID)
        {
            foreach (DocumentFormat.OpenXml.Wordprocessing.TableRowProperties tableRowProperties in tableRow.Elements<DocumentFormat.OpenXml.Wordprocessing.TableRowProperties>())
            {
                DOTableRowProp TRowProp = new DOTableRowProp(tableRowProperties);
                TableRowProperties = TRowProp;
            }

            foreach (DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell in tableRow.Elements<DocumentFormat.OpenXml.Wordprocessing.TableCell>())
            {
                DOTableCell TCell = new DOTableCell(tableCell, doID);
                TableCells.Add(TCell);
            }
        }
    }

    public class DOTableRowProp 
    {
        public DOTableRowProp(DocumentFormat.OpenXml.Wordprocessing.TableRowProperties)
        {

        }
    }

    public class DOTableCell
    {
        public DOTableCellProp TableCellProperties { get; set; }
        public List<DOParagraph> TableParagraphs { get; set; }

        public DOTableCell(DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell, int d)
        {
            foreach (DocumentFormat.OpenXml.Wordprocessing.TableCellProperties tCellProp in tableCell.Elements<DocumentFormat.OpenXml.Wordprocessing.TableCellProperties>())
            {
                DOTableCellProp tCellProperties = new DOTableCellProp(tCellProp);
               
                if (tCellProp.TableCellBorders != null)
                {
                    DOTableCellBorders tableCellBorders = new DOTableCellBorders(tCellProp.TableCellBorders);
                    tCellProperties.TableCellBorders = tableCellBorders;
                }
                if (tCellProp.TableCellWidth != null)
                {
                    DOTableCellWidth tableCellWidth = new DOTableCellWidth(tCellProp.TableCellWidth);
                    tCellProperties.TableCellWidth = tableCellWidth;
                }
                TableCellProperties = tCellProperties;
            }
            foreach (DocumentFormat.OpenXml.Wordprocessing.Paragraph TCellParagraph in tableCell.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>())
            {
                DOParagraph paer = new DOParagraph(TCellParagraph, d);
                TableParagraphs.Add(paer);
            }
        }
    }

    public class DOTableCellProp
    {
        public object GridSpan { get; set; }
        public object HideMark { get; set; }
        public object HorizontalMerge { get; set; }
        public object NoWrap { get; set; }
        public object Shading { get; set; }

        public DOTableCellBorders TableCellBorders { get; set; }
        public object TableCellFitText { get; set; }
        public object TableCellMargin { get; set; }
        public object TableCellVerticalAlignment { get; set; }
        public DOTableCellWidth TableCellWidth { get; set; }
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
        }
    }

    public class DOTableCellBorders
    {
        public DOBottomBorder BottomBorder { get; set; }
        public DOEndBorder EndBorder { get; set; }
        public object InsideHorinzontalBorder { get; set; }
        public object InsideVerticalBorder { get; set; }
        public DOLeftBorder LeftBorder { get; set; }
        public DORightBorder RightBorder { get; set; }
        public DOStartBorder StartBorder { get; set; }
        public DOTopBorder TopBorder { get; set; }
        public object TopLeftToBottomRightCellBorder { get; set; }
        public object TopRightToBottomLeftCellBorder { get; set; }

        public DOTableCellBorders(DocumentFormat.OpenXml.Wordprocessing.TableCellBorders tableCellBorders)
        {
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

    public class DOTableCellWidth
    {
        public string Type { get; set; }
        public string Width { get; set; }

        public DOTableCellWidth(DocumentFormat.OpenXml.Wordprocessing.TableCellWidth tableCellWidth)
        {
            Type = tableCellWidth.Type;
            Width = tableCellWidth.Width;
        }
    }

    public class DOTableCellMarginDefault
    {
        public DOBottomMargin BottomMargin { get; set; }
        public DOEndMargin EndMargin { get; set; }
        public DOStartMargin StartMargin { get; set; }
        public DOTableCellLeftMargin TableCellLeftMargin { get; set; }
        public DOTableCellRightMargin TableCellRightMargin { get; set; }
        public DOTopMargin TopMargin { get; set; }
    }
    public class DOMargin
    {
        public string Type { get; set; }
        public string Width { get; set; }
    }

    public class DOBottomMargin : DOMargin { }

    public class DOEndMargin : DOMargin { }

    public class DOStartMargin : DOMargin { }

    public class DOTableCellLeftMargin : DOMargin { }

    public class DOTableCellRightMargin : DOMargin { }

    public class DOTopMargin : DOMargin { }

    public class DOTableIndentation : DOMargin
    {
        public DOTableIndentation() { }
        public DOTableIndentation(DocumentFormat.OpenXml.Wordprocessing.TableIndentation tableIndentation)
        {
            Type = tableIndentation.Type;
            Width = tableIndentation.Width;
        }
    }

    public class DOTableJustification
    {
        public string Val { get; set; }
        public DOTableJustification(DocumentFormat.OpenXml.Wordprocessing.TableJustification tableJustification)
        {
            Val = tableJustification.Val.Value.ToString();
        }
    }

    public class DOTableLayout
    {
        public string Type { get; set; }
        public DOTableLayout(DocumentFormat.OpenXml.Wordprocessing.TableLayout tableLayout)
        {
            Type = tableLayout.Type;
        }
    }

    public class DOTableWidth : DOMargin
    {
        public DOTableWidth(DocumentFormat.OpenXml.Wordprocessing.TableWidth tableWidth)
        {
            Type = tableWidth.Type;
            Width = tableWidth.Width;
        }
    }
}
