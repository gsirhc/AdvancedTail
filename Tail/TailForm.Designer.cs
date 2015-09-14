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
            this.mainMenuToolbar = new Tail.UserControls.MainMenuToolbar();
            this.logDisplay = new Tail.UserControls.LogDisplay();
            this.SuspendLayout();
            // 
            // mainMenuToolbar
            // 
            this.mainMenuToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainMenuToolbar.FilePath = "";
            this.mainMenuToolbar.FilterEnabled = true;
            this.mainMenuToolbar.Location = new System.Drawing.Point(0, 0);
            this.mainMenuToolbar.Name = "mainMenuToolbar";
            this.mainMenuToolbar.Size = new System.Drawing.Size(806, 77);
            this.mainMenuToolbar.TabIndex = 0;
            this.mainMenuToolbar.TrimEnabled = true;
            // 
            // logDisplay
            // 
            this.logDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logDisplay.Location = new System.Drawing.Point(0, 77);
            this.logDisplay.Name = "logDisplay";
            this.logDisplay.ShowLineNumbers = false;
            this.logDisplay.Size = new System.Drawing.Size(806, 492);
            this.logDisplay.TabIndex = 1;
            this.logDisplay.WordWrap = false;
            // 
            // TailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 569);
            this.Controls.Add(this.logDisplay);
            this.Controls.Add(this.mainMenuToolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TailForm";
            this.Text = "AdvancedTail";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.MainMenuToolbar mainMenuToolbar;
        private UserControls.LogDisplay logDisplay;
    }
}

