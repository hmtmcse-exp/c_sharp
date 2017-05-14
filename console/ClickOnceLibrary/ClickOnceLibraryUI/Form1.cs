using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Deployment.Application;
using System.Security.Permissions;
using ClickOnceLibrary;

namespace ClickOnceLibraryUI
{
    public partial class Form1 : Form
    {

        Dictionary<String, String> DllMapping = new Dictionary<String, String>();

     ///   [SecurityPermission(SecurityAction.Demand, ControlAppDomain = true)]
        public Form1()
        {
            InitializeComponent();
            DllMapping["ClickOnceLibrary"] = "ClickOnceLibrary";
      //      AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            Assembly newAssembly = null;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment deploy = ApplicationDeployment.CurrentDeployment;

                // Get the DLL name from the Name argument.
                string[] nameParts = args.Name.Split(',');
                string dllName = nameParts[0];
                string downloadGroupName = DllMapping[dllName];

                try
                {
                    deploy.DownloadFileGroup(downloadGroupName);
                }
                catch (DeploymentException de)
                {
                    MessageBox.Show("Downloading file group failed. Group name: " + downloadGroupName + "; DLL name: " + args.Name);
                    throw (de);
                }

                // Load the assembly.
                // Assembly.Load() doesn't work here, as the previous failure to load the assembly
                // is cached by the CLR. LoadFrom() is not recommended. Use LoadFile() instead.
                try
                {
                    newAssembly = Assembly.LoadFile(Application.StartupPath + @"\" + dllName + ".dll");
                }
                catch (Exception e)
                {
                    throw (e);
                }
            }
            else
            {
                //Major error - not running under ClickOnce, but missing assembly. Don't know how to recover.
                throw (new Exception("Cannot load assemblies dynamically - application is not deployed using ClickOnce."));
            }


            return (newAssembly);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DynamicClass dc = new DynamicClass();
            MessageBox.Show("Message: " + dc.Message);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyInstaller installer = new MyInstaller();
            installer.InstallApplication(@"C:\Users\touhid\Desktop\dynamicUpdate\1.0.0.0\ClickOnceLibraryUI.application");
        }
    }
}
