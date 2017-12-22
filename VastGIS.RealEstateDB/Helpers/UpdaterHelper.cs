// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdaterHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Defines the UpdaterHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Shared;

namespace VastGIS.RealEstateDB.Helpers
{
    public static class UpdaterHelper
    {
        private static bool _isx64;

        /// <summary>
        /// Downloads the latest version, if it exists.
        /// </summary>
        public static void GetLatestVersion()
        {
            var config = AppConfig.Instance;

            // TODO: Need modifications, skip for now:
            return;

        }

        /// <summary>
        /// Checks if a new version is available to download
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="isx64">Is the current assembly x64.</param>
        /// <param name="type">The type, stable or beta</param>
        /// <param name="fileVersionInfo">The file version information.</param>
        /// <param name="downloadUrl">The download URL.</param>
        /// <param name="installerName">Name of the installer.</param>
        /// <returns>True when a new version is available</returns>
        private static bool CheckVersions(
            IReadOnlyDictionary<string, InstallerInfo> result, 
            bool isx64, 
            string type, 
            FileVersionInfo fileVersionInfo, 
            out string downloadUrl,
            out string installerName)
        {
            var key = isx64 ? type + "-x64" : type + "-x86";
            Version latestVersion;
            try
            {
                latestVersion = result[key].Versionnumber;
                downloadUrl = result[key].DownloadUrl;
                installerName = result[key].Name;
            }
            catch (Exception ex)
            {
                Logger.Current.Debug("Warning in CheckVersions: " + ex.Message);
                downloadUrl = string.Empty;
                installerName = string.Empty;
                return false;
            }

            Logger.Current.Debug("Latest {0} version: {1}", type, latestVersion);
            if (latestVersion.Major >= fileVersionInfo.ProductMajorPart && latestVersion.Minor >= fileVersionInfo.ProductMinorPart
                && latestVersion.Build >= fileVersionInfo.ProductBuildPart && latestVersion.Revision > fileVersionInfo.ProductPrivatePart)
            {
                Logger.Current.Debug("New {0} version [{1}] available at {2}", type, latestVersion, downloadUrl);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Start method to download a possible newer version
        /// </summary>
        private static async void DownloadNewerVersion()
        {
            // TODO: Needs modifications. For now, skip:
            return;

         
        }

        /// <summary>
        /// Structure to deserialize the json file
        /// </summary>
        public struct InstallerInfo
        {
            public string Cpu { get; set; }

            public string Description { get; set; }

            public string DownloadUrl { get; set; }

            public string Name { get; set; }

            public Version Versionnumber { get; set; }
        }
    }
}