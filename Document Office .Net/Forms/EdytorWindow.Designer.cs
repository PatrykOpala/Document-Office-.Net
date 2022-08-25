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
            this.panelNewspaper = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.paragraphContainer1 = new Document_Office.Net.CustomUserControls.ParagraphContainer();
            this.panelEdytor.SuspendLayout();
            this.panelNewspaper.SuspendLayout();
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
            // panelNewspaper
            // 
            this.panelNewspaper.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelNewspaper.BackColor = System.Drawing.Color.White;
            this.panelNewspaper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNewspaper.Controls.Add(this.richTextBox1);
            this.panelNewspaper.Controls.Add(this.button1);
            this.panelNewspaper.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.panelNewspaper.Location = new System.Drawing.Point(98, 275);
            this.panelNewspaper.Name = "panelNewspaper";
            this.panelNewspaper.Size = new System.Drawing.Size(793, 522);
            this.panelNewspaper.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(2)))), ((int)(((byte)(88)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(610, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Dalej";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(60, 141);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(659, 144);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // paragraphContainer1
            // 
            this.paragraphContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paragraphContainer1.AutoScroll = true;
            this.paragraphContainer1.Location = new System.Drawing.Point(98, 51);
            this.paragraphContainer1.Name = "paragraphContainer1";
            this.paragraphContainer1.Size = new System.Drawing.Size(671, 170);
            this.paragraphContainer1.TabIndex = 1;
            // 
            // EdytorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 616);
            this.Controls.Add(this.panelEdytor);
            this.Name = "EdytorWindow";
            this.Text = "Document Office.Edytor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelEdytor.ResumeLayout(false);
            this.panelNewspaper.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelEdytor;
        private System.Windows.Forms.Panel panelNewspaper;
        private CustomUserControls.ParagraphContainer paragraphContainer1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
    }
}