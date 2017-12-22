using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.Common.Api.Helpers;
using VastGIS.Common.Plugins;
using VastGIS.Common.Plugins.Mvp;
using VastGIS.Common.Plugins.Services;
using VastGIS.Common.UI.Style;

namespace VastGIS.Common.UI
{
    internal static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterService<IStyleService, SyncfusionStyleService>()
                .RegisterSingleton<ControlStyleSettings>();
        }
    }
}
