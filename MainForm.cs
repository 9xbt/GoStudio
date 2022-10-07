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
using System.Reflection;
using System.CodeDom.Compiler;

namespace GoExe_Editor
{
    public partial class MainForm : Form
    {
        string[] EditorLines;
        public static string Version = "1.1";
        bool saved;
        public MainForm()
        {
            InitializeComponent();
            EditorLines = TextBox.Lines;

            this.TextBox.SelectionColor = Color.Black;

            this.CheckKeyword("print=", Color.Magenta, 0);
            this.CheckKeyword("variable=", Color.Purple, 0);
            this.CheckKeyword("input=", Color.Blue, 0);
            this.CheckKeyword("variable=", Color.DarkGoldenrod, 0);
            this.CheckKeyword("if=", Color.DarkGoldenrod, 0);

            this.CheckKeyword("stop=", Color.Red, 0);

            this.CheckKeyword("randomnum=", Color.Black, 0);
            this.CheckKeyword("clear=", Color.Black, 0);

            this.CheckKeyword("{getInput}", Color.Blue, 0);

            this.CheckKeyword("{1}", Color.Blue, 0);
            this.CheckKeyword("{2}", Color.Blue, 0);
            this.CheckKeyword("{3}", Color.Blue, 0);
            this.CheckKeyword("{4}", Color.Blue, 0);
            this.CheckKeyword("{5}", Color.Blue, 0);
            this.CheckKeyword("{6}", Color.Blue, 0);
            this.CheckKeyword("{7}", Color.Blue, 0);
            this.CheckKeyword("{8}", Color.Blue, 0);
            this.CheckKeyword("{9}", Color.Blue, 0);
            this.CheckKeyword("{10}", Color.Blue, 0);
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
                EditorLines = TextBox.Lines;
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
            if (DeleteFile.ShowDialog() == DialogResult.OK)
            {
                File.Delete(DeleteFile.FileName);
            }
        }

        private void wikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Owen2k6/GoOS/wiki/Using-GoCode");
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            saved = false;

            this.TextBox.SelectionColor = Color.Black;

            this.CheckKeyword("print=", Color.Magenta, 0);
            this.CheckKeyword("variable=", Color.Purple, 0);
            this.CheckKeyword("input=", Color.Blue, 0);
            this.CheckKeyword("variable=", Color.DarkGoldenrod, 0);
            this.CheckKeyword("if=", Color.DarkGoldenrod, 0);

            this.CheckKeyword("stop=", Color.Red, 0);

            this.CheckKeyword("#", Color.Yellow, 5);
            this.CheckKeyword("randomnum=", Color.DimGray, 0);
            this.CheckKeyword("clear=", Color.DimGray, 0);

            this.CheckKeyword("{getInput}", Color.Blue, 0);

            this.CheckKeyword("{1}", Color.Blue, 0);
            this.CheckKeyword("{2}", Color.Blue, 0);
            this.CheckKeyword("{3}", Color.Blue, 0);
            this.CheckKeyword("{4}", Color.Blue, 0);
            this.CheckKeyword("{5}", Color.Blue, 0);
            this.CheckKeyword("{6}", Color.Blue, 0);
            this.CheckKeyword("{7}", Color.Blue, 0);
            this.CheckKeyword("{8}", Color.Blue, 0);
            this.CheckKeyword("{9}", Color.Blue, 0);
            this.CheckKeyword("{10}", Color.Blue, 0);
        }

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.TextBox.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.TextBox.SelectionStart;

                while ((index = this.TextBox.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.TextBox.Select((index + startIndex), word.Length);
                    this.TextBox.SelectionColor = color;
                    this.TextBox.Select(selectStart, 0);
                    this.TextBox.SelectionColor = Color.Black;
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (SaveFile.ShowDialog() == DialogResult.OK)
                {
                    EditorLines = TextBox.Lines;
                    File.WriteAllLines(SaveFile.FileName + ".goexe", EditorLines);
                    Text = "GoCode Editor - " + SaveFile.FileName;
                }
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else { }
        }
    }
}