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
            this.buttonDeleteFilter = new System.Windows.Forms.Button();
            this.buttonEditFilter = new System.Windows.Forms.Button();
            this.labelFilterDescription = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.listBoxFilterFolders = new System.Windows.Forms.ListBox();
            this.listBoxFilterItems = new System.Windows.Forms.ListBox();
            this.buttonNewFilter = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
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
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxTrimFrom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTrimTo = new System.Windows.Forms.TextBox();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxTrimMiddle = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDeleteFilter
            // 
            this.buttonDeleteFilter.Location = new System.Drawing.Point(395, 64);
            this.buttonDeleteFilter.Name = "buttonDeleteFilter";
            this.buttonDeleteFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteFilter.TabIndex = 9;
            this.buttonDeleteFilter.Text = "Delete";
            this.buttonDeleteFilter.UseVisualStyleBackColor = true;
            this.buttonDeleteFilter.Click += new System.EventHandler(this.buttonDeleteFilter_Click);
            // 
            // buttonEditFilter
            // 
            this.buttonEditFilter.Location = new System.Drawing.Point(395, 35);
            this.buttonEditFilter.Name = "buttonEditFilter";
            this.buttonEditFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonEditFilter.TabIndex = 8;
            this.buttonEditFilter.Text = "Save";
            this.buttonEditFilter.UseVisualStyleBackColor = true;
            this.buttonEditFilter.Click += new System.EventHandler(this.buttonEditFilter_Click);
            // 
            // labelFilterDescription
            // 
            this.labelFilterDescription.AutoSize = true;
            this.labelFilterDescription.Location = new System.Drawing.Point(67, 132);
            this.labelFilterDescription.Name = "labelFilterDescription";
            this.labelFilterDescription.Size = new System.Drawing.Size(148, 13);
            this.labelFilterDescription.TabIndex = 3;
            this.labelFilterDescription.Text = "This is an example description";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Location = new System.Drawing.Point(5, 132);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Description:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Location = new System.Drawing.Point(158, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Configuration:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(5, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Group:";
            // 
            // listBoxFilterFolders
            // 
            this.listBoxFilterFolders.FormattingEnabled = true;
            this.listBoxFilterFolders.Location = new System.Drawing.Point(8, 35);
            this.listBoxFilterFolders.Name = "listBoxFilterFolders";
            this.listBoxFilterFolders.Size = new System.Drawing.Size(149, 95);
            this.listBoxFilterFolders.TabIndex = 0;
            this.listBoxFilterFolders.SelectedIndexChanged += new System.EventHandler(this.listBoxFilterFolders_SelectedIndexChanged);
            // 
            // listBoxFilterItems
            // 
            this.listBoxFilterItems.FormattingEnabled = true;
            this.listBoxFilterItems.Location = new System.Drawing.Point(160, 35);
            this.listBoxFilterItems.Name = "listBoxFilterItems";
            this.listBoxFilterItems.Size = new System.Drawing.Size(230, 95);
            this.listBoxFilterItems.TabIndex = 1;
            this.listBoxFilterItems.SelectedIndexChanged += new System.EventHandler(this.listBoxFilterItems_SelectedIndexChanged);
            // 
            // buttonNewFilter
            // 
            this.buttonNewFilter.Location = new System.Drawing.Point(395, 106);
            this.buttonNewFilter.Name = "buttonNewFilter";
            this.buttonNewFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonNewFilter.TabIndex = 51;
            this.buttonNewFilter.Text = "New";
            this.buttonNewFilter.UseVisualStyleBackColor = true;
            this.buttonNewFilter.Click += new System.EventHandler(this.buttonSaveFilter_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(8, 277);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(284, 13);
            this.label10.TabIndex = 50;
            this.label10.Text = "All expression fields accept plain text or regular expressions";
            // 
            // textBoxSubtleExample
            // 
            this.textBoxSubtleExample.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSubtleExample.Location = new System.Drawing.Point(328, 253);
            this.textBoxSubtleExample.Name = "textBoxSubtleExample";
            this.textBoxSubtleExample.Size = new System.Drawing.Size(121, 22);
            this.textBoxSubtleExample.TabIndex = 18;
            this.textBoxSubtleExample.Text = "Example Text";
            // 
            // textBoxSubtleRegex
            // 
            this.textBoxSubtleRegex.Location = new System.Drawing.Point(69, 253);
            this.textBoxSubtleRegex.Name = "textBoxSubtleRegex";
            this.textBoxSubtleRegex.Size = new System.Drawing.Size(254, 20);
            this.textBoxSubtleRegex.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(22, 256);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Subtle:";
            // 
            // textBoxGrayExample
            // 
            this.textBoxGrayExample.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGrayExample.Location = new System.Drawing.Point(328, 227);
            this.textBoxGrayExample.Name = "textBoxGrayExample";
            this.textBoxGrayExample.Size = new System.Drawing.Size(121, 22);
            this.textBoxGrayExample.TabIndex = 15;
            this.textBoxGrayExample.Text = "Example Text";
            // 
            // textBoxBlueExample
            // 
            this.textBoxBlueExample.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBlueExample.Location = new System.Drawing.Point(328, 201);
            this.textBoxBlueExample.Name = "textBoxBlueExample";
            this.textBoxBlueExample.Size = new System.Drawing.Size(121, 22);
            this.textBoxBlueExample.TabIndex = 14;
            this.textBoxBlueExample.Text = "Example Text";
            // 
            // textBoxGreenExample
            // 
            this.textBoxGreenExample.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGreenExample.Location = new System.Drawing.Point(328, 175);
            this.textBoxGreenExample.Name = "textBoxGreenExample";
            this.textBoxGreenExample.Size = new System.Drawing.Size(121, 22);
            this.textBoxGreenExample.TabIndex = 13;
            this.textBoxGreenExample.Text = "Example Text";
            // 
            // textBoxYellowExample
            // 
            this.textBoxYellowExample.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxYellowExample.Location = new System.Drawing.Point(328, 149);
            this.textBoxYellowExample.Name = "textBoxYellowExample";
            this.textBoxYellowExample.Size = new System.Drawing.Size(121, 22);
            this.textBoxYellowExample.TabIndex = 12;
            this.textBoxYellowExample.Text = "Example Text";
            // 
            // textBoxRedExample
            // 
            this.textBoxRedExample.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRedExample.Location = new System.Drawing.Point(328, 123);
            this.textBoxRedExample.Name = "textBoxRedExample";
            this.textBoxRedExample.Size = new System.Drawing.Size(121, 22);
            this.textBoxRedExample.TabIndex = 11;
            this.textBoxRedExample.Text = "Example Text";
            // 
            // textBoxYellowRegex
            // 
            this.textBoxYellowRegex.Location = new System.Drawing.Point(69, 149);
            this.textBoxYellowRegex.Name = "textBoxYellowRegex";
            this.textBoxYellowRegex.Size = new System.Drawing.Size(254, 20);
            this.textBoxYellowRegex.TabIndex = 10;
            // 
            // textBoxBlueRegex
            // 
            this.textBoxBlueRegex.Location = new System.Drawing.Point(69, 201);
            this.textBoxBlueRegex.Name = "textBoxBlueRegex";
            this.textBoxBlueRegex.Size = new System.Drawing.Size(254, 20);
            this.textBoxBlueRegex.TabIndex = 9;
            // 
            // textBoxGrayRegex
            // 
            this.textBoxGrayRegex.Location = new System.Drawing.Point(69, 227);
            this.textBoxGrayRegex.Name = "textBoxGrayRegex";
            this.textBoxGrayRegex.Size = new System.Drawing.Size(254, 20);
            this.textBoxGrayRegex.TabIndex = 8;
            // 
            // textBoxGreenRegex
            // 
            this.textBoxGreenRegex.Location = new System.Drawing.Point(69, 175);
            this.textBoxGreenRegex.Name = "textBoxGreenRegex";
            this.textBoxGreenRegex.Size = new System.Drawing.Size(254, 20);
            this.textBoxGreenRegex.TabIndex = 6;
            // 
            // textBoxRedRegex
            // 
            this.textBoxRedRegex.Location = new System.Drawing.Point(69, 123);
            this.textBoxRedRegex.Name = "textBoxRedRegex";
            this.textBoxRedRegex.Size = new System.Drawing.Size(254, 20);
            this.textBoxRedRegex.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Gray:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Blue:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Green:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Yellow:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Red:";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(12, 474);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 31;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxTrimFrom
            // 
            this.textBoxTrimFrom.Location = new System.Drawing.Point(69, 73);
            this.textBoxTrimFrom.Name = "textBoxTrimFrom";
            this.textBoxTrimFrom.Size = new System.Drawing.Size(380, 20);
            this.textBoxTrimFrom.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Trim From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Trim To:";
            // 
            // textBoxTrimTo
            // 
            this.textBoxTrimTo.Location = new System.Drawing.Point(69, 47);
            this.textBoxTrimTo.Name = "textBoxTrimTo";
            this.textBoxTrimTo.Size = new System.Drawing.Size(380, 20);
            this.textBoxTrimTo.TabIndex = 45;
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(69, 23);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(380, 20);
            this.textBoxFilter.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Line Filter:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(323, 474);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 32;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(411, 474);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 30;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.labelFilterDescription);
            this.groupBox2.Controls.Add(this.buttonNewFilter);
            this.groupBox2.Controls.Add(this.buttonDeleteFilter);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.listBoxFilterFolders);
            this.groupBox2.Controls.Add(this.buttonEditFilter);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.listBoxFilterItems);
            this.groupBox2.Location = new System.Drawing.Point(8, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(476, 158);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Predefined ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxTrimMiddle);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.textBoxSubtleExample);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.textBoxSubtleRegex);
            this.groupBox3.Controls.Add(this.textBoxTrimFrom);
            this.groupBox3.Controls.Add(this.textBoxTrimTo);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBoxGrayExample);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxBlueExample);
            this.groupBox3.Controls.Add(this.textBoxFilter);
            this.groupBox3.Controls.Add(this.textBoxGreenExample);
            this.groupBox3.Controls.Add(this.textBoxGreenRegex);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBoxYellowExample);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBoxRedExample);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBoxYellowRegex);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBoxBlueRegex);
            this.groupBox3.Controls.Add(this.textBoxRedRegex);
            this.groupBox3.Controls.Add(this.textBoxGrayRegex);
            this.groupBox3.Location = new System.Drawing.Point(8, 172);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(478, 297);
            this.groupBox3.TabIndex = 52;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Expressions ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 51;
            this.label11.Text = "Trim Middle:";
            // 
            // textBoxTrimMiddle
            // 
            this.textBoxTrimMiddle.Location = new System.Drawing.Point(69, 96);
            this.textBoxTrimMiddle.Name = "textBoxTrimMiddle";
            this.textBoxTrimMiddle.Size = new System.Drawing.Size(380, 20);
            this.textBoxTrimMiddle.TabIndex = 52;
            // 
            // FilterConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 503);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterConfigForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filter Configuration";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label10;
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
        private System.Windows.Forms.ListBox listBoxFilterItems;
        private System.Windows.Forms.ListBox listBoxFilterFolders;
        private System.Windows.Forms.Label labelFilterDescription;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxSubtleExample;
        private System.Windows.Forms.TextBox textBoxSubtleRegex;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button buttonNewFilter;
        private System.Windows.Forms.Button buttonDeleteFilter;
        private System.Windows.Forms.Button buttonEditFilter;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxTrimMiddle;
        private System.Windows.Forms.Label label11;
    }
}