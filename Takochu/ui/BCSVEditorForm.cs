using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
            }

            if (mFile != null)
            {
                mFile.Close();
            }

            filesystemView.Nodes.Clear();

            mFilesystem = new RARCFilesystem(Program.sGame.mFilesystem.OpenFile(archiveTextBox.Text));

            TreeNode root = new TreeNode("/");

            PopulateTreeView(ref root, "/root");

            filesystemView.Nodes.Add(root);
        }

        private void PopulateTreeView(ref TreeNode node, string parent)
        {
            List<string> dirs = mFilesystem.GetDirectories(parent);
            List<string> files = mFilesystem.GetFiles(parent);

            foreach (string file in files)
            {
                string ext = Path.GetExtension(file);

                if (ext == ".bcsv" || ext == ".pa" || ext == ".camn" || ext == ".bamnt" || ext == "" | ext == ".bcam")
                {
                    TreeNode tn = new TreeNode(file);
                    tn.Tag = Convert.ToString(parent + "/" + file);
                    node.Nodes.Add(tn);
                }
            }

            foreach (string dir in dirs)
            {
                TreeNode tn = new TreeNode(dir);
                node.Nodes.Add(tn);

                PopulateTreeView(ref tn, parent + "/" + dir);
            }
        }

        private void BCSVEditorForm_Load(object sender, EventArgs e)
        {

        }

        private RARCFilesystem mFilesystem;
        private BCSV mFile;

        private void filesystemView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (filesystemView.SelectedNode != null)
            {
                if (filesystemView.SelectedNode.Tag == null)
                    return;

                mFile = new BCSV(mFilesystem.OpenFile((string)filesystemView.SelectedNode.Tag));
                saveBCSVBtn.Enabled = true;

                bcsvGridView.Rows.Clear();
                bcsvGridView.Columns.Clear();

                foreach (BCSV.Field f in mFile.mFields.Values)
                {
                    int columnIdx = bcsvGridView.Columns.Add(f.mHash.ToString("X8"), f.mName);

                    // format floating point cells to show the first decimal point
                    if (f.mType == 2)
                        bcsvGridView.Columns[columnIdx].DefaultCellStyle.Format = "N1";
                }

                foreach (BCSV.Entry entry in mFile.mEntries)
                {
                    object[] row = new object[entry.Count];
                    int i = 0;

                    foreach (KeyValuePair<uint, object> _val in entry)
                    {
                        object val = _val.Value;
                        row[i++] = val;
                    }

                    bcsvGridView.Rows.Add(row);
                }
            }
        }

        private void saveBCSVBtn_Click(object sender, EventArgs e)
        {
            mFile.mEntries.Clear();

            foreach(DataGridViewRow r in bcsvGridView.Rows)
            {
                if (r.IsNewRow)
                    continue;

                BCSV.Entry entry = new BCSV.Entry();
                mFile.mEntries.Add(entry);

                foreach(BCSV.Field f in mFile.mFields.Values)
                {
                    uint hash = f.mHash;
                    string valStr = r.Cells[hash.ToString("X8")].FormattedValue.ToString();

                    try
                    {
                        switch (f.mType)
                        {
                            case 0:
                            case 3:
                                entry.Add(hash, uint.Parse(valStr));
                                break;
                            case 4:
                                entry.Add(hash, ushort.Parse(valStr));
                                break;
                            case 5:
                                entry.Add(hash, byte.Parse(valStr));
                                break;
                            case 2:
                                entry.Add(hash, float.Parse(valStr));
                                break;
                            case 6:
                                entry.Add(hash, valStr);
                                break;
                        }
                    }
                    catch
                    {
                        switch(f.mType)
                        {
                            case 0:
                            case 3:
                                entry.Add(hash, (uint)0);
                                break;
                            case 4:
                                entry.Add(hash, (ushort)0);
                                break;
                            case 5:
                                entry.Add(hash, (byte)0);
                                break;
                            case 2:
                                entry.Add(hash, 0f);
                                break;
                            case 6:
                                entry.Add(hash, "");
                                break;
                        }
                    }
                }
            }

            mFile.Save();
            mFilesystem.Save();
        }
    }
}
