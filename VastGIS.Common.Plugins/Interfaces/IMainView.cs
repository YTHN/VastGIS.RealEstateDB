using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.Common.Api.Enums;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Events;
using VastGIS.Common.Plugins.Mvp;

namespace VastGIS.Common.Plugins.Interfaces
{
    public interface IMainView : IView
    {
        object DockingManager { get; }
        object MenuManager { get; }
        object StatusBar { get; }
        object RibbonControlAdv { get; }
     
        IView View { get; }
        MainViewType ViewType { get; }
        event EventHandler<CancelEventArgs> ViewClosing;
        event EventHandler<RenderedEventArgs> ViewUpdating;
        event Action BeforeShow;
        void Lock();
        void Unlock();
        void DoUpdateView(bool focusMap = true);
    }
}
