using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }

    public class DOBottomBorder : DOBorder { }

    public class DOEndBorder : DOBorder { }

    public class DOLeftBorder : DOBorder { }

    public class DORightBorder : DOBorder { }

    public class DOStartBorder : DOBorder { }

    public class DOTopBorder : DOBorder { }
}
