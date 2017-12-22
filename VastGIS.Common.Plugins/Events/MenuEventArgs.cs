using System;
using VastGIS.Common.Plugins.Interfaces;

namespace VastGIS.Common.Plugins.Events
{
    public class MenuEventArgs: EventArgs
    {
        public MenuEventArgs(IMenuItem menuItem)
        {
            MenuItem = menuItem;
        }

        public IMenuItem MenuItem { get; private set; }
    }
}
