using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace AllTest
{
    class Program
    {

        [STAThread]
        //[STAThreadAttribute]
        static void Main(string[] args)
        {
            //Application.Run(new FolderBrowserDialogExampleForm1());

            //string[] array1 = Directory.GetFiles(@"C:\");
            //foreach (string name in array1)
            //{
            //    Console.WriteLine(name);
            //}


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



            //Console.WriteLine(new Uri(new Uri("https://www.google.com/"), "/touhid").ToString());




            //try
            //{
            //    ManagementObjectSearcher searcher =
            //        new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

            //    foreach (ManagementObject queryObj in searcher.Get())
            //    {
            //        Console.WriteLine("-----------------------------------");
            //        Console.WriteLine("Win32_Processor instance");
            //        Console.WriteLine("-----------------------------------");
            //        Console.WriteLine("Architecture: {0}", queryObj["Architecture"]);
            //        Console.WriteLine("Caption: {0}", queryObj["Caption"]);
            //        Console.WriteLine("Family: {0}", queryObj["Family"]);
            //        Console.WriteLine("ProcessorId: {0}", queryObj["ProcessorId"]);
            //    }
            //}
            //catch (ManagementException e)
            //{
            //    Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
            //}


            //FileInfo oFileInfo = new FileInfo(@"C:\Users\touhid\Desktop\fonts\Lato\Lato-Black.ttf");

            //FileAttributes fileAttributes = File.GetAttributes(@"C:\Users\touhid\Desktop\fonts\Lato\Lato-Black.ttf");


            //List<string> arrHeaders = new List<string>();

            Shell32.Shell shell = new Shell32.Shell();
            var strFileName = @"C:\Users\touhid\Desktop\fonts\Lato\Lato-Black.ttf";
            Shell32.Folder objFolder = shell.NameSpace(System.IO.Path.GetDirectoryName(strFileName));
            Shell32.FolderItem folderItem = objFolder.ParseName(System.IO.Path.GetFileName(strFileName));

            //for (int i = 0; i < short.MaxValue; i++)
            //{
            //    string header = objFolder.GetDetailsOf(null, i);
            //    if (String.IsNullOrEmpty(header))
            //        break;
            //    arrHeaders.Add(header);
            //}


            //for (int i = 0; i < arrHeaders.Count; i++)
            //{
            //    Console.WriteLine(arrHeaders[i] + " " + i + " :" + objFolder.GetDetailsOf(folderItem, i));
            //}

            Console.WriteLine("Title: " + objFolder.GetDetailsOf(folderItem, 21));
            Console.WriteLine("Type: " + objFolder.GetDetailsOf(folderItem, 2));
            Console.WriteLine("Authors: " + objFolder.GetDetailsOf(folderItem, 20));


            Console.ReadLine();



            //Console.Read();

            //Console.ReadLine();

        }
    }
}
