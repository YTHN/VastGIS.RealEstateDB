using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Enums;
using VastGIS.Common.Plugins.Events;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.RealEstateDB.Views;


namespace VastGIS.RealEstateDB.Menu
{
    public class StatusBarListener
    {
        private readonly IAppContext _context;

        public StatusBarListener(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            
            _context = context;

            InitStatusBar();

            var appContext = context as AppContext;
            if (appContext != null)
            {
                appContext.Broadcaster.StatusItemClicked += PluginManager_MenuItemClicked;
            }

          
        }

    
        
        private void InitStatusBar()
        {
            var bar = _context.StatusBar;
            
            var progressMsg = bar.Items.AddLabel("Progress", StatusBarKeys.ProgressMsg, Identity);
            progressMsg.BeginGroup = true;
            progressMsg.Visible = false;

            bar.Items.AddProgressBar(StatusBarKeys.ProgressBar, Identity).Visible = false;

            bar.Update();
        }

        private void PluginManager_MenuItemClicked(object sender, MenuItemEventArgs e)
        {
            var menuItem = sender as IMenuItem;
            if (menuItem == null)
            {
                throw new InvalidCastException("Invalid type of menu item. IMenuItem interface is expected");
            }

            switch (e.ItemKey)
            {
                
                
                default:
                    // do nothing
                    break;
            }
        }

        private PluginIdentity Identity
        {
            get { return PluginIdentity.Default; }
        }

        protected IMenuItem FindItem(string itemKey)
        {
            return _context.StatusBar.FindItem(itemKey, Identity);
        }

        public void Update()
        {
            var bar = _context.StatusBar;

        }

      

    

     

      
    }
}
