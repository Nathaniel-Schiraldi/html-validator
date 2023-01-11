namespace Lab4B
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
            this.fileStatusLabel = new System.Windows.Forms.Label();
            this.openHTMLFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStripFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLoadFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripProcessMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCheckTagsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileContentsListBox = new System.Windows.Forms.ListBox();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileStatusLabel
            // 
            this.fileStatusLabel.AutoSize = true;
            this.fileStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileStatusLabel.Location = new System.Drawing.Point(12, 35);
            this.fileStatusLabel.Name = "fileStatusLabel";
            this.fileStatusLabel.Size = new System.Drawing.Size(154, 24);
            this.fileStatusLabel.TabIndex = 4;
            this.fileStatusLabel.Text = "No File Loaded";
            // 
            // openHTMLFileDialog
            // 
            this.openHTMLFileDialog.FileName = "openFileDialog1";
            // 
            // toolStripFileMenuItem
            // 
            this.toolStripFileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLoadFileMenuItem,
            this.toolStripExitMenuItem});
            this.toolStripFileMenuItem.Name = "toolStripFileMenuItem";
            this.toolStripFileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.toolStripFileMenuItem.Text = "File";
            // 
            // toolStripLoadFileMenuItem
            // 
            this.toolStripLoadFileMenuItem.Name = "toolStripLoadFileMenuItem";
            this.toolStripLoadFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.toolStripLoadFileMenuItem.Size = new System.Drawing.Size(173, 22);
            this.toolStripLoadFileMenuItem.Text = "Load File ...";
            this.toolStripLoadFileMenuItem.Click += new System.EventHandler(this.toolStripLoadFileMenuItem_Click);
            // 
            // toolStripExitMenuItem
            // 
            this.toolStripExitMenuItem.Name = "toolStripExitMenuItem";
            this.toolStripExitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.toolStripExitMenuItem.Size = new System.Drawing.Size(173, 22);
            this.toolStripExitMenuItem.Text = "Exit";
            this.toolStripExitMenuItem.Click += new System.EventHandler(this.toolStripExitMenuItem_Click);
            // 
            // toolStripProcessMenuItem
            // 
            this.toolStripProcessMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripCheckTagsMenuItem});
            this.toolStripProcessMenuItem.Name = "toolStripProcessMenuItem";
            this.toolStripProcessMenuItem.Size = new System.Drawing.Size(59, 20);
            this.toolStripProcessMenuItem.Text = "Process";
            // 
            // toolStripCheckTagsMenuItem
            // 
            this.toolStripCheckTagsMenuItem.Name = "toolStripCheckTagsMenuItem";
            this.toolStripCheckTagsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.toolStripCheckTagsMenuItem.Size = new System.Drawing.Size(175, 22);
            this.toolStripCheckTagsMenuItem.Text = "Check Tags";
            this.toolStripCheckTagsMenuItem.Click += new System.EventHandler(this.toolStripCheckTagsMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripFileMenuItem,
            this.toolStripProcessMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(563, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip3";
            // 
            // fileContentsListBox
            // 
            this.fileContentsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileContentsListBox.FormattingEnabled = true;
            this.fileContentsListBox.ItemHeight = 24;
            this.fileContentsListBox.Location = new System.Drawing.Point(16, 71);
            this.fileContentsListBox.Name = "fileContentsListBox";
            this.fileContentsListBox.Size = new System.Drawing.Size(535, 364);
            this.fileContentsListBox.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 477);
            this.Controls.Add(this.fileContentsListBox);
            this.Controls.Add(this.fileStatusLabel);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "Nathaniel\'s HTML File Checker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label fileStatusLabel;
        private System.Windows.Forms.OpenFileDialog openHTMLFileDialog;
        private System.Windows.Forms.ToolStripMenuItem toolStripFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripLoadFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripProcessMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripCheckTagsMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ListBox fileContentsListBox;
    }
}

