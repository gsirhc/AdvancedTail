﻿namespace Tail
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileInNewWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runAtStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.recentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.demoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoScrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordWrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLineNumbersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.clearDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableTrimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonEnableTrim = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEnableFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFilter = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTrim = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRead = new System.Windows.Forms.ToolStripStatusLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxLoadAll = new System.Windows.Forms.CheckBox();
            this.numericUpDownLoadLast = new System.Windows.Forms.NumericUpDown();
            this.toolStripStatusLabelTotalLines = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelLinesDisplayed = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelLinesIgnored = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLoadLast)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFile
            // 
            this.textBoxFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFile.Location = new System.Drawing.Point(173, 53);
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.ReadOnly = true;
            this.textBoxFile.Size = new System.Drawing.Size(588, 20);
            this.textBoxFile.TabIndex = 1;
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxLog.DetectUrls = false;
            this.richTextBoxLog.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxLog.Location = new System.Drawing.Point(0, 78);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.Size = new System.Drawing.Size(770, 464);
            this.richTextBoxLog.TabIndex = 3;
            this.richTextBoxLog.Text = "";
            this.richTextBoxLog.WordWrap = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.tailToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(770, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.openFileInNewWindowToolStripMenuItem,
            this.runAtStartupToolStripMenuItem,
            this.toolStripSeparator7,
            this.recentFilesToolStripMenuItem,
            this.toolStripSeparator3,
            this.demoToolStripMenuItem,
            this.toolStripSeparator8,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Image = global::Tail.Properties.Resources.folder_page;
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.openFileToolStripMenuItem.Text = "Open File...";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonOpenFile_Click);
            // 
            // openFileInNewWindowToolStripMenuItem
            // 
            this.openFileInNewWindowToolStripMenuItem.Name = "openFileInNewWindowToolStripMenuItem";
            this.openFileInNewWindowToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.openFileInNewWindowToolStripMenuItem.Text = "Open File in New Window...";
            this.openFileInNewWindowToolStripMenuItem.Click += new System.EventHandler(this.openFileInNewWindowToolStripMenuItem_Click);
            // 
            // runAtStartupToolStripMenuItem
            // 
            this.runAtStartupToolStripMenuItem.CheckOnClick = true;
            this.runAtStartupToolStripMenuItem.Name = "runAtStartupToolStripMenuItem";
            this.runAtStartupToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.runAtStartupToolStripMenuItem.Text = "Run Last File at Startup";
            this.runAtStartupToolStripMenuItem.Click += new System.EventHandler(this.runAtStartupToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(217, 6);
            // 
            // recentFilesToolStripMenuItem
            // 
            this.recentFilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noFilesToolStripMenuItem});
            this.recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
            this.recentFilesToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.recentFilesToolStripMenuItem.Text = "Recent Files";
            this.recentFilesToolStripMenuItem.MouseHover += new System.EventHandler(this.recentFilesToolStripMenuItem_MouseHover);
            // 
            // noFilesToolStripMenuItem
            // 
            this.noFilesToolStripMenuItem.Name = "noFilesToolStripMenuItem";
            this.noFilesToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.noFilesToolStripMenuItem.Text = "No Files";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(217, 6);
            // 
            // demoToolStripMenuItem
            // 
            this.demoToolStripMenuItem.Name = "demoToolStripMenuItem";
            this.demoToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.demoToolStripMenuItem.Text = "Demo...";
            this.demoToolStripMenuItem.Click += new System.EventHandler(this.demoToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(217, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoScrollToolStripMenuItem,
            this.wordWrapToolStripMenuItem,
            this.showLineNumbersToolStripMenuItem,
            this.toolStripSeparator6,
            this.clearDisplayToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // autoScrollToolStripMenuItem
            // 
            this.autoScrollToolStripMenuItem.Checked = true;
            this.autoScrollToolStripMenuItem.CheckOnClick = true;
            this.autoScrollToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoScrollToolStripMenuItem.Name = "autoScrollToolStripMenuItem";
            this.autoScrollToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.autoScrollToolStripMenuItem.Text = "Auto Scroll";
            // 
            // wordWrapToolStripMenuItem
            // 
            this.wordWrapToolStripMenuItem.CheckOnClick = true;
            this.wordWrapToolStripMenuItem.Name = "wordWrapToolStripMenuItem";
            this.wordWrapToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.wordWrapToolStripMenuItem.Text = "Word Wrap";
            this.wordWrapToolStripMenuItem.Click += new System.EventHandler(this.wordWrapToolStripMenuItem_Click);
            // 
            // showLineNumbersToolStripMenuItem
            // 
            this.showLineNumbersToolStripMenuItem.CheckOnClick = true;
            this.showLineNumbersToolStripMenuItem.Name = "showLineNumbersToolStripMenuItem";
            this.showLineNumbersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showLineNumbersToolStripMenuItem.Text = "Show Line Numbers";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(177, 6);
            // 
            // clearDisplayToolStripMenuItem
            // 
            this.clearDisplayToolStripMenuItem.Name = "clearDisplayToolStripMenuItem";
            this.clearDisplayToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearDisplayToolStripMenuItem.Text = "Clear Display";
            this.clearDisplayToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonClear_Click);
            // 
            // tailToolStripMenuItem
            // 
            this.tailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator5,
            this.filterToolStripMenuItem,
            this.enableFilterToolStripMenuItem,
            this.enableTrimToolStripMenuItem});
            this.tailToolStripMenuItem.Name = "tailToolStripMenuItem";
            this.tailToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.tailToolStripMenuItem.Text = "Tail";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Image = global::Tail.Properties.Resources.resultset_next;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonStart_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Image = global::Tail.Properties.Resources.stop;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonStop_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::Tail.Properties.Resources.arrow_refresh;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(135, 6);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Image = global::Tail.Properties.Resources.application_form_edit;
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.filterToolStripMenuItem.Text = "Filter...";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonFilter_Click);
            // 
            // enableFilterToolStripMenuItem
            // 
            this.enableFilterToolStripMenuItem.Checked = true;
            this.enableFilterToolStripMenuItem.CheckOnClick = true;
            this.enableFilterToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableFilterToolStripMenuItem.Name = "enableFilterToolStripMenuItem";
            this.enableFilterToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.enableFilterToolStripMenuItem.Text = "Enable Filter";
            this.enableFilterToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonEnableFilter_Click);
            // 
            // enableTrimToolStripMenuItem
            // 
            this.enableTrimToolStripMenuItem.Checked = true;
            this.enableTrimToolStripMenuItem.CheckOnClick = true;
            this.enableTrimToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableTrimToolStripMenuItem.Name = "enableTrimToolStripMenuItem";
            this.enableTrimToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.enableTrimToolStripMenuItem.Text = "Enable Trim";
            this.enableTrimToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonEnableTrim_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpenFile,
            this.toolStripButtonFilter,
            this.toolStripSeparator1,
            this.toolStripButtonStart,
            this.toolStripButtonStop,
            this.toolStripButtonRefresh,
            this.toolStripButtonClear,
            this.toolStripSeparator2,
            this.toolStripButtonEnableTrim,
            this.toolStripButtonEnableFilter,
            this.toolStripSeparator4,
            this.toolStripTextBoxSearch,
            this.toolStripButtonSearch});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(770, 25);
            this.toolStrip1.TabIndex = 27;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonOpenFile
            // 
            this.toolStripButtonOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOpenFile.Image = global::Tail.Properties.Resources.folder_page;
            this.toolStripButtonOpenFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpenFile.Name = "toolStripButtonOpenFile";
            this.toolStripButtonOpenFile.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonOpenFile.Text = "Open File...";
            this.toolStripButtonOpenFile.ToolTipText = "Open File...";
            this.toolStripButtonOpenFile.Click += new System.EventHandler(this.toolStripButtonOpenFile_Click);
            // 
            // toolStripButtonFilter
            // 
            this.toolStripButtonFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFilter.Image = global::Tail.Properties.Resources.application_form_edit;
            this.toolStripButtonFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFilter.Name = "toolStripButtonFilter";
            this.toolStripButtonFilter.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFilter.Text = "Filter...";
            this.toolStripButtonFilter.Click += new System.EventHandler(this.toolStripButtonFilter_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonStart
            // 
            this.toolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStart.Image = global::Tail.Properties.Resources.resultset_next;
            this.toolStripButtonStart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStart.Name = "toolStripButtonStart";
            this.toolStripButtonStart.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStart.Text = "Start Tail";
            this.toolStripButtonStart.Click += new System.EventHandler(this.toolStripButtonStart_Click);
            // 
            // toolStripButtonStop
            // 
            this.toolStripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStop.Image = global::Tail.Properties.Resources.stop;
            this.toolStripButtonStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStop.Text = "Stop Tail";
            this.toolStripButtonStop.Click += new System.EventHandler(this.toolStripButtonStop_Click);
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Image = global::Tail.Properties.Resources.arrow_refresh;
            this.toolStripButtonRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRefresh.Text = "Refresh";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripButtonClear
            // 
            this.toolStripButtonClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClear.Image = global::Tail.Properties.Resources.page_white;
            this.toolStripButtonClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClear.Name = "toolStripButtonClear";
            this.toolStripButtonClear.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonClear.Text = "Clear Display (not file)";
            this.toolStripButtonClear.Click += new System.EventHandler(this.toolStripButtonClear_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonEnableTrim
            // 
            this.toolStripButtonEnableTrim.Checked = true;
            this.toolStripButtonEnableTrim.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonEnableTrim.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEnableTrim.Image = global::Tail.Properties.Resources.cut_red;
            this.toolStripButtonEnableTrim.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonEnableTrim.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEnableTrim.Name = "toolStripButtonEnableTrim";
            this.toolStripButtonEnableTrim.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEnableTrim.Text = "Enable/Disable Trim";
            this.toolStripButtonEnableTrim.Click += new System.EventHandler(this.toolStripButtonEnableTrim_Click);
            // 
            // toolStripButtonEnableFilter
            // 
            this.toolStripButtonEnableFilter.Checked = true;
            this.toolStripButtonEnableFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonEnableFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEnableFilter.Image = global::Tail.Properties.Resources.application_form_delete;
            this.toolStripButtonEnableFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonEnableFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEnableFilter.Name = "toolStripButtonEnableFilter";
            this.toolStripButtonEnableFilter.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEnableFilter.Text = "Enable/Disable Filter";
            this.toolStripButtonEnableFilter.Click += new System.EventHandler(this.toolStripButtonEnableFilter_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBoxSearch
            // 
            this.toolStripTextBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
            this.toolStripTextBoxSearch.Size = new System.Drawing.Size(150, 25);
            // 
            // toolStripButtonSearch
            // 
            this.toolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearch.Image = global::Tail.Properties.Resources.find;
            this.toolStripButtonSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearch.Name = "toolStripButtonSearch";
            this.toolStripButtonSearch.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSearch.Text = "Search displayed contents";
            this.toolStripButtonSearch.Click += new System.EventHandler(this.toolStripButtonSearch_Click);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 545);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(770, 24);
            this.statusStrip1.TabIndex = 28;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Load Last:";
            // 
            // checkBoxLoadAll
            // 
            this.checkBoxLoadAll.AutoSize = true;
            this.checkBoxLoadAll.Location = new System.Drawing.Point(107, 54);
            this.checkBoxLoadAll.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxLoadAll.Name = "checkBoxLoadAll";
            this.checkBoxLoadAll.Size = new System.Drawing.Size(64, 17);
            this.checkBoxLoadAll.TabIndex = 31;
            this.checkBoxLoadAll.Text = "Load All";
            this.checkBoxLoadAll.UseVisualStyleBackColor = true;
            this.checkBoxLoadAll.CheckedChanged += new System.EventHandler(this.checkBoxLoadAll_CheckedChanged);
            // 
            // numericUpDownLoadLast
            // 
            this.numericUpDownLoadLast.Location = new System.Drawing.Point(70, 54);
            this.numericUpDownLoadLast.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownLoadLast.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownLoadLast.Name = "numericUpDownLoadLast";
            this.numericUpDownLoadLast.Size = new System.Drawing.Size(32, 20);
            this.numericUpDownLoadLast.TabIndex = 32;
            this.numericUpDownLoadLast.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLoadLast.ValueChanged += new System.EventHandler(this.numericUpDownLoadLast_ValueChanged);
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
            // TailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 569);
            this.Controls.Add(this.numericUpDownLoadLast);
            this.Controls.Add(this.checkBoxLoadAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.richTextBoxLog);
            this.Controls.Add(this.textBoxFile);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TailForm";
            this.Text = "AdvancedTail";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLoadLast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonStart;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripButton toolStripButtonEnableFilter;
        private System.Windows.Forms.ToolStripButton toolStripButtonEnableTrim;
        private System.Windows.Forms.ToolStripButton toolStripButtonFilter;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem runAtStartupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoScrollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordWrapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableTrimToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem clearDisplayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFilter;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTrim;
        private System.Windows.Forms.ToolStripMenuItem demoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLineNumbersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileInNewWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.ToolStripMenuItem recentFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxLoadAll;
        private System.Windows.Forms.NumericUpDown numericUpDownLoadLast;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRead;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTotalLines;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLinesDisplayed;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLinesIgnored;
    }
}

