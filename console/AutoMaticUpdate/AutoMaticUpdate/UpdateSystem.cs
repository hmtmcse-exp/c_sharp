using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Deployment.Application;
using System.Security.Permissions;
using static System.Net.Mime.MediaTypeNames;

namespace AutoMaticUpdate
{
    class UpdateSystem
    {


        Dictionary<String, String> DllMapping = new Dictionary<String, String>();

        public UpdateSystem()
        {
            DllMapping["ClickOnceLibrary"] = "ClickOnceLibrary";
        }

        public void start()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
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
                    Console.WriteLine("Downloading file group failed. Group name: " + downloadGroupName + "; DLL name: " + args.Name);
                    throw (de);
                }


                try
                {
                    newAssembly = Assembly.LoadFile(@"\" + dllName + ".dll");
                }
                catch (Exception e)
                {
                    throw (e);
                }
            }
            else
            {

                throw (new Exception("Cannot load assemblies dynamically - application is not deployed using ClickOnce."));
            }


            return (newAssembly);
        }

    }

}
