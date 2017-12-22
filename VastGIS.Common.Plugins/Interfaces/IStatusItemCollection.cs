using System.Drawing;
using VastGIS.Common.Plugins.Concrete;

namespace VastGIS.Common.Plugins.Interfaces
{
    public interface IStatusItemCollection: IMenuItemCollection
    {
        IMenuItem AddProgressBar(string key, PluginIdentity identity);
        IDropDownMenuItem AddSplitButton(string text, string key, PluginIdentity identity);
    }
}
