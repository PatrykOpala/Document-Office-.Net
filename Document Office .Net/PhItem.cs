using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;

namespace Document_Office.Net
{
    public class PhItem
    {
        public string _Name { get; set; }
        public List<string> _Header = new List<string>();
        public string _Body { get; set; }

        public System.Drawing.Color _Color {get; set;}
        public string _ColorString {get; set;}

        public PhItem()
        {
            _Name = "Paragraph";
        }

        public PhItem(string header, string body, string name = "Linia: ")
        {
            _Header.Add(header);
            _Body = body;
            _Name = name;
        }

        public void SetBody(string value)
        {
            _Body = $"{_Name} {value}";
        }
    }
}
