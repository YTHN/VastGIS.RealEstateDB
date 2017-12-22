using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.Common.Plugins.Interfaces;

namespace VastGIS.Common.UI.Menu
{
    internal class ToolbarCollectionMain : ToolbarCollectionBase, IToolbarCollection
    {
        internal ToolbarCollectionMain(object menuManager, IMenuIndex menuIndex)
            : base(menuManager, menuIndex)
        {
        }

        public IToolbar MapToolbar
        {
            get { return this.FirstOrDefault(t => t.Key == MAP_TOOLBAR_KEY); }
        }

        public IToolbar FileToolbar
        {
            get { return this.FirstOrDefault(t => t.Key == FILE_TOOLBAR_KEY); }
        }
    }
}
