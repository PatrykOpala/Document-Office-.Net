using DocumentFormat.OpenXml.Office2013.Excel;
using System.Collections.Generic;

namespace Document_Office.Net
{
    public class DOParagraph : DOElement
    {
        public string Name { get; set; } = "Paragraph";
        public List<DORun> ListRuns = new List<DORun>();
        public DOParagProp paragraphProperties { get; set; } 
        public DORun[] Arrayruns { get; set; }

        public DOParagraph()
        {
            
        }

        public DOParagraph(int id)
        {
            base.DOID = id;
        }
    }

    public class DOParagProp
    {
        /*
         AdjustRightIndent
         AutoSpaceDE
         AutoSpaceDN
         BiDi
         ConditionalFormatStyle
         ContextualSpacing
         DivId
         FrameProperties
         Indentation
         Justification
         KeepLines
         KeepNext
         Kinsoku
         MirrorIndents
         NumberingProperties
         OutlineLevel
         OverflowPunctuation
         PageBreakBefore

        ----------------------- ParagraphBorders/MarkRunProperties/...etc Better Class -----------------------

         ParagraphBorders
         ParagraphMarkRunProperties
         ParagraphPropertiesChange
         ParagraphStyleId

        ----------------------- ParagraphBorders/MarkRunProperties/...etc Better Class -----------------------

         SectionProperties
         Shading
         SnapToGrid
         SpacingBetweenLines

        ----------------------- Suppress Better Class -----------------------
         SuppressAutoHyphens
         SuppressLineNumbers
         SuppressOverlap
        ----------------------- Suppress Better Class -----------------------

         Tabs
        ----------------------- Text Better Class -----------------------
         TextAlignment
         TextBoxTightWrap
         TextDirection
        ----------------------- Text Better Class -----------------------

         TopLinePunctuation
         WidowControl
         WordWrap
         */
    }

    public class DORun
    {
        public int DORunID = 0;
        public List<DOText> ListText = new List<DOText>();
        public DOText[] Text { get; set; }
        public DORunProp Properties { get; set; }

        public override string ToString()
        {
            string tr = "";
            foreach(DOText dOText in Text)
            {
                tr += dOText.Value;
            }
            return tr;
        }
    }

    public class DOText
    {
        public string Value { get; set; }

        public void SetNewValue(string OldValue, string NewValue)
        {
            if(OldValue == Value)
            {
                Value = NewValue;
            }
        }
    }

    public class DORunProp : ExtendsDORunProp
    {
        public bool Bold { get; set; } = false;
        public DOBorder Border { get; set; }
        public bool BoldComplexScript { get; set; } = false;
        public bool Caps { get; set; } = false;
        public System.Drawing.Color? _Color { get; set; }
        public bool CharakterScale { get; set; } = false;
        public bool ComplexScript { get; set; } = false;
        public bool Highlight { get; set; } = false;
        public bool Italic { get; set; } = false;
        public bool ItalicComplexScript { get; set; } = false;
        public bool NumberSpacing { get; set; } = false;
        public bool Outline { get; set; } = false;
        public string FontSize { get; set; }
        public bool SmallCaps { get; set; } = false;
        public bool Spacing { get; set; } = false;
        public bool Strike { get; set; } = false;
        public string Underline { get; set; }
    }

    public class DOShading
    {
        public string Color { get; set; }
        public string Fill { get; set; }
        public string ThemeColor { get; set; }
        public string ThemeFill { get; set; }
        public string ThemeFillShade { get; set; }
        public string ThemeFillTint { get; set; }
        public string ThemeShade { get; set; }
        public string ThemeTint { get; set; }
        public string Val { get; set; }
    }

    public class ExtendsDORunProp
    {
        public bool ContextualAlternatives { get; set; } = false;
        public bool DoubleStrike { get; set; } = false;
        public bool EastAsianLayout { get; set; } = false;
        public bool Emboss { get; set; } = false;
        public bool Emphasis { get; set; } = false;
        public bool FillTextEffect { get; set; } = false;
        public bool FitText { get; set; } = false;
        public bool FontSizeComplexScript { get; set; } = false;
        public bool Glow { get; set; } = false;
        public bool Imprint { get; set; } = false;
        public bool Kern { get; set; } = false;
        public bool Languages { get; set; } = false;
        public bool Ligatures { get; set; } = false;
        public bool NoProof { get; set; } = false;
        public bool NumberSpacing { get; set; } = false;
        public bool NumberingFormat { get; set; } = false;
        public bool Position { get; set; } = false;
        public bool Properties3D { get; set; } = false;
        public bool Reflection { get; set; } = false;
        public bool RightToLeftText { get; set; } = false;
        public bool RunFonts { get; set; } = false;
        public bool RunPropertiesChange { get; set; } = false;
        public bool RunStyle { get; set; } = false;
        public bool Scene3D { get; set; } = false;
        public DOShading Shading { get; set; }
        public bool Shadow { get; set; } = false;
        public bool Shadow14 { get; set; } = false;
        public bool SnapToGrid { get; set; } = false;
        public bool Spacing { get; set; } = false;
        public bool SpecVanish { get; set; } = false;
        public bool StylisticSets { get; set; } = false;
        public bool TextEffect { get; set; } = false;
        public bool TextOutlineEffect { get; set; } = false;
        public bool Vanish { get; set; } = false;
        public bool VerticalTextAlignment { get; set; } = false;
        public bool WebHidden { get; set; } = false;

    }
}
