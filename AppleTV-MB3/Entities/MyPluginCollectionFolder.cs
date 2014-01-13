using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using MediaBrowser.Common.Extensions;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Entities.Movies;
using MediaBrowser.Model.Entities;
using System.Linq;

namespace AppleTV_MB3.Entities
{
    /// <summary>
    /// Class TrailerCollectionFolder
    /// </summary>
    class MyPluginCollectionFolder : BasePluginFolder
    {
        public MyPluginCollectionFolder()
        {
            Name = "AppleTV_MB3";
        }

    }

    /// <summary>
    /// Class PluginFolderCreator
    /// </summary>
    public class PluginFolderCreator : IVirtualFolderCreator
    {
        /// <summary>
        /// Gets the folder.
        /// </summary>
        /// <returns>BasePluginFolder.</returns>
        public BasePluginFolder GetFolder()
        {
            return new MyPluginCollectionFolder
            {
                Id = "AppleTV_MB3".GetMBId(typeof(MyPluginCollectionFolder)),
            };

        }
    }
}
