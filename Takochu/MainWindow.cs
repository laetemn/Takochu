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

namespace Takochu
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            BCSV.PopulateHashTable();

            ExternalFilesystem e = new ExternalFilesystem("C:/Users/xarf9/Hacking/Wii/SMG2/Filesystem/DATA/files/");

            Console.WriteLine(e.DoesDirectoryExist("LocalizeData/UsEnglish"));
            Console.WriteLine(e.DoesDirectoryExist("GAY"));

            RARCFilesystem rarcFS = new RARCFilesystem(e.OpenFile("ObjectData/Mario.arc"));

            FileBase f = rarcFS.OpenFile("/Mario/Mario.bdl");
            BMD bmd = new BMD(f);
        }
    }
}
