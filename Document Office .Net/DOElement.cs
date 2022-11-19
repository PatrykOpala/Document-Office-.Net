using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document_Office.Net
{
    public class DOElement
    {
        public int DOID = 0;

        public DOElement()
        {

        }

        public DOElement(int id)
        {
            DOID = id;
        }
    }

    public class DOItem
    {
        public int itemID { get; set; } = 0;
        public string itemText { get; set; } = "";
        public string itemPlaceholder { get; set; } = "";

        public DOItem(int id, string str)
        {
            itemID = id;
            itemText = str;
        }

        public DOItem(int id, string str, string placeholder)
        {
            itemID = id;
            itemText = str;
            itemPlaceholder = placeholder;
        }

        public override string ToString()
        {
            return this.itemPlaceholder;
        }
    }
}
