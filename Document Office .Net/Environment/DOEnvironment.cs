using System;
using System.Collections.Generic;

namespace Document_Office.Net.Environment
{
    public class DOEnvironmentUI
    {
        private List<IDOElement> elements = new List<IDOElement>();
        public DOEnvironmentUI() { }

        public void GenerateUI() { }

        public void SaveToFile(string fileName)
        {

        }

        public void AddElementsToList(List<IDOElement> elements) { }
    }

    internal class DOEnvironment
    {
        private List<Guid> ido = new List<Guid>();
        private List<DOParagraph> DocsParagraphElements = new List<DOParagraph>();
        private List<DOTable> DocsTableElements = new List<DOTable>();
        private int countCopies = 0;

        private List<DOEnvironmentUI> environmentUIs = new List<DOEnvironmentUI>();

        public DOEnvironment(){}

        public void AddParagraph(DOParagraph paragraph, Guid guid)
        {
            DocsParagraphElements.Add(paragraph);
            ido.Add(guid);
        }
        public void AddTable(DOTable table, Guid guid)
        {
            DocsTableElements.Add(table);
            ido.Add(guid);
        }

        public void AddCountCopies(int count) => countCopies = count;
    }
}
