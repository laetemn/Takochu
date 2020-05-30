namespace Takochu
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.selectGameFolderBtn = new System.Windows.Forms.ToolStripButton();
            this.bcsvEditorBtn = new System.Windows.Forms.ToolStripButton();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectGameFolderBtn,
            this.bcsvEditorBtn});
            this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(800, 25);
            this.mainToolStrip.TabIndex = 0;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // selectGameFolderBtn
            // 
            this.selectGameFolderBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectGameFolderBtn.Image = ((System.Drawing.Image)(resources.GetObject("selectGameFolderBtn.Image")));
            this.selectGameFolderBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectGameFolderBtn.Name = "selectGameFolderBtn";
            this.selectGameFolderBtn.Size = new System.Drawing.Size(112, 22);
            this.selectGameFolderBtn.Text = "Select Game Folder";
            this.selectGameFolderBtn.Click += new System.EventHandler(this.selectGameFolderBtn_Click);
            // 
            // bcsvEditorBtn
            // 
            this.bcsvEditorBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bcsvEditorBtn.Image = ((System.Drawing.Image)(resources.GetObject("bcsvEditorBtn.Image")));
            this.bcsvEditorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bcsvEditorBtn.Name = "bcsvEditorBtn";
            this.bcsvEditorBtn.Size = new System.Drawing.Size(98, 22);
            this.bcsvEditorBtn.Text = "toolStripButton1";
            this.bcsvEditorBtn.Click += new System.EventHandler(this.bcsvEditorBtn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainToolStrip);
            this.Name = "MainWindow";
            this.Text = "Takochu";
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton selectGameFolderBtn;
        private System.Windows.Forms.ToolStripButton bcsvEditorBtn;
    }
}

