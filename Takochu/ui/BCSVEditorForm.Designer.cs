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
            this.openBCSVBtn = new System.Windows.Forms.ToolStripButton();
            this.saveBCSVBtn = new System.Windows.Forms.ToolStripButton();
            this.bcsvGridView = new System.Windows.Forms.DataGridView();
            this.filesystemView = new System.Windows.Forms.TreeView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bcsvGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.archiveTextBox,
            this.toolStripSeparator1,
            this.openBCSVBtn,
            this.saveBCSVBtn});
            this.toolStrip1.Location = new System.Drawing.Point(4, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(886, 25);
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
            this.archiveTextBox.Size = new System.Drawing.Size(750, 25);
            this.archiveTextBox.Text = "/ObjectData/Kuribo.arc";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            this.saveBCSVBtn.Click += new System.EventHandler(this.saveBCSVBtn_Click);
            // 
            // bcsvGridView
            // 
            this.bcsvGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bcsvGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bcsvGridView.Location = new System.Drawing.Point(0, 253);
            this.bcsvGridView.Name = "bcsvGridView";
            this.bcsvGridView.Size = new System.Drawing.Size(921, 354);
            this.bcsvGridView.TabIndex = 1;
            // 
            // filesystemView
            // 
            this.filesystemView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filesystemView.Location = new System.Drawing.Point(0, 28);
            this.filesystemView.Name = "filesystemView";
            this.filesystemView.Size = new System.Drawing.Size(921, 219);
            this.filesystemView.TabIndex = 2;
            this.filesystemView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.filesystemView_NodeMouseDoubleClick);
            // 
            // BCSVEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 608);
            this.Controls.Add(this.filesystemView);
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
        private System.Windows.Forms.ToolStripButton openBCSVBtn;
        private System.Windows.Forms.ToolStripButton saveBCSVBtn;
        private System.Windows.Forms.DataGridView bcsvGridView;
        private System.Windows.Forms.TreeView filesystemView;
    }
}