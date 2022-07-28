namespace Document_Office.Net.Forms
{
    partial class EdytorWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelButtonChange = new System.Windows.Forms.Panel();
            this.buttonChange = new System.Windows.Forms.Button();
            this.panelGenerate = new System.Windows.Forms.Panel();
            this.panelGenerateButton = new System.Windows.Forms.Button();
            this.panelEdytor = new System.Windows.Forms.Panel();
            this.panelNewspaper = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelButtonChange.SuspendLayout();
            this.panelGenerate.SuspendLayout();
            this.panelEdytor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panelGenerate);
            this.panel1.Controls.Add(this.panelButtonChange);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1054, 112);
            this.panel1.TabIndex = 0;
            // 
            // panelButtonChange
            // 
            this.panelButtonChange.Controls.Add(this.buttonChange);
            this.panelButtonChange.Location = new System.Drawing.Point(22, 12);
            this.panelButtonChange.Name = "panelButtonChange";
            this.panelButtonChange.Size = new System.Drawing.Size(59, 85);
            this.panelButtonChange.TabIndex = 0;
            // 
            // buttonChange
            // 
            this.buttonChange.BackColor = System.Drawing.Color.Transparent;
            this.buttonChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChange.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonChange.Image = global::Document_Office.Net.Properties.Resources.close1;
            this.buttonChange.Location = new System.Drawing.Point(0, 0);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(59, 85);
            this.buttonChange.TabIndex = 0;
            this.buttonChange.Text = "Zmień";
            this.buttonChange.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonChange.UseVisualStyleBackColor = false;
            // 
            // panelGenerate
            // 
            this.panelGenerate.Controls.Add(this.panelGenerateButton);
            this.panelGenerate.Location = new System.Drawing.Point(102, 12);
            this.panelGenerate.Name = "panelGenerate";
            this.panelGenerate.Size = new System.Drawing.Size(59, 85);
            this.panelGenerate.TabIndex = 1;
            // 
            // panelGenerateButton
            // 
            this.panelGenerateButton.BackColor = System.Drawing.Color.Transparent;
            this.panelGenerateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.panelGenerateButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelGenerateButton.Image = global::Document_Office.Net.Properties.Resources.close1;
            this.panelGenerateButton.Location = new System.Drawing.Point(0, 0);
            this.panelGenerateButton.Name = "panelGenerateButton";
            this.panelGenerateButton.Size = new System.Drawing.Size(59, 85);
            this.panelGenerateButton.TabIndex = 0;
            this.panelGenerateButton.Text = "Generuj";
            this.panelGenerateButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.panelGenerateButton.UseVisualStyleBackColor = false;
            // 
            // panelEdytor
            // 
            this.panelEdytor.AutoScroll = true;
            this.panelEdytor.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.panelEdytor.BackColor = System.Drawing.Color.Transparent;
            this.panelEdytor.Controls.Add(this.panelNewspaper);
            this.panelEdytor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdytor.Location = new System.Drawing.Point(0, 112);
            this.panelEdytor.Name = "panelEdytor";
            this.panelEdytor.Size = new System.Drawing.Size(1054, 504);
            this.panelEdytor.TabIndex = 1;
            // 
            // panelNewspaper
            // 
            this.panelNewspaper.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelNewspaper.BackColor = System.Drawing.Color.White;
            this.panelNewspaper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNewspaper.Location = new System.Drawing.Point(138, 18);
            this.panelNewspaper.Name = "panelNewspaper";
            this.panelNewspaper.Size = new System.Drawing.Size(793, 1122);
            this.panelNewspaper.TabIndex = 0;
            // 
            // EdytorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 616);
            this.Controls.Add(this.panelEdytor);
            this.Controls.Add(this.panel1);
            this.Name = "EdytorWindow";
            this.Text = "Document Office.Edytor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panelButtonChange.ResumeLayout(false);
            this.panelGenerate.ResumeLayout(false);
            this.panelEdytor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelGenerate;
        private System.Windows.Forms.Button panelGenerateButton;
        private System.Windows.Forms.Panel panelButtonChange;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Panel panelEdytor;
        private System.Windows.Forms.Panel panelNewspaper;
    }
}