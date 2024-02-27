using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Document_Office.Net.Environment
{
   internal class DOEnvironmentUI
    {
        private List<IDOElement> elements = new List<IDOElement>();
        private string fileName = "";
        public DOEnvironmentUI() { }

        public void GenerateUI(int width, int height, int x, int y, string fileName, Form form, string TestText = "")
        {
            this.fileName = fileName;
            PrepareEnvContainer(width, height, x, y, form, TestText);
        }

        public void SaveToFile()
        {

        }

        private void PrepareEnvContainer(int width, int height, int x, int y, Form form, string TestText) 
        {
            form.AutoScroll = true;

            Panel EnvPanel = new Panel()
            {
                Size = new Size(width, height),
                BackColor = Color.Magenta,
                Location = new Point(x, y),
            };

            TextBox textBox = new TextBox()
            {
                Text = TestText,
                TextAlign = HorizontalAlignment.Center,
                Font = new Font("Arial", 30.0f),
            };
            EnvPanel.Controls.Add(textBox);
            

            form.Controls.Add(EnvPanel);
        }

        public void AddElementsToList(List<IDOElement> elements) => this.elements = elements;
    }

    internal class DOEnvironment
    {
        private List<Guid> ido = new List<Guid>();
        private List<DOParagraph> DocsParagraphElements = new List<DOParagraph>();
        private List<DOTable> DocsTableElements = new List<DOTable>();
        private List<DOEnvironmentUI> environmentUIs = new List<DOEnvironmentUI>();

        private int countCopies = 0;
        private string EnvironmentFileName = "";
        private Form RootWindow = null;


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

        public void AddRootWindowToEnvironment(Form rootWindow) => RootWindow = rootWindow;

        public void AddEnvironmentFileName(string fileName) => EnvironmentFileName = fileName;

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

            int xEnv = 0;
            int yEnv = 0;

            for(int iterator = 1; iterator < countCopies + 1; iterator++)
            {
                DOEnvironmentUI envUI = new DOEnvironmentUI();
                envUI.AddElementsToList(dOElements);
                envUI.GenerateUI(width + 135, 600, xEnv, yEnv, EnvironmentFileName, RootWindow, iterator.ToString());
                environmentUIs.Add(envUI);

                if(iterator % 2 == 1)
                {
                    if (xEnv > 0)
                    {
                        xEnv = 0;
                    }
                    else
                    {
                        xEnv = width + 136;
                    }
                }

                if(iterator % 2 == 0)
                {
                    if (yEnv > 0)
                    {
                        yEnv = 0;
                    }
                    else
                    {
                        yEnv = 600 + 1;
                    }
                }
            }

        }

        public void AddCountCopies(int count) => countCopies = count;
    }
}
