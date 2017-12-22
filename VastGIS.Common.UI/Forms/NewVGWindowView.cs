using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using VastGIS.Common.Plugins.Mvp;
using VastGIS.Common.UI.Properties;
using Action = System.Action;

namespace VastGIS.Common.UI.Forms
{
#if STYLE2010
    public partial class MapWindowView : Office2010Form, IViewInternal
#else
    public partial class NewVGWindowView : RibbonForm, IViewInternal
#endif
    {
        public event Action OkClicked;

        protected NewVGWindowView()
        {
            //Logger.Current.Trace("Start MapWindowView");
            //Logger.Current.Trace("Start MapWindowView.InitializeComponent()");
            InitializeComponent();
            //Logger.Current.Trace("End MapWindowView.InitializeComponent()");
            Icon = Resources.MapWindow;
#if STYLE2010
            ApplyAeroTheme = false;
            UseOffice2010SchemeBackColor = true;
#endif
            //Logger.Current.Trace("End MapWindowView");
        }

        protected void Invoke(Action action)
        {
            if (action != null)
            {
                action();
            }
        }

        public virtual void ShowView(IWin32Window parent = null)
        {
            if (!Visible)
            {
                AppViewFactory.Instance.ShowChildView(this, parent);
            }
        }

        public virtual ViewStyle Style
        {
            get
            {
                return new ViewStyle()
                           {
                               Modal = true,
                               Sizable = false,
                           };
            }
        }

        public virtual void BeforeClose()
        {
            // default implementation; can be overriden in child classes
        }

        public virtual void UpdateView()
        {
            // default implementation; can be overriden in child classes
        }

        protected void FireOkClicked()
        {
            Invoke(OkClicked);
        }

        public void StartWait()
        {
            Cursor = Cursors.WaitCursor;

            EnableControls(false);

            Application.DoEvents();
        }

        public void StopWait()
        {
            Cursor = Cursors.Default;

            EnableControls(true);

            Application.DoEvents();
        }

        private void EnableControls(bool state)
        {
            foreach (Control ctrl in Controls)
            {
                ctrl.Enabled = state;
            }
        }

        public Form AsForm
        {
            get { return this; }
        }

        private void MapWindowView_Load(object sender, EventArgs e)
        {
            // Fixing CORE-160
            //CaptionFont = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }
    }
}
