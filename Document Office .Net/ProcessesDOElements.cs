using System.Collections.Generic;
using Document_Office.Net.Models;

namespace Document_Office.Net
{ 
    internal class ProcessesDOParagraph
    {
        internal string Type { get; } = "Paragraph";
        internal List<DORunModel> ListRuns = new List<DORunModel>();
        internal DOParagPropModel ParagraphProperties { get; set; }


        internal ProcessesDOParagraph(DOParagraph parag)
        {
            foreach(DORun dr in parag.listRuns)
            {
                DORunModel dORunModel = new DORunModel(dr);
                ListRuns.Add(dORunModel);
            }

            DOParagPropModel dOParagPropModel = new DOParagPropModel(parag.ParagraphProperties);

            ParagraphProperties = dOParagPropModel;
        }
    }

    internal class ProcessesDOTable
    {
        internal string Type { get; } = "Table";
        internal DOTableProp TableProperties { get; set; }
        internal DOTableGrid TableGrid { get; set; }

        internal List<DOTableRow> TableRowList = new List<DOTableRow>();

        internal ProcessesDOTable(DOTable table)
        {
            /*TableProperties = table.TableProperties;
            TableGrid = table.TableGrid;
            TableRowList = table.TableRows;*/
        }
    }

    internal class ProcessesDOElements
    {
        internal static ProcessesDOParagraph ProcessesDOParagraph(DOParagraph dOParagraph)
        {
            ProcessesDOParagraph processesDOParagraph = new ProcessesDOParagraph(dOParagraph);
            return processesDOParagraph;
        }

        internal static ProcessesDOTable ProcessesDOTable(DOTable dOTable)
        {
            ProcessesDOTable processesDOTable = new ProcessesDOTable(dOTable);
            return processesDOTable;
        }
    }
}
