using System.Reflection;
using System.Deployment.Application;

using System.Security.Permissions;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;

namespace AutoMaticUpdate
{
    class Program
    {

     

        static void Main(string[] args)
        {
            UpdateSystem updateCheckInfo = new UpdateSystem();
            updateCheckInfo.start();
            Console.ReadLine();
        }

    }
}
