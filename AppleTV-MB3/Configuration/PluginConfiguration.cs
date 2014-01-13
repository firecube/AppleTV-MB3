using MediaBrowser.Model.Plugins;

namespace AppleTV_MB3.Configuration
{
    /// <summary>
    /// Class PluginConfiguration
    /// </summary>
    public class PluginConfiguration : BasePluginConfiguration
    {

        /// <summary>
        /// My plug-in optin
        /// </summary>
        /// <value>The option.</value>
        public string MyOption { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginConfiguration" /> class.
        /// </summary>
        public PluginConfiguration()
        {
            MyOption = "some default";
        }
    }
}
