using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.Common.Plugins.Events;
using VastGIS.Common.Plugins.Interfaces;

namespace VastGIS.Common.UI.Menu
{
    internal class ToolbarCollection: ToolbarCollectionBase, IToolbarCollectionEx
    {
        internal ToolbarCollection(object menuManager, IMenuIndex menuIndex)
            : base(menuManager, menuIndex)
        {
        }

        public event EventHandler<MenuItemEventArgs> ItemClicked
        {
            add { _menuIndex.ItemClicked += value; }
            remove { _menuIndex.ItemClicked -= value; }
        }
    }
}
