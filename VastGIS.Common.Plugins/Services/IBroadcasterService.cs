using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Events;

namespace VastGIS.Common.Plugins.Services
{
    public interface IBroadcasterService
    {
        /// <summary>
        /// Broadcasts map event to all the listening plugins.
        /// </summary>
        //void BroadcastEvent<T>(Expression<Func<BasePlugin, MapEventHandler<T>>> eventHandler, IMuteMap sender, T args)
        //    where T : EventArgs;

        //void BroadcastEvent<T>(Expression<Func<BasePlugin, LegendEventHandler<T>>> eventHandler, IMuteLegend sender, T args)
        //    where T : EventArgs;

        void BroadcastEvent<T>(Expression<Func<BasePlugin, EventHandler<T>>> eventHandler, object sender, T args)
            where T : EventArgs;

        void BroadcastEvent<T>(Expression<Func<BasePlugin, EventHandler<T>>> eventHandler, object sender, T args, PluginIdentity identity)
            where T : EventArgs;

        event EventHandler<MenuItemEventArgs> MenuItemClicked;
        event EventHandler<MenuItemEventArgs> StatusItemClicked;

        void FireItemClicked(object sender, MenuItemEventArgs args);

        void FireStatusItemClicked(object sender, MenuItemEventArgs args);
    }
}
