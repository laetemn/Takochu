namespace Takochu.ui
{
    partial class BCSVEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BCSVEditorForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.archiveTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.fileTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.openBCSVBtn = new System.Windows.Forms.ToolStripButton();
            this.saveBCSVBtn = new System.Windows.Forms.ToolStripButton();
            this.bcsvGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bcsvGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.archiveTextBox,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.fileTextBox,
            this.openBCSVBtn,
            this.saveBCSVBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(883, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(50, 22);
            this.toolStripLabel1.Text = "Archive:";
            // 
            // archiveTextBox
            // 
            this.archiveTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.archiveTextBox.Name = "archiveTextBox";
            this.archiveTextBox.Size = new System.Drawing.Size(350, 25);
            this.archiveTextBox.Text = "/ObjectData/Kuribo.arc";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(28, 22);
            this.toolStripLabel2.Text = "File:";
            // 
            // fileTextBox
            // 
            this.fileTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(350, 25);
            this.fileTextBox.Text = "/Kuribo/ActorInfo/InitActor.bcsv";
            // 
            // openBCSVBtn
            // 
            this.openBCSVBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openBCSVBtn.Image = ((System.Drawing.Image)(resources.GetObject("openBCSVBtn.Image")));
            this.openBCSVBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openBCSVBtn.Name = "openBCSVBtn";
            this.openBCSVBtn.Size = new System.Drawing.Size(40, 22);
            this.openBCSVBtn.Text = "Open";
            this.openBCSVBtn.Click += new System.EventHandler(this.openBCSVBtn_Click);
            // 
            // saveBCSVBtn
            // 
            this.saveBCSVBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveBCSVBtn.Enabled = false;
            this.saveBCSVBtn.Image = ((System.Drawing.Image)(resources.GetObject("saveBCSVBtn.Image")));
            this.saveBCSVBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveBCSVBtn.Name = "saveBCSVBtn";
            this.saveBCSVBtn.Size = new System.Drawing.Size(35, 22);
            this.saveBCSVBtn.Text = "Save";
            // 
            // bcsvGridView
            // 
            this.bcsvGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bcsvGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bcsvGridView.Location = new System.Drawing.Point(0, 25);
            this.bcsvGridView.Name = "bcsvGridView";
            this.bcsvGridView.Size = new System.Drawing.Size(883, 425);
            this.bcsvGridView.TabIndex = 1;
            // 
            // BCSVEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 450);
            this.Controls.Add(this.bcsvGridView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "BCSVEditorForm";
            this.Text = "BCSVEditorForm";
            this.Load += new System.EventHandler(this.BCSVEditorForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bcsvGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox archiveTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox fileTextBox;
        private System.Windows.Forms.ToolStripButton openBCSVBtn;
        private System.Windows.Forms.ToolStripButton saveBCSVBtn;
        private System.Windows.Forms.DataGridView bcsvGridView;
    }
}