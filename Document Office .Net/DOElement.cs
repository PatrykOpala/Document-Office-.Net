﻿using System;

namespace Document_Office.Net
{
    public interface IDOElement
    {
        Guid IDOElementGuid { get; }
    }

    public class ChooseTable
    {
        public Guid TableRowGuid { get; set; }
        public Guid TableCellGuid { get; set; }
        public Guid TableParagraphGuid { get; set; }

        public ChooseTable(Guid tableRowGuid, Guid tableCellGuid, Guid tableParagraphGuid)
        {
            TableRowGuid = tableRowGuid;
            TableCellGuid = tableCellGuid;
            TableParagraphGuid = tableParagraphGuid;
        }
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
