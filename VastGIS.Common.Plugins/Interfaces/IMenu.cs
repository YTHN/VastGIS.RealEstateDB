using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VastGIS.Common.Plugins.Concrete;

namespace VastGIS.Common.Plugins.Interfaces
{
    public interface IMenu: IMenuBase
    {
        IDropDownMenuItem FileMenu { get; }

        IDropDownMenuItem LayerMenu { get; }

        IDropDownMenuItem ViewMenu { get; }

        IDropDownMenuItem PluginsMenu { get; }

        IDropDownMenuItem TilesMenu { get; }

        IDropDownMenuItem ToolsMenu { get; }

        IDropDownMenuItem HelpMenu { get; }

        IDropDownMenuItem MapMenu { get; }
    }

    public interface IRibbonMenu
    {
        object MainItems { get; }
        object QuickItems { get; }

        ToolStripItem FindToolStripItem(string key, PluginIdentity identity);

    }
    
}
