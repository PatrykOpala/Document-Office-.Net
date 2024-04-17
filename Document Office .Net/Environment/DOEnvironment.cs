using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Document_Office.Net.Environment
{
   internal class DOEnvironmentUI
    {
        private List<IDOElement> elements = new List<IDOElement>();
        private Panel _newspaperPanel = null;
        private string fileName = "";
        private int _y = 0;
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
                AutoScroll = true,
            };

            Label textBox = new Label()
            {
                Text = TestText,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 30.0f),
                Size = new Size(30, 50),
                BackColor= Color.Teal,
            };
            EnvPanel.Controls.Add(textBox);

            EnvPanel.Controls.Add(CreateNewspaper(width));

            form.Controls.Add(EnvPanel);
        }

        public Control CreateNewspaper(int containerWidth)
        {
            Panel newspaperPanel = new Panel()
            {
                Size = new Size(containerWidth - 160, 500),
                BackColor = Color.White,
                Location = new Point(containerWidth / 2 - 460, 50),
                AutoSize = true,
            };

            /*if(this.elements.Count > 0 )
            {
                foreach( IDOElement idoElement in this.elements )
                {
                    Console.WriteLine(idoElement.Type);

                    if(idoElement.Type == "Paragraph")
                    {
                        newspaperPanel.Controls.Add(CreateNewspaperParagraph(new DOParagraph()));
                    }
                }
            }*/

            _newspaperPanel = newspaperPanel;
            return newspaperPanel;
        }

        public void CreateNewspaperParagraph(DOParagraph paragraph, ref int vertical)
        {
            foreach(DORun dORun in paragraph.ListRuns)
            {
                Label label = new Label()
                {
                    Location = new Point(vertical, _y),
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand,
                    AutoSize = true,
                    Tag = dORun.DORunGuid,
                    Font = dORun.Properties.Font,
                    ForeColor = Color.Black,
                    Text = dORun.Text
                    //dORun.Properties._Color
                };

                if (dORun.Text == "")
                    label.Text = "[Pusty]";

                Graphics gfx = Graphics.FromImage(new Bitmap(1, 1));
                SizeF stringSize = gfx.MeasureString(dORun.Text, dORun.Properties.Font);

                label.Text = dORun.Text;

                if (dORun.Text == " ")
                {
                    label.Location = new Point(vertical + ((int)stringSize.Width) - 17, _y);
                    //vertical += label.Size.Width;
                    label.Text = " ";
                }

                _newspaperPanel.Controls.Add(label);
                Console.WriteLine(stringSize.Width);
                vertical += label.Size.Width + 5;
                //((int)stringSize.Width)
            }
            _y += 100;
        }

        public void CreateNewspaperTable(DOTable Table)
        {
            Label label = new Label()
            {

            };

            this._newspaperPanel.Controls.Add(label);
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
            /*foreach(Guid elementGuid in ido)
            //{
            //    foreach(DOParagraph paragraph in DocsParagraphElements)
            //    {
            //        if(paragraph != null)
            //        {
            //            if(paragraph.IDOElementGuid == elementGuid)
            //            {
            //                dOElements.Add(paragraph);
            //            }
            //        }
            //    }

            //    foreach(DOTable table in DocsTableElements)
            //    {
            //        if (table != null)
            //        {
            //            if (table.IDOElementGuid == elementGuid)
            //            {
            //                dOElements.Add(table);
            //            }
            //        }
            //    }
            }*/

            int xEnv = 0;
            int yEnv = 0;

            for(int iterator = 1; iterator < countCopies + 1; iterator++)
            {
                DOEnvironmentUI envUI = new DOEnvironmentUI();
                envUI.AddElementsToList(dOElements);
                Console.WriteLine($"CountCopies: {countCopies}");
                if (countCopies > 2)
                    envUI.GenerateUI(width + 135, 600, xEnv, yEnv, EnvironmentFileName, RootWindow, iterator.ToString());
                else
                    envUI.GenerateUI(width + 150, 600, xEnv, yEnv, EnvironmentFileName, RootWindow, iterator.ToString());

                foreach (Guid elementGuid in ido)
                {
                    int x = 0;
                    foreach (DOParagraph paragraph in DocsParagraphElements)
                    {
                        if (paragraph != null)
                        {
                            
                            if (paragraph.IDOElementGuid == elementGuid)
                            {
                                envUI.CreateNewspaperParagraph(paragraph, ref x);
                            }
                        }
                    }

                    foreach (DOTable table in DocsTableElements)
                    {
                        if (table != null)
                        {
                            if (table.IDOElementGuid == elementGuid)
                            {
                                //dOElements.Add(table);
                            }
                        }
                    }
                }

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
