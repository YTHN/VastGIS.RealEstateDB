// -------------------------------------------------------------------------------------------
// <copyright file="MenuListener.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using VastGIS.Common.Api.Enums;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Enums;
using VastGIS.Common.Plugins.Events;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Services;
using VastGIS.Common.Shared;
using VastGIS.Common.UI.Docking;
using VastGIS.RealEstateDB.Helpers;
using VastGIS.RealEstateDB.Views;


namespace VastGIS.RealEstateDB.Menu
{
    public class MenuListener
    {
        private readonly IAppContext _context;
        
        private readonly IProjectService _projectService;
      

        public MenuListener(
            IAppContext context,
            IProjectService projectService)
        {
            Logger.Current.Trace("In MenuListener");
            if (context == null) throw new ArgumentNullException("context");
            if (projectService == null) throw new ArgumentNullException("projectService");
          

            _context = context;
           
            _projectService = projectService;
            

            var appContext = context as AppContext;
            if (appContext != null)
            {
                appContext.Broadcaster.MenuItemClicked += MenuItemClicked;
            }

            //TilesMenuHelper.TileProviderSelected += OnTileProviderSelected;
            //TilesMenuHelper.ChooseActiveProvider += OnChooseActiveProvider;
        }

        public void RunCommand(string menuKey)
        {
            if ( HandleProjectCommand(menuKey) || HandleDialogs(menuKey) ||
                HandleHelpMenu(menuKey) )
            {
                _context.View.Update();
                return;
            }

            switch (menuKey)
            {
              
            
                case MenuKeys.PluginsConfigure:
                    {
                        var model = _context.Container.GetInstance<ConfigViewModel>();
                        model.SelectedPage = ConfigPageType.Plugins;
                        model.UseSelectedPage = true;
                        _context.Container.Run<ConfigPresenter, ConfigViewModel>(model);
                    }
                    break;
                default:
                    MessageService.Current.Info("There is no handler for menu item with key: " + menuKey);
                    break;
            }

            _context.View.Update();
        }

      

       

        private bool HandleDialogs(string itemKey)
        {
            switch (itemKey)
            {
                case MenuKeys.Settings:
                    var model = _context.Container.GetInstance<ConfigViewModel>();
                    _context.Container.Run<ConfigPresenter, ConfigViewModel>(model);
                    return true;
             
            }
            return false;
        }

        private bool HandleHelpMenu(string itemKey)
        {
            switch (itemKey)
            {
                case MenuKeys.Welcome:
                    var model = new WelcomeViewModel(AppConfig.Instance.RecentProjects);
                    _context.Container.Run<WelcomePresenter, WelcomeViewModel>(model);
                    return true;
                case MenuKeys.About:
                    _context.Container.Run<AboutPresenter>();
                    return true;
            }

            return false;
        }

      

        private bool HandleProjectCommand(string itemKey)
        {
            switch (itemKey)
            {
                case MenuKeys.Test:
                    //_context.Projections.UpdateEsriName(_context.Projections.Name);
                    return true;
                case MenuKeys.NewMap:
                    _projectService.TryClose();
                    return true;
                case MenuKeys.SaveProject:
                    if (_projectService.Save())
                    {
                        ShowProjectSaved();
                    }
                    return true;
                case MenuKeys.SaveProjectAs:
                    if (_projectService.SaveAs())
                    {
                        ShowProjectSaved();
                    }
                    return true;
                case MenuKeys.OpenProject:
                    _projectService.Open();
                    return true;
                case Common.Plugins.Menu.MenuKeys.Quit:
                    var appContext = _context as AppContext;
                    if (appContext != null)
                    {
                        appContext.Close();
                    }
                    return true;
            }
            return false;
        }

        private void MenuItemClicked(object sender, MenuItemEventArgs e)
        {
            //RunCommand(e.ItemKey);
            if (_context == null || _context.Commands == null || _context.Commands.Count == 0) return;
            ICommand command = _context.Commands.FirstOrDefault(c => c.Key == e.ItemKey);
            if (command != null)
            {
                command.OnClick();
                return;
            }

        }
        
     
        private void ShowProjectSaved()
        {
            MessageService.Current.Info("Project was saved: " + _projectService.Filename);
        }

    
    }
}