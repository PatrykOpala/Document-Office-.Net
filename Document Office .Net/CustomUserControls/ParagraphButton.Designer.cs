namespace Document_Office.Net.CustomUserControls
{
    partial class ParagraphButton
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelContent = new System.Windows.Forms.Label();
            this.labelParagraph = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelContent
            // 
            this.labelContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelContent.AutoSize = true;
            this.labelContent.Location = new System.Drawing.Point(34, 55);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(66, 13);
            this.labelContent.TabIndex = 0;
            this.labelContent.Text = "labelContent";
            // 
            // labelParagraph
            // 
            this.labelParagraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelParagraph.AutoSize = true;
            this.labelParagraph.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelParagraph.Location = new System.Drawing.Point(80, 98);
            this.labelParagraph.Name = "labelParagraph";
            this.labelParagraph.Size = new System.Drawing.Size(127, 18);
            this.labelParagraph.TabIndex = 1;
            this.labelParagraph.Text = "Paragraph X / X";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelParagraph);
            this.panel2.Controls.Add(this.labelContent);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(244, 140);
            this.panel2.TabIndex = 3;
            // 
            // ParagraphButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.panel2);
            this.Name = "ParagraphButton";
            this.Size = new System.Drawing.Size(244, 140);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelContent;
        private System.Windows.Forms.Label labelParagraph;
        private System.Windows.Forms.Panel panel2;
    }
}
