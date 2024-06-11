namespace Document_Office.Net
{
    partial class StartWindow
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

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartWindow));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCloseProgram = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dialogStartWindow = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.minusTen = new System.Windows.Forms.Button();
            this.minusOne = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.countFilesLabel = new System.Windows.Forms.Label();
            this.plusOne = new System.Windows.Forms.Button();
            this.plusTen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelFileName = new System.Windows.Forms.Label();
            this.LocationButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.dialogStartWindow.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.White;
            this.MainPanel.Controls.Add(this.dialogStartWindow);
            this.MainPanel.Controls.Add(this.panel1);
            this.MainPanel.Controls.Add(this.pictureBox1);
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(971, 549);
            this.MainPanel.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.buttonCloseProgram);
            this.panel1.Controls.Add(this.buttonStart);
            this.panel1.Location = new System.Drawing.Point(0, 321);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 226);
            this.panel1.TabIndex = 2;
            // 
            // buttonCloseProgram
            // 
            this.buttonCloseProgram.FlatAppearance.BorderSize = 0;
            this.buttonCloseProgram.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCloseProgram.Location = new System.Drawing.Point(419, 133);
            this.buttonCloseProgram.Name = "buttonCloseProgram";
            this.buttonCloseProgram.Size = new System.Drawing.Size(136, 38);
            this.buttonCloseProgram.TabIndex = 1;
            this.buttonCloseProgram.Text = "Zamknij";
            this.buttonCloseProgram.UseVisualStyleBackColor = true;
            this.buttonCloseProgram.Click += new System.EventHandler(this.buttonCloseProgram_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(2)))), ((int)(((byte)(88)))));
            this.buttonStart.FlatAppearance.BorderSize = 0;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonStart.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonStart.Location = new System.Drawing.Point(341, 34);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(293, 55);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Rozpocznij";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(397, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pictureBox1.Size = new System.Drawing.Size(184, 183);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // dialogStartWindow
            // 
            this.dialogStartWindow.BackColor = System.Drawing.Color.Gainsboro;
            this.dialogStartWindow.Controls.Add(this.buttonCancel);
            this.dialogStartWindow.Controls.Add(this.buttonNext);
            this.dialogStartWindow.Controls.Add(this.LocationButton);
            this.dialogStartWindow.Controls.Add(this.panel4);
            this.dialogStartWindow.Controls.Add(this.label2);
            this.dialogStartWindow.Controls.Add(this.plusTen);
            this.dialogStartWindow.Controls.Add(this.plusOne);
            this.dialogStartWindow.Controls.Add(this.panel3);
            this.dialogStartWindow.Controls.Add(this.minusOne);
            this.dialogStartWindow.Controls.Add(this.minusTen);
            this.dialogStartWindow.Controls.Add(this.label1);
            this.dialogStartWindow.Location = new System.Drawing.Point(0, 0);
            this.dialogStartWindow.Name = "dialogStartWindow";
            this.dialogStartWindow.Size = new System.Drawing.Size(971, 547);
            this.dialogStartWindow.TabIndex = 3;
            this.dialogStartWindow.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(65, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ilość kopii";
            // 
            // minusTen
            // 
            this.minusTen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(2)))), ((int)(((byte)(88)))));
            this.minusTen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minusTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.minusTen.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.minusTen.Location = new System.Drawing.Point(72, 171);
            this.minusTen.Name = "minusTen";
            this.minusTen.Size = new System.Drawing.Size(38, 30);
            this.minusTen.TabIndex = 19;
            this.minusTen.Text = "-10";
            this.minusTen.UseVisualStyleBackColor = false;
            this.minusTen.Click += new System.EventHandler(this.minusTen_Click);
            // 
            // minusOne
            // 
            this.minusOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(2)))), ((int)(((byte)(88)))));
            this.minusOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minusOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.minusOne.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.minusOne.Location = new System.Drawing.Point(116, 171);
            this.minusOne.Name = "minusOne";
            this.minusOne.Size = new System.Drawing.Size(30, 30);
            this.minusOne.TabIndex = 20;
            this.minusOne.Text = "-1";
            this.minusOne.UseVisualStyleBackColor = false;
            this.minusOne.Click += new System.EventHandler(this.minusOne_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.countFilesLabel);
            this.panel3.Location = new System.Drawing.Point(161, 146);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(87, 79);
            this.panel3.TabIndex = 21;
            // 
            // countFilesLabel
            // 
            this.countFilesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.countFilesLabel.AutoSize = true;
            this.countFilesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.countFilesLabel.Location = new System.Drawing.Point(29, 23);
            this.countFilesLabel.Name = "countFilesLabel";
            this.countFilesLabel.Size = new System.Drawing.Size(31, 33);
            this.countFilesLabel.TabIndex = 0;
            this.countFilesLabel.Text = "0";
            // 
            // plusOne
            // 
            this.plusOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(2)))), ((int)(((byte)(88)))));
            this.plusOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.plusOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.plusOne.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.plusOne.Location = new System.Drawing.Point(265, 171);
            this.plusOne.Name = "plusOne";
            this.plusOne.Size = new System.Drawing.Size(34, 30);
            this.plusOne.TabIndex = 17;
            this.plusOne.Text = "+1";
            this.plusOne.UseVisualStyleBackColor = false;
            this.plusOne.Click += new System.EventHandler(this.plusOne_Click);
            // 
            // plusTen
            // 
            this.plusTen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(2)))), ((int)(((byte)(88)))));
            this.plusTen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.plusTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.plusTen.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.plusTen.Location = new System.Drawing.Point(308, 171);
            this.plusTen.Name = "plusTen";
            this.plusTen.Size = new System.Drawing.Size(40, 30);
            this.plusTen.TabIndex = 22;
            this.plusTen.Text = "+10";
            this.plusTen.UseVisualStyleBackColor = false;
            this.plusTen.Click += new System.EventHandler(this.plusTen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(65, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 24);
            this.label2.TabIndex = 23;
            this.label2.Text = "Ścieżka do pliku";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.labelFileName);
            this.panel4.Location = new System.Drawing.Point(69, 321);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(428, 40);
            this.panel4.TabIndex = 24;
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFileName.Location = new System.Drawing.Point(3, 8);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(112, 24);
            this.labelFileName.TabIndex = 0;
            this.labelFileName.Text = "Wybierz Plik";
            // 
            // LocationButton
            // 
            this.LocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LocationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LocationButton.Location = new System.Drawing.Point(507, 321);
            this.LocationButton.Name = "LocationButton";
            this.LocationButton.Size = new System.Drawing.Size(46, 40);
            this.LocationButton.TabIndex = 10;
            this.LocationButton.Text = "...";
            this.LocationButton.UseVisualStyleBackColor = true;
            this.LocationButton.Click += new System.EventHandler(this.LocationButton_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCancel.Location = new System.Drawing.Point(639, 468);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(109, 38);
            this.buttonCancel.TabIndex = 26;
            this.buttonCancel.Text = "Anuluj";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(2)))), ((int)(((byte)(88)))));
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonNext.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonNext.Location = new System.Drawing.Point(807, 468);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(107, 38);
            this.buttonNext.TabIndex = 25;
            this.buttonNext.Text = "Dalej";
            this.buttonNext.UseVisualStyleBackColor = false;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // StartWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(971, 547);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MainPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.dialogStartWindow.ResumeLayout(false);
            this.dialogStartWindow.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonCloseProgram;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel dialogStartWindow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button minusTen;
        private System.Windows.Forms.Button minusOne;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label countFilesLabel;
        private System.Windows.Forms.Button plusOne;
        private System.Windows.Forms.Button plusTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Button LocationButton;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonNext;
    }
}

