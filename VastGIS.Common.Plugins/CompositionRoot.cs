using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Enums;
using VastGIS.Common.Plugins.Helpers;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Mvp;
using VastGIS.Common.Plugins.Services;
using VastGIS.Common.Shared;

namespace VastGIS.Common.Plugins
{
    internal static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterSingleton<IBroadcasterService, PluginBroadcaster>()
                .RegisterSingleton<IPluginManager, PluginManager>()
                .RegisterSingleton<MainPlugin>();

            EnumHelper.RegisterConverter(new AutoToggleConverter());
       
        }
    }
}
