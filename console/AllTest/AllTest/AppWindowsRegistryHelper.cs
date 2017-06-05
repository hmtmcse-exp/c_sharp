using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllTest
{
    public class AppWindowsRegistryHelper
    {
        public String readLocalMachineKey(String key)
        {
            RegistryKey myKey = Registry.LocalMachine.OpenSubKey(
              @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts");
            return myKey.GetValue(key) != null ? myKey.GetValue(key).ToString() : null;
        }
    }
}
