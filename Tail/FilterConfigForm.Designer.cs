namespace Tail
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
            this.textBoxTrimFrom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTrimTo = new System.Windows.Forms.TextBox();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.buttonLevelStarts = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonLevelContains = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonNoHighlighting = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxTrimFrom
            // 
            this.textBoxTrimFrom.Location = new System.Drawing.Point(98, 64);
            this.textBoxTrimFrom.Name = "textBoxTrimFrom";
            this.textBoxTrimFrom.Size = new System.Drawing.Size(374, 20);
            this.textBoxTrimFrom.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Trim From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Trim To:";
            // 
            // textBoxTrimTo
            // 
            this.textBoxTrimTo.Location = new System.Drawing.Point(98, 38);
            this.textBoxTrimTo.Name = "textBoxTrimTo";
            this.textBoxTrimTo.Size = new System.Drawing.Size(374, 20);
            this.textBoxTrimTo.TabIndex = 26;
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(98, 12);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(374, 20);
            this.textBoxFilter.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Filter:";
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(397, 313);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 30;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(12, 313);
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
            this.buttonCancel.Location = new System.Drawing.Point(312, 313);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 32;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonNoHighlighting);
            this.groupBox1.Controls.Add(this.buttonLevelContains);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.buttonLevelStarts);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 189);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Highlighting ";
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
            // buttonLevelStarts
            // 
            this.buttonLevelStarts.Location = new System.Drawing.Point(86, 158);
            this.buttonLevelStarts.Name = "buttonLevelStarts";
            this.buttonLevelStarts.Size = new System.Drawing.Size(123, 23);
            this.buttonLevelStarts.TabIndex = 16;
            this.buttonLevelStarts.Text = "Starts with Log Level ";
            this.buttonLevelStarts.UseVisualStyleBackColor = true;
            this.buttonLevelStarts.Click += new System.EventHandler(this.buttonLevelStarts_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Preconfigured:";
            // 
            // buttonLevelContains
            // 
            this.buttonLevelContains.Location = new System.Drawing.Point(215, 158);
            this.buttonLevelContains.Name = "buttonLevelContains";
            this.buttonLevelContains.Size = new System.Drawing.Size(123, 23);
            this.buttonLevelContains.TabIndex = 18;
            this.buttonLevelContains.Text = "Contains Log Level ";
            this.buttonLevelContains.UseVisualStyleBackColor = true;
            this.buttonLevelContains.Click += new System.EventHandler(this.buttonLevelContains_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(241, 289);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(231, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "All fields accept plain text or regular expressions";
            // 
            // buttonNoHighlighting
            // 
            this.buttonNoHighlighting.Location = new System.Drawing.Point(344, 158);
            this.buttonNoHighlighting.Name = "buttonNoHighlighting";
            this.buttonNoHighlighting.Size = new System.Drawing.Size(70, 23);
            this.buttonNoHighlighting.TabIndex = 19;
            this.buttonNoHighlighting.Text = "None";
            this.buttonNoHighlighting.UseVisualStyleBackColor = true;
            this.buttonNoHighlighting.Click += new System.EventHandler(this.buttonNoHighlighting_Click);
            // 
            // FilterConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 348);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxTrimFrom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxTrimTo);
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FilterConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filter Configuration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTrimFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTrimTo;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxYellowRegex;
        private System.Windows.Forms.TextBox textBoxBlueRegex;
        private System.Windows.Forms.TextBox textBoxGrayRegex;
        private System.Windows.Forms.TextBox textBoxGreenRegex;
        private System.Windows.Forms.TextBox textBoxRedRegex;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRedExample;
        private System.Windows.Forms.TextBox textBoxGrayExample;
        private System.Windows.Forms.TextBox textBoxBlueExample;
        private System.Windows.Forms.TextBox textBoxGreenExample;
        private System.Windows.Forms.TextBox textBoxYellowExample;
        private System.Windows.Forms.Button buttonLevelContains;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonLevelStarts;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonNoHighlighting;
    }
}