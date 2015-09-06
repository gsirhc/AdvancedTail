namespace Tail.UserControls
{
    partial class LogDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFilter = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTrim = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRead = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTotalLines = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelLinesDisplayed = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelLinesIgnored = new System.Windows.Forms.ToolStripStatusLabel();
            this.scintilla = new ScintillaNET.Scintilla();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStatus,
            this.toolStripStatusLabelFilter,
            this.toolStripStatusLabelTrim,
            this.toolStripStatusLabelRead,
            this.toolStripStatusLabelTotalLines,
            this.toolStripStatusLabelLinesDisplayed,
            this.toolStripStatusLabelLinesIgnored});
            this.statusStrip1.Location = new System.Drawing.Point(0, 410);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(622, 24);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(43, 19);
            this.toolStripStatusLabelStatus.Text = "Ready";
            // 
            // toolStripStatusLabelFilter
            // 
            this.toolStripStatusLabelFilter.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelFilter.Name = "toolStripStatusLabelFilter";
            this.toolStripStatusLabelFilter.Size = new System.Drawing.Size(85, 19);
            this.toolStripStatusLabelFilter.Text = "Filter: Enabled";
            this.toolStripStatusLabelFilter.Click += new System.EventHandler(this.toolStripStatusLabelFilter_Click);
            // 
            // toolStripStatusLabelTrim
            // 
            this.toolStripStatusLabelTrim.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelTrim.Name = "toolStripStatusLabelTrim";
            this.toolStripStatusLabelTrim.Size = new System.Drawing.Size(83, 19);
            this.toolStripStatusLabelTrim.Text = "Trim: Enabled";
            this.toolStripStatusLabelTrim.Click += new System.EventHandler(this.toolStripStatusLabelTrim_Click);
            // 
            // toolStripStatusLabelRead
            // 
            this.toolStripStatusLabelRead.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelRead.Name = "toolStripStatusLabelRead";
            this.toolStripStatusLabelRead.Size = new System.Drawing.Size(52, 19);
            this.toolStripStatusLabelRead.Text = "Waiting";
            // 
            // toolStripStatusLabelTotalLines
            // 
            this.toolStripStatusLabelTotalLines.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelTotalLines.Name = "toolStripStatusLabelTotalLines";
            this.toolStripStatusLabelTotalLines.Size = new System.Drawing.Size(40, 19);
            this.toolStripStatusLabelTotalLines.Text = "Total:";
            // 
            // toolStripStatusLabelLinesDisplayed
            // 
            this.toolStripStatusLabelLinesDisplayed.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelLinesDisplayed.Name = "toolStripStatusLabelLinesDisplayed";
            this.toolStripStatusLabelLinesDisplayed.Size = new System.Drawing.Size(65, 19);
            this.toolStripStatusLabelLinesDisplayed.Text = "Displayed:";
            // 
            // toolStripStatusLabelLinesIgnored
            // 
            this.toolStripStatusLabelLinesIgnored.Name = "toolStripStatusLabelLinesIgnored";
            this.toolStripStatusLabelLinesIgnored.Size = new System.Drawing.Size(51, 19);
            this.toolStripStatusLabelLinesIgnored.Text = "Ignored:";
            // 
            // scintilla
            // 
            this.scintilla.AutomaticFold = ((ScintillaNET.AutomaticFold)(((ScintillaNET.AutomaticFold.Show | ScintillaNET.AutomaticFold.Click) 
            | ScintillaNET.AutomaticFold.Change)));
            this.scintilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintilla.Location = new System.Drawing.Point(0, 0);
            this.scintilla.Name = "scintilla";
            this.scintilla.Size = new System.Drawing.Size(622, 410);
            this.scintilla.TabIndex = 30;
            this.scintilla.UseTabs = false;
            // 
            // LogDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scintilla);
            this.Controls.Add(this.statusStrip1);
            this.Name = "LogDisplay";
            this.Size = new System.Drawing.Size(622, 434);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFilter;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTrim;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRead;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTotalLines;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLinesDisplayed;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLinesIgnored;
        private ScintillaNET.Scintilla scintilla;
    }
}
