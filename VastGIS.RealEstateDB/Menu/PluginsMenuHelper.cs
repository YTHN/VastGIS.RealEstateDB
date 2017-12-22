using System;
using System.Collections.Generic;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Events;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Services;


namespace VastGIS.RealEstateDB.Menu
{
    internal static class PluginsMenuHelper
    {
        private static IPluginManager _manager;
        private static IAppContext _context;

        internal static void Init(IAppContext context, IPluginManager pluginManager)
        {
            if (context == null || pluginManager == null)
            {
                throw new NullReferenceException("Failed to initialize plugins.");
            }
            _context = context;
            _manager = pluginManager;

            var menuItem = context.Menu.PluginsMenu;
            menuItem.DropDownOpening += MenuDropDownOpening;
        }

        private static void ClearPlugins()
        {
            var list = new List<IMenuItem>();

            var menuItem = _context.Menu.PluginsMenu;

            foreach (var item in menuItem.SubItems)
            {
                if (!item.Skip && !item.HasKey)
                {
                    list.Add(item);
                }
            }

            foreach (var item in list)
            {
                menuItem.SubItems.Remove(item);
            }
        }

        private static void MenuDropDownOpening(object sender, EventArgs e)
        {
            ClearPlugins();

            var menuItem = _context.Menu.PluginsMenu;
            
            var configureItem = _context.Menu.FindItem(MenuKeys.PluginsConfigure, PluginIdentity.Default);
            menuItem.SubItems.InsertBefore = configureItem;

            foreach (var p in _manager.CustomPlugins)
            {
                var item = menuItem.SubItems.AddButton(p.Identity.Name, PluginIdentity.Default);
                item.Tag = p.Identity;
                item.ItemClicked += OnItemClick;
                item.Checked = _manager.PluginActive(p.Identity);
            }

            menuItem.Update();
        }

        private static void OnItemClick(object sender, MenuItemEventArgs e)
        {
            var item = sender as IMenuItem;
            if (item != null)
            {
                var identity = item.Tag as PluginIdentity;
                if (identity != null)
                {
                    if (item.Checked)
                    {
                        _manager.UnloadPlugin(identity, _context);
                    }
                    else
                    {
                        _manager.LoadPlugin(identity, _context);
                    }
                    item.Checked = !item.Checked;
                    _context.View.Update();
                }
            }
        }
    }
}
