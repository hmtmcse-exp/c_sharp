using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsScanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string information = "";

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_ComputerSystem");
            foreach (ManagementObject mo in searcher.Get())
            {
                information += "PC NAME: " + mo["Name"] + System.Environment.NewLine;
                information += "Username: " + mo["UserName"] + System.Environment.NewLine;
                information += "Motherboard: " + mo["Manufacturer"] + System.Environment.NewLine;
                information += "RAM: " + Math.Round(Convert.ToDouble(mo["TotalPhysicalMemory"]) / 1073741824, 2) + "GB" + System.Environment.NewLine;
            }


            searcher = new ManagementObjectSearcher("select * from Win32_Processor");
            foreach (ManagementObject mo in searcher.Get())
            {
                information += "Processor: " + mo["Name"] + System.Environment.NewLine;
            }



            long totalSize = 0;
            searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject mo in searcher.Get())
            {
                if (mo.Properties["InterfaceType"].Value.ToString() != "USB")
                {
                    totalSize += Convert.ToInt64(mo.Properties["Size"].Value.ToString());
                }
            }
            information += "HDD: " + (totalSize / 1073741824) + "GB" + System.Environment.NewLine;


            searcher = new ManagementObjectSearcher("select * from Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection queryCollection = searcher.Get();
            queryCollection = searcher.Get();
            information += System.Environment.NewLine + "NIC Information: ";
            int nic = 1;
            foreach (ManagementObject currentConfig in queryCollection)
            {

                string[] addresses = (string[])currentConfig["IPAddress"];
                if (addresses != null)
                {
                    information += System.Environment.NewLine + "NIC-" + nic + ": " + System.Environment.NewLine;
                    information += "IP Address: " + addresses[0] + System.Environment.NewLine;
                    information += "MAC Address: " + currentConfig["MACAddress"] + System.Environment.NewLine;
                    nic++;
                }
            }

            int gpu = 1;
            ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_VideoController");
            foreach (ManagementObject obj in objvide.Get())
            {
                information += System.Environment.NewLine + "GPU-" + gpu + ": " + System.Environment.NewLine;
                information += "Name: " + obj["Name"] + System.Environment.NewLine;
                information += "Location: " + obj["AdapterDACType"] + System.Environment.NewLine;
                information += "Memory: " + Math.Round(Convert.ToDouble(obj["AdapterRAM"]) / 1073741824, 2) + "GB" + System.Environment.NewLine;
                information += "Driver Version: " + obj["DriverVersion"] + System.Environment.NewLine;
                information += "Video Processor: " + obj["VideoProcessor"] + System.Environment.NewLine;
                gpu++;
            }


            information += "Software List" + System.Environment.NewLine;
            searcher = new ManagementObjectSearcher("select * from Win32_Product");
            foreach (ManagementObject mo in searcher.Get())
            {
                information += mo["Name"] + System.Environment.NewLine;
                Console.WriteLine(mo["Name"]);
            }

            textBox1.Text = information;
        }
    }
}
