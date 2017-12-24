// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Manages the startup of the application and interaction with main view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using VastGIS.Common.Api.Concrete;
using VastGIS.Common.Api.Enums;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Events;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Mvp;
using VastGIS.Common.Plugins.Services;
using VastGIS.Common.Shared;
using VastGIS.Helpers;
using VastGIS.Listeners;
using VastGIS.RealEstateDB.Controls;
using VastGIS.RealEstateDB.Forms;
using VastGIS.RealEstateDB.Helpers;
using VastGIS.RealEstateDB.Menu;


namespace VastGIS.RealEstateDB.Views
{
    /// <summary>
    /// Manages the startup of the application and interaction with main view.
    /// </summary>
    public class MainPresenter : BasePresenter<IMainView>
    {
        private readonly IConfigService _configService;
        private readonly IAppContext _context;

        private readonly MainPluginListener _mainPluginListener;

        private readonly MenuGenerator _menuGenerator;
        private readonly MenuListener _menuListener;
        private readonly MenuUpdater _menuUpdater;
        private readonly IProjectService _projectService;
        private readonly StatusBarListener _statusBarListener;

        public MainPresenter(
            IAppContext context,
            IMainView view,
            IProjectService projectService,
            IConfigService configService
        )
            : base(view)
        {
            Logger.Current.Trace("Start MainPresenter");
            if (view == null) throw new ArgumentNullException("view");
            if (projectService == null) throw new ArgumentNullException("projectService");
            if (configService == null) throw new ArgumentNullException("configService");

            // PM 2016-03-02 Added:
            //修改，依据界面类型来判断是否为一般形态还是Ribbon


            _context = context;
            _projectService = projectService;
            _configService = configService;
            GdalConfiguration.ConfigureOgr();
            GlobalListeners.Attach(Logger.Current);


            try
            {
                var appContext = context as AppContext;
                if (appContext == null)
                {
                    throw new InvalidCastException("Invalid type of IAppContext instance");
                }

                appContext.Init(view, projectService, configService);


                view.ViewClosing += OnViewClosing;
                view.ViewUpdating += OnViewUpdating;
                view.BeforeShow += OnBeforeShow;

                var container = context.Container;
                _statusBarListener = container.GetSingleton<StatusBarListener>();
                _menuGenerator = container.GetSingleton<MenuGenerator>();
                _menuListener = container.GetSingleton<MenuListener>();
                _mainPluginListener = container.GetSingleton<MainPluginListener>();
                _menuUpdater = new MenuUpdater(_context, PluginIdentity.Default);
                SplashView.Instance.ShowStatus("Loading plugins");
                appContext.InitPlugins(configService); // must be called after docking is initialized

                // this will display progress updates and debug window
                // file based-logger is already working
                Logger.Current.Init(appContext);
            }
            finally
            {
            }

            View.AsForm.Shown += ViewShown;
            Logger.Current.Trace("End MainPresenter");
        }

        private void ViewShown(object sender, EventArgs e)
        {
            Application.DoEvents();

            LoadLastProject();
        }

        public override bool ViewOkClicked()
        {
            return true; // there is no ok button
        }

        private void LoadLastProject()
        {
            // for development only
            var config = _configService.Config;
            if (!config.LoadLastProject || !File.Exists(config.LastProjectPath))
            {
                return;
            }

            try
            {
                _projectService.Open(config.LastProjectPath, true);
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Error on project loading: <{0}>", ex, config.LastProjectPath);
            }
        }

        private void OnBeforeShow()
        {
            _menuListener.RunCommand(MenuKeys.Welcome);


            UpdaterHelper.GetLatestVersion();
        }

        private void OnViewClosing(object sender, CancelEventArgs e)
        {
            _configService.Config.LastProjectPath = _projectService.Filename;
            _configService.SaveAll();

            if (!_projectService.TryClose())
            {
                e.Cancel = true;
            }

            // Check if a new installer is still downloading:
            //if (AppConfig.Instance.UpdaterIsDownloading)
            //{
            //    if (
            //        MessageService.Current.Ask(
            //            "A new version of MapWindow is being downloaded, but hasn't finished yet. Do you want to wait for it? In the debug window a message will be added when the download is finished."))
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //}

            // Check if a new installer is downloaded and can be installed:
            //if (AppConfig.Instance.UpdaterHasNewInstaller)
            //{
            //    var filename = AppConfig.Instance.UpdaterInstallername;
            //    if (File.Exists(filename))
            //    {
            //        if (MessageService.Current.Ask("A new installer is downloaded do you want to install it now?"))
            //        {
            //            AppConfig.Instance.UpdaterHasNewInstaller = false;
            //            _configService.SaveAll();
            //            var myProcess = new Process { StartInfo = { UseShellExecute = false, FileName = filename, CreateNoWindow = true } };
            //            myProcess.Start();
            //        }
            //    }
            //}
        }

        private void OnViewUpdating(object sender, RenderedEventArgs e)
        {
            _menuUpdater.Update(e.Rendered);

            _statusBarListener.Update();

            var appContext = _context as AppContext;
            if (appContext != null)
            {
                appContext.Broadcaster.BroadcastEvent(p => p.ViewUpdating_, sender, e);
            }
        }
    }
}