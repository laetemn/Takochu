using GL_EditorFramework.EditorDrawables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Takochu.fmt;
using Takochu.io;

namespace Takochu.ui
{
    public partial class EditorWindow : Form
    {
        public EditorWindow(string galaxyName)
        {
            InitializeComponent();

            RARCFilesystem fs = new RARCFilesystem(Program.sGame.mFilesystem.OpenFile("/ObjectData/Kuribo.arc"));
            BMD bmd = new BMD(fs.OpenFile("/Kuribo/Kuribo.bdl"));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            scene = new EditorScene();

            galaxyViewControl.MainDrawable = scene;
            galaxyViewControl.ActiveCamera = new GL_EditorFramework.StandardCameras.InspectCamera(1f);
            galaxyViewControl.CameraDistance = 20.0f;
        }

        private EditorScene scene;
        private string mGalaxyName;
    }
}
