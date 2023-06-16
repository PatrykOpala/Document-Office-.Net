
namespace Document_Office.Net
{
    public class DOBorder
    {
        private string Color;
        private string Frame;
        private string Shadow;
        private string Size;
        private string Space;
        private string ThemeColor;
        private string ThemeShade;
        private string ThemeTint;
        private string Val;

        public string GetColor() => Color;
        public string GetFrame() => Frame;
        public string GetShadow() => Shadow;
        public string GetSize() => Size;
        public string GetSpace() => Space;
        public string GetThemeColor() => ThemeColor;
        public string GetThemeShade() => ThemeShade;
        public string GetThemeTint() => ThemeTint;
        public string GetVal() => Val;

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
        
        public DOBorder(DOBorder border)
        {
            Color = border.GetColor();
            Frame = border.GetFrame();
            Shadow = border.GetShadow();
            Size = border.GetSize();
            Space = border.GetSpace();
            ThemeColor = border.GetThemeColor();
            ThemeShade = border.GetThemeShade();
            ThemeTint = border.GetThemeTint();
            Val = border.GetVal();
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
