using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.Common.Plugins.Concrete;

namespace VastGIS.Common.Plugins.Interfaces
{
    public interface IMenuBase: IToolbar
    {
        IMenuItem FindItem(string key, PluginIdentity identity);

        void RemoveItemsForPlugin(PluginIdentity identity);
    }
}
