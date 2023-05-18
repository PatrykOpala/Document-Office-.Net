using System;

namespace Document_Office.Net
{
    public interface IDOElement
    {
        Guid DOID { get; set; }
        string Type { get; set; }
        Guid GetDOID();
        string GetType();
    }

    public class DOItem
    {
        public Guid itemID { get; set; }
        public string itemText { get; set; } = "";
        public string itemPlaceholder { get; set; } = "";

        public DOItem(Guid id, string str)
        {
            itemID = id;
            itemText = str;
        }

        public DOItem(Guid id, string str, string placeholder)
        {
            itemID = id;
            itemText = str;
            itemPlaceholder = placeholder;
        }

        public override string ToString() => this.itemPlaceholder;
    }
}
