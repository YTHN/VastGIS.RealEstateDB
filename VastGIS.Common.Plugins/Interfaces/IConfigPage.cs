// -------------------------------------------------------------------------------------------
// <copyright file="IConfigPage.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Drawing;
using VastGIS.Common.Plugins.Enums;

namespace VastGIS.Common.Plugins.Interfaces
{
    public interface IConfigPage
    {
        string Description { get; }

        Bitmap Icon { get; }

        string PageName { get; }

        ConfigPageType PageType { get; }

        ConfigPageType ParentPage { get; }

        object Tag { get; set; }

        /// <summary>
        /// Gets a value indicating whether the page height can be adjusted to fit the the parent.
        /// </summary>
        bool VariableHeight { get; }

        void Initialize();

        void Save();

        int ImageIndex { get; set; }

        Size OriginalSize { get; set; }
    }
}