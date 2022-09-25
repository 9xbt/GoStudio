using System;
using System.Windows.Forms;

namespace GoExe_Editor
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            label1.Text = "GoCode Editor v" + MainForm.Version;
        }

        private void button1_Click(object sender, EventArgs e) => Close();
    }
}
