using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VastGIS.Common.Api.Enums;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Events;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Mvp;
using VastGIS.Common.Shared;
using VastGIS.Common.UI.Forms;
using VastGIS.Common.UI.Helpers;
using VastGIS.RealEstateDB.Forms;


namespace VastGIS.RealEstateDB.Views
{
    public partial class NewMainView : NewVGWindowView,IMainView
    {
        public const string SerializationKey = ""; // intentionally empty
        private const string WindowTitle = "移动地理信息平台-Windows版-未见空间";
        private readonly IAppContext _context;
        private bool _locked;
        private bool _rendered;
        private IView _view;

        public NewMainView(IAppContext context)
        {
            Logger.Current.Trace("启动主界面");
            _context = context;

            Logger.Current.Trace("开始初始化界面");
            InitializeComponent();
            Logger.Current.Trace("结束界面初始化");

            statusStripEx1.Items.Clear();
            statusStripEx1.Refresh();

            ToolTipHelper.Init(superToolTip1);

            FormClosing += NewMainView_FormClosing;

            // setting bar item text before form is shown results in creation of duplicated bar item;
            // it seems it's a bug in Syncfusion's XpMenus
            Shown += (s, e) =>
                {
                    _rendered = true;

                   // UpdateView();

                   // ForceTaskBarDisplay();
                };
            Logger.Current.Trace("End MainView");
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x00040000; // Turn on WS_EX_APPWINDOW
                return cp;
            }
        }

        

        public event EventHandler<CancelEventArgs> ViewClosing;

        public event EventHandler<RenderedEventArgs> ViewUpdating;

        public event Action BeforeShow;

        public void Lock()
        {
            _locked = true;
        }

        public void Unlock()
        {
            _locked = false;
            UpdateView();
        }

        private bool FireViewClosing()
        {
            var handler = ViewClosing;
            if (handler != null)
            {
                var args = new CancelEventArgs();
                handler(this, args);
                if (args.Cancel)
                {
                    return false;
                }
            }
            return true;
        }

        private void FireViewUpdating(bool rendered)
        {
            var handler = ViewUpdating;
            if (handler != null)
            {
                handler(this, new RenderedEventArgs { Rendered = rendered });
            }
        }

        private void ForceTaskBarDisplay()
        {
            // I found no better solution. There several similar issues reported 
            // but no explanation as to why it happens or any clean way to fix it.
            // http ://stackoverflow.com/questions/18701186/form-is-not-visible-on-taskbar
            // http ://stackoverflow.com/questions/6937183/application-not-visible-in-taskbar-when-using-application-run
            // http ://stackoverflow.com/questions/4183809/main-form-not-shown-in-taskbar
            // In theory form should appear in task bar when WS_EX_APPWINDOW is set or it's top level unowned form plus ShowInTaskBar 
            // is not set to false manually. All these conditions are met in our case.
            // http ://stackoverflow.com/questions/8204397/what-does-ws-ex-appwindow-do
            using (
                var form = new Form
                               {
                                   Width = 0,
                                   Height = 0,
                                   Left = -500,
                                   Top = 0,
                                   StartPosition = FormStartPosition.Manual
                               })
            {
                form.Show(this);
                form.Close();
            }
        }

        private void NewMainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            // if there are hidden child forms which override FormClosing
            // the initial value is set to true: https ://msdn.microsoft.com/en-us/library/system.windows.forms.form.formclosing%28v=vs.110%29.aspx
            // currently it may be the case with non-modal Find / Replace form in the table editor
            e.Cancel = false;

            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                return;
            }

            if (!FireViewClosing())
            {
                e.Cancel = true;
            }
            else
            {
                
                _dockingManager1.SaveLayout(SerializationKey, false);
                //_mainFrameBarManager1.SaveLayout(SerializationKey, false);
            }
        }
        #region IView implementation
        private void RestorePreviousState()
        {
            _dockingManager1.TryRestoreLayout(SerializationKey);
            //_mainFrameBarManager1.TryRestoreLayout(SerializationKey);
        }

        public override void ShowView(IWin32Window parent = null)
        {
            RestorePreviousState();

            //DockPanelHelper.ClosePanel(_context, DockPanelKeys.TableEditor);
            //DockPanelHelper.ClosePanel(_context, DockPanelKeys.Tasks);

            Program.Timer.Stop();
            Logger.Current.Info("Loading time: " + Program.Timer.Elapsed);

            SplashView.Instance.Close();

            _context.DockPanels.Unlock();

          
            statusStripEx1.ContextMenuStrip.Opening += OnStatusBarCustomizationMenuOpening;

            Invoke(BeforeShow);

            AppConfig.Instance.FirstRun = false;

            Show();

            Activate();

            Application.Run(this);
        }

        private void UpdateStatusBarCustomizationMenu()
        {
            //var hash = new HashSet<string>
            //               {
            //                   StatusBarKeys.TileProvider,
            //                   StatusBarKeys.MapScale,
            //                   StatusBarKeys.MapUnits,
            //                   StatusBarKeys.ProjectionDropDown
            //               };
            //try
            //{
            //    foreach (ToolStripItem item in statusStripEx1.ContextMenuStrip.Items)
            //    {
            //        var status = ReflectionHelper.GetInstanceField(item, "m_item") as ToolStripItem;
            //        if (status == null)
            //        {
            //            item.Visible = false;
            //            continue;
            //        }

            //        var metadata = status.Tag as MenuItemMetadata;

            //        if (metadata != null && hash.Contains(metadata.Key))
            //        {
            //            item.Text = StatusBarKeys.GetStatusItemName(metadata.Key);
            //            item.Visible = true;
            //            continue;
            //        }

            //        item.Visible = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger.Current.Warn("Failed to update status bar customization menu.", ex);
            //}
        }

        private void OnStatusBarCustomizationMenuOpening(object sender, CancelEventArgs e)
        {
            UpdateStatusBarCustomizationMenu();
        }

        private string GetCaption()
        {
            string caption = WindowTitle;

            if (!_context.Project.IsEmpty)
            {
                caption += @" - " + _context.Project.Filename;
            }

            return caption;
        }

        public void DoUpdateView(bool focusMap = true)
        {
            if (_locked) return;

            Text = GetCaption();

            // broadcast to plugins
            if (_rendered)
            {
              //  FireViewUpdating(_rendered);
            }

        
        }

        public override void UpdateView()
        {
            DoUpdateView();
        }

        public ButtonBase OkButton
        {
            get { return null; }
        }

        #endregion

        #region IMainView implementation

        public object DockingManager
        {
            get { return _dockingManager1; }
        }

        public object MenuManager
        {
            get { return null; }
        }

        public object StatusBar
        {
            get { return statusStripEx1; }
        }

       

       

        public object RibbonControlAdv
        {
            get { return ribbonControlAdv1; }
        }
        public IView View
        {
            get { return this; }
        }

        public MainViewType ViewType
        {
            get { return MainViewType.Ribbon; }
        }
        #endregion
    }
}
