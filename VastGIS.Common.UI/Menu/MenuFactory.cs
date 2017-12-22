using System;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Enums;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Shared;
using VastGIS.Common.UI.Enums;
using VastGIS.Common.UI.Menu.Classic;
using Syncfusion.Windows.Forms.Tools.XPMenus;
using VastGIS.Common.UI.Menu.Ribbon;

namespace VastGIS.Common.UI.Menu
{
    public class MenuFactory
    {
        private static IMenu _instance;
        private static IRibbonMenu _ribbonInstance;

      

        internal static IMenu CreateMainMenu(object menuManager)
        {
           
            if (_instance == null)
            {
                var menuIndex = new MenuIndex(MenuIndexType.MainMenu);

                if (DebugHelper.SyncfusionMenu)
                {
                    _instance = new MainSyncfusionMenu(menuManager, menuIndex);
                }
                else
                {
                    _instance = new MainMenuStripMenu(menuManager, menuIndex);
                }

                CreateDefaultMenuItems(_instance);
            }

            return _instance;
        }

        internal static IRibbonMenu CreateRibbonMenu(object menuManager)
        {
            if (_ribbonInstance == null)
            {
                _ribbonInstance=new RibbonMenu(menuManager);
            }

            return _ribbonInstance;
        }

        internal static IMenuEx CreateMenu(object menuManager)
        {
            var menuIndex = new MenuIndex(MenuIndexType.MainMenu, false);

            return new MenuStripMenu(menuManager, menuIndex);
        }

        internal static IStatusBar CreateStatusBar(object bar, PluginIdentity identity)
        {
            var menuIndex = new MenuIndex(MenuIndexType.StatusBar);
            var statusBar = new StatusBar(bar, menuIndex, identity);
            return statusBar;
        }

        internal static IToolbarCollection CreateMainToolbars(object menuManager)
        {
            var menuIndex = new MenuIndex(MenuIndexType.Toolbar);
            return new ToolbarCollectionMain(menuManager, menuIndex);
        }

        internal static IToolbarCollectionEx CreateToolbars(object menuManager)
        {
            var menuIndex = new MenuIndex(MenuIndexType.Toolbar, false);
            return new ToolbarCollection(menuManager, menuIndex);
        }

        private static void CreateDefaultMenuItems(IMenuBase menu)
        {
            var items = menu.Items;

            items.AddDropDown("File", MainMenuKeys.File, PluginIdentity.Default);
            items.AddDropDown("View", MainMenuKeys.View, PluginIdentity.Default);
            items.AddDropDown("Map", MainMenuKeys.Map, PluginIdentity.Default);
            items.AddDropDown("Layer", MainMenuKeys.Layer, PluginIdentity.Default);
            items.AddDropDown("Plugins", MainMenuKeys.Plugins, PluginIdentity.Default);
            items.AddDropDown("Tiles", MainMenuKeys.Tiles, PluginIdentity.Default);
            items.AddDropDown("Tools", MainMenuKeys.Tools, PluginIdentity.Default);
            items.AddDropDown("Help", MainMenuKeys.Help, PluginIdentity.Default);

            menu.Update();
        }

        //Ribbon界面初始化
        private static void CreateDefaultRibbonMenuItems(IMenuBase menu)
        {
            var items = menu.Items;

            //items.AddTabItem("项目", MainMenuKeys.File, PluginIdentity.Default);
            //items.AddTabItem("视图", MainMenuKeys.View, PluginIdentity.Default);
            //items.AddTabItem("地图", MainMenuKeys.Map, PluginIdentity.Default);
            //items.AddTabItem("图层", MainMenuKeys.Layer, PluginIdentity.Default);
            //items.AddTabItem("插件", MainMenuKeys.Plugins, PluginIdentity.Default);
            //items.AddTabItem("切片", MainMenuKeys.Tiles, PluginIdentity.Default);
            //items.AddTabItem("工具", MainMenuKeys.Tools, PluginIdentity.Default);
            //items.AddTabItem("帮助", MainMenuKeys.Help, PluginIdentity.Default);

            menu.Update();
        }
    }
}
