using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IELTS_Helper
{
    public partial class IELTS : Form
    {
        public IELTS()
        {
            InitializeComponent();
        }

        private void webBrowser3_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = CommonMark.CommonMarkConverter.Convert("**Hello world!**");
            introWeb.DocumentText = result;
        }
    }
}
