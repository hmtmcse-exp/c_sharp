using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Security.Permissions;

namespace server
{
    class Program
    {
        [SecurityPermission(SecurityAction.Demand)]
        public static void Main(string[] args)
        {
            IpcChannel serverChannel = new IpcChannel("localhost: 9091");

            // Join the channel to the server
            ChannelServices.RegisterChannel(server channel);

            // Provides the object for registered channels. 
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObject), "RemoteObject.rem",
                                                                WellKnownObjectMode.Singleton);

            Console.WriteLine("Press ENTER to exit the server.");
            Console.ReadLine();
            Console.WriteLine("Server closes.");
        }
    }
}
