namespace OOP_GP
{
    partial class Form1
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
            this.reviewFilesButton = new System.Windows.Forms.Button();
            this.baseFilesLabel = new System.Windows.Forms.Label();
            this.reviewFilesLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.submitButton = new System.Windows.Forms.Button();
            this.baseFilesButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reviewFilesButton
            // 
            this.reviewFilesButton.Location = new System.Drawing.Point(45, 85);
            this.reviewFilesButton.Name = "reviewFilesButton";
            this.reviewFilesButton.Size = new System.Drawing.Size(86, 41);
            this.reviewFilesButton.TabIndex = 1;
            this.reviewFilesButton.Text = "Select files to be reviewed";
            this.reviewFilesButton.UseVisualStyleBackColor = true;
            this.reviewFilesButton.Click += new System.EventHandler(this.reviewFilesButton_Click);
            // 
            // baseFilesLabel
            // 
            this.baseFilesLabel.AutoSize = true;
            this.baseFilesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.baseFilesLabel.Location = new System.Drawing.Point(137, 52);
            this.baseFilesLabel.Name = "baseFilesLabel";
            this.baseFilesLabel.Size = new System.Drawing.Size(84, 15);
            this.baseFilesLabel.TabIndex = 2;
            this.baseFilesLabel.Text = "(None selected)";
            // 
            // reviewFilesLabel
            // 
            this.reviewFilesLabel.AutoSize = true;
            this.reviewFilesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reviewFilesLabel.Location = new System.Drawing.Point(137, 99);
            this.reviewFilesLabel.Name = "reviewFilesLabel";
            this.reviewFilesLabel.Size = new System.Drawing.Size(84, 15);
            this.reviewFilesLabel.TabIndex = 0;
            this.reviewFilesLabel.Text = "(None selected)";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(265, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Menu;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.optionsToolStripMenuItem.Text = "Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.menuStrip1_Click);
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(45, 132);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(88, 36);
            this.submitButton.TabIndex = 2;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // baseFilesButton
            // 
            this.baseFilesButton.Location = new System.Drawing.Point(45, 38);
            this.baseFilesButton.Name = "baseFilesButton";
            this.baseFilesButton.Size = new System.Drawing.Size(86, 41);
            this.baseFilesButton.TabIndex = 0;
            this.baseFilesButton.Text = "Select base code files";
            this.baseFilesButton.UseVisualStyleBackColor = true;
            this.baseFilesButton.Click += new System.EventHandler(this.baseFilesButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 190);
            this.Controls.Add(this.baseFilesButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.reviewFilesLabel);
            this.Controls.Add(this.baseFilesLabel);
            this.Controls.Add(this.reviewFilesButton);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MOSS Entry";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button reviewFilesButton;
        private System.Windows.Forms.Label baseFilesLabel;
        private System.Windows.Forms.Label reviewFilesLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button baseFilesButton;
    }
}

