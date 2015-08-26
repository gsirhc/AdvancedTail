namespace Tail
{
    partial class TailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TailForm));
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.buttonTailFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.checkBoxEnableFilter = new System.Windows.Forms.CheckBox();
            this.textBoxTrimTo = new System.Windows.Forms.TextBox();
            this.checkBoxWordWrap = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoScroll = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxTrimFrom = new System.Windows.Forms.TextBox();
            this.checkBoxEnableTrim = new System.Windows.Forms.CheckBox();
            this.checkBoxRunAtStartup = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxFile
            // 
            this.textBoxFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFile.Location = new System.Drawing.Point(92, 12);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.Size = new System.Drawing.Size(660, 20);
            this.textBoxFile.TabIndex = 1;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxLog.DetectUrls = false;
            this.richTextBoxLog.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxLog.Location = new System.Drawing.Point(0, 119);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(879, 450);
            this.richTextBoxLog.TabIndex = 3;
            this.richTextBoxLog.Text = "";
            this.richTextBoxLog.WordWrap = false;
            // 
            // buttonTailFile
            // 
            this.buttonTailFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTailFile.Location = new System.Drawing.Point(758, 10);
            this.buttonTailFile.Name = "buttonTailFile";
            this.buttonTailFile.Size = new System.Drawing.Size(109, 23);
            this.buttonTailFile.TabIndex = 4;
            this.buttonTailFile.Text = "Tail";
            this.buttonTailFile.UseVisualStyleBackColor = true;
            this.buttonTailFile.Click += new System.EventHandler(this.buttonTailFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Regex Filter:";
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(758, 90);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(109, 23);
            this.buttonStop.TabIndex = 13;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilter.Location = new System.Drawing.Point(92, 38);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(558, 20);
            this.textBoxFilter.TabIndex = 14;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(12, 90);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(109, 23);
            this.buttonClear.TabIndex = 15;
            this.buttonClear.Text = "Clear Display";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefresh.Enabled = false;
            this.buttonRefresh.Location = new System.Drawing.Point(758, 63);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(109, 23);
            this.buttonRefresh.TabIndex = 16;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonTailFile_Click);
            // 
            // checkBoxEnableFilter
            // 
            this.checkBoxEnableFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEnableFilter.AutoSize = true;
            this.checkBoxEnableFilter.Checked = true;
            this.checkBoxEnableFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnableFilter.Location = new System.Drawing.Point(656, 40);
            this.checkBoxEnableFilter.Name = "checkBoxEnableFilter";
            this.checkBoxEnableFilter.Size = new System.Drawing.Size(84, 17);
            this.checkBoxEnableFilter.TabIndex = 17;
            this.checkBoxEnableFilter.Text = "Enable Filter";
            this.checkBoxEnableFilter.UseVisualStyleBackColor = true;
            this.checkBoxEnableFilter.CheckedChanged += new System.EventHandler(this.checkBoxEnableFilter_CheckedChanged);
            // 
            // textBoxTrimTo
            // 
            this.textBoxTrimTo.Location = new System.Drawing.Point(92, 64);
            this.textBoxTrimTo.Name = "textBoxTrimTo";
            this.textBoxTrimTo.Size = new System.Drawing.Size(233, 20);
            this.textBoxTrimTo.TabIndex = 18;
            // 
            // checkBoxWordWrap
            // 
            this.checkBoxWordWrap.AutoSize = true;
            this.checkBoxWordWrap.Location = new System.Drawing.Point(127, 94);
            this.checkBoxWordWrap.Name = "checkBoxWordWrap";
            this.checkBoxWordWrap.Size = new System.Drawing.Size(81, 17);
            this.checkBoxWordWrap.TabIndex = 20;
            this.checkBoxWordWrap.Text = "Word Wrap";
            this.checkBoxWordWrap.UseVisualStyleBackColor = true;
            this.checkBoxWordWrap.CheckedChanged += new System.EventHandler(this.checkBoxWordWrap_CheckedChanged);
            // 
            // checkBoxAutoScroll
            // 
            this.checkBoxAutoScroll.AutoSize = true;
            this.checkBoxAutoScroll.Checked = true;
            this.checkBoxAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoScroll.Location = new System.Drawing.Point(214, 94);
            this.checkBoxAutoScroll.Name = "checkBoxAutoScroll";
            this.checkBoxAutoScroll.Size = new System.Drawing.Size(77, 17);
            this.checkBoxAutoScroll.TabIndex = 21;
            this.checkBoxAutoScroll.Text = "Auto Scroll";
            this.checkBoxAutoScroll.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Trim To Regex:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(331, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Trim From Regex:";
            // 
            // textBoxTrimFrom
            // 
            this.textBoxTrimFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTrimFrom.Location = new System.Drawing.Point(427, 64);
            this.textBoxTrimFrom.Name = "textBoxTrimFrom";
            this.textBoxTrimFrom.Size = new System.Drawing.Size(223, 20);
            this.textBoxTrimFrom.TabIndex = 23;
            // 
            // checkBoxEnableTrim
            // 
            this.checkBoxEnableTrim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEnableTrim.AutoSize = true;
            this.checkBoxEnableTrim.Checked = true;
            this.checkBoxEnableTrim.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnableTrim.Location = new System.Drawing.Point(656, 67);
            this.checkBoxEnableTrim.Name = "checkBoxEnableTrim";
            this.checkBoxEnableTrim.Size = new System.Drawing.Size(82, 17);
            this.checkBoxEnableTrim.TabIndex = 24;
            this.checkBoxEnableTrim.Text = "Enable Trim";
            this.checkBoxEnableTrim.UseVisualStyleBackColor = true;
            this.checkBoxEnableTrim.CheckedChanged += new System.EventHandler(this.checkBoxEnableTrim_CheckedChanged);
            // 
            // checkBoxRunAtStartup
            // 
            this.checkBoxRunAtStartup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxRunAtStartup.AutoSize = true;
            this.checkBoxRunAtStartup.Location = new System.Drawing.Point(766, 37);
            this.checkBoxRunAtStartup.Name = "checkBoxRunAtStartup";
            this.checkBoxRunAtStartup.Size = new System.Drawing.Size(95, 17);
            this.checkBoxRunAtStartup.TabIndex = 25;
            this.checkBoxRunAtStartup.Text = "Run at Startup";
            this.checkBoxRunAtStartup.UseVisualStyleBackColor = true;
            this.checkBoxRunAtStartup.CheckedChanged += new System.EventHandler(this.checkBoxRunAtStartup_CheckedChanged);
            // 
            // TailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 569);
            this.Controls.Add(this.checkBoxRunAtStartup);
            this.Controls.Add(this.checkBoxEnableTrim);
            this.Controls.Add(this.textBoxTrimFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBoxAutoScroll);
            this.Controls.Add(this.checkBoxWordWrap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxTrimTo);
            this.Controls.Add(this.checkBoxEnableFilter);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTailFile);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.textBoxFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TailForm";
            this.Text = "Tail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Button buttonTailFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.CheckBox checkBoxEnableFilter;
        private System.Windows.Forms.TextBox textBoxTrimTo;
        private System.Windows.Forms.CheckBox checkBoxWordWrap;
        private System.Windows.Forms.CheckBox checkBoxAutoScroll;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxTrimFrom;
        private System.Windows.Forms.CheckBox checkBoxEnableTrim;
        private System.Windows.Forms.CheckBox checkBoxRunAtStartup;
    }
}

