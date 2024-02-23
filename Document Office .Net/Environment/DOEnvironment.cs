using System;
using System.Collections.Generic;

namespace Document_Office.Net.Environment
{
   internal class DOEnvironmentUI
    {
        private List<IDOElement> elements = new List<IDOElement>();
        private string fileName = "";
        public DOEnvironmentUI() { }

        public void GenerateUI(int width, string fileName, System.Windows.Forms.Form form)
        {
            this.fileName = fileName;

            // form.Controls.Add();
        }

        public void SaveToFile()
        {

        }

        public void AddElementsToList(List<IDOElement> elements) => this.elements = elements;
    }

    internal class DOEnvironment
    {
        private List<Guid> ido = new List<Guid>();
        private List<DOParagraph> DocsParagraphElements = new List<DOParagraph>();
        private List<DOTable> DocsTableElements = new List<DOTable>();
        private int countCopies = 0;
        private string EnvironmentFileName = "";
        private System.Windows.Forms.Form RootWindow = null;

        private List<DOEnvironmentUI> environmentUIs = new List<DOEnvironmentUI>();

        public DOEnvironment(){ }

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

        public void AddRootWindowToEnvironment(System.Windows.Forms.Form rootWindow) => this.RootWindow = rootWindow;

        public void AddEnvironmentFileName(string fileName) => this.EnvironmentFileName = fileName;

        public void InitUI(int width) 
        {
            List<IDOElement> dOElements = new List<IDOElement>();
            foreach(Guid elementGuid in ido)
            {
                foreach(DOParagraph paragraph in DocsParagraphElements)
                {
                    if(paragraph != null)
                    {
                        if(paragraph.IDOElementGuid == elementGuid)
                        {
                            dOElements.Add(paragraph);
                        }
                    }
                }

                foreach(DOTable table in DocsTableElements)
                {
                    if (table != null)
                    {
                        if (table.IDOElementGuid == elementGuid)
                        {
                            dOElements.Add(table);
                        }
                    }
                }
            }
            DOEnvironmentUI envUI = new DOEnvironmentUI();
            envUI.AddElementsToList(dOElements);
            envUI.GenerateUI(width, EnvironmentFileName, RootWindow);

            this.environmentUIs.Add(envUI);
        }

        public void AddCountCopies(int count) => countCopies = count;
    }
}
