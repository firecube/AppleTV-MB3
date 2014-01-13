using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy.Hosting.Self;

namespace AppleTV_MB3.AtvWebServer
{
    public class Server : IDisposable
    {
        NancyHost host;

        public Server(string domainToSpoof)
        {
            host = new NancyHost(new Uri(string.Format("http://{0}:80", domainToSpoof)));
        }

        public void Start()
        {
            host.Start();
        }

        public void Dispose()
        {
            host.Stop();
        }
    }
}
