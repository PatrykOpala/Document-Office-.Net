using System;
using System.Collections.Generic;
using System.Drawing;

namespace Document_Office.Net
{
    public class DOParagraph : IDOElement
    {
        string IDOElement.Type { get; set; } = "Paragraph";
        public List<DORun> ListRuns = new List<DORun>();
        public DOParagProp paragraphProperties { get; set; }

        private bool IsEmpty { get; set; }

        int IDOElement.DOID { get; set; }

        public DOParagraph(){}

        public DOParagraph(DocumentFormat.OpenXml.Wordprocessing.Paragraph b, int id)
        {
            ((IDOElement)this).DOID = id;
            Random x = new Random();
            foreach (DocumentFormat.OpenXml.Wordprocessing.Run r in b.Elements<DocumentFormat.OpenXml.Wordprocessing.Run>())
            {
                IsEmpty = String.IsNullOrEmpty(r.InnerText);
                ListRuns.Add(new DORun(r, x.Next(110) + id));
            }
        }

        public int GetDOID() => ((IDOElement)this).DOID;

        string IDOElement.GetType() => ((IDOElement)this).Type;

        public bool GetIsEmpty() => this.IsEmpty;
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
        public int DORunID { get; set; } = 0;
        public List<string> ListText = new List<string>();
        public DORunProp Properties { get; set; }
        public DORun() { }
        public DORun(DocumentFormat.OpenXml.Wordprocessing.Run r, int id)
        {
            this.DORunID = id;
            DORunProp props = new DORunProp(r.RunProperties);
            Properties = props;

            foreach (DocumentFormat.OpenXml.Wordprocessing.Text rText in r.Elements<DocumentFormat.OpenXml.Wordprocessing.Text>())
            {
                ListText.Add(rText.Text);
            }
        }
    }
    public class DORunProp
    {
        public bool Bold { get; set; }
        public DOBorder Border { get; set; }
        public bool BoldComplexScript { get; set; }
        public bool Caps { get; set; }
        public Color? _Color { get; set; }
        public bool CharakterScale { get; set; }
        public bool ComplexScript { get; set; }
        public bool Highlight { get; set; }
        public bool Italic { get; set; }
        public bool ItalicComplexScript { get; set; }
        public bool NumberSpacing { get; set; }
        public bool Outline { get; set; }
        public System.Drawing.Font FontSize { get; set; }
        public bool SmallCaps { get; set; }
        public bool Spacing { get; set; }
        public bool Strike { get; set; }
        public string Underline { get; set; }
        public DORunProp(DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties)
        {
            if(runProperties != null)
            {
                if (runProperties.Bold != null && runProperties.BoldComplexScript != null)
                {
                    Bold = true;
                    BoldComplexScript = true;
                }

                if (runProperties.FontSize != null)
                {
                    FontSize = new System.Drawing.Font("Microsoft Sans Serif", float.Parse(runProperties.FontSize.Val.Value), FontStyle.Regular, GraphicsUnit.Point, 238);
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
            else
            {
                Bold = false;
                Border = null;
                BoldComplexScript = false;
                Caps = false;
                _Color = null;
                CharakterScale = false;
                ComplexScript = false;
                Highlight = false;
                Italic = false;
                ItalicComplexScript = false;
                NumberSpacing = false;
                Outline = false;
                FontSize = new System.Drawing.Font("Microsoft Sans Serif", 30, FontStyle.Regular, GraphicsUnit.Point, 238); ;
                SmallCaps = false;
                Spacing = false;
                Strike = false;
                Underline = "";
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
