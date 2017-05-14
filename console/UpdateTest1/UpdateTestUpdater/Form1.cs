using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpdateTestUpdater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread th = new Thread(killAndUpdate);
            th.Start();
        }

        public void killAndUpdate()
        {
            Thread.Sleep(5000);
            string processName = "UpdateTest1";
            if (Process.GetProcessesByName(processName).Length > 0)
            {
                foreach (var process in Process.GetProcessesByName(processName))
                {
                    process.Kill();
                }
            }

            Thread.Sleep(5000);
            File.Delete("UpdateTestDLL.dll");
            File.Move(@"F:\touhid\c_sharp\console\UpdateTest1\UpdateTestDLL\bin\Debug\UpdateTestDLL.dll", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UpdateTestDLL.dll"));
            Process.Start("UpdateTest1.exe");
            Application.Exit();
        }
    }
}
