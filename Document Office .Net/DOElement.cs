﻿namespace Document_Office.Net
{
    public interface IDOElement
    {
        int DOID { get; set; }
        string Type { get; set; }
        int GetDOID();
        string GetType();
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

        public override string ToString() => this.itemPlaceholder
    }
}
