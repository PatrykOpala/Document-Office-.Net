
namespace Document_Office.Net
{
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

        public DOBorder(DocumentFormat.OpenXml.Wordprocessing.BorderType borderType)
        {
            Color = borderType.Color;
            Frame = borderType.Frame;
            Shadow = borderType.Shadow;
            Size = borderType.Size;
            Space = borderType.Space;
            ThemeColor = borderType.ThemeColor;
            ThemeShade = borderType.ThemeShade;
            ThemeTint = borderType.ThemeTint;
            Val = borderType.Val.InnerText;
        }
    }

    public class DOBottomBorder : DOBorder
    {
        public DOBottomBorder(DocumentFormat.OpenXml.Wordprocessing.BottomBorder bottomBorder) : base(bottomBorder) { }

    }

    public class DOEndBorder : DOBorder
    {
        public DOEndBorder(DocumentFormat.OpenXml.Wordprocessing.EndBorder endBorder) : base(endBorder) { }
    }

    public class DOLeftBorder : DOBorder
    {
        public DOLeftBorder(DocumentFormat.OpenXml.Wordprocessing.LeftBorder leftBorder) : base(leftBorder) { }
    }

    public class DORightBorder : DOBorder
    {
        public DORightBorder(DocumentFormat.OpenXml.Wordprocessing.RightBorder rightBorder) : base(rightBorder) { }
    }

    public class DOStartBorder : DOBorder
    {
        public DOStartBorder(DocumentFormat.OpenXml.Wordprocessing.StartBorder startBorder) : base(startBorder) {}
    }

    public class DOTopBorder : DOBorder
    {
        public DOTopBorder(DocumentFormat.OpenXml.Wordprocessing.TopBorder topBorder) : base(topBorder){}
    }
}
