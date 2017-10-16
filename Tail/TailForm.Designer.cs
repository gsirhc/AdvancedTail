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
            this.mainMenuToolbar.HighlightEnabled = true;
            this.mainMenuToolbar.LoadLastNLines = -1;
            this.mainMenuToolbar.Location = new System.Drawing.Point(0, 0);
            this.mainMenuToolbar.Margin = new System.Windows.Forms.Padding(11, 11, 11, 11);
            this.mainMenuToolbar.Name = "mainMenuToolbar";
            this.mainMenuToolbar.PreviewPredefinedFilter = true;
            this.mainMenuToolbar.PromptRefreshOnFilterChange = true;
            this.mainMenuToolbar.Size = new System.Drawing.Size(1478, 120);
            this.mainMenuToolbar.TabIndex = 0;
            this.mainMenuToolbar.TrimEnabled = true;
            // 
            // logDisplay
            // 
            this.logDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logDisplay.Location = new System.Drawing.Point(0, 120);
            this.logDisplay.Margin = new System.Windows.Forms.Padding(11, 11, 11, 11);
            this.logDisplay.Name = "logDisplay";
            this.logDisplay.ShowLineNumbers = false;
            this.logDisplay.Size = new System.Drawing.Size(1478, 930);
            this.logDisplay.TabIndex = 1;
            this.logDisplay.WordWrap = false;
            // 
            // TailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 1050);
            this.Controls.Add(this.logDisplay);
            this.Controls.Add(this.mainMenuToolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "TailForm";
            this.Text = "AdvancedTail";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.MainMenuToolbar mainMenuToolbar;
        private UserControls.LogDisplay logDisplay;
    }
}

