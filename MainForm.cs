using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.CodeDom;
using System.Threading;

namespace GoExe_Editor
{
    public partial class MainForm : Form
    {
        string[] EditorLines;
        public MainForm()
        {
            InitializeComponent();
            EditorLines = TextBox.Lines;
        }

        private void removeLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveForm rfrm = new RemoveForm();
            rfrm.ShowDialog();
            if (RemoveForm.CanDelete == true)
            {
                EditorLines[RemoveForm.LineInt] = "";
                UpdateLines();
            }
        }
        public void UpdateLines()
        {
            TextBox.Lines = EditorLines;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                EditorLines = File.ReadAllLines(OpenFile.FileName);
                UpdateLines();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(SaveFile.FileName + ".goexe", EditorLines);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Text = "";
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenFile.FileName.Length != 0)
            {
                File.Delete(OpenFile.FileName);
                TextBox.Text = "";
            }
        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditForm efrm = new EditForm();
            efrm.ShowDialog();
            if (EditForm.CanEdit == true)
            {
                EditorLines[RemoveForm.LineInt] = EditForm.LineString;
                UpdateLines();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm afrm = new AboutForm();
            afrm.ShowDialog();
        }
    }
}