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
            Get["/mw2/api-video/appletv/wsjlive/main.js"] = x =>
            {
                var response = (Response)@"/*
 *
 * Main app entry point
 *
 */


atv.config = { 
    ""doesJavaScriptLoadRoot"": true,
    ""DEBUG_LEVEL"": 4
};


atv.onAppEntry = function()
{
    var xmlstr =
""<?xml version=\""1.0\"" encoding=\""UTF-8\""?> \
<atv> \
  <body> \
    <dialog id=\""com.sample.error-dialog\""> \
      <title>Media Browser...</title> \
      <description>... now owns this Apple TV!</description> \
    </dialog> \
  </body> \
</atv>"";
        
	var doc = atv.parseXML(xmlstr);
	atv.loadXML(doc);
};";
                response.ContentType = "text/javascript";
                return response;
            };
        }
    }
}
