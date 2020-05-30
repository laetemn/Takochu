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
    public partial class BCSVEditorForm : Form
    {
        public BCSVEditorForm()
        {
            InitializeComponent();
        }

        private void openBCSVBtn_Click(object sender, EventArgs e)
        {
            if (mFilesystem != null)
            {
                mFilesystem.Close();
                mFile.Close();
            }

            mFilesystem = new RARCFilesystem(Program.sGame.mFilesystem.OpenFile(archiveTextBox.Text));
            mFile = new BCSV(mFilesystem.OpenFile(fileTextBox.Text));

            bcsvGridView.Rows.Clear();
            bcsvGridView.Columns.Clear();

            foreach(BCSV.Field f in mFile.mFields.Values)
            {
                int columnIdx = bcsvGridView.Columns.Add(f.mHash.ToString("X"), f.mName);

                // format floating point cells to show the first decimal point
                if (f.mType == 2)
                    bcsvGridView.Columns[columnIdx].DefaultCellStyle.Format = "N1";
            }

            foreach (BCSV.Entry entry in mFile.mEntries)
            {
                object[] row = new object[entry.Count];
                int i = 0;

                foreach (KeyValuePair<int, object> _val in entry)
                {
                    object val = _val.Value;
                    row[i++] = val;
                }

                bcsvGridView.Rows.Add(row);
            }
        }

        private void BCSVEditorForm_Load(object sender, EventArgs e)
        {

        }

        private RARCFilesystem mFilesystem;
        private BCSV mFile;
    }
}
