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
    public partial class RemoveForm : Form
    {
        decimal LineDecimal;
        public static int LineInt;
        public static bool CanDelete = false;
        public RemoveForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CanDelete = true;
            LineDecimal = numericUpDown1.Value;
            LineInt = Convert.ToInt32(LineDecimal);
            Close();
        }
    }
}
