using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppleTV_MB3.AtvWebServer.Modules
{
    public class Home : NancyModule
    {
        public Home()
        {
            Get["/"] = x =>
            {
                return "I am borg!";
            };
        }
    }
}
