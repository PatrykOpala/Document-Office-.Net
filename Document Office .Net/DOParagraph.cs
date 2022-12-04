using Microsoft.SqlServer.Server;
using System.Collections.Generic;

namespace Document_Office.Net
{
    public class DOParagraph : DOElement
    {
        public string Name { get; set; } = "Paragraph";
        public List<DORun> ListRuns = new List<DORun>();
        public DORun[] Arrayruns { get; set; }

        public DOParagraph()
        {
            
        }

        public DOParagraph(int id)
        {
            base.DOID = id;
        }
    }

    public class DORun
    {
        public int DORunID = 0;
        public List<DOText> ListText = new List<DOText>();
        public DOText[] Text { get; set; }
        public DORunProp[] Properties { get; set; }

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
