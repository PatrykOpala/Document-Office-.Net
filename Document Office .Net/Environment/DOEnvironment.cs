using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Document_Office.Net.Environment
{
    internal class LabelTag
    {
        public Guid _guid;
        public string _oldValue;
        public string _newValue;

        public LabelTag(Guid guid, string oldValue, string newValue = "")
        {
            this._guid = guid;
            this._oldValue = oldValue;
            this._newValue = newValue;
        }
    }

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
            foreach (Control element in _newspaperPanel.Controls)
            {
                var text = element.Text;
                var textArray = text.Split();

            }
        }

        private void PrepareEnvContainer(int width, int height, int x, int y, Form form, string TestText) 
        {
            form.AutoScroll = true;

            Button GenerateButton = new Button();

            GenerateButton.Text = "Przetwórz dokumenty";
            GenerateButton.Location = new Point(0, 10);
            GenerateButton.Size = new Size(190, 30);
            GenerateButton.Font = new Font("Arial", 13);

            Panel EnvPanel = new Panel()
            {
                Size = new Size(width, height),
                BackColor = Color.Magenta,
                Location = new Point(x, y + 50),
                AutoScroll = true,
            };

            Label textBox = new Label()
            {
                Text = TestText,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 30.0f),
                Size = new Size(30, 50),
            };
            EnvPanel.Controls.Add(textBox);

            EnvPanel.Controls.Add(CreateNewspaper(width));

            form.Controls.Add(GenerateButton);
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
            _newspaperPanel = newspaperPanel;
            return newspaperPanel;
        }

       /* public void CreateNewspaperParagraph(DOParagraph paragraph, ref int vertical)
        {
            foreach(DORun dORun in paragraph.ListRuns)
            {
                Label label = new Label()
                {
                    Location = new Point(vertical, _y),
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand,
                    AutoSize = true,
                    Tag = new LabelTag(dORun.DORunGuid, dORun.Text),
                    Font = dORun.Properties.Font,
                    ForeColor = Color.Black,
                    Text = dORun.Text
                };

                Graphics gfx = Graphics.FromImage(new Bitmap(1, 1));
                SizeF stringSize = gfx.MeasureString(dORun.Text, dORun.Properties.Font);

                label.Text = dORun.Text;

                if (dORun.Text == "")
                {
                    label.Text = "[Pusty]";
                }

                if (dORun.Text == " ")
                {
                    label.Location = new Point(vertical + ((int)stringSize.Width) - 17, _y);
                    label.Text = dORun.Text;
                }

                label.Click += Label_Click;

                _newspaperPanel.Controls.Add(label);
                vertical += label.Size.Width + 5;
            }
            _y += 100;
        }*/

        private void Label_Click(object sender, EventArgs e)
        {
            Label targetLabel = ((Label)sender);

            foreach (var text in targetLabel.Text.Split(' '))
            {
                var j = text.ToCharArray();
                foreach (var i in j)
                {
                    Console.WriteLine($"{((short)i)}");
                }
            }

            //Console.WriteLine($"{((LabelTag)targetLabel.Tag)._oldValue}");
            /*foreach(var text in targetLabel.Text.Split(' '))
            {
                var j = text.ToCharArray();
                foreach(var i in j)
                {
                    Console.WriteLine($"{((short)i)}");
                }
            }*/

            /*Panel Click_Panel = new Panel()
            {
                Size = new Size(400, 200),
                Location = new Point(targetLabel.Bounds.X, targetLabel.Bounds.Y + 20),
                BackColor = Color.Brown,
            };

            Label Old_Value_Label = new Label()
            {
                Text = "Poprzednia wartość",
                Location = new Point(5,20),
                ForeColor = Color.White,
                Font = new Font("Arial", 15),
                AutoSize = true
            };

            TextBox Old_Value_TextBox = new TextBox()
            {
                Location = new Point(Old_Value_Label.Bounds.X, Old_Value_Label.Bounds.Y + 30),
                Size = new Size(160, 50),
                Text = targetLabel.Text,
                Font = new Font("Arial", 15),
            };

            Label New_Value_Label = new Label()
            {
                Text = "Nowa wartość",
                Location = new Point(Old_Value_Label.Size.Width + 110, Old_Value_Label.Location.Y),
                ForeColor = Color.White,
                Font = new Font("Arial", 15),
                AutoSize = true
            };

            TextBox New_Value_TextBox = new TextBox()
            {
                Location = new Point(New_Value_Label.Bounds.X, New_Value_Label.Bounds.Y + 30),
                Size = new Size(140, 30),
                Font = new Font("Arial", 15),
            };

            targetLabel.Parent.Controls.Add(Click_Panel);
            targetLabel.Parent.Controls.SetChildIndex(Click_Panel, 0);

            Click_Panel.Controls.Add(Old_Value_Label);
            Click_Panel.Controls.Add(Old_Value_TextBox);

            Click_Panel.Controls.Add(New_Value_Label);
            Click_Panel.Controls.Add(New_Value_TextBox);*/

        }

        public void CreateNewspaperParagraph(DOParagraph paragraph, ref int vertical)
        {
            string paragraphText = "";
            foreach (DORun dORun in paragraph.ListRuns)
            {
                paragraphText += dORun.Text;
            }
            Graphics gfx = Graphics.FromImage(new Bitmap(1, 1));
            SizeF stringSize;
            Font font;
            if (paragraph.ListRuns.Length > 1)
            {
                font = paragraph.ListRuns[1].Properties.Font;
                stringSize = gfx.MeasureString(paragraphText, paragraph.ListRuns[1].Properties.Font);
            }
            else
            {
                font = paragraph.ListRuns[0].Properties.Font;
                stringSize = gfx.MeasureString("[Pusty Akapit]", paragraph.ListRuns[0].Properties.Font);
            }

            TextBox textBox = new TextBox()
            {
                Location = new Point(vertical, _y),
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size((int)stringSize.Width, (int)stringSize.Height),
                Font = font,
                ForeColor = Color.Black,
                Text = paragraphText.Length < 1 ? "[Pusty Akapit]" : paragraphText,
            };

            _newspaperPanel.Controls.Add(textBox);
            _y += 90;
            paragraphText = "";
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

            int xEnv = 0;
            int yEnv = 0;

            for(int iterator = 1; iterator < countCopies + 1; iterator++)
            {
                DOEnvironmentUI envUI = new DOEnvironmentUI();
                envUI.AddElementsToList(dOElements);
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

        private void GenerateUI()
        {

        }

        public void AddCountCopies(int count) => countCopies = count;
    }
}
