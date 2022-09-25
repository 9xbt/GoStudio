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
using System.Diagnostics;

namespace GoExe_Editor
{
    public partial class MainForm : Form
    {
        string[] EditorLines;
        public static string Version = "1.0.1";
        public MainForm()
        {
            InitializeComponent();
            EditorLines = TextBox.Lines;
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
                Text = "GoCode Editor - " + OpenFile.FileName;
                UpdateLines();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(SaveFile.FileName + ".goexe", EditorLines);
                Text = "GoCode Editor - " + SaveFile.FileName;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox.Text = "";
            EditorLines = null;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm afrm = new AboutForm();
            afrm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (OpenFile.FileName.Length != 0)
            {
                File.Delete(OpenFile.FileName);
                TextBox.Text = "";
            }
        }

        private void wikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Owen2k6/GoOS/wiki/Using-GoCode"); 
        }
    }
}