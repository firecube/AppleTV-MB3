using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace AppleTV_MB3.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var ip = GetLocalIPAddress();
            if (ip == null)
            {
                Console.Write("Can't find local IP");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Starting DNS and Web Servers");

            var dns = new DnsRelay.Server("secure.marketwatch.com", ip, IPAddress.Parse("8.8.8.8"));
            dns.Start();

            var web = new AtvWebServer.Server("secure.marketwatch.com");
            web.Start();

            Console.ReadLine();
        }

        private static IPAddress GetLocalIPAddress()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            return host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
        }
    }
}
