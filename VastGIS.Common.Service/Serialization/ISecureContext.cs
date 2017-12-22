using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VastGIS.Common.Plugins;
using VastGIS.Common.Plugins.Enums;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Services;

namespace VastGIS.Common.Services.Serialization
{
    public interface ISecureContext: IAppContext
    {
        IPluginManager PluginManager { get; }
        Control GetDockPanelObject(DefaultDockPanel panel);
    }
}
