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
            this.duplicateLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.DOElementContainer = new System.Windows.Forms.Panel();
            this.panelEdytor.SuspendLayout();
            this.panelNewspaper.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEdytor
            // 
            this.panelEdytor.AutoScroll = true;
            this.panelEdytor.AutoScrollMargin = new System.Drawing.Size(0, 20);
            this.panelEdytor.BackColor = System.Drawing.Color.Transparent;
            this.panelEdytor.Controls.Add(this.panelNewspaper);
            this.panelEdytor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdytor.Location = new System.Drawing.Point(0, 0);
            this.panelEdytor.Name = "panelEdytor";
            this.panelEdytor.Size = new System.Drawing.Size(1447, 797);
            this.panelEdytor.TabIndex = 1;
            // 
            // panelNewspaper
            // 
            this.panelNewspaper.BackColor = System.Drawing.Color.White;
            this.panelNewspaper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNewspaper.Controls.Add(this.DOElementContainer);
            this.panelNewspaper.Controls.Add(this.duplicateLabel);
            this.panelNewspaper.Controls.Add(this.comboBox1);
            this.panelNewspaper.Controls.Add(this.button1);
            this.panelNewspaper.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.panelNewspaper.Location = new System.Drawing.Point(42, 143);
            this.panelNewspaper.Name = "panelNewspaper";
            this.panelNewspaper.Size = new System.Drawing.Size(793, 522);
            this.panelNewspaper.TabIndex = 0;
            // 
            // duplicateLabel
            // 
            this.duplicateLabel.AutoSize = true;
            this.duplicateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.duplicateLabel.Location = new System.Drawing.Point(57, 17);
            this.duplicateLabel.Name = "duplicateLabel";
            this.duplicateLabel.Size = new System.Drawing.Size(0, 25);
            this.duplicateLabel.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(147, 56);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(156, 26);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(2)))), ((int)(((byte)(88)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(610, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "Dalej";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DOElementContainer
            // 
            this.DOElementContainer.Location = new System.Drawing.Point(42, 143);
            this.DOElementContainer.Name = "DOElementContainer";
            this.DOElementContainer.Size = new System.Drawing.Size(659, 255);
            this.DOElementContainer.TabIndex = 5;
            // 
            // EdytorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 797);
            this.Controls.Add(this.panelEdytor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(300, 100);
            this.MaximizeBox = false;
            this.Name = "EdytorWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Document Office.Edytor";
            this.panelEdytor.ResumeLayout(false);
            this.panelNewspaper.ResumeLayout(false);
            this.panelNewspaper.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelEdytor;
        private System.Windows.Forms.Panel panelNewspaper;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label duplicateLabel;
        private System.Windows.Forms.Panel DOElementContainer;
    }
}