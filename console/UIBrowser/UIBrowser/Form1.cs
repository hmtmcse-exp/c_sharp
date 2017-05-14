using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog x = new OpenFileDialog();

            x.DefaultExt = "ttf";
            x.Filter = "Fonts (*.ttf,*.otf)|*.ttf;*.otf";
            x.Multiselect = true;
            x.ShowDialog();
            string[] result = x.FileNames;

            foreach (string y in result)
                MessageBox.Show(y, "Selected Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
