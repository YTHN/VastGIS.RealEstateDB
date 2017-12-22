using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Enums;
using VastGIS.Common.Plugins.Events;

namespace VastGIS.Common.Plugins.Interfaces
{
    internal interface IMenuIndex
    {
        void AddItem(string key, IMenuItem item);
        void Remove(string key);
        IMenuItem GetItem(string key);
        void RemoveItemsForPlugin(PluginIdentity pluginIdentity);
        IEnumerable<IMenuItem> ItemsForPlugin(PluginIdentity pluginIdentity);
        void Clear();
        void SaveMetadata(object key, MenuItemCollectionMetadata metadata);
        MenuItemCollectionMetadata LoadMetadata(object key);
        MenuIndexType ToolbarType { get; }
        bool NeedsToolTip { get; }
        bool IsMainMenu { get; }
        event EventHandler<MenuItemEventArgs> ItemClicked;
        void FireItemClicked(object sender, MenuItemEventArgs e);
    }
}
