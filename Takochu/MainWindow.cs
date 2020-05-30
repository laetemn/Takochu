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
            Console.WriteLine(gamePath);

            // is it valid AND does it still exist?
            if (gamePath != "" && Directory.Exists(gamePath))
            {
                Program.sGame = new smg.Game(new ExternalFilesystem(gamePath));
            }
        }

        private void selectGameFolderBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.GamePath = dialog.SelectedPath;
                Properties.Settings.Default.Save();

                Program.sGame = new smg.Game(new ExternalFilesystem(dialog.SelectedPath));
            }
        }

        private void bcsvEditorBtn_Click(object sender, EventArgs e)
        {
            BCSVEditorForm bcsvEditor = new BCSVEditorForm();
            bcsvEditor.Show();
        }
    }
}
