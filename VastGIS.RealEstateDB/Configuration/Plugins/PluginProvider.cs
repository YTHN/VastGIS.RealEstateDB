using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VastGIS.Common.Plugins.Services;

namespace VastGIS.RealEstateDB.Configuration.Plugins
{
    internal class PluginProvider : IEnumerable<PluginInfo>
    {
        private readonly IEnumerable<PluginInfo> _list;

        public PluginProvider(IPluginManager manager)
        {
            if (manager == null) throw new ArgumentNullException("manager");
            _list = manager.AllPlugins.Select(p => new PluginInfo(p, p.IsApplicationPlugin)).ToList();
        }

        public IEnumerator<PluginInfo> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
