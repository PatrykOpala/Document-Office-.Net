using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Office.Net
{
    public struct DOTableProp
    {
        public object BiDiVisual { get; set; }
        public object Shading { get; set; }
        public object TableBorders { get; set; }
        public object TableCaption { get; set; }
        public DOTableCellMarginDefault? TableCellMarginDefault { get; set; }
        public object TableCellSpacing { get; set; }
        public object TableDescription { get; set; }
        public DOTableIndentation TableIndentation { get; set; }
        public DOTableJustification? TableJustification { get; set; }
        public DOTableLayout? TableLayout { get; set; }
        public object TableLook { get; set; }
        public object TableOverlap { get; set; }
        public object TablePositionProperties { get; set; }
        public object TablePropertiesChange { get; set; }
        public object TableStyle { get; set; }
        public DOTableWidth TableWidth { get; set; }
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
    public struct DOTableCellMarginDefault
    {
        public DOBottomMargin BottomMargin { get; set; }
        public DOEndMargin EndMargin { get; set; }
        public DOStartMargin StartMargin { get; set; }
        public DOTableCellLeftMargin TableCellLeftMargin { get; set; }
        public DOTableCellRightMargin TableCellRightMargin { get; set; }
        public DOTopMargin TopMargin { get; set; }
    }

    public class DOTableIndentation : DOMargin
    {
        public DOTableIndentation() { }
        public DOTableIndentation(DocumentFormat.OpenXml.Wordprocessing.TableIndentation tableIndentation)
        {
            Type = tableIndentation.Type;
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

    public class DOTableWidth : DOMargin
    {
        public DOTableWidth(DocumentFormat.OpenXml.Wordprocessing.TableWidth tableWidth)
        {
            Type = tableWidth.Type;
            Width = tableWidth.Width;
        }

        public int getCalculateWidth(int elementWidth)
        {
            if (Type == "pct")
            {
                ushort percentage = (ushort)(ushort.Parse(Width) / 100);
                if (percentage == 50)
                {
                    return elementWidth / 2;
                }
            }
            return 0;
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
}
