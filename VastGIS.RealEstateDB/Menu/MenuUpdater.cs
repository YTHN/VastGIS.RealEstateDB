using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VastGIS.Common.Api.Enums;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.UI.Menu;

namespace VastGIS.RealEstateDB.Menu
{
    internal class MenuUpdater: MenuServiceBase
    {
      
      

        public MenuUpdater(IAppContext context, PluginIdentity identity) 
            : base(context, identity)
        {
            
           
        }

        public void Update(bool rendered)
        {
            
                UpdateMenu();
            

            
        }

        private void UpdateMenu()
        {

            
                ToolStripItem oneItem;
                oneItem=FindToolStripItem(MenuKeys.RemoveLayer);
                if(oneItem != null) oneItem.Enabled = false;
                oneItem = FindToolStripItem(MenuKeys.LayerClearSelection);
                if (oneItem != null) oneItem.Enabled = true;
              

                var config = AppConfig.Instance;
           
            
           
        }

      
    }
}
