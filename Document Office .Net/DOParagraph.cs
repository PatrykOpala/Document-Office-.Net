using System;
using System.Collections.Generic;
using System.Drawing;

namespace Document_Office.Net
{
    public class DOParagraph : IDOElement
    {
        private string _type = "Paragraph";
        public string Type { get; }
        private List<DORun> _listRuns = new List<DORun>();
        public DORun[] ListRuns { get { return _listRuns.ToArray(); } }
        private DOParagProp _paragraphProperties;
        public DOParagProp ParagraphProperties { get { return _paragraphProperties; } set { _paragraphProperties = value; } }

        public bool IsEmpty { get; private set; }

        private Guid _paragraphGuid;
        public Guid ParagraphGuid { get { return _paragraphGuid; } set { _paragraphGuid = value; } }

        public DOParagraph(){}

        public DOParagraph(DocumentFormat.OpenXml.Wordprocessing.Paragraph b)
        {
            
            foreach (DocumentFormat.OpenXml.Wordprocessing.Run r in b.Elements<DocumentFormat.OpenXml.Wordprocessing.Run>())
            {
                IsEmpty = String.IsNullOrEmpty(r.InnerText);
                _listRuns.Add(new DORun(r));
            }
        }

        public void AddRun(DORun dORun) => _listRuns.Add(dORun);
    }

    public struct DOParagProp
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
        private Guid _doRunGuid;
        public Guid DORunGuid { get { return _doRunGuid; } set { _doRunGuid = value; } }
        private List<string> _listText = new List<string>();
        public string[] ListText { get { return _listText.ToArray(); } }
        public DORunProp Properties { get; set; }
        public DORun() { }
        public DORun(DocumentFormat.OpenXml.Wordprocessing.Run r)
        {
            DORunGuid = Guid.NewGuid();
            DORunProp props = new DORunProp(r.RunProperties);
            Properties = props;

            foreach (DocumentFormat.OpenXml.Wordprocessing.Text rText in r.Elements<DocumentFormat.OpenXml.Wordprocessing.Text>())
            {
                _listText.Add(rText.Text);
            }
        }

        public void AddText(string text) => _listText.Add(text);
    }

    public struct DORunProp
    {
        public bool Bold { get; private set; }
        public DOBorder Border { get; private set; }
        public bool BoldComplexScript { get; private set; }
        public bool Caps { get; private set; }
        public Color? _Color { get; private set; }
        public bool CharakterScale { get; private set; }
        public bool ComplexScript { get; private set; }
        public bool Highlight { get; private set; }
        public bool Italic { get; private set; }
        public bool ItalicComplexScript { get; private set; }
        public bool NumberSpacing { get; private set; }
        public bool Outline { get; private set; }
        public System.Drawing.Font? FontSize { get; private set; }
        public bool SmallCaps { get; private set; }
        public bool Spacing { get; private set; }
        public bool Strike { get; private set; }
        public string Underline { get; private set; }
        public DORunProp(DocumentFormat.OpenXml.Wordprocessing.RunProperties runProperties)
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
            FontSize = null;
            SmallCaps = false;
            Spacing = false;
            Strike = false;
            Underline = "";


            if (runProperties != null)
            {
                if (runProperties.Bold != null && runProperties.BoldComplexScript != null)
                {
                    Bold = true;
                    BoldComplexScript = true;
                }

                if (runProperties.FontSize != null)
                {
                    FontSize = new System.Drawing.Font("Microsoft Sans Serif", float.Parse(runProperties.FontSize.Val.Value), 
                        FontStyle.Regular, GraphicsUnit.Point, 238);
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
    }

    /*public class DORunProp
    {
        public bool Bold { get; private set; }
        public DOBorder Border { get; private set; }
        public bool BoldComplexScript { get; private set; }
        public bool Caps { get; private set; }
        public Color? _Color { get; private set; }
        public bool CharakterScale { get; private set; }
        public bool ComplexScript { get; private set; }
        public bool Highlight { get; private set; }
        public bool Italic { get; private set; }
        public bool ItalicComplexScript { get; private set; }
        public bool NumberSpacing { get; private set; }
        public bool Outline { get; private set; }
        public System.Drawing.Font FontSize { get;private set; }
        public bool SmallCaps { get; private set; }
        public bool Spacing { get; private set; }
        public bool Strike { get; private set; }
        public string Underline { get; private set; }
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
    }*/

    public struct DOShading
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

    public struct ExtendsDORunProp
    {
        public bool ContextualAlternatives { get; set; }
        public bool DoubleStrike { get; set; }
        public bool EastAsianLayout { get; set; }
        public bool Emboss { get; set; }
        public bool Emphasis { get; set; }
        public bool FillTextEffect { get; set; }
        public bool FitText { get; set; }
        public bool FontSizeComplexScript { get; set; }
        public bool Glow { get; set; }
        public bool Imprint { get; set; }
        public bool Kern { get; set; }
        public bool Languages { get; set; }
        public bool Ligatures { get; set; }
        public bool NoProof { get; set; }
        public bool NumberSpacing { get; set; }
        public bool NumberingFormat { get; set; }
        public bool Position { get; set; }
        public bool Properties3D { get; set; }
        public bool Reflection { get; set; }
        public bool RightToLeftText { get; set; }
        public bool RunFonts { get; set; }
        public bool RunPropertiesChange { get; set; }
        public bool RunStyle { get; set; }
        public bool Scene3D { get; set; }
        public DOShading Shading { get; set; }
        public bool Shadow { get; set; }
        public bool Shadow14 { get; set; }
        public bool SnapToGrid { get; set; }
        public bool Spacing { get; set; }
        public bool SpecVanish { get; set; }
        public bool StylisticSets { get; set; }
        public bool TextEffect { get; set; }
        public bool TextOutlineEffect { get; set; }
        public bool Vanish { get; set; }
        public bool VerticalTextAlignment { get; set; }
        public bool WebHidden { get; set; }

    }
}
