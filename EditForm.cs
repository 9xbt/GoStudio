using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoExe_Editor
{
    public partial class EditForm : Form
    {
        public static bool CanEdit = false;
        decimal LineDecimal;
        public static int LineInt;
        public static string LineString;
        public EditForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CanEdit = true;
            LineDecimal = numericUpDown1.Value;
            LineInt = Convert.ToInt32(LineDecimal);
            LineString = textBox1.Text;
            Close();
        }
    }
}
