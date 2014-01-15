﻿using System.Threading;
using System.Threading.Tasks;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.ScheduledTasks;
using MediaBrowser.Common.Security;
using MediaBrowser.Controller.Library;
using MediaBrowser.Controller.Plugins;
using AppleTV_MB3.Configuration;
using MediaBrowser.Model.Logging;
using System.Net;

namespace AppleTV_MB3
{
    /// <summary>
    /// Class ServerEntryPoint
    /// </summary>
    public class ServerEntryPoint : IServerEntryPoint, IRequiresRegistration
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static ServerEntryPoint Instance { get; private set; }

        /// <summary>
        /// The _task manager
        /// </summary>
        private readonly ITaskManager _taskManager;

        /// <summary>
        /// Access to the LibraryManager of MB Server
        /// </summary>
        public ILibraryManager LibraryManager { get; private set; }

        /// <summary>
        /// Access to the SecurityManager of MB Server
        /// </summary>
        public ISecurityManager PluginSecurityManager { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerEntryPoint" /> class.
        /// </summary>
        /// <param name="taskManager">The task manager.</param>
        /// <param name="appPaths">The app paths.</param>
        /// <param name="logManager"></param>
        public ServerEntryPoint(ITaskManager taskManager, ILibraryManager libraryManager, IApplicationPaths appPaths, ILogManager logManager, ISecurityManager securityManager)
        {
            _taskManager = taskManager;
            LibraryManager = libraryManager;
            PluginSecurityManager = securityManager;
            Plugin.Logger = logManager.GetLogger(Plugin.Instance.Name);

            dns = new DnsRelay.Server("secure.marketwatch.com", IPAddress.Parse("192.168.10.20"), IPAddress.Parse("8.8.8.8"));
            web = web = new AtvWebServer.Server("secure.marketwatch.com");

            Instance = this;
        }

        DnsRelay.Server dns;
        AtvWebServer.Server web;

        /// <summary>
        /// Runs this instance.
        /// </summary>
        public void Run()
        {
            dns.Start();
            web.Start();
        }

        /// <summary>
        /// Called when [configuration updated].
        /// </summary>
        /// <param name="oldConfig">The old config.</param>
        /// <param name="newConfig">The new config.</param>
        public void OnConfigurationUpdated(PluginConfiguration oldConfig, PluginConfiguration newConfig)
        {
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Loads our registration information
        ///
        /// </summary>
        /// <returns></returns>
        public async Task LoadRegistrationInfoAsync()
        {
            //Plugin.Instance.Registration = await PluginSecurityManager.GetRegistrationStatus("AppleTV_MB3", "[**MB2CompatibleFeature**]").ConfigureAwait(false);
        }
    }
}
