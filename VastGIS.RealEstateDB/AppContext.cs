// -------------------------------------------------------------------------------------------
// <copyright file="AppContext.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using VastGIS.Common.Api.Enums;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Enums;
using VastGIS.Common.Plugins.Events;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Mvp;
using VastGIS.Common.Plugins.Services;
using VastGIS.Common.Services.Serialization;
using VastGIS.Common.Shared;
using VastGIS.Common.UI.Docking;
using VastGIS.Common.UI.Forms;
using VastGIS.Common.UI.Menu;
using VastGIS.Common.UI.Style;
using VastGIS.Helpers;
using VastGIS.RealEstateDB.Controls;
using VastGIS.RealEstateDB.Helpers;

namespace VastGIS.RealEstateDB
{
    /// <summary>
    /// Central class storing all the resource avaialable for plugins.
    /// </summary>
    public class AppContext : ISecureContext
    {
        private readonly IApplicationContainer _container;

        private readonly IStyleService _styleService;
       
        private IConfigService _configService;

     
        private IMainView _mainView;
      
        private IProjectService _project;
     
        private List<ICommand> _commands;

        public AppContext(
            IApplicationContainer container,
            IStyleService styleService)
        {
            Logger.Current.Trace("In AppContext");
            if (container == null) throw new ArgumentNullException("container");
            if (styleService == null) throw new ArgumentNullException("styleService");
         
            _container = container;
         
            _styleService = styleService;
          
            _commands=new List<ICommand>();
        }

        public IBroadcasterService Broadcaster { get; private set; }

        public IApplicationContainer Container
        {
            get { return _container; }
        }

        public IProject Project
        {
            get { return _project as IProject; }
        }

        public IAppView View { get; private set; }

      

     

        public IStatusBar StatusBar { get; private set; }

        public IMenu Menu { get; private set; }

        public IToolbarCollection Toolbars { get; private set; }

     

        public IDockPanelCollection DockPanels { get; private set; }

     

        public AppConfig Config
        {
            get { return _configService.Config; }
        }

   
        public SynchronizationContext SynchronizationContext { get; private set; }

     
        public MainViewType ViewType
        {
            get { return _mainView.ViewType; }
        }

        public IRibbonMenu RibbonMenu
        {
            get;
            private set;
        }

     

        public List<ICommand> Commands
        {
            get { return _commands; }
            set { _commands = value; }
        }

        public bool Initialized { get; private set; }

    
        public IPluginManager PluginManager { get; private set; }

        public Control GetDockPanelObject(DefaultDockPanel panel)
        {
            switch (panel)
            {
               
                default:
                    throw new ArgumentOutOfRangeException("panel");
            }
        }

        public void Close()
        {
            _mainView.Close();
        }

        /// <summary>
        /// Sets all the necessary references from the main view. 
        /// </summary>
        /// <remarks>We don't use contructor injection here since most of other services use this one as a parameter.
        /// Perhaps property injection can be used.</remarks>
        internal void Init(
            IMainView mainView,
            IProjectService project,
            IConfigService configService
          )
        {
            Logger.Current.Trace("Start AppContext.Init()");
            if (mainView == null) throw new ArgumentNullException("mainView");
            if (project == null) throw new ArgumentNullException("project");

          

           

            // it's expected here that we are on the UI thread
            SynchronizationContext = SynchronizationContext.Current;

            PluginManager = _container.GetSingleton<IPluginManager>();
            Broadcaster = _container.GetSingleton<IBroadcasterService>();
       
            _mainView = mainView;
            View = new AppView(mainView, _styleService);
            _project = project;
           _configService = configService;
      
          
            
                DockPanels = new DockPanelCollection(mainView.DockingManager, mainView as Form, Broadcaster,
                    _styleService);
                //创建Ribbon主菜单
                RibbonMenu = MenuFactory.CreateRibbonMenu(mainView.RibbonControlAdv);

           
            StatusBar = MenuFactory.CreateStatusBar(mainView.StatusBar, PluginIdentity.Default);

    

            this.InitDocking();

            Initialized = true;
            Logger.Current.Trace("End AppContext.Init()");
        }

        internal void InitPlugins(IConfigService configService)
        {
            var pluginManager = PluginManager;
            pluginManager.PluginUnloaded += ManagerPluginUnloaded;
            pluginManager.AssemblePlugins();

            var guids = configService.Config.ApplicationPlugins;
            if (guids != null)
            {
                PluginManager.RestoreApplicationPlugins(guids, this);
            }
        }

        private void ManagerPluginUnloaded(object sender, PluginEventArgs e)
        {
            if(Toolbars!=null)
            Toolbars.RemoveItemsForPlugin(e.Identity);
            if (ViewType == MainViewType.Normal) Menu.RemoveItemsForPlugin(e.Identity);
            else
            {
                
            }
            DockPanels.RemoveItemsForPlugin(e.Identity);
            StatusBar.RemoveItemsForPlugin(e.Identity);
        }
    }
}