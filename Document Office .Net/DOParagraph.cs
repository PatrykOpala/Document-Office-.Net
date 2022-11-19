namespace Document_Office.Net
{
    public class DOParagraph : DOElement
    {
        public string Name { get; set; } = "Paragraph";
        public DORun[] Arrayruns { get; set; }

        public DOParagraph(int id)
        {
            base.DOID = id;
        }
    }

    public class DORun
    {
        public int DORunID = 0;
        public string[] Text { get; set; }
        public DORunProp[] Properties { get; set; }
    }

    public class DORunProp
    {
        public bool Bold { get; set; } = false;
        public bool Border { get; set; } = false;
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
}
