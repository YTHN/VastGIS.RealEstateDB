using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VastGIS.Common.Api.Events;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Events;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Services;

namespace VastGIS.Common.Plugins
{
    internal class PluginBroadcaster : IBroadcasterService
    {
        private readonly IPluginManager _manager;
        private readonly Dictionary<string, FieldInfo> _fields = new Dictionary<string,FieldInfo>();
        //private readonly Guid _symbologyPluginGuid = new Guid("F05CCFAF-26BB-4656-BBE2-0F5E3C7AD0FB");

        public event EventHandler<MenuItemEventArgs> MenuItemClicked;
        public event EventHandler<MenuItemEventArgs> StatusItemClicked;

        private static IBroadcasterService _instance;
        public static IBroadcasterService Instance
        {
            get { return _instance; }
        }

        public PluginBroadcaster(IPluginManager manager)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("Plugins manager is null.");
            }
            _manager = manager;

            _instance = this;
        }

   
     

        public void BroadcastEvent<T>(Expression<Func<BasePlugin, EventHandler<T>>> eventHandler, object sender, T args)
            where T : EventArgs
        {
           BroadcastEvent(eventHandler.Body as MemberExpression, sender, args, null);        
        }

        public void BroadcastEvent<T>(Expression<Func<BasePlugin, EventHandler<T>>> eventHandler, object sender, T args, PluginIdentity identity)
            where T : EventArgs
        {
            BroadcastEvent(eventHandler.Body as MemberExpression, sender, args, identity);
        }

        /// <summary>
        /// Returns list of active plugins with default handler in the last position. 
        /// </summary>
        private List<BasePlugin> GetActiveList(Guid? defaultHandler)
        {
            var handler = defaultHandler != null ? _manager.ListeningPlugins.FirstOrDefault(p => p.Identity.Guid == defaultHandler) : null;

            var plugins = handler == null ? _manager.ListeningPlugins : _manager.ListeningPlugins.Where(p => p != handler);
            var list = plugins.ToList();

            if (handler != null)
            {
                list.Add(handler);
            }
            return list;
        }

        private void BroadcastEvent<T>(MemberExpression expression, object sender, T args, PluginIdentity identity, Guid? defaultHandler = null)
            where T : EventArgs
        {
            if (expression == null)
            {
                return;
            }
            
            string eventName = expression.Member.Name;

            var singleTargetArgs = args as SingleTargetEventArgs;

            var fieldInfo = GetEventField(eventName);
            if (fieldInfo != null)
            {
                var list = GetActiveList(defaultHandler);

                foreach (var p in list)
                {
                    if (identity != null && p.Identity != identity)
                    {
                        continue;   // it's a wrong target
                    }

                    var del = fieldInfo.GetValue(p) as MulticastDelegate;
                    if (del != null)
                    {
                        if (del.GetInvocationList().Any())
                        {
                            del.Method.Invoke(del.Target, new[] { sender, args });
                        }
                    }

                    // in case we want only one handler
                    if (singleTargetArgs != null && singleTargetArgs.Handled)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Returns cached field for particular event.
        /// </summary>
        private FieldInfo GetEventField(string eventName)
        {
            if (!_fields.ContainsKey(eventName))
            {
                var fieldInfo = typeof(BasePlugin).GetField(eventName, BindingFlags.Instance | BindingFlags.NonPublic);
                _fields.Add(eventName, fieldInfo);
                return fieldInfo;
            }

            return _fields[eventName];
        }

        private void BroadcastPluginItemClicked(object sender, MenuItemEventArgs e)
        {
            var item = sender as IMenuItem;
            if (item != null)
            {
                BroadcastEvent(p => p.ItemClicked_, sender, e, item.PluginIdentity);
            }
            var cmd = sender as MenuCommand;
            if (cmd != null)
            {
                BroadcastEvent(p => p.ItemClicked_, sender, e, cmd.PluginIdentity);
            }
        }

        public void FireItemClicked(object sender, MenuItemEventArgs args)
        {
            var item = sender as IMenuItem;
            if (item != null)
            {
                if (item.PluginIdentity == PluginIdentity.Default)
                {
                    var handler = MenuItemClicked;
                    if (handler != null)
                    {
                        handler.Invoke(sender, args);
                    }
                }
                else
                {
                    BroadcastPluginItemClicked(sender, args);
                }
            }

            var cmd = sender as MenuCommand;
            if (cmd != null)
            {
                if (cmd.PluginIdentity == PluginIdentity.Default)
                {
                    var handler = MenuItemClicked;
                    if (handler != null)
                    {
                        handler.Invoke(sender, args);
                    }
                }
                else
                {
                    BroadcastPluginItemClicked(sender, args);
                }
            }
        }

        public void FireStatusItemClicked(object sender, MenuItemEventArgs args)
        {
            var item = sender as IMenuItem;
            if (item != null)
            {
                if (item.PluginIdentity == PluginIdentity.Default)
                {
                    var handler = StatusItemClicked;
                    if (handler != null)
                    {
                        handler.Invoke(sender, args);
                    }
                }
                else
                {
                    BroadcastPluginItemClicked(sender, args);
                }
            }
        }
    }
}
