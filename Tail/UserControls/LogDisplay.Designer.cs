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
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFilter = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTrim = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRead = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTotalLines = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelLinesDisplayed = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelLinesIgnored = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxLog.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxLog.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(622, 407);
            this.richTextBoxLog.TabIndex = 0;
            this.richTextBoxLog.Text = "";
            this.richTextBoxLog.WordWrap = false;
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
            // 
            // toolStripStatusLabelTrim
            // 
            this.toolStripStatusLabelTrim.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelTrim.Name = "toolStripStatusLabelTrim";
            this.toolStripStatusLabelTrim.Size = new System.Drawing.Size(84, 19);
            this.toolStripStatusLabelTrim.Text = "Trim: Enabled";
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
            this.toolStripStatusLabelTotalLines.Size = new System.Drawing.Size(41, 19);
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
            // LogDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.richTextBoxLog);
            this.Name = "LogDisplay";
            this.Size = new System.Drawing.Size(622, 434);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFilter;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTrim;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRead;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTotalLines;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLinesDisplayed;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLinesIgnored;
    }
}
