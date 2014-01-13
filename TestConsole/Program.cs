using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace AppleTV_MB3.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting DNS and Web Servers...");

            var dns = new DnsRelay.Server("www.atv.com", IPAddress.Parse("192.168.10.20"));
            dns.Start();

            var web = new AtvWebServer.Server("www.atv.com");
            web.Start();

            Console.ReadLine();
        }
    }
}
