using VastGIS.Common.UI.Controls;
using VastGIS.RealEstateDB.Configuration.Plugins;

namespace VastGIS.RealEstateDB.Configuration
{
    internal class PluginGrid: StronglyTypedGrid<PluginInfo>
    {
        public PluginGrid()
        {
            Adapter.HotTracking = false;
            Adapter.ShowSuperTooltips = true;
            Adapter.ReadOnly = false;
            Adapter.AllowCurrentCell = false;
            WrapWithPanel = false;
        }

        protected override void UpdateColumns()
        {
            // do nothing
        }
    }
}
