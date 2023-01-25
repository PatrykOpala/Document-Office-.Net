using System.Collections.Generic;
using System.Drawing;

namespace Document_Office.Net
{
    public class DOParagraph : IDOElement
    {
        public string Name { get; set; } = "Paragraph";
        public List<DORun> ListRuns = new List<DORun>();
        public DOParagProp paragraphProperties { get; set; }
        int IDOElement.DOID { get; set; } = 0;

        //public DORun[] Arrayruns { get; set; }

        public DOParagraph(){}

        public DOParagraph(DocumentFormat.OpenXml.Wordprocessing.Paragraph b, int id)
        {
            ((IDOElement)this).DOID = id;
            foreach (DocumentFormat.OpenXml.Wordprocessing.Run r in b.Elements<DocumentFormat.OpenXml.Wordprocessing.Run>())
            {
                DORun run = new DORun(r, id);
                ListRuns.Add(run);
            }
        }

        public int GetDOID()
        {
            return ((IDOElement)this).DOID;
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
        public DORunProp Properties { get; set; }

        public DORun()
        {

        }
        public DORun(DocumentFormat.OpenXml.Wordprocessing.Run r, int id)
        {
            DORunID = id + 1;
            DORunProp props = new DORunProp(r.RunProperties);
            Properties = props;

            foreach (DocumentFormat.OpenXml.Wordprocessing.Text rText in r.Elements<DocumentFormat.OpenXml.Wordprocessing.Text>())
            {
                DOText DOtext = new DOText(rText);
                ListText.Add(DOtext);
            }
        }
    }

    public class DOText
    {
        public string Value { get; set; }
        public DOText()
        {

        }
        public DOText(DocumentFormat.OpenXml.Wordprocessing.Text rText)
        {
            Value = rText.Text;
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

        public DORunProp() { }
        public DORunProp(DORunProp dORunProp)
        {
            Bold = dORunProp.Bold;
            BoldComplexScript = dORunProp.BoldComplexScript;
            Border = dORunProp.Border;
            Caps = dORunProp.Caps;
            _Color = dORunProp._Color;
            CharakterScale = dORunProp.CharakterScale;
            ComplexScript = dORunProp.ComplexScript;
            Highlight = dORunProp.Highlight;
            Italic = dORunProp.Italic;
            ItalicComplexScript = dORunProp.ItalicComplexScript;
            NumberSpacing = dORunProp.NumberSpacing;
            Outline = dORunProp.Outline;
            FontSize = dORunProp.FontSize;
            SmallCaps = dORunProp.SmallCaps;
            Spacing = dORunProp.Spacing;
            Strike = dORunProp.Strike;
            Underline = dORunProp.Underline;
        }
        public DORunProp(DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties)
        {
            if (runProperties.Bold != null && runProperties.BoldComplexScript != null)
            {
                Bold = true;
                BoldComplexScript = true;
            }

            if (runProperties.FontSize != null)
            {
                FontSize = runProperties.FontSize.Val.Value;
            }

            if (runProperties.Color != null)
            {
                _Color = ColorTranslator.FromHtml("#" + runProperties.Color.Val);
            }

            if (runProperties.Italic != null && runProperties.ItalicComplexScript != null)
            {
                Italic = true;
                ItalicComplexScript = true;
            }

            if (runProperties.Strike != null)
            {
                Strike = true;
            }

            if (runProperties.Underline != null)
            {
                Underline = runProperties.Underline.Val;
            }
        }
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
