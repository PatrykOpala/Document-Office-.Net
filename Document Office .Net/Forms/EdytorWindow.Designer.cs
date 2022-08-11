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
            this.panelEdytor = new System.Windows.Forms.Panel();
            this.paragraphContainer1 = new Document_Office.Net.CustomUserControls.ParagraphContainer();
            this.panelNewspaper = new System.Windows.Forms.Panel();
            this.panelEdytor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEdytor
            // 
            this.panelEdytor.AutoScroll = true;
            this.panelEdytor.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.panelEdytor.BackColor = System.Drawing.Color.Transparent;
            this.panelEdytor.Controls.Add(this.paragraphContainer1);
            this.panelEdytor.Controls.Add(this.panelNewspaper);
            this.panelEdytor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdytor.Location = new System.Drawing.Point(0, 0);
            this.panelEdytor.Name = "panelEdytor";
            this.panelEdytor.Size = new System.Drawing.Size(1054, 616);
            this.panelEdytor.TabIndex = 1;
            // 
            // paragraphContainer1
            // 
            this.paragraphContainer1.AutoScroll = true;
            this.paragraphContainer1.Location = new System.Drawing.Point(121, 72);
            this.paragraphContainer1.Name = "paragraphContainer1";
            this.paragraphContainer1.Size = new System.Drawing.Size(688, 170);
            this.paragraphContainer1.TabIndex = 1;
            // 
            // panelNewspaper
            // 
            this.panelNewspaper.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelNewspaper.BackColor = System.Drawing.Color.White;
            this.panelNewspaper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNewspaper.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.panelNewspaper.Location = new System.Drawing.Point(93, 292);
            this.panelNewspaper.Name = "panelNewspaper";
            this.panelNewspaper.Size = new System.Drawing.Size(793, 861);
            this.panelNewspaper.TabIndex = 0;
            // 
            // EdytorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 616);
            this.Controls.Add(this.panelEdytor);
            this.Name = "EdytorWindow";
            this.Text = "Document Office.Edytor";
            this.panelEdytor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelEdytor;
        private System.Windows.Forms.Panel panelNewspaper;
        private CustomUserControls.ParagraphContainer paragraphContainer1;
    }
}