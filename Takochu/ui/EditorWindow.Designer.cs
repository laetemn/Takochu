namespace Takochu.ui
{
    partial class EditorWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorWindow));
            this.galaxyViewControl = new GL_EditorFramework.GL_Core.GL_ControlModern();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // galaxyViewControl
            // 
            this.galaxyViewControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.galaxyViewControl.BackColor = System.Drawing.Color.Black;
            this.galaxyViewControl.CameraDistance = 10F;
            this.galaxyViewControl.CameraTarget = ((OpenTK.Vector3)(resources.GetObject("galaxyViewControl.CameraTarget")));
            this.galaxyViewControl.CamRotX = 0F;
            this.galaxyViewControl.CamRotY = 0F;
            this.galaxyViewControl.CurrentShader = null;
            this.galaxyViewControl.Fov = 0.7853982F;
            this.galaxyViewControl.Location = new System.Drawing.Point(202, 1);
            this.galaxyViewControl.Name = "galaxyViewControl";
            this.galaxyViewControl.NormPickingDepth = 0F;
            this.galaxyViewControl.ShowOrientationCube = true;
            this.galaxyViewControl.Size = new System.Drawing.Size(596, 445);
            this.galaxyViewControl.Stereoscopy = GL_EditorFramework.GL_Core.GL_ControlBase.StereoscopyType.DISABLED;
            this.galaxyViewControl.TabIndex = 0;
            this.galaxyViewControl.VSync = false;
            this.galaxyViewControl.ZFar = 32000F;
            this.galaxyViewControl.ZNear = 0.32F;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(2, 1);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(194, 445);
            this.treeView1.TabIndex = 1;
            // 
            // EditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.galaxyViewControl);
            this.Name = "EditorWindow";
            this.Text = "EditorWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private GL_EditorFramework.GL_Core.GL_ControlModern galaxyViewControl;
        private System.Windows.Forms.TreeView treeView1;
    }
}