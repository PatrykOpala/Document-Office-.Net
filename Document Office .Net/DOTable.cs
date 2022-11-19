using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Office.Net
{
    public class DOTable : DOElement
    {
        public string Name { get; set; } = "Table";
        public DOTableProp TableProperties { get; set; }
        public DOTableGrid TableGrid { get; set; }
        public DOTableRow[] TableRowArray { get; set; }

        public DOTable(int id)
        {
            base.DOID = id;
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
    }

    public class DOTableGrid
    {
        public DOGridColumn[] GridColumns { get; set; }
    }

    public class DOGridColumn
    {
        public string ObjectName { get; set; }
        public string Width { get; set; }
        public DOGridColumn()
        {
            ObjectName = "GridColumn";
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
        public DOTableCell[] TableCells { get; set; }
    }

    public class DOTableRowProp { }

    public class DOTableCell
    {
        public DOTableCellProp TableCellProperties { get; set; }
        public DOParagraph[] TableParagraphs { get; set; }
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
    }

    public class DOBorder
    {
        public string Color { get; set; }
        public string Frame { get; set; }
        public string Shadow { get; set; }
        public string Size { get; set; }
        public string Space { get; set; }
        public string ThemeColor { get; set; }
        public string ThemeShade { get; set; }
        public string ThemeTint { get; set; }
        public string Val { get; set; }
    }

    public class DOBottomBorder : DOBorder { }

    public class DOEndBorder : DOBorder { }

    public class DOLeftBorder : DOBorder { }

    public class DORightBorder : DOBorder { }

    public class DOStartBorder : DOBorder { }

    public class DOTopBorder : DOBorder { }

    public class DOTableCellWidth
    {
        public string Type { get; set; }
        public string Width { get; set; }
    }

    public class DOTableCellMarginDefault
    {
        public string ObjectName { get; set; }
        public DOBottomMargin BottomMargin { get; set; }
        public DOEndMargin EndMargin { get; set; }
        public DOStartMargin StartMargin { get; set; }
        public DOTableCellLeftMargin TableCellLeftMargin { get; set; }
        public DOTableCellRightMargin TableCellRightMargin { get; set; }
        public DOTopMargin TopMargin { get; set; }

        public DOTableCellMarginDefault()
        {
            ObjectName = "TableCellMarginDefault";
        }
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

    public class DOTableIndentation : DOMargin { }

    public class DOTableJustification
    {
        public string ObjectName { get; set; }
        public string Val { get; set; }
        public DOTableJustification()
        {
            ObjectName = "TableJustification";
        }
    }

    public class DOTableLayout
    {
        public string ObjectName { get; set; }
        public string Type { get; set; }
        public DOTableLayout()
        {
            ObjectName = "TableLayout";
        }
    }

    public class DOTableWidth : DOMargin
    {
        public string ObjectName { get; set; }
        public DOTableWidth()
        {
            ObjectName = "TableWidth";
        }
    }
}
