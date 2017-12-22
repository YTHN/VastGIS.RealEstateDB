using System.Diagnostics;
using System.Drawing;
using Syncfusion.Windows.Forms.Tools;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Enums;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Services.Serialization;
using VastGIS.Common.UI.Docking;

namespace VastGIS.RealEstateDB.Helpers
{
    internal static class DockPanelHelper
    {
        private const int PanelSize = 300;

        public static void InitDocking(this ISecureContext context)
        {
            var panels = context.DockPanels;
            if(panels!=null)
            panels.Lock();
            panels.Unlock();
        }

        

        //private static void InitLegend(ISecureContext context)
        //{
        //    var legendControl = context.GetDockPanelObject(DefaultDockPanel.Legend);
        //    var legend = context.DockPanels.Add(legendControl, DockPanelKeys.Legend, PluginIdentity.Default);
        //    legend.Caption = "Legend";
        //    legend.DockTo(null, DockPanelState.Left, PanelSize);
        //    legend.SetIcon(Resources.ico_legend);
        //}

       

      

        public static void ClosePanel(IAppContext context, string dockPanelKey)
        {
            var panel = context.DockPanels.Find(dockPanelKey);
            if (panel != null)
            {
                panel.Visible = false;
            }
        }

        public static void ShowPanel(IAppContext context, string dockPanelKey)
        {
            var panel = context.DockPanels.Find(dockPanelKey);
            if (panel != null)
            {
                panel.Visible = true;
                panel.Activate();
                panel.Focus();
            }
        }

        public static void SerializeDockState(IAppContext context)
        {
            var panels = context.DockPanels;
            panels.Lock();

            foreach (var panel in panels)
            {
                Debug.Print(panel.Caption);
                Debug.Print("Hidden: " + panel.AutoHidden);
                Debug.Print("Visible: " + panel.Visible);
                Debug.Print("Style: " + panel.DockState);

                //bool hidden = panel.Hidden;
                //if (hidden)
                //{
                //    panel.Hidden = false;
                //}

                //bool visible = panel.Visible;
                //if (!visible)
                //{
                //    panel.Visible = true;
                //}

                var host = panel.Control.Parent as DockHost;
                if (host != null)
                {


                    var dhc = host.InternalController as DockHostController;
                    if (dhc != null)
                    {
                        DockInfo di = dhc.GetSerCurrentDI();
                        if (di != null)
                        {

                            Rectangle r;

                            if (dhc.bInAutoHide)
                            {
                                r = dhc.DINew.rcDockArea;
                            }
                            else
                            {
                                r = dhc.LayoutRect;
                            }

                            Debug.Print("Child host count: " + dhc.ChildHostCount);

                            Debug.Print("Controller name: " + di.ControlleName);
                            Debug.Print("Style: " + di.dStyle);
                            Debug.Print("x: {0}; y: {1}; w: {2}; h: {3}", r.X, r.Y, r.Width, r.Height);
                            //Debug.Print("x: {0}; y: {1}; w: {2}; h: {3}", r2.X, r2.Y, r2.Width, r2.Height);
                            Debug.Print("Priority: " + di.nPriority);
                            Debug.Print("DockIndex: " + di.nDockIndex);
                        }
                    }
                }

                //if (!visible)
                //{
                //    panel.Visible = false;
                //}

                //if (hidden)
                //{
                //    panel.Hidden = true;
                //}

                Debug.Print("--------------");
            }

            panels.Unlock();
        }
    }
}
