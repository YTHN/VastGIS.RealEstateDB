using System.Collections.Generic;
using VastGIS.Plugins.Mvp;

namespace VastGIS.Plugins.Interfaces
{
    public interface ISimpleAppContext
    {
        IApplicationContainer Container { get; }

        IDockPanelCollection DockPanels { get; }
        IStatusBar StatusBar { get; }

        IAppView View { get; }

        bool Initialized { get; }

        IRibbonMenu RibbonMenu { get; }

        List<ICommand> Commands { get; set; }
    }
}