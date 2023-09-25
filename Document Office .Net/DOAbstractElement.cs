using System;
using System.Collections.Generic;

namespace Document_Office.Net
{
    internal class DOAbstractElement : IDOElement
    {
        public Guid IDOElementGuid { get; set; }

        public string Type { get; set; }

        public string Target { get; set; }

        public bool IsReplace { get; set; } = false;
    }

    internal class DOAbstractParagraph : DOAbstractElement
    {
        public List<DORun> ListRuns = new List<DORun>();
        //public DORun[] ListRuns { get { return _listRuns.ToArray(); } }
        private DOParagProp _paragraphProperties;
        public DOParagProp ParagraphProperties { get { return _paragraphProperties; } set { _paragraphProperties = value; } }
        public bool IsEmpty { get; set; }
        public DOAbstractParagraph() { }
    }

    internal class DOAbstractTable : DOAbstractElement
    {
        public DOTableProp TableProperties { get; set; }
        public DOTableGrid TableGrid { get; set; }
        public List<DOTableRow> TableRows = new List<DOTableRow>();
        //public DOTableRow[] TableRows { get { return dOTableRows.ToArray(); } }
        public DOAbstractTable() { }
    }
}
