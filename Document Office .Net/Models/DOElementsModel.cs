using System.Collections.Generic;

namespace Document_Office.Net.Models
{
    internal class DOElementsModel
    {

    }

    public struct DORunModel
    {
        public List<string> ListText;
        public DORunProp Properties { get; set; }
        public DORunModel(DORun run)
        {
            ListText = run.ListText;
            Properties = run.Properties;
        }
    }

    public struct DOParagPropModel
    {
        public DOParagPropModel(DOParagProp paragProp)
        {

        }
    }
}
