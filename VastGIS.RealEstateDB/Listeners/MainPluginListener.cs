// -------------------------------------------------------------------------------------------
// <copyright file="MainPluginListener.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing.Imaging;
using System.Windows.Forms;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Services;
using VastGIS.Common.Shared;


namespace VastGIS.Listeners
{
    public class MainPluginListener
    {
        private readonly IBroadcasterService _broadcaster;
        private readonly IConfigService _configService;
        private readonly IAppContext _context;
        private readonly MainPlugin _plugin;

        public MainPluginListener(
            IAppContext context,
            MainPlugin plugin,
            IConfigService configService,
            IBroadcasterService broadcaster)
        {
            Logger.Current.Trace("In MainPluginListener");
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            if (configService == null) throw new ArgumentNullException("configService");
            if (broadcaster == null) throw new ArgumentNullException("broadcaster");

            _context = context;
            _plugin = plugin;
            _configService = configService;
            _broadcaster = broadcaster;

            
        }

      

       
    }
}