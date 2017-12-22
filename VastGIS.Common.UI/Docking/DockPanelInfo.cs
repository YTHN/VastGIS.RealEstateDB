using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.Common.Plugins.Concrete;

namespace VastGIS.Common.UI.Docking
{
    internal class DockPanelInfo
    {
        public DockPanelInfo(PluginIdentity identity, string key)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new NullReferenceException("");
            }
            Identity = identity;
            Key = key;
        }
        public PluginIdentity Identity { get; set; }
        public string Key { get; set; }
    }
}
