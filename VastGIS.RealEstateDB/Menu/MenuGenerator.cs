using System;
using System.Collections.Generic;
using VastGIS.Common.Api.Enums;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Enums;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Services;
using VastGIS.Common.Shared;
using VastGIS.Common.UI.Menu;
using VastGIS.Common.UI.Menu.Ribbon;
using ViewMenuHelper = VastGIS.Common.UI.Helpers.ViewMenuHelper;

namespace VastGIS.RealEstateDB.Menu
{
    internal class MenuGenerator
    {
       
        
        private readonly IAppContext _context;
        private readonly IPluginManager _pluginManager;
        private readonly MenuCommands _commands;
        private readonly object _menuManager;
        private readonly object _dockingManager;

        public MenuGenerator(IAppContext context, IPluginManager pluginManager, IMainView mainView)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (pluginManager == null) throw new ArgumentNullException("pluginManager");
            if (mainView == null) throw new ArgumentNullException("mainView");

            _context = context;
            _pluginManager = pluginManager;
            _menuManager = mainView.MenuManager;
            _dockingManager = mainView.DockingManager;
            _commands = new MenuCommands(_context,PluginIdentity.Default);
            _context.Commands.AddRange(_commands.GetCommands());
            
                InitRibbonMenu();
            
        }

        private void InitRibbonMenu()
        {
            RibbonMenu menu = _context.RibbonMenu as RibbonMenu;
            menu.AddHeaderTab("tabFile", "文件");
            menu.AddToolStripEx("toolStripFiles", "文件", "tabFile");

            menu.AddHeaderTab("tabView", "视图");
            menu.AddToolStripEx("toolStripView", "视图", "tabView");
            menu.AddToolStripEx("toolStripViewTools", "工具", "tabView");
            menu.AddToolStripEx("toolStripViewSelection", "选择", "tabView");


            menu.AddButton(_commands[MenuKeys.NewMap]);
       

            menu.AddButton(_commands[MenuKeys.OpenProject]);
            menu.AddButton(_commands[MenuKeys.SaveProject]);
            menu.AddButton(_commands[MenuKeys.SaveProjectAs]);

            menu.AddButton(_commands[Common.Plugins.Menu.MenuKeys.Quit]);
        }

      

        #region Menus

     

        private void InitPluginsMenu()
        {
            var menu = _context.Menu.PluginsMenu;
            menu.SubItems.AddButton("Configure Plugins...", MenuKeys.PluginsConfigure, PluginIdentity.Default).BeginGroup = true;
            
            PluginsMenuHelper.Init(_context, _pluginManager);
        }

      

     

        private void InitHelpMenu()
        {
            var items = _context.Menu.HelpMenu.SubItems;
            items.AddButton("Show Welcome Screen", MenuKeys.Welcome, PluginIdentity.Default);
            items.AddButton("Supported Drivers", MenuKeys.SupportedDrivers, PluginIdentity.Default);
            items.AddButton("COM Usage", MenuKeys.ComUsage, PluginIdentity.Default).BeginGroup = true;
            items.AddButton("About", MenuKeys.About, PluginIdentity.Default).BeginGroup = true;

            _context.Menu.HelpMenu.Update();
        }

        #endregion

       
    }
}
