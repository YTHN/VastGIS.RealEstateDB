using VastGIS.Common.Plugins.Interfaces;


namespace VastGIS.Common.Plugins.Helpers
{
    public static class AppContextHelper
    {
        /// <summary>
        /// Clears selection from all layers.
        /// </summary>
       

        /// <summary>
        /// Activates the panel. Use DockPanelKeys members to specify correct key.
        /// </summary>
        internal static void ActivatePanel(this IAppContext context, string dockPanelKey)
        {
            var panel = context.DockPanels.Find(dockPanelKey);
            if (panel != null)
            {
                panel.Visible = true;
                panel.Activate();
            }
        }

      
    }
}
