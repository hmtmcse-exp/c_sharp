using System;
using System.Diagnostics;
using System.Security;
using System.ComponentModel;
using System.Management;
using System.IO;

namespace AllTest
{
    class Program
    {
        static void Main(string[] args)
        {


            string[] array1 = Directory.GetFiles(@"C:\");
            foreach (string name in array1)
            {
                Console.WriteLine(name);
            }


            //string domain = "";
            //string uname = "touhid@BITMASCOT.local";
            //SecureString password = new SecureString();
            //string rawPassword = "Bismillah786";
            //foreach (System.Char c in rawPassword)
            //{
            //    password.AppendChar(c);
            //}

            //try
            //{
            //    Console.WriteLine("\nTrying to launch NotePad using your login information...");
            //    Process.Start("c:\\WINDOWS\\system32\\cmd.exe", uname, password, domain);
            //    Process myProcess = new Process();

            //}
            //catch (Win32Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}



            Console.WriteLine(new Uri(new Uri("https://www.google.com/"), "/touhid").ToString());




            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Win32_Processor instance");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Architecture: {0}", queryObj["Architecture"]);
                    Console.WriteLine("Caption: {0}", queryObj["Caption"]);
                    Console.WriteLine("Family: {0}", queryObj["Family"]);
                    Console.WriteLine("ProcessorId: {0}", queryObj["ProcessorId"]);
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
            }



            Console.Read();

            Console.ReadLine();

        }
    }
}
