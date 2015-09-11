﻿namespace Tail
{
    partial class FilterConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterConfigForm));
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelFilterDescription = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.listBoxFilterItems = new System.Windows.Forms.ListBox();
            this.listBoxFilterFolders = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonSaveFilter = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxSubtleExample = new System.Windows.Forms.TextBox();
            this.textBoxSubtleRegex = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxGrayExample = new System.Windows.Forms.TextBox();
            this.textBoxBlueExample = new System.Windows.Forms.TextBox();
            this.textBoxGreenExample = new System.Windows.Forms.TextBox();
            this.textBoxYellowExample = new System.Windows.Forms.TextBox();
            this.textBoxRedExample = new System.Windows.Forms.TextBox();
            this.textBoxYellowRegex = new System.Windows.Forms.TextBox();
            this.textBoxBlueRegex = new System.Windows.Forms.TextBox();
            this.textBoxGrayRegex = new System.Windows.Forms.TextBox();
            this.textBoxGreenRegex = new System.Windows.Forms.TextBox();
            this.textBoxRedRegex = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTrimFrom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTrimTo = new System.Windows.Forms.TextBox();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(416, 345);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 30;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(404, 283);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 31;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(335, 345);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 32;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(495, 339);
            this.tabControl1.TabIndex = 35;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(487, 313);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Predefined Filters";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label11.Location = new System.Drawing.Point(9, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(435, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Note, your selection will overwrite the values in the Manual Configuration tab wh" +
    "en clicked.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelFilterDescription);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.listBoxFilterItems);
            this.groupBox3.Controls.Add(this.listBoxFilterFolders);
            this.groupBox3.Location = new System.Drawing.Point(6, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(471, 267);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Filters ";
            // 
            // labelFilterDescription
            // 
            this.labelFilterDescription.AutoSize = true;
            this.labelFilterDescription.Location = new System.Drawing.Point(75, 243);
            this.labelFilterDescription.Name = "labelFilterDescription";
            this.labelFilterDescription.Size = new System.Drawing.Size(148, 13);
            this.labelFilterDescription.TabIndex = 3;
            this.labelFilterDescription.Text = "This is an example description";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(6, 243);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Description:";
            // 
            // listBoxFilterItems
            // 
            this.listBoxFilterItems.FormattingEnabled = true;
            this.listBoxFilterItems.Location = new System.Drawing.Point(234, 19);
            this.listBoxFilterItems.Name = "listBoxFilterItems";
            this.listBoxFilterItems.Size = new System.Drawing.Size(231, 212);
            this.listBoxFilterItems.TabIndex = 1;
            this.listBoxFilterItems.SelectedIndexChanged += new System.EventHandler(this.listBoxFilterItems_SelectedIndexChanged);
            // 
            // listBoxFilterFolders
            // 
            this.listBoxFilterFolders.FormattingEnabled = true;
            this.listBoxFilterFolders.Location = new System.Drawing.Point(6, 19);
            this.listBoxFilterFolders.Name = "listBoxFilterFolders";
            this.listBoxFilterFolders.Size = new System.Drawing.Size(222, 212);
            this.listBoxFilterFolders.TabIndex = 0;
            this.listBoxFilterFolders.SelectedIndexChanged += new System.EventHandler(this.listBoxFilterFolders_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.buttonSaveFilter);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.buttonClear);
            this.tabPage2.Controls.Add(this.textBoxTrimFrom);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.textBoxTrimTo);
            this.tabPage2.Controls.Add(this.textBoxFilter);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(487, 313);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Manual Configuration";
            // 
            // buttonSaveFilter
            // 
            this.buttonSaveFilter.Location = new System.Drawing.Point(323, 283);
            this.buttonSaveFilter.Name = "buttonSaveFilter";
            this.buttonSaveFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveFilter.TabIndex = 51;
            this.buttonSaveFilter.Text = "Save";
            this.buttonSaveFilter.UseVisualStyleBackColor = true;
            this.buttonSaveFilter.Click += new System.EventHandler(this.buttonSaveFilter_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(3, 288);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(231, 13);
            this.label10.TabIndex = 50;
            this.label10.Text = "All fields accept plain text or regular expressions";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxSubtleExample);
            this.groupBox1.Controls.Add(this.textBoxSubtleRegex);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.textBoxGrayExample);
            this.groupBox1.Controls.Add(this.textBoxBlueExample);
            this.groupBox1.Controls.Add(this.textBoxGreenExample);
            this.groupBox1.Controls.Add(this.textBoxYellowExample);
            this.groupBox1.Controls.Add(this.textBoxRedExample);
            this.groupBox1.Controls.Add(this.textBoxYellowRegex);
            this.groupBox1.Controls.Add(this.textBoxBlueRegex);
            this.groupBox1.Controls.Add(this.textBoxGrayRegex);
            this.groupBox1.Controls.Add(this.textBoxGreenRegex);
            this.groupBox1.Controls.Add(this.textBoxRedRegex);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(473, 190);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Highlighting ";
            // 
            // textBoxSubtleExample
            // 
            this.textBoxSubtleExample.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSubtleExample.Location = new System.Drawing.Point(333, 156);
            this.textBoxSubtleExample.Name = "textBoxSubtleExample";
            this.textBoxSubtleExample.Size = new System.Drawing.Size(121, 22);
            this.textBoxSubtleExample.TabIndex = 18;
            this.textBoxSubtleExample.Text = "Example Text";
            // 
            // textBoxSubtleRegex
            // 
            this.textBoxSubtleRegex.Location = new System.Drawing.Point(56, 158);
            this.textBoxSubtleRegex.Name = "textBoxSubtleRegex";
            this.textBoxSubtleRegex.Size = new System.Drawing.Size(271, 20);
            this.textBoxSubtleRegex.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 161);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Subtle:";
            // 
            // textBoxGrayExample
            // 
            this.textBoxGrayExample.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGrayExample.Location = new System.Drawing.Point(333, 131);
            this.textBoxGrayExample.Name = "textBoxGrayExample";
            this.textBoxGrayExample.Size = new System.Drawing.Size(121, 22);
            this.textBoxGrayExample.TabIndex = 15;
            this.textBoxGrayExample.Text = "Example Text";
            // 
            // textBoxBlueExample
            // 
            this.textBoxBlueExample.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBlueExample.Location = new System.Drawing.Point(333, 105);
            this.textBoxBlueExample.Name = "textBoxBlueExample";
            this.textBoxBlueExample.Size = new System.Drawing.Size(121, 22);
            this.textBoxBlueExample.TabIndex = 14;
            this.textBoxBlueExample.Text = "Example Text";
            // 
            // textBoxGreenExample
            // 
            this.textBoxGreenExample.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGreenExample.Location = new System.Drawing.Point(333, 79);
            this.textBoxGreenExample.Name = "textBoxGreenExample";
            this.textBoxGreenExample.Size = new System.Drawing.Size(121, 22);
            this.textBoxGreenExample.TabIndex = 13;
            this.textBoxGreenExample.Text = "Example Text";
            // 
            // textBoxYellowExample
            // 
            this.textBoxYellowExample.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxYellowExample.Location = new System.Drawing.Point(333, 53);
            this.textBoxYellowExample.Name = "textBoxYellowExample";
            this.textBoxYellowExample.Size = new System.Drawing.Size(121, 22);
            this.textBoxYellowExample.TabIndex = 12;
            this.textBoxYellowExample.Text = "Example Text";
            // 
            // textBoxRedExample
            // 
            this.textBoxRedExample.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRedExample.Location = new System.Drawing.Point(333, 27);
            this.textBoxRedExample.Name = "textBoxRedExample";
            this.textBoxRedExample.Size = new System.Drawing.Size(121, 22);
            this.textBoxRedExample.TabIndex = 11;
            this.textBoxRedExample.Text = "Example Text";
            // 
            // textBoxYellowRegex
            // 
            this.textBoxYellowRegex.Location = new System.Drawing.Point(56, 54);
            this.textBoxYellowRegex.Name = "textBoxYellowRegex";
            this.textBoxYellowRegex.Size = new System.Drawing.Size(271, 20);
            this.textBoxYellowRegex.TabIndex = 10;
            // 
            // textBoxBlueRegex
            // 
            this.textBoxBlueRegex.Location = new System.Drawing.Point(56, 106);
            this.textBoxBlueRegex.Name = "textBoxBlueRegex";
            this.textBoxBlueRegex.Size = new System.Drawing.Size(271, 20);
            this.textBoxBlueRegex.TabIndex = 9;
            // 
            // textBoxGrayRegex
            // 
            this.textBoxGrayRegex.Location = new System.Drawing.Point(56, 132);
            this.textBoxGrayRegex.Name = "textBoxGrayRegex";
            this.textBoxGrayRegex.Size = new System.Drawing.Size(271, 20);
            this.textBoxGrayRegex.TabIndex = 8;
            // 
            // textBoxGreenRegex
            // 
            this.textBoxGreenRegex.Location = new System.Drawing.Point(56, 80);
            this.textBoxGreenRegex.Name = "textBoxGreenRegex";
            this.textBoxGreenRegex.Size = new System.Drawing.Size(271, 20);
            this.textBoxGreenRegex.TabIndex = 6;
            // 
            // textBoxRedRegex
            // 
            this.textBoxRedRegex.Location = new System.Drawing.Point(56, 28);
            this.textBoxRedRegex.Name = "textBoxRedRegex";
            this.textBoxRedRegex.Size = new System.Drawing.Size(271, 20);
            this.textBoxRedRegex.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Gray:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Blue:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Green:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Yellow:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Red:";
            // 
            // textBoxTrimFrom
            // 
            this.textBoxTrimFrom.Location = new System.Drawing.Point(87, 61);
            this.textBoxTrimFrom.Name = "textBoxTrimFrom";
            this.textBoxTrimFrom.Size = new System.Drawing.Size(374, 20);
            this.textBoxTrimFrom.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Trim From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Trim To:";
            // 
            // textBoxTrimTo
            // 
            this.textBoxTrimTo.Location = new System.Drawing.Point(87, 35);
            this.textBoxTrimTo.Name = "textBoxTrimTo";
            this.textBoxTrimTo.Size = new System.Drawing.Size(374, 20);
            this.textBoxTrimTo.TabIndex = 45;
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(87, 9);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(374, 20);
            this.textBoxFilter.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Filter:";
            // 
            // FilterConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 375);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FilterConfigForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filter Configuration";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxGrayExample;
        private System.Windows.Forms.TextBox textBoxBlueExample;
        private System.Windows.Forms.TextBox textBoxGreenExample;
        private System.Windows.Forms.TextBox textBoxYellowExample;
        private System.Windows.Forms.TextBox textBoxRedExample;
        private System.Windows.Forms.TextBox textBoxYellowRegex;
        private System.Windows.Forms.TextBox textBoxBlueRegex;
        private System.Windows.Forms.TextBox textBoxGrayRegex;
        private System.Windows.Forms.TextBox textBoxGreenRegex;
        private System.Windows.Forms.TextBox textBoxRedRegex;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTrimFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTrimTo;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBoxFilterItems;
        private System.Windows.Forms.ListBox listBoxFilterFolders;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelFilterDescription;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxSubtleExample;
        private System.Windows.Forms.TextBox textBoxSubtleRegex;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button buttonSaveFilter;
    }
}