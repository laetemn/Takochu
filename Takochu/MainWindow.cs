using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Takochu.fmt;
using Takochu.io;
using Takochu.ui;
using Takochu.util;

namespace Takochu
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            string gamePath = Properties.Settings.Default.GamePath;

            if (gamePath == "")
            {
                MessageBox.Show("Please select a path that contains the dump of your SMG1 / SMG2 copy.");
                bool res = SetGamePath();

                if (!res)
                    return;
            }

            // is it valid AND does it still exist?
            if (gamePath != "" && Directory.Exists(gamePath))
            {
                Program.sGame = new smg.Game(new ExternalFilesystem(gamePath));
                bcsvEditorBtn.Enabled = true;
            }
        }

        private void selectGameFolderBtn_Click(object sender, EventArgs e)
        {
            SetGamePath();
        }

        private void bcsvEditorBtn_Click(object sender, EventArgs e)
        {
            BCSVEditorForm bcsvEditor = new BCSVEditorForm();
            bcsvEditor.Show();
        }

        private bool SetGamePath()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.SelectedPath;
                if (Directory.Exists($"{path}/StageData") && Directory.Exists($"{path}/ObjectData"))
                {

                    Properties.Settings.Default.GamePath = dialog.SelectedPath;
                    Properties.Settings.Default.Save();

                    Program.sGame = new smg.Game(new ExternalFilesystem(dialog.SelectedPath));

                    MessageBox.Show("Path set successfully! You may now use Takochu.");
                    return true;
                }
                else
                {
                    MessageBox.Show("Invalid folder. If you have already selected a correct folder, that will continue to be your base folder.");
                    return false;
                }
            }

            return false;
        }
    }
}
