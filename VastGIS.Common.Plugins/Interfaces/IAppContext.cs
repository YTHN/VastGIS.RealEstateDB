// -------------------------------------------------------------------------------------------
// <copyright file="IAppContext.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Mvp;
namespace VastGIS.Common.Plugins.Interfaces
{
    public interface IAppContext
    {
        AppConfig Config { get; }

        IApplicationContainer Container { get; }

        IDockPanelCollection DockPanels { get; }
    

        IMenu Menu { get; }

        IProject Project { get; }
    

        IStatusBar StatusBar { get; }

        SynchronizationContext SynchronizationContext { get; }

        IToolbarCollection Toolbars { get; }

        IAppView View { get; }

        bool Initialized { get; }

        IRibbonMenu RibbonMenu { get; }

     
        List<ICommand> Commands { get; set; }
    }
    
}